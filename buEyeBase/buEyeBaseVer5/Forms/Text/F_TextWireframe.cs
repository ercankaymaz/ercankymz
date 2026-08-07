// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Text.F_TextWireframe
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Simulation;
using buEyeBaseVer5.Forms.Viewport;
using buEyeBaseVer5.Forms.Vision;
using buEyeBaseVer5.Forms.Watch;
using dummy_ptr;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Text;

public class F_TextWireframe : Form
{
  internal ImageList \u0001;
  internal Button \u0002;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal ListView \u0001;
  internal Label \u0001;
  internal TextBox \u0001;
  internal Panel \u0002;
  internal Button \u0003;

  public F_TextWireframe()
  {
    ((F_WatchByGrid) this).Tag = "";
    // ISSUE: explicit constructor call
    ((DataTable) this).\u002Ector();
  }

  public abstract void m000B63();

  public F_TextWireframe()
  {
    ((F_WatchByGrid) this).ClassIndex = -1;
    ((F_WatchByGrid) this).ClassSubIndex = -1;
    // ISSUE: explicit constructor call
    ((TreeNode) this).\u002Ector();
  }

  public F_TextWireframe()
  {
    ((F_WatchByGrid) this).PropertiesForm = new FormProperties();
    ((F_WatchByGrid) this).SortSetting = (SortSettings) new ShapeRuntimeData();
    ((F_WatchByGrid) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SortingSettings) this);
  }

  public void Init()
  {
    ((F_WatchByGrid) this).PropertiesForm.Inited = false;
    if (((F_WatchByGrid) this).PropertiesForm.Height > 10)
      this.Height = ((F_WatchByGrid) this).PropertiesForm.Height;
    if (((F_WatchByGrid) this).PropertiesForm.Width > 10)
      this.Width = ((F_WatchByGrid) this).PropertiesForm.Width;
    this.TopMost = ((F_WatchByGrid) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_WatchByGrid) this).PropertiesForm.FormPosition;
    ((F_ViewportMouseCfg) this).\u0002.Items.Clear();
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[0]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[1]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[2]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[3]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[4]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[5]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[6]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[7]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[8]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[9]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[10]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[11]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[12]);
    ((F_ViewportMouseCfg) this).\u0002.Items.Add((object) buClassLanguage.SortingNextGroupFindRulesType[13]);
    ((F_ViewportMouseCfg) this).\u0002.SelectedIndex = Convert.ToInt32((object) ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).NextGroupRules);
    ((F_CameraLive) this).\u0001.Items.Clear();
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[0]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[1]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[2]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[3]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[4]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[5]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[6]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[7]);
    ((F_CameraLive) this).\u0001.Items.Add((object) buClassLanguage.SortingIntersectionRulesType[8]);
    ((F_CameraLive) this).\u0001.SelectedIndex = Convert.ToInt32((object) ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).IntersectionRules);
    ((F_CameraLive) this).\u0001.Checked = ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).isFirstPointCatchFromStartPointForDrawSequence;
    ((F_CameraLive) this).\u0001.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).Resolution;
    ((F_ViewportMouseCfg) this).\u0002.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).ConstantPoint.X;
    ((F_ViewportMouseCfg) this).\u0004.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).ConstantPoint.Y;
    ((F_ViewportMouseCfg) this).\u0003.Value = (Decimal) ((SortbuOptions) ((SortbuFilter) ((F_WatchByGrid) this).SortSetting).Option).ConstantPoint.Z;
    ((F_SimulationPanel) this).ControlUpdate();
    this.LoadLanguage();
    ((F_CameraLive) this).\u0001.Image = (Image) null;
    ((F_WatchByGrid) this).PropertiesForm.Result = DialogResult.None;
    ((F_WatchByGrid) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_WatchByGrid.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ViewportMouseCfg) this).btn_ok.Name)
    {
      ((F_SimulationPanel) this).Apply();
      ((F_WatchByGrid) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_WatchByGrid) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_WatchByGrid) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_CameraLive) this).btn_cancel.Name))
      return;
    ((F_WatchByGrid) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_WatchByGrid) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_WatchByGrid) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
