﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelModel;

namespace HotelDAL
{
    /// <summary>
    /// 顾客数据处理
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 查询指定或全部的顾客信息 (支持模糊查询)
        /// </summary>
        /// <param name="name">要查询的顾客姓名</param>
        /// <returns>返回满足条件的顾客信息</returns>
        public DataTable SeeUserRecord(string name)
        {
            // 搜索系统临时数据库中满足名称条件的顾客信息
            var table = from row in HotelData.Data.Tables["UserTable"].AsEnumerable()
                        where row["UserName"].ToString().Contains(name)
                        select row;

            return table.CopyToDataTable();                             // 返回得到的记录
        }
        /// <summary>
        /// 查询指定顾客的消费记录
        /// </summary>
        /// <param name="idCard">顾客身份证</param>
        /// <returns>返回指定的顾客消费列表</returns>
        public DataTable GetConsumeRecord(string idCard)
        {
            // 查询系统临时数据库中指定顾客的消费记录
            var table = from row in HotelData.Data.Tables["ConsumptionRecord"].AsEnumerable()
                        where row["IDCard"].Equals(idCard)
                        select row;

            return table.CopyToDataTable();                             // 返回得到的记录
        }
        /// <summary>
        /// 删除指定的顾客信息
        /// </summary>
        /// <param name="IDCard">顾客身份证</param>
        public void DeleteUserRecord(string IDCard)
        {
            // 遍历系统临时数据库搜索满足条件的记录
            foreach (DataRow row in HotelData.Data.Tables["ConsumptionRecord"].Rows)
            {
                if (IDCard.Equals(row["IDCard"])) {                     // 删除指定的顾客信息
                    HotelData.Data.Tables["ConsumptionRecord"].Rows.Remove(row);
                    break;
                }
            }
        }
        /// <summary>
        /// 修改指定的顾客信息 (修改时必须传入顾客的所有信息)
        /// </summary>
        /// <param name="user">更新信息</param>
        public void AmendUserRecord(UserTable user)
        {
            // 遍历系统临时数据库搜索满足条件的记录
            foreach (DataRow row in HotelData.Data.Tables["ConsumptionRecord"].Rows)
            {
                if (user.IDCard.Equals(row["IDCard"]))                  // 修改指定的顾客信息
                {
                    row[0] = user.UserName;
                    row[1] = user.IDCard;
                    row[2] = user.TelephoneNumber;
                    row[3] = user.Balance;
                    row[4] = user.Member;
                    row[5] = user.Gender;
                    row[6] = user.Age;
                    break;
                }
            }
        }
    }
}
