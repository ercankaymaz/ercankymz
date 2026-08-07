// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_ItemCutCamParameters
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Controls;
using buEyeBaseVer5.Forms.File;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_ItemCutCamParameters : Form
{
  public buCheckBox chk_midtoleft;
  public buCheckBox chk_mintomax;
  public buSpin spn_radiustopdistance;
  internal buSeparator \u0001;
  public buCheckBox chk_caxisfollowdirection;
  public buLabel lbl_direction;
  public static byte f002A26;
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleProfileCutPars varProfileCut;
  public string strMessageRoughtFinish;
  public string strMessageRoughtFinishSelect;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;

  public void Init()
  {
    ((F_MarbleContourMenu) this).Properties.Inited = false;
    if (((F_MarbleContourMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleContourMenu) this).Properties.Height;
    if (((F_MarbleContourMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleContourMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleContourMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleContourMenu) this).Properties.FormPosition;
    ((F_MarbleContourMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleContourMenu) this).Properties.Inited = true;
    ((F_MarbleContourMenu) this).spn_rampheight.Value = ((MarbleCorners) ((F_MarbleContourMenu) this).varSweep).SweepRampHeight;
    ((F_MarbleContourMenu) this).spn_rampwidth.Value = ((MarbleCorners) ((F_MarbleContourMenu) this).varSweep).SweepRampWidth;
    ((F_MarbleContourMenu) this).spn_targetz.Value = ((MarbleCorners) ((F_MarbleContourMenu) this).varSweep).SweepTargetZ;
    ((F_MarbleContourMenu) this).spn_width.Value = ((MarbleCorners) ((F_MarbleContourMenu) this).varSweep).SweepWidth;
    ((F_MarbleContourMenu) this).spn_followoffset.Value = ((MarbleCorners) ((F_MarbleContourMenu) this).varSweep).SweepFollowOffset;
    ((F_MarbleContourMenu) this).spn_safedistance.Value = ((MarbleCopyType) ((F_MarbleContourMenu) this).varSweep).SafeDistance;
    ((F_MarbleContourMenu) this).spn_widthstep.Value = ((MarbleCopyType) ((F_MarbleContourMenu) this).varSweep).SweepYStep;
    if (((MarbleCopyType) ((F_MarbleContourMenu) this).varSweep).SawRampType == CamZRampType.None)
    {
      ((F_MarbleContourMenu) this).chk_circular.Check = false;
      ((F_MarbleContourMenu) this).chk_linear.Check = false;
      ((F_MarbleContourMenu) this).chk_none.Check = true;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = false;
    }
    else if (((MarbleCopyType) ((F_MarbleContourMenu) this).varSweep).SawRampType == CamZRampType.Linear)
    {
      ((F_MarbleContourMenu) this).chk_circular.Check = false;
      ((F_MarbleContourMenu) this).chk_linear.Check = true;
      ((F_MarbleContourMenu) this).chk_none.Check = false;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = false;
    }
    else if (((MarbleCopyType) ((F_MarbleContourMenu) this).varSweep).SawRampType == CamZRampType.FromFile)
    {
      ((F_MarbleContourMenu) this).chk_circular.Check = false;
      ((F_MarbleContourMenu) this).chk_linear.Check = false;
      ((F_MarbleContourMenu) this).chk_none.Check = false;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = true;
    }
    else
    {
      ((F_MarbleContourMenu) this).chk_circular.Check = true;
      ((F_MarbleContourMenu) this).chk_linear.Check = false;
      ((F_MarbleContourMenu) this).chk_none.Check = false;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = false;
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSweepCut) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleContourMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleContourMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleContourMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleContourMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleContourMenu) this).btn_selectfile.Name)
      {
        F_AddFromFile fAddFromFile = (F_AddFromFile) new F_ControlUIListbox();
        ((F_ControlUICheck) fAddFromFile).PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        fAddFromFile.StartPosition = FormStartPosition.CenterParent;
        ((F_ControlUICoordinate) fAddFromFile).Path = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathFromFileSweepForm;
        ((F_ControlUICoordinate) fAddFromFile).KeepRatio = true;
        ((F_ControlUICoordinate) fAddFromFile).ExtensionList.Clear();
        ((F_ControlUICoordinate) fAddFromFile).ExtensionList.Add(".dxf");
        ((F_ControlUICoordinate) fAddFromFile).ExtensionList.Add(".dwg");
        ((F_ControlUICoordinate) fAddFromFile).ExtensionList.Add(".bucad5");
        ((F_ControlUICoordinate) fAddFromFile).MoveEntities = false;
        ((F_ControlUIDataGridView) fAddFromFile).Init();
        int num = (int) fAddFromFile.ShowDialog();
        if (((F_ControlUICheck) fAddFromFile).PropertiesForm.Result != DialogResult.OK)
          return;
        ((F_MarbleContourMenu) this).SweepZFormEntities.Clear();
        ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathFromFileSweepForm = ((F_ControlUICoordinate) fAddFromFile).Path;
        for (int index = 0; index <= ((F_ControlUICoordinate) fAddFromFile).viewport.Entities.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buAngularDim.Copy(((F_ControlUICoordinate) fAddFromFile).viewport.Entities[index], ref copiedEntity);
          ((F_MarbleContourMenu) this).SweepZFormEntities.Add(copiedEntity);
        }
      }
      if (control2.Name == ((F_MarbleContourMenu) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleSweepCut) this);
        ((F_MarbleContourMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleContourMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleContourMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleContourMenu) this).btn_cancel.Name))
        return;
      ((F_MarbleContourMenu) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleContourMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleContourMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleContourMenu) this).Properties.Inited)
      return;
    buCheckBox buCheckBox = obj0 as buCheckBox;
    if (buCheckBox.Name == ((F_MarbleContourMenu) this).chk_circular.Name)
    {
      ((F_MarbleContourMenu) this).chk_circular.Check = true;
      ((F_MarbleContourMenu) this).chk_linear.Check = false;
      ((F_MarbleContourMenu) this).chk_none.Check = false;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = false;
    }
    if (buCheckBox.Name == ((F_MarbleContourMenu) this).chk_linear.Name)
    {
      ((F_MarbleContourMenu) this).chk_none.Check = false;
      ((F_MarbleContourMenu) this).chk_circular.Check = false;
      ((F_MarbleContourMenu) this).chk_linear.Check = true;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = false;
    }
    if (buCheckBox.Name == ((F_MarbleContourMenu) this).chk_none.Name)
    {
      ((F_MarbleContourMenu) this).chk_linear.Check = false;
      ((F_MarbleContourMenu) this).chk_circular.Check = false;
      ((F_MarbleContourMenu) this).chk_none.Check = true;
      ((F_MarbleContourMenu) this).chk_fromfile.Check = false;
    }
    if (!(buCheckBox.Name == ((F_MarbleContourMenu) this).chk_fromfile.Name))
      return;
    ((F_MarbleContourMenu) this).chk_linear.Check = false;
    ((F_MarbleContourMenu) this).chk_circular.Check = false;
    ((F_MarbleContourMenu) this).chk_none.Check = false;
    ((F_MarbleContourMenu) this).chk_fromfile.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleContourMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleContourMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ItemCutCamParameters() => F_MarbleContourMenu.Captions = new List<string>();

  public F_ItemCutCamParameters()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleContourMenu) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleContourMenu) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleContourMenu) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleContourMenu) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleContourMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleContourMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleContourMenu) this).PropertiesForm.Height;
    if (((F_MarbleContourMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleContourMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleContourMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleContourMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleAxesSettings) this).ToolToImageIndex();
    ((F_MarbleAxesSettings) this).StrategyFromToolType();
    ((F_MarbleSetAngle) this).buGround1.DisplayTop.BackColor = ((F_MarbleContourMenu) this).clrFormCaption;
    ((F_MarbleSetAngle) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleSetAngle) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleContourMenu) this).clrFormBackUpper;
    ((F_MarbleSetAngle) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleContourMenu) this).clrFormBackDown;
    ((F_MarbleSetAngle) this).btn_close.Display.BackColor = ((F_MarbleContourMenu) this).clrFormCaption;
    ((F_MarbleSetAngle) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleContourMenu) this).clrFormCaption, 0.9);
    ((F_MarbleSetAngle) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleContourMenu) this).clrFormCaption, 0.95);
    ((F_MarbleSetAngle) this).lbl_contourtype.Display.BackColor = ((F_MarbleContourMenu) this).clrLabel;
    ((F_MarbleSetAngle) this).lbl_strategytype.Display.BackColor = ((F_MarbleContourMenu) this).clrLabel;
    ((F_MarbleSetAngle) this).lbl_tooltype.Display.BackColor = ((F_MarbleContourMenu) this).clrLabel;
    ((F_MarbleContourMenu) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleContourMenu) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleContourMenu) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleSetAngle) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleSetAngle) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleSetAngle) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleSetAngle) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleSetAngle) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleSetAngle) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleSetAngle) this).btn_strategy.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleSetAngle) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleSetAngle) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleSetAngle) this).btn_tool.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleSetAngle) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleSetAngle) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleSetAngle) this).btn_toolsettings.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleSetAngle) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleSetAngle) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleSetAngle) this).btn_camsettings.Display.BackColor = ((F_MarbleContourMenu) this).clrButtonDisplay;
    ((F_MarbleSetAngle) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonDown;
    ((F_MarbleSetAngle) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleContourMenu) this).clrButtonOver;
    ((F_MarbleContourMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleContourMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleSetAngle) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Sweep} {buLangTranslate.preDef.Type}";
      ((F_MarbleSetAngle) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleSetAngle) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleContourMenu) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleSetAngle) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleSetAngle) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleSetAngle) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleSetAngle) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleSetAngle) this).buGround1.Text = $"{buLangTranslate.preDef.Sweep} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }
}
