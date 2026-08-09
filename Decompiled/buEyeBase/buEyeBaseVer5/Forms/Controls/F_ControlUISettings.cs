using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUISettings : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_menubutton1;

	public ImageList IC32;

	public buButton btn_menubutton4;

	public buButton btn_menubutton3;

	public buButton btn_menubutton2;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buButton btn_systembutton4;

	public buButton btn_systembutton3;

	public buButton btn_systembutton2;

	public buButton btn_systembutton1;

	public buButton btn_commandbutton4;

	public buButton btn_commandbutton3;

	public buButton btn_commandbutton2;

	public buButton btn_commandbutton1;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buLabel buLabel_2;

	internal buLabel buLabel_3;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	public buCheckBox chk_4;

	public buCheckBox chk_3;

	public buCheckBox chk_2;

	public buSpin spn_4;

	public buSpin spn_3;

	public buSpin spn_2;

	public buCheckBox chk_1;

	public buSpin spn_1;

	internal buTextBox buTextBox_0;

	internal buTextBox buTextBox_1;

	internal buTextBox buTextBox_2;

	internal buTextBox buTextBox_3;

	internal buListBox buListBox_0;

	internal buListBox buListBox_1;

	internal buListBox buListBox_2;

	internal buListBox buListBox_3;

	internal DataGridView dataGridView_0;

	internal DataGridView dataGridView_1;

	public buButton btn_cancell;

	public buButton btn_okk;

	public buLabel lbl_coord1;

	public buLabel lbl_coord2;

	public buLabel lbl_coord1val;

	public buLabel lbl_coord2val;

	internal buLabel buLabel_4;

	public buButton btn_speedminus;

	public buButton btn_speedplus;

	public buSpin spn_speed;

	public buLabel lbl_speed;

	public buTrack track_speed;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal buLabel buLabel_5;

	internal PictureBox pictureBox_4;

	internal PictureBox pictureBox_5;

	internal PictureBox pictureBox_6;

	public buTrack track_2;

	public buTrack track_1;

	public buProgressBar Progress_1;

	internal PictureBox pictureBox_7;

	public buProgressBar Progress_2;

	internal buLabel buLabel_6;

	internal buLabel buLabel_7;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	internal PictureBox pictureBox_8;

	internal PictureBox pictureBox_9;

	internal buLabel buLabel_12;

	internal buLabel buLabel_13;

	internal PictureBox pictureBox_10;

	internal PictureBox pictureBox_11;

	internal buLabel buLabel_14;

	internal buLabel buLabel_15;

	internal buLabel buLabel_16;

	internal buGround buGround_0;

	internal buLabel buLabel_17;

	internal buLabel buLabel_18;

	internal buLabel buLabel_19;

	public buButton btn_on2;

	public buButton btn_on1;

	internal buComboBox buComboBox_0;

	internal buComboBox buComboBox_1;

	internal buComboBox buComboBox_2;

	internal buComboBox buComboBox_3;

	internal buLabel buLabel_20;

	internal buGroup buGroup_0;

	internal buGroup buGroup_1;

	internal buLabel buLabel_21;

	internal buGround buGround_1;

	internal buLabel buLabel_22;

	internal buLabel buLabel_23;

	internal buLabel buLabel_24;

	internal buLabel buLabel_25;

	internal buLabel buLabel_26;

	internal buLabel buLabel_27;

	internal PictureBox pictureBox_12;

	internal buLabel buLabel_28;

	internal TreeView treeView_0;

	internal TreeView treeView_1;

	public buButton btn_off1;

	public buButton btn_off2;

	internal buPanel buPanel_0;

	internal buPanel buPanel_1;

	internal buLabel buLabel_29;

	public F_ControlUISettings()
	{
		Class186.smethod_145(this);
		timer_0.Interval = 1000;
		timer_0.Tick += timer_0_Tick;
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		if (dataGridView_1.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 35;
			dataGridViewColumn.HeaderText = buLangTranslate.preDef.Number;
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_1.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = dataGridView_1.Width - 40;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Text;
			dataGridViewColumn2.Name = "Text";
			dataGridViewColumn2.ReadOnly = true;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_1.Columns.Add(dataGridViewColumn2);
			dataGridView_1.Rows.Add(Class186.smethod_341("DataGridView1", this, 1));
			dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Height = 12;
			dataGridView_1.Rows.Add(Class186.smethod_341("DataGridView1", this, 2));
			dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Height = 12;
		}
		if (dataGridView_0.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 35;
			dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Number;
			dataGridViewColumn3.Name = "No";
			dataGridViewColumn3.ReadOnly = true;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = dataGridView_0.Width - 40;
			dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Text;
			dataGridViewColumn4.Name = "Text";
			dataGridViewColumn4.ReadOnly = true;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView_0.Columns.Add(dataGridViewColumn4);
			dataGridView_0.Rows.Add(Class186.smethod_341("DataGridView2", this, 1));
			dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = 12;
			dataGridView_0.Rows.Add(Class186.smethod_341("DataGridView2", this, 2));
			dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Height = 12;
		}
		dataGridView_1.RowHeadersVisible = false;
		dataGridView_1.AllowUserToAddRows = false;
		dataGridView_1.AllowUserToResizeColumns = false;
		dataGridView_1.ColumnHeadersVisible = true;
		dataGridView_1.ColumnHeadersHeight = 8;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.ColumnHeadersVisible = true;
		dataGridView_0.ColumnHeadersHeight = 8;
		InitVisual();
		PropertiesForm.Result = DialogResult.None;
		timer_0.Enabled = true;
		Class186.smethod_179(this);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Apply()
	{
	}

	public void InitVisual()
	{
		FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
		if (fileInfo.Exists)
		{
			Control.ControlCollection controlCollection = null;
			controlCollection = buGround1.Controls;
			controlCollection = hmiUICommands.SetVisualItem(controlCollection);
		}
		PropertiesForm.VisualUpdated = true;
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			Control control = sender as Control;
			if (!(control.Name == btn_ok.Name))
			{
				if (!((control.Name == btn_close.Name) | (control.Name == btn_cancel.Name)))
				{
					if (!PropertiesForm.Inited)
					{
						return;
					}
					if (control.Name == btn_menubutton1.Name)
					{
						F_ControlUIButton f_ControlUIButton = new F_ControlUIButton();
						f_ControlUIButton.refButton = (buButton)buControlCommands.CloneControl(btn_menubutton1);
						f_ControlUIButton.refButton = buButton.CopyVisual(btn_menubutton1, f_ControlUIButton.refButton);
						f_ControlUIButton.Init();
						f_ControlUIButton.ShowDialog();
						if (f_ControlUIButton.PropertiesForm.Result == DialogResult.OK)
						{
							btn_menubutton1 = buButton.CopyVisual(f_ControlUIButton.refButton, btn_menubutton1);
							buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton.refButton.Display, buEyeVars.parVisual.hmiButtonMenu1.ButtonNormal);
							buEyeVars.parVisual.hmiButtonMenu1.ButtonOver = buControlDisplay.Copy(f_ControlUIButton.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonMenu1.ButtonOver);
							buEyeVars.parVisual.hmiButtonMenu1.ButtonDown = buControlDisplay.Copy(f_ControlUIButton.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonMenu1.ButtonDown);
							buEyeVars.parVisual.hmiButtonMenu1.Parameters.GeometryArcDiameer = f_ControlUIButton.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonMenu1.Parameters.GeometryType = f_ControlUIButton.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonMenu1.Parameters.ImageAlignment = f_ControlUIButton.refButton.ImageAlign;
						}
						f_ControlUIButton.Dispose();
					}
					if (control.Name == btn_menubutton2.Name)
					{
						F_ControlUIButton f_ControlUIButton2 = new F_ControlUIButton();
						f_ControlUIButton2.refButton = btn_menubutton2;
						f_ControlUIButton2.Init();
						f_ControlUIButton2.ShowDialog();
						if (f_ControlUIButton2.PropertiesForm.Result == DialogResult.OK)
						{
							btn_menubutton2 = buButton.CopyVisual(f_ControlUIButton2.refButton, btn_menubutton2);
							buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton2.refButton.Display, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal);
							buEyeVars.parVisual.hmiButtonMenu2.ButtonOver = buControlDisplay.Copy(f_ControlUIButton2.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonMenu2.ButtonOver);
							buEyeVars.parVisual.hmiButtonMenu2.ButtonDown = buControlDisplay.Copy(f_ControlUIButton2.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonMenu2.ButtonDown);
							buEyeVars.parVisual.hmiButtonMenu2.Parameters.GeometryArcDiameer = f_ControlUIButton2.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonMenu2.Parameters.GeometryType = f_ControlUIButton2.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonMenu2.Parameters.ImageAlignment = f_ControlUIButton2.refButton.ImageAlign;
						}
						f_ControlUIButton2.Dispose();
					}
					if (control.Name == btn_menubutton3.Name)
					{
						F_ControlUIButton f_ControlUIButton3 = new F_ControlUIButton();
						f_ControlUIButton3.refButton = btn_menubutton3;
						f_ControlUIButton3.Init();
						f_ControlUIButton3.ShowDialog();
						if (f_ControlUIButton3.PropertiesForm.Result == DialogResult.OK)
						{
							btn_menubutton3 = buButton.CopyVisual(f_ControlUIButton3.refButton, btn_menubutton3);
							buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton3.refButton.Display, buEyeVars.parVisual.hmiButtonMenu3.ButtonNormal);
							buEyeVars.parVisual.hmiButtonMenu3.ButtonOver = buControlDisplay.Copy(f_ControlUIButton3.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonMenu3.ButtonOver);
							buEyeVars.parVisual.hmiButtonMenu3.ButtonDown = buControlDisplay.Copy(f_ControlUIButton3.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonMenu3.ButtonDown);
							buEyeVars.parVisual.hmiButtonMenu3.Parameters.GeometryArcDiameer = f_ControlUIButton3.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonMenu3.Parameters.GeometryType = f_ControlUIButton3.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonMenu3.Parameters.ImageAlignment = f_ControlUIButton3.refButton.ImageAlign;
						}
						f_ControlUIButton3.Dispose();
					}
					if (control.Name == btn_menubutton4.Name)
					{
						F_ControlUIButton f_ControlUIButton4 = new F_ControlUIButton();
						f_ControlUIButton4.refButton = btn_menubutton4;
						f_ControlUIButton4.Init();
						f_ControlUIButton4.ShowDialog();
						if (f_ControlUIButton4.PropertiesForm.Result == DialogResult.OK)
						{
							btn_menubutton4 = buButton.CopyVisual(f_ControlUIButton4.refButton, btn_menubutton4);
							buEyeVars.parVisual.hmiButtonMenu4.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton4.refButton.Display, buEyeVars.parVisual.hmiButtonMenu4.ButtonNormal);
							buEyeVars.parVisual.hmiButtonMenu4.ButtonOver = buControlDisplay.Copy(f_ControlUIButton4.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonMenu4.ButtonOver);
							buEyeVars.parVisual.hmiButtonMenu4.ButtonDown = buControlDisplay.Copy(f_ControlUIButton4.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonMenu4.ButtonDown);
							buEyeVars.parVisual.hmiButtonMenu4.Parameters.GeometryArcDiameer = f_ControlUIButton4.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonMenu4.Parameters.GeometryType = f_ControlUIButton4.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonMenu4.Parameters.ImageAlignment = f_ControlUIButton4.refButton.ImageAlign;
						}
						f_ControlUIButton4.Dispose();
					}
					if (control.Name == btn_systembutton1.Name)
					{
						F_ControlUIButton f_ControlUIButton5 = new F_ControlUIButton();
						f_ControlUIButton5.refButton = btn_systembutton1;
						f_ControlUIButton5.Init();
						f_ControlUIButton5.ShowDialog();
						if (f_ControlUIButton5.PropertiesForm.Result == DialogResult.OK)
						{
							btn_systembutton1 = buButton.CopyVisual(f_ControlUIButton5.refButton, btn_systembutton1);
							buEyeVars.parVisual.hmiButtonSystem1.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton5.refButton.Display, buEyeVars.parVisual.hmiButtonSystem1.ButtonNormal);
							buEyeVars.parVisual.hmiButtonSystem1.ButtonOver = buControlDisplay.Copy(f_ControlUIButton5.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonSystem1.ButtonOver);
							buEyeVars.parVisual.hmiButtonSystem1.ButtonDown = buControlDisplay.Copy(f_ControlUIButton5.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonSystem1.ButtonDown);
							buEyeVars.parVisual.hmiButtonSystem1.Parameters.GeometryArcDiameer = f_ControlUIButton5.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonSystem1.Parameters.GeometryType = f_ControlUIButton5.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonSystem1.Parameters.ImageAlignment = f_ControlUIButton5.refButton.ImageAlign;
						}
						f_ControlUIButton5.Dispose();
					}
					if (control.Name == btn_systembutton2.Name)
					{
						F_ControlUIButton f_ControlUIButton6 = new F_ControlUIButton();
						f_ControlUIButton6.refButton = btn_systembutton2;
						f_ControlUIButton6.Init();
						f_ControlUIButton6.ShowDialog();
						if (f_ControlUIButton6.PropertiesForm.Result == DialogResult.OK)
						{
							btn_systembutton2 = buButton.CopyVisual(f_ControlUIButton6.refButton, btn_systembutton2);
							buEyeVars.parVisual.hmiButtonSystem2.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton6.refButton.Display, buEyeVars.parVisual.hmiButtonSystem2.ButtonNormal);
							buEyeVars.parVisual.hmiButtonSystem2.ButtonOver = buControlDisplay.Copy(f_ControlUIButton6.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonSystem2.ButtonOver);
							buEyeVars.parVisual.hmiButtonSystem2.ButtonDown = buControlDisplay.Copy(f_ControlUIButton6.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonSystem2.ButtonDown);
							buEyeVars.parVisual.hmiButtonSystem2.Parameters.GeometryArcDiameer = f_ControlUIButton6.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonSystem2.Parameters.GeometryType = f_ControlUIButton6.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonSystem2.Parameters.ImageAlignment = f_ControlUIButton6.refButton.ImageAlign;
						}
						f_ControlUIButton6.Dispose();
					}
					if (control.Name == btn_systembutton3.Name)
					{
						F_ControlUIButton f_ControlUIButton7 = new F_ControlUIButton();
						f_ControlUIButton7.refButton = btn_systembutton3;
						f_ControlUIButton7.Init();
						f_ControlUIButton7.ShowDialog();
						if (f_ControlUIButton7.PropertiesForm.Result == DialogResult.OK)
						{
							btn_systembutton3 = buButton.CopyVisual(f_ControlUIButton7.refButton, btn_systembutton3);
							buEyeVars.parVisual.hmiButtonSystem3.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton7.refButton.Display, buEyeVars.parVisual.hmiButtonSystem3.ButtonNormal);
							buEyeVars.parVisual.hmiButtonSystem3.ButtonOver = buControlDisplay.Copy(f_ControlUIButton7.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonSystem3.ButtonOver);
							buEyeVars.parVisual.hmiButtonSystem3.ButtonDown = buControlDisplay.Copy(f_ControlUIButton7.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonSystem3.ButtonDown);
							buEyeVars.parVisual.hmiButtonSystem3.Parameters.GeometryArcDiameer = f_ControlUIButton7.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonSystem3.Parameters.GeometryType = f_ControlUIButton7.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonSystem3.Parameters.ImageAlignment = f_ControlUIButton7.refButton.ImageAlign;
						}
						f_ControlUIButton7.Dispose();
					}
					if (control.Name == btn_systembutton4.Name)
					{
						F_ControlUIButton f_ControlUIButton8 = new F_ControlUIButton();
						f_ControlUIButton8.refButton = btn_systembutton4;
						f_ControlUIButton8.Init();
						f_ControlUIButton8.ShowDialog();
						if (f_ControlUIButton8.PropertiesForm.Result == DialogResult.OK)
						{
							btn_systembutton4 = buButton.CopyVisual(f_ControlUIButton8.refButton, btn_systembutton4);
							buEyeVars.parVisual.hmiButtonSystem4.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton8.refButton.Display, buEyeVars.parVisual.hmiButtonSystem4.ButtonNormal);
							buEyeVars.parVisual.hmiButtonSystem4.ButtonOver = buControlDisplay.Copy(f_ControlUIButton8.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonSystem4.ButtonOver);
							buEyeVars.parVisual.hmiButtonSystem4.ButtonDown = buControlDisplay.Copy(f_ControlUIButton8.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonSystem4.ButtonDown);
							buEyeVars.parVisual.hmiButtonSystem4.Parameters.GeometryArcDiameer = f_ControlUIButton8.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonSystem4.Parameters.GeometryType = f_ControlUIButton8.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonSystem4.Parameters.ImageAlignment = f_ControlUIButton8.refButton.ImageAlign;
						}
						f_ControlUIButton8.Dispose();
					}
					if (control.Name == btn_commandbutton1.Name)
					{
						F_ControlUIButton f_ControlUIButton9 = new F_ControlUIButton();
						f_ControlUIButton9.refButton = btn_commandbutton1;
						f_ControlUIButton9.Init();
						f_ControlUIButton9.ShowDialog();
						if (f_ControlUIButton9.PropertiesForm.Result == DialogResult.OK)
						{
							btn_commandbutton1 = buButton.CopyVisual(f_ControlUIButton9.refButton, btn_commandbutton1);
							buEyeVars.parVisual.hmiButtonCommand1.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton9.refButton.Display, buEyeVars.parVisual.hmiButtonCommand1.ButtonNormal);
							buEyeVars.parVisual.hmiButtonCommand1.ButtonOver = buControlDisplay.Copy(f_ControlUIButton9.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonCommand1.ButtonOver);
							buEyeVars.parVisual.hmiButtonCommand1.ButtonDown = buControlDisplay.Copy(f_ControlUIButton9.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonCommand1.ButtonDown);
							buEyeVars.parVisual.hmiButtonCommand1.Parameters.GeometryArcDiameer = f_ControlUIButton9.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonCommand1.Parameters.GeometryType = f_ControlUIButton9.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonCommand1.Parameters.ImageAlignment = f_ControlUIButton9.refButton.ImageAlign;
						}
						f_ControlUIButton9.Dispose();
					}
					if (control.Name == btn_commandbutton2.Name)
					{
						F_ControlUIButton f_ControlUIButton10 = new F_ControlUIButton();
						f_ControlUIButton10.refButton = btn_commandbutton2;
						f_ControlUIButton10.Init();
						f_ControlUIButton10.ShowDialog();
						if (f_ControlUIButton10.PropertiesForm.Result == DialogResult.OK)
						{
							btn_commandbutton2 = buButton.CopyVisual(f_ControlUIButton10.refButton, btn_commandbutton2);
							buEyeVars.parVisual.hmiButtonCommand2.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton10.refButton.Display, buEyeVars.parVisual.hmiButtonCommand2.ButtonNormal);
							buEyeVars.parVisual.hmiButtonCommand2.ButtonOver = buControlDisplay.Copy(f_ControlUIButton10.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonCommand2.ButtonOver);
							buEyeVars.parVisual.hmiButtonCommand2.ButtonDown = buControlDisplay.Copy(f_ControlUIButton10.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonCommand2.ButtonDown);
							buEyeVars.parVisual.hmiButtonCommand2.Parameters.GeometryArcDiameer = f_ControlUIButton10.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonCommand2.Parameters.GeometryType = f_ControlUIButton10.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonCommand2.Parameters.ImageAlignment = f_ControlUIButton10.refButton.ImageAlign;
						}
						f_ControlUIButton10.Dispose();
					}
					if (control.Name == btn_commandbutton3.Name)
					{
						F_ControlUIButton f_ControlUIButton11 = new F_ControlUIButton();
						f_ControlUIButton11.refButton = btn_commandbutton3;
						f_ControlUIButton11.Init();
						f_ControlUIButton11.ShowDialog();
						if (f_ControlUIButton11.PropertiesForm.Result == DialogResult.OK)
						{
							btn_commandbutton3 = buButton.CopyVisual(f_ControlUIButton11.refButton, btn_commandbutton3);
							buEyeVars.parVisual.hmiButtonCommand3.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton11.refButton.Display, buEyeVars.parVisual.hmiButtonCommand3.ButtonNormal);
							buEyeVars.parVisual.hmiButtonCommand3.ButtonOver = buControlDisplay.Copy(f_ControlUIButton11.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonCommand3.ButtonOver);
							buEyeVars.parVisual.hmiButtonCommand3.ButtonDown = buControlDisplay.Copy(f_ControlUIButton11.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonCommand3.ButtonDown);
							buEyeVars.parVisual.hmiButtonCommand3.Parameters.GeometryArcDiameer = f_ControlUIButton11.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonCommand3.Parameters.GeometryType = f_ControlUIButton11.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonCommand3.Parameters.ImageAlignment = f_ControlUIButton11.refButton.ImageAlign;
						}
						f_ControlUIButton11.Dispose();
					}
					if (control.Name == btn_commandbutton4.Name)
					{
						F_ControlUIButton f_ControlUIButton12 = new F_ControlUIButton();
						f_ControlUIButton12.refButton = btn_commandbutton4;
						f_ControlUIButton12.Init();
						f_ControlUIButton12.ShowDialog();
						if (f_ControlUIButton12.PropertiesForm.Result == DialogResult.OK)
						{
							btn_commandbutton4 = buButton.CopyVisual(f_ControlUIButton12.refButton, btn_commandbutton4);
							buEyeVars.parVisual.hmiButtonCommand4.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton12.refButton.Display, buEyeVars.parVisual.hmiButtonCommand4.ButtonNormal);
							buEyeVars.parVisual.hmiButtonCommand4.ButtonOver = buControlDisplay.Copy(f_ControlUIButton12.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonCommand4.ButtonOver);
							buEyeVars.parVisual.hmiButtonCommand4.ButtonDown = buControlDisplay.Copy(f_ControlUIButton12.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonCommand4.ButtonDown);
							buEyeVars.parVisual.hmiButtonCommand4.Parameters.GeometryArcDiameer = f_ControlUIButton12.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonCommand4.Parameters.GeometryType = f_ControlUIButton12.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonCommand4.Parameters.ImageAlignment = f_ControlUIButton12.refButton.ImageAlign;
						}
						f_ControlUIButton12.Dispose();
					}
					if (control.Name == btn_okk.Name)
					{
						F_ControlUIButton f_ControlUIButton13 = new F_ControlUIButton();
						f_ControlUIButton13.refButton = btn_okk;
						f_ControlUIButton13.Init();
						f_ControlUIButton13.ShowDialog();
						if (f_ControlUIButton13.PropertiesForm.Result == DialogResult.OK)
						{
							btn_okk = buButton.CopyVisual(f_ControlUIButton13.refButton, btn_okk);
							buEyeVars.parVisual.hmiButtonOk.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton13.refButton.Display, buEyeVars.parVisual.hmiButtonOk.ButtonNormal);
							buEyeVars.parVisual.hmiButtonOk.ButtonOver = buControlDisplay.Copy(f_ControlUIButton13.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonOk.ButtonOver);
							buEyeVars.parVisual.hmiButtonOk.ButtonDown = buControlDisplay.Copy(f_ControlUIButton13.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonOk.ButtonDown);
							buEyeVars.parVisual.hmiButtonOk.Parameters.GeometryArcDiameer = f_ControlUIButton13.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonOk.Parameters.GeometryType = f_ControlUIButton13.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonOk.Parameters.ImageAlignment = f_ControlUIButton13.refButton.ImageAlign;
						}
						f_ControlUIButton13.Dispose();
					}
					if (control.Name == btn_cancell.Name)
					{
						F_ControlUIButton f_ControlUIButton14 = new F_ControlUIButton();
						f_ControlUIButton14.refButton = btn_cancell;
						f_ControlUIButton14.Init();
						f_ControlUIButton14.ShowDialog();
						if (f_ControlUIButton14.PropertiesForm.Result == DialogResult.OK)
						{
							btn_cancell = buButton.CopyVisual(f_ControlUIButton14.refButton, btn_cancell);
							buEyeVars.parVisual.hmiButtonCancel.ButtonNormal = buControlDisplay.Copy(f_ControlUIButton14.refButton.Display, buEyeVars.parVisual.hmiButtonCancel.ButtonNormal);
							buEyeVars.parVisual.hmiButtonCancel.ButtonOver = buControlDisplay.Copy(f_ControlUIButton14.refButton.ButtonOverDisplay, buEyeVars.parVisual.hmiButtonCancel.ButtonOver);
							buEyeVars.parVisual.hmiButtonCancel.ButtonDown = buControlDisplay.Copy(f_ControlUIButton14.refButton.ButtonDownDisplay, buEyeVars.parVisual.hmiButtonCancel.ButtonDown);
							buEyeVars.parVisual.hmiButtonCancel.Parameters.GeometryArcDiameer = f_ControlUIButton14.refButton.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiButtonCancel.Parameters.GeometryType = f_ControlUIButton14.refButton.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiButtonCancel.Parameters.ImageAlignment = f_ControlUIButton14.refButton.ImageAlign;
						}
						f_ControlUIButton14.Dispose();
					}
					if (control.Name == buLabel_3.Name)
					{
						F_ControlUILabel f_ControlUILabel = new F_ControlUILabel();
						f_ControlUILabel.refLabel = (buLabel)buControlCommands.CloneControl(buLabel_3);
						f_ControlUILabel.Init();
						f_ControlUILabel.ShowDialog();
						if (f_ControlUILabel.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_3 = buLabel.CopyVisual(f_ControlUILabel.refLabel, buLabel_3);
							buEyeVars.parVisual.hmiLabel1.Display = buControlDisplay.Copy(f_ControlUILabel.refLabel.Display, buEyeVars.parVisual.hmiLabel1.Display);
							buEyeVars.parVisual.hmiLabel1.Parameters.GeometryArcDiameer = f_ControlUILabel.refLabel.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiLabel1.Parameters.GeometryType = f_ControlUILabel.refLabel.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiLabel1.Parameters.ImageAlignment = f_ControlUILabel.refLabel.ImageAlign;
						}
						f_ControlUILabel.Dispose();
					}
					if (control.Name == buLabel_2.Name)
					{
						F_ControlUILabel f_ControlUILabel2 = new F_ControlUILabel();
						f_ControlUILabel2.refLabel = (buLabel)buControlCommands.CloneControl(buLabel_2);
						f_ControlUILabel2.Init();
						f_ControlUILabel2.ShowDialog();
						if (f_ControlUILabel2.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_2 = buLabel.CopyVisual(f_ControlUILabel2.refLabel, buLabel_2);
							buEyeVars.parVisual.hmiLabel2.Display = buControlDisplay.Copy(f_ControlUILabel2.refLabel.Display, buEyeVars.parVisual.hmiLabel2.Display);
							buEyeVars.parVisual.hmiLabel2.Parameters.GeometryArcDiameer = f_ControlUILabel2.refLabel.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiLabel2.Parameters.GeometryType = f_ControlUILabel2.refLabel.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiLabel2.Parameters.ImageAlignment = f_ControlUILabel2.refLabel.ImageAlign;
						}
						f_ControlUILabel2.Dispose();
					}
					if (control.Name == buLabel_1.Name)
					{
						F_ControlUILabel f_ControlUILabel3 = new F_ControlUILabel();
						f_ControlUILabel3.refLabel = buLabel_1;
						f_ControlUILabel3.Init();
						f_ControlUILabel3.ShowDialog();
						if (f_ControlUILabel3.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_1 = buLabel.CopyVisual(f_ControlUILabel3.refLabel, buLabel_1);
							buEyeVars.parVisual.hmiLabel3.Display = buControlDisplay.Copy(f_ControlUILabel3.refLabel.Display, buEyeVars.parVisual.hmiLabel3.Display);
							buEyeVars.parVisual.hmiLabel3.Parameters.GeometryArcDiameer = f_ControlUILabel3.refLabel.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiLabel3.Parameters.GeometryType = f_ControlUILabel3.refLabel.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiLabel3.Parameters.ImageAlignment = f_ControlUILabel3.refLabel.ImageAlign;
						}
						f_ControlUILabel3.Dispose();
					}
					if (control.Name == buLabel_0.Name)
					{
						F_ControlUILabel f_ControlUILabel4 = new F_ControlUILabel();
						f_ControlUILabel4.refLabel = buLabel_0;
						f_ControlUILabel4.Init();
						f_ControlUILabel4.ShowDialog();
						if (f_ControlUILabel4.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_0 = buLabel.CopyVisual(f_ControlUILabel4.refLabel, buLabel_0);
							buEyeVars.parVisual.hmiLabel4.Display = buControlDisplay.Copy(f_ControlUILabel4.refLabel.Display, buEyeVars.parVisual.hmiLabel4.Display);
							buEyeVars.parVisual.hmiLabel4.Parameters.GeometryArcDiameer = f_ControlUILabel4.refLabel.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiLabel4.Parameters.GeometryType = f_ControlUILabel4.refLabel.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiLabel4.Parameters.ImageAlignment = f_ControlUILabel4.refLabel.ImageAlign;
						}
						f_ControlUILabel4.Dispose();
					}
					if (control.Name == spn_1.Name)
					{
						F_ControlUISpin f_ControlUISpin = new F_ControlUISpin();
						f_ControlUISpin.refSpin = new buSpin();
						f_ControlUISpin.refSpin = buSpin.CopyVisual(spn_1, f_ControlUISpin.refSpin);
						f_ControlUISpin.Init();
						f_ControlUISpin.ShowDialog();
						if (f_ControlUISpin.PropertiesForm.Result == DialogResult.OK)
						{
							spn_1 = buSpin.CopyVisual(f_ControlUISpin.refSpin, spn_1);
							buEyeVars.parVisual.hmiSpin1.ButtonNormal = buControlDisplay.Copy(f_ControlUISpin.refSpin.ButtonNormalDisplay, buEyeVars.parVisual.hmiSpin1.ButtonNormal);
							buEyeVars.parVisual.hmiSpin1.ButtonOver = buControlDisplay.Copy(f_ControlUISpin.refSpin.ButtonOverDisplay, buEyeVars.parVisual.hmiSpin1.ButtonOver);
							buEyeVars.parVisual.hmiSpin1.ButtonDown = buControlDisplay.Copy(f_ControlUISpin.refSpin.ButtonDownDisplay, buEyeVars.parVisual.hmiSpin1.ButtonDown);
							buEyeVars.parVisual.hmiSpin1.Caption = buControlDisplay.Copy(f_ControlUISpin.refSpin.Caption.Display, buEyeVars.parVisual.hmiSpin1.Caption);
							buEyeVars.parVisual.hmiSpin1.Display = buControlDisplay.Copy(f_ControlUISpin.refSpin.Display, buEyeVars.parVisual.hmiSpin1.Display);
							buEyeVars.parVisual.hmiSpin1.Parameters.GeometryArcDiameer = f_ControlUISpin.refSpin.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiSpin1.Parameters.GeometryType = f_ControlUISpin.refSpin.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiSpin1.Parameters.ImageAlignment = f_ControlUISpin.refSpin.ImageAlign;
						}
						f_ControlUISpin.Dispose();
					}
					if (control.Name == spn_2.Name)
					{
						F_ControlUISpin f_ControlUISpin2 = new F_ControlUISpin();
						f_ControlUISpin2.refSpin = new buSpin();
						f_ControlUISpin2.refSpin = buSpin.CopyVisual(spn_2, f_ControlUISpin2.refSpin);
						f_ControlUISpin2.Init();
						f_ControlUISpin2.ShowDialog();
						if (f_ControlUISpin2.PropertiesForm.Result == DialogResult.OK)
						{
							spn_2 = buSpin.CopyVisual(f_ControlUISpin2.refSpin, spn_2);
							buEyeVars.parVisual.hmiSpin2.ButtonNormal = buControlDisplay.Copy(f_ControlUISpin2.refSpin.ButtonNormalDisplay, buEyeVars.parVisual.hmiSpin2.ButtonNormal);
							buEyeVars.parVisual.hmiSpin2.ButtonOver = buControlDisplay.Copy(f_ControlUISpin2.refSpin.ButtonOverDisplay, buEyeVars.parVisual.hmiSpin2.ButtonOver);
							buEyeVars.parVisual.hmiSpin2.ButtonDown = buControlDisplay.Copy(f_ControlUISpin2.refSpin.ButtonDownDisplay, buEyeVars.parVisual.hmiSpin2.ButtonDown);
							buEyeVars.parVisual.hmiSpin2.Caption = buControlDisplay.Copy(f_ControlUISpin2.refSpin.Caption.Display, buEyeVars.parVisual.hmiSpin2.Caption);
							buEyeVars.parVisual.hmiSpin2.Display = buControlDisplay.Copy(f_ControlUISpin2.refSpin.Display, buEyeVars.parVisual.hmiSpin2.Display);
							buEyeVars.parVisual.hmiSpin2.Parameters.GeometryArcDiameer = f_ControlUISpin2.refSpin.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiSpin2.Parameters.GeometryType = f_ControlUISpin2.refSpin.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiSpin2.Parameters.ImageAlignment = f_ControlUISpin2.refSpin.ImageAlign;
						}
						f_ControlUISpin2.Dispose();
					}
					if (control.Name == spn_3.Name)
					{
						F_ControlUISpin f_ControlUISpin3 = new F_ControlUISpin();
						f_ControlUISpin3.refSpin = new buSpin();
						f_ControlUISpin3.refSpin = buSpin.CopyVisual(spn_3, f_ControlUISpin3.refSpin);
						f_ControlUISpin3.Init();
						f_ControlUISpin3.ShowDialog();
						if (f_ControlUISpin3.PropertiesForm.Result == DialogResult.OK)
						{
							spn_3 = buSpin.CopyVisual(f_ControlUISpin3.refSpin, spn_3);
							buEyeVars.parVisual.hmiSpin3.ButtonNormal = buControlDisplay.Copy(f_ControlUISpin3.refSpin.ButtonNormalDisplay, buEyeVars.parVisual.hmiSpin3.ButtonNormal);
							buEyeVars.parVisual.hmiSpin3.ButtonOver = buControlDisplay.Copy(f_ControlUISpin3.refSpin.ButtonOverDisplay, buEyeVars.parVisual.hmiSpin3.ButtonOver);
							buEyeVars.parVisual.hmiSpin3.ButtonDown = buControlDisplay.Copy(f_ControlUISpin3.refSpin.ButtonDownDisplay, buEyeVars.parVisual.hmiSpin3.ButtonDown);
							buEyeVars.parVisual.hmiSpin3.Caption = buControlDisplay.Copy(f_ControlUISpin3.refSpin.Caption.Display, buEyeVars.parVisual.hmiSpin3.Caption);
							buEyeVars.parVisual.hmiSpin3.Display = buControlDisplay.Copy(f_ControlUISpin3.refSpin.Display, buEyeVars.parVisual.hmiSpin3.Display);
							buEyeVars.parVisual.hmiSpin3.Parameters.GeometryArcDiameer = f_ControlUISpin3.refSpin.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiSpin3.Parameters.GeometryType = f_ControlUISpin3.refSpin.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiSpin3.Parameters.ImageAlignment = f_ControlUISpin3.refSpin.ImageAlign;
						}
						f_ControlUISpin3.Dispose();
					}
					if (control.Name == spn_4.Name)
					{
						F_ControlUISpin f_ControlUISpin4 = new F_ControlUISpin();
						f_ControlUISpin4.refSpin = new buSpin();
						f_ControlUISpin4.refSpin = buSpin.CopyVisual(spn_4, f_ControlUISpin4.refSpin);
						f_ControlUISpin4.Init();
						f_ControlUISpin4.ShowDialog();
						if (f_ControlUISpin4.PropertiesForm.Result == DialogResult.OK)
						{
							spn_4 = buSpin.CopyVisual(f_ControlUISpin4.refSpin, spn_4);
							buEyeVars.parVisual.hmiSpin4.ButtonNormal = buControlDisplay.Copy(f_ControlUISpin4.refSpin.ButtonNormalDisplay, buEyeVars.parVisual.hmiSpin4.ButtonNormal);
							buEyeVars.parVisual.hmiSpin4.ButtonOver = buControlDisplay.Copy(f_ControlUISpin4.refSpin.ButtonOverDisplay, buEyeVars.parVisual.hmiSpin4.ButtonOver);
							buEyeVars.parVisual.hmiSpin4.ButtonDown = buControlDisplay.Copy(f_ControlUISpin4.refSpin.ButtonDownDisplay, buEyeVars.parVisual.hmiSpin4.ButtonDown);
							buEyeVars.parVisual.hmiSpin4.Caption = buControlDisplay.Copy(f_ControlUISpin4.refSpin.Caption.Display, buEyeVars.parVisual.hmiSpin4.Caption);
							buEyeVars.parVisual.hmiSpin4.Display = buControlDisplay.Copy(f_ControlUISpin4.refSpin.Display, buEyeVars.parVisual.hmiSpin4.Display);
							buEyeVars.parVisual.hmiSpin4.Parameters.GeometryArcDiameer = f_ControlUISpin4.refSpin.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiSpin4.Parameters.GeometryType = f_ControlUISpin4.refSpin.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiSpin4.Parameters.ImageAlignment = f_ControlUISpin4.refSpin.ImageAlign;
						}
						f_ControlUISpin4.Dispose();
					}
					if (control.Name == buTextBox_3.Name)
					{
						F_ControlUIText f_ControlUIText = new F_ControlUIText();
						f_ControlUIText.refText = new buTextBox();
						f_ControlUIText.refText = buTextBox.CopyVisual(buTextBox_3, f_ControlUIText.refText);
						f_ControlUIText.Init();
						f_ControlUIText.ShowDialog();
						if (f_ControlUIText.PropertiesForm.Result == DialogResult.OK)
						{
							buTextBox_3 = buTextBox.CopyVisual(f_ControlUIText.refText, buTextBox_3);
							buEyeVars.parVisual.hmiText1.Caption = buControlDisplay.Copy(f_ControlUIText.refText.Caption.Display, buEyeVars.parVisual.hmiText1.Caption);
							buEyeVars.parVisual.hmiText1.Display = buControlDisplay.Copy(f_ControlUIText.refText.Display, buEyeVars.parVisual.hmiText1.Display);
							buEyeVars.parVisual.hmiText1.Parameters.GeometryArcDiameer = f_ControlUIText.refText.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiText1.Parameters.GeometryType = f_ControlUIText.refText.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiText1.Parameters.ImageAlignment = f_ControlUIText.refText.ImageAlign;
						}
						f_ControlUIText.Dispose();
					}
					if (control.Name == buTextBox_2.Name)
					{
						F_ControlUIText f_ControlUIText2 = new F_ControlUIText();
						f_ControlUIText2.refText = new buTextBox();
						f_ControlUIText2.refText = buTextBox.CopyVisual(buTextBox_2, f_ControlUIText2.refText);
						f_ControlUIText2.Init();
						f_ControlUIText2.ShowDialog();
						if (f_ControlUIText2.PropertiesForm.Result == DialogResult.OK)
						{
							buTextBox_2 = buTextBox.CopyVisual(f_ControlUIText2.refText, buTextBox_2);
							buEyeVars.parVisual.hmiText2.Caption = buControlDisplay.Copy(f_ControlUIText2.refText.Caption.Display, buEyeVars.parVisual.hmiText2.Caption);
							buEyeVars.parVisual.hmiText2.Display = buControlDisplay.Copy(f_ControlUIText2.refText.Display, buEyeVars.parVisual.hmiText2.Display);
							buEyeVars.parVisual.hmiText2.Parameters.GeometryArcDiameer = f_ControlUIText2.refText.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiText2.Parameters.GeometryType = f_ControlUIText2.refText.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiText2.Parameters.ImageAlignment = f_ControlUIText2.refText.ImageAlign;
						}
						f_ControlUIText2.Dispose();
					}
					if (control.Name == buTextBox_1.Name)
					{
						F_ControlUIText f_ControlUIText3 = new F_ControlUIText();
						f_ControlUIText3.refText = new buTextBox();
						f_ControlUIText3.refText = buTextBox.CopyVisual(buTextBox_1, f_ControlUIText3.refText);
						f_ControlUIText3.Init();
						f_ControlUIText3.ShowDialog();
						if (f_ControlUIText3.PropertiesForm.Result == DialogResult.OK)
						{
							buTextBox_1 = buTextBox.CopyVisual(f_ControlUIText3.refText, buTextBox_1);
							buEyeVars.parVisual.hmiText3.Caption = buControlDisplay.Copy(f_ControlUIText3.refText.Caption.Display, buEyeVars.parVisual.hmiText3.Caption);
							buEyeVars.parVisual.hmiText3.Display = buControlDisplay.Copy(f_ControlUIText3.refText.Display, buEyeVars.parVisual.hmiText3.Display);
							buEyeVars.parVisual.hmiText3.Parameters.GeometryArcDiameer = f_ControlUIText3.refText.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiText3.Parameters.GeometryType = f_ControlUIText3.refText.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiText3.Parameters.ImageAlignment = f_ControlUIText3.refText.ImageAlign;
						}
						f_ControlUIText3.Dispose();
					}
					if (control.Name == buTextBox_0.Name)
					{
						F_ControlUIText f_ControlUIText4 = new F_ControlUIText();
						f_ControlUIText4.refText = new buTextBox();
						f_ControlUIText4.refText = buTextBox.CopyVisual(buTextBox_0, f_ControlUIText4.refText);
						f_ControlUIText4.Init();
						f_ControlUIText4.ShowDialog();
						if (f_ControlUIText4.PropertiesForm.Result == DialogResult.OK)
						{
							buTextBox_0 = buTextBox.CopyVisual(f_ControlUIText4.refText, buTextBox_0);
							buEyeVars.parVisual.hmiText4.Caption = buControlDisplay.Copy(f_ControlUIText4.refText.Caption.Display, buEyeVars.parVisual.hmiText4.Caption);
							buEyeVars.parVisual.hmiText4.Display = buControlDisplay.Copy(f_ControlUIText4.refText.Display, buEyeVars.parVisual.hmiText4.Display);
							buEyeVars.parVisual.hmiText4.Parameters.GeometryArcDiameer = f_ControlUIText4.refText.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiText4.Parameters.GeometryType = f_ControlUIText4.refText.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiText4.Parameters.ImageAlignment = f_ControlUIText4.refText.ImageAlign;
						}
						f_ControlUIText4.Dispose();
					}
					if (control.Name == chk_1.Name)
					{
						F_ControlUICheck f_ControlUICheck = new F_ControlUICheck();
						f_ControlUICheck.refCheck = new buCheckBox();
						f_ControlUICheck.refCheck = buCheckBox.CopyVisual(chk_1, f_ControlUICheck.refCheck);
						f_ControlUICheck.Init();
						f_ControlUICheck.ShowDialog();
						if (f_ControlUICheck.PropertiesForm.Result == DialogResult.OK)
						{
							chk_1 = buCheckBox.CopyVisual(f_ControlUICheck.refCheck, chk_1);
							buEyeVars.parVisual.hmiCheck1.Caption = buControlDisplay.Copy(f_ControlUICheck.refCheck.CheckTick.TickDisplay, buEyeVars.parVisual.hmiCheck1.Caption);
							buEyeVars.parVisual.hmiCheck1.ButtonNormal = buControlDisplay.Copy(f_ControlUICheck.refCheck.CheckTick.ColorModeDisplay, buEyeVars.parVisual.hmiCheck1.ButtonNormal);
							buEyeVars.parVisual.hmiCheck1.Display = buControlDisplay.Copy(f_ControlUICheck.refCheck.Display, buEyeVars.parVisual.hmiCheck1.Display);
							buEyeVars.parVisual.hmiCheck1.Parameters.GeometryArcDiameer = f_ControlUICheck.refCheck.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiCheck1.Parameters.GeometryType = f_ControlUICheck.refCheck.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiCheck1.Parameters.ImageAlignment = f_ControlUICheck.refCheck.ImageAlign;
							buEyeVars.parVisual.hmiCheck1.Parameters.CheckColorMode = f_ControlUICheck.refCheck.CheckTick.ColorModeEnable;
							buEyeVars.parVisual.hmiCheck1.Parameters.CheckBoxVisible = f_ControlUICheck.refCheck.CheckTick.Visible;
							if (f_ControlUICheck.refCheck.CheckTick.BoxSize > 0)
							{
								buEyeVars.parVisual.hmiCheck1.Parameters.CheckBoxSize = f_ControlUICheck.refCheck.CheckTick.BoxSize;
							}
							if (f_ControlUICheck.refCheck.CheckTick.Shape != ShapeType.Rectangle)
							{
								buEyeVars.parVisual.hmiCheck1.Parameters.CheckBoxCheckIsRectangle = false;
							}
							else
							{
								buEyeVars.parVisual.hmiCheck1.Parameters.CheckBoxCheckIsRectangle = true;
							}
						}
						f_ControlUICheck.Dispose();
					}
					if (control.Name == chk_2.Name)
					{
						F_ControlUICheck f_ControlUICheck2 = new F_ControlUICheck();
						f_ControlUICheck2.refCheck = new buCheckBox();
						f_ControlUICheck2.refCheck = buCheckBox.CopyVisual(chk_2, f_ControlUICheck2.refCheck);
						f_ControlUICheck2.Init();
						f_ControlUICheck2.ShowDialog();
						if (f_ControlUICheck2.PropertiesForm.Result == DialogResult.OK)
						{
							chk_2 = buCheckBox.CopyVisual(f_ControlUICheck2.refCheck, chk_2);
							buEyeVars.parVisual.hmiCheck2.Caption = buControlDisplay.Copy(f_ControlUICheck2.refCheck.CheckTick.TickDisplay, buEyeVars.parVisual.hmiCheck2.Caption);
							buEyeVars.parVisual.hmiCheck2.ButtonNormal = buControlDisplay.Copy(f_ControlUICheck2.refCheck.CheckTick.ColorModeDisplay, buEyeVars.parVisual.hmiCheck2.ButtonNormal);
							buEyeVars.parVisual.hmiCheck2.Display = buControlDisplay.Copy(f_ControlUICheck2.refCheck.Display, buEyeVars.parVisual.hmiCheck2.Display);
							buEyeVars.parVisual.hmiCheck2.Parameters.GeometryArcDiameer = f_ControlUICheck2.refCheck.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiCheck2.Parameters.GeometryType = f_ControlUICheck2.refCheck.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiCheck2.Parameters.ImageAlignment = f_ControlUICheck2.refCheck.ImageAlign;
							buEyeVars.parVisual.hmiCheck2.Parameters.CheckColorMode = f_ControlUICheck2.refCheck.CheckTick.ColorModeEnable;
							buEyeVars.parVisual.hmiCheck2.Parameters.CheckBoxVisible = f_ControlUICheck2.refCheck.CheckTick.Visible;
							if (f_ControlUICheck2.refCheck.CheckTick.BoxSize > 0)
							{
								buEyeVars.parVisual.hmiCheck2.Parameters.CheckBoxSize = f_ControlUICheck2.refCheck.CheckTick.BoxSize;
							}
							if (f_ControlUICheck2.refCheck.CheckTick.Shape != ShapeType.Rectangle)
							{
								buEyeVars.parVisual.hmiCheck2.Parameters.CheckBoxCheckIsRectangle = false;
							}
							else
							{
								buEyeVars.parVisual.hmiCheck2.Parameters.CheckBoxCheckIsRectangle = true;
							}
						}
						f_ControlUICheck2.Dispose();
					}
					if (control.Name == chk_3.Name)
					{
						F_ControlUICheck f_ControlUICheck3 = new F_ControlUICheck();
						f_ControlUICheck3.refCheck = new buCheckBox();
						f_ControlUICheck3.refCheck = buCheckBox.CopyVisual(chk_3, f_ControlUICheck3.refCheck);
						f_ControlUICheck3.Init();
						f_ControlUICheck3.ShowDialog();
						if (f_ControlUICheck3.PropertiesForm.Result == DialogResult.OK)
						{
							chk_3 = buCheckBox.CopyVisual(f_ControlUICheck3.refCheck, chk_3);
							buEyeVars.parVisual.hmiCheck3.Caption = buControlDisplay.Copy(f_ControlUICheck3.refCheck.CheckTick.TickDisplay, buEyeVars.parVisual.hmiCheck3.Caption);
							buEyeVars.parVisual.hmiCheck3.ButtonNormal = buControlDisplay.Copy(f_ControlUICheck3.refCheck.CheckTick.ColorModeDisplay, buEyeVars.parVisual.hmiCheck3.ButtonNormal);
							buEyeVars.parVisual.hmiCheck3.Display = buControlDisplay.Copy(f_ControlUICheck3.refCheck.Display, buEyeVars.parVisual.hmiCheck3.Display);
							buEyeVars.parVisual.hmiCheck3.Parameters.GeometryArcDiameer = f_ControlUICheck3.refCheck.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiCheck3.Parameters.GeometryType = f_ControlUICheck3.refCheck.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiCheck3.Parameters.ImageAlignment = f_ControlUICheck3.refCheck.ImageAlign;
							buEyeVars.parVisual.hmiCheck3.Parameters.CheckColorMode = f_ControlUICheck3.refCheck.CheckTick.ColorModeEnable;
							buEyeVars.parVisual.hmiCheck3.Parameters.CheckBoxVisible = f_ControlUICheck3.refCheck.CheckTick.Visible;
							if (f_ControlUICheck3.refCheck.CheckTick.BoxSize > 0)
							{
								buEyeVars.parVisual.hmiCheck3.Parameters.CheckBoxSize = f_ControlUICheck3.refCheck.CheckTick.BoxSize;
							}
							if (f_ControlUICheck3.refCheck.CheckTick.Shape != ShapeType.Rectangle)
							{
								buEyeVars.parVisual.hmiCheck3.Parameters.CheckBoxCheckIsRectangle = false;
							}
							else
							{
								buEyeVars.parVisual.hmiCheck3.Parameters.CheckBoxCheckIsRectangle = true;
							}
						}
						f_ControlUICheck3.Dispose();
					}
					if (control.Name == chk_4.Name)
					{
						F_ControlUICheck f_ControlUICheck4 = new F_ControlUICheck();
						f_ControlUICheck4.refCheck = new buCheckBox();
						f_ControlUICheck4.refCheck = buCheckBox.CopyVisual(chk_4, f_ControlUICheck4.refCheck);
						f_ControlUICheck4.Init();
						f_ControlUICheck4.ShowDialog();
						if (f_ControlUICheck4.PropertiesForm.Result == DialogResult.OK)
						{
							chk_4 = buCheckBox.CopyVisual(f_ControlUICheck4.refCheck, chk_4);
							buEyeVars.parVisual.hmiCheck4.Caption = buControlDisplay.Copy(f_ControlUICheck4.refCheck.CheckTick.TickDisplay, buEyeVars.parVisual.hmiCheck4.Caption);
							buEyeVars.parVisual.hmiCheck4.ButtonNormal = buControlDisplay.Copy(f_ControlUICheck4.refCheck.CheckTick.ColorModeDisplay, buEyeVars.parVisual.hmiCheck4.ButtonNormal);
							buEyeVars.parVisual.hmiCheck4.Display = buControlDisplay.Copy(f_ControlUICheck4.refCheck.Display, buEyeVars.parVisual.hmiCheck4.Display);
							buEyeVars.parVisual.hmiCheck4.Parameters.GeometryArcDiameer = f_ControlUICheck4.refCheck.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiCheck4.Parameters.GeometryType = f_ControlUICheck4.refCheck.Geometry.ShapeMode;
							buEyeVars.parVisual.hmiCheck4.Parameters.ImageAlignment = f_ControlUICheck4.refCheck.ImageAlign;
							buEyeVars.parVisual.hmiCheck4.Parameters.CheckColorMode = f_ControlUICheck4.refCheck.CheckTick.ColorModeEnable;
							buEyeVars.parVisual.hmiCheck4.Parameters.CheckBoxVisible = f_ControlUICheck4.refCheck.CheckTick.Visible;
							if (f_ControlUICheck4.refCheck.CheckTick.BoxSize > 0)
							{
								buEyeVars.parVisual.hmiCheck4.Parameters.CheckBoxSize = f_ControlUICheck4.refCheck.CheckTick.BoxSize;
							}
							if (f_ControlUICheck4.refCheck.CheckTick.Shape != ShapeType.Rectangle)
							{
								buEyeVars.parVisual.hmiCheck4.Parameters.CheckBoxCheckIsRectangle = false;
							}
							else
							{
								buEyeVars.parVisual.hmiCheck4.Parameters.CheckBoxCheckIsRectangle = true;
							}
						}
						f_ControlUICheck4.Dispose();
					}
					if (control.Name == radioButton_0.Name)
					{
						F_ControlUIRadio f_ControlUIRadio = new F_ControlUIRadio();
						f_ControlUIRadio.refRadio = new RadioButton();
						f_ControlUIRadio.refRadio.ForeColor = radioButton_0.ForeColor;
						f_ControlUIRadio.refRadio.BackColor = radioButton_0.BackColor;
						f_ControlUIRadio.refRadio.Font = new Font(radioButton_0.Font.Name, radioButton_0.Font.Size, radioButton_0.Font.Style);
						f_ControlUIRadio.refRadio.TextAlign = radioButton_0.TextAlign;
						f_ControlUIRadio.Init();
						f_ControlUIRadio.ShowDialog();
						if (f_ControlUIRadio.PropertiesForm.Result == DialogResult.OK)
						{
							radioButton_0.ForeColor = f_ControlUIRadio.refRadio.ForeColor;
							radioButton_0.BackColor = f_ControlUIRadio.refRadio.BackColor;
							radioButton_0.Font = new Font(f_ControlUIRadio.refRadio.Font.Name, f_ControlUIRadio.refRadio.Font.Size, f_ControlUIRadio.refRadio.Font.Style);
							radioButton_0.TextAlign = f_ControlUIRadio.refRadio.TextAlign;
							buEyeVars.parVisual.hmiRadioButton1.Display.Fonts.Alignment = radioButton_0.TextAlign;
							buEyeVars.parVisual.hmiRadioButton1.Display.BackColor = radioButton_0.BackColor;
							buEyeVars.parVisual.hmiRadioButton1.Display.Fonts.ForeColor = radioButton_0.ForeColor;
							buEyeVars.parVisual.hmiRadioButton1.Display.Fonts.Font = new Font(radioButton_0.Font.Name, radioButton_0.Font.Size, radioButton_0.Font.Style);
						}
						f_ControlUIRadio.Dispose();
					}
					if (control.Name == radioButton_3.Name)
					{
						F_ControlUIRadio f_ControlUIRadio2 = new F_ControlUIRadio();
						f_ControlUIRadio2.refRadio = new RadioButton();
						f_ControlUIRadio2.refRadio.ForeColor = radioButton_3.ForeColor;
						f_ControlUIRadio2.refRadio.BackColor = radioButton_3.BackColor;
						f_ControlUIRadio2.refRadio.Font = new Font(radioButton_3.Font.Name, radioButton_3.Font.Size, radioButton_3.Font.Style);
						f_ControlUIRadio2.refRadio.TextAlign = radioButton_3.TextAlign;
						f_ControlUIRadio2.Init();
						f_ControlUIRadio2.ShowDialog();
						if (f_ControlUIRadio2.PropertiesForm.Result == DialogResult.OK)
						{
							radioButton_3.ForeColor = f_ControlUIRadio2.refRadio.ForeColor;
							radioButton_3.BackColor = f_ControlUIRadio2.refRadio.BackColor;
							radioButton_3.Font = new Font(f_ControlUIRadio2.refRadio.Font.Name, f_ControlUIRadio2.refRadio.Font.Size, f_ControlUIRadio2.refRadio.Font.Style);
							radioButton_3.TextAlign = f_ControlUIRadio2.refRadio.TextAlign;
							buEyeVars.parVisual.hmiRadioButton2.Display.Fonts.Alignment = radioButton_3.TextAlign;
							buEyeVars.parVisual.hmiRadioButton2.Display.BackColor = radioButton_3.BackColor;
							buEyeVars.parVisual.hmiRadioButton2.Display.Fonts.ForeColor = radioButton_3.ForeColor;
							buEyeVars.parVisual.hmiRadioButton2.Display.Fonts.Font = new Font(radioButton_3.Font.Name, radioButton_3.Font.Size, radioButton_3.Font.Style);
						}
						f_ControlUIRadio2.Dispose();
					}
					if (control.Name == radioButton_2.Name)
					{
						F_ControlUIRadio f_ControlUIRadio3 = new F_ControlUIRadio();
						f_ControlUIRadio3.refRadio = new RadioButton();
						f_ControlUIRadio3.refRadio.ForeColor = radioButton_2.ForeColor;
						f_ControlUIRadio3.refRadio.BackColor = radioButton_2.BackColor;
						f_ControlUIRadio3.refRadio.Font = new Font(radioButton_2.Font.Name, radioButton_2.Font.Size, radioButton_2.Font.Style);
						f_ControlUIRadio3.refRadio.TextAlign = radioButton_2.TextAlign;
						f_ControlUIRadio3.Init();
						f_ControlUIRadio3.ShowDialog();
						if (f_ControlUIRadio3.PropertiesForm.Result == DialogResult.OK)
						{
							radioButton_2.ForeColor = f_ControlUIRadio3.refRadio.ForeColor;
							radioButton_2.BackColor = f_ControlUIRadio3.refRadio.BackColor;
							radioButton_2.Font = new Font(f_ControlUIRadio3.refRadio.Font.Name, f_ControlUIRadio3.refRadio.Font.Size, f_ControlUIRadio3.refRadio.Font.Style);
							radioButton_2.TextAlign = f_ControlUIRadio3.refRadio.TextAlign;
							buEyeVars.parVisual.hmiRadioButton3.Display.Fonts.Alignment = radioButton_2.TextAlign;
							buEyeVars.parVisual.hmiRadioButton3.Display.BackColor = radioButton_2.BackColor;
							buEyeVars.parVisual.hmiRadioButton3.Display.Fonts.ForeColor = radioButton_2.ForeColor;
							buEyeVars.parVisual.hmiRadioButton3.Display.Fonts.Font = new Font(radioButton_2.Font.Name, radioButton_2.Font.Size, radioButton_2.Font.Style);
						}
						f_ControlUIRadio3.Dispose();
					}
					if (control.Name == radioButton_1.Name)
					{
						F_ControlUIRadio f_ControlUIRadio4 = new F_ControlUIRadio();
						f_ControlUIRadio4.refRadio = new RadioButton();
						f_ControlUIRadio4.refRadio.ForeColor = radioButton_1.ForeColor;
						f_ControlUIRadio4.refRadio.BackColor = radioButton_1.BackColor;
						f_ControlUIRadio4.refRadio.Font = new Font(radioButton_1.Font.Name, radioButton_1.Font.Size, radioButton_1.Font.Style);
						f_ControlUIRadio4.refRadio.TextAlign = radioButton_2.TextAlign;
						f_ControlUIRadio4.Init();
						f_ControlUIRadio4.ShowDialog();
						if (f_ControlUIRadio4.PropertiesForm.Result == DialogResult.OK)
						{
							radioButton_1.ForeColor = f_ControlUIRadio4.refRadio.ForeColor;
							radioButton_1.BackColor = f_ControlUIRadio4.refRadio.BackColor;
							radioButton_1.Font = new Font(f_ControlUIRadio4.refRadio.Font.Name, f_ControlUIRadio4.refRadio.Font.Size, f_ControlUIRadio4.refRadio.Font.Style);
							radioButton_1.TextAlign = f_ControlUIRadio4.refRadio.TextAlign;
							buEyeVars.parVisual.hmiRadioButton4.Display.Fonts.Alignment = radioButton_1.TextAlign;
							buEyeVars.parVisual.hmiRadioButton4.Display.BackColor = radioButton_1.BackColor;
							buEyeVars.parVisual.hmiRadioButton4.Display.Fonts.ForeColor = radioButton_1.ForeColor;
							buEyeVars.parVisual.hmiRadioButton4.Display.Fonts.Font = new Font(radioButton_1.Font.Name, radioButton_1.Font.Size, radioButton_1.Font.Style);
						}
						f_ControlUIRadio4.Dispose();
					}
					if (control.Name == buListBox_3.Name)
					{
						F_ControlUIListbox f_ControlUIListbox = new F_ControlUIListbox();
						f_ControlUIListbox.refList = new buListBox();
						f_ControlUIListbox.refList = buListBox.CopyVisual(buListBox_3, f_ControlUIListbox.refList);
						f_ControlUIListbox.Init();
						f_ControlUIListbox.ShowDialog();
						if (f_ControlUIListbox.PropertiesForm.Result == DialogResult.OK)
						{
							buListBox_3 = buListBox.CopyVisual(f_ControlUIListbox.refList, buListBox_3);
							buEyeVars.parVisual.hmiListbox1.Display = buControlDisplay.Copy(f_ControlUIListbox.refList.Display, buEyeVars.parVisual.hmiListbox1.Display);
							buEyeVars.parVisual.hmiListbox1.Parameters.GeometryArcDiameer = f_ControlUIListbox.refList.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiListbox1.Parameters.GeometryType = f_ControlUIListbox.refList.Geometry.ShapeMode;
						}
						f_ControlUIListbox.Dispose();
					}
					if (control.Name == buListBox_2.Name)
					{
						F_ControlUIListbox f_ControlUIListbox2 = new F_ControlUIListbox();
						f_ControlUIListbox2.refList = new buListBox();
						f_ControlUIListbox2.refList = buListBox.CopyVisual(buListBox_2, f_ControlUIListbox2.refList);
						f_ControlUIListbox2.Init();
						f_ControlUIListbox2.ShowDialog();
						if (f_ControlUIListbox2.PropertiesForm.Result == DialogResult.OK)
						{
							buListBox_2 = buListBox.CopyVisual(f_ControlUIListbox2.refList, buListBox_2);
							buEyeVars.parVisual.hmiListbox2.Display = buControlDisplay.Copy(f_ControlUIListbox2.refList.Display, buEyeVars.parVisual.hmiListbox2.Display);
							buEyeVars.parVisual.hmiListbox2.Parameters.GeometryArcDiameer = f_ControlUIListbox2.refList.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiListbox2.Parameters.GeometryType = f_ControlUIListbox2.refList.Geometry.ShapeMode;
						}
						f_ControlUIListbox2.Dispose();
					}
					if (control.Name == buListBox_1.Name)
					{
						F_ControlUIListbox f_ControlUIListbox3 = new F_ControlUIListbox();
						f_ControlUIListbox3.refList = new buListBox();
						f_ControlUIListbox3.refList = buListBox.CopyVisual(buListBox_1, f_ControlUIListbox3.refList);
						f_ControlUIListbox3.Init();
						f_ControlUIListbox3.ShowDialog();
						if (f_ControlUIListbox3.PropertiesForm.Result == DialogResult.OK)
						{
							buListBox_1 = buListBox.CopyVisual(f_ControlUIListbox3.refList, buListBox_1);
							buEyeVars.parVisual.hmiListbox3.Display = buControlDisplay.Copy(f_ControlUIListbox3.refList.Display, buEyeVars.parVisual.hmiListbox3.Display);
							buEyeVars.parVisual.hmiListbox3.Parameters.GeometryArcDiameer = f_ControlUIListbox3.refList.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiListbox3.Parameters.GeometryType = f_ControlUIListbox3.refList.Geometry.ShapeMode;
						}
						f_ControlUIListbox3.Dispose();
					}
					if (control.Name == buListBox_0.Name)
					{
						F_ControlUIListbox f_ControlUIListbox4 = new F_ControlUIListbox();
						f_ControlUIListbox4.refList = new buListBox();
						f_ControlUIListbox4.refList = buListBox.CopyVisual(buListBox_0, f_ControlUIListbox4.refList);
						f_ControlUIListbox4.Init();
						f_ControlUIListbox4.ShowDialog();
						if (f_ControlUIListbox4.PropertiesForm.Result == DialogResult.OK)
						{
							buListBox_0 = buListBox.CopyVisual(f_ControlUIListbox4.refList, buListBox_0);
							buEyeVars.parVisual.hmiListbox4.Display = buControlDisplay.Copy(f_ControlUIListbox4.refList.Display, buEyeVars.parVisual.hmiListbox4.Display);
							buEyeVars.parVisual.hmiListbox4.Parameters.GeometryArcDiameer = f_ControlUIListbox4.refList.Geometry.ArcDiameter;
							buEyeVars.parVisual.hmiListbox4.Parameters.GeometryType = f_ControlUIListbox4.refList.Geometry.ShapeMode;
						}
						f_ControlUIListbox4.Dispose();
					}
					if (control.Name == track_1.Name)
					{
						F_ControlUITrack f_ControlUITrack = new F_ControlUITrack();
						f_ControlUITrack.Settings = new hmiUISettings(buEyeVars.parVisual.hmiTrack1);
						f_ControlUITrack.Init();
						f_ControlUITrack.ShowDialog();
						if (f_ControlUITrack.PropertiesForm.Result == DialogResult.OK)
						{
							track_1 = buTrack.CopyVisual(f_ControlUITrack.track_ref, track_1);
							buEyeVars.parVisual.hmiTrack1 = new hmiUISettings(f_ControlUITrack.Settings);
						}
						f_ControlUITrack.Dispose();
					}
					if (control.Name == track_2.Name)
					{
						F_ControlUITrack f_ControlUITrack2 = new F_ControlUITrack();
						f_ControlUITrack2.Settings = new hmiUISettings(buEyeVars.parVisual.hmiTrack2);
						f_ControlUITrack2.Init();
						f_ControlUITrack2.ShowDialog();
						if (f_ControlUITrack2.PropertiesForm.Result == DialogResult.OK)
						{
							track_2 = buTrack.CopyVisual(f_ControlUITrack2.track_ref, track_2);
							buEyeVars.parVisual.hmiTrack2 = new hmiUISettings(f_ControlUITrack2.Settings);
						}
						f_ControlUITrack2.Dispose();
					}
					if (control.Name == Progress_1.Name)
					{
						F_ControlUIProgress f_ControlUIProgress = new F_ControlUIProgress();
						f_ControlUIProgress.Settings = new hmiUISettings(buEyeVars.parVisual.hmiProgress1);
						f_ControlUIProgress.Init();
						f_ControlUIProgress.ShowDialog();
						if (f_ControlUIProgress.PropertiesForm.Result == DialogResult.OK)
						{
							Progress_1 = buProgressBar.CopyVisual(f_ControlUIProgress.Progress_Ref, Progress_1);
							buEyeVars.parVisual.hmiProgress1 = new hmiUISettings(f_ControlUIProgress.Settings);
						}
						f_ControlUIProgress.Dispose();
					}
					if (control.Name == Progress_2.Name)
					{
						F_ControlUIProgress f_ControlUIProgress2 = new F_ControlUIProgress();
						f_ControlUIProgress2.Settings = new hmiUISettings(buEyeVars.parVisual.hmiProgress2);
						f_ControlUIProgress2.Init();
						f_ControlUIProgress2.ShowDialog();
						if (f_ControlUIProgress2.PropertiesForm.Result == DialogResult.OK)
						{
							Progress_2 = buProgressBar.CopyVisual(f_ControlUIProgress2.Progress_Ref, Progress_2);
							buEyeVars.parVisual.hmiProgress2 = new hmiUISettings(f_ControlUIProgress2.Settings);
						}
						f_ControlUIProgress2.Dispose();
					}
					if (control.Name == buGroup_1.Name)
					{
						F_ControlUIGroup f_ControlUIGroup = new F_ControlUIGroup();
						f_ControlUIGroup.Settings = new hmiUISettings(buEyeVars.parVisual.hmiGroup1);
						f_ControlUIGroup.Init();
						f_ControlUIGroup.ShowDialog();
						if (f_ControlUIGroup.PropertiesForm.Result == DialogResult.OK)
						{
							buGroup_1 = buGroup.CopyVisual(f_ControlUIGroup.grp_ref, buGroup_1);
							buEyeVars.parVisual.hmiGroup1 = new hmiUISettings(f_ControlUIGroup.Settings);
						}
						f_ControlUIGroup.Dispose();
					}
					if (control.Name == buGroup_0.Name)
					{
						F_ControlUIGroup f_ControlUIGroup2 = new F_ControlUIGroup();
						f_ControlUIGroup2.Settings = new hmiUISettings(buEyeVars.parVisual.hmiGroup2);
						f_ControlUIGroup2.Init();
						f_ControlUIGroup2.ShowDialog();
						if (f_ControlUIGroup2.PropertiesForm.Result == DialogResult.OK)
						{
							buGroup_0 = buGroup.CopyVisual(f_ControlUIGroup2.grp_ref, buGroup_0);
							buEyeVars.parVisual.hmiGroup2 = new hmiUISettings(f_ControlUIGroup2.Settings);
						}
						f_ControlUIGroup2.Dispose();
					}
					if (control.Name == buGround_0.Name)
					{
						F_ControlUIGround f_ControlUIGround = new F_ControlUIGround();
						f_ControlUIGround.Settings = new hmiUISettings(buEyeVars.parVisual.hmiGround1);
						f_ControlUIGround.Init();
						f_ControlUIGround.ShowDialog();
						if (f_ControlUIGround.PropertiesForm.Result == DialogResult.OK)
						{
							buGround_0 = buGround.CopyVisual(f_ControlUIGround.Ground_Ref, buGround_0);
							buEyeVars.parVisual.hmiGround1 = new hmiUISettings(f_ControlUIGround.Settings);
						}
						f_ControlUIGround.Dispose();
					}
					if (control.Name == buGround_1.Name)
					{
						F_ControlUIGround f_ControlUIGround2 = new F_ControlUIGround();
						f_ControlUIGround2.Settings = new hmiUISettings(buEyeVars.parVisual.hmiGround2);
						f_ControlUIGround2.Init();
						f_ControlUIGround2.ShowDialog();
						if (f_ControlUIGround2.PropertiesForm.Result == DialogResult.OK)
						{
							buGround_1 = buGround.CopyVisual(f_ControlUIGround2.Ground_Ref, buGround_1);
							buEyeVars.parVisual.hmiGround2 = new hmiUISettings(f_ControlUIGround2.Settings);
						}
						f_ControlUIGround2.Dispose();
					}
					if (control.Name == buComboBox_3.Name)
					{
						F_ControlUICombo f_ControlUICombo = new F_ControlUICombo();
						f_ControlUICombo.Settings = new hmiUISettings(buEyeVars.parVisual.hmiCombo1);
						f_ControlUICombo.Init();
						f_ControlUICombo.ShowDialog();
						if (f_ControlUICombo.PropertiesForm.Result == DialogResult.OK)
						{
							buComboBox_3 = buComboBox.CopyVisual(f_ControlUICombo.Cmb_Ref, buComboBox_3);
							buEyeVars.parVisual.hmiCombo1 = new hmiUISettings(f_ControlUICombo.Settings);
						}
						f_ControlUICombo.Dispose();
					}
					if (control.Name == buPanel_1.Name)
					{
						F_ControlUIPanel f_ControlUIPanel = new F_ControlUIPanel();
						f_ControlUIPanel.Settings = new hmiUISettings(buEyeVars.parVisual.hmiPanel1);
						f_ControlUIPanel.Init();
						f_ControlUIPanel.ShowDialog();
						if (f_ControlUIPanel.PropertiesForm.Result == DialogResult.OK)
						{
							buPanel_1 = buPanel.CopyVisual(f_ControlUIPanel.pnl_ref, buPanel_1);
							buEyeVars.parVisual.hmiPanel1 = new hmiUISettings(f_ControlUIPanel.Settings);
						}
						f_ControlUIPanel.Dispose();
					}
					if (control.Name == buPanel_0.Name)
					{
						F_ControlUIPanel f_ControlUIPanel2 = new F_ControlUIPanel();
						f_ControlUIPanel2.Settings = new hmiUISettings(buEyeVars.parVisual.hmiPanel2);
						f_ControlUIPanel2.Init();
						f_ControlUIPanel2.ShowDialog();
						if (f_ControlUIPanel2.PropertiesForm.Result == DialogResult.OK)
						{
							buPanel_0 = buPanel.CopyVisual(f_ControlUIPanel2.pnl_ref, buPanel_0);
							buEyeVars.parVisual.hmiPanel2 = new hmiUISettings(f_ControlUIPanel2.Settings);
						}
						f_ControlUIPanel2.Dispose();
					}
					if ((control.Name == lbl_coord1.Name) | (control.Name == lbl_coord1val.Name))
					{
						F_ControlUICoordinate f_ControlUICoordinate = new F_ControlUICoordinate();
						f_ControlUICoordinate.Settings = new hmiUISettings(buEyeVars.parVisual.hmiCoords1);
						f_ControlUICoordinate.Init();
						f_ControlUICoordinate.ShowDialog();
						if (f_ControlUICoordinate.PropertiesForm.Result == DialogResult.OK)
						{
							lbl_coord1 = buLabel.CopyVisual(f_ControlUICoordinate.lbl_caption, lbl_coord1);
							lbl_coord1val = buLabel.CopyVisual(f_ControlUICoordinate.lbl_val, lbl_coord1val);
							buEyeVars.parVisual.hmiCoords1 = new hmiUISettings(f_ControlUICoordinate.Settings);
						}
						f_ControlUICoordinate.Dispose();
					}
					if ((control.Name == lbl_coord2.Name) | (control.Name == lbl_coord2val.Name))
					{
						F_ControlUICoordinate f_ControlUICoordinate2 = new F_ControlUICoordinate();
						f_ControlUICoordinate2.Settings = new hmiUISettings(buEyeVars.parVisual.hmiCoords2);
						f_ControlUICoordinate2.Init();
						f_ControlUICoordinate2.ShowDialog();
						if (f_ControlUICoordinate2.PropertiesForm.Result == DialogResult.OK)
						{
							lbl_coord2 = buLabel.CopyVisual(f_ControlUICoordinate2.lbl_caption, lbl_coord2);
							lbl_coord2val = buLabel.CopyVisual(f_ControlUICoordinate2.lbl_val, lbl_coord2val);
							buEyeVars.parVisual.hmiCoords2 = new hmiUISettings(f_ControlUICoordinate2.Settings);
						}
						f_ControlUICoordinate2.Dispose();
					}
					if ((control.Name == spn_speed.Name) | (control.Name == lbl_speed.Name) | (control.Name == btn_speedminus.Name) | (control.Name == btn_speedplus.Name) | (control.Name == track_speed.Name))
					{
						F_ControlUISpeeds f_ControlUISpeeds = new F_ControlUISpeeds();
						f_ControlUISpeeds.Settings = new hmiUISettings(buEyeVars.parVisual.hmiSpeed1);
						f_ControlUISpeeds.Init();
						f_ControlUISpeeds.ShowDialog();
						if (f_ControlUISpeeds.PropertiesForm.Result == DialogResult.OK)
						{
							track_speed = hmiUICommands.hmiToBuTrack(f_ControlUISpeeds.Settings, track_speed);
							lbl_speed = buLabel.CopyVisual(f_ControlUISpeeds.lbl_speed, lbl_speed);
							spn_speed = buSpin.CopyVisual(f_ControlUISpeeds.spn_speed, spn_speed);
							btn_speedplus = buButton.CopyVisual(f_ControlUISpeeds.btn_plus, btn_speedplus);
							btn_speedminus = buButton.CopyVisual(f_ControlUISpeeds.btn_minus, btn_speedminus);
							buEyeVars.parVisual.hmiSpeed1 = new hmiUISettings(f_ControlUISpeeds.Settings);
						}
						f_ControlUISpeeds.Dispose();
					}
					if (control.Name == track_2.Name)
					{
						F_ControlUITrack f_ControlUITrack3 = new F_ControlUITrack();
						f_ControlUITrack3.Settings = new hmiUISettings(buEyeVars.parVisual.hmiTrack2);
						f_ControlUITrack3.Init();
						f_ControlUITrack3.ShowDialog();
						if (f_ControlUITrack3.PropertiesForm.Result == DialogResult.OK)
						{
							track_2 = buTrack.CopyVisual(f_ControlUITrack3.track_ref, track_2);
							buEyeVars.parVisual.hmiTrack2 = new hmiUISettings(f_ControlUITrack3.Settings);
						}
						f_ControlUITrack3.Dispose();
					}
					if (control.Name == btn_on1.Name)
					{
						F_ControlUIBasic f_ControlUIBasic = new F_ControlUIBasic();
						f_ControlUIBasic.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiOn1);
						f_ControlUIBasic.Init();
						f_ControlUIBasic.ShowDialog();
						if (f_ControlUIBasic.PropertiesForm.Result == DialogResult.OK)
						{
							btn_on1.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiOn1.Display, btn_on1.Display);
							btn_on1.ButtonDownDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOn1.Display, btn_on1.ButtonDownDisplay);
							btn_on1.ButtonOverDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOn1.Display, btn_on1.ButtonOverDisplay);
							btn_on1.Geometry.ArcDiameter = f_ControlUIBasic.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiOn1 = new hmiUIBasicSettings(f_ControlUIBasic.Settings);
						}
						f_ControlUIBasic.Dispose();
					}
					if (control.Name == btn_off1.Name)
					{
						F_ControlUIBasic f_ControlUIBasic2 = new F_ControlUIBasic();
						f_ControlUIBasic2.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiOff1);
						f_ControlUIBasic2.Init();
						f_ControlUIBasic2.ShowDialog();
						if (f_ControlUIBasic2.PropertiesForm.Result == DialogResult.OK)
						{
							btn_off1.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiOff1.Display, btn_off1.Display);
							btn_off1.ButtonDownDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOff1.Display, btn_off1.ButtonDownDisplay);
							btn_off1.ButtonOverDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOff1.Display, btn_off1.ButtonOverDisplay);
							btn_off1.Geometry.ArcDiameter = f_ControlUIBasic2.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiOff1 = new hmiUIBasicSettings(f_ControlUIBasic2.Settings);
						}
						f_ControlUIBasic2.Dispose();
					}
					if (control.Name == btn_on2.Name)
					{
						F_ControlUIBasic f_ControlUIBasic3 = new F_ControlUIBasic();
						f_ControlUIBasic3.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiOn2);
						f_ControlUIBasic3.Init();
						f_ControlUIBasic3.ShowDialog();
						if (f_ControlUIBasic3.PropertiesForm.Result == DialogResult.OK)
						{
							btn_on2.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiOn2.Display, btn_on2.Display);
							btn_on2.ButtonDownDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOn2.Display, btn_on2.ButtonDownDisplay);
							btn_on2.ButtonOverDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOn2.Display, btn_on2.ButtonOverDisplay);
							btn_on2.Geometry.ArcDiameter = f_ControlUIBasic3.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiOn2 = new hmiUIBasicSettings(f_ControlUIBasic3.Settings);
						}
						f_ControlUIBasic3.Dispose();
					}
					if (control.Name == btn_off2.Name)
					{
						F_ControlUIBasic f_ControlUIBasic4 = new F_ControlUIBasic();
						f_ControlUIBasic4.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiOff2);
						f_ControlUIBasic4.Init();
						f_ControlUIBasic4.ShowDialog();
						if (f_ControlUIBasic4.PropertiesForm.Result == DialogResult.OK)
						{
							btn_off2.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiOff2.Display, btn_off2.Display);
							btn_off2.ButtonDownDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOff2.Display, btn_off2.ButtonDownDisplay);
							btn_off2.ButtonOverDisplay = buControlDisplay.Copy(buEyeVars.parVisual.hmiOff2.Display, btn_off2.ButtonOverDisplay);
							btn_off2.Geometry.ArcDiameter = f_ControlUIBasic4.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiOff2 = new hmiUIBasicSettings(f_ControlUIBasic4.Settings);
						}
						f_ControlUIBasic4.Dispose();
					}
					if (control.Name == buLabel_27.Name)
					{
						F_ControlUIBasic f_ControlUIBasic5 = new F_ControlUIBasic();
						f_ControlUIBasic5.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiWarning);
						f_ControlUIBasic5.Init();
						f_ControlUIBasic5.ShowDialog();
						if (f_ControlUIBasic5.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_27.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiWarning.Display, buLabel_27.Display);
							buLabel_27.Geometry.ArcDiameter = f_ControlUIBasic5.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiWarning = new hmiUIBasicSettings(f_ControlUIBasic5.Settings);
						}
						f_ControlUIBasic5.Dispose();
					}
					if (control.Name == buLabel_26.Name)
					{
						F_ControlUIBasic f_ControlUIBasic6 = new F_ControlUIBasic();
						f_ControlUIBasic6.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiError);
						f_ControlUIBasic6.Init();
						f_ControlUIBasic6.ShowDialog();
						if (f_ControlUIBasic6.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_26.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiError.Display, buLabel_26.Display);
							buLabel_26.Geometry.ArcDiameter = f_ControlUIBasic6.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiError = new hmiUIBasicSettings(f_ControlUIBasic6.Settings);
						}
						f_ControlUIBasic6.Dispose();
					}
					if (control.Name == buLabel_25.Name)
					{
						F_ControlUIBasic f_ControlUIBasic7 = new F_ControlUIBasic();
						f_ControlUIBasic7.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiInfo);
						f_ControlUIBasic7.Init();
						f_ControlUIBasic7.ShowDialog();
						if (f_ControlUIBasic7.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_25.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiInfo.Display, buLabel_25.Display);
							buLabel_25.Geometry.ArcDiameter = f_ControlUIBasic7.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiInfo = new hmiUIBasicSettings(f_ControlUIBasic7.Settings);
						}
						f_ControlUIBasic7.Dispose();
					}
					if (control.Name == buLabel_24.Name)
					{
						F_ControlUIBasic f_ControlUIBasic8 = new F_ControlUIBasic();
						f_ControlUIBasic8.Settings = new hmiUIBasicSettings(buEyeVars.parVisual.hmiStatus);
						f_ControlUIBasic8.Init();
						f_ControlUIBasic8.ShowDialog();
						if (f_ControlUIBasic8.PropertiesForm.Result == DialogResult.OK)
						{
							buLabel_24.Display = buControlDisplay.Copy(buEyeVars.parVisual.hmiStatus.Display, buLabel_24.Display);
							buLabel_24.Geometry.ArcDiameter = f_ControlUIBasic8.Settings.Parameters.GeometryArcDiameer;
							buEyeVars.parVisual.hmiStatus = new hmiUIBasicSettings(f_ControlUIBasic8.Settings);
						}
						f_ControlUIBasic8.Dispose();
					}
				}
				else
				{
					PropertiesForm.Result = DialogResult.Cancel;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						Dispose();
					}
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						base.Visible = false;
					}
				}
			}
			else
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					Dispose();
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					base.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = sender as DataGridView;
		if (dataGridView.Name == dataGridView_1.Name)
		{
			F_ControlUIDataGridView f_ControlUIDataGridView = new F_ControlUIDataGridView();
			f_ControlUIDataGridView.dgv_ref = hmiUICommands.hmiToDataGridView(buEyeVars.parVisual.hmiDGV1, f_ControlUIDataGridView.dgv_ref);
			f_ControlUIDataGridView.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			f_ControlUIDataGridView.Init();
			f_ControlUIDataGridView.ShowDialog();
			if (f_ControlUIDataGridView.PropertiesForm.Result == DialogResult.OK)
			{
				buEyeVars.parVisual.hmiDGV1.colorHeader = f_ControlUIDataGridView.dgv_ref.ColumnHeadersDefaultCellStyle.BackColor;
				buEyeVars.parVisual.hmiDGV1.colorHeaderFore = f_ControlUIDataGridView.dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
				buEyeVars.parVisual.hmiDGV1.fontHeader = new Font(buEyeVars.parVisual.hmiDGV1.fontHeader.Name, buEyeVars.parVisual.hmiDGV1.fontHeader.Size, buEyeVars.parVisual.hmiDGV1.fontHeader.Style);
				buEyeVars.parVisual.hmiDGV1.colorHeaderFore = f_ControlUIDataGridView.dgv_ref.RowHeadersDefaultCellStyle.ForeColor;
				buEyeVars.parVisual.hmiDGV1.colorHeader = f_ControlUIDataGridView.dgv_ref.RowHeadersDefaultCellStyle.BackColor;
				buEyeVars.parVisual.hmiDGV1.colorGrid = f_ControlUIDataGridView.dgv_ref.GridColor;
				buEyeVars.parVisual.hmiDGV1.colorBackGround = f_ControlUIDataGridView.dgv_ref.BackgroundColor;
				buEyeVars.parVisual.hmiDGV1.colorCellSelected = f_ControlUIDataGridView.dgv_ref.DefaultCellStyle.SelectionBackColor;
				buEyeVars.parVisual.hmiDGV1.colorFore = f_ControlUIDataGridView.dgv_ref.DefaultCellStyle.SelectionForeColor;
				buEyeVars.parVisual.hmiDGV1.fontCell = new Font(buEyeVars.parVisual.hmiDGV1.fontCell.Name, buEyeVars.parVisual.hmiDGV1.fontCell.Size, buEyeVars.parVisual.hmiDGV1.fontCell.Style);
				buEyeVars.parVisual.hmiDGV1.colorCell = f_ControlUIDataGridView.dgv_ref.DefaultCellStyle.BackColor;
				buEyeVars.parVisual.hmiDGV1.colorFore = f_ControlUIDataGridView.dgv_ref.DefaultCellStyle.ForeColor;
				dataGridView_1 = hmiUICommands.hmiToDataGridView(buEyeVars.parVisual.hmiDGV1, dataGridView_1);
			}
			f_ControlUIDataGridView.Dispose();
		}
		if (dataGridView.Name == dataGridView_0.Name)
		{
			F_ControlUIDataGridView f_ControlUIDataGridView2 = new F_ControlUIDataGridView();
			f_ControlUIDataGridView2.dgv_ref = hmiUICommands.hmiToDataGridView(buEyeVars.parVisual.hmiDGV2, f_ControlUIDataGridView2.dgv_ref);
			f_ControlUIDataGridView2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			f_ControlUIDataGridView2.Init();
			f_ControlUIDataGridView2.ShowDialog();
			if (f_ControlUIDataGridView2.PropertiesForm.Result == DialogResult.OK)
			{
				buEyeVars.parVisual.hmiDGV2.colorHeader = f_ControlUIDataGridView2.dgv_ref.ColumnHeadersDefaultCellStyle.BackColor;
				buEyeVars.parVisual.hmiDGV2.colorHeaderFore = f_ControlUIDataGridView2.dgv_ref.ColumnHeadersDefaultCellStyle.ForeColor;
				buEyeVars.parVisual.hmiDGV2.fontHeader = new Font(buEyeVars.parVisual.hmiDGV1.fontHeader.Name, buEyeVars.parVisual.hmiDGV1.fontHeader.Size, buEyeVars.parVisual.hmiDGV1.fontHeader.Style);
				buEyeVars.parVisual.hmiDGV2.colorHeaderFore = f_ControlUIDataGridView2.dgv_ref.RowHeadersDefaultCellStyle.ForeColor;
				buEyeVars.parVisual.hmiDGV2.colorHeader = f_ControlUIDataGridView2.dgv_ref.RowHeadersDefaultCellStyle.BackColor;
				buEyeVars.parVisual.hmiDGV2.colorGrid = f_ControlUIDataGridView2.dgv_ref.GridColor;
				buEyeVars.parVisual.hmiDGV2.colorBackGround = f_ControlUIDataGridView2.dgv_ref.BackgroundColor;
				buEyeVars.parVisual.hmiDGV2.colorCellSelected = f_ControlUIDataGridView2.dgv_ref.DefaultCellStyle.SelectionBackColor;
				buEyeVars.parVisual.hmiDGV2.colorFore = f_ControlUIDataGridView2.dgv_ref.DefaultCellStyle.SelectionForeColor;
				buEyeVars.parVisual.hmiDGV2.fontCell = new Font(buEyeVars.parVisual.hmiDGV1.fontCell.Name, buEyeVars.parVisual.hmiDGV1.fontCell.Size, buEyeVars.parVisual.hmiDGV1.fontCell.Style);
				buEyeVars.parVisual.hmiDGV2.colorCell = f_ControlUIDataGridView2.dgv_ref.DefaultCellStyle.BackColor;
				buEyeVars.parVisual.hmiDGV2.colorFore = f_ControlUIDataGridView2.dgv_ref.DefaultCellStyle.ForeColor;
				dataGridView_0 = hmiUICommands.hmiToDataGridView(buEyeVars.parVisual.hmiDGV1, dataGridView_0);
			}
			f_ControlUIDataGridView2.Dispose();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
