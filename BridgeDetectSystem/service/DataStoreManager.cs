﻿using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BridgeDetectSystem.service
{
   public class DataStoreManager
    {  System.Threading.Timer StoreTimer { get; set; }
        
        DBHelper dbhelper = DBHelper.GetInstance();
        AdamHelper adamHelper = AdamHelper.GetInstance();
        string name = UserRightManager.user.userName;//得到操作人的名字
        /// <summary>
        /// 将吊杆数据，力和位移存入数据库
        /// </summary>
        public void InsertSteeveData()
        {
           
            Dictionary<int, Steeve> dicSteeve = adamHelper.steeveDic;       //吊杆
            string sqlSteeveForce = string.Format("insert into SteeveForce values(newid(),getdate(),'{0}',{1},{2},{3},{4})", name,dicSteeve[0].GetForce(), dicSteeve[1].GetForce(), dicSteeve[2].GetForce(), dicSteeve[3].GetForce());                      //吊杆力
            string sqlSteeveDis= string.Format("insert into SteeveDisplacement values(newid(),getdate(),'{0}',{1},{2},{3},{4})", name, dicSteeve[0].GetDisplace(), dicSteeve[1].GetDisplace(), dicSteeve[2].GetDisplace(), dicSteeve[3].GetDisplace());          //吊杆位移
            try
            {
                int r1 = dbhelper.ExecuteNonQuery(sqlSteeveForce);
                int r2 = dbhelper.ExecuteNonQuery(sqlSteeveDis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "数据存入数据库发生错误");
            }
        }
        /// <summary>
        /// 将锚杆力记录存入数据库
        /// </summary>
        public void InsertAnchorData()
        {
            Dictionary<int, Anchor> dicAnchor = adamHelper.anchorDic;
            string sql= string.Format("insert into AnchorForce values(newid(),getdate(),'{0}',{1},{2},{3},{4})", name, dicAnchor[0].GetForce(), dicAnchor[1].GetForce(), dicAnchor[2].GetForce(), dicAnchor[3].GetForce());
            try
            {
                int r= dbhelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "数据存入数据库发生错误");
            }
        }
        /// <summary>
        /// 将前支点位移存入数据库
        /// </summary>
        public void InsertFrontPivotDis()
        {
            Dictionary<int, FrontPivot> dicFrontPivot = adamHelper.frontPivotDic;
            string sql = string.Format("insert into FrontPivotDis values(newid(),getdate(),'{0}',{1},{2})", name, dicFrontPivot[0].GetDisplace(), dicFrontPivot[1].GetDisplace());
            try
            {
                int r = dbhelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "数据存入数据库发生错误");
            }

        }
        /// <summary>
        /// 指定时间间隔插入数据到数据库
        /// </summary>
        public void storeData()
        {

            StoreTimer = new System.Threading.Timer(_ =>
            {
                try
                {
                    InsertSteeveData();
                    InsertAnchorData();
                    InsertFrontPivotDis();
                }
                catch (Exception ex)
                {
                  StoreTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    throw ex;
                }
            }, null, 0, 1000);
        }
    }
}
