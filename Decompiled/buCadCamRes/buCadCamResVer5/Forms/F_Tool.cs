using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCadCamResVer5.Marble;
using buControls;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_Tool : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ToolBase5 Tool = new ToolBase5();

	public Design viewportLayout;

	public string pathTool = Application.StartupPath;

	private int int_0 = -1;

	private int int_1 = -1;

	private List<TabPage> list_0 = new List<TabPage>();

	private readonly List<NumericUpDown> invalidAxisLimitControls = new List<NumericUpDown>();

	private Button saveMachineLimitsButton;

	private Button loadMachineLimitsButton;

	private Label machineLimitsStatusLabel;

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal ComboBox comboBox_0;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_0;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_1;

	internal TextBox textBox_0;

	internal Label label_5;

	internal TabPage tabPage_1;

	internal Label label_6;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_7;

	internal Panel panel_2;

	internal Label label_8;

	internal NumericUpDown numericUpDown_6;

	internal Panel panel_3;

	internal Label label_9;

	internal NumericUpDown numericUpDown_7;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal Panel panel_4;

	internal NumericUpDown numericUpDown_9;

	internal Label label_11;

	internal Panel panel_5;

	internal TextBox textBox_1;

	internal TextBox textBox_2;

	internal TextBox textBox_3;

	internal TextBox textBox_4;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal Label label_12;

	internal Label label_13;

	internal NumericUpDown numericUpDown_10;

	internal ComboBox comboBox_1;

	internal Label label_14;

	internal TabPage tabPage_2;

	internal Panel panel_6;

	internal Panel panel_7;

	internal NumericUpDown numericUpDown_11;

	internal Label label_15;

	internal NumericUpDown numericUpDown_12;

	internal Label label_16;

	internal Panel panel_8;

	internal Label label_17;

	internal NumericUpDown numericUpDown_13;

	internal Label label_18;

	internal NumericUpDown numericUpDown_14;

	internal Panel panel_9;

	internal Label label_19;

	internal NumericUpDown numericUpDown_15;

	internal Label label_20;

	internal NumericUpDown numericUpDown_16;

	internal Label label_21;

	internal Panel panel_10;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal CheckBox checkBox_6;

	internal Label label_22;

	internal Panel panel_11;

	internal Panel panel_12;

	internal NumericUpDown numericUpDown_17;

	internal Label label_23;

	internal NumericUpDown numericUpDown_18;

	internal Label label_24;

	internal Panel panel_13;

	internal Label label_25;

	internal NumericUpDown numericUpDown_19;

	internal Label label_26;

	internal NumericUpDown numericUpDown_20;

	internal Panel panel_14;

	internal Label label_27;

	internal NumericUpDown numericUpDown_21;

	internal Label label_28;

	internal NumericUpDown numericUpDown_22;

	internal Label label_29;

	internal Panel panel_15;

	internal CheckBox checkBox_7;

	internal CheckBox checkBox_8;

	internal CheckBox checkBox_9;

	internal CheckBox checkBox_10;

	internal CheckBox checkBox_11;

	internal CheckBox checkBox_12;

	internal CheckBox checkBox_13;

	internal CheckBox checkBox_14;

	internal Label label_30;

	internal TabPage tabPage_3;

	internal Label label_31;

	internal TextBox textBox_5;

	internal Label label_32;

	internal Label label_33;

	internal NumericUpDown numericUpDown_23;

	internal Label label_34;

	internal TextBox textBox_6;

	internal Panel panel_16;

	internal CheckBox checkBox_15;

	internal Label label_35;

	internal Button button_0;

	internal Panel panel_17;

	internal CheckBox checkBox_16;

	internal NumericUpDown numericUpDown_24;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal NumericUpDown numericUpDown_25;

	internal Label label_36;

	internal Panel panel_18;

	internal Label label_37;

	internal Label label_38;

	internal CheckBox checkBox_17;

	internal CheckBox checkBox_18;

	internal Label label_39;

	internal Label label_40;

	internal ComboBox comboBox_2;

	internal NumericUpDown numericUpDown_26;

	internal Label label_41;

	internal Label label_42;

	internal NumericUpDown numericUpDown_27;

	internal NumericUpDown numericUpDown_28;

	internal Label label_43;

	internal NumericUpDown numericUpDown_29;

	internal Label label_44;

	internal NumericUpDown numericUpDown_30;

	internal Label label_45;

	internal NumericUpDown numericUpDown_31;

	internal Label label_46;

	internal Label label_47;

	internal NumericUpDown numericUpDown_32;

	internal Label label_48;

	internal NumericUpDown numericUpDown_33;

	internal NumericUpDown numericUpDown_34;

	internal Label label_49;

	internal Label label_50;

	internal NumericUpDown numericUpDown_35;

	internal Label label_51;

	internal NumericUpDown numericUpDown_36;

	internal TabPage tabPage_4;

	internal TabPage tabPage_5;

	internal Label label_52;

	internal NumericUpDown numericUpDown_37;

	internal Label label_53;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal Label label_54;

	internal NumericUpDown numericUpDown_38;

	internal Label label_55;

	internal RadioButton radioButton_5;

	internal RadioButton radioButton_6;

	internal NumericUpDown numericUpDown_39;

	internal Label label_56;

	internal Label label_57;

	internal NumericUpDown numericUpDown_40;

	internal Label label_58;

	internal NumericUpDown numericUpDown_41;

	internal Label label_59;

	internal RadioButton radioButton_7;

	internal RadioButton radioButton_8;

	internal RadioButton radioButton_9;

	internal Label label_60;

	internal NumericUpDown numericUpDown_42;

	internal NumericUpDown numericUpDown_43;

	internal Label label_61;

	internal Label label_62;

	internal NumericUpDown numericUpDown_44;

	internal Label label_63;

	internal NumericUpDown numericUpDown_45;

	internal Label label_64;

	internal NumericUpDown numericUpDown_46;

	internal NumericUpDown numericUpDown_47;

	internal Label label_65;

	internal Label label_66;

	internal NumericUpDown numericUpDown_48;

	internal Label label_67;

	internal NumericUpDown numericUpDown_49;

	internal Label label_68;

	internal NumericUpDown numericUpDown_50;

	internal NumericUpDown numericUpDown_51;

	internal Label label_69;

	internal Label label_70;

	internal NumericUpDown numericUpDown_52;

	internal Label label_71;

	internal NumericUpDown numericUpDown_53;

	internal Label label_72;

	internal TextBox textBox_7;

	internal Label label_73;

	internal TextBox textBox_8;

	internal Label label_74;

	internal TextBox textBox_9;

	internal Label label_75;

	internal TextBox textBox_10;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_0;

	internal NumericUpDown numericUpDown_54;

	internal Label label_76;

	internal Label label_77;

	internal NumericUpDown numericUpDown_55;

	internal Label label_78;

	internal RadioButton radioButton_10;

	internal RadioButton radioButton_11;

	internal RadioButton radioButton_12;

	internal NumericUpDown numericUpDown_56;

	internal Label label_79;

	public Button btn_aggregatesettings;

	internal CheckBox checkBox_19;

	internal Label label_80;

	public Panel pnl_model;

	internal Panel panel_19;

	internal Label label_81;

	internal Label label_82;

	internal Label label_83;

	internal Label label_84;

	internal Label label_85;

	internal Label label_86;

	internal Label label_87;

	internal Label label_88;

	internal Label label_89;

	internal Label label_90;

	internal Label label_91;

	internal Label label_92;

	internal Label label_93;

	internal Label label_94;

	internal Label label_95;

	internal Label label_96;

	internal Label label_97;

	internal Button button_1;

	internal CheckBox checkBox_20;

	internal CheckBox checkBox_21;

	internal CheckBox checkBox_22;

	public DataGridView DGV_Arbor;

	public DataGridView DGV_Holder;

	internal Button button_2;

	internal Panel panel_20;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Panel panel_21;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Label label_98;

	internal Label label_99;

	internal CheckBox checkBox_23;

	internal Button button_12;

	internal Label label_100;

	internal NumericUpDown numericUpDown_57;

	internal Label label_101;

	internal TabControl tabControl_1;

	internal TabPage tabPage_6;

	internal TabPage tabPage_7;

	internal TabPage tabPage_8;

	internal TabPage tabPage_9;

	internal TabPage tabPage_10;

	internal TabPage tabPage_11;

	internal TabPage tabPage_12;

	internal TabPage tabPage_13;

	internal TabPage tabPage_14;

	internal TabPage tabPage_15;

	internal TabPage tabPage_16;

	internal TabPage tabPage_17;

	internal ImageList imageList_1;

	internal TabPage tabPage_18;

	internal Label label_102;

	internal NumericUpDown numericUpDown_58;

	internal TabPage tabPage_19;

	internal Label label_103;

	internal NumericUpDown numericUpDown_59;

	internal Button button_13;

	internal Button button_14;

	internal NumericUpDown numericUpDown_60;

	internal Label label_104;

	internal Label label_105;

	internal NumericUpDown numericUpDown_61;

	internal Label label_106;

	internal NumericUpDown numericUpDown_62;

	public F_Tool()
	{
		Class5.smethod_108(this);
		if (viewportLayout == null)
		{
			viewportLayout = new Design();
		}
	}

	public void Init()
	{
		Properties.Inited = false;
		ArrayList arrayList = new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		for (int i = 0; i <= tabControl_1.TabPages.Count - 1; i++)
		{
			list_0.Add(tabControl_1.TabPages[i]);
		}
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Purpose, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Purpose), ref comboBox_0);
		numericUpDown_3.Value = Tool.Data.No;
		numericUpDown_2.Value = Tool.Data.Sector;
		numericUpDown_1.Value = Tool.Data.HeightOffsetIndex;
		numericUpDown_0.Value = Tool.Data.Priority;
		numericUpDown_61.Value = (decimal)Tool.Data.TappingInfo;
		numericUpDown_62.Value = Tool.Data.HeadNumber;
		textBox_0.Text = Tool.Data.Name;
		textBox_6.Text = Tool.Data.Tag;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Geometry.GeometryType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Geometry.GeometryType), ref comboBox_2);
		checkBox_19.Checked = Tool.Data.isAgregate;
		numericUpDown_27.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_28.Value = (decimal)Tool.Geometry.CutLength;
		checkBox_21.Checked = Tool.Geometry.DrawArbor;
		checkBox_22.Checked = Tool.Geometry.DrawHolder;
		checkBox_20.Checked = Tool.Geometry.DrawLength;
		numericUpDown_26.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_32.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_34.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_33.Value = (decimal)Tool.Geometry.RoundRadius;
		numericUpDown_37.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_29.Value = (decimal)Tool.Geometry.Thickness;
		numericUpDown_36.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_30.Value = (decimal)Tool.Geometry.TaperAngle;
		numericUpDown_56.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_35.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_54.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_55.Value = (decimal)Tool.Geometry.UpperRadius;
		numericUpDown_38.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_31.Value = (decimal)Tool.Geometry.OutsideDiameter;
		numericUpDown_41.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_39.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_40.Value = (decimal)Tool.Geometry.TaperAngle;
		numericUpDown_45.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_43.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_42.Value = (decimal)Tool.Geometry.OutsideDiameter;
		numericUpDown_44.Value = (decimal)Tool.Geometry.TaperAngle;
		numericUpDown_47.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_46.Value = (decimal)Tool.Geometry.MaxDiameter;
		numericUpDown_48.Value = (decimal)Tool.Geometry.ProfileRadius;
		numericUpDown_49.Value = (decimal)Tool.Geometry.UpperDiameter;
		numericUpDown_50.Value = (decimal)Tool.Geometry.FlatnessDiameter;
		numericUpDown_53.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_51.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_52.Value = (decimal)Tool.Geometry.ConvexTipRadius;
		numericUpDown_57.Value = (decimal)Tool.Geometry.FromFileAngle;
		checkBox_23.Checked = Tool.Geometry.FromFileEnable;
		label_101.Text = Tool.Geometry.FromFileFileName;
		if (Tool.Geometry.CornerRadiusType != ToolCornerRadiusType.None)
		{
			if (Tool.Geometry.CornerRadiusType != ToolCornerRadiusType.Corner)
			{
				radioButton_7.Checked = true;
				radioButton_10.Checked = true;
				radioButton_2.Checked = true;
			}
			else
			{
				radioButton_8.Checked = true;
				radioButton_5.Checked = true;
				radioButton_11.Checked = true;
				radioButton_3.Checked = true;
			}
		}
		else
		{
			radioButton_9.Checked = true;
			radioButton_6.Checked = true;
			radioButton_12.Checked = true;
			radioButton_4.Checked = true;
		}
		Class5.smethod_178(this);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.CamData.SpindleDirection, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.CamData.SpindleDirection), ref comboBox_1);
		if (Tool.CamData.DepthType != CamDepthType.Constant)
		{
			radioButton_0.Checked = true;
		}
		else
		{
			radioButton_1.Checked = true;
		}
		numericUpDown_25.Value = (decimal)Tool.CamData.DepthConstant;
		numericUpDown_24.Value = Tool.CamData.DepthSliceCount;
		numericUpDown_5.Value = (decimal)Tool.CamData.Cutover;
		numericUpDown_6.Value = (decimal)Tool.CamData.OperationHeight;
		numericUpDown_7.Value = (decimal)Tool.CamData.FeedSpeed;
		numericUpDown_4.Value = (decimal)Tool.CamData.FinishSpeed;
		numericUpDown_23.Value = (decimal)Tool.CamData.RetractSpeed;
		numericUpDown_8.Value = (decimal)Tool.CamData.PlungeSpeed;
		numericUpDown_10.Value = (decimal)Tool.CamData.SpindleSpeed;
		numericUpDown_9.Value = (decimal)Tool.CamData.SafeDistance;
		numericUpDown_60.Value = (decimal)Tool.CamData.RapidDistance;
		checkBox_2.Checked = Tool.CamData.Air;
		checkBox_0.Checked = Tool.CamData.InnerCooling;
		checkBox_1.Checked = Tool.CamData.Oil;
		checkBox_3.Checked = Tool.CamData.Water;
		checkBox_17.Checked = Tool.CamData.FeedFromTool;
		checkBox_18.Checked = Tool.CamData.DistanceFromTool;
		checkBox_16.Checked = Tool.CamData.DepthFromTool;
		checkBox_15.Checked = Tool.CamData.CutOverrideFromTool;
		textBox_3.Text = buString.ArrayListToString(Tool.CamData.AirText, NewLineEnable: true);
		textBox_4.Text = buString.ArrayListToString(Tool.CamData.WaterText, NewLineEnable: true);
		textBox_2.Text = buString.ArrayListToString(Tool.CamData.InnerCoolText, NewLineEnable: true);
		textBox_1.Text = buString.ArrayListToString(Tool.CamData.OilText, NewLineEnable: true);
		label_93.BackColor = Tool.Display.ToolBodySolid.SkinColor;
		label_95.BackColor = Tool.Display.ToolCutSolid.SkinColor;
		label_92.BackColor = Tool.Display.HolderSolid.SkinColor;
		label_90.BackColor = Tool.Display.ArborSolid.SkinColor;
		label_88.BackColor = Tool.Display.CamColor;
		label_86.BackColor = Tool.Display.UpperCamColor;
		label_84.BackColor = Tool.Display.PlungeColor;
		label_82.BackColor = Tool.Display.LeaveColor;
		SetAxisLimitValue(numericUpDown_19, Tool.Limits.AxesMinLimits.A);
		SetAxisLimitValue(numericUpDown_21, Tool.Limits.AxesMinLimits.B);
		SetAxisLimitValue(numericUpDown_18, Tool.Limits.AxesMinLimits.C);
		SetAxisLimitValue(numericUpDown_20, Tool.Limits.AxesMaxLimits.A);
		SetAxisLimitValue(numericUpDown_22, Tool.Limits.AxesMaxLimits.B);
		SetAxisLimitValue(numericUpDown_17, Tool.Limits.AxesMaxLimits.C);
		SetAxisLimitValue(numericUpDown_13, Tool.Limits.AxesMinLimits.X);
		SetAxisLimitValue(numericUpDown_15, Tool.Limits.AxesMinLimits.Y);
		SetAxisLimitValue(numericUpDown_12, Tool.Limits.AxesMinLimits.Z);
		SetAxisLimitValue(numericUpDown_14, Tool.Limits.AxesMaxLimits.X);
		SetAxisLimitValue(numericUpDown_16, Tool.Limits.AxesMaxLimits.Y);
		SetAxisLimitValue(numericUpDown_11, Tool.Limits.AxesMaxLimits.Z);
		checkBox_14.Checked = Tool.Limits.PlaneTop;
		checkBox_13.Checked = Tool.Limits.PlaneBottom;
		checkBox_10.Checked = Tool.Limits.PlaneFront;
		checkBox_9.Checked = Tool.Limits.PlaneBack;
		checkBox_12.Checked = Tool.Limits.PlaneLeft;
		checkBox_11.Checked = Tool.Limits.PlaneRight;
		checkBox_8.Checked = Tool.Limits.PlaneAll;
		checkBox_7.Checked = Tool.Limits.PlaneSlope;
		checkBox_6.Checked = Tool.Limits.RotationA;
		checkBox_5.Checked = Tool.Limits.RotationB;
		checkBox_4.Checked = Tool.Limits.RotationC;
		textBox_5.Text = buString.ArrayListToString(Tool.Aux, NewLineEnable: true);
		textBox_10.Text = buString.ArrayListToString(Tool.ToolPre, NewLineEnable: true);
		textBox_9.Text = buString.ArrayListToString(Tool.ToolNext, NewLineEnable: true);
		textBox_8.Text = buString.ArrayListToString(Tool.SpindlePre, NewLineEnable: true);
		textBox_7.Text = buString.ArrayListToString(Tool.SpindleNext, NewLineEnable: true);
		numericUpDown_61.Visible = false;
		label_105.Visible = false;
		if (Tool.Purpose == ToolPurpose.Tapping)
		{
			numericUpDown_61.Visible = true;
			label_105.Visible = true;
		}
		DGV_Holder.RowHeadersVisible = false;
		DGV_Holder.ColumnHeadersVisible = false;
		DGV_Holder.AllowUserToAddRows = false;
		DGV_Holder.AllowUserToResizeColumns = false;
		DGV_Holder.AllowUserToResizeRows = false;
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 70;
		dataGridViewColumn.HeaderText = "X";
		dataGridViewColumn.Name = "X";
		dataGridViewColumn.ReadOnly = false;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		DGV_Holder.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = 70;
		dataGridViewColumn2.HeaderText = "Y";
		dataGridViewColumn2.Name = "Y";
		dataGridViewColumn2.ReadOnly = false;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		DGV_Holder.Columns.Add(dataGridViewColumn2);
		DGV_Arbor.RowHeadersVisible = false;
		DGV_Arbor.ColumnHeadersVisible = false;
		DGV_Arbor.AllowUserToAddRows = false;
		DGV_Arbor.AllowUserToResizeColumns = false;
		DGV_Arbor.AllowUserToResizeRows = false;
		DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
		dataGridViewColumn3.Width = 60;
		dataGridViewColumn3.HeaderText = "X";
		dataGridViewColumn3.Name = "X";
		dataGridViewColumn3.ReadOnly = false;
		dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
		DGV_Arbor.Columns.Add(dataGridViewColumn3);
		DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
		dataGridViewColumn4.Width = 60;
		dataGridViewColumn4.HeaderText = "Y";
		dataGridViewColumn4.Name = "Y";
		dataGridViewColumn4.ReadOnly = false;
		dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
		DGV_Arbor.Columns.Add(dataGridViewColumn4);
		pnl_model.Controls.Add(viewportLayout);
		TabPAgeVisibility();
		Properties.Result = DialogResult.None;
		InitializeAxisLimitValidation();
		Properties.Inited = true;
		timer_0.Tick += Init_Tick;
		timer_0.Interval = 10;
		timer_0.Enabled = true;
	}

	public void Init_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		DrawTool();
		Class5.smethod_57(this);
		Class5.smethod_36(this);
	}

  private void SetAxisLimitValue(NumericUpDown control, double value)
  {
    bool invalid = double.IsNaN(value) || double.IsInfinity(value);
    decimal convertedValue = 0M;
    if (!invalid)
    {
      try
      {
        convertedValue = (decimal) value;
      }
      catch (OverflowException)
      {
        invalid = true;
      }
    }

    if (convertedValue < control.Minimum)
    {
      convertedValue = control.Minimum;
      invalid = true;
    }
    else if (convertedValue > control.Maximum)
    {
      convertedValue = control.Maximum;
      invalid = true;
    }

    control.Value = convertedValue;
    if (invalid && !this.invalidAxisLimitControls.Contains(control))
      this.invalidAxisLimitControls.Add(control);
  }

  private void InitializeAxisLimitValidation()
  {
    NumericUpDown[] controls = this.GetAxisLimitControls();
    for (int index = 0; index < controls.Length; ++index)
      controls[index].ValueChanged += new EventHandler(this.AxisLimitValueChanged);

    this.checkBox_6.CheckedChanged += new EventHandler(this.AxisLimitValueChanged);
    this.checkBox_5.CheckedChanged += new EventHandler(this.AxisLimitValueChanged);
    this.checkBox_4.CheckedChanged += new EventHandler(this.AxisLimitValueChanged);
    this.InitializeMachineEnvelopeControls();
    string ignoredMessage;
    this.TryValidateAxisLimits(out ignoredMessage);
  }

  private void InitializeMachineEnvelopeControls()
  {
    if (this.saveMachineLimitsButton != null)
      return;

    this.saveMachineLimitsButton = new Button();
    this.saveMachineLimitsButton.Name = "btn_save_machine_limits";
    this.saveMachineLimitsButton.Text = "Save as Machine Limits";
    this.saveMachineLimitsButton.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
    this.saveMachineLimitsButton.Location = new Point(7, 482);
    this.saveMachineLimitsButton.Size = new Size(220, 38);
    this.saveMachineLimitsButton.Click += new EventHandler(this.SaveMachineLimitsClick);

    this.loadMachineLimitsButton = new Button();
    this.loadMachineLimitsButton.Name = "btn_load_machine_limits";
    this.loadMachineLimitsButton.Text = "Load Machine Limits";
    this.loadMachineLimitsButton.Font = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
    this.loadMachineLimitsButton.Location = new Point(233, 482);
    this.loadMachineLimitsButton.Size = new Size(205, 38);
    this.loadMachineLimitsButton.Click += new EventHandler(this.LoadMachineLimitsClick);

    this.machineLimitsStatusLabel = new Label();
    this.machineLimitsStatusLabel.Name = "lbl_machine_limits_status";
    this.machineLimitsStatusLabel.Text = "Machine profile: not saved in this session";
    this.machineLimitsStatusLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
    this.machineLimitsStatusLabel.Location = new Point(444, 482);
    this.machineLimitsStatusLabel.Size = new Size(258, 38);
    this.machineLimitsStatusLabel.TextAlign = ContentAlignment.MiddleLeft;

    this.tabPage_2.Controls.Add(this.saveMachineLimitsButton);
    this.tabPage_2.Controls.Add(this.loadMachineLimitsButton);
    this.tabPage_2.Controls.Add(this.machineLimitsStatusLabel);
    this.saveMachineLimitsButton.BringToFront();
    this.loadMachineLimitsButton.BringToFront();
    this.machineLimitsStatusLabel.BringToFront();

    string profileFile = this.GetMachineProfileFilePath();
    this.machineLimitsStatusLabel.Text = File.Exists(profileFile)
      ? "Machine profile: saved"
      : "Machine profile: not configured";
    this.machineLimitsStatusLabel.ForeColor = File.Exists(profileFile) ? Color.DarkGreen : Color.DarkOrange;
  }

  private void SaveMachineLimitsClick(object sender, EventArgs e)
  {
    string validationMessage;
    if (!this.TryValidateAxisLimits(out validationMessage))
    {
      buString5.MessageBoxWarning(validationMessage);
      return;
    }

    try
    {
      FiveAxisSafetyProfile profile = new FiveAxisSafetyProfile()
      {
        XMin = (double) this.numericUpDown_13.Value,
        XMax = (double) this.numericUpDown_14.Value,
        YMin = (double) this.numericUpDown_15.Value,
        YMax = (double) this.numericUpDown_16.Value,
        ZMin = (double) this.numericUpDown_12.Value,
        ZMax = (double) this.numericUpDown_11.Value,
        AMin = (double) this.numericUpDown_19.Value,
        AMax = (double) this.numericUpDown_20.Value,
        BMin = (double) this.numericUpDown_21.Value,
        BMax = (double) this.numericUpDown_22.Value,
        CMin = (double) this.numericUpDown_18.Value,
        CMax = (double) this.numericUpDown_17.Value,
        MaxCuttingTiltDelta = FiveAxisPathSafety.ActiveProfile.MaxCuttingTiltDelta
      };
      FiveAxisSafetyProfileStore.Save(this.GetMachineProfileFilePath(), profile);
      FiveAxisPathSafety.Configure(profile);
      this.machineLimitsStatusLabel.Text = "Machine profile: saved and active";
      this.machineLimitsStatusLabel.ForeColor = Color.DarkGreen;
    }
    catch (Exception ex)
    {
      this.machineLimitsStatusLabel.Text = "Machine profile: save failed";
      this.machineLimitsStatusLabel.ForeColor = Color.DarkRed;
      buString5.MessageBoxWarning("Machine limits could not be saved: " + ex.Message);
    }
  }

  private void LoadMachineLimitsClick(object sender, EventArgs e)
  {
    try
    {
      FiveAxisSafetyProfile profile;
      string profileFile = this.GetMachineProfileFilePath();
      if (!FiveAxisSafetyProfileStore.TryLoad(profileFile, out profile))
      {
        buString5.MessageBoxWarning("A saved XYZ/ABC machine-limit profile was not found.");
        return;
      }

      this.invalidAxisLimitControls.Clear();
      this.SetAxisLimitValue(this.numericUpDown_13, profile.XMin);
      this.SetAxisLimitValue(this.numericUpDown_14, profile.XMax);
      this.SetAxisLimitValue(this.numericUpDown_15, profile.YMin);
      this.SetAxisLimitValue(this.numericUpDown_16, profile.YMax);
      this.SetAxisLimitValue(this.numericUpDown_12, profile.ZMin);
      this.SetAxisLimitValue(this.numericUpDown_11, profile.ZMax);
      this.SetAxisLimitValue(this.numericUpDown_19, profile.AMin);
      this.SetAxisLimitValue(this.numericUpDown_20, profile.AMax);
      this.SetAxisLimitValue(this.numericUpDown_21, profile.BMin);
      this.SetAxisLimitValue(this.numericUpDown_22, profile.BMax);
      this.SetAxisLimitValue(this.numericUpDown_18, profile.CMin);
      this.SetAxisLimitValue(this.numericUpDown_17, profile.CMax);
      string ignoredMessage;
      this.TryValidateAxisLimits(out ignoredMessage);
      this.machineLimitsStatusLabel.Text = "Machine profile: loaded and active";
      this.machineLimitsStatusLabel.ForeColor = Color.DarkGreen;
    }
    catch (Exception ex)
    {
      this.machineLimitsStatusLabel.Text = "Machine profile: load failed";
      this.machineLimitsStatusLabel.ForeColor = Color.DarkRed;
      buString5.MessageBoxWarning("Machine limits could not be loaded: " + ex.Message);
    }
  }

  private string GetMachineProfileFilePath()
  {
    string settingsDirectory = AppPath.Settings;
    if (string.IsNullOrWhiteSpace(settingsDirectory))
      settingsDirectory = Path.Combine(Application.StartupPath, "Settings");
    return FiveAxisSafetyProfileStore.GetDefaultFilePath(settingsDirectory);
  }

  private NumericUpDown[] GetAxisLimitControls()
  {
    return new NumericUpDown[]
    {
      this.numericUpDown_13, this.numericUpDown_14,
      this.numericUpDown_15, this.numericUpDown_16,
      this.numericUpDown_12, this.numericUpDown_11,
      this.numericUpDown_19, this.numericUpDown_20,
      this.numericUpDown_21, this.numericUpDown_22,
      this.numericUpDown_18, this.numericUpDown_17
    };
  }

  private bool IsAxisLimitControl(System.Windows.Forms.Control control)
  {
    NumericUpDown[] controls = this.GetAxisLimitControls();
    for (int index = 0; index < controls.Length; ++index)
    {
      if (object.ReferenceEquals(controls[index], control))
        return true;
    }
    return false;
  }

  private void AxisLimitValueChanged(object sender, EventArgs e)
  {
    NumericUpDown numericControl = sender as NumericUpDown;
    if (numericControl != null)
      this.invalidAxisLimitControls.Remove(numericControl);
    string ignoredMessage;
    this.TryValidateAxisLimits(out ignoredMessage);
  }

  private bool TryValidateAxisLimits(out string message)
  {
    List<string> errors = new List<string>();
    this.ValidateAxisPair("X", this.numericUpDown_13, this.numericUpDown_14, true, errors);
    this.ValidateAxisPair("Y", this.numericUpDown_15, this.numericUpDown_16, true, errors);
    this.ValidateAxisPair("Z", this.numericUpDown_12, this.numericUpDown_11, true, errors);
    this.ValidateAxisPair("A", this.numericUpDown_19, this.numericUpDown_20, this.checkBox_6.Checked, errors);
    this.ValidateAxisPair("B", this.numericUpDown_21, this.numericUpDown_22, this.checkBox_5.Checked, errors);
    this.ValidateAxisPair("C", this.numericUpDown_18, this.numericUpDown_17, this.checkBox_4.Checked, errors);

    if (this.invalidAxisLimitControls.Count > 0)
      errors.Add("Highlighted axis limits were invalid or outside the supported numeric range when loaded.");

    message = string.Join(Environment.NewLine, errors.ToArray());
    return errors.Count == 0;
  }

  private void ValidateAxisPair(
    string axis,
    NumericUpDown minimumControl,
    NumericUpDown maximumControl,
    bool axisEnabled,
    List<string> errors)
  {
    bool valid = minimumControl.Value < maximumControl.Value ||
                 (!axisEnabled && minimumControl.Value == maximumControl.Value);
    if (!valid)
      errors.Add(axis + " axis minimum limit must be smaller than its maximum limit.");

    bool loadedValueInvalid = this.invalidAxisLimitControls.Contains(minimumControl) ||
                              this.invalidAxisLimitControls.Contains(maximumControl);
    Color color = valid && !loadedValueInvalid ? SystemColors.Window : Color.MistyRose;
    minimumControl.BackColor = color;
    maximumControl.BackColor = color;
  }


	public void DrawTool()
	{
		List<Mesh> refMeshes = new List<Mesh>();
		viewportLayout.Entities.Clear();
		if (Tool.Geometry.FromFileEnable)
		{
			FileInfo fileInfo = new FileInfo(Tool.Geometry.FromFileFileName);
			if (fileInfo.Exists)
			{
				ReadSTL readSTL = new ReadSTL(fileInfo.FullName);
				readSTL.DoWork();
				readSTL.OpenTo(viewportLayout);
				if (viewportLayout.Entities.Count > 0)
				{
					for (int i = 0; i <= viewportLayout.Entities.Count - 1; i++)
					{
						if (viewportLayout.Entities[i] is Mesh)
						{
							viewportLayout.Entities[i].ColorMethod = colorMethodType.byEntity;
							if (viewportLayout.Entities[i].Color == Color.Black)
							{
								viewportLayout.Entities[i].Color = Color.DarkGray;
							}
							viewportLayout.Entities[i].Rotate(buConversion5.DegreeToRadian(Tool.Geometry.FromFileAngle), new Vector3D(0.0, 0.0, 1.0));
						}
					}
					viewportLayout.Entities.Regen();
					viewportLayout.ActiveViewport.ViewCubeIcon.Visible = false;
					viewportLayout.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
					viewportLayout.SetView(viewType.Top, fit: true, animate: false);
					viewportLayout.ZoomOut(2);
					viewportLayout.Invalidate();
				}
			}
		}
		else
		{
			clsInit.appMW.CreateTool(Tool, ToolCut: true, Tool.Geometry.DrawLength, Tool.Geometry.DrawArbor, Tool.Geometry.DrawHolder, ref refMeshes);
		}
		if (refMeshes.Count <= 0)
		{
			return;
		}
		for (int j = 0; j <= refMeshes.Count - 1; j++)
		{
			if (refMeshes[j].Vertices.Length != 0)
			{
				viewportLayout.Entities.Add(refMeshes[j]);
			}
		}
		List<Entity> dimEntities = new List<Entity>();
		clsInit.cVector5.ToolDimensionEntities(Tool, ref dimEntities);
		for (int k = 0; k <= dimEntities.Count - 1; k++)
		{
			viewportLayout.Entities.Add(dimEntities[k]);
		}
		viewportLayout.ActiveViewport.ViewCubeIcon.Visible = false;
		viewportLayout.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		viewportLayout.SetView(viewType.Front, fit: true, animate: false);
		viewportLayout.ZoomOut(2);
		viewportLayout.Invalidate();
	}

	public void TabPAgeVisibility()
	{
		tabControl_1.TabPages.Clear();
		if (Tool.Geometry.GeometryType == ToolType.Flat)
		{
			tabControl_1.TabPages.Add(list_0[0]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Sphere)
		{
			tabControl_1.TabPages.Add(list_0[1]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Saw)
		{
			tabControl_1.TabPages.Add(list_0[2]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Bullnose)
		{
			tabControl_1.TabPages.Add(list_0[3]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Slot)
		{
			tabControl_1.TabPages.Add(list_0[4]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Taper)
		{
			tabControl_1.TabPages.Add(list_0[5]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Lollipop)
		{
			tabControl_1.TabPages.Add(list_0[6]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Dove)
		{
			tabControl_1.TabPages.Add(list_0[7]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Chamfer)
		{
			tabControl_1.TabPages.Add(list_0[8]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Barrel)
		{
			tabControl_1.TabPages.Add(list_0[9]);
		}
		if (Tool.Geometry.GeometryType == ToolType.ConvexTip)
		{
			tabControl_1.TabPages.Add(list_0[10]);
		}
		if (Tool.Geometry.GeometryType == ToolType.FromFile)
		{
			tabControl_1.TabPages.Add(list_0[11]);
		}
		if (Tool.Geometry.GeometryType == ToolType.WateJet)
		{
			tabControl_1.TabPages.Add(list_0[12]);
		}
		if (Tool.Geometry.GeometryType == ToolType.Laser)
		{
			tabControl_1.TabPages.Add(list_0[13]);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if (control.Name == btn_ok.Name)
		{
			if (numericUpDown_28.Value > numericUpDown_27.Value)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[98]);
				return;
			}
			string axisLimitError;
			if (!TryValidateAxisLimits(out axisLimitError))
			{
				if (tabControl_0.TabPages.Contains(tabPage_2))
				{
					tabControl_0.SelectedTab = tabPage_2;
				}
				buString5.MessageBoxWarning(axisLimitError);
				return;
			}
			Class5.smethod_218(this);
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_14.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = AppPath.ToolHolder;
			saveFileDialog.Filter = "Tool Holder Files (*.butoolholder)|*.butoolholder";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				AppPath.ToolHolder = buFile5.GetPath(saveFileDialog.FileName);
				ToolBase5.SaveToolHolder(Tool, saveFileDialog.FileName);
			}
		}
		if (control.Name == button_13.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = AppPath.ToolHolder;
			openFileDialog.Filter = "Tool Holder Files (*.butoolholder)|*.butoolholder";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				AppPath.ToolHolder = buFile5.GetPath(openFileDialog.FileName);
				ToolBase5.OpenToolHolder(ref Tool, openFileDialog.FileName);
				DrawTool();
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			base.Visible = false;
		}
		if (control.Name == button_0.Name)
		{
			if (panel_0.Visible)
			{
				panel_0.Visible = false;
			}
			else
			{
				panel_0.Visible = true;
			}
		}
		if (control.Name == button_2.Name)
		{
			if (panel_20.Visible)
			{
				panel_20.Visible = false;
			}
			else
			{
				Class5.smethod_57(this);
				panel_20.Visible = true;
			}
		}
		if (control.Name == button_5.Name)
		{
			panel_20.Visible = false;
		}
		if (control.Name == button_6.Name)
		{
			Tool.Geometry.HolderPoints.Clear();
			for (int i = 0; i <= DGV_Holder.Rows.Count - 1; i++)
			{
				double result = 0.0;
				double result2 = 0.0;
				double.TryParse(DGV_Holder.Rows[i].Cells[0].Value.ToString(), out result);
				double.TryParse(DGV_Holder.Rows[i].Cells[1].Value.ToString(), out result2);
				Tool.Geometry.HolderPoints.Add(new Pnt3D(result, result2));
			}
			DrawTool();
			panel_20.Visible = false;
		}
		if (control.Name == button_4.Name)
		{
			if (!((DGV_Holder.Rows.Count - 1 == int_0) | (int_0 == -1)))
			{
				DGV_Holder.Rows.Insert(int_0, 0, 0);
			}
			else
			{
				DGV_Holder.Rows.Add(0, 0);
			}
		}
		if (control.Name == button_3.Name && ((int_0 >= 0) & (int_0 <= DGV_Holder.Rows.Count - 1)))
		{
			DGV_Holder.Rows.RemoveAt(int_0);
			int_0--;
		}
		if (control.Name == button_7.Name)
		{
			if (panel_21.Visible)
			{
				panel_21.Visible = false;
			}
			else
			{
				Class5.smethod_36(this);
				panel_21.Visible = true;
			}
		}
		if (control.Name == button_8.Name)
		{
			panel_21.Visible = false;
		}
		if (control.Name == button_9.Name)
		{
			Tool.Geometry.ArborPoints.Clear();
			for (int j = 0; j <= DGV_Arbor.Rows.Count - 1; j++)
			{
				double result3 = 0.0;
				double result4 = 0.0;
				double.TryParse(DGV_Arbor.Rows[j].Cells[0].Value.ToString(), out result3);
				double.TryParse(DGV_Arbor.Rows[j].Cells[1].Value.ToString(), out result4);
				Tool.Geometry.ArborPoints.Add(new Pnt3D(result3, result4));
			}
			DrawTool();
			panel_21.Visible = false;
		}
		if (control.Name == button_11.Name)
		{
			if (!((DGV_Arbor.Rows.Count - 1 == int_1) | (int_1 == -1)))
			{
				DGV_Arbor.Rows.Insert(int_1, 0, 0);
			}
			else
			{
				DGV_Arbor.Rows.Add(0, 0);
			}
		}
		if (control.Name == button_10.Name && ((int_1 >= 0) & (int_1 <= DGV_Arbor.Rows.Count - 1)))
		{
			DGV_Arbor.Rows.RemoveAt(int_1);
			int_1--;
		}
		if (control.Name == button_1.Name)
		{
			if (Tool.Geometry.GeometryType != ToolType.Flat)
			{
				if (Tool.Geometry.GeometryType != ToolType.Sphere)
				{
					if (Tool.Geometry.GeometryType != ToolType.Bullnose)
					{
						if (Tool.Geometry.GeometryType != ToolType.Lollipop)
						{
							if (Tool.Geometry.GeometryType != ToolType.Slot)
							{
								if (Tool.Geometry.GeometryType != ToolType.Taper)
								{
									if (Tool.Geometry.GeometryType != ToolType.Dove)
									{
										if (Tool.Geometry.GeometryType != ToolType.Chamfer)
										{
											if (Tool.Geometry.GeometryType != ToolType.Barrel)
											{
												if (Tool.Geometry.GeometryType != ToolType.ConvexTip)
												{
													if (Tool.Geometry.GeometryType != ToolType.Saw)
													{
														if (Tool.Geometry.GeometryType != ToolType.WateJet)
														{
															if (Tool.Geometry.GeometryType == ToolType.Laser)
															{
																checkBox_22.Checked = false;
																checkBox_21.Checked = false;
																numericUpDown_27.Value = 30m;
																numericUpDown_28.Value = 5m;
																numericUpDown_59.Value = 2m;
															}
														}
														else
														{
															numericUpDown_27.Value = 30m;
															numericUpDown_28.Value = 5m;
															numericUpDown_58.Value = 2m;
														}
													}
													else
													{
														numericUpDown_27.Value = 40m;
														numericUpDown_28.Value = 4m;
														numericUpDown_37.Value = 200m;
														numericUpDown_29.Value = 2m;
													}
												}
												else
												{
													numericUpDown_27.Value = 40m;
													numericUpDown_28.Value = 20m;
													numericUpDown_50.Value = 0m;
													numericUpDown_53.Value = 10m;
													numericUpDown_51.Value = 1m;
													numericUpDown_52.Value = 10m;
												}
											}
											else
											{
												numericUpDown_27.Value = 30m;
												numericUpDown_28.Value = 18m;
												numericUpDown_47.Value = 0.1m;
												numericUpDown_46.Value = 20m;
												numericUpDown_48.Value = 12m;
												numericUpDown_49.Value = 10m;
											}
										}
										else
										{
											numericUpDown_27.Value = 50m;
											numericUpDown_28.Value = 20m;
											numericUpDown_45.Value = 2m;
											numericUpDown_43.Value = 0m;
											numericUpDown_42.Value = 20m;
											numericUpDown_44.Value = 45m;
											radioButton_9.Checked = true;
										}
									}
									else
									{
										numericUpDown_27.Value = 40m;
										numericUpDown_28.Value = 6m;
										numericUpDown_30.Value = 8m;
										numericUpDown_41.Value = 20m;
										numericUpDown_39.Value = 2m;
										numericUpDown_40.Value = 45m;
										radioButton_6.Checked = true;
									}
								}
								else
								{
									numericUpDown_27.Value = 50m;
									numericUpDown_28.Value = 28m;
									numericUpDown_30.Value = 8m;
									numericUpDown_36.Value = 6m;
									numericUpDown_56.Value = 0m;
									radioButton_4.Checked = true;
								}
							}
							else
							{
								numericUpDown_27.Value = 40m;
								numericUpDown_28.Value = 5m;
								numericUpDown_35.Value = 80m;
								numericUpDown_54.Value = 2m;
								numericUpDown_55.Value = 2m;
								radioButton_12.Checked = true;
							}
						}
						else
						{
							numericUpDown_27.Value = 40m;
							numericUpDown_28.Value = 10m;
							numericUpDown_38.Value = 10m;
							numericUpDown_31.Value = 6m;
						}
					}
					else
					{
						numericUpDown_27.Value = 40m;
						numericUpDown_28.Value = 20m;
						numericUpDown_34.Value = 10m;
						numericUpDown_33.Value = 2m;
					}
				}
				else
				{
					numericUpDown_27.Value = 40m;
					numericUpDown_28.Value = 20m;
					numericUpDown_32.Value = 10m;
				}
			}
			else
			{
				numericUpDown_27.Value = 40m;
				numericUpDown_28.Value = 20m;
				numericUpDown_26.Value = 10m;
			}
			Class5.smethod_218(this);
			DrawTool();
		}
		if (control.Name == button_12.Name)
		{
			OpenFileDialog openFileDialog2 = new OpenFileDialog();
			openFileDialog2.InitialDirectory = pathTool;
			openFileDialog2.Multiselect = false;
			openFileDialog2.Filter = "Tool Geometry Stl File (*.stl)|*.stl";
			openFileDialog2.FilterIndex = 1;
			if (openFileDialog2.ShowDialog() == DialogResult.OK)
			{
				FileInfo fileInfo = new FileInfo(openFileDialog2.FileName);
				pathTool = fileInfo.DirectoryName;
				label_101.Text = openFileDialog2.FileName;
				Tool.Geometry.FromFileFileName = openFileDialog2.FileName;
				Class5.smethod_218(this);
				DrawTool();
			}
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			string axisLimitError;
			if (!IsAxisLimitControl(control) || TryValidateAxisLimits(out axisLimitError))
			{
				Class5.smethod_218(this);
				DrawTool();
			}
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(tabControl_0.SelectedTab.Controls, result, e.Shift);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				if (sender.GetType() == typeof(TextBox))
				{
					TextBox textBox = new TextBox();
					textBox = (TextBox)sender;
					buControlCommands.ShowKeyPad(this, textBox);
				}
				if (sender.GetType() == typeof(NumericUpDown))
				{
					NumericUpDown numericUpDown = new NumericUpDown();
					numericUpDown = (NumericUpDown)sender;
					buControlCommands.ShowKeyPad(this, numericUpDown);
				}
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == label_95.Name)
		{
			Color cColor = label_95.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
			{
				label_95.BackColor = cColor;
				Tool.Display.ToolCutSolid.SkinColor = cColor;
			}
		}
		if (control.Name == label_93.Name)
		{
			Color cColor2 = label_93.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				label_93.BackColor = cColor2;
				Tool.Display.ToolBodySolid.SkinColor = cColor2;
			}
		}
		if (control.Name == label_90.Name)
		{
			Color cColor3 = label_90.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor3) == DialogResult.OK)
			{
				label_90.BackColor = cColor3;
				Tool.Display.ArborSolid.SkinColor = cColor3;
			}
		}
		if (control.Name == label_92.Name)
		{
			Color cColor4 = label_92.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor4) == DialogResult.OK)
			{
				label_92.BackColor = cColor4;
				Tool.Display.HolderSolid.SkinColor = cColor4;
			}
		}
		if (control.Name == label_88.Name)
		{
			Color cColor5 = label_88.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor5) == DialogResult.OK)
			{
				label_88.BackColor = cColor5;
				Tool.Display.CamColor = cColor5;
			}
		}
		if (control.Name == label_86.Name)
		{
			Color cColor6 = label_86.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor6) == DialogResult.OK)
			{
				label_86.BackColor = cColor6;
				Tool.Display.UpperCamColor = cColor6;
			}
		}
		if (control.Name == label_84.Name)
		{
			Color cColor7 = label_84.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor7) == DialogResult.OK)
			{
				label_84.BackColor = cColor7;
				Tool.Display.PlungeColor = cColor7;
			}
		}
		if (control.Name == label_82.Name)
		{
			Color cColor8 = label_82.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor8) == DialogResult.OK)
			{
				label_82.BackColor = cColor8;
				Tool.Display.LeaveColor = cColor8;
			}
		}
		DrawTool();
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			Tool.Geometry.GeometryType = (ToolType)buGeneral.EnumValueFromInt(Tool.Geometry.GeometryType, comboBox_2.SelectedIndex);
			Tool.Purpose = (ToolPurpose)buGeneral.EnumValueFromInt(Tool.Purpose, comboBox_0.SelectedIndex);
			numericUpDown_61.Visible = false;
			label_105.Visible = false;
			if (Tool.Purpose == ToolPurpose.Tapping)
			{
				numericUpDown_61.Visible = true;
				label_105.Visible = true;
			}
			TabPAgeVisibility();
			method_0(button_1, null);
			DrawTool();
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if ((control.Name == radioButton_3.Name) | (control.Name == radioButton_2.Name) | (control.Name == radioButton_4.Name))
		{
			if (radioButton_4.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			}
			if (radioButton_3.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			}
			if (radioButton_2.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
			}
			Class5.smethod_178(this);
			DrawTool();
		}
		if ((control.Name == radioButton_11.Name) | (control.Name == radioButton_10.Name) | (control.Name == radioButton_12.Name))
		{
			if (radioButton_12.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			}
			if (radioButton_11.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			}
			if (radioButton_10.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
			}
			Class5.smethod_178(this);
			DrawTool();
		}
		if ((control.Name == radioButton_5.Name) | (control.Name == radioButton_6.Name))
		{
			if (radioButton_6.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			}
			if (radioButton_5.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			}
			Class5.smethod_178(this);
			DrawTool();
		}
		if ((control.Name == radioButton_8.Name) | (control.Name == radioButton_7.Name) | (control.Name == radioButton_9.Name))
		{
			if (radioButton_9.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			}
			if (radioButton_8.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			}
			if (radioButton_7.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
			}
			Class5.smethod_178(this);
			DrawTool();
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		Class5.smethod_218(this);
		DrawTool();
	}

	internal void method_8(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == checkBox_21.Name)
			{
				Tool.Geometry.DrawArbor = checkBox_21.Checked;
			}
			if (control.Name == checkBox_22.Name)
			{
				Tool.Geometry.DrawHolder = checkBox_22.Checked;
			}
			if (control.Name == checkBox_20.Name)
			{
				Tool.Geometry.DrawLength = checkBox_20.Checked;
			}
			DrawTool();
		}
	}

	internal void method_9(object sender, DataGridViewCellEventArgs e)
	{
		Control control = (Control)sender;
		if (control.Name == DGV_Holder.Name)
		{
			int_0 = e.RowIndex;
		}
		if (control.Name == DGV_Arbor.Name)
		{
			int_1 = e.RowIndex;
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
