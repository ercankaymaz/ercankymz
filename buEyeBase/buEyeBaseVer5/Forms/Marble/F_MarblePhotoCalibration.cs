// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarblePhotoCalibration
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
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

public class F_MarblePhotoCalibration : Form
{
  public buButton btn_addvacuum;
  public buListBox lst_vacuumlist;
  public static byte f001C8A;
  private string \u0001 = "F_MarbleViewV1";
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_magnetoffset;
  public buButton btn_magnet_rightup;
  public buButton btn_magnet_leftdown;
  public buButton btn_magnet_leftup;

  public F_MarblePhotoCalibration() => \u0007.\u0001.\u0001((F_MarbleEventAling) this);

  [CompilerGenerated]
  [SpecialName]
  public void add_AlingCommand(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = this.\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref this.\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_AlingCommand(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = this.\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref this.\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      ((F_MarbleImageThicknessList) this).\u0001.ItemSize = new Size(1, 1);
      ((F_MarbleImageThicknessList) this).\u0001.Text = "";
      ((F_MarbleImageThicknessList) this).\u0002.Text = "";
      ((F_MarbleVacuum) this).\u0003.Text = "";
      if (clsVisualVars.parVisual != null)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (!this.PropertiesForm.Updated)
    {
      this.UpdateVisuals();
      this.PropertiesForm.Updated = true;
    }
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.spn_magnetoffset.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignMagnetOffset;
    ((F_MarbleVacuum) this).spn_moveval.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignMoveValue;
    ((F_MarbleVacuum) this).spn_sideoffset.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignSideOffset;
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.ground_base.Text = buLangTranslate.preDef.Alignment;
      this.spn_magnetoffset.Caption.Caption = buLangTranslate.preDef.Offset;
      ((F_MarbleVacuum) this).spn_moveval.Caption.Caption = buLangTranslate.preDef.Distance;
      ((F_MarbleVacuum) this).spn_sideoffset.Caption.Caption = buLangTranslate.preDef.Offset;
      ((F_MarbleImageThicknessList) this).btn_magnet.Text = buLangTranslate.preDef.Magnet;
      ((F_MarbleImageThicknessList) this).btn_move.Text = buLangTranslate.preDef.Move;
      ((F_MarbleImageThicknessList) this).btn_side.Text = buLangTranslate.preDef.Side;
    }
    catch (Exception ex)
    {
    }
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
  }
}
