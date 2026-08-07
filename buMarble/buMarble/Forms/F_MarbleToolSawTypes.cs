// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleToolSawTypes
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleToolSawTypes : Form
{
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal ImageList \u0001;
  public buButton btn_input;
  public buButton btn_output;
  public buTab buTab_tools;
  public TabPage tabPage_input;
  internal TabPage \u0001;
  public buButton btn_default;
  public buButton btn_readplc;
  public DataGridView DGV_Input;
  public DataGridView DGV_Output;
  public buButton btn_codesysdefault;
  public static byte f000452;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.buGround1.Controls);
    if (PageIndex == 0)
    {
      this.btn_input = buControlCommands.SetButtonColorAll(this.btn_input, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
      this.buTab_tools.SelectedIndex = 0;
    }
    if (PageIndex != 1)
      return;
    this.btn_output = buControlCommands.SetButtonColorAll(this.btn_output, buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor);
    this.buTab_tools.SelectedIndex = 1;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_ok.Name)
      {
        ((F_MarbleIOConfig) this).Apply();
        ((F_MarbleIOConfig) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleIOConfig) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleIOConfig) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == ((F_MarbleIOConfig) this).btn_close.Name | control.Name == this.btn_cancel.Name)
      {
        ((F_MarbleIOConfig) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleIOConfig) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleIOConfig) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_readplc.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Read, buLangTranslate.preSentences.DoYouWantToReadIOParameter);
        int num1 = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        clsAppMarbleVars.cmdMarble.ReadIOData();
        ((F_MarbleIOConfig) this).FillIO();
        buDialogMessageBoxOk dialogMessageBoxOk = new buDialogMessageBoxOk();
        dialogMessageBoxOk.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxOk.Init(buLangTranslate.preDef.Parameter, buLangTranslate.preSentences.ParameterReadDone);
        int num2 = (int) dialogMessageBoxOk.ShowDialog();
      }
      if (control.Name == this.btn_default.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Read, buLangTranslate.preSentences.DoYouWanttoCallDefaultValues);
        int num3 = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        clsAppMarbleVars.cmdMarble.DebugCreateDefaultIOFile();
        buDialogMessageBoxOk dialogMessageBoxOk = new buDialogMessageBoxOk();
        dialogMessageBoxOk.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxOk.Init(buLangTranslate.preDef.File, $"{buLangTranslate.preSentences.FileCreated}{Environment.NewLine}{AppPath.Base}\\DefaultIO.txt");
        int num4 = (int) dialogMessageBoxOk.ShowDialog();
      }
      if (control.Name == this.btn_codesysdefault.Name)
      {
        buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
        dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Read, buLangTranslate.preSentences.DoYouWanttoCallDefaultValues);
        int num5 = (int) dialogMessageBoxYesNo.ShowDialog();
        if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
          return;
        clsAppMarbleVars.cmdMarble.DebugCreateDefaultCodesysIO();
        buDialogMessageBoxOk dialogMessageBoxOk = new buDialogMessageBoxOk();
        dialogMessageBoxOk.StartPosition = FormStartPosition.CenterScreen;
        dialogMessageBoxOk.Init(buLangTranslate.preDef.File, $"{buLangTranslate.preSentences.FileCreated}{Environment.NewLine}{AppPath.Base}\\DefaultCodesysIO.txt");
        int num6 = (int) dialogMessageBoxOk.ShowDialog();
      }
      if (control.Name == this.btn_input.Name)
      {
        this.buTab_tools.SelectedIndex = 0;
        this.MenuButtonColors(0);
      }
      if (!(control.Name == this.btn_output.Name))
        return;
      this.buTab_tools.SelectedIndex = 1;
      this.MenuButtonColors(1);
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex != 5 || (obj1.RowIndex < 0 ? 0 : (obj1.RowIndex <= clsAppMarbleVars.cMachine.Outputs.Count - 1 ? 1 : 0)) == 0)
      return;
    int rowIndex = obj1.RowIndex;
    bool Val = false;
    clsAppMarbleVars.cmdMarble.readBOOLVar(CodesysVariableBaseType.None, clsAppMarbleVars.cMachine.Outputs[rowIndex].Name, ref Val);
    if (!Val)
      clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.None, true, clsAppMarbleVars.cMachine.Outputs[rowIndex].Name);
    else
      clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.None, false, clsAppMarbleVars.cMachine.Outputs[rowIndex].Name);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleIOConfig) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleIOConfig) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolSawTypes() => F_MarbleIOConfig.Captions = new List<string>();

  public F_MarbleToolSawTypes()
  {
    ((F_MarbleUserList) this).Tool = new ToolBase5();
    ((F_MarbleUserList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_MarbleUserList) this).\u0001.Text = ((F_MarbleUserList) this).Tool.Data.Name;
    ((F_MarbleUserList) this).spn_toolthickness.Value = ((F_MarbleUserList) this).Tool.Geometry.Thickness;
    ((F_MarbleUserList) this).spn_tooldia.Value = ((F_MarbleUserList) this).Tool.Geometry.Diameter;
    ((F_MarbleUserList) this).spn_toolsocket.Value = ((F_MarbleUserList) this).Tool.Geometry.SocketThickness;
    ((F_MarbleMDIV1) this).spn_toolspeed.Value = ((F_MarbleUserList) this).Tool.CamData.SpindleSpeed;
    \u0005.\u0003.\u0001(this);
    clsAppMarbleVars.cmdMarble.DrawTool(((F_MarbleUserList) this).Tool);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((F_MarbleUserList) this).Tool.Purpose = ToolPurpose.Saw;
    ((F_MarbleUserList) this).Tool.Data.Name = ((F_MarbleUserList) this).\u0001.Text;
    ((F_MarbleUserList) this).Tool.CamData.SpindleSpeed = ((F_MarbleMDIV1) this).spn_toolspeed.Value;
    ((F_MarbleUserList) this).Tool.Geometry.Thickness = ((F_MarbleUserList) this).spn_toolthickness.Value;
    ((F_MarbleUserList) this).Tool.Geometry.Diameter = ((F_MarbleUserList) this).spn_tooldia.Value;
    ((F_MarbleUserList) this).Tool.Geometry.SocketThickness = ((F_MarbleUserList) this).spn_toolsocket.Value;
    if (((F_MarbleUserList) this).Tool.Geometry.Thickness <= 0.0)
      ((F_MarbleUserList) this).Tool.Geometry.CutLength = ((F_MarbleUserList) this).Tool.Geometry.Length * 0.75;
    if (((F_MarbleUserList) this).Tool.Geometry.Diameter <= 0.0)
      return;
    clsAppMarbleVars.cmdMarble.DrawTool(((F_MarbleUserList) this).Tool);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleUserList) this).btn_ok.Name)
      {
        this.Apply();
        ((F_MarbleMDIV1) this).pnl_preview.Controls.Clear();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleUserList) this).btn_close.Name | control2.Name == ((F_MarbleUserList) this).btn_cancel.Name))
        return;
      ((F_MarbleMDIV1) this).pnl_preview.Controls.Clear();
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }
}
