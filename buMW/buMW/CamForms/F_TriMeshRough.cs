// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_TriMeshRough
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
using buMW.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_TriMeshRough : Form
{
  internal System.Windows.Forms.Label \u008F;
  internal Button \u0015;
  internal Panel \u0016;
  internal Button \u0016;
  internal Button \u0017;
  internal CheckBox \u0016;
  internal System.Windows.Forms.Label \u0090;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal ComboBox \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal Panel \u0001;
  internal ComboBox \u0002;
  internal System.Windows.Forms.Label \u0005;
  internal Panel \u0002;
  internal Button \u0001;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0003;
  internal Button \u0002;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0007;
  internal ComboBox \u0003;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0011;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal Panel \u0006;
  internal Button \u0003;
  internal System.Windows.Forms.Label \u0014;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal System.Windows.Forms.Label \u0017;
  internal NumericUpDown \u000E;
  internal System.Windows.Forms.Label \u0018;
  internal NumericUpDown \u000F;
  internal NumericUpDown \u0010;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal CheckBox \u0002;
  internal Panel \u0007;
  internal System.Windows.Forms.Label \u0019;
  internal CheckBox \u0003;
  internal Panel \u0008;
  internal System.Windows.Forms.Label \u001A;
  public ComboBox cmb_exitramptype;
  internal System.Windows.Forms.Label \u001B;
  internal Button \u0004;
  internal System.Windows.Forms.Label \u001C;
  public ComboBox cmb_entryramptype;
  internal Panel \u000E;
  internal CheckBox \u0004;
  internal System.Windows.Forms.Label \u001D;
  internal Panel \u000F;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u001E;
  internal Panel \u0010;
  internal System.Windows.Forms.Label \u001F;
  internal System.Windows.Forms.Label \u007F;
  internal NumericUpDown \u0011;
  internal Panel \u0011;
  internal Button \u0005;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u0080;
  internal NumericUpDown \u0012;
  internal Panel \u0012;
  internal Button \u0006;
  internal Button \u0007;
  internal System.Windows.Forms.Label \u0081;
  internal NumericUpDown \u0013;
  internal System.Windows.Forms.Label \u0082;
  internal NumericUpDown \u0014;
  internal System.Windows.Forms.Label \u0083;
  internal NumericUpDown \u0015;
  internal CheckBox \u0007;
  internal Panel \u0013;
  internal System.Windows.Forms.Label \u0084;
  internal System.Windows.Forms.Label \u0086;
  internal System.Windows.Forms.Label \u0087;
  internal ComboBox \u0004;
  internal CheckBox \u0008;
  internal System.Windows.Forms.Label \u0088;
  internal NumericUpDown \u0016;
  internal CheckBox \u000E;
  internal CheckBox \u000F;
  internal Panel \u0014;
  internal System.Windows.Forms.Label \u0089;
  internal System.Windows.Forms.Label \u008A;
  internal NumericUpDown \u0017;
  internal CheckBox \u0010;
  internal Button \u0008;
  internal NumericUpDown \u0018;
  internal System.Windows.Forms.Label \u008B;
  internal System.Windows.Forms.Label \u008C;
  internal NumericUpDown \u0019;
  internal Button \u000E;
  internal NumericUpDown \u001A;
  internal System.Windows.Forms.Label \u008D;
  internal NumericUpDown \u001B;
  internal System.Windows.Forms.Label \u008E;
  internal NumericUpDown \u001C;
  internal System.Windows.Forms.Label \u008F;
  internal System.Windows.Forms.Label \u0090;
  internal ComboBox \u0005;
  internal Button \u000F;
  internal Button \u0010;
  internal Button \u0011;
  internal Button \u0012;
  internal Panel \u0015;
  internal Button \u0013;
  internal System.Windows.Forms.Label \u0091;
  internal Panel \u0016;
  internal Button \u0014;

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_TriMeshParallelCut) this).\u0015.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.Offset;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0001.Name)
    {
      if (((F_TriMeshParallelCut) this).\u0001.SelectedIndex == 0)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SortOneway;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).\u0001.SelectedIndex == 1)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SortZigzag;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).\u0001.SelectedIndex != 2)
        ;
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0002.Name)
    {
      if (((F_TriMeshParallelCut) this).\u0002.SelectedIndex == 0 || ((F_TriMeshParallelCut) this).\u0002.SelectedIndex != 1)
        ;
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0004.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.CutTolerance;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0001.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.FeedRate;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0002.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.PlungeRate;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0003.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.RetractRate;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u000F.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0001.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.RapidRetract;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0003.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u000E.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0008.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0007.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.EntryFeedDistance;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0006.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.AirSafeDistance;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0005.Name)
    {
      if (((F_TriMeshParallelCut) this).\u0001.Checked)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
      else
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0001.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0002.Name)
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u000E.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LeadIn;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshParallelCut) this).\u0008.Name)
    {
      ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LeadOut;
      if (((F_TriMeshParallelCut) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    if (control2.Name == ((F_TriMeshParallelCut) this).cmb_leadintype.Name)
    {
      if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 0)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 1)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 2)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 3)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 4)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 5)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 6)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 7)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 8)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 9)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 10)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 11)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 12)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_TriMeshParallelCut) this).cmb_leadintype.SelectedIndex == 13)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    if (control2.Name == ((F_TriMeshParallelCut) this).cmb_leadouttype.Name)
    {
      if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 0)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 1)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 2)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 3)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 4)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 5)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 6)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 7)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 8)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 9)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 10)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 11)
      {
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_TriMeshParallelCut) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 12)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_TriMeshParallelCut) this).cmb_leadouttype.SelectedIndex == 13)
        ((F_TriMeshParallelCut) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    ((F_TriMeshParallelCut) this).\u0002.Checked = false;
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    ((F_TriMeshParallelCut) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TriMeshParallelCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TriMeshParallelCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_TriMeshRough() => F_TriMeshParallelCut.Captions = new List<string>();

  public F_TriMeshRough() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.\u0002.Visible = this.PropertiesForm.ShowHelp;
    this.\u0018.Value = (Decimal) this.mwCamParameter.MachParam.ParallelMachAngleInYX;
    this.\u001A.Value = (Decimal) this.mwCamParameter.MachParam.RadialOffset;
    this.\u001B.Value = (Decimal) this.mwCamParameter.MachParam.AxialOffset;
    this.\u001C.Value = (Decimal) this.mwCamParameter.MachParam.StockRemain;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.CutTolerance;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedRate;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.PlungeFeedRate;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.RetractFeedRate;
    this.\u0016.Value = (Decimal) this.mwCamParameter.MachParam.MinFeedRateAsFeedRatePercentage;
    this.\u000E.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    this.\u000F.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.RetractPlaneIncremental;
    this.\u0010.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ClearancePlaneHeight;
    this.\u0008.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AirMoveSafetyDistance;
    this.\u0007.Value = (Decimal) this.buCamParameter.Speeds.SpindleSpeed;
    this.\u0017.Value = (Decimal) this.mwCamParameter.MachParam.MaxStepoverDistance;
    if (this.Tool != null)
      this.\u0019.Value = (Decimal) (this.mwCamParameter.MachParam.MaxStepoverDistance / this.Tool.Geometry.Diameter * 100.0);
    this.\u0008.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ReverseCuttingOrderFlg;
    this.\u0001.Checked = this.mwCamParameter.MachParam.RapidRetractFlg;
    this.\u0007.Checked = this.mwCamParameter.MachParam.RapidFeedFlg;
    this.\u000F.Checked = this.mwCamParameter.MachParam.RapidApproachFlg;
    this.\u000E.Checked = this.mwCamParameter.MachParam.AdaptiveFeedRateFlg;
    this.\u0001.Items.Clear();
    this.\u0001.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType[0]);
    this.\u0001.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType[1]);
    this.\u0001.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType[2]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
      this.\u0001.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
      this.\u0001.SelectedIndex = 1;
    else
      this.\u0001.SelectedIndex = 2;
    this.\u0005.Items.Clear();
    this.\u0005.Items.Add((object) buMWCaptions.MachiningParamsStockRemainType[0]);
    this.\u0005.Items.Add((object) buMWCaptions.MachiningParamsStockRemainType[1]);
    if (this.mwCamParameter.MachParam.StockRemainType == MachiningParamsStockRemainType.SrtGlobal)
      this.\u0005.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.StockRemainType == MachiningParamsStockRemainType.SrtRadialAndAxial)
      this.\u0005.SelectedIndex = 1;
    this.\u0004.Items.Clear();
    this.\u0004.Items.Add((object) buMWCaptions.MachiningParamsDirection[2]);
    this.\u0004.Items.Add((object) buMWCaptions.MachiningParamsDirection[3]);
    if (this.mwCamParameter.MachParam.MachDirForOneWay == MachiningParamsDirection.DirClimb)
      this.\u0004.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.MachDirForOneWay == MachiningParamsDirection.DirConventional)
      this.\u0004.SelectedIndex = 1;
    this.\u0002.Items.Clear();
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsMachType[0]);
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsMachType[1]);
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsMachType[2]);
    if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0002.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0002.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeSpiral)
      this.\u0002.SelectedIndex = 2;
    this.\u0003.Items.Clear();
    this.\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[0]);
    this.\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[1]);
    if (this.mwCamParameter.MachParam.MachiningAreaMode == MachiningParamsMachiningAreaMode.MachByLanes)
      this.\u0003.SelectedIndex = 0;
    else
      this.\u0003.SelectedIndex = 1;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
    {
      this.\u0002.Checked = true;
      this.\u0001.Checked = false;
    }
    else
    {
      this.\u0002.Checked = false;
      this.\u0001.Checked = true;
    }
    if (this.buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
    {
      this.\u0004.Checked = true;
      this.\u0003.Checked = false;
    }
    else
    {
      this.\u0004.Checked = false;
      this.\u0003.Checked = true;
    }
    this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
    this.cmb_entryramptype.Items.Clear();
    this.cmb_entryramptype.Items.Add((object) buMWCaptions.FirstEntryType[0]);
    this.cmb_entryramptype.Items.Add((object) buMWCaptions.FirstEntryType[1]);
    this.cmb_entryramptype.Items.Add((object) buMWCaptions.FirstEntryType[2]);
    if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.FromRapidPlane)
      this.cmb_entryramptype.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseRapidDistance)
      this.cmb_entryramptype.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseFeedDistance)
      this.cmb_entryramptype.SelectedIndex = 2;
    this.cmb_exitramptype.Items.Clear();
    this.cmb_exitramptype.Items.Add((object) buMWCaptions.LastExitType[0]);
    this.cmb_exitramptype.Items.Add((object) buMWCaptions.LastExitType[1]);
    this.cmb_exitramptype.Items.Add((object) buMWCaptions.LastExitType[2]);
    if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.BackToRapidPlane)
      this.cmb_exitramptype.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseRapidDistance)
      this.cmb_exitramptype.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseFeedDistance)
      this.cmb_exitramptype.SelectedIndex = 2;
    this.\u0011.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DraftAngle;
    this.\u0010.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ClosedOffsetFlg;
    this.\u0005.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurvesFlg;
    this.\u0004.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RestRoughFlg;
    this.\u0006.Checked = this.mwCamParameter.MachParam.Containment2dParams.IsUsedFlg;
    ((F_RoughLink) this).\u0012.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FinalContourPassFlg;
    ((F_RoughLink) this).\u0011.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0001.Image = (Image) ResourceImage.RoughtOffset;
    this.Configration.Mode = CamMode.TriangularMesh;
    this.Configration.CamTriMeshType = CamTriangularMeshType.Rough;
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    F_MwTriMUpDownAdvanced.\u0001(this);
    this.ControlUpdate();
  }

  public void ControlUpdate()
  {
    this.\u0018.Enabled = false;
    this.\u008B.Enabled = false;
    if (this.\u0001.SelectedIndex == 1)
    {
      this.\u0018.Enabled = true;
      this.\u008B.Enabled = true;
    }
    this.\u001C.Enabled = false;
    this.\u008F.Enabled = false;
    this.\u001B.Enabled = false;
    this.\u008E.Enabled = false;
    this.\u001A.Enabled = false;
    this.\u008D.Enabled = false;
    if (this.\u0005.SelectedIndex == 0)
    {
      this.\u001C.Enabled = true;
      this.\u008F.Enabled = true;
    }
    else
    {
      this.\u001B.Enabled = true;
      this.\u008E.Enabled = true;
      this.\u001A.Enabled = true;
      this.\u008D.Enabled = true;
    }
    if (this.\u0002.Checked)
    {
      this.\u0006.Enabled = true;
      this.\u0005.Enabled = false;
    }
    else
    {
      this.\u0006.Enabled = false;
      this.\u0005.Enabled = true;
    }
    this.\u0015.Enabled = this.\u0007.Checked;
    this.\u0016.Enabled = this.\u000E.Checked;
    this.cmb_entryramptype.Enabled = this.\u0003.Checked;
    this.\u0012.Enabled = this.\u0004.Checked;
    this.\u0010.Enabled = this.\u0006.Checked;
    this.\u0005.Enabled = this.\u0006.Checked;
    ((F_RoughLink) this).\u0015.Enabled = ((F_RoughLink) this).\u0012.Checked;
    this.\u0014.Enabled = ((F_RoughLink) this).\u0011.Checked;
    this.\u0008.Enabled = this.\u0005.Checked;
    this.\u0011.Enabled = this.\u0005.Checked;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.PropertiesForm.Inited)
        return;
      if (this.PropertiesForm.ReadOnly)
      {
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
        return;
      }
      \u0005.\u0002.\u0001(this);
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.\u0002.Name)
    {
      F_DepthStepAdvanced depthStepAdvanced = new F_DepthStepAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      depthStepAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      depthStepAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      depthStepAdvanced.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        depthStepAdvanced.Tool = new ToolBase5(depthStepAdvanced.Tool);
      depthStepAdvanced.Init();
      int num = (int) depthStepAdvanced.ShowDialog();
      if (depthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(depthStepAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(depthStepAdvanced.buCamParameter);
      }
    }
    if (control2.Name == this.\u000E.Name)
    {
      F_Height fHeight = new F_Height()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fHeight.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fHeight.buCamParameter = new camParameters5(this.buCamParameter);
      fHeight.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fHeight.Tool = new ToolBase5(fHeight.Tool);
      fHeight.Init();
      int num = (int) fHeight.ShowDialog();
      if (fHeight.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fHeight.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fHeight.buCamParameter);
      }
    }
    if (control2.Name == this.\u0001.Name)
    {
      F_SurfaceQuality fSurfaceQuality = new F_SurfaceQuality()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fSurfaceQuality.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fSurfaceQuality.buCamParameter = new camParameters5(this.buCamParameter);
      fSurfaceQuality.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fSurfaceQuality.Tool = new ToolBase5(fSurfaceQuality.Tool);
      fSurfaceQuality.Init();
      int num = (int) fSurfaceQuality.ShowDialog();
      if (fSurfaceQuality.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fSurfaceQuality.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fSurfaceQuality.buCamParameter);
      }
    }
    if (control2.Name == this.\u000F.Name)
    {
      F_RoughLink fRoughLink = new F_RoughLink()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fRoughLink.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fRoughLink.buCamParameter = new camParameters5(this.buCamParameter);
      fRoughLink.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fRoughLink.Tool = new ToolBase5(fRoughLink.Tool);
      fRoughLink.Init();
      int num = (int) fRoughLink.ShowDialog();
      if (fRoughLink.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fRoughLink.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fRoughLink.buCamParameter);
        if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.FromRapidPlane)
          this.cmb_entryramptype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseRapidDistance)
          this.cmb_entryramptype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseFeedDistance)
          this.cmb_entryramptype.SelectedIndex = 2;
        if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.BackToRapidPlane)
          this.cmb_exitramptype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseRapidDistance)
          this.cmb_exitramptype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseFeedDistance)
          this.cmb_exitramptype.SelectedIndex = 2;
        this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
      }
    }
    if (control2.Name == this.\u0003.Name)
    {
      F_HeightAdvanced fHeightAdvanced = new F_HeightAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fHeightAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fHeightAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      fHeightAdvanced.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fHeightAdvanced.Tool = new ToolBase5(fHeightAdvanced.Tool);
      fHeightAdvanced.Init();
      int num = (int) fHeightAdvanced.ShowDialog();
      if (fHeightAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fHeightAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fHeightAdvanced.buCamParameter);
      }
    }
    if (control2.Name == this.\u0004.Name)
    {
      \u0005.\u0002.\u0001(this);
      F_Roughing fRoughing = new F_Roughing()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fRoughing.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fRoughing.mwCamParameter.DrillPoints = this.mwCamParameter.DrillPoints;
      fRoughing.buCamParameter = new camParameters5(this.buCamParameter);
      ((F_StockDef) fRoughing).chk_mirror.Visible = false;
      ((F_StockDef) fRoughing).chk_transformrotate.Visible = false;
      ((F_StockDef) fRoughing).btn_mirror.Visible = false;
      ((F_StockDef) fRoughing).btn_transformrotate.Visible = false;
      fRoughing.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fRoughing.Tool = new ToolBase5(fRoughing.Tool);
      fRoughing.Init();
      int num = (int) fRoughing.ShowDialog();
      if (fRoughing.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fRoughing.mwCamParameter.MachParam);
        this.mwCamParameter.DrillPoints = fRoughing.mwCamParameter.DrillPoints;
        this.buCamParameter = new camParameters5(fRoughing.buCamParameter);
        if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.FromRapidPlane)
          this.cmb_entryramptype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseRapidDistance)
          this.cmb_entryramptype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseFeedDistance)
          this.cmb_entryramptype.SelectedIndex = 2;
        if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.BackToRapidPlane)
          this.cmb_exitramptype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseRapidDistance)
          this.cmb_exitramptype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseFeedDistance)
          this.cmb_exitramptype.SelectedIndex = 2;
        this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
      }
    }
    if (control2.Name == this.\u0012.Name)
    {
      F_RestRough fRestRough = new F_RestRough()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fRestRough.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fRestRough.buCamParameter = new camParameters5(this.buCamParameter);
      fRestRough.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fRestRough.Tool = new ToolBase5(fRestRough.Tool);
      fRestRough.Init();
      int num = (int) fRestRough.ShowDialog();
      if (fRestRough.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fRestRough.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fRestRough.buCamParameter);
      }
    }
    if (control2.Name == ((F_RoughLink) this).\u0015.Name)
    {
      F_ProfilePass fProfilePass = new F_ProfilePass()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fProfilePass.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fProfilePass.buCamParameter = new camParameters5(this.buCamParameter);
      fProfilePass.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fProfilePass.Tool = new ToolBase5(fProfilePass.Tool);
      fProfilePass.Init();
      int num = (int) fProfilePass.ShowDialog();
      if (fProfilePass.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fProfilePass.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fProfilePass.buCamParameter);
      }
    }
    if (control2.Name == this.\u0010.Name)
    {
      F_2DContainment f2Dcontainment = new F_2DContainment()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      f2Dcontainment.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      f2Dcontainment.buCamParameter = new camParameters5(this.buCamParameter);
      f2Dcontainment.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        f2Dcontainment.Tool = new ToolBase5(f2Dcontainment.Tool);
      f2Dcontainment.Init();
      int num = (int) f2Dcontainment.ShowDialog();
      if (f2Dcontainment.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(f2Dcontainment.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(f2Dcontainment.buCamParameter);
      }
    }
    if (control2.Name == this.\u0011.Name)
    {
      F_Fixtures fFixtures = new F_Fixtures()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fFixtures.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fFixtures.buCamParameter = new camParameters5(this.buCamParameter);
      fFixtures.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fFixtures.Tool = new ToolBase5(fFixtures.Tool);
      fFixtures.Init();
      int num = (int) fFixtures.ShowDialog();
      if (fFixtures.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fFixtures.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fFixtures.buCamParameter);
      }
    }
    if (control2.Name == this.\u0014.Name)
    {
      F_Silhouette fSilhouette = new F_Silhouette()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fSilhouette.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fSilhouette.buCamParameter = new camParameters5(this.buCamParameter);
      fSilhouette.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fSilhouette.Tool = new ToolBase5(fSilhouette.Tool);
      fSilhouette.Init();
      int num = (int) fSilhouette.ShowDialog();
      if (fSilhouette.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fSilhouette.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fSilhouette.buCamParameter);
      }
    }
    if (!(control2.Name == this.\u0013.Name))
      return;
    F_Filtering fFiltering = new F_Filtering()
    {
      mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
    };
    fFiltering.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
    fFiltering.buCamParameter = new camParameters5(this.buCamParameter);
    fFiltering.Configration = new MWCalculationOptions(this.Configration);
    if (this.Tool != null)
      fFiltering.Tool = new ToolBase5(fFiltering.Tool);
    fFiltering.Init();
    int num1 = (int) fFiltering.ShowDialog();
    if (fFiltering.PropertiesForm.Result != DialogResult.OK)
      return;
    this.mwCamParameter.MachParam = new MachiningParams(fFiltering.mwCamParameter.MachParam);
    this.buCamParameter = new camParameters5(fFiltering.buCamParameter);
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.\u0001.SelectedTab.Controls, result, obj1.Shift);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!(this.PropertiesForm.TouchPad & !this.\u0002.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!this.PropertiesForm.Inited)
      return;
    this.ControlUpdate();
    if (control2.Name == this.\u0001.Name)
    {
      if (this.\u0001.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.RoughtOffset;
      else if (this.\u0001.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.RoughParalel;
      else if (this.\u0001.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.RoughtAdaptive;
    }
    if (control2.Name == this.\u0005.Name)
    {
      if (this.\u0005.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (this.\u0005.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
    }
    if (control2.Name == this.\u0004.Name)
    {
      if (this.\u0004.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.ClimbRough;
      else if (this.\u0004.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.ConventionalRough;
    }
    if (control2.Name == this.\u0002.Name)
    {
      if (this.\u0002.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.CuttingMethodOneWayTriangleMesh;
      else if (this.\u0002.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.CuttingMethodZigzagTriangleMeshRough;
      else if (this.\u0002.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.CuttingMethodSpiralTriangleMeshRough;
    }
    if (control2.Name == this.\u0003.Name)
    {
      if (this.\u0003.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.MachByLevelsTriangleMeshRough;
      else if (this.\u0003.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.MachByRegionsTriangleMeshRough;
    }
    if (control2.Name == this.cmb_entryramptype.Name)
    {
      if (this.cmb_entryramptype.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryFromRapidPlaneRough;
      else if (this.cmb_entryramptype.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryUseRapidDistanceRough;
      else if (this.cmb_entryramptype.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryUseFeedDistanceRough;
      else if (this.cmb_entryramptype.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
      else if (this.cmb_entryramptype.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
      else if (this.cmb_entryramptype.SelectedIndex == 5)
        this.\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
      else if (this.cmb_entryramptype.SelectedIndex == 6)
        this.\u0001.Image = (Image) ResourceImage.LineTangential;
      else if (this.cmb_entryramptype.SelectedIndex == 7)
        this.\u0001.Image = (Image) ResourceImage.LineReverseTangential;
      else if (this.cmb_entryramptype.SelectedIndex == 8)
        this.\u0001.Image = (Image) ResourceImage.LineOrthogonal;
      else if (this.cmb_entryramptype.SelectedIndex == 9)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (this.cmb_entryramptype.SelectedIndex == 10)
        this.\u0001.Image = (Image) ResourceImage.ProfileVertical;
      else if (this.cmb_entryramptype.SelectedIndex == 11)
        this.\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
      else if (this.cmb_entryramptype.SelectedIndex == 12)
        this.\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (this.cmb_entryramptype.SelectedIndex == 13)
        this.\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    if (!(control2.Name == this.cmb_exitramptype.Name))
      return;
    if (this.cmb_exitramptype.SelectedIndex == 0)
      this.\u0001.Image = (Image) ResourceImage.LastExitUseRapidPlaneRough;
    else if (this.cmb_exitramptype.SelectedIndex == 1)
      this.\u0001.Image = (Image) ResourceImage.LastExitUseRapidDistanceRough;
    else if (this.cmb_exitramptype.SelectedIndex == 2)
      this.\u0001.Image = (Image) ResourceImage.LastExitUseFeedDistanceRough;
    else if (this.cmb_exitramptype.SelectedIndex == 3)
      this.\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
    else if (this.cmb_exitramptype.SelectedIndex == 4)
      this.\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
    else if (this.cmb_exitramptype.SelectedIndex == 5)
      this.\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
    else if (this.cmb_exitramptype.SelectedIndex == 6)
      this.\u0001.Image = (Image) ResourceImage.LineTangential;
    else if (this.cmb_exitramptype.SelectedIndex == 7)
      this.\u0001.Image = (Image) ResourceImage.LineReverseTangential;
    else if (this.cmb_exitramptype.SelectedIndex == 8)
      this.\u0001.Image = (Image) ResourceImage.LineOrthogonal;
    else if (this.cmb_exitramptype.SelectedIndex == 9)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (this.cmb_exitramptype.SelectedIndex == 10)
      this.\u0001.Image = (Image) ResourceImage.ProfileVertical;
    else if (this.cmb_exitramptype.SelectedIndex == 11)
      this.\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
    else if (this.cmb_exitramptype.SelectedIndex == 12)
    {
      this.\u0001.Image = (Image) ResourceImage.LeadInPosition;
    }
    else
    {
      if (this.cmb_exitramptype.SelectedIndex != 13)
        return;
      this.\u0001.Image = (Image) ResourceImage.LineSlant;
    }
  }
}
