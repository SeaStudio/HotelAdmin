﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelBLL;
using HotelModel;

namespace HotelAdmin
{
    public partial class RoomRegulate : Form
    {
        DataTable dt = new DataTable();//暂时保存数据
        RoomTypeManager rtm = new RoomTypeManager();
        MoreTableManager mtm = new MoreTableManager();
        public RoomRegulate()
        {
            InitializeComponent();
            dgvRoom.AutoGenerateColumns = false;
            dgvUser.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 窗体加载时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomRegulate_Load(object sender, EventArgs e)
        {
            //添加树形菜单内容
            DataTable dt = rtm.TypeTable();

            foreach (DataRow item in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = item["Name"].ToString().Trim();
                tn.Tag = item;

                tvCaiDan.Nodes[0].Nodes.Add(tn);
            }
        }

        /// <summary>
        /// 选中房间类型显示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvCaiDan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvCaiDan.SelectedNode == null)
            {
                return;
            }

            if (tvCaiDan.SelectedNode.Level == 0)
            {
                DataTable dt = mtm.MoreMore();
                dgvRoom.DataSource = dt;
            }
            else if (tvCaiDan.SelectedNode.Level == 1)
            {
                DataTable dt = mtm.MoreMore(tvCaiDan.SelectedNode.Text);
                dgvRoom.DataSource = dt;
            }
        }

        /// <summary>
        /// 选中查看用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRoom.SelectedRows.Count == 0)
            {
                return;
            }

            dgvUser.DataSource = mtm.MoreMore(dgvRoom.SelectedRows[0].Cells[0].Value.ToString());
                
            
        }
    }
}
