// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleImageMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleImageMenu : Form
{
  public buButton btn_dooropen;
  public buCheckBox chk_round6;
  public buCheckBox chk_round5;
  public buCheckBox chk_round4;
  public buCheckBox chk_round3;
  public buCheckBox chk_round2;
  public buLabel buLabel10;
  public buCheckBox chk_round1;
  public static byte f002477;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public ToolBase5 ToolSaw;
  public ToolBase5 ToolMillingHead;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_opentools;
  public buButton btn_savetools;
  public buTab buTab_command_settings;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleToolSpindleAndMagazine) this).indexMat = ((F_MarbleToolSawMillingHeadMilling) this).\u0001.SelectedIndex;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCamSettings) this);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control Ctrl = obj0 as Control;
    List<string> FileNames = new List<string>();
    string str = "---------------";
    if (Ctrl is buControl)
    {
      buControl buControl = Ctrl as buControl;
      if ((buControl.Aux.HelpRefKey == null ? 0 : (buControl.Aux.HelpRefKey.Length > 0 ? 1 : 0)) != 0)
      {
        if (AppBool.HelpMe)
        {
          AppBool.HelpMe = false;
          buFile5.IsoCutter.GetFilesWithKeywordWithExtension(AppPath.HelpVideo, buControl.Aux.HelpRefKey, "mp4", ref FileNames);
          if (FileNames.Count > 0)
            ;
        }
        buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, buControl.Aux.HelpRefKey, ref FileNames);
        if (FileNames.Count > 0)
        {
          ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
          string controlText = buControlCommands.GetControlText(Ctrl);
          if (controlText.Length <= 0)
            return;
          ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine;
          return;
        }
      }
    }
    if (Ctrl.Name == ((F_MarbleToolSawMillingHeadMilling) this).\u0007.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0003", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preCaptionMarble.ConcaveCornerByDrillMilling;
    }
    else if (Ctrl.Name == ((F_MarbleToolSpindleAndMagazine) this).\u0005.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0004", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSawMillingHeadMilling) this).\u0007.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0005", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSawMillingHead) this).\u0006.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0007", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSawMillingHeadMilling) this).\u0008.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0039", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSpindleAndMagazine) this).\u0003.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0037", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSpindleAndMagazine) this).\u0004.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0038", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u0019.Name | Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u001D.Name | Ctrl.Name == ((F_MarbleSawMillingMenu) this).\u007F.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0008", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u0018.Name | Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u001C.Name | Ctrl.Name == ((F_MarbleSawMillingMenu) this).\u001F.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0010", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSawMilling) this).\u0014.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0011", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolSawMilling) this).\u0013.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0012", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u001B.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0013", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u001A.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0014", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str;
    }
    else if (Ctrl.Name == ((F_MarbleSawMillingMenu) this).\u0080.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0031", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcAAngle;
    }
    else if (Ctrl.Name == ((F_MarbleSawMillingMenu) this).\u0081.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0032", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcOffset;
    }
    else if (Ctrl.Name == ((F_MarbleSawMillingMenu) this).\u0082.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0033", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u0017.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0034", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u0016.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0036", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
    }
    else if (Ctrl.Name == ((F_MarbleToolAndStrategyMenu) this).\u0015.Name)
    {
      buFile5.IsoCutter.GetFilesWithKeyword(AppPath.HelpImages, "H0035", ref FileNames);
      if (FileNames.Count <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = Image.FromFile(FileNames[0]);
      string controlText = buControlCommands.GetControlText(Ctrl);
      if (controlText.Length <= 0)
        return;
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = controlText + Environment.NewLine + str + Environment.NewLine + buLangTranslate.preHelpMarble.ConcaveArcNoOffset;
    }
    else
    {
      ((F_MarbleToolSawMillingHead) this).\u0007.Text = buLangTranslate.preSentences.NoInformatonAvailable + Environment.NewLine + str;
      ((F_MarbleToolSawMillingHead) this).\u0001.Image = (Image) null;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleImageMenu() => F_MarbleToolSpindleAndMagazine.Captions = new List<string>();

  public F_MarbleImageMenu()
  {
    ((F_MarbleOperationCmds) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleOperationCmds) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleOperationCmds) this).ToolMilling = (ToolBase5) new ToolGeometry5();
    ((F_MarbleOperationCmds) this).Tools = (ToolBase5[]) null;
    ((F_MarbleOperationCmds) this).PropertiesForm = new FormProperties();
    ((F_MarbleOperationCmds) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleToolSpindleAndMagazine) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandTool(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleOperationCmds) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleOperationCmds) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandTool(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleOperationCmds) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleOperationCmds) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleOperationCmds) this).PropertiesForm.Inited = false;
    if (((F_MarbleOperationCmds) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleOperationCmds) this).PropertiesForm.Height;
    if (((F_MarbleOperationCmds) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleOperationCmds) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleOperationCmds) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleOperationCmds) this).PropertiesForm.FormPosition;
    ((F_MarbleOperationCmds) this).spn_milling_diameter.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).ToolMilling).Geometry.Diameter;
    ((F_MarbleOperationCmds) this).spn_milling_length.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).ToolMilling).Geometry.Length;
    ((F_MarbleOperationCmds) this).spn_milling_speed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).ToolMilling).CamData).SpindleSpeed;
    ((F_MarbleProfileCamStrategyMenu) this).spn_toollen1.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry.Length;
    ((F_MarbleProfileCamStrategyMenu) this).spn_toollen2.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry.Length;
    ((F_MarbleOperationCmds) this).spn_toollen3.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry.Length;
    ((F_MarbleOperationCmds) this).spn_toollen4.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry.Length;
    ((F_MarbleOperationCmds) this).spn_toollen5.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry.Length;
    if (((F_MarbleOperationCmds) this).Tools.Length >= 6)
      ((F_MarbleOperationCmds) this).spn_toollen6.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Geometry.Length;
    ((F_MarbleProfileCamStrategyMenu) this).spn_tooldia1.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry.Diameter;
    ((F_MarbleOperationCmds) this).spn_tooldia2.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry.Diameter;
    ((F_MarbleOperationCmds) this).spn_tooldia3.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry.Diameter;
    ((F_MarbleOperationCmds) this).spn_tooldia4.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry.Diameter;
    ((F_MarbleOperationCmds) this).spn_tooldia5.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry.Diameter;
    if (((F_MarbleOperationCmds) this).Tools.Length >= 6)
      ((F_MarbleProfileCamStrategyMenu) this).spn_tooldia1.Value = ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry.Diameter;
    ((F_MarbleProfileCamStrategyMenu) this).spn_toolspeed1.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).CamData).SpindleSpeed;
    ((F_MarbleOperationCmds) this).spn_toolspeed2.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).CamData).SpindleSpeed;
    ((F_MarbleOperationCmds) this).spn_toolspeed3.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).CamData).SpindleSpeed;
    ((F_MarbleOperationCmds) this).spn_toolspeed4.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).CamData).SpindleSpeed;
    ((F_MarbleOperationCmds) this).spn_toolspeed5.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).CamData).SpindleSpeed;
    if (((F_MarbleOperationCmds) this).Tools.Length >= 6)
      ((F_MarbleOperationCmds) this).spn_toolspeed6.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).CamData).SpindleSpeed;
    ((F_MarbleSheetMenu) this).spn_toolX1.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Positions).Position.X;
    ((F_MarbleSheetMenu) this).spn_toolX2.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Positions).Position.X;
    ((F_MarbleCounterTopMenu) this).spn_toolX3.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Positions).Position.X;
    ((F_MarbleCounterTopMenu) this).spn_toolX4.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Positions).Position.X;
    ((F_MarbleCounterTopMenu) this).spn_toolX5.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Positions).Position.X;
    ((F_MarbleCounterTopMenu) this).spn_toolX6.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Positions).Position.X;
    ((F_MarbleSheetMenu) this).spn_toolY1.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Positions).Position.Y;
    ((F_MarbleSheetMenu) this).spn_toolY2.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Positions).Position.Y;
    ((F_MarbleCounterTopMenu) this).spn_toolY3.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Positions).Position.Y;
    ((F_MarbleCounterTopMenu) this).spn_toolY4.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Positions).Position.Y;
    ((F_MarbleCounterTopMenu) this).spn_toolY5.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Positions).Position.Y;
    ((F_MarbleCounterTopMenu) this).spn_toolY6.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Positions).Position.Y;
    ((F_MarbleSheetMenu) this).spn_toolZ1.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Positions).Position.Z;
    ((F_MarbleCounterTopMenu) this).spn_toolZ2.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Positions).Position.Z;
    ((F_MarbleCounterTopMenu) this).spn_toolZ3.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Positions).Position.Z;
    ((F_MarbleCounterTopMenu) this).spn_toolZ4.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Positions).Position.Z;
    ((F_MarbleCounterTopMenu) this).spn_toolZ5.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Positions).Position.Z;
    ((F_MarbleCounterTopMenu) this).spn_toolZ6.Value = ((MoveEventFormVars) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Positions).Position.Z;
    this.chk_round1.Check = ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[1]).Geometry).GeometryType != ToolType.Flat;
    this.chk_round2.Check = ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[2]).Geometry).GeometryType != ToolType.Flat;
    this.chk_round3.Check = ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[3]).Geometry).GeometryType != ToolType.Flat;
    this.chk_round4.Check = ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[4]).Geometry).GeometryType != ToolType.Flat;
    this.chk_round5.Check = ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[5]).Geometry).GeometryType != ToolType.Flat;
    this.chk_round6.Check = ((ToolData5) ((ToolGeometry5) ((F_MarbleOperationCmds) this).Tools[6]).Geometry).GeometryType != ToolType.Flat;
    this.LoadLanguage();
    ((F_MarbleOperationCmds) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleOperationCmds) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleOperationCmds) this).\u0001.Text = buLangTranslate.preDef.Tools;
      ((F_MarbleOperationCmds) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleOperationCmds) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleOperationCmds) this).tabPage_mlling.Text = buLangTranslate.preDef.Milling;
      ((F_MarbleOperationCmds) this).btn_milling_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleOperationCmds) this).btn_milling_activate.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Activate}";
      ((F_MarbleOperationCmds) this).btn_milling_measure.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}";
      ((F_MarbleOperationCmds) this).btn_milling_zeroposition.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Zero}";
      ((F_MarbleOperationCmds) this).btn_savetools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Save}";
      ((F_MarbleOperationCmds) this).btn_opentools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Open}";
      ((F_MarbleOperationCmds) this).spn_milling_diameter.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleOperationCmds) this).spn_milling_length.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}";
      ((F_MarbleOperationCmds) this).spn_milling_speed.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Speed}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleOperationCmds) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleOperationCmds) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleOperationCmds) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleOperationCmds) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithThreeDataEventHandler CommandExecute;
}
