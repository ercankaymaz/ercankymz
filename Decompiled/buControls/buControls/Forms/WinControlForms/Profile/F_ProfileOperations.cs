using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileOperations : Form
{
	public FormProperties Properties = new FormProperties();

	public ProfileOperation ItemOperation = null;

	public static ProfileOperationData OperationData = new ProfileOperationData();

	public ProfileItem Profile = new ProfileItem();

	public camParameters CamPar = new camParameters();

	public camParameters CamNotchPar = new camParameters();

	public ToolBase toolSelected = new ToolBase();

	public bool OperationUpdating = false;

	[CompilerGenerated]
	private ProfileOperationCommand profileOperationCommand_0;

	[CompilerGenerated]
	private ProfileOperationAddEventHandler profileOperationAddEventHandler_0;

	[CompilerGenerated]
	private ProfileOperationAddGetHeight profileOperationAddGetHeight_0;

	[CompilerGenerated]
	private OkCommandWithBoolEventHandler okCommandWithBoolEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	private int int_0 = 0;

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal Panel panel_0;

	public Button btn_getHCommon;

	public NumericUpDown spn_poszcommon;

	public NumericUpDown spn_posycommon;

	internal Label label_0;

	public NumericUpDown spn_posxcommon;

	internal Panel panel_1;

	internal Label label_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_2;

	internal Label label_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_3;

	internal Label label_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_2;

	internal Panel panel_4;

	internal Label label_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_3;

	internal CheckBox checkBox_0;

	internal Label label_9;

	internal Label label_10;

	internal CheckBox checkBox_1;

	public Button btn_cancel;

	public Button btn_ok;

	internal Panel panel_5;

	public Button btn_tool;

	public Button btn_planetop;

	internal Label label_11;

	internal Panel panel_6;

	internal Panel panel_7;

	public Button btn_depth;

	internal Panel panel_8;

	internal Label label_12;

	internal Label label_13;

	internal NumericUpDown numericUpDown_4;

	internal Panel panel_9;

	internal Label label_14;

	internal Label label_15;

	internal NumericUpDown numericUpDown_5;

	internal Panel panel_10;

	internal Label label_16;

	internal Label label_17;

	internal NumericUpDown numericUpDown_6;

	internal Panel panel_11;

	internal Label label_18;

	internal Label label_19;

	internal NumericUpDown numericUpDown_7;

	internal Panel panel_12;

	internal Label label_20;

	internal Label label_21;

	internal NumericUpDown numericUpDown_8;

	internal Panel panel_13;

	internal Label label_22;

	internal Label label_23;

	internal NumericUpDown numericUpDown_9;

	internal Panel panel_14;

	internal Label label_24;

	internal Label label_25;

	internal NumericUpDown numericUpDown_10;

	internal Panel panel_15;

	internal Label label_26;

	internal Label label_27;

	internal NumericUpDown numericUpDown_11;

	internal Panel panel_16;

	internal Label label_28;

	internal Label label_29;

	internal NumericUpDown numericUpDown_12;

	internal Panel panel_17;

	internal Label label_30;

	internal Label label_31;

	internal NumericUpDown numericUpDown_13;

	internal Panel panel_18;

	internal Label label_32;

	internal Label label_33;

	internal NumericUpDown numericUpDown_14;

	internal TabPage tabPage_5;

	internal TabPage tabPage_6;

	internal Panel panel_19;

	internal Label label_34;

	internal Label label_35;

	internal NumericUpDown numericUpDown_15;

	internal Panel panel_20;

	internal Label label_36;

	internal Label label_37;

	internal NumericUpDown numericUpDown_16;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal Label label_38;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal TabControl tabControl_1;

	internal TabPage tabPage_7;

	internal TabPage tabPage_8;

	internal Panel panel_21;

	internal Label label_39;

	internal Label label_40;

	internal NumericUpDown numericUpDown_17;

	internal Panel panel_22;

	internal Label label_41;

	internal Label label_42;

	internal NumericUpDown numericUpDown_18;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	internal RadioButton radioButton_5;

	internal Panel panel_23;

	internal Label label_43;

	internal Label label_44;

	internal NumericUpDown numericUpDown_19;

	internal Label label_45;

	internal Label label_46;

	internal TabPage tabPage_9;

	internal RadioButton radioButton_6;

	internal RadioButton radioButton_7;

	internal RadioButton radioButton_8;

	internal Panel panel_24;

	internal Label label_47;

	internal Label label_48;

	internal NumericUpDown numericUpDown_20;

	internal Panel panel_25;

	internal Label label_49;

	internal Label label_50;

	internal NumericUpDown numericUpDown_21;

	internal Panel panel_26;

	internal Label label_51;

	internal Label label_52;

	internal NumericUpDown numericUpDown_22;

	internal TabPage tabPage_10;

	internal Panel panel_27;

	internal TextBox textBox_0;

	internal Label label_53;

	internal Label label_54;

	internal RadioButton radioButton_9;

	internal RadioButton radioButton_10;

	internal Panel panel_28;

	internal Label label_55;

	internal Label label_56;

	internal NumericUpDown numericUpDown_23;

	internal Panel panel_29;

	internal Label label_57;

	internal Label label_58;

	internal NumericUpDown numericUpDown_24;

	internal Panel panel_30;

	internal Label label_59;

	internal Label label_60;

	internal NumericUpDown numericUpDown_25;

	public Button btn_planeleft;

	public Button btn_planeright;

	public Button btn_planebottom;

	public NumericUpDown spn_selectedposition;

	internal Label label_61;

	public Button btn_camsettings;

	internal CheckBox checkBox_2;

	internal Label label_62;

	internal Panel panel_31;

	internal Label label_63;

	internal Label label_64;

	internal NumericUpDown numericUpDown_26;

	internal CheckBox checkBox_3;

	internal Label label_65;

	public Button btn_planeegik;

	public Button btn_planeegiksettings;

	internal PictureBox pictureBox_3;

	internal Label label_66;

	public NumericUpDown spn_planeegillen;

	internal Label label_67;

	internal Label label_68;

	public Button btn_addheight;

	public ListBox lst_autofoundlayers;

	public Button btn_getplane;

	internal TabPage tabPage_11;

	internal Panel panel_32;

	internal Label label_69;

	internal Label label_70;

	internal NumericUpDown numericUpDown_27;

	internal Panel panel_33;

	internal Label label_71;

	internal Label label_72;

	internal NumericUpDown numericUpDown_28;

	internal Panel panel_34;

	internal Label label_73;

	internal Label label_74;

	internal NumericUpDown numericUpDown_29;

	public Button btn_removeheight;

	internal Label label_75;

	public NumericUpDown spn_depth;

	internal Label label_76;

	public TreeView tree_depth;

	internal ImageList imageList_2;

	public NumericUpDown spn_depthfound;

	public event ProfileOperationCommand ProfileCommand
	{
		[CompilerGenerated]
		add
		{
			ProfileOperationCommand profileOperationCommand = profileOperationCommand_0;
			ProfileOperationCommand profileOperationCommand2;
			do
			{
				profileOperationCommand2 = profileOperationCommand;
				ProfileOperationCommand value2 = (ProfileOperationCommand)Delegate.Combine(profileOperationCommand2, value);
				profileOperationCommand = Interlocked.CompareExchange(ref profileOperationCommand_0, value2, profileOperationCommand2);
			}
			while ((object)profileOperationCommand != profileOperationCommand2);
		}
		[CompilerGenerated]
		remove
		{
			ProfileOperationCommand profileOperationCommand = profileOperationCommand_0;
			ProfileOperationCommand profileOperationCommand2;
			do
			{
				profileOperationCommand2 = profileOperationCommand;
				ProfileOperationCommand value2 = (ProfileOperationCommand)Delegate.Remove(profileOperationCommand2, value);
				profileOperationCommand = Interlocked.CompareExchange(ref profileOperationCommand_0, value2, profileOperationCommand2);
			}
			while ((object)profileOperationCommand != profileOperationCommand2);
		}
	}

	public event ProfileOperationAddEventHandler ProfileDataChanged
	{
		[CompilerGenerated]
		add
		{
			ProfileOperationAddEventHandler profileOperationAddEventHandler = profileOperationAddEventHandler_0;
			ProfileOperationAddEventHandler profileOperationAddEventHandler2;
			do
			{
				profileOperationAddEventHandler2 = profileOperationAddEventHandler;
				ProfileOperationAddEventHandler value2 = (ProfileOperationAddEventHandler)Delegate.Combine(profileOperationAddEventHandler2, value);
				profileOperationAddEventHandler = Interlocked.CompareExchange(ref profileOperationAddEventHandler_0, value2, profileOperationAddEventHandler2);
			}
			while ((object)profileOperationAddEventHandler != profileOperationAddEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ProfileOperationAddEventHandler profileOperationAddEventHandler = profileOperationAddEventHandler_0;
			ProfileOperationAddEventHandler profileOperationAddEventHandler2;
			do
			{
				profileOperationAddEventHandler2 = profileOperationAddEventHandler;
				ProfileOperationAddEventHandler value2 = (ProfileOperationAddEventHandler)Delegate.Remove(profileOperationAddEventHandler2, value);
				profileOperationAddEventHandler = Interlocked.CompareExchange(ref profileOperationAddEventHandler_0, value2, profileOperationAddEventHandler2);
			}
			while ((object)profileOperationAddEventHandler != profileOperationAddEventHandler2);
		}
	}

	public event ProfileOperationAddGetHeight ProfileGetHeight
	{
		[CompilerGenerated]
		add
		{
			ProfileOperationAddGetHeight profileOperationAddGetHeight = profileOperationAddGetHeight_0;
			ProfileOperationAddGetHeight profileOperationAddGetHeight2;
			do
			{
				profileOperationAddGetHeight2 = profileOperationAddGetHeight;
				ProfileOperationAddGetHeight value2 = (ProfileOperationAddGetHeight)Delegate.Combine(profileOperationAddGetHeight2, value);
				profileOperationAddGetHeight = Interlocked.CompareExchange(ref profileOperationAddGetHeight_0, value2, profileOperationAddGetHeight2);
			}
			while ((object)profileOperationAddGetHeight != profileOperationAddGetHeight2);
		}
		[CompilerGenerated]
		remove
		{
			ProfileOperationAddGetHeight profileOperationAddGetHeight = profileOperationAddGetHeight_0;
			ProfileOperationAddGetHeight profileOperationAddGetHeight2;
			do
			{
				profileOperationAddGetHeight2 = profileOperationAddGetHeight;
				ProfileOperationAddGetHeight value2 = (ProfileOperationAddGetHeight)Delegate.Remove(profileOperationAddGetHeight2, value);
				profileOperationAddGetHeight = Interlocked.CompareExchange(ref profileOperationAddGetHeight_0, value2, profileOperationAddGetHeight2);
			}
			while ((object)profileOperationAddGetHeight != profileOperationAddGetHeight2);
		}
	}

	public event OkCommandWithBoolEventHandler ProfileOk
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithBoolEventHandler okCommandWithBoolEventHandler = okCommandWithBoolEventHandler_0;
			OkCommandWithBoolEventHandler okCommandWithBoolEventHandler2;
			do
			{
				okCommandWithBoolEventHandler2 = okCommandWithBoolEventHandler;
				OkCommandWithBoolEventHandler value2 = (OkCommandWithBoolEventHandler)Delegate.Combine(okCommandWithBoolEventHandler2, value);
				okCommandWithBoolEventHandler = Interlocked.CompareExchange(ref okCommandWithBoolEventHandler_0, value2, okCommandWithBoolEventHandler2);
			}
			while ((object)okCommandWithBoolEventHandler != okCommandWithBoolEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithBoolEventHandler okCommandWithBoolEventHandler = okCommandWithBoolEventHandler_0;
			OkCommandWithBoolEventHandler okCommandWithBoolEventHandler2;
			do
			{
				okCommandWithBoolEventHandler2 = okCommandWithBoolEventHandler;
				OkCommandWithBoolEventHandler value2 = (OkCommandWithBoolEventHandler)Delegate.Remove(okCommandWithBoolEventHandler2, value);
				okCommandWithBoolEventHandler = Interlocked.CompareExchange(ref okCommandWithBoolEventHandler_0, value2, okCommandWithBoolEventHandler2);
			}
			while ((object)okCommandWithBoolEventHandler != okCommandWithBoolEventHandler2);
		}
	}

	public event CancelCommandEventHandler ProfileCancel
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_ProfileOperations()
	{
		Class76.smethod_537(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		if (OperationData.OperationType == ProfileOperationTypes.Circle)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Hole)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Text)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.FromSelection)
		{
			tabControl_0.TabPages.RemoveAt(9);
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			tabControl_0.TabPages.RemoveAt(8);
			tabControl_0.TabPages.RemoveAt(7);
			tabControl_0.TabPages.RemoveAt(6);
			tabControl_0.TabPages.RemoveAt(5);
			tabControl_0.TabPages.RemoveAt(4);
			tabControl_0.TabPages.RemoveAt(3);
			tabControl_0.TabPages.RemoveAt(2);
			tabControl_0.TabPages.RemoveAt(1);
			tabControl_0.TabPages.RemoveAt(0);
		}
		if (toolSelected.Purpose == ToolPurpose.Saw)
		{
			CamNotchPar.Speeds.Feed = toolSelected.CamData.FeedSpeed;
			CamNotchPar.Speeds.Finish = toolSelected.CamData.FinishSpeed;
			CamNotchPar.Speeds.Plunge = toolSelected.CamData.PlungeSpeed;
			CamNotchPar.Speeds.AreaClearance = toolSelected.CamData.AreaClearanceSpeed;
			CamNotchPar.Distances.Safe = toolSelected.CamData.SafeDistance;
		}
		else
		{
			CamPar.Speeds.Feed = toolSelected.CamData.FeedSpeed;
			CamPar.Speeds.Finish = toolSelected.CamData.FinishSpeed;
			CamPar.Speeds.Plunge = toolSelected.CamData.PlungeSpeed;
			CamPar.Speeds.AreaClearance = toolSelected.CamData.AreaClearanceSpeed;
			CamPar.Distances.Safe = toolSelected.CamData.SafeDistance;
		}
		checkBox_1.Checked = CamPar.Operations.AreaClearanceEnable;
		checkBox_0.Checked = CamPar.Operations.FinishEnable;
		checkBox_2.Checked = CamPar.Steps.Enable;
		checkBox_3.Checked = CamPar.Operations.MakeCenterOffset;
		if (CamPar.Operations.Direction == ClockDirectionType.CW)
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
		if (CamPar.Operations.Direction == ClockDirectionType.CCW)
		{
			radioButton_1.Checked = false;
			radioButton_0.Checked = true;
		}
		label_0.Enabled = true;
		label_46.Enabled = true;
		label_45.Enabled = true;
		spn_posxcommon.Enabled = true;
		spn_posycommon.Enabled = true;
		spn_poszcommon.Enabled = true;
		btn_planebottom.BackColor = Color.LightGray;
		btn_planetop.BackColor = Color.LightGray;
		btn_planeright.BackColor = Color.LightGray;
		btn_planeleft.BackColor = Color.LightGray;
		if (OperationData.PlaneSelectedName == planeNames.Top)
		{
			btn_planetop.BackColor = Color.Gold;
			label_45.Enabled = false;
			spn_poszcommon.Enabled = false;
		}
		if (OperationData.PlaneSelectedName == planeNames.Bottom)
		{
			btn_planebottom.BackColor = Color.Gold;
			label_45.Enabled = false;
			spn_poszcommon.Enabled = false;
		}
		if (OperationData.PlaneSelectedName == planeNames.Left)
		{
			btn_planeleft.BackColor = Color.Gold;
			label_46.Enabled = false;
			spn_posycommon.Enabled = false;
		}
		if (OperationData.PlaneSelectedName == planeNames.Right)
		{
			btn_planeright.BackColor = Color.Gold;
			label_46.Enabled = false;
			spn_posycommon.Enabled = false;
		}
		if (Convert.ToInt32(OperationData.PlaneSelectedName) == -1)
		{
			OperationData.PlaneSelectedName = planeNames.Top;
			btn_planetop.BackColor = Color.Gold;
			label_45.Enabled = false;
			spn_poszcommon.Enabled = false;
		}
		spn_depth.Value = (decimal)OperationData.DepthTopPlaneValue;
		spn_planeegillen.Value = (decimal)OperationData.PlaneSlopeLength;
		spn_posxcommon.Value = (decimal)OperationData.Position.X;
		spn_posycommon.Value = (decimal)OperationData.Position.Y;
		spn_poszcommon.Value = (decimal)OperationData.Position.Z;
		numericUpDown_0.Value = (decimal)OperationData.CircleData.CircleDiameter;
		numericUpDown_2.Value = (decimal)OperationData.RectangleData.RectangleWidth;
		numericUpDown_1.Value = (decimal)OperationData.RectangleData.RectangleHeight;
		numericUpDown_3.Value = (decimal)OperationData.RectangleData.RectangleAngle;
		numericUpDown_27.Value = (decimal)OperationData.SlotData.SlotAngle;
		numericUpDown_28.Value = (decimal)OperationData.SlotData.SlotDiameter;
		numericUpDown_29.Value = (decimal)OperationData.SlotData.SlotWidth;
		numericUpDown_7.Value = (decimal)OperationData.RectangleRoundData.RoundRectangleWidth;
		numericUpDown_6.Value = (decimal)OperationData.RectangleRoundData.RoundRectangleHeight;
		numericUpDown_4.Value = (decimal)OperationData.RectangleRoundData.RoundRectangleRadius;
		numericUpDown_5.Value = (decimal)OperationData.RectangleRoundData.RoundRectangleAngle;
		numericUpDown_11.Value = (decimal)OperationData.BarelData.BarrelLength;
		numericUpDown_10.Value = (decimal)OperationData.BarelData.BarrelDiameter;
		numericUpDown_9.Value = (decimal)OperationData.BarelData.BarrelWidth;
		numericUpDown_8.Value = (decimal)OperationData.BarelData.BarrelAngle;
		numericUpDown_14.Value = (decimal)OperationData.EllipseData.EllipseWidth;
		numericUpDown_13.Value = (decimal)OperationData.EllipseData.EllipseHeight;
		numericUpDown_12.Value = (decimal)OperationData.EllipseData.EllipseAngle;
		numericUpDown_26.Value = (decimal)OperationData.HoleData.HoleDiameter;
		numericUpDown_15.Value = (decimal)OperationData.NotchData.NotchLDepth;
		numericUpDown_16.Value = (decimal)OperationData.NotchData.NotchLHeight;
		numericUpDown_17.Value = (decimal)OperationData.NotchData.NotchUDepth;
		numericUpDown_18.Value = (decimal)OperationData.NotchData.NotchUHeight;
		numericUpDown_19.Value = (decimal)OperationData.NotchData.NotchUStart;
		numericUpDown_22.Value = (decimal)OperationData.FreeDrawData.FreeDrawWidth;
		numericUpDown_21.Value = (decimal)OperationData.FreeDrawData.FreeDrawHeight;
		numericUpDown_20.Value = (decimal)OperationData.FreeDrawData.FreeDrawAngle;
		numericUpDown_25.Value = (decimal)OperationData.TextData.TextWidth;
		numericUpDown_24.Value = (decimal)OperationData.TextData.TextHeight;
		numericUpDown_23.Value = (decimal)OperationData.TextData.TextAngle;
		textBox_0.Text = OperationData.TextData.TextString;
		if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
		{
			radioButton_4.Checked = true;
			radioButton_5.Checked = false;
		}
		if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
		{
			radioButton_4.Checked = false;
			radioButton_5.Checked = true;
		}
		if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
		if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
		{
			radioButton_3.Checked = false;
			radioButton_2.Checked = true;
		}
		if (OperationData.NotchData.NotchType == ProfileNotchType.LType)
		{
			tabControl_1.SelectedIndex = 0;
		}
		if (OperationData.NotchData.NotchType == ProfileNotchType.UType)
		{
			tabControl_1.SelectedIndex = 1;
		}
		if (OperationData.FreeDrawData.FreeDrawScaleCenter == ProfileScaleCenterType.BottomLeft)
		{
			radioButton_8.Checked = true;
			radioButton_7.Checked = false;
			radioButton_6.Checked = false;
		}
		if (OperationData.FreeDrawData.FreeDrawScaleCenter == ProfileScaleCenterType.Center)
		{
			radioButton_8.Checked = false;
			radioButton_7.Checked = true;
			radioButton_6.Checked = false;
		}
		if (OperationData.FreeDrawData.FreeDrawScaleCenter == ProfileScaleCenterType.TopRight)
		{
			radioButton_8.Checked = false;
			radioButton_7.Checked = false;
			radioButton_6.Checked = true;
		}
		if (OperationData.TextData.TextScaleCenter == ProfileScaleCenterType.BottomLeft)
		{
			radioButton_10.Checked = true;
			radioButton_9.Checked = false;
		}
		if (OperationData.TextData.TextScaleCenter == ProfileScaleCenterType.Center)
		{
			radioButton_10.Checked = false;
			radioButton_9.Checked = true;
		}
		btn_tool.Text = toolSelected.Data.Name + " - Dia: " + toolSelected.Geometry.Diameter.ToString("f1") + " - Spindle: " + toolSelected.CamData.SpindleSpeed.ToString("f1");
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		if (profileOperationAddEventHandler_0 != null)
		{
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.CalculateH = !OperationUpdating;
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
		if (OperationUpdating)
		{
			lst_autofoundlayers.Items.Clear();
			tree_depth.Nodes.Clear();
			for (int i = 0; i <= OperationData.DepthValues.Count - 1; i++)
			{
				lst_autofoundlayers.Items.Add(OperationData.DepthValues[i].Position);
			}
			for (int j = 0; j <= OperationData.DepthSelectedValues.Count - 1; j++)
			{
				AddDepthHeightToTree(OperationData.DepthSelectedValues[j], j);
			}
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
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
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if (control.Name == spn_posxcommon.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.Position.X = (double)spn_posxcommon.Value;
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.CalculateH = !OperationUpdating;
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
		if (control.Name == spn_posycommon.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.Position.Y = (double)spn_posycommon.Value;
			ProfileOperationAddEventArg profileOperationAddEventArg2 = new ProfileOperationAddEventArg();
			profileOperationAddEventArg2.CalculateH = !OperationUpdating;
			profileOperationAddEventArg2.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg2.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg2);
		}
		if (control.Name == spn_poszcommon.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.Position.Z = (double)spn_poszcommon.Value;
			ProfileOperationAddEventArg profileOperationAddEventArg3 = new ProfileOperationAddEventArg();
			profileOperationAddEventArg3.CalculateH = !OperationUpdating;
			profileOperationAddEventArg3.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg3.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg3);
		}
		if (control.Name == spn_selectedposition.Name && profileOperationAddEventHandler_0 != null)
		{
			ProfileOperationAddEventArg profileOperationAddEventArg4 = new ProfileOperationAddEventArg();
			profileOperationAddEventArg4.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg4.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg4);
		}
		if (control.Name == spn_planeegillen.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.PlaneSlopeLength = (double)spn_planeegillen.Value;
			ProfileOperationAddEventArg profileOperationAddEventArg5 = new ProfileOperationAddEventArg();
			profileOperationAddEventArg5.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg5.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg5);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Circle && control.Name == numericUpDown_0.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.CircleData.CircleDiameter = (double)numericUpDown_0.Value;
			ProfileOperationAddEventArg profileOperationAddEventArg6 = new ProfileOperationAddEventArg();
			profileOperationAddEventArg6.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg6.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg6);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Rectangle)
		{
			if (control.Name == numericUpDown_3.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleData.RectangleAngle = (double)numericUpDown_3.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg7 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg7.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg7.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg7);
			}
			if (control.Name == numericUpDown_1.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleData.RectangleHeight = (double)numericUpDown_1.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg8 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg8.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg8.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg8);
			}
			if (control.Name == numericUpDown_2.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleData.RectangleWidth = (double)numericUpDown_2.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg9 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg9.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg9.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg9);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
		{
			if (control.Name == numericUpDown_5.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleRoundData.RoundRectangleAngle = (double)numericUpDown_5.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg10 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg10.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg10.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg10);
			}
			if (control.Name == numericUpDown_6.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleRoundData.RoundRectangleHeight = (double)numericUpDown_6.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg11 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg11.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg11.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg11);
			}
			if (control.Name == numericUpDown_7.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleRoundData.RoundRectangleWidth = (double)numericUpDown_7.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg12 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg12.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg12.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg12);
			}
			if (control.Name == numericUpDown_4.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.RectangleRoundData.RoundRectangleRadius = (double)numericUpDown_4.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg13 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg13.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg13.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg13);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.Slot)
		{
			if (control.Name == numericUpDown_27.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.SlotData.SlotAngle = (double)numericUpDown_27.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg14 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg14.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg14.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg14);
			}
			if (control.Name == numericUpDown_28.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.SlotData.SlotDiameter = (double)numericUpDown_28.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg15 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg15.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg15.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg15);
			}
			if (control.Name == numericUpDown_29.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.SlotData.SlotWidth = (double)numericUpDown_29.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg16 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg16.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg16.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg16);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.Barrel)
		{
			if (control.Name == numericUpDown_8.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.BarelData.BarrelAngle = (double)numericUpDown_8.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg17 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg17.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg17.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg17);
			}
			if (control.Name == numericUpDown_10.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.BarelData.BarrelDiameter = (double)numericUpDown_10.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg18 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg18.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg18.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg18);
			}
			if (control.Name == numericUpDown_11.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.BarelData.BarrelLength = (double)numericUpDown_11.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg19 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg19.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg19.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg19);
			}
			if (control.Name == numericUpDown_9.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.BarelData.BarrelWidth = (double)numericUpDown_9.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg20 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg20.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg20.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg20);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.Ellipse)
		{
			if (control.Name == numericUpDown_12.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.EllipseData.EllipseAngle = (double)numericUpDown_12.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg21 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg21.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg21.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg21);
			}
			if (control.Name == numericUpDown_13.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.EllipseData.EllipseHeight = (double)numericUpDown_13.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg22 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg22.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg22.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg22);
			}
			if (control.Name == numericUpDown_14.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.EllipseData.EllipseWidth = (double)numericUpDown_14.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg23 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg23.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg23.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg23);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.Hole && control.Name == numericUpDown_26.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.HoleData.HoleDiameter = (double)numericUpDown_26.Value;
			ProfileOperationAddEventArg profileOperationAddEventArg24 = new ProfileOperationAddEventArg();
			profileOperationAddEventArg24.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg24.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventHandler_0(profileOperationAddEventArg24);
		}
		if (OperationData.OperationType == ProfileOperationTypes.Notch)
		{
			if (control.Name == numericUpDown_15.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.NotchData.NotchLDepth = (double)numericUpDown_15.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg25 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg25.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg25.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg25);
			}
			if (control.Name == numericUpDown_16.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.NotchData.NotchLHeight = (double)numericUpDown_16.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg26 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg26.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg26.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg26);
			}
			if (control.Name == numericUpDown_17.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.NotchData.NotchUDepth = (double)numericUpDown_17.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg27 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg27.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg27.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg27);
			}
			if (control.Name == numericUpDown_18.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.NotchData.NotchUHeight = (double)numericUpDown_18.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg28 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg28.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg28.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg28);
			}
			if (control.Name == numericUpDown_19.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.NotchData.NotchUStart = (double)numericUpDown_19.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg29 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg29.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg29.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg29);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.FreeDraw)
		{
			if (control.Name == numericUpDown_22.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.FreeDrawData.FreeDrawWidth = (double)numericUpDown_22.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg30 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg30.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg30.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg30);
			}
			if (control.Name == numericUpDown_21.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.FreeDrawData.FreeDrawHeight = (double)numericUpDown_21.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg31 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg31.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg31.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg31);
			}
			if (control.Name == numericUpDown_20.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.FreeDrawData.FreeDrawAngle = (double)numericUpDown_20.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg32 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg32.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg32.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg32);
			}
		}
		if (OperationData.OperationType == ProfileOperationTypes.Text)
		{
			if (control.Name == numericUpDown_25.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.TextData.TextWidth = (double)numericUpDown_25.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg33 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg33.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg33.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg33);
			}
			if (control.Name == numericUpDown_24.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.TextData.TextHeight = (double)numericUpDown_24.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg34 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg34.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg34.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg34);
			}
			if (control.Name == numericUpDown_23.Name && profileOperationAddEventHandler_0 != null)
			{
				OperationData.TextData.TextAngle = (double)numericUpDown_23.Value;
				ProfileOperationAddEventArg profileOperationAddEventArg35 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg35.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg35.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventHandler_0(profileOperationAddEventArg35);
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_368(this);
			Properties.Result = DialogResult.OK;
			if (okCommandWithBoolEventHandler_0 != null)
			{
				okCommandWithBoolEventHandler_0(Data: true);
			}
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (!(control.Name == btn_camsettings.Name) || !Properties.Inited)
		{
			return;
		}
		if (!Properties.ReadOnly)
		{
			if (OperationData.OperationType == ProfileOperationTypes.Notch)
			{
				F_NotchCamSettings f_NotchCamSettings = new F_NotchCamSettings();
				f_NotchCamSettings.Properties = new FormProperties(FormCloseModeType.Dispose, AutoScaleMode.None, FormStartPosition.CenterParent, topmost: true, 0, 0);
				f_NotchCamSettings.CamPar = new camParameters(CamNotchPar);
				f_NotchCamSettings.OperationData = new ProfileOperationData(OperationData);
				f_NotchCamSettings.Owner = this;
				f_NotchCamSettings.Init();
				f_NotchCamSettings.ShowDialog();
				if (f_NotchCamSettings.Properties.Result == DialogResult.OK)
				{
					CamNotchPar = new camParameters(f_NotchCamSettings.CamPar);
					OperationData = new ProfileOperationData(f_NotchCamSettings.OperationData);
					f_NotchCamSettings.Owner.Focus();
					f_NotchCamSettings.Owner.Focus();
					if (base.Owner != null)
					{
						base.Owner.Focus();
					}
				}
				return;
			}
			F_CamSettings f_CamSettings = new F_CamSettings();
			f_CamSettings.Properties = new FormProperties(FormCloseModeType.Dispose, AutoScaleMode.None, FormStartPosition.CenterParent, topmost: true, 0, 0);
			f_CamSettings.CamPar = new camParameters(CamPar);
			f_CamSettings.OperationData = new ProfileOperationData(OperationData);
			f_CamSettings.Owner = this;
			f_CamSettings.Init();
			f_CamSettings.ShowDialog();
			if (f_CamSettings.Properties.Result == DialogResult.OK)
			{
				CamPar = new camParameters(f_CamSettings.CamPar);
				OperationData = new ProfileOperationData(f_CamSettings.OperationData);
				f_CamSettings.Owner.Focus();
				if (base.Owner != null)
				{
					base.Owner.Focus();
				}
			}
		}
		else
		{
			Dispose();
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		btn_planebottom.BackColor = Color.LightGray;
		btn_planetop.BackColor = Color.LightGray;
		btn_planeright.BackColor = Color.LightGray;
		btn_planeleft.BackColor = Color.LightGray;
		btn_planeegik.BackColor = Color.LightGray;
		label_0.Enabled = true;
		label_46.Enabled = true;
		label_45.Enabled = true;
		spn_posxcommon.Enabled = true;
		spn_posycommon.Enabled = true;
		spn_poszcommon.Enabled = true;
		Class76.smethod_368(this);
		if ((control.Name == btn_planetop.Name) & (OperationData.PlaneSelectedName != planeNames.Top))
		{
			lst_autofoundlayers.Items.Clear();
			tree_depth.Nodes.Clear();
			OperationData.PlaneSelectedName = planeNames.Top;
			btn_planetop.BackColor = Color.Gold;
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
				profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg.CalculateH = !OperationUpdating;
				profileOperationAddEventHandler_0(profileOperationAddEventArg);
			}
			label_45.Enabled = false;
			spn_poszcommon.Enabled = false;
		}
		if ((control.Name == btn_planebottom.Name) & (OperationData.PlaneSelectedName != planeNames.Bottom))
		{
			lst_autofoundlayers.Items.Clear();
			tree_depth.Nodes.Clear();
			OperationData.PlaneSelectedName = planeNames.Bottom;
			btn_planebottom.BackColor = Color.Gold;
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg2 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg2.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg2.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg2.CalculateH = !OperationUpdating;
				profileOperationAddEventHandler_0(profileOperationAddEventArg2);
			}
			label_45.Enabled = false;
			spn_poszcommon.Enabled = false;
		}
		if ((control.Name == btn_planeright.Name) & (OperationData.PlaneSelectedName != planeNames.Right))
		{
			lst_autofoundlayers.Items.Clear();
			tree_depth.Nodes.Clear();
			OperationData.PlaneSelectedName = planeNames.Right;
			btn_planeright.BackColor = Color.Gold;
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg3 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg3.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg3.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg3.CalculateH = !OperationUpdating;
				profileOperationAddEventHandler_0(profileOperationAddEventArg3);
			}
			label_46.Enabled = false;
			spn_posycommon.Enabled = false;
		}
		if ((control.Name == btn_planeleft.Name) & (OperationData.PlaneSelectedName != planeNames.Left))
		{
			lst_autofoundlayers.Items.Clear();
			tree_depth.Nodes.Clear();
			OperationData.PlaneSelectedName = planeNames.Left;
			btn_planeleft.BackColor = Color.Gold;
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg4 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg4.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg4.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg4.CalculateH = !OperationUpdating;
				profileOperationAddEventHandler_0(profileOperationAddEventArg4);
			}
			label_46.Enabled = false;
			spn_posycommon.Enabled = false;
		}
		if ((control.Name == btn_planeegik.Name) & (OperationData.PlaneSelectedName != planeNames.Free))
		{
			lst_autofoundlayers.Items.Clear();
			tree_depth.Nodes.Clear();
			OperationData.PlaneSelectedName = planeNames.Free;
			OperationData.PlaneSelected.PlaneType = planeType.YZ;
			btn_planeegik.BackColor = Color.Gold;
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg5 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg5.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg5.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg5.CalculateH = !OperationUpdating;
				profileOperationAddEventHandler_0(profileOperationAddEventArg5);
			}
			label_45.Enabled = false;
			spn_poszcommon.Enabled = false;
		}
		if (control.Name == btn_getplane.Name && profileOperationCommand_0 != null)
		{
			profileOperationCommand_0("getplane");
		}
		if (!(control.Name == btn_planeegiksettings.Name))
		{
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_getHCommon.Name && profileOperationAddGetHeight_0 != null)
		{
			profileOperationAddGetHeight_0(JustCalculate: false, OperationData.PlaneSelectedName, ref OperationData.DepthAllPositions, ref OperationData.DepthValues);
		}
		if (control.Name == btn_addheight.Name)
		{
			DepthPosition depthPosition = new DepthPosition();
			depthPosition.Position = (double)spn_selectedposition.Value;
			depthPosition.Depth = (double)spn_depth.Value;
			AddDepthHeightToTree(depthPosition, OperationData.DepthSelectedValues.Count);
			OperationData.DepthSelectedValues.Add(depthPosition);
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
				profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg.CalculateH = false;
				profileOperationAddEventArg.AddToSelectedHeightList = true;
				profileOperationAddEventHandler_0(profileOperationAddEventArg);
			}
		}
		if (control.Name == btn_removeheight.Name)
		{
			TreeViewNodeSettings treeViewNodeSettings = new TreeViewNodeSettings();
			treeViewNodeSettings = (TreeViewNodeSettings)tree_depth.SelectedNode;
			if (treeViewNodeSettings.ClassIndex >= 0)
			{
				tree_depth.Nodes.RemoveAt(treeViewNodeSettings.ClassIndex);
			}
			if (profileOperationAddEventHandler_0 != null)
			{
				ProfileOperationAddEventArg profileOperationAddEventArg2 = new ProfileOperationAddEventArg();
				profileOperationAddEventArg2.OperationData = new ProfileOperationData(OperationData);
				profileOperationAddEventArg2.OperationData.OperationType = OperationData.OperationType;
				profileOperationAddEventArg2.CalculateH = false;
				profileOperationAddEventArg2.AddToSelectedHeightList = true;
				profileOperationAddEventHandler_0(profileOperationAddEventArg2);
			}
		}
	}

	public void AddDepthHeightToTree(DepthPosition DH, int Index)
	{
		TreeViewNodeSettings treeViewNodeSettings = new TreeViewNodeSettings();
		treeViewNodeSettings.Text = DH.Position.ToString();
		treeViewNodeSettings.Tag = DH.Position + ";" + DH.Depth + ";" + DH.StepEnable + ";" + DH.StepDistance;
		treeViewNodeSettings.ImageIndex = -1;
		treeViewNodeSettings.SelectedImageIndex = -1;
		treeViewNodeSettings.ClassIndex = Index;
		treeViewNodeSettings.ClassSubIndex = -1;
		TreeViewNodeSettings treeViewNodeSettings2 = new TreeViewNodeSettings();
		treeViewNodeSettings2.Text = "D = " + DH.Depth;
		treeViewNodeSettings2.Tag = DH.Position + ";" + DH.Depth + ";" + DH.StepEnable + ";" + DH.StepDistance;
		treeViewNodeSettings2.ImageIndex = -1;
		treeViewNodeSettings2.SelectedImageIndex = -1;
		treeViewNodeSettings2.ClassIndex = Index;
		treeViewNodeSettings2.ClassSubIndex = -1;
		treeViewNodeSettings.Nodes.Add(treeViewNodeSettings2);
		treeViewNodeSettings2 = new TreeViewNodeSettings();
		treeViewNodeSettings2.Text = "Step = " + DH.StepEnable;
		if (DH.StepEnable)
		{
			treeViewNodeSettings2.Text = treeViewNodeSettings2.Text + " - L = " + DH.StepDistance;
		}
		treeViewNodeSettings2.Tag = DH.Position + ";" + DH.Depth + ";" + DH.StepEnable + ";" + DH.StepDistance;
		treeViewNodeSettings2.ImageIndex = -1;
		treeViewNodeSettings2.SelectedImageIndex = -1;
		treeViewNodeSettings2.ClassIndex = Index;
		treeViewNodeSettings2.ClassSubIndex = -1;
		treeViewNodeSettings.Nodes.Add(treeViewNodeSettings2);
		tree_depth.Nodes.Add(treeViewNodeSettings);
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (tabControl_1.SelectedIndex == 0)
		{
			OperationData.NotchData.NotchType = ProfileNotchType.LType;
		}
		if (tabControl_1.SelectedIndex == 1)
		{
			OperationData.NotchData.NotchType = ProfileNotchType.UType;
		}
		if (profileOperationAddEventHandler_0 != null)
		{
			Class76.smethod_368(this);
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if ((profileOperationAddEventHandler_0 != null) & Properties.Inited)
		{
			Class76.smethod_368(this);
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		if ((profileOperationAddEventHandler_0 != null) & Properties.Inited)
		{
			Class76.smethod_368(this);
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		if ((profileOperationAddEventHandler_0 != null) & Properties.Inited)
		{
			Class76.smethod_368(this);
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
	}

	internal void method_11(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited && control.Name == textBox_0.Name && e.KeyCode == Keys.Return && profileOperationAddEventHandler_0 != null)
		{
			OperationData.TextData.TextString = textBox_0.Text;
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
	}

	internal void method_12(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited && control.Name == textBox_0.Name && profileOperationAddEventHandler_0 != null)
		{
			OperationData.TextData.TextString = textBox_0.Text;
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
		}
	}

	internal void method_13(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == lst_autofoundlayers.Name && ((lst_autofoundlayers.SelectedIndex >= 0) & (lst_autofoundlayers.SelectedIndex <= lst_autofoundlayers.Items.Count - 1)))
		{
			decimal value = Convert.ToDecimal(lst_autofoundlayers.Items[lst_autofoundlayers.SelectedIndex]);
			spn_selectedposition.Value = value;
		}
	}

	internal void method_14(object sender, TreeViewEventArgs e)
	{
		if (tree_depth.SelectedNode == null)
		{
			return;
		}
		string text = tree_depth.SelectedNode.Tag.ToString();
		string[] array = text.Split(';');
		if (array != null)
		{
			int_0 = ((TreeViewNodeSettings)tree_depth.SelectedNode).ClassIndex;
			if (array.Length >= 4)
			{
				double.Parse(array[0]);
				double num = double.Parse(array[1]);
				bool.Parse(array[2]);
				double.Parse(array[3]);
				spn_depthfound.Value = (decimal)num;
			}
		}
	}

	internal void method_15(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return && profileOperationAddEventHandler_0 != null)
		{
			ProfileOperationAddEventArg profileOperationAddEventArg = new ProfileOperationAddEventArg();
			profileOperationAddEventArg.OperationData = new ProfileOperationData(OperationData);
			profileOperationAddEventArg.OperationData.OperationType = OperationData.OperationType;
			profileOperationAddEventArg.CalculateH = false;
			profileOperationAddEventArg.OperationData.DepthSelectedValues[0].Depth = (double)spn_depthfound.Value;
			OperationData.DepthSelectedValues[0].Depth = (double)spn_depthfound.Value;
			profileOperationAddEventHandler_0(profileOperationAddEventArg);
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
