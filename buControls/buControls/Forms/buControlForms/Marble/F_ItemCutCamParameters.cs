// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Marble.F_ItemCutCamParameters
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.Controls;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Marble;

public class F_ItemCutCamParameters : Form
{
  public static List<string> Captions = new List<string>();
  public marbleOperation Value = new marbleOperation();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  public buSpin spn_bwdvel;
  public buSpin spn_fwdvel;
  public buSpin spn_leadout;
  public buSpin spn_leadin;
  public buSpin spn_plungevel;
  public buSpin spn_matthickness;
  public buSpin spn_leavevel;
  public buSpin spn_backwardcutstep;
  public buSpin spn_forwardcutstep;
  public buComboBox cmb_cutdir;
  public buSpin spn_stepupdistance;
  public buSpin spn_safedistance;

  public F_ItemCutCamParameters()
  {
    Class39.smethod_673(this);
    this.spn_bwdvel.Click += new EventHandler(this.spn_plungevel_Click);
    this.spn_fwdvel.Click += new EventHandler(this.spn_plungevel_Click);
    this.spn_leadin.Click += new EventHandler(this.spn_plungevel_Click);
    this.spn_leadout.Click += new EventHandler(this.spn_plungevel_Click);
    this.spn_plungevel.Click += new EventHandler(this.spn_plungevel_Click);
  }

  public void Init()
  {
    this.spn_bwdvel.Value = this.Value.CamParameters.BackwardCuttingVelocity;
    this.spn_fwdvel.Value = this.Value.CamParameters.ForwardCuttingVelocity;
    this.spn_leadin.Value = this.Value.CamParameters.FirstEnterDistance;
    this.spn_leadout.Value = this.Value.CamParameters.LastOutDistance;
    this.spn_plungevel.Value = this.Value.CamParameters.PlungeVelocity;
    this.spn_leavevel.Value = this.Value.CamParameters.LeaveVelocity;
    this.spn_matthickness.Value = this.Value.MaterialThickness;
    this.spn_forwardcutstep.Value = this.Value.CamParameters.ForwardStepDownDistance;
    this.spn_backwardcutstep.Value = this.Value.CamParameters.BackwardStepDownDistance;
    this.spn_safedistance.Value = this.Value.CamParameters.SafeDistance;
    this.spn_stepupdistance.Value = this.Value.CamParameters.StepUpDistance;
    this.LoadLanguage();
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.CamParameters.CuttingDirection, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Value.CamParameters.CuttingDirection), ref this.cmb_cutdir);
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_ItemCutCamParameters.Captions.Count <= 14)
        return;
      this.buGround_0.Text = F_ItemCutCamParameters.Captions[0];
      this.spn_fwdvel.Caption.Caption = F_ItemCutCamParameters.Captions[1];
      this.spn_bwdvel.Caption.Caption = F_ItemCutCamParameters.Captions[2];
      this.spn_leadin.Caption.Caption = F_ItemCutCamParameters.Captions[3];
      this.spn_leadout.Caption.Caption = F_ItemCutCamParameters.Captions[4];
      this.spn_plungevel.Caption.Caption = F_ItemCutCamParameters.Captions[5];
      this.spn_leavevel.Caption.Caption = F_ItemCutCamParameters.Captions[6];
      this.spn_forwardcutstep.Caption.Caption = F_ItemCutCamParameters.Captions[7];
      this.spn_backwardcutstep.Caption.Caption = F_ItemCutCamParameters.Captions[8];
      this.spn_matthickness.Caption.Caption = F_ItemCutCamParameters.Captions[9];
      this.spn_safedistance.Caption.Caption = F_ItemCutCamParameters.Captions[10];
      this.spn_stepupdistance.Caption.Caption = F_ItemCutCamParameters.Captions[11];
      this.cmb_cutdir.Caption.Caption = F_ItemCutCamParameters.Captions[12];
      this.buButton_1.Text = F_ItemCutCamParameters.Captions[13];
      this.buButton_2.Text = F_ItemCutCamParameters.Captions[14];
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_0(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.buGround_0.Controls, result, e.Shift);
  }

  internal void spn_plungevel_Click(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Value.CamParameters.BackwardCuttingVelocity = this.spn_bwdvel.Value;
    this.Value.CamParameters.ForwardCuttingVelocity = this.spn_fwdvel.Value;
    this.Value.CamParameters.FirstEnterDistance = this.spn_leadin.Value;
    this.Value.CamParameters.LastOutDistance = this.spn_leadout.Value;
    this.Value.CamParameters.PlungeVelocity = this.spn_plungevel.Value;
    this.Value.CamParameters.LeaveVelocity = this.spn_leavevel.Value;
    this.Value.MaterialThickness = this.spn_matthickness.Value;
    this.Value.CamParameters.ForwardStepDownDistance = this.spn_forwardcutstep.Value;
    this.Value.CamParameters.BackwardStepDownDistance = this.spn_backwardcutstep.Value;
    this.Value.CamParameters.SafeDistance = this.spn_safedistance.Value;
    this.Value.CamParameters.StepUpDistance = this.spn_stepupdistance.Value;
    this.Value.CamParameters.CuttingDirection = (CamCuttingDirectionType) buGeneral.EnumValueFromInt((object) this.Value.CamParameters.CuttingDirection, this.cmb_cutdir.SelectedIndex);
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
