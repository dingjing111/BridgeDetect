using BridgeDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.service
{
  public static class RecreateRecordManager
    {
        private static DBHelper dbHelper = DBHelper.GetInstance();

        /// <summary>
        ///1 重建用户表
        /// </summary>
        public static void RecreateUserManagerTable()
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
        public static void RecreateAlarmRecord()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.AlarmRecord', 'U') IS NOT NULL 
                                        DROP TABLE dbo.AlarmRecord; ");
            dbHelper.ExecuteNonQuery(
                @"create table AlarmRecord
                (guid uniqueidentifier NOT NULL,
	             time datetime NULL,
	             warntype nvarchar(50) NULL,
	             operator nvarchar(50) NULL,
                )");
        }
        /// <summary>
        ///3 重建锚杆力的表
        /// </summary>
        public static void RecreateAnchorForce()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.AnchorForce', 'U') IS NOT NULL 
                                        DROP TABLE dbo.AnchorForce; ");
            dbHelper.ExecuteNonQuery(
                @"create table AnchorForce
                ([guid] [uniqueidentifier] NOT NULL,
	             [time] [datetime] NULL,
	             [operator] [nvarchar](50) NULL,
	             [position1] [real] NULL,
	             [position2] [real] NULL,
	             [position3] [real] NULL,
	             [position4] [real] NULL,	            
                )");
        }
        /// <summary>
        ///4 重建前支点位移表
        /// </summary>
        public static void RecreateFrontPivotDis()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.FrontPivotDis', 'U') IS NOT NULL 
                                        DROP TABLE dbo.FrontPivotDis; ");
            dbHelper.ExecuteNonQuery(
                @"create table FrontPivotDis
                ([guid] [uniqueidentifier] NOT NULL,
	             [time] [datetime] NULL,
	             [operator] [nvarchar](50) NULL,
	             [position1] [real] NULL,
	             [position2] [real] NULL,
                )");
        }
        /// <summary>
        /// 5重建吊杆位移表
        /// </summary>
        public static void RecreateSteeveDisplacement()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.SteeveDisplacement', 'U') IS NOT NULL 
                                        DROP TABLE dbo.SteeveDisplacement; ");
            dbHelper.ExecuteNonQuery(
                @"create table SteeveDisplacement
                ([guid] [uniqueidentifier] NOT NULL,
	                [time] [datetime] NULL,
	                [operator] [nvarchar](50) NULL,
	                [position1] [real] NULL,
	                [position2] [real] NULL,
	                [position3] [real] NULL,
	                [position4] [real] NULL,	
                )");
        }
        /// <summary>
        /// 6.重建吊杆力表
        /// </summary>
        public static void RecreateSteeveForce()
        {
            dbHelper.ExecuteNonQuery(@"IF OBJECT_ID('dbo.SteeveForce', 'U') IS NOT NULL 
                                        DROP TABLE dbo.SteeveForce; ");
            dbHelper.ExecuteNonQuery(
                @"create table SteeveForce
                ([guid] [uniqueidentifier] NOT NULL,
	            [time] [datetime] NULL,
	            [operator] [nvarchar](50) NULL,
	            [position1] [real] NULL,
	            [position2] [real] NULL,
	            [position3] [real] NULL,
	            [position4] [real] NULL,
                )");

        }

        public static void InitialDataBase()
        {
            RecreateUserManagerTable();
            RecreateSteeveForce();
            RecreateSteeveDisplacement();
            RecreateAnchorForce();
            RecreateFrontPivotDis();
            RecreateAlarmRecord();
        }
    }
}
