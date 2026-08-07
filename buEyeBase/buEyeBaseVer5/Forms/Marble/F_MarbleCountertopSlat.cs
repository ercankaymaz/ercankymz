// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCountertopSlat
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCountertopSlat : Form
{
  public buButton btn_cancel;
  internal buLabel \u0001;
  internal RadioButton \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  internal RadioButton \u0002;
  public static byte f001C5E;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_offset;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;
  public static byte f001C69;
  private string \u0001;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_extend;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;
  public static byte f001C74;
  private string \u0001 = "F_MarbleEventVacuum";
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_move_right;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleCountertopSlat() => \u0007.\u0001.\u0001((F_MarbleEventVacuum) this);

  [CompilerGenerated]
  [SpecialName]
  public void add_VacuumCommand(OkCommandWithFiveDataEventHandler value)
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
  public void remove_VacuumCommand(OkCommandWithFiveDataEventHandler value)
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
    ((F_MarbleEdgeAngleList) this).spn_moveval.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignMoveValue;
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.ground_base.Text = buLangTranslate.preDef.Vacuum;
      ((F_MarbleEdgeAngleList) this).spn_moveval.Caption.Caption = buLangTranslate.preDef.Distance;
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
