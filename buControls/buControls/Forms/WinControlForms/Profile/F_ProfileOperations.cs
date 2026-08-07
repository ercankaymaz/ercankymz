// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.F_ProfileOperations
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile;

public class F_ProfileOperations : Form
{
  public FormProperties Properties = new FormProperties();
  public ProfileOperation ItemOperation = (ProfileOperation) null;
  public static ProfileOperationData OperationData = new ProfileOperationData();
  public ProfileItem Profile = new ProfileItem();
  public camParameters CamPar = new camParameters();
  public camParameters CamNotchPar = new camParameters();
  public ToolBase toolSelected = new ToolBase();
  public bool OperationUpdating = false;
  private int int_0 = 0;
  internal IContainer icontainer_0 = (IContainer) null;
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

  public F_ProfileOperations() => Class39.smethod_537(this);

  public event ProfileOperationCommand ProfileCommand;

  public event ProfileOperationAddEventHandler ProfileDataChanged;

  public event ProfileOperationAddGetHeight ProfileGetHeight;

  public event OkCommandWithBoolEventHandler ProfileOk;

  public event CancelCommandEventHandler ProfileCancel;

  public void Init()
  {
    this.Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Circle)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Rectangle)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Barrel)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Ellipse)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Hole)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Notch)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Text)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.FromSelection)
    {
      this.tabControl_0.TabPages.RemoveAt(9);
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Slot)
    {
      this.tabControl_0.TabPages.RemoveAt(8);
      this.tabControl_0.TabPages.RemoveAt(7);
      this.tabControl_0.TabPages.RemoveAt(6);
      this.tabControl_0.TabPages.RemoveAt(5);
      this.tabControl_0.TabPages.RemoveAt(4);
      this.tabControl_0.TabPages.RemoveAt(3);
      this.tabControl_0.TabPages.RemoveAt(2);
      this.tabControl_0.TabPages.RemoveAt(1);
      this.tabControl_0.TabPages.RemoveAt(0);
    }
    if (this.toolSelected.Purpose != ToolPurpose.Saw)
    {
      this.CamPar.Speeds.Feed = this.toolSelected.CamData.FeedSpeed;
      this.CamPar.Speeds.Finish = this.toolSelected.CamData.FinishSpeed;
      this.CamPar.Speeds.Plunge = this.toolSelected.CamData.PlungeSpeed;
      this.CamPar.Speeds.AreaClearance = this.toolSelected.CamData.AreaClearanceSpeed;
      this.CamPar.Distances.Safe = this.toolSelected.CamData.SafeDistance;
    }
    else
    {
      this.CamNotchPar.Speeds.Feed = this.toolSelected.CamData.FeedSpeed;
      this.CamNotchPar.Speeds.Finish = this.toolSelected.CamData.FinishSpeed;
      this.CamNotchPar.Speeds.Plunge = this.toolSelected.CamData.PlungeSpeed;
      this.CamNotchPar.Speeds.AreaClearance = this.toolSelected.CamData.AreaClearanceSpeed;
      this.CamNotchPar.Distances.Safe = this.toolSelected.CamData.SafeDistance;
    }
    this.checkBox_1.Checked = this.CamPar.Operations.AreaClearanceEnable;
    this.checkBox_0.Checked = this.CamPar.Operations.FinishEnable;
    this.checkBox_2.Checked = this.CamPar.Steps.Enable;
    this.checkBox_3.Checked = this.CamPar.Operations.MakeCenterOffset;
    if (this.CamPar.Operations.Direction == ClockDirectionType.CW)
    {
      this.radioButton_1.Checked = true;
      this.radioButton_0.Checked = false;
    }
    if (this.CamPar.Operations.Direction == ClockDirectionType.CCW)
    {
      this.radioButton_1.Checked = false;
      this.radioButton_0.Checked = true;
    }
    this.label_0.Enabled = true;
    this.label_46.Enabled = true;
    this.label_45.Enabled = true;
    this.spn_posxcommon.Enabled = true;
    this.spn_posycommon.Enabled = true;
    this.spn_poszcommon.Enabled = true;
    this.btn_planebottom.BackColor = Color.LightGray;
    this.btn_planetop.BackColor = Color.LightGray;
    this.btn_planeright.BackColor = Color.LightGray;
    this.btn_planeleft.BackColor = Color.LightGray;
    if (F_ProfileOperations.OperationData.PlaneSelectedName == planeNames.Top)
    {
      this.btn_planetop.BackColor = Color.Gold;
      this.label_45.Enabled = false;
      this.spn_poszcommon.Enabled = false;
    }
    if (F_ProfileOperations.OperationData.PlaneSelectedName == planeNames.Bottom)
    {
      this.btn_planebottom.BackColor = Color.Gold;
      this.label_45.Enabled = false;
      this.spn_poszcommon.Enabled = false;
    }
    if (F_ProfileOperations.OperationData.PlaneSelectedName == planeNames.Left)
    {
      this.btn_planeleft.BackColor = Color.Gold;
      this.label_46.Enabled = false;
      this.spn_posycommon.Enabled = false;
    }
    if (F_ProfileOperations.OperationData.PlaneSelectedName == planeNames.Right)
    {
      this.btn_planeright.BackColor = Color.Gold;
      this.label_46.Enabled = false;
      this.spn_posycommon.Enabled = false;
    }
    if (Convert.ToInt32((object) F_ProfileOperations.OperationData.PlaneSelectedName) == -1)
    {
      F_ProfileOperations.OperationData.PlaneSelectedName = planeNames.Top;
      this.btn_planetop.BackColor = Color.Gold;
      this.label_45.Enabled = false;
      this.spn_poszcommon.Enabled = false;
    }
    this.spn_depth.Value = (Decimal) F_ProfileOperations.OperationData.DepthTopPlaneValue;
    this.spn_planeegillen.Value = (Decimal) F_ProfileOperations.OperationData.PlaneSlopeLength;
    this.spn_posxcommon.Value = (Decimal) F_ProfileOperations.OperationData.Position.X;
    this.spn_posycommon.Value = (Decimal) F_ProfileOperations.OperationData.Position.Y;
    this.spn_poszcommon.Value = (Decimal) F_ProfileOperations.OperationData.Position.Z;
    this.numericUpDown_0.Value = (Decimal) F_ProfileOperations.OperationData.CircleData.CircleDiameter;
    this.numericUpDown_2.Value = (Decimal) F_ProfileOperations.OperationData.RectangleData.RectangleWidth;
    this.numericUpDown_1.Value = (Decimal) F_ProfileOperations.OperationData.RectangleData.RectangleHeight;
    this.numericUpDown_3.Value = (Decimal) F_ProfileOperations.OperationData.RectangleData.RectangleAngle;
    this.numericUpDown_27.Value = (Decimal) F_ProfileOperations.OperationData.SlotData.SlotAngle;
    this.numericUpDown_28.Value = (Decimal) F_ProfileOperations.OperationData.SlotData.SlotDiameter;
    this.numericUpDown_29.Value = (Decimal) F_ProfileOperations.OperationData.SlotData.SlotWidth;
    this.numericUpDown_7.Value = (Decimal) F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleWidth;
    this.numericUpDown_6.Value = (Decimal) F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleHeight;
    this.numericUpDown_4.Value = (Decimal) F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleRadius;
    this.numericUpDown_5.Value = (Decimal) F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleAngle;
    this.numericUpDown_11.Value = (Decimal) F_ProfileOperations.OperationData.BarelData.BarrelLength;
    this.numericUpDown_10.Value = (Decimal) F_ProfileOperations.OperationData.BarelData.BarrelDiameter;
    this.numericUpDown_9.Value = (Decimal) F_ProfileOperations.OperationData.BarelData.BarrelWidth;
    this.numericUpDown_8.Value = (Decimal) F_ProfileOperations.OperationData.BarelData.BarrelAngle;
    this.numericUpDown_14.Value = (Decimal) F_ProfileOperations.OperationData.EllipseData.EllipseWidth;
    this.numericUpDown_13.Value = (Decimal) F_ProfileOperations.OperationData.EllipseData.EllipseHeight;
    this.numericUpDown_12.Value = (Decimal) F_ProfileOperations.OperationData.EllipseData.EllipseAngle;
    this.numericUpDown_26.Value = (Decimal) F_ProfileOperations.OperationData.HoleData.HoleDiameter;
    this.numericUpDown_15.Value = (Decimal) F_ProfileOperations.OperationData.NotchData.NotchLDepth;
    this.numericUpDown_16.Value = (Decimal) F_ProfileOperations.OperationData.NotchData.NotchLHeight;
    this.numericUpDown_17.Value = (Decimal) F_ProfileOperations.OperationData.NotchData.NotchUDepth;
    this.numericUpDown_18.Value = (Decimal) F_ProfileOperations.OperationData.NotchData.NotchUHeight;
    this.numericUpDown_19.Value = (Decimal) F_ProfileOperations.OperationData.NotchData.NotchUStart;
    this.numericUpDown_22.Value = (Decimal) F_ProfileOperations.OperationData.FreeDrawData.FreeDrawWidth;
    this.numericUpDown_21.Value = (Decimal) F_ProfileOperations.OperationData.FreeDrawData.FreeDrawHeight;
    this.numericUpDown_20.Value = (Decimal) F_ProfileOperations.OperationData.FreeDrawData.FreeDrawAngle;
    this.numericUpDown_25.Value = (Decimal) F_ProfileOperations.OperationData.TextData.TextWidth;
    this.numericUpDown_24.Value = (Decimal) F_ProfileOperations.OperationData.TextData.TextHeight;
    this.numericUpDown_23.Value = (Decimal) F_ProfileOperations.OperationData.TextData.TextAngle;
    this.textBox_0.Text = F_ProfileOperations.OperationData.TextData.TextString;
    if (F_ProfileOperations.OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
    {
      this.radioButton_4.Checked = true;
      this.radioButton_5.Checked = false;
    }
    if (F_ProfileOperations.OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
    {
      this.radioButton_4.Checked = false;
      this.radioButton_5.Checked = true;
    }
    if (F_ProfileOperations.OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
    {
      this.radioButton_3.Checked = true;
      this.radioButton_2.Checked = false;
    }
    if (F_ProfileOperations.OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
    {
      this.radioButton_3.Checked = false;
      this.radioButton_2.Checked = true;
    }
    if (F_ProfileOperations.OperationData.NotchData.NotchType == ProfileNotchType.LType)
      this.tabControl_1.SelectedIndex = 0;
    if (F_ProfileOperations.OperationData.NotchData.NotchType == ProfileNotchType.UType)
      this.tabControl_1.SelectedIndex = 1;
    if (F_ProfileOperations.OperationData.FreeDrawData.FreeDrawScaleCenter == ProfileScaleCenterType.BottomLeft)
    {
      this.radioButton_8.Checked = true;
      this.radioButton_7.Checked = false;
      this.radioButton_6.Checked = false;
    }
    if (F_ProfileOperations.OperationData.FreeDrawData.FreeDrawScaleCenter == ProfileScaleCenterType.Center)
    {
      this.radioButton_8.Checked = false;
      this.radioButton_7.Checked = true;
      this.radioButton_6.Checked = false;
    }
    if (F_ProfileOperations.OperationData.FreeDrawData.FreeDrawScaleCenter == ProfileScaleCenterType.TopRight)
    {
      this.radioButton_8.Checked = false;
      this.radioButton_7.Checked = false;
      this.radioButton_6.Checked = true;
    }
    if (F_ProfileOperations.OperationData.TextData.TextScaleCenter == ProfileScaleCenterType.BottomLeft)
    {
      this.radioButton_10.Checked = true;
      this.radioButton_9.Checked = false;
    }
    if (F_ProfileOperations.OperationData.TextData.TextScaleCenter == ProfileScaleCenterType.Center)
    {
      this.radioButton_10.Checked = false;
      this.radioButton_9.Checked = true;
    }
    this.btn_tool.Text = $"{this.toolSelected.Data.Name} - Dia: {this.toolSelected.Geometry.Diameter.ToString("f1")} - Spindle: {this.toolSelected.CamData.SpindleSpeed.ToString("f1")}";
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    // ISSUE: reference to a compiler-generated field
    if (this.profileOperationAddEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(new ProfileOperationAddEventArg()
      {
        CalculateH = !this.OperationUpdating,
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      });
    }
    if (!this.OperationUpdating)
      return;
    this.lst_autofoundlayers.Items.Clear();
    this.tree_depth.Nodes.Clear();
    for (int index = 0; index <= F_ProfileOperations.OperationData.DepthValues.Count - 1; ++index)
      this.lst_autofoundlayers.Items.Add((object) F_ProfileOperations.OperationData.DepthValues[index].Position);
    for (int index = 0; index <= F_ProfileOperations.OperationData.DepthSelectedValues.Count - 1; ++index)
      this.AddDepthHeightToTree(F_ProfileOperations.OperationData.DepthSelectedValues[index], index);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (this.cancelCommandEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelCommandEventHandler_0();
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad((Form) this, (Control) sender);
      }
      if (!(sender.GetType() == typeof (NumericUpDown)))
        return;
      NumericUpDown numericUpDown = new NumericUpDown();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.spn_posxcommon.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.Position.X = (double) this.spn_posxcommon.Value;
      ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
      {
        CalculateH = !this.OperationUpdating,
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e1);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.spn_posycommon.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.Position.Y = (double) this.spn_posycommon.Value;
      ProfileOperationAddEventArg e2 = new ProfileOperationAddEventArg()
      {
        CalculateH = !this.OperationUpdating,
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e2.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e2);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.spn_poszcommon.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.Position.Z = (double) this.spn_poszcommon.Value;
      ProfileOperationAddEventArg e3 = new ProfileOperationAddEventArg()
      {
        CalculateH = !this.OperationUpdating,
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e3.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e3);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.spn_selectedposition.Name && this.profileOperationAddEventHandler_0 != null)
    {
      ProfileOperationAddEventArg e4 = new ProfileOperationAddEventArg()
      {
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e4.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e4);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.spn_planeegillen.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.PlaneSlopeLength = (double) this.spn_planeegillen.Value;
      ProfileOperationAddEventArg e5 = new ProfileOperationAddEventArg()
      {
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e5.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e5);
    }
    // ISSUE: reference to a compiler-generated field
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Circle && control2.Name == this.numericUpDown_0.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.CircleData.CircleDiameter = (double) this.numericUpDown_0.Value;
      ProfileOperationAddEventArg e6 = new ProfileOperationAddEventArg()
      {
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e6.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e6);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Rectangle)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_3.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleData.RectangleAngle = (double) this.numericUpDown_3.Value;
        ProfileOperationAddEventArg e7 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e7.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e7);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_1.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleData.RectangleHeight = (double) this.numericUpDown_1.Value;
        ProfileOperationAddEventArg e8 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e8.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e8);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_2.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleData.RectangleWidth = (double) this.numericUpDown_2.Value;
        ProfileOperationAddEventArg e9 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e9.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e9);
      }
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.RoundRectangle)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_5.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleAngle = (double) this.numericUpDown_5.Value;
        ProfileOperationAddEventArg e10 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e10.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e10);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_6.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleHeight = (double) this.numericUpDown_6.Value;
        ProfileOperationAddEventArg e11 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e11.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e11);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_7.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleWidth = (double) this.numericUpDown_7.Value;
        ProfileOperationAddEventArg e12 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e12.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e12);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_4.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.RectangleRoundData.RoundRectangleRadius = (double) this.numericUpDown_4.Value;
        ProfileOperationAddEventArg e13 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e13.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e13);
      }
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Slot)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_27.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.SlotData.SlotAngle = (double) this.numericUpDown_27.Value;
        ProfileOperationAddEventArg e14 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e14.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e14);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_28.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.SlotData.SlotDiameter = (double) this.numericUpDown_28.Value;
        ProfileOperationAddEventArg e15 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e15.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e15);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_29.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.SlotData.SlotWidth = (double) this.numericUpDown_29.Value;
        ProfileOperationAddEventArg e16 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e16.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e16);
      }
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Barrel)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_8.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.BarelData.BarrelAngle = (double) this.numericUpDown_8.Value;
        ProfileOperationAddEventArg e17 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e17.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e17);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_10.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.BarelData.BarrelDiameter = (double) this.numericUpDown_10.Value;
        ProfileOperationAddEventArg e18 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e18.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e18);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_11.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.BarelData.BarrelLength = (double) this.numericUpDown_11.Value;
        ProfileOperationAddEventArg e19 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e19.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e19);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_9.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.BarelData.BarrelWidth = (double) this.numericUpDown_9.Value;
        ProfileOperationAddEventArg e20 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e20.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e20);
      }
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Ellipse)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_12.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.EllipseData.EllipseAngle = (double) this.numericUpDown_12.Value;
        ProfileOperationAddEventArg e21 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e21.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e21);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_13.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.EllipseData.EllipseHeight = (double) this.numericUpDown_13.Value;
        ProfileOperationAddEventArg e22 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e22.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e22);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_14.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.EllipseData.EllipseWidth = (double) this.numericUpDown_14.Value;
        ProfileOperationAddEventArg e23 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e23.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e23);
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Hole && control2.Name == this.numericUpDown_26.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.HoleData.HoleDiameter = (double) this.numericUpDown_26.Value;
      ProfileOperationAddEventArg e24 = new ProfileOperationAddEventArg()
      {
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e24.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e24);
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.Notch)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_15.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.NotchData.NotchLDepth = (double) this.numericUpDown_15.Value;
        ProfileOperationAddEventArg e25 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e25.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e25);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_16.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.NotchData.NotchLHeight = (double) this.numericUpDown_16.Value;
        ProfileOperationAddEventArg e26 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e26.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e26);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_17.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.NotchData.NotchUDepth = (double) this.numericUpDown_17.Value;
        ProfileOperationAddEventArg e27 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e27.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e27);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_18.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.NotchData.NotchUHeight = (double) this.numericUpDown_18.Value;
        ProfileOperationAddEventArg e28 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e28.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e28);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_19.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.NotchData.NotchUStart = (double) this.numericUpDown_19.Value;
        ProfileOperationAddEventArg e29 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e29.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e29);
      }
    }
    if (F_ProfileOperations.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
    {
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_22.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.FreeDrawData.FreeDrawWidth = (double) this.numericUpDown_22.Value;
        ProfileOperationAddEventArg e30 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e30.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e30);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_21.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.FreeDrawData.FreeDrawHeight = (double) this.numericUpDown_21.Value;
        ProfileOperationAddEventArg e31 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e31.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e31);
      }
      // ISSUE: reference to a compiler-generated field
      if (control2.Name == this.numericUpDown_20.Name && this.profileOperationAddEventHandler_0 != null)
      {
        F_ProfileOperations.OperationData.FreeDrawData.FreeDrawAngle = (double) this.numericUpDown_20.Value;
        ProfileOperationAddEventArg e32 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e32.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e32);
      }
    }
    if (F_ProfileOperations.OperationData.OperationType != ProfileOperationTypes.Text)
      return;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.numericUpDown_25.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.TextData.TextWidth = (double) this.numericUpDown_25.Value;
      ProfileOperationAddEventArg e33 = new ProfileOperationAddEventArg()
      {
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e33.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e33);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.numericUpDown_24.Name && this.profileOperationAddEventHandler_0 != null)
    {
      F_ProfileOperations.OperationData.TextData.TextHeight = (double) this.numericUpDown_24.Value;
      ProfileOperationAddEventArg e34 = new ProfileOperationAddEventArg()
      {
        OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
      };
      e34.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddEventHandler_0(e34);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == this.numericUpDown_23.Name) || this.profileOperationAddEventHandler_0 == null)
      return;
    F_ProfileOperations.OperationData.TextData.TextAngle = (double) this.numericUpDown_23.Value;
    ProfileOperationAddEventArg e35 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e35.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e35);
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_368(this);
      this.Properties.Result = DialogResult.OK;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithBoolEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithBoolEventHandler_0(true);
      }
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (this.cancelCommandEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.cancelCommandEventHandler_0();
      }
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_camsettings.Name) || !this.Properties.Inited)
      return;
    if (this.Properties.ReadOnly)
      this.Dispose();
    else if (F_ProfileOperations.OperationData.OperationType != ProfileOperationTypes.Notch)
    {
      F_CamSettings fCamSettings = new F_CamSettings();
      fCamSettings.Properties = new FormProperties(FormCloseModeType.Dispose, AutoScaleMode.None, FormStartPosition.CenterParent, true, 0, 0);
      fCamSettings.CamPar = new camParameters(this.CamPar);
      fCamSettings.OperationData = new ProfileOperationData(F_ProfileOperations.OperationData);
      fCamSettings.Owner = (Form) this;
      fCamSettings.Init();
      int num = (int) fCamSettings.ShowDialog();
      if (fCamSettings.Properties.Result != DialogResult.OK)
        return;
      this.CamPar = new camParameters(fCamSettings.CamPar);
      F_ProfileOperations.OperationData = new ProfileOperationData(fCamSettings.OperationData);
      fCamSettings.Owner.Focus();
      if (this.Owner == null)
        return;
      this.Owner.Focus();
    }
    else
    {
      F_NotchCamSettings notchCamSettings = new F_NotchCamSettings();
      notchCamSettings.Properties = new FormProperties(FormCloseModeType.Dispose, AutoScaleMode.None, FormStartPosition.CenterParent, true, 0, 0);
      notchCamSettings.CamPar = new camParameters(this.CamNotchPar);
      notchCamSettings.OperationData = new ProfileOperationData(F_ProfileOperations.OperationData);
      notchCamSettings.Owner = (Form) this;
      notchCamSettings.Init();
      int num = (int) notchCamSettings.ShowDialog();
      if (notchCamSettings.Properties.Result != DialogResult.OK)
        return;
      this.CamNotchPar = new camParameters(notchCamSettings.CamPar);
      F_ProfileOperations.OperationData = new ProfileOperationData(notchCamSettings.OperationData);
      notchCamSettings.Owner.Focus();
      notchCamSettings.Owner.Focus();
      if (this.Owner == null)
        return;
      this.Owner.Focus();
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.btn_planebottom.BackColor = Color.LightGray;
    this.btn_planetop.BackColor = Color.LightGray;
    this.btn_planeright.BackColor = Color.LightGray;
    this.btn_planeleft.BackColor = Color.LightGray;
    this.btn_planeegik.BackColor = Color.LightGray;
    this.label_0.Enabled = true;
    this.label_46.Enabled = true;
    this.label_45.Enabled = true;
    this.spn_posxcommon.Enabled = true;
    this.spn_posycommon.Enabled = true;
    this.spn_poszcommon.Enabled = true;
    Class39.smethod_368(this);
    if (control2.Name == this.btn_planetop.Name & F_ProfileOperations.OperationData.PlaneSelectedName != 0)
    {
      this.lst_autofoundlayers.Items.Clear();
      this.tree_depth.Nodes.Clear();
      F_ProfileOperations.OperationData.PlaneSelectedName = planeNames.Top;
      this.btn_planetop.BackColor = Color.Gold;
      // ISSUE: reference to a compiler-generated field
      if (this.profileOperationAddEventHandler_0 != null)
      {
        ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        e1.CalculateH = !this.OperationUpdating;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e1);
      }
      this.label_45.Enabled = false;
      this.spn_poszcommon.Enabled = false;
    }
    if (control2.Name == this.btn_planebottom.Name & F_ProfileOperations.OperationData.PlaneSelectedName != planeNames.Bottom)
    {
      this.lst_autofoundlayers.Items.Clear();
      this.tree_depth.Nodes.Clear();
      F_ProfileOperations.OperationData.PlaneSelectedName = planeNames.Bottom;
      this.btn_planebottom.BackColor = Color.Gold;
      // ISSUE: reference to a compiler-generated field
      if (this.profileOperationAddEventHandler_0 != null)
      {
        ProfileOperationAddEventArg e2 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e2.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        e2.CalculateH = !this.OperationUpdating;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e2);
      }
      this.label_45.Enabled = false;
      this.spn_poszcommon.Enabled = false;
    }
    if (control2.Name == this.btn_planeright.Name & F_ProfileOperations.OperationData.PlaneSelectedName != planeNames.Right)
    {
      this.lst_autofoundlayers.Items.Clear();
      this.tree_depth.Nodes.Clear();
      F_ProfileOperations.OperationData.PlaneSelectedName = planeNames.Right;
      this.btn_planeright.BackColor = Color.Gold;
      // ISSUE: reference to a compiler-generated field
      if (this.profileOperationAddEventHandler_0 != null)
      {
        ProfileOperationAddEventArg e3 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e3.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        e3.CalculateH = !this.OperationUpdating;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e3);
      }
      this.label_46.Enabled = false;
      this.spn_posycommon.Enabled = false;
    }
    if (control2.Name == this.btn_planeleft.Name & F_ProfileOperations.OperationData.PlaneSelectedName != planeNames.Left)
    {
      this.lst_autofoundlayers.Items.Clear();
      this.tree_depth.Nodes.Clear();
      F_ProfileOperations.OperationData.PlaneSelectedName = planeNames.Left;
      this.btn_planeleft.BackColor = Color.Gold;
      // ISSUE: reference to a compiler-generated field
      if (this.profileOperationAddEventHandler_0 != null)
      {
        ProfileOperationAddEventArg e4 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e4.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        e4.CalculateH = !this.OperationUpdating;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e4);
      }
      this.label_46.Enabled = false;
      this.spn_posycommon.Enabled = false;
    }
    if (control2.Name == this.btn_planeegik.Name & F_ProfileOperations.OperationData.PlaneSelectedName != planeNames.Free)
    {
      this.lst_autofoundlayers.Items.Clear();
      this.tree_depth.Nodes.Clear();
      F_ProfileOperations.OperationData.PlaneSelectedName = planeNames.Free;
      F_ProfileOperations.OperationData.PlaneSelected.PlaneType = planeType.YZ;
      this.btn_planeegik.BackColor = Color.Gold;
      // ISSUE: reference to a compiler-generated field
      if (this.profileOperationAddEventHandler_0 != null)
      {
        ProfileOperationAddEventArg e5 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e5.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        e5.CalculateH = !this.OperationUpdating;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e5);
      }
      this.label_45.Enabled = false;
      this.spn_poszcommon.Enabled = false;
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_getplane.Name && this.profileOperationCommand_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.profileOperationCommand_0("getplane");
    }
    if (control2.Name == this.btn_planeegiksettings.Name)
      ;
  }

  internal void method_5(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.btn_getHCommon.Name && this.profileOperationAddGetHeight_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.profileOperationAddGetHeight_0(false, F_ProfileOperations.OperationData.PlaneSelectedName, ref F_ProfileOperations.OperationData.DepthAllPositions, ref F_ProfileOperations.OperationData.DepthValues);
    }
    if (control2.Name == this.btn_addheight.Name)
    {
      DepthPosition DH = new DepthPosition();
      DH.Position = (double) this.spn_selectedposition.Value;
      DH.Depth = (double) this.spn_depth.Value;
      this.AddDepthHeightToTree(DH, F_ProfileOperations.OperationData.DepthSelectedValues.Count);
      F_ProfileOperations.OperationData.DepthSelectedValues.Add(DH);
      // ISSUE: reference to a compiler-generated field
      if (this.profileOperationAddEventHandler_0 != null)
      {
        ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
        {
          OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
        };
        e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
        e1.CalculateH = false;
        e1.AddToSelectedHeightList = true;
        // ISSUE: reference to a compiler-generated field
        this.profileOperationAddEventHandler_0(e1);
      }
    }
    if (!(control2.Name == this.btn_removeheight.Name))
      return;
    TreeViewNodeSettings viewNodeSettings = new TreeViewNodeSettings();
    TreeViewNodeSettings selectedNode = (TreeViewNodeSettings) this.tree_depth.SelectedNode;
    if (selectedNode.ClassIndex >= 0)
      this.tree_depth.Nodes.RemoveAt(selectedNode.ClassIndex);
    // ISSUE: reference to a compiler-generated field
    if (this.profileOperationAddEventHandler_0 == null)
      return;
    ProfileOperationAddEventArg e2 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e2.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e2.CalculateH = false;
    e2.AddToSelectedHeightList = true;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e2);
  }

  public void AddDepthHeightToTree(DepthPosition DH, int Index)
  {
    TreeViewNodeSettings node1 = new TreeViewNodeSettings();
    node1.Text = DH.Position.ToString();
    node1.Tag = (object) $"{DH.Position.ToString()};{DH.Depth.ToString()};{DH.StepEnable.ToString()};{DH.StepDistance.ToString()}";
    node1.ImageIndex = -1;
    node1.SelectedImageIndex = -1;
    node1.ClassIndex = Index;
    node1.ClassSubIndex = -1;
    TreeViewNodeSettings node2 = new TreeViewNodeSettings();
    node2.Text = "D = " + DH.Depth.ToString();
    node2.Tag = (object) $"{DH.Position.ToString()};{DH.Depth.ToString()};{DH.StepEnable.ToString()};{DH.StepDistance.ToString()}";
    node2.ImageIndex = -1;
    node2.SelectedImageIndex = -1;
    node2.ClassIndex = Index;
    node2.ClassSubIndex = -1;
    node1.Nodes.Add((TreeNode) node2);
    TreeViewNodeSettings node3 = new TreeViewNodeSettings();
    node3.Text = "Step = " + DH.StepEnable.ToString();
    if (DH.StepEnable)
      node3.Text = $"{node3.Text} - L = {DH.StepDistance.ToString()}";
    node3.Tag = (object) $"{DH.Position.ToString()};{DH.Depth.ToString()};{DH.StepEnable.ToString()};{DH.StepDistance.ToString()}";
    node3.ImageIndex = -1;
    node3.SelectedImageIndex = -1;
    node3.ClassIndex = Index;
    node3.ClassSubIndex = -1;
    node1.Nodes.Add((TreeNode) node3);
    this.tree_depth.Nodes.Add((TreeNode) node1);
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (this.tabControl_1.SelectedIndex == 0)
      F_ProfileOperations.OperationData.NotchData.NotchType = ProfileNotchType.LType;
    if (this.tabControl_1.SelectedIndex == 1)
      F_ProfileOperations.OperationData.NotchData.NotchType = ProfileNotchType.UType;
    // ISSUE: reference to a compiler-generated field
    if (this.profileOperationAddEventHandler_0 == null)
      return;
    Class39.smethod_368(this);
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  internal void method_7(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.profileOperationAddEventHandler_0 != null & this.Properties.Inited))
      return;
    Class39.smethod_368(this);
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  internal void method_8(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.profileOperationAddEventHandler_0 != null & this.Properties.Inited))
      return;
    Class39.smethod_368(this);
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  internal void method_9(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (!(this.profileOperationAddEventHandler_0 != null & this.Properties.Inited))
      return;
    Class39.smethod_368(this);
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  internal void method_10(object sender, EventArgs e)
  {
  }

  internal void method_11(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (!this.Properties.Inited || !(control2.Name == this.textBox_0.Name) || e.KeyCode != Keys.Return || this.profileOperationAddEventHandler_0 == null)
      return;
    F_ProfileOperations.OperationData.TextData.TextString = this.textBox_0.Text;
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  internal void method_12(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    // ISSUE: reference to a compiler-generated field
    if (!this.Properties.Inited || !(control2.Name == this.textBox_0.Name) || this.profileOperationAddEventHandler_0 == null)
      return;
    F_ProfileOperations.OperationData.TextData.TextString = this.textBox_0.Text;
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  internal void method_13(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == this.lst_autofoundlayers.Name) || !(this.lst_autofoundlayers.SelectedIndex >= 0 & this.lst_autofoundlayers.SelectedIndex <= this.lst_autofoundlayers.Items.Count - 1))
      return;
    this.spn_selectedposition.Value = Convert.ToDecimal(this.lst_autofoundlayers.Items[this.lst_autofoundlayers.SelectedIndex]);
  }

  internal void method_14(object sender, TreeViewEventArgs e)
  {
    if (this.tree_depth.SelectedNode == null)
      return;
    string[] strArray = this.tree_depth.SelectedNode.Tag.ToString().Split(';');
    if (strArray == null)
      return;
    this.int_0 = ((TreeViewNodeSettings) this.tree_depth.SelectedNode).ClassIndex;
    if (strArray.Length < 4)
      return;
    double.Parse(strArray[0]);
    double num = double.Parse(strArray[1]);
    bool.Parse(strArray[2]);
    double.Parse(strArray[3]);
    this.spn_depthfound.Value = (Decimal) num;
  }

  internal void method_15(object sender, KeyEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (e.KeyCode != Keys.Return || this.profileOperationAddEventHandler_0 == null)
      return;
    ProfileOperationAddEventArg e1 = new ProfileOperationAddEventArg()
    {
      OperationData = new ProfileOperationData(F_ProfileOperations.OperationData)
    };
    e1.OperationData.OperationType = F_ProfileOperations.OperationData.OperationType;
    e1.CalculateH = false;
    e1.OperationData.DepthSelectedValues[0].Depth = (double) this.spn_depthfound.Value;
    F_ProfileOperations.OperationData.DepthSelectedValues[0].Depth = (double) this.spn_depthfound.Value;
    // ISSUE: reference to a compiler-generated field
    this.profileOperationAddEventHandler_0(e1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
