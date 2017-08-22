using BridgeDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.service
{
    class RecreateRecordManager
    {
        private DBHelper dbHelper = DBHelper.GetInstance();

        /// <summary>
        ///1 重建用户表
        /// </summary>
        public void RecreateUserManagerTable()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.UserManager', 'U') IS NOT NULL 
                                        DROP TABLE dbo.UserManager; ");
            dbHelper.ExecuteNonQuery(
                @"create table UserManager
                (phid int IDENTITY(1,1) NOT NULL,
	             userName nvarchar(50) NOT NULL,
	             password nvarchar(50) NOT NULL,
	             rightLevel int NOT NULL,
	             viewLog nvarchar(50) NULL,
	             parameterSet nvarchar(50) NULL,
	             systemSet nvarchar(50) NULL,
                )");
            dbHelper.ExecuteNonQuery("insert into UserManager values('admin','12345',3,'有','有','有')");
        }
        /// <summary>
        /// 2.重建报警记录表
        /// </summary>
        public void RecreateAlarmRecord()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.AlarmRecord', 'U') IS NOT NULL 
                                        DROP TABLE dbo.AlarmRecord; ");
            dbHelper.ExecuteNonQuery(
                @"create table AlarmRecord
                (GUId uniqueidentifier NOT NULL,
	             time datetime NULL,
	             warntype nvarchar(50) NULL,
	             operator nvarchar(50) NULL,
                )");
        }
        /// <summary>
        ///3 重建锚杆力的表
        /// </summary>
        public void RecreateAnchorForce()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.AnchorForce', 'U') IS NOT NULL 
                                        DROP TABLE dbo.AnchorForce; ");
            dbHelper.ExecuteNonQuery(
                @"create table AnchorForce
                ([GUId] [uniqueidentifier] NOT NULL,
	             [time] [datetime] NULL,
	             [operator] [nvarchar](50) NULL,
	             [position1] [real] NULL,
	             [position2] [real] NULL,
	             [position3] [real] NULL,
	             [position4] [real] NULL,
	             [position5] [real] NULL,
	             [position6] [real] NULL,
	             [position7] [real] NULL,
	             [position8] [real] NULL,
	             [position9] [real] NULL,
	             [position10] [real] NULL,
	             [position11] [real] NULL,
	             [position12] [real] NULL,
	             [position13] [real] NULL,
	             [position14] [real] NULL,
	             [position15] [real] NULL,
	             [position16] [real] NULL,
                )");
        }
        /// <summary>
        ///4 重建前支点位移表
        /// </summary>
        public void RecreateFrontPivotDis()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.FrontPivotDis', 'U') IS NOT NULL 
                                        DROP TABLE dbo.FrontPivotDis; ");
            dbHelper.ExecuteNonQuery(
                @"create table FrontPivotDis
                ([GUId] [uniqueidentifier] NOT NULL,
	             [time] [datetime] NULL,
	             [operator] [nvarchar](50) NULL,
	             [position1] [real] NULL,
	             [position2] [real] NULL,
                )");
        }
        /// <summary>
        /// 5重建吊杆位移表
        /// </summary>
        public void RecreateSteeveDisplacement()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.SteeveDisplacement', 'U') IS NOT NULL 
                                        DROP TABLE dbo.SteeveDisplacement; ");
            dbHelper.ExecuteNonQuery(
                @"create table SteeveDisplacement
                ([GUId] [uniqueidentifier] NOT NULL,
	[time] [datetime] NULL,
	[operator] [nvarchar](50) NULL,
	[position1] [real] NULL,
	[position2] [real] NULL,
	[position3] [real] NULL,
	[position4] [real] NULL,
	[position5] [real] NULL,
	[position6] [real] NULL,
	[position7] [real] NULL,
	[position8] [real] NULL,
	[position9] [real] NULL,
	[position10] [real] NULL,
	[position11] [real] NULL,
	[position12] [real] NULL,
	[position13] [real] NULL,
	[position14] [real] NULL,
	[position15] [real] NULL,
	[position16] [real] NULL,
                )");
        }
        /// <summary>
        /// 6.重建吊杆力表
        /// </summary>
        public void RecreateSteeveForce()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.SteeveForce', 'U') IS NOT NULL 
                                        DROP TABLE dbo.SteeveForce; ");
            dbHelper.ExecuteNonQuery(
                @"create table SteeveForce
                ([GUId] [uniqueidentifier] NOT NULL,
	[time] [datetime] NULL,
	[operator] [nvarchar](50) NULL,
	[position1] [real] NULL,
	[position2] [real] NULL,
	[position3] [real] NULL,
	[position4] [real] NULL,
	[position5] [real] NULL,
	[position6] [real] NULL,
	[position7] [real] NULL,
	[position8] [real] NULL,
	[position9] [real] NULL,
	[position10] [real] NULL,
	[position11] [real] NULL,
	[position12] [real] NULL,
	[position13] [real] NULL,
	[position14] [real] NULL,
	[position15] [real] NULL,
	[position16] [real] NULL,
                )");

        }
    }
}
