// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUICheck
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Events;
using buEyeBaseVer5.Forms.Customer.DincMak;
using buEyeBaseVer5.Forms.Diamaker;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.Forms.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUICheck : Form
{
  internal Button \u0005;
  internal Button \u0006;
  internal Button \u0007;
  internal NumericUpDown \u0001;
  internal Button \u0008;
  internal Label \u0003;
  internal Label \u0004;
  internal TextBox \u0002;
  internal Button \u000E;
  internal NumericUpDown \u0002;
  internal NumericUpDown \u0003;
  public DataGridView grid_files;
  internal Panel \u0003;
  internal CheckBox \u0001;
  internal PictureBox \u0001;
  public static byte f003260;
  [CompilerGenerated]
  internal OkCommandWithTwoDataEventHandler \u0001;
  public FormProperties PropertiesForm;
  public List<buEntity> EntitiesTransformed;
  public List<LayerBase5> Layers;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  public void Apply()
  {
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightEndOffset = (double) ((F_DiamakerGrindVShape) this).spn_blockheightendoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternHeightStartOffset = (double) ((F_DiamakerGrindVShape) this).spn_blockheightstartoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthEndOffset = (double) ((F_DiamakerGrindVShape) this).spn_blockwidthendoffset.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).PatternWidthStartOffset = (double) ((F_DiamakerGrindVShape) this).spn_blockwidthstartoffset.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockWidth = (double) ((F_DiamakerGrindVShape) this).spn_blocktotalwidth.Value;
    ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).BlockHeight = (double) ((F_DiamakerGrindVShape) this).spn_blocktotalheight.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormRepeatCount = (int) ((F_DiamakerGrindVShape) this).spn_repeatcount.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormSpace = (double) ((F_DiamakerGrindVShape) this).spn_space.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonWidth = (double) ((F_DiamakerGrindVShape) this).spn_wavewidth.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonHeight = (double) ((F_DiamakerGrindVShape) this).spn_waveheight.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonBaseHeight = (double) ((F_DiamakerGrindVShape) this).spn_wavebaseheight.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonRoundRad = (double) ((F_DiamakerGrindVShape) this).spn_round.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).WaveFormShapeCommonChamferLen = (double) ((F_DiamakerGrindVShape) this).spn_chamfer.Value;
    ((DrillMoveOptions) DrillCalcItem.varFoamRunSettings).BlockName = ((F_DiamakerGrindVShape) this).\u0001.Text;
    ((DrillMove) DrillCalcItem.varFoamSettings).CuttingFeed = (double) ((F_DiamakerGrindVShape) this).spn_cutvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).EntryFeed = (double) ((F_DiamakerGrindVShape) this).spn_leadinvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).LeaveFeed = (double) ((F_DiamakerGrindVShape) this).spn_leadoutvel.Value;
    ((DrillMove) DrillCalcItem.varFoamSettings).ConnectionFeed = (double) ((F_DiamakerGrindVShape) this).spn_connectionvel.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_DiamakerGrindVShape) this).\u0002.Name)
    {
      ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.Cancel;
      // ISSUE: reference to a compiler-generated field
      if (((F_DiamakerGrindVShape) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_DiamakerGrindVShape) this).\u0001();
      }
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_DiamakerGrindVShape) this).\u0001.Name)
    {
      ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.OK;
      // ISSUE: reference to a compiler-generated field
      if (((F_DiamakerGrindVShape) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Finished = true;
        // ISSUE: reference to a compiler-generated field
        ((F_DiamakerGrindVShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_DiamakerGrindVShape) this).\u0003.Name)
    {
      ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames = FoamPlaneType.YZ;
      ((F_DiamakerGrindVShape) this).\u0004.BackColor = Color.Silver;
      ((F_DiamakerGrindVShape) this).\u0003.BackColor = Color.Gold;
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      if (((F_DiamakerGrindVShape) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Command = "PlaneYZ";
        // ISSUE: reference to a compiler-generated field
        ((F_DiamakerGrindVShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
    }
    if (control2.Name == ((F_DiamakerGrindVShape) this).\u0004.Name)
    {
      ((DrillCNCSettings) DrillCalcItem.varFoamRunSettings).planeNames = FoamPlaneType.XZ;
      ((F_DiamakerGrindVShape) this).\u0004.BackColor = Color.Gold;
      ((F_DiamakerGrindVShape) this).\u0003.BackColor = Color.Silver;
      this.Apply();
      // ISSUE: reference to a compiler-generated field
      if (((F_DiamakerGrindVShape) this).\u0001 != null)
      {
        FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
        ((DrillCNCSettings) Data2).Command = "PlaneXZ";
        // ISSUE: reference to a compiler-generated field
        ((F_DiamakerGrindVShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
      }
    }
    if (!(control2.Name == ((F_DiamakerGrindVShape) this).\u0005.Name))
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
    ((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size = new SizeObject(((F_DiamakerGrindVShape) this).FoamSize);
    ((F_MarbleJobList) fMaterial3D).Init((MaterialBase5) null);
    fMaterial3D.StartPosition = FormStartPosition.CenterParent;
    int num = (int) fMaterial3D.ShowDialog((IWin32Window) this);
    // ISSUE: reference to a compiler-generated field
    if (((F_MarbleJobOPListV2) fMaterial3D).PropertiesForm.Result != DialogResult.OK || ((F_DiamakerGrindVShape) this).\u0002 == null)
      return;
    ((F_DiamakerGrindVShape) this).FoamSize = new SizeObject(((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size);
    // ISSUE: reference to a compiler-generated field
    ((F_DiamakerGrindVShape) this).\u0002((object) "FoamSize", (object) ((SortResult) ((F_MarbleJobOPListV2) fMaterial3D).Material).Size);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_DiamakerGrindVShape) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_DiamakerGrindVShape) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_DiamakerGrindVShape) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_DiamakerGrindVShape) this).PropertiesForm.Inited || ((F_DiamakerGrindVShape) this).ValueChanging)
      return;
    ((F_DiamakerGrindVShape) this).ValueChanging = true;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_DiamakerGrindVShape) this).\u0001 != null)
    {
      FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
    }
    ((F_DiamakerGrindVShape) this).ValueChanging = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (!((F_DiamakerGrindVShape) this).PropertiesForm.Inited || ((F_DiamakerGrindVShape) this).ValueChanging || AppBool.Calculation)
      return;
    ((F_DiamakerGrindVShape) this).ValueChanging = true;
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DiamakerGrindVShape) this).spn_blockhorcount.Name && ((F_DiamakerGrindVShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0002((object) "HorizontalCount", (object) (double) ((F_DiamakerGrindVShape) this).spn_blockhorcount.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DiamakerGrindVShape) this).spn_blockvercount.Name && ((F_DiamakerGrindVShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0002((object) "VerticalCount", (object) (double) ((F_DiamakerGrindVShape) this).spn_blockvercount.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DiamakerGrindVShape) this).spn_cutvel.Name && ((F_DiamakerGrindVShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0002((object) "VelCut", (object) (double) ((F_DiamakerGrindVShape) this).spn_cutvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DiamakerGrindVShape) this).spn_leadinvel.Name && ((F_DiamakerGrindVShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0002((object) "VelLeadIn", (object) (double) ((F_DiamakerGrindVShape) this).spn_leadinvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DiamakerGrindVShape) this).spn_leadoutvel.Name && ((F_DiamakerGrindVShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0002((object) "VelLeadOut", (object) (double) ((F_DiamakerGrindVShape) this).spn_leadoutvel.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_DiamakerGrindVShape) this).spn_connectionvel.Name && ((F_DiamakerGrindVShape) this).\u0002 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_DiamakerGrindVShape) this).\u0002((object) "VelConnection", (object) (double) ((F_DiamakerGrindVShape) this).spn_connectionvel.Value);
    }
    ((F_DiamakerGrindVShape) this).ValueChanging = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_DiamakerGrindVShape) this).PropertiesForm.Inited)
      return;
    this.Apply();
    // ISSUE: reference to a compiler-generated field
    if (((F_DiamakerGrindVShape) this).\u0001 == null)
      return;
    FoamUpdateArg Data2 = (FoamUpdateArg) new buNestingCalc();
    // ISSUE: reference to a compiler-generated field
    ((F_DiamakerGrindVShape) this).\u0001((object) DrillCalcItem.varFoamRunSettings, (object) Data2);
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    double result = 0.0;
    if (((F_DiamakerGrindVShape) this).lst_idealwidth.SelectedIndex < 0)
      return;
    double.TryParse(((F_DiamakerGrindVShape) this).lst_idealwidth.Items[((F_DiamakerGrindVShape) this).lst_idealwidth.SelectedIndex].ToString(), out result);
    if (result <= 0.0)
      return;
    ((F_DiamakerGrindVShape) this).spn_blocktotalwidth.Value = (Decimal) (result + 0.1);
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    double result = 0.0;
    if (((F_DiamakerGrindVShape) this).lst_idealheight.SelectedIndex < 0)
      return;
    double.TryParse(((F_DiamakerGrindVShape) this).lst_idealheight.Items[((F_DiamakerGrindVShape) this).lst_idealheight.SelectedIndex].ToString(), out result);
    if (result <= 0.0)
      return;
    ((F_DiamakerGrindVShape) this).spn_blocktotalheight.Value = (Decimal) (result + 0.1);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_DiamakerGrindVShape) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_DiamakerGrindVShape) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m00156F();

  public F_ControlUICheck()
  {
    ((F_DiamakerGrindVShape) this).PropertiesForm = new FormProperties();
    ((F_DiamakerGrindVShape) this).SequenceHor = FoamSequenceHor.HorizontalStartThenEnd;
    ((F_DiamakerGrindVShape) this).SequenceVer = FoamSequenceVer.VerticalStartThenEnd;
    ((F_DiamakerGrindVShape) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_FoamSequence) this);
    ((F_DiamakerGrindVShape) this).\u0001.Image = ((F_DiamakerGrindVShape) this).\u0002.Images[0];
    ((F_DiamakerGrindVShape) this).\u0002.Image = ((F_DiamakerGrindVShape) this).\u0002.Images[1];
    ((F_RectangleShape) this).\u0005.Image = ((F_DiamakerGrindVShape) this).\u0002.Images[2];
    ((F_RectangleShape) this).\u0004.Image = ((F_RectangleShape) this).\u0003.Images[0];
    ((F_RectangleShape) this).\u0003.Image = ((F_RectangleShape) this).\u0003.Images[1];
  }
}
