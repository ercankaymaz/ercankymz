// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_TuftingSetProps
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_TuftingSetProps : Form
{
  internal NumericUpDown \u0002;
  internal Label \u000F;
  internal NumericUpDown \u0003;
  internal Label \u0010;
  public static byte f001016;
  private IContainer \u0001;
  public Design viewport_preview;
  public FormProperties PropertiesForm;
  public QuiltingRuntimeSettings Setting;
  public static List<string> Captions;
  internal IContainer \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal Label \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  public static byte f001025;

  public void LoadLanguage()
  {
    string callMethod = "NestSheetPart LoadLanguage";
    try
    {
      if (F_TuftingExchange.Captions.Count < 33)
        return;
      this.Text = F_TuftingExchange.Captions[0];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
    {
      control = (System.Windows.Forms.Control) obj0;
      string name = control.Name;
    }
    if (obj0.GetType() == typeof (ToolStripMenuItem))
    {
      string name1 = ((ToolStripItem) obj0).Name;
    }
    if (control.Name == ((F_TuftingExchange) this).\u0001.Name)
    {
      this.Apply();
      ((F_TuftingExchange) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_TuftingExchange) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_TuftingExchange) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_TuftingExchange) this).\u0002.Name)
    {
      ((F_TuftingExchange) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_TuftingExchange) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_TuftingExchange) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control.Name == ((F_TuftingExchange) this).btn_open.Name))
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = ((F_TuftingExchange) this).pathPost;
    openFileDialog.Filter = "Kinematic File (*.bupost)|*.bupost";
    openFileDialog.Multiselect = false;
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    ((F_TuftingExchange) this).pathPost = buFile5.bunesting.GetPath(openFileDialog.FileName);
    ((F_TuftingExchange) this).ExistingPostName = buFile5.bunesting.getFileName(openFileDialog.FileName);
    this.\u0001((object) ((F_TuftingExchange) this).\u0001, obj1);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_TuftingExchange) this).PropertiesForm.Inited || ((F_TuftingExchange) this).\u0001.SelectedIndex < 0)
      return;
    ((F_TuftingExchange) this).\u0001 = ((F_TuftingExchange) this).\u0001.SelectedIndex;
    ((F_TuftingExchange) this).ExistingPostName = ((F_TuftingExchange) this).\u0001.Items[((F_TuftingExchange) this).\u0001].ToString();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TuftingExchange) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TuftingExchange) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_TuftingSetProps() => F_TuftingExchange.Captions = new List<string>();

  public F_TuftingSetProps()
  {
    ((F_TuftingExchange) this).View = viewType.Top;
    ((F_TuftingExchange) this).ZoomFit = true;
    ((F_TuftingExchange) this).ZoomAnimation = false;
    ((F_TuftingExchange) this).fileNameTexture = Application.StartupPath;
    ((F_TuftingExchange) this).previewEntities = new List<Entity>();
    ((F_TuftingExchange) this).\u0001 = new Timer();
    ((F_TuftingExchange) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Preview) this);
    if (((F_TuftingExchange) this).viewportLayout == null)
      ((F_TuftingExchange) this).viewportLayout = new Design();
    ((F_TuftingExchange) this).\u0001.Interval = 20;
    ((F_TuftingExchange) this).\u0001.Tick += new EventHandler(((F_TuftingSort) this).\u0001);
  }

  public void Init()
  {
  }

  public void Init(viewType view, bool zoomFit, bool zoomAnimation)
  {
    ((F_TuftingExchange) this).ZoomFit = zoomFit;
    ((F_TuftingExchange) this).View = view;
    ((F_TuftingExchange) this).ZoomAnimation = zoomAnimation;
    ((F_TuftingExchange) this).\u0001.Enabled = true;
  }
}
