// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_PlaneSettings
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

public class F_PlaneSettings : Form
{
  internal Panel \u0001;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal PictureBox \u0003;
  internal Label \u0001;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Label \u0002;
  public NumericUpDown spn_vellfeed;
  internal Label \u0003;
  public NumericUpDown spn_velplunge;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  public NumericUpDown spn_dissafe;
  internal Panel \u0003;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Panel \u0004;
  internal RadioButton \u0005;

  static F_PlaneSettings() => F_Settnigs.Captions = new List<string>();

  public F_PlaneSettings()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).StitchCount = 0;
    ((F_Settnigs) this).ExtendType = SewingAddStitchType.OneWay;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingExtend) this);
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
    ((F_Settnigs) this).\u0001.Value = (Decimal) ((F_Settnigs) this).StitchCount;
    if (((F_Settnigs) this).ExtendType == SewingAddStitchType.OneWay)
      ((F_Settnigs) this).\u0001.Checked = true;
    else if (((F_Settnigs) this).ExtendType == SewingAddStitchType.TwoWay)
      ((F_Settnigs) this).\u0002.Checked = true;
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
}
