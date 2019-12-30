using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BridgeDetectSystem.util;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace BridgeDetectSystem.service
{
    public class ConfigManager
    {
        #region Singletom

        private DBHelper dbHelper;

        private ConfigManager(DBHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        private static volatile ConfigManager instance = null;
        /// <summary>使用DbHelper类的实例初始化唯一的ConfigManager实例。重复调用会抛出异常。</summary>
        public static ConfigManager Initialize(DBHelper dbHelper, bool loadFromDB)
        {
            if (instance != null)
            {
                throw new ConfigManagerException("Trying to initialize ConfigManager while its instance already exists.");
            }

            instance = new ConfigManager(dbHelper);
            if (loadFromDB)
            {
                try
                {
                    instance.LoadConfigFromDb();
                    Debug.WriteLine("[ConfigManager.LoadConfigFromDb] Last config loaded.");
                }
                catch (ConfigManagerException ex)
                {
                    Debug.WriteLine("[ConfigManager.LoadConfigFromDb] last config loaded");
                    Debug.WriteLine("[ConfigManager.LoadConfigFromDb] Default config loaded.");
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            return instance;
        }

        public static ConfigManager Initialize(DBHelper dbHelper)
        {
            return Initialize(dbHelper, true);
        }

        /// <summary>获取唯一的ConfigManager实例。在初始化之前调用会抛出异常。</summary>
        public static ConfigManager GetInstance()
        {
            if (instance == null)
            {
                throw new ConfigManagerException("Trying to get ConfigManager instance before initialization. Use ConfigManager.Initialize() first.");
            }
            return instance;
        }

        #endregion

        #region Config fields

        /// <summary>所有设备配置的名称枚举。可作为Get(key)等方法的key使用。</summary>
        public enum ConfigKeys
        {
            //挂篮
            basket_upDisLimit,
            basket_downDisLimit,
            basket_allowDisDiffLimit,//单根吊杆位移上限
            
            //吊杆
            steeve_DisDiffLimit,//吊杆位移差
            steeve_ForceLimit,
            steeve_ForceDiffLimit,
            //锚杆
            anchor_ForceLimit,
            anchor_ForceDiffLimit,
            //前支点
            frontPivot_DisLimit,
        }

        /// <summary>
        /// 代表配置的一项。
        ///     readableName: 可读的配置描述
        ///     minValue: 最小值
        ///     maxValue: 最大值
        ///     defaultValue: 未设置时的默认值
        ///     value: 当前值
        ///     UNSET_VALUE：未设置时的value
        /// </summary>
        public class ConfigItem
        {
            public const int UNSET_VALUE = -1;
            public string readableName { get; private set; }
            public double minValue { get; private set; }
            public double maxValue { get; private set; }
            public double defaultValue { get; private set; }
            public double value { get; set; }
            public ConfigItem(string readableName, double minValue, double maxValue, double defaultValue)
            {
                this.readableName = readableName;
                this.minValue = minValue;
                this.maxValue = maxValue;
                this.defaultValue = defaultValue;
                this.value = defaultValue;
            }
        }

        /// <summary>当前的配置项集合</summary>
        private Dictionary<ConfigKeys, ConfigItem> configItems = GetInitialConfig();

        /// <summary>获取一套完整的初始配置</summary>
        private static Dictionary<ConfigKeys, ConfigItem> GetInitialConfig()
        {
            var config = new Dictionary<ConfigKeys, ConfigItem>()
            {
                 //配置项                                                    min  max  default
                {ConfigKeys.basket_upDisLimit,new ConfigItem("挂篮上升位移", 0, 10000, 3000 ) },
                {ConfigKeys.basket_downDisLimit,new ConfigItem("挂篮下降位移", 0, 10000, 3000 ) },
                {ConfigKeys.basket_allowDisDiffLimit,new ConfigItem("挂篮位移允许误差", 0, 10000, 3000 ) },

                {ConfigKeys.steeve_DisDiffLimit,new ConfigItem("吊杆位移差值上限", 0, 10000, 3000 ) },
                {ConfigKeys.steeve_ForceLimit,new ConfigItem("吊杆受力上限", 0, 300, 250 ) },
                {ConfigKeys.steeve_ForceDiffLimit,new ConfigItem("吊杆力差值上限", 0, 10000, 250 ) },

                {ConfigKeys.anchor_ForceLimit,new ConfigItem("锚杆力上限", 0, 10000, 8000 ) },
                {ConfigKeys.anchor_ForceDiffLimit,new ConfigItem("锚杆力差值上限", 0, 10000, 8000 ) },
                {ConfigKeys.frontPivot_DisLimit,new ConfigItem("前支点位移上限", 0, 10000, 10 ) },

            };

            return config;
        }

        /// <summary>
        /// 检查一套配置的完整性。
        /// 如果配置已经完整(值都已经设置)（所有枚举ConfigKeys中的值都存在于字典config中），返回true，否则返回false
        /// </summary>
        private static bool CheckIntegrety(Dictionary<ConfigKeys,ConfigItem> config,out ConfigKeys missingKey)
        {
            foreach(ConfigKeys configKey in Enum.GetValues(typeof(ConfigKeys)))
            {
                if(config[configKey].value== ConfigItem.UNSET_VALUE)
                {
                    Debug.WriteLine("[ConfigManager.CheckIntegrety]Missing key: " + configKey.ToString());
                    missingKey = configKey;
                    return false;
                }
            }
            missingKey = 0;
            return true;
        }

        /// <summary>按key获取一个配置项。找不到则抛出异常。</summary>
        /// <param name="key">要获取的配置项的key</param>
        private ConfigItem GetItem(ConfigKeys key)
        {
            ConfigItem item;
            if (configItems.TryGetValue(key, out item))
            {
                return item;
            }
            else
            {
                throw new ConfigManagerException("[ConfigManager.GetItem] Cannot find config with key: " + key.ToString());
            }
        }

        /// <summary>
        /// 设置一个配置项。值不在该配置项的合法范围内将抛出异常。
        /// </summary>
        /// <param name="key">要设置的配置项</param>
        /// <param name="value">要设置的值</param>
        public void Set(ConfigKeys key, double value)
        {
            ConfigItem item = this.GetItem(key);

            if (!IsValueValid(key, value))
            {
                throw new ConfigManagerException(String.Format("[ConfigManager.Set] New value {0} is not in valid range({1}~{2})", value, item.minValue, item.maxValue));
            }

            item.value = value;
        }

        /// <summary>获取一个配置项的值。</summary>
        public double Get(ConfigKeys key)
        {
            return this.GetItem(key).value;
        }

        /// <summary>获取一个配置项的描述文本</summary>
        public string GetReadableName(ConfigKeys key)
        {
            return this.GetItem(key).readableName;
        }

        /// <summary>获取一个配置项的最小值</summary>
        public double GetMinValue(ConfigKeys key)
        {
            return this.GetItem(key).minValue;
        }

        /// <summary>获取一个配置项的最大值</summary>
        public double GetMaxValue(ConfigKeys key)
        {
            return this.GetItem(key).maxValue;
        }

        /// <summary>检查某值是否在某配置项的合法范围内，在则返回true，否则返回false</summary>
        public bool IsValueValid(ConfigKeys key, double valueToCheck)
        {
            ConfigItem item = GetItem(key);
            if (valueToCheck < item.minValue || valueToCheck > item.maxValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Database function
        
        /// <summary>重建数据库中的config表。</summary>
        public void RecreateDbTable()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.config', 'U') IS NOT NULL 
                                        DROP TABLE dbo.config; ");
            dbHelper.ExecuteNonQuery(
                @"create table config
                (
                    name varchar(30) primary key,
                    value real not null
                )");
        }


        /// <summary>从数据库的config表中读取配置。如配置不完整则抛出异常。</summary>
        public void LoadConfigFromDb()
        {
            SqlDataReader reader = dbHelper.ExecuteReader(@"SELECT * FROM config");
            var tempConfig = GetInitialConfig();
            while (reader.Read())
            {
                string key = reader.GetValue(0).ToString();
                ConfigKeys configKey;
                if (Enum.TryParse(key, false, out configKey) == false)
                {
                    throw new ConfigManagerException("[LoadConfigFromDb] Unknown config key: " + key);
                }
                double value = (float)reader.GetValue(1);
                tempConfig[configKey].value = value;
            }
            reader.Close();
            ConfigKeys missingKey;
            if (CheckIntegrety(tempConfig, out missingKey) == true)
            {
                this.configItems = tempConfig;
                Debug.WriteLine("[LoadConfigFromDb] Config updated.");
            }
            else
            {
                throw new ConfigManagerException("[LoadConfigFromDb] New config is broken. No changes applied. Missing key: " + missingKey.ToString());
            }
        }

        /// <summary>将配置写到数据库的config表中。当前配置不完整则抛出异常。</summary>
        public void StoreConfigToDb()
        {
            ConfigKeys missingKey;
            if (CheckIntegrety(configItems, out missingKey) == false)
            {
                throw new ConfigManagerException("[StoreConfigToDb] Current config is broken. No changes applied. Missing key: " + missingKey.ToString());
            }
            dbHelper.ExecuteNonQuery(@"DELETE FROM config");
            List<KeyValuePair<string, double>> values = new List<KeyValuePair<string, double>>();
            foreach (ConfigKeys key in Enum.GetValues(typeof(ConfigKeys)))
            {
                values.Add(new KeyValuePair<string, double>(key.ToString(), this.Get(key)));
            }

            StringBuilder sql =new StringBuilder(@"INSERT INTO config (name, value) VALUES ");

            for (int i = 0; i < values.Count; i++)
            {
                sql.Append("( ");
                sql.AppendFormat("'{0}','{1}'", values[i].Key, values[i].Value);
                sql.Append(")");
                if (i < values.Count - 1)
                {
                    sql.Append(",");
                }
            }
            int affected = dbHelper.ExecuteNonQuery(sql.ToString());
            Debug.WriteLine("[StoreConfigToDb] " + affected.ToString() + " rows affected.");
        }

        #endregion

        //public double upDisLimit { get; set; }
        //public double downDisLimit { get; set; }
        //public double allowDisDiffLimit { get; set; }

        //public double steeveDisDiffLimit { get; set; }
        //public double steeveForceUpLimit { get; set; }
        //public double steeveForceDiffLimit { get; set; }
        //public double anchorForceLimit { get; set; }
        //public double anchorForceDiffLimit { get; set; }
        //public double frontPivotDisLimit { get; set; }

    }

    public class ConfigManagerException : Exception
    {
        public ConfigManagerException(string message) : base(message) { }
        public ConfigManagerException(string message, Exception inner) : base(message, inner) { }
    }

}
