// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMParalelCutLink
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMParalelCutLink : Form
{
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal Button \u0001;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal RadioButton \u0002;
  public ComboBox comboBox1;
  internal Button \u0002;
  public ComboBox comboBox4;
  public ComboBox comboBox3;
  public ComboBox comboBox2;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0002;
  public ComboBox comboBox7;
  public ComboBox comboBox8;
  internal Button \u0003;
  public ComboBox comboBox5;
  public ComboBox comboBox6;
  internal Button \u0004;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0003;
  public ComboBox comboBox9;
  internal RadioButton \u0003;
  public ComboBox comboBox10;
  internal RadioButton \u0004;
  internal Button \u0005;
  internal NumericUpDown \u0004;
  public ComboBox comboBox11;
  public ComboBox comboBox12;
  internal Button \u0006;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u0011;
  public ComboBox comboBox13;
  public ComboBox comboBox14;
  internal Button \u0007;
  internal NumericUpDown \u0005;
  public ComboBox comboBox15;
  public ComboBox comboBox16;
  internal Button \u0008;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal System.Windows.Forms.Label \u0014;
  internal Button \u000E;
  internal Button \u000F;
  internal System.Windows.Forms.Label \u0015;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRoughLink) this).Properties.Inited)
      return;
    ((F_MwTriMRoughLink) this).Properties.Inited = false;
    ((F_MwTriMRoughLink) this).Apply();
    ((F_MwTriMRoughLink) this).UpdateControlFromType();
    ((F_MwTriMRoughLink) this).Properties.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    F_MwTriMRetract fMwTriMretract = new F_MwTriMRetract();
    fMwTriMretract.Par = new MachiningParams(((F_MwTriMRoughLink) this).Par);
    fMwTriMretract.Init();
    int num = (int) fMwTriMretract.ShowDialog();
    if (fMwTriMretract.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMRoughLink) this).Par = new MachiningParams(fMwTriMretract.Par);
    fMwTriMretract.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRoughLink) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRoughLink) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMParalelCutLink() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  public void UpdateControlFromType()
  {
  }
}
