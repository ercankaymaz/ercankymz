// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Shape.F_CutList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Vision;
using buEyeBaseVer5.Forms.Watch;
using devDept.Eyeshot.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Shape;

public class F_CutList : Form
{
  public buButton btn_pause;
  public buButton btn_stop;
  internal buLabel \u0001;
  public static byte f001186;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public FoamSequenceHor Sequence;
  private IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Label \u0001;
  public NumericUpDown spn_len;
  public NumericUpDown spn_rad;
  internal Label \u0002;
  public NumericUpDown spn_angle;
  internal Label \u0003;
  public static byte f001195;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public Design viewportLayout;
  public bool ShowViewport;
  public bool ShowCamSettings;
  public bool ShowTool;
  public bool ShowObjectPosition;
  public bool ShowCornerLocation;
  public bool EnableTopPlane;
  public bool EnableBottomPlane;
  public bool EnableLeftPlane;
  public bool EnableRightPlane;
  public bool EnableFrontPlane;
  public bool EnableBacktPlane;
  public bool ClosePageAfterOk;
  public List<ToolBase5> Tools;
  public ToolBase5 activeTool;
  public buShape selectedShape;
  public camParameters5 CamPar;
  public ShapeRuntimeData parShape;
  private Timer \u0001;
  private int \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public Panel pnl_model;
  internal ImageList \u0001;
  internal ListView \u0001;
  internal ImageList \u0002;
  internal DataGridView \u0001;
  internal Panel \u0001;
  public Button btn_front;
  public Button btn_back;
  public Button btn_right;
  public Button btn_left;
  public Button btn_top;
  public Button btn_bottom;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      ((F_EngraveList) this).Items.Add(new WatchItem());
      DataGridViewRowCollection rows = ((F_EngraveList) this).DGV.Rows;
      int count = ((F_EngraveList) this).Items.Count;
      string str1 = "";
      string str2 = "";
      string str3 = "";
      string str4 = "Bool";
      string str5 = "";
      string str6 = "";
      string str7 = "";
      string str8 = "";
      object[] objArray = \u0007.\u0001.\u0001(str5, str7, (F_WatchByGrid) this, count, str2, str6, str4, str8, str1, str3);
      rows.Add(objArray);
      if (((F_EngraveList) this).DGV.Rows.Count > 0)
        ;
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_EngraveList) this).\u0001(((F_EngraveList) this).Items);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      string text = "Do You Want to Remove";
      if (AppLanguage.SystemMessages.Count >= 8)
        text = AppLanguage.SystemMessages[7];
      if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.No || !(((F_EngraveList) this).\u0001 >= 0 & ((F_EngraveList) this).\u0001 <= ((F_EngraveList) this).Items.Count - 1))
        return;
      ((F_EngraveList) this).DGV.Rows.RemoveAt(((F_EngraveList) this).\u0001);
      ((F_EngraveList) this).Items.RemoveAt(((F_EngraveList) this).\u0001);
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_EngraveList) this).\u0001(((F_EngraveList) this).Items);
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_EngraveList) this).\u0001(((F_EngraveList) this).\u0001);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      string text = "Do You Want to Remove All";
      if (AppLanguage.SystemMessages.Count >= 9)
        text = AppLanguage.SystemMessages[8];
      if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) == DialogResult.No)
        return;
      ((F_EngraveList) this).DGV.Rows.Clear();
      ((F_EngraveList) this).Items.Clear();
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_EngraveList) this).\u0001(((F_EngraveList) this).Items);
      }
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_EngraveList) this).\u0001();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (((F_EngraveList) this).\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_EngraveList) this).\u0001(((F_EngraveList) this).Items);
      for (int index = 0; index <= ((F_EngraveList) this).Items.Count - 1; ++index)
      {
        ((F_EngraveList) this).Items[index].NewValue = "";
        ((F_EngraveList) this).DGV.Rows[index].Cells[3].Value = (object) "";
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      ((F_EngraveList) this).\u0003.Visible = true;
      if (!(((F_EngraveList) this).\u0001 >= 0 & ((F_EngraveList) this).\u0001 <= ((F_EngraveList) this).DGV.Rows.Count - 1))
        return;
      ((F_EngraveList) this).DGV.Rows[((F_EngraveList) this).\u0001].Cells[1].Value = (object) ((F_EngraveList) this).AddString;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0008([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
      System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
      if (control2.Name == ((F_EngraveList) this).btn_closecross.Name | control2.Name == ((F_EngraveList) this).btn_cancel.Name)
        this.Visible = false;
      if (control2.Name == ((F_EngraveList) this).btn_minimize.Name)
        this.WindowState = FormWindowState.Minimized;
      if (!(control2.Name == ((F_EngraveList) this).btn_maximize.Name))
        return;
      if (this.WindowState == FormWindowState.Maximized)
        this.WindowState = FormWindowState.Normal;
      else
        this.WindowState = FormWindowState.Maximized;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (((F_EngraveList) this).\u0002 != 4)
      return;
    ((F_EngraveList) this).\u0002.Visible = true;
    this.SetVarType(((F_EngraveList) this).Items[((F_EngraveList) this).\u0001].VarType);
  }

  internal void \u000E([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_EngraveList) this).\u0001 >= 0 & ((F_EngraveList) this).\u0001 <= ((F_EngraveList) this).Items.Count - 1))
      return;
    ((F_EngraveList) this).Items[((F_EngraveList) this).\u0001].VarType = this.GetVarType();
    ((F_EngraveList) this).Items[((F_EngraveList) this).\u0001].MinValue = 0.0;
    ((F_EngraveList) this).Items[((F_EngraveList) this).\u0001].MaxValue = 0.0;
    ((F_EngraveList) this).DGV.Rows[((F_EngraveList) this).\u0001].Cells[4].Value = (object) ((F_EngraveList) this).Items[((F_EngraveList) this).\u0001].VarType.ToString();
    // ISSUE: reference to a compiler-generated field
    if (((F_EngraveList) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_EngraveList) this).\u0001(((F_EngraveList) this).Items);
    }
    ((F_EngraveList) this).\u0002.Visible = false;
  }

  public void SetVarType(VariableType Var)
  {
    if (Var == VariableType.Bool)
      ((F_EngraveList) this).\u0003.Checked = true;
    if (Var == VariableType.DINT)
      ((F_EngraveList) this).\u0004.Checked = true;
    if (Var == VariableType.INT)
      ((F_EngraveList) this).\u0005.Checked = true;
    if (Var == VariableType.REAL)
      ((F_EngraveList) this).\u0002.Checked = true;
    if (Var != VariableType.LREAL)
      return;
    ((F_EngraveList) this).\u0001.Checked = true;
  }

  public VariableType GetVarType()
  {
    return !((F_EngraveList) this).\u0004.Checked ? (!((F_EngraveList) this).\u0005.Checked ? (!((F_EngraveList) this).\u0002.Checked ? (!((F_EngraveList) this).\u0001.Checked ? (!((F_EngraveList) this).\u0003.Checked ? VariableType.Bool : VariableType.Bool) : VariableType.LREAL) : VariableType.REAL) : VariableType.INT) : VariableType.DINT;
  }

  internal void \u000F([In] object obj0, [In] EventArgs obj1)
  {
    ((F_EngraveList) this).\u0003.Visible = false;
  }

  internal void \u0010([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_EngraveList) this).\u0001 >= 0 & ((F_EngraveList) this).\u0001 <= ((F_EngraveList) this).Items.Count - 1))
      return;
    ((F_EngraveList) this).DGV.Rows[((F_EngraveList) this).\u0001].Cells[1].Value = (object) ((F_EngraveList) this).btnN_stringglobal.Text.Trim();
    ((F_EngraveList) this).\u0003.Visible = false;
  }

  internal void \u0011([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_EngraveList) this).\u0001 >= 0 & ((F_EngraveList) this).\u0001 <= ((F_EngraveList) this).Items.Count - 1))
      return;
    ((F_EngraveList) this).DGV.Rows[((F_EngraveList) this).\u0001].Cells[1].Value = (object) ((F_EngraveList) this).btn_stringpersist.Text.Trim();
    ((F_EngraveList) this).\u0003.Visible = false;
  }

  internal void \u0012([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_EngraveList) this).\u0001 >= 0 & ((F_EngraveList) this).\u0001 <= ((F_EngraveList) this).Items.Count - 1))
      return;
    ((F_EngraveList) this).DGV.Rows[((F_EngraveList) this).\u0001].Cells[1].Value = (object) ((F_EngraveList) this).btn_stringIO.Text.Trim();
    ((F_EngraveList) this).\u0003.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellCancelEventArgs obj1)
  {
    ((F_EngraveList) this).Editing = true;
  }

  internal void \u0004([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_EngraveList) this).Editing = false;
  }

  internal void \u0005([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_EngraveList) this).Editing = false;
  }

  internal void \u0013([In] object obj0, [In] EventArgs obj1)
  {
    ((F_EngraveList) this).\u0002.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_EngraveList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_EngraveList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_CutList() => F_EngraveList.Captions = new List<string>();

  public F_CutList()
  {
    ((F_EngraveList) this).PropertiesForm = new FormProperties();
    ((F_EngraveList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_CameraLive) this);
  }

  public void Init()
  {
    ((F_EngraveList) this).PropertiesForm.Inited = false;
    if (((F_EngraveList) this).PropertiesForm.Height > 10)
      this.Height = ((F_EngraveList) this).PropertiesForm.Height;
    if (((F_EngraveList) this).PropertiesForm.Width > 10)
      this.Width = ((F_EngraveList) this).PropertiesForm.Width;
    this.TopMost = ((F_EngraveList) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_EngraveList) this).PropertiesForm.FormPosition;
    ((F_ShapeAll) this).LoadLanguage();
    ((F_EngraveList) this).PropertiesForm.Result = DialogResult.None;
    ((F_EngraveList) this).PropertiesForm.Inited = true;
  }

  public event OkCommandWithTwoDataEventHandler DataOk;

  public event CancelCommandEventHandler DataCancel;
}
