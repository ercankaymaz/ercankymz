// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Customer.DincMak.F_LineShape
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Events;
using buEyeBaseVer5.Forms.Door;
using buEyeBaseVer5.Forms.Events;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Materials;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Customer.DincMak;

public class F_LineShape : Form
{
  internal Label \u0007;
  internal Panel \u0002;
  internal Label \u0008;
  internal Panel \u0003;
  internal Label \u000E;
  internal Panel \u0004;
  internal Button \u0005;
  public NumericUpDown spn_patternspacehight;
  public Label label18;
  internal Label \u000F;
  public Label label20;
  public NumericUpDown spn_patternspacewidth;
  internal Label \u0010;
  public Label label21;
  public Label label22;
  public NumericUpDown spn_totalpart;
  public Label label23;
  internal Panel \u0005;
  public NumericUpDown spn_connectionvel;
  public Label label25;
  public NumericUpDown spn_leadoutvel;
  public Label label28;
  public NumericUpDown spn_leadinvel;
  public Label label24;
  public Label label26;
  public NumericUpDown spn_cutvel;
  internal Label \u0011;
  internal Panel \u0006;

  public void Apply()
  {
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightEndOffset = (double) ((F_DoorMat) this).spn_blockheightendoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightStartOffset = (double) ((F_DoorMat) this).spn_blockheightstartoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthEndOffset = (double) ((F_DoorMat) this).spn_blockwidthendoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthStartOffset = (double) ((F_EventAll) this).spn_blockwidthstartoffset.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockWidth = (double) ((F_EventAll) this).spn_blocktotalwidth.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).BlockHeight = (double) ((F_EventAll) this).spn_blocktotalheight.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).SlicesHeight = (double) ((F_DoorMat) this).spn_waveheight.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockName = ((F_DoorMat) this).\u0001.Text;
    ((DrillMove) DrillCalcItem.varFoamSettings).CuttingFeed = (double) ((F_DoorMat) this).spn_cutvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).EntryFeed = (double) ((F_DoorMat) this).spn_leadinvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).LeaveFeed = (double) ((F_DoorMat) this).spn_leadoutvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).ConnectionFeed = (double) ((F_DoorMat) this).spn_connectionvel.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_EventAll) this).\u0002.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_EventAll) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_EventAll) this).\u0001();
      }
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_EventAll) this).\u0001.Name)
    {
      ((F_EventAll) this).PropertiesForm.Result = DialogResult.OK;
      // ISSUE: reference to a compiler-generated field
      if (((F_EventAll) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_EventAll) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_EventAll) this).\u0003.Name)
    {
      ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames = FoamPlaneType.YZ;
      ((F_EventAll) this).\u0004.BackColor = Color.Silver;
      ((F_EventAll) this).\u0003.BackColor = Color.Gold;
      ((F_EventAll) this).ValueChanging = true;
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      if (((F_EventAll) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Command = "PlaneYZ";
        // ISSUE: reference to a compiler-generated field
        ((F_EventAll) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
      ((F_EventAll) this).ValueChanging = false;
    }
    if (control2.Name == ((F_EventAll) this).\u0004.Name)
    {
      ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames = FoamPlaneType.XZ;
      ((F_EventAll) this).\u0004.BackColor = Color.Gold;
      ((F_EventAll) this).\u0003.BackColor = Color.Silver;
      ((F_EventAll) this).ValueChanging = true;
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      if (((F_EventAll) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Command = "PlaneXZ";
        // ISSUE: reference to a compiler-generated field
        ((F_EventAll) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
      ((F_EventAll) this).ValueChanging = false;
    }
    if (!(control2.Name == ((F_DoorMat) this).\u0005.Name))
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
    ((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size = new SizeObject(((F_EventAll) this).FoamSize);
    ((F_MarbleJobList) fMaterial3D).Init((MaterialBase5) null);
    fMaterial3D.StartPosition = FormStartPosition.CenterParent;
    int num = (int) fMaterial3D.ShowDialog((IWin32Window) this);
    // ISSUE: reference to a compiler-generated field
    if (((F_MarbleJobOPListV2) fMaterial3D).PropertiesForm.Result != DialogResult.OK || ((F_EventAll) this).\u0002 == null)
      return;
    ((F_EventAll) this).FoamSize = new SizeObject(((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size);
    // ISSUE: reference to a compiler-generated field
    ((F_EventAll) this).\u0002((object) "FoamSize", (object) ((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_EventAll) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_EventAll) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_EventAll) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_EventAll) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_EventAll) this).PropertiesForm.Inited || ((F_EventAll) this).ValueChanging || AppBool.Calculation)
      return;
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DoorMat) this).spn_blockhorcount.Name && ((F_EventAll) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_EventAll) this).\u0002((object) "HorizontalCount", (object) (double) ((F_DoorMat) this).spn_blockhorcount.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DoorMat) this).spn_blockvercount.Name && ((F_EventAll) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_EventAll) this).\u0002((object) "VerticalCount", (object) (double) ((F_DoorMat) this).spn_blockvercount.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DoorMat) this).spn_cutvel.Name && ((F_EventAll) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_EventAll) this).\u0002((object) "VelCut", (object) (double) ((F_DoorMat) this).spn_cutvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DoorMat) this).spn_leadinvel.Name && ((F_EventAll) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_EventAll) this).\u0002((object) "VelLeadIn", (object) (double) ((F_DoorMat) this).spn_leadinvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DoorMat) this).spn_leadoutvel.Name && ((F_EventAll) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_EventAll) this).\u0002((object) "VelLeadOut", (object) (double) ((F_DoorMat) this).spn_leadoutvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control.Name == ((F_DoorMat) this).spn_connectionvel.Name) || ((F_EventAll) this).\u0002 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_EventAll) this).\u0002((object) "VelConnection", (object) (double) ((F_DoorMat) this).spn_connectionvel.Value);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_EventAll) this).PropertiesForm.Inited)
      return;
    ((F_EventAll) this).ValueChanging = true;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_EventAll) this).\u0001 != null)
    {
      FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
      // ISSUE: reference to a compiler-generated field
      ((F_EventAll) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
    }
    ((F_EventAll) this).ValueChanging = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_EventAll) this).PropertiesForm.Inited)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_EventAll) this).\u0001 == null)
      return;
    FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
    // ISSUE: reference to a compiler-generated field
    ((F_EventAll) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_EventAll) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_EventAll) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m00155C();
}
