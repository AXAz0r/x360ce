﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using x360ce.Engine.Data;

namespace x360ce.App.Controls
{
	public partial class ControllersUserControl : UserControl
	{
		public ControllersUserControl()
		{
			InitializeComponent();
		}

		private void ControllersUserControl_Load(object sender, EventArgs e)
		{
			UpdateButtons();
			ControllersDataGridView.AutoGenerateColumns = false;
			ControllersDataGridView.DataSource = SettingManager.UserControllers.Items;
		}

		private void ControllersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			var grid = (DataGridView)sender;
			var item = ((UserController)grid.Rows[e.RowIndex].DataBoundItem);
			if (e.ColumnIndex == grid.Columns[MyIconColumn.Name].Index)
			{
				e.Value = item.IsOnline
					? Properties.Resources.bullet_square_glass_green
					: Properties.Resources.bullet_square_glass_grey;
			}
		}

		public List<UserController> GetSelected()
		{
			var grid = ControllersDataGridView;
			var items = grid.SelectedRows.Cast<DataGridViewRow>().Select(x => (UserController)x.DataBoundItem).ToList();
			return items;
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			ControllersDataGridView.Invalidate();
		}

		private void ControllerDeleteButton_Click(object sender, EventArgs e)
		{
			var items = GetSelected();
			foreach (var item in items)
			{
				SettingManager.UserControllers.Items.Remove(item);
			}
		}

		private void ControllersDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			UpdateButtons();
		}

		void UpdateButtons()
		{
			var grid = ControllersDataGridView;
			ControllerDeleteButton.Enabled = grid.SelectedRows.Count > 0;
		}

	}
}
