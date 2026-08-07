// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Vision.F_CameraLive
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Forms.Watch;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Vision;

public class F_CameraLive : Form
{
  internal CheckBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal ComboBox \u0001;
  internal Label \u0003;
  internal CheckBox \u0002;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;

  [CompilerGenerated]
  [SpecialName]
  public void add_ApplyClick(F_SettingTreeView.ApplyClickEvent value)
  {
    // ISSUE: reference to a compiler-generated field
    F_SettingTreeView.ApplyClickEvent applyClickEvent = ((F_WatchByGrid) this).\u0001;
    F_SettingTreeView.ApplyClickEvent comparand;
    do
    {
      comparand = applyClickEvent;
      // ISSUE: reference to a compiler-generated field
      applyClickEvent = Interlocked.CompareExchange<F_SettingTreeView.ApplyClickEvent>(ref ((F_WatchByGrid) this).\u0001, comparand + value, comparand);
    }
    while (applyClickEvent != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ApplyClick(F_SettingTreeView.ApplyClickEvent value)
  {
    // ISSUE: reference to a compiler-generated field
    F_SettingTreeView.ApplyClickEvent applyClickEvent = ((F_WatchByGrid) this).\u0001;
    F_SettingTreeView.ApplyClickEvent comparand;
    do
    {
      comparand = applyClickEvent;
      // ISSUE: reference to a compiler-generated field
      applyClickEvent = Interlocked.CompareExchange<F_SettingTreeView.ApplyClickEvent>(ref ((F_WatchByGrid) this).\u0001, comparand - value, comparand);
    }
    while (applyClickEvent != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DefaultClick(F_SettingTreeView.DefaultClickEvent value)
  {
    // ISSUE: reference to a compiler-generated field
    F_SettingTreeView.DefaultClickEvent defaultClickEvent = ((F_WatchByGrid) this).\u0001;
    F_SettingTreeView.DefaultClickEvent comparand;
    do
    {
      comparand = defaultClickEvent;
      // ISSUE: reference to a compiler-generated field
      defaultClickEvent = Interlocked.CompareExchange<F_SettingTreeView.DefaultClickEvent>(ref ((F_WatchByGrid) this).\u0001, comparand + value, comparand);
    }
    while (defaultClickEvent != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DefaultClick(F_SettingTreeView.DefaultClickEvent value)
  {
    // ISSUE: reference to a compiler-generated field
    F_SettingTreeView.DefaultClickEvent defaultClickEvent = ((F_WatchByGrid) this).\u0001;
    F_SettingTreeView.DefaultClickEvent comparand;
    do
    {
      comparand = defaultClickEvent;
      // ISSUE: reference to a compiler-generated field
      defaultClickEvent = Interlocked.CompareExchange<F_SettingTreeView.DefaultClickEvent>(ref ((F_WatchByGrid) this).\u0001, comparand - value, comparand);
    }
    while (defaultClickEvent != comparand);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_WatchByGrid) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_WatchByGrid) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CameraLive() => F_WatchByGrid.Captions = new List<string>();
}
