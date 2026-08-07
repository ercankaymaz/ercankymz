// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Diamaker.F_DiamakerGrindVShape
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Door;
using buEyeBaseVer5.Forms.Events;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Foam;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Diamaker;

public class F_DiamakerGrindVShape : Form
{
  internal Label \u000E;
  public Label label6;
  public Label label7;
  public Panel pnl_controlsslice;
  public static byte f003168;
  public FormProperties PropertiesForm;
  public SizeObject FoamSize;
  public bool ValueChanging;
  internal IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal Button \u0003;
  internal ImageList \u0003;
  internal Button \u0004;
  public NumericUpDown spn_blockvercount;
  public NumericUpDown spn_blockhorcount;
  public NumericUpDown spn_blocktotalwidth;
  public NumericUpDown spn_blocktotalheight;
  public NumericUpDown spn_blockwidthstartoffset;
  public NumericUpDown spn_blockwidthendoffset;
  public NumericUpDown spn_blockheightendoffset;
  public NumericUpDown spn_blockheightstartoffset;
  public NumericUpDown spn_waveheight;
  public NumericUpDown spn_wavewidth;
  public Label label9;
  public NumericUpDown spn_wavebaseheight;
  internal Panel \u0001;
  public NumericUpDown spn_totalpart;
  public Label label23;
  internal Label \u0001;
  internal Label \u0002;
  public Label label16;
  public Label label19;
  internal Panel \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  public Label label24;
  public Label label25;
  public Label label26;
  internal TextBox \u0001;
  internal Label \u0006;
  internal Button \u0005;
  public Label label18;
  public Label label17;
  internal Label \u0007;
  internal Panel \u0003;
  public NumericUpDown spn_connectionvel;
  public Label label1;
  public NumericUpDown spn_leadoutvel;
  public Label label2;
  public NumericUpDown spn_leadinvel;
  public Label label3;
  public Label label4;
  public NumericUpDown spn_cutvel;
  internal Label \u0008;
  public Label label6;
  public Label label7;
  public Label label8;
  public NumericUpDown spn_repeatcount;
  internal Panel \u0004;
  internal Label \u000E;
  public ListBox lst_idealheight;
  public ListBox lst_idealwidth;
  internal Label \u000F;
  public Label label13;
  internal Panel \u0005;
  public TextBox txt_info;
  internal Label \u0010;
  public Label label14;
  public NumericUpDown spn_round;
  public NumericUpDown spn_chamfer;
  public Label label29;
  public Panel pnl_controlswave;
  public Panel panel4;
  public Label label30;
  public NumericUpDown spn_space;
  public static byte f0031B6;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public FoamSequenceHor SequenceHor;
  public FoamSequenceVer SequenceVer;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal PictureBox \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal PictureBox \u0002;
  internal Label \u0001;
  internal Panel \u0001;
  internal Panel \u0002;
  internal Label \u0002;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_EventAll) this).btn_ok.Name)
    {
      ((F_DoorMat) this).Apply();
      ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else if (control2.Name == ((F_AddFromFile) this).btn_cancel.Name)
    {
      ((F_AddFromFile) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_AddFromFile) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else if (control2.Name == ((F_EventAll) this).btn_add.Name)
    {
      if (!(((F_EventAll) this).\u0001.Value > 0M & ((F_EventAll) this).\u0002.Value > 0M))
        return;
      ((F_AddFromFile) this).SliceList.Add(new LengthCount((double) ((F_EventAll) this).\u0001.Value, (int) ((F_EventAll) this).\u0002.Value));
      ((F_EventAll) this).DGV_table.Rows.Add(\u0007.\u0001.\u0001((double) ((F_EventAll) this).\u0001.Value, (int) ((F_EventAll) this).\u0002.Value, (F_FoamSlicesList) this));
    }
    else
    {
      if (!(control2.Name == ((F_EventAll) this).btn_remove.Name) || !(((F_AddFromFile) this).\u0001 >= 0 & ((F_AddFromFile) this).\u0001 <= ((F_AddFromFile) this).SliceList.Count - 1))
        return;
      ((F_AddFromFile) this).SliceList.RemoveAt(((F_AddFromFile) this).\u0001);
      ((F_EventAll) this).DGV_table.Rows.RemoveAt(((F_AddFromFile) this).\u0001);
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_AddFromFile) this).\u0001 = obj1.RowIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_AddFromFile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_AddFromFile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_DiamakerGrindVShape() => F_AddFromFile.Captions = new List<string>();

  public F_DiamakerGrindVShape()
  {
    ((F_EventAll) this).PropertiesForm = new FormProperties();
    ((F_EventAll) this).foamType = FoamType.SlicesVertical;
    ((F_EventAll) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_FoamWaveMenu) this);
  }

  public void Init()
  {
    ((F_EventAll) this).PropertiesForm.Inited = false;
    if (((F_EventAll) this).PropertiesForm.Height > 10)
      this.Height = ((F_EventAll) this).PropertiesForm.Height;
    if (((F_EventAll) this).PropertiesForm.Width > 10)
      this.Width = ((F_EventAll) this).PropertiesForm.Width;
    this.TopMost = ((F_EventAll) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_EventAll) this).PropertiesForm.FormPosition;
    this.ControlUpdate();
    this.LoadLanguage();
    ((F_EventAll) this).PropertiesForm.Result = DialogResult.None;
    ((F_EventAll) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_EventAll.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  public void ControlUpdate()
  {
  }
}
