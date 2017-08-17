using System;
using System.Data;
using System.Windows.Forms;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.util;

namespace BridgeDetectSystem
{
    public partial class UserRightWin : MetroFramework.Forms.MetroForm
    {
        public UserRightWin()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            this.initial();
            this.LoadUserManager();//加载表
        }

        #region 初始化窗体
        private void initial()
        {
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;//窗体与屏幕一样大
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.panel2.Height = this.panel1.Height * 8 / 10;
            this.panel4.Height = this.panel1.Height / 15;
        }
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddAndUpdate(1);
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                User user = new User();
                user.phid = dgvUser.SelectedRows[0].Cells[0].Value.ToString();
                user.userName = dgvUser.SelectedRows[0].Cells[1].Value.ToString();
                user.password = dgvUser.SelectedRows[0].Cells[2].Value.ToString();
                user.rightLevel = Convert.ToInt32(dgvUser.SelectedRows[0].Cells[3].Value);
                mea.obj = user;
                ShowAddAndUpdate(2);
            }
            else
            {
                MessageBox.Show("如果要修改请先选中修改的行");
            }
          
        }
        /// <summary>
        /// 加载用户权限的表
        /// </summary>
        private void LoadUserManager()
        {
            DBHelper dbhelper = DBHelper.GetInstance();
            string sql = "select * from UserManager";
            //SqlDataReader reader = dbhelper.ExecuteReader(sql);
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            dgvUser.DataSource = dt;
            dgvUser.AutoGenerateColumns = false;
            
           // dgvUser.SelectedRows[0].Selected = false;
            dgvUser.Invalidate();

        }

        private void dgvUser_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        public event EventHandler evt;

        MyEventArgs mea = new MyEventArgs();
        /// <summary>
        /// 生成新增或修改窗口   
        /// </summary>
        /// <param name="p">标识 1，新增。。。2，修改窗口。。</param>
        public void ShowAddAndUpdate(int p)
        {
            AddAndUpdateUser sau = new AddAndUpdateUser();
            this.evt += new EventHandler(sau.SetText);
            mea.Temp = p;
            if (this.evt != null)
            {
                this.evt(this, mea);
                sau.FormClosed += new FormClosedEventHandler(sau_FormClosed);
                sau.ShowDialog();
            }

        }
        void sau_FormClosed(object sender,FormClosedEventArgs e)
        {
            LoadUserManager();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count > 0)
            {
                int r = -1;
                // Stu student = new Stu();
                DBHelper dbhelper = DBHelper.GetInstance();
                string idstr = dgvUser.SelectedRows[0].Cells[0].Value.ToString();
                int id = Convert.ToInt32(idstr);
                string sql = "delete from UserManager where phid=" + id;
                r= dbhelper.ExecuteNonQuery(sql);
                string msg = r > 0 ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                string sql2 = "select * from UserManager";
                DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql2, null, 0);
                dgvUser.DataSource = dt;
                dgvUser.Invalidate();
            }
        }
    }
}
