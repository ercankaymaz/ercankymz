// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_WFRough
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
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

public class F_WFRough : Form
{
  internal RadioButton \u0008;
  internal Panel \u0019;
  internal Button \u0013;
  internal Button \u0014;
  internal CheckBox \u0015;
  internal System.Windows.Forms.Label \u0092;
  internal Button \u0015;
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
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0004;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0007;
  internal ComboBox \u0002;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0002;
  internal Button \u0001;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u000E;
  internal Panel \u0003;
  internal Panel \u0004;
  internal Button \u0002;
  internal NumericUpDown \u0008;
  internal NumericUpDown \u000E;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u000F;
  internal NumericUpDown \u000F;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal NumericUpDown \u0010;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0005;
  internal ComboBox \u0003;
  internal System.Windows.Forms.Label \u0011;
  internal Panel \u0006;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal System.Windows.Forms.Label \u0014;
  internal Panel \u0007;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal System.Windows.Forms.Label \u0017;
  internal Panel \u0008;
  internal Button \u0003;
  internal System.Windows.Forms.Label \u0018;
  internal NumericUpDown \u0011;
  internal System.Windows.Forms.Label \u0019;
  internal System.Windows.Forms.Label \u001A;
  internal System.Windows.Forms.Label \u001B;
  internal NumericUpDown \u0012;
  internal System.Windows.Forms.Label \u001C;
  internal NumericUpDown \u0013;
  internal NumericUpDown \u0014;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal CheckBox \u0002;
  internal Panel \u000E;
  internal System.Windows.Forms.Label \u001D;
  internal CheckBox \u0003;
  internal Panel \u000F;
  internal System.Windows.Forms.Label \u001E;
  public ComboBox cmb_exitramptype;
  internal System.Windows.Forms.Label \u001F;
  internal Button \u0004;
  internal System.Windows.Forms.Label \u007F;
  public ComboBox cmb_entryramptype;
  internal Panel \u0010;
  internal System.Windows.Forms.Label \u0080;
  internal System.Windows.Forms.Label \u0081;
  internal NumericUpDown \u0015;
  internal NumericUpDown \u0016;
  internal CheckBox \u0004;
  internal Panel \u0011;
  internal System.Windows.Forms.Label \u0082;
  internal System.Windows.Forms.Label \u0083;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u0084;
  internal ComboBox \u0004;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u0086;
  internal NumericUpDown \u0017;
  internal CheckBox \u0007;
  internal CheckBox \u0008;
  internal Panel \u0012;
  internal System.Windows.Forms.Label \u0087;
  internal System.Windows.Forms.Label \u0088;
  internal NumericUpDown \u0018;
  internal CheckBox \u000E;
  internal CheckBox \u000F;
  internal CheckBox \u0010;
  internal NumericUpDown \u0019;
  internal System.Windows.Forms.Label \u0089;
  internal System.Windows.Forms.Label \u008A;
  internal NumericUpDown \u001A;
  internal Button \u0005;
  internal Panel \u0013;
  internal Button \u0006;
  internal Button \u0007;
  internal CheckBox \u0011;
  internal System.Windows.Forms.Label \u008B;
  internal Panel \u0014;
  internal Button \u0008;
  internal CheckBox \u0012;
  internal System.Windows.Forms.Label \u008C;
  internal Panel \u0015;
  internal Button \u000E;
  internal Button \u000F;
  internal CheckBox \u0013;
  internal Button \u0010;
  internal System.Windows.Forms.Label \u008D;
  internal Panel \u0016;
  internal Button \u0011;
  internal CheckBox \u0014;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_WFContour4AX) this).\u0006.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.Offset;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0001.Name)
    {
      if (!((F_WFContour4AX) this).buCamParameter.Operations.isClosed)
      {
        if (((F_WFContour4AX) this).\u0001.SelectedIndex == 0)
          ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.OffsetOpenLeft;
        else if (((F_WFContour4AX) this).\u0001.SelectedIndex == 1)
          ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.OffsetOpenCenter;
        else if (((F_WFContour4AX) this).\u0001.SelectedIndex == 2)
          ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.OffsetOpenRight;
      }
      else if (((F_WFContour4AX) this).\u0001.SelectedIndex == 0)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.OffsetInside;
      else if (((F_WFContour4AX) this).\u0001.SelectedIndex == 1)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.OffsetCenter;
      else if (((F_WFContour4AX) this).\u0001.SelectedIndex == 2)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.OffsetOutside;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u000F.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ConstantHeight;
    else if (control2.Name == ((F_WFContour4AX) this).\u0004.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.StartHeight;
    else if (control2.Name == ((F_WFContour4AX) this).\u0005.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.EndHeight;
    else if (control2.Name == ((F_WFContour4AX) this).\u0002.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    else if (control2.Name == ((F_WFContour4AX) this).\u0001.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_WFContour4AX) this).\u0008.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_WFContour4AX) this).\u000E.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == ((F_WFContour4AX) this).\u0004.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.StepDepth;
    else if (control2.Name == ((F_WFContour4AX) this).\u0003.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == ((F_WFContour4AX) this).\u0002.Name)
    {
      if (((F_WFContour4AX) this).\u0002.SelectedIndex == 0)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SortOneway;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).\u0002.SelectedIndex == 1)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SortZigzag;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).\u0002.SelectedIndex == 2)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SortSpiral;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0003.Name)
    {
      if (((F_WFContour4AX) this).\u0003.SelectedIndex == 0)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.GroupLevel;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).\u0003.SelectedIndex == 1)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.GroupRegion;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0004.Name)
    {
      if (((F_WFContour4AX) this).\u0004.SelectedIndex == 0)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ContourCW;
      else if (((F_WFContour4AX) this).\u0004.SelectedIndex == 1)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ContourCCW;
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0007.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.CutTolerance;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0017.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.Overlap;
    else if (control2.Name == ((F_WFContour4AX) this).\u0001.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.FeedRate;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0002.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.PlungeRate;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0003.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.RetractRate;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0016.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == ((F_WFContour4AX) this).\u0001.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.RapidRetract;
    else if (control2.Name == ((F_WFContour4AX) this).\u0007.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == ((F_WFContour4AX) this).\u0014.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == ((F_WFContour4AX) this).\u0013.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == ((F_WFContour4AX) this).\u0012.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.EntryFeedDistance;
    else if (control2.Name == ((F_WFContour4AX) this).\u0011.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.AirSafeDistance;
    else if (control2.Name == ((F_WFContour4AX) this).\u0010.Name)
    {
      if (((F_WFContour4AX) this).\u0005.Checked)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
      else
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0005.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == ((F_WFContour4AX) this).\u0006.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    else if (control2.Name == ((F_WFContour4AX) this).\u0015.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.DraftAngle;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0003.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LeadIn;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0004.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LeadOut;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    if (control2.Name == ((F_WFContour4AX) this).cmb_leadintype.Name)
    {
      if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 0)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 1)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 2)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 3)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 4)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 5)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 6)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 7)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 8)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 9)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 10)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 11)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 12)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_WFContour4AX) this).cmb_leadintype.SelectedIndex == 13)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    if (control2.Name == ((F_WFContour4AX) this).cmb_leadouttype.Name)
    {
      if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 0)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 1)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 2)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 3)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 4)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 5)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 6)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 7)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 8)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 9)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 10)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 11)
      {
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_WFContour4AX) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 12)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_WFContour4AX) this).cmb_leadouttype.SelectedIndex == 13)
        ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0005.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.SharpCornerEnable;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u000E.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.RestFinishEnable;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u000F.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage._2DContaintmentEnable;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0006.Name)
    {
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.TabsEnable;
      if (((F_WFContour4AX) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour4AX) this).\u0010.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ExtendTrimEnable;
    else if (control2.Name == ((F_WFContour4AX) this).\u0011.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.MultPassEnable;
    else if (control2.Name == ((F_WFContour4AX) this).\u0012.Name)
      ((F_WFContour4AX) this).\u0001.Image = (Image) ResourceImage.ProfilieAlongToolAxis;
    ((F_WFContour4AX) this).\u0002.Checked = false;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    ((F_WFContour4AX) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_WFContour4AX) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_WFContour4AX) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_WFRough() => F_WFContour4AX.Captions = new List<string>();

  public F_WFRough() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.\u0002.Visible = this.PropertiesForm.ShowHelp;
    this.\u000E.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0008.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.CutTolerance;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedRate;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.PlungeFeedRate;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.RetractFeedRate;
    this.\u0019.Value = (Decimal) this.mwCamParameter.MachParam.ParallelMachAngleInYX;
    this.\u0012.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    this.\u0013.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.RetractPlaneIncremental;
    this.\u0014.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ClearancePlaneHeight;
    this.\u0011.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AirMoveSafetyDistance;
    this.\u0005.Value = (Decimal) this.buCamParameter.Steps.EndValue;
    this.\u0004.Value = (Decimal) this.buCamParameter.Steps.StartValue;
    this.\u000F.Value = (Decimal) this.buCamParameter.Operations.Height;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.StockRemain;
    this.\u0010.Value = (Decimal) this.buCamParameter.Speeds.SpindleSpeed;
    this.\u0001.Checked = this.mwCamParameter.MachParam.RapidRetractFlg;
    this.\u0006.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ReverseCuttingOrderFlg;
    this.\u0004.Checked = this.mwCamParameter.MachParam.RapidFeedFlg;
    this.\u0005.Checked = this.buCamParameter.Offsets.AddToolDiameterAsOffset;
    this.\u0008.Checked = this.mwCamParameter.MachParam.RapidApproachFlg;
    this.\u0007.Checked = this.mwCamParameter.MachParam.AdaptiveFeedRateFlg;
    this.\u0017.Value = (Decimal) this.mwCamParameter.MachParam.MinFeedRateAsFeedRatePercentage;
    this.\u0018.Value = (Decimal) this.mwCamParameter.MachParam.MaxStepoverDistance;
    if (this.Tool != null)
      this.\u001A.Value = (Decimal) (this.mwCamParameter.MachParam.MaxStepoverDistance / this.Tool.Geometry.Diameter * 100.0);
    this.\u0001.Items.Clear();
    this.\u0001.Items.Add((object) buMWCaptions.WireframeBasedTpCalcParamsRoughType[0]);
    this.\u0001.Items.Add((object) buMWCaptions.WireframeBasedTpCalcParamsRoughType[1]);
    this.\u0001.Items.Add((object) buMWCaptions.WireframeBasedTpCalcParamsRoughType[2]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType == WireframeBasedTpCalcParamsRoughType.WfbRghtOffset)
      this.\u0001.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType == WireframeBasedTpCalcParamsRoughType.WfbRghtParallel)
      this.\u0001.SelectedIndex = 1;
    else
      this.\u0001.SelectedIndex = 2;
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
    if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0002.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0002.SelectedIndex = 1;
    this.\u0003.Items.Clear();
    this.\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[0]);
    this.\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[1]);
    if (this.mwCamParameter.MachParam.MachiningAreaMode == MachiningParamsMachiningAreaMode.MachByLanes)
      this.\u0003.SelectedIndex = 0;
    else
      this.\u0003.SelectedIndex = 1;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
    {
      this.\u0002.Checked = true;
      this.\u0001.Checked = false;
    }
    else
    {
      this.\u0002.Checked = false;
      this.\u0001.Checked = true;
    }
    if (!this.buCamParameter.Steps.Enable)
    {
      this.\u0003.Checked = true;
      this.\u0004.Checked = false;
    }
    else
    {
      this.\u0003.Checked = false;
      this.\u0004.Checked = true;
    }
    if (this.buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
    {
      this.\u0006.Checked = true;
      this.\u0005.Checked = false;
    }
    else
    {
      this.\u0006.Checked = false;
      this.\u0005.Checked = true;
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
    this.\u0015.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.DraftAngle;
    this.\u0011.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurvesFlg;
    this.\u0010.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg;
    this.\u000F.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ClosedOffsetFlg;
    this.\u0012.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RestRoughFlg;
    this.\u0013.Checked = this.mwCamParameter.MachParam.Containment2dParams.IsUsedFlg;
    this.\u0014.Checked = this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.IsUsedFlg;
    ((F_WFContour) this).\u0015.Checked = this.mwCamParameter.MachParam.FeedControlZoneParams.Status;
    this.Configration.Mode = CamMode.WireFrame;
    this.Configration.CamWireframeType = CamWireFrameType.Pocket;
    this.\u0001.Image = (Image) ResourceImage.RoughtOffset;
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  public void ControlUpdate()
  {
    this.\u0008.Enabled = this.\u0012.Checked;
    this.\u0007.Enabled = this.\u0011.Checked;
    this.\u0006.Enabled = this.\u0011.Checked;
    this.\u000F.Enabled = this.\u0013.Checked;
    this.\u0010.Enabled = this.\u0013.Checked;
    this.\u0011.Enabled = this.\u0014.Checked;
    ((F_WFContour) this).\u0013.Enabled = ((F_WFContour) this).\u0015.Checked;
    ((F_WFContour) this).\u0012.Enabled = ((F_WFContour) this).\u0015.Checked;
    this.\u0016.Enabled = this.\u0004.Checked;
    if (this.\u0003.Checked)
    {
      this.\u0005.Enabled = true;
      this.\u0004.Enabled = false;
    }
    else
    {
      this.\u0005.Enabled = false;
      this.\u0004.Enabled = true;
    }
    if (this.\u0002.Checked)
    {
      this.\u000E.Enabled = true;
      this.\u0008.Enabled = false;
    }
    else
    {
      this.\u000E.Enabled = false;
      this.\u0008.Enabled = true;
    }
    this.cmb_entryramptype.Enabled = this.\u0003.Checked;
    this.\u007F.Enabled = this.\u0003.Checked;
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
      depthStepAdvanced.Init();
      int num = (int) depthStepAdvanced.ShowDialog();
      if (depthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(depthStepAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(depthStepAdvanced.buCamParameter);
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
      fSurfaceQuality.Init();
      int num = (int) fSurfaceQuality.ShowDialog();
      if (fSurfaceQuality.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fSurfaceQuality.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fSurfaceQuality.buCamParameter);
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
      fHeightAdvanced.Init();
      int num = (int) fHeightAdvanced.ShowDialog();
      if (fHeightAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fHeightAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fHeightAdvanced.buCamParameter);
      }
    }
    if (control2.Name == this.\u0005.Name)
    {
      F_RoughLink fRoughLink = new F_RoughLink()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fRoughLink.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fRoughLink.buCamParameter = new camParameters5(this.buCamParameter);
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
    if (control2.Name == ((F_WFContour) this).\u0014.Name)
    {
      F_FeedAdvanced fFeedAdvanced = new F_FeedAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fFeedAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fFeedAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      fFeedAdvanced.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fFeedAdvanced.Tool = new ToolBase5(fFeedAdvanced.Tool);
      fFeedAdvanced.Init();
      int num = (int) fFeedAdvanced.ShowDialog();
      if (fFeedAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fFeedAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fFeedAdvanced.buCamParameter);
      }
    }
    if (control2.Name == this.\u0008.Name)
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
    if (control2.Name == this.\u000F.Name)
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
    if (control2.Name == this.\u0006.Name)
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
    if (control2.Name == this.\u0011.Name)
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
    if (!(control2.Name == ((F_WFContour) this).\u0012.Name))
      return;
    F_FeedZone fFeedZone = new F_FeedZone()
    {
      mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
    };
    fFeedZone.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
    fFeedZone.buCamParameter = new camParameters5(this.buCamParameter);
    fFeedZone.Configration = new MWCalculationOptions(this.Configration);
    if (this.Tool != null)
      fFeedZone.Tool = new ToolBase5(fFeedZone.Tool);
    fFeedZone.Init();
    int num1 = (int) fFeedZone.ShowDialog();
    if (fFeedZone.PropertiesForm.Result != DialogResult.OK)
      return;
    this.mwCamParameter.MachParam = new MachiningParams(fFeedZone.mwCamParameter.MachParam);
    this.buCamParameter = new camParameters5(fFeedZone.buCamParameter);
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
    if (control2.Name == this.\u0004.Name)
    {
      if (this.\u0004.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.ContourCW;
      else if (this.\u0004.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.ContourCCW;
    }
    if (control2.Name == this.\u0002.Name)
    {
      if (this.\u0002.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.SortOneway;
      else if (this.\u0002.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.SortZigzag;
      else if (this.\u0002.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.SortSpiral;
    }
    if (control2.Name == this.\u0003.Name)
    {
      if (this.\u0003.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.GroupLevel;
      else if (this.\u0003.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.GroupRegion;
    }
    if (control2.Name == this.cmb_entryramptype.Name)
    {
      if (this.cmb_entryramptype.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.ArcTangential;
      else if (this.cmb_entryramptype.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
      else if (this.cmb_entryramptype.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
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
      this.\u0001.Image = (Image) ResourceImage.ArcTangential;
    else if (this.cmb_exitramptype.SelectedIndex == 1)
      this.\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
    else if (this.cmb_exitramptype.SelectedIndex == 2)
      this.\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
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

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0006.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.Offset;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0001.Name)
    {
      if (this.\u0001.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.RoughtOffset;
      else if (this.\u0001.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.RoughParalel;
      else if (this.\u0001.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.RoughtAdaptive;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u000F.Name)
      this.\u0001.Image = (Image) ResourceImage.ConstantHeight;
    else if (control2.Name == this.\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.StartHeight;
    else if (control2.Name == this.\u0005.Name)
      this.\u0001.Image = (Image) ResourceImage.EndHeight;
    else if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == this.\u0008.Name)
      this.\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == this.\u000E.Name)
      this.\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == this.\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.StepDepth;
    else if (control2.Name == this.\u0003.Name)
      this.\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == this.\u0002.Name)
    {
      if (this.\u0002.SelectedIndex == 0)
      {
        this.\u0001.Image = (Image) ResourceImage.SortOneway;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.\u0002.SelectedIndex == 1)
      {
        this.\u0001.Image = (Image) ResourceImage.SortZigzag;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.\u0002.SelectedIndex == 2)
      {
        this.\u0001.Image = (Image) ResourceImage.SortSpiral;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == this.\u0003.Name)
    {
      if (this.\u0003.SelectedIndex == 0)
      {
        this.\u0001.Image = (Image) ResourceImage.GroupLevel;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.\u0003.SelectedIndex == 1)
      {
        this.\u0001.Image = (Image) ResourceImage.GroupRegion;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == this.\u0004.Name)
    {
      if (this.\u0004.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.ContourCW;
      else if (this.\u0004.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.ContourCCW;
    }
    else if (control2.Name == this.\u0007.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.CutTolerance;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0019.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.NoImage;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0006.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.ReverseCuttingOrder;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0001.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.FeedRate;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0002.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.PlungeRate;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0003.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.RetractRate;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0018.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.MaxStepoverTriangleMeshRough;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0016.Name)
      this.\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.RapidRetract;
    else if (control2.Name == this.\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == this.\u0014.Name)
      this.\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == this.\u0013.Name)
      this.\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == this.\u0012.Name)
      this.\u0001.Image = (Image) ResourceImage.EntryFeedDistance;
    else if (control2.Name == this.\u0011.Name)
      this.\u0001.Image = (Image) ResourceImage.AirSafeDistance;
    else if (control2.Name == this.\u0010.Name)
      this.\u0001.Image = !this.\u0005.Checked ? (Image) ResourceImage.SpindleCW : (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == this.\u0005.Name)
      this.\u0001.Image = (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == this.\u0006.Name)
      this.\u0001.Image = (Image) ResourceImage.SpindleCW;
    else if (control2.Name == this.\u0015.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.DraftAngle;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0003.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.LeadIn;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.cmb_entryramptype.Name)
    {
      if (this.cmb_entryramptype.SelectedIndex == 0)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 1)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 2)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 3)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 4)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 5)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 6)
      {
        this.\u0001.Image = (Image) ResourceImage.LineTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 7)
      {
        this.\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 8)
      {
        this.\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 9)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (this.cmb_entryramptype.SelectedIndex == 10)
      {
        this.\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 11)
      {
        this.\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_entryramptype.SelectedIndex == 12)
        this.\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (this.cmb_entryramptype.SelectedIndex == 13)
        this.\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    else if (control2.Name == this.cmb_exitramptype.Name)
    {
      if (this.cmb_exitramptype.SelectedIndex == 0)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 1)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 2)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 3)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 4)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 5)
      {
        this.\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 6)
      {
        this.\u0001.Image = (Image) ResourceImage.LineTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 7)
      {
        this.\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 8)
      {
        this.\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 9)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (this.cmb_exitramptype.SelectedIndex == 10)
      {
        this.\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 11)
      {
        this.\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (this.\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_exitramptype.SelectedIndex == 12)
        this.\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (this.cmb_exitramptype.SelectedIndex == 13)
        this.\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    else if (control2.Name == this.\u0012.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.RestFinishEnable;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0013.Name)
    {
      this.\u0001.Image = (Image) ResourceImage._2DContaintmentEnable;
      if (this.\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else
      this.\u0001.Image = !(control2.Name == this.\u0014.Name) ? (Image) ResourceImage.NoImage : (Image) ResourceImage.MultPassEnable;
    this.\u0002.Checked = false;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();
}
