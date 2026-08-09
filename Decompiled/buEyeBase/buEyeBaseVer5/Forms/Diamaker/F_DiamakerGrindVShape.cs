using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using ns71;

namespace buEyeBaseVer5.Forms.Diamaker;

public class F_DiamakerGrindVShape : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public Design viewport = null;

	public ToolBase5 ToolGrinding = new ToolBase5();

	public ToolBase5 ToolNick = new ToolBase5();

	public bool isCircular = false;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal ImageList imageList_1;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal ImageList imageList_2;

	public TabControl tabControl1;

	public NumericUpDown spn_basethickness;

	public NumericUpDown spn_baseHeight;

	public NumericUpDown spn_targetangle;

	internal Label label_3;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal Label label_4;

	public NumericUpDown spn_angle_finishspindlespeed;

	internal Label label_5;

	internal Label label_6;

	public NumericUpDown spn_angle_roughdepth;

	public NumericUpDown spn_angle_roughspindlespeed;

	internal Label label_7;

	internal Label label_8;

	public NumericUpDown spn_angle_width;

	public NumericUpDown spn_angle_finishvel;

	internal Label label_9;

	internal Label label_10;

	public NumericUpDown spn_angle_finishdepth;

	public NumericUpDown spn_angle_roughtvel;

	internal Label label_11;

	internal Panel panel_1;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal Label label_12;

	public NumericUpDown spn_height_finishspindlespeed;

	internal Label label_13;

	internal Label label_14;

	public NumericUpDown spn_height_roughtdepth;

	public NumericUpDown spn_height_roughspindlespeed;

	internal Label label_15;

	internal Label label_16;

	public NumericUpDown spn_height_width;

	public NumericUpDown spn_height_finishvel;

	internal Label label_17;

	internal Label label_18;

	public NumericUpDown spn_height_finishdepth;

	public NumericUpDown spn_height_roughtvel;

	internal Label label_19;

	internal Panel panel_2;

	internal Label label_20;

	internal Button button_2;

	public NumericUpDown spn_targetHeight;

	internal Label label_21;

	internal Label label_22;

	public NumericUpDown spn_feeddistance;

	internal Panel panel_3;

	internal CheckBox checkBox_0;

	internal RadioButton radioButton_6;

	internal RadioButton radioButton_7;

	internal RadioButton radioButton_8;

	internal Label label_23;

	public NumericUpDown spn_nick_finishspindlespeed;

	internal Label label_24;

	internal Label label_25;

	public NumericUpDown spn_nick_depth;

	public NumericUpDown spn_nick_roughspindlespeed;

	internal Label label_26;

	internal Label label_27;

	public NumericUpDown spn_nick_width;

	public NumericUpDown spn_nick_finishvel;

	internal Label label_28;

	internal Label label_29;

	public NumericUpDown spn_nick_finishdepth;

	public NumericUpDown spn_nick_roughtvel;

	internal Label label_30;

	internal Panel panel_4;

	internal Label label_31;

	public NumericUpDown spn_feedcount;

	public NumericUpDown spn_angle_finishoperationcount;

	internal Label label_32;

	internal Label label_33;

	public NumericUpDown spn_grindinglength;

	public RadioButton radiolineartype;

	public RadioButton radio_circulartype;

	internal CheckBox checkBox_1;

	internal Label label_34;

	internal CheckBox checkBox_2;

	internal Label label_35;

	public NumericUpDown spn_toolpersentage;

	public F_DiamakerGrindVShape()
	{
		Class186.smethod_566(this);
		if (viewport == null)
		{
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, new EyeCreateProps
			{
				ShowToolBar = false,
				ShowViewCube = false,
				ShowCoordinateArrow = false
			}, ref viewport);
			viewport.Dock = DockStyle.Fill;
			if (panel_2.Controls.Count == 0)
			{
				panel_2.Controls.Add(viewport);
			}
		}
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		tabControl1.SizeMode = TabSizeMode.Fixed;
		tabControl1.Appearance = TabAppearance.FlatButtons;
		tabControl1.ItemSize = new Size(0, 1);
		tabControl1.Top = 5;
		spn_toolpersentage.Value = (decimal)buDiamakerCalc.varGrindingShape.ToolPersentage;
		spn_grindinglength.Value = (decimal)buDiamakerCalc.varGrindingShape.GrindingLength;
		spn_feedcount.Value = buDiamakerCalc.varGrindingShape.FeedCount;
		spn_feeddistance.Value = (decimal)buDiamakerCalc.varGrindingShape.FeedDistance;
		spn_baseHeight.Value = (decimal)buDiamakerCalc.varGrindingShape.BaseMaterialHeight;
		spn_targetHeight.Value = (decimal)buDiamakerCalc.varGrindingShape.TargetMaterialHeight;
		spn_basethickness.Value = (decimal)buDiamakerCalc.varGrindingShape.MaterialThickness;
		spn_targetangle.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeTargetAngle;
		spn_height_finishdepth.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightFinishDepth;
		spn_height_finishspindlespeed.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightFinishSpindleSpeed;
		spn_height_finishvel.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightFinishVel;
		spn_height_roughspindlespeed.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightRoughSpindleSpeed;
		spn_height_roughtdepth.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightRoughDepth;
		spn_height_roughtvel.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightRoughVel;
		spn_height_width.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeHeightWidth;
		spn_angle_finishdepth.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleFinishDepth;
		spn_angle_finishspindlespeed.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleFinishSpindleSpeed;
		spn_angle_finishvel.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleFinishVel;
		spn_angle_roughdepth.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleRoughDepth;
		spn_angle_roughspindlespeed.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleRoughSpindleSpeed;
		spn_angle_roughtvel.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleRoughVel;
		spn_angle_width.Value = (decimal)buDiamakerCalc.varGrindingShape.VShapeAngleWidth;
		spn_angle_finishoperationcount.Value = buDiamakerCalc.varGrindingShape.VShapeAngleFinishCount;
		checkBox_1.Checked = buDiamakerCalc.varGrindingShape.VShapeAngleEnable;
		spn_nick_finishdepth.Value = (decimal)buDiamakerCalc.varGrindingShape.NickFinishDepth;
		spn_nick_finishspindlespeed.Value = (decimal)buDiamakerCalc.varGrindingShape.NickFinishSpindleSpeed;
		spn_nick_finishvel.Value = (decimal)buDiamakerCalc.varGrindingShape.NickFinishVel;
		spn_nick_roughspindlespeed.Value = (decimal)buDiamakerCalc.varGrindingShape.NickRoughSpindleSpeed;
		spn_nick_depth.Value = (decimal)buDiamakerCalc.varGrindingShape.NickDepth;
		spn_nick_roughtvel.Value = (decimal)buDiamakerCalc.varGrindingShape.NickRoughVel;
		spn_nick_width.Value = (decimal)buDiamakerCalc.varGrindingShape.NickWidth;
		checkBox_0.Checked = buDiamakerCalc.varGrindingShape.NickEnable;
		checkBox_2.Checked = buDiamakerCalc.varGrindingShape.NickReverseDir;
		if (buDiamakerCalc.varGrindingShape.VShapeHeightToolNo != 1)
		{
			if (buDiamakerCalc.varGrindingShape.VShapeHeightToolNo != 2)
			{
				radioButton_3.Checked = true;
			}
			else
			{
				radioButton_4.Checked = true;
			}
		}
		else
		{
			radioButton_5.Checked = true;
		}
		if (buDiamakerCalc.varGrindingShape.VShapeAngleToolNo != 1)
		{
			if (buDiamakerCalc.varGrindingShape.VShapeAngleToolNo != 2)
			{
				radioButton_0.Checked = true;
			}
			else
			{
				radioButton_1.Checked = true;
			}
		}
		else
		{
			radioButton_2.Checked = true;
		}
		if (buDiamakerCalc.varGrindingShape.NickToolNo != 1)
		{
			if (buDiamakerCalc.varGrindingShape.NickToolNo != 2)
			{
				radioButton_6.Checked = true;
			}
			else
			{
				radioButton_7.Checked = true;
			}
		}
		else
		{
			radioButton_8.Checked = true;
		}
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Apply()
	{
		buDiamakerCalc.varGrindingShape.ToolPersentage = (double)spn_toolpersentage.Value;
		buDiamakerCalc.varGrindingShape.GrindingLength = (double)spn_grindinglength.Value;
		buDiamakerCalc.varGrindingShape.FeedCount = (int)spn_feedcount.Value;
		buDiamakerCalc.varGrindingShape.FeedDistance = (double)spn_feeddistance.Value;
		buDiamakerCalc.varGrindingShape.BaseMaterialHeight = (double)spn_baseHeight.Value;
		buDiamakerCalc.varGrindingShape.TargetMaterialHeight = (double)spn_targetHeight.Value;
		buDiamakerCalc.varGrindingShape.MaterialThickness = (double)spn_basethickness.Value;
		buDiamakerCalc.varGrindingShape.VShapeTargetAngle = (double)spn_targetangle.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightFinishDepth = (double)spn_height_finishdepth.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightFinishSpindleSpeed = (double)spn_height_finishspindlespeed.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightFinishVel = (double)spn_height_finishvel.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightRoughDepth = (double)spn_height_roughtdepth.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightRoughSpindleSpeed = (double)spn_height_roughspindlespeed.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightRoughVel = (double)spn_height_roughtvel.Value;
		buDiamakerCalc.varGrindingShape.VShapeHeightWidth = (double)spn_height_width.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleFinishDepth = (double)spn_angle_finishdepth.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleFinishSpindleSpeed = (double)spn_angle_finishspindlespeed.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleFinishVel = (double)spn_angle_finishvel.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleRoughDepth = (double)spn_angle_roughdepth.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleRoughSpindleSpeed = (double)spn_angle_roughspindlespeed.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleRoughVel = (double)spn_angle_roughtvel.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleWidth = (double)spn_angle_width.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleFinishCount = (int)spn_angle_finishoperationcount.Value;
		buDiamakerCalc.varGrindingShape.VShapeAngleEnable = checkBox_1.Checked;
		buDiamakerCalc.varGrindingShape.NickFinishDepth = (double)spn_nick_finishdepth.Value;
		buDiamakerCalc.varGrindingShape.NickFinishSpindleSpeed = (double)spn_nick_finishspindlespeed.Value;
		buDiamakerCalc.varGrindingShape.NickFinishVel = (double)spn_nick_finishvel.Value;
		buDiamakerCalc.varGrindingShape.NickRoughSpindleSpeed = (double)spn_nick_roughspindlespeed.Value;
		buDiamakerCalc.varGrindingShape.NickDepth = (double)spn_nick_depth.Value;
		buDiamakerCalc.varGrindingShape.NickRoughVel = (double)spn_nick_roughtvel.Value;
		buDiamakerCalc.varGrindingShape.NickWidth = (double)spn_nick_width.Value;
		buDiamakerCalc.varGrindingShape.NickEnable = checkBox_0.Checked;
		buDiamakerCalc.varGrindingShape.NickReverseDir = checkBox_2.Checked;
		if (!radioButton_5.Checked)
		{
			if (!radioButton_4.Checked)
			{
				buDiamakerCalc.varGrindingShape.VShapeHeightToolNo = 3;
			}
			else
			{
				buDiamakerCalc.varGrindingShape.VShapeHeightToolNo = 2;
			}
		}
		else
		{
			buDiamakerCalc.varGrindingShape.VShapeHeightToolNo = 1;
		}
		if (!radioButton_2.Checked)
		{
			if (!radioButton_1.Checked)
			{
				buDiamakerCalc.varGrindingShape.VShapeAngleToolNo = 3;
			}
			else
			{
				buDiamakerCalc.varGrindingShape.VShapeAngleToolNo = 2;
			}
		}
		else
		{
			buDiamakerCalc.varGrindingShape.VShapeAngleToolNo = 1;
		}
		if (!radioButton_8.Checked)
		{
			if (!radioButton_7.Checked)
			{
				buDiamakerCalc.varGrindingShape.NickToolNo = 3;
			}
			else
			{
				buDiamakerCalc.varGrindingShape.NickToolNo = 2;
			}
		}
		else
		{
			buDiamakerCalc.varGrindingShape.NickToolNo = 1;
		}
		if (!radiolineartype.Checked)
		{
			if (radio_circulartype.Checked)
			{
				isCircular = true;
			}
		}
		else
		{
			isCircular = false;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_2.Name)
		{
			Apply();
			Class186.smethod_437(this);
		}
		if (control.Name == button_1.Name)
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
		if (control.Name == button_0.Name)
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

	internal void method_2(object sender, FormClosingEventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		if (!PropertiesForm.Inited)
		{
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
