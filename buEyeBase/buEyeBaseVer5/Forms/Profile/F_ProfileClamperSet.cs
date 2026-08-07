// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileClamperSet
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Sewing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileClamperSet : Form
{
  public List<SelectedPlaneInfo> selectedPlanes;
  private Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal ImageList \u0003;
  internal ImageList \u0004;

  static F_ProfileClamperSet() => F_Settnigs.Captions = new List<string>();

  public F_ProfileClamperSet()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).ActualCommands = new List<string>();
    ((F_Settnigs) this).AllCommands = new List<string>();
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingSetProperties) this);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      this.Height = ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      this.Width = ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    ((F_Settnigs) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_Settnigs) this).ActualCommands.Count - 1; ++index)
      ((F_Settnigs) this).\u0001.Items.Add((object) ((F_Settnigs) this).ActualCommands[index]);
    ((F_Settnigs) this).\u0002.Items.Clear();
    for (int index = 0; index <= ((F_Settnigs) this).AllCommands.Count - 1; ++index)
      ((F_Settnigs) this).\u0002.Items.Add((object) ((F_Settnigs) this).AllCommands[index]);
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_Settnigs.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Settnigs) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
    if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Settnigs) this).btn_ok.Name)
    {
      if (!((F_Settnigs) this).Properties.Inited)
        return;
      if (((F_Settnigs) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_SewingSetProperties) this);
      ((F_Settnigs) this).Properties.Result = DialogResult.OK;
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_Settnigs) this).btn_cancel.Name)
    {
      ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_Settnigs) this).\u0001.Name && ((F_Settnigs) this).\u0002.SelectedIndex >= 0)
      ((F_Settnigs) this).\u0001.Items.Add((object) ((F_Settnigs) this).\u0002.Items[((F_Settnigs) this).\u0002.SelectedIndex].ToString());
    if (!(control2.Name == ((F_Settnigs) this).\u0002.Name) || ((F_Settnigs) this).\u0001.SelectedIndex < 0)
      return;
    ((F_Settnigs) this).\u0001.Items.RemoveAt(((F_Settnigs) this).\u0001.SelectedIndex);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Settnigs) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Settnigs) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
