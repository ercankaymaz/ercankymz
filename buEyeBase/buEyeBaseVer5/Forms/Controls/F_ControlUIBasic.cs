// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIBasic
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Events;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Materials;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIBasic : Form
{
  internal Label \u0004;
  internal TextBox \u0002;
  internal Button \u000E;
  internal NumericUpDown \u0002;
  internal NumericUpDown \u0003;
  public DataGridView grid_files;
  internal Panel \u0003;
  internal CheckBox \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Button \u000F;
  public static byte f003294;
  public Color SpinBaseColor;

  [CompilerGenerated]
  [SpecialName]
  public void remove_ParameterChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_RectangleShape) this).\u0002;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_RectangleShape) this).\u0002, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_SlotShape) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_SlotShape) this).\u0001, comparand + value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataCancel(CancelCommandEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CancelCommandEventHandler commandEventHandler = ((F_SlotShape) this).\u0001;
    CancelCommandEventHandler comparand;
    do
    {
      comparand = commandEventHandler;
      // ISSUE: reference to a compiler-generated field
      commandEventHandler = Interlocked.CompareExchange<CancelCommandEventHandler>(ref ((F_SlotShape) this).\u0001, comparand - value, comparand);
    }
    while (commandEventHandler != comparand);
  }

  public void Init()
  {
    ((F_RectangleShape) this).PropertiesForm.Inited = false;
    ((F_SlotShape) this).\u0001.Text = ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockName;
    ((F_SlotShape) this).spn_blockheightendoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightEndOffset;
    ((F_SlotShape) this).spn_blockheightstartoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightStartOffset;
    ((F_SlotShape) this).spn_blockwidthendoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthEndOffset;
    ((F_SlotShape) this).spn_blockwidthstartoffset.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthStartOffset;
    ((F_SlotShape) this).spn_blocktotalwidth.Value = (Decimal) ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockWidth;
    ((F_SlotShape) this).spn_blocktotalheight.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).BlockHeight;
    ((F_SlotShape) this).spn_patternwidth.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidth;
    ((F_SlotShape) this).spn_patternheight.Value = (Decimal) ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeight;
    ((F_LineShape) this).spn_patternspacewidth.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).PatternDistancesWidth;
    ((F_LineShape) this).spn_patternspacehight.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).PatternDistancesHeight;
    ((F_LineShape) this).spn_cutvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).CuttingFeed;
    ((F_LineShape) this).spn_leadinvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).EntryFeed;
    ((F_LineShape) this).spn_leadoutvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).LeaveFeed;
    ((F_LineShape) this).spn_connectionvel.Value = (Decimal) ((DrillMove) DrillCalcItem.varFoamSettings).ConnectionFeed;
    ((F_VShapePocket) this).\u0002.Checked = ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternMirrorX;
    ((F_VShapePocket) this).\u0001.Checked = ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternMirrorY;
    ((F_SlotShape) this).\u0004.BackColor = Color.Silver;
    ((F_SlotShape) this).\u0003.BackColor = Color.Silver;
    if (((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames == FoamPlaneType.XZ)
      ((F_SlotShape) this).\u0004.BackColor = Color.Gold;
    if (((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames == FoamPlaneType.YZ)
      ((F_SlotShape) this).\u0003.BackColor = Color.Gold;
    ((F_RectangleShape) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Apply()
  {
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightEndOffset = (double) ((F_SlotShape) this).spn_blockheightendoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightStartOffset = (double) ((F_SlotShape) this).spn_blockheightstartoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthEndOffset = (double) ((F_SlotShape) this).spn_blockwidthendoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthStartOffset = (double) ((F_SlotShape) this).spn_blockwidthstartoffset.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockWidth = (double) ((F_SlotShape) this).spn_blocktotalwidth.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).BlockHeight = (double) ((F_SlotShape) this).spn_blocktotalheight.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidth = (double) ((F_SlotShape) this).spn_patternwidth.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeight = (double) ((F_SlotShape) this).spn_patternheight.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockName = ((F_SlotShape) this).\u0001.Text;
    ((DrillMove) DrillCalcItem.varFoamSettings).PatternDistancesWidth = (double) ((F_LineShape) this).spn_patternspacewidth.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).PatternDistancesHeight = (double) ((F_LineShape) this).spn_patternspacehight.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).CuttingFeed = (double) ((F_LineShape) this).spn_cutvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).EntryFeed = (double) ((F_LineShape) this).spn_leadinvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).LeaveFeed = (double) ((F_LineShape) this).spn_leadoutvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).ConnectionFeed = (double) ((F_LineShape) this).spn_connectionvel.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternMirrorX = ((F_VShapePocket) this).\u0002.Checked;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternMirrorY = ((F_VShapePocket) this).\u0001.Checked;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_SlotShape) this).\u0002.Name)
    {
      ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_SlotShape) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_SlotShape) this).\u0001();
      }
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_SlotShape) this).\u0001.Name)
    {
      ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.OK;
      // ISSUE: reference to a compiler-generated field
      if (((F_RectangleShape) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Finished = true;
        ((DrillCNCSettings) Data2).PatternSpaceHeight = (double) ((F_LineShape) this).spn_patternspacehight.Value;
        ((DrillCNCSettings) Data2).PatternSpaceWidth = (double) ((F_LineShape) this).spn_patternspacewidth.Value;
        // ISSUE: reference to a compiler-generated field
        ((F_RectangleShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_SlotShape) this).\u0003.Name)
    {
      ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames = FoamPlaneType.YZ;
      ((F_SlotShape) this).\u0004.BackColor = Color.Silver;
      ((F_SlotShape) this).\u0003.BackColor = Color.Gold;
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      if (((F_RectangleShape) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).PatternSpaceHeight = (double) ((F_LineShape) this).spn_patternspacehight.Value;
        ((DrillCNCSettings) Data2).PatternSpaceWidth = (double) ((F_LineShape) this).spn_patternspacewidth.Value;
        ((DrillCNCSettings) Data2).Command = "PlaneYZ";
        // ISSUE: reference to a compiler-generated field
        ((F_RectangleShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
    }
    if (control2.Name == ((F_SlotShape) this).\u0004.Name)
    {
      ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames = FoamPlaneType.XZ;
      ((F_SlotShape) this).\u0004.BackColor = Color.Gold;
      ((F_SlotShape) this).\u0003.BackColor = Color.Silver;
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      if (((F_RectangleShape) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).PatternSpaceHeight = (double) ((F_LineShape) this).spn_patternspacehight.Value;
        ((DrillCNCSettings) Data2).PatternSpaceWidth = (double) ((F_LineShape) this).spn_patternspacewidth.Value;
        ((DrillCNCSettings) Data2).Command = "PlaneXZ";
        // ISSUE: reference to a compiler-generated field
        ((F_RectangleShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
    }
    if (!(control2.Name == ((F_LineShape) this).\u0005.Name))
      return;
    F_Material3D fMaterial3D = (F_Material3D) new F_MarbleJobList();
    CreateModelProperties Properties = (CreateModelProperties) new ShapeEdit();
    ((MaterialBase5) Properties).CoordinateSystemIconVisible = false;
    ((MaterialBase5) Properties).ViewCubeIconVisible = false;
    ((MaterialBase5) Properties).OrigineCaptionVisible = false;
    ((MaterialBase5) Properties).ToolBorVisible = false;
    ((F_MarbleJobOPListV2) fMaterial3D).viewportLayout = ((DrawingFinisedEvent) buCall.\u0001).CreateModelControl("", Properties);
    fMaterial3D.TopMost = true;
    ((F_MarbleStartLine) fMaterial3D).pnl_model.Controls.Add((Control) ((F_MarbleJobOPListV2) fMaterial3D).viewportLayout);
    ((F_MarbleJobOPListV2) fMaterial3D).viewportLayout.Entities.Clear();
    ((F_MarbleJobOPListV2) fMaterial3D).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ((F_MarbleJobOPListV2) fMaterial3D).Material = (MaterialBase5) new ShapeLeadInOut();
    ((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size = new SizeObject(((F_RectangleShape) this).FoamSize);
    ((F_MarbleJobList) fMaterial3D).Init((MaterialBase5) null);
    fMaterial3D.StartPosition = FormStartPosition.CenterParent;
    int num = (int) fMaterial3D.ShowDialog((IWin32Window) this);
    // ISSUE: reference to a compiler-generated field
    if (((F_MarbleJobOPListV2) fMaterial3D).PropertiesForm.Result != DialogResult.OK || ((F_RectangleShape) this).\u0002 == null)
      return;
    ((F_RectangleShape) this).FoamSize = new SizeObject(((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size);
    // ISSUE: reference to a compiler-generated field
    ((F_RectangleShape) this).\u0002((object) "FoamSize", (object) ((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_RectangleShape) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_RectangleShape) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_RectangleShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_RectangleShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_RectangleShape) this).PropertiesForm.Inited)
      return;
    if (control.Name == ((F_SlotShape) this).spn_blockvercount.Name)
      ;
    ((F_SlotShape) this).ValueChanging = true;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_RectangleShape) this).\u0001 != null)
    {
      FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
      ((DrillCNCSettings) Data2).PatternSpaceHeight = (double) ((F_LineShape) this).spn_patternspacehight.Value;
      ((DrillCNCSettings) Data2).PatternSpaceWidth = (double) ((F_LineShape) this).spn_patternspacewidth.Value;
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
    }
    ((F_SlotShape) this).ValueChanging = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_RectangleShape) this).PropertiesForm.Inited)
      return;
    ((F_SlotShape) this).ValueChanging = true;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_RectangleShape) this).\u0001 != null)
    {
      FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
      ((DrillCNCSettings) Data2).PatternSpaceHeight = (double) ((F_LineShape) this).spn_patternspacehight.Value;
      ((DrillCNCSettings) Data2).PatternSpaceWidth = (double) ((F_LineShape) this).spn_patternspacewidth.Value;
      // ISSUE: reference to a compiler-generated field
      ((F_RectangleShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
    }
    ((F_SlotShape) this).ValueChanging = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_RectangleShape) this).PropertiesForm.Inited)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_RectangleShape) this).\u0001 == null)
      return;
    FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
    // ISSUE: reference to a compiler-generated field
    ((F_RectangleShape) this).\u0001((object) DrillCalcItem.varFoamSettings, (object) Data2);
  }
}
