// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_DepthStepAdvanced
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_DepthStepAdvanced : Form
{
  internal CheckBox \u0013;
  internal System.Windows.Forms.Label \u008D;
  internal Button \u0015;
  internal Panel \u0019;
  internal System.Windows.Forms.Label \u008E;
  internal System.Windows.Forms.Label \u008F;
  internal NumericUpDown \u0018;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal Button \u0001;
  internal Button \u0002;
  internal ListBox \u0001;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal CheckBox \u0002;
  internal NumericUpDown \u0002;
  internal CheckBox \u0003;
  public Button btn_ok;
  internal ImageList \u0001;
  public Button btn_cancel;
  internal ImageList \u0002;
  internal CheckBox \u0004;
  internal PictureBox \u0001;
  internal Panel \u0001;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal CheckBox \u0005;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0004;
  internal CheckBox \u0006;
  internal CheckBox \u0007;
  internal CheckBox \u0008;
  internal Panel \u0003;
  internal CheckBox \u000E;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal NumericUpDown \u0007;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0004;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_WFContour) this).\u0006.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.Offset;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0001.Name)
    {
      if (!((F_WFContour) this).buCamParameter.Operations.isClosed)
      {
        if (((F_WFContour) this).\u0001.SelectedIndex == 0)
          ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.OffsetOpenLeft;
        else if (((F_WFContour) this).\u0001.SelectedIndex == 1)
          ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.OffsetOpenCenter;
        else if (((F_WFContour) this).\u0001.SelectedIndex == 2)
          ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.OffsetOpenRight;
      }
      else if (((F_WFContour) this).\u0001.SelectedIndex == 0)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.OffsetInside;
      else if (((F_WFContour) this).\u0001.SelectedIndex == 1)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.OffsetCenter;
      else if (((F_WFContour) this).\u0001.SelectedIndex == 2)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.OffsetOutside;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u000F.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ConstantHeight;
    else if (control2.Name == ((F_WFContour) this).\u0004.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.StartHeight;
    else if (control2.Name == ((F_WFContour) this).\u0005.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.EndHeight;
    else if (control2.Name == ((F_WFContour) this).\u0002.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    else if (control2.Name == ((F_WFContour) this).\u0001.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_WFContour) this).\u0008.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_WFContour) this).\u000E.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == ((F_WFContour) this).\u0004.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.StepDepth;
    else if (control2.Name == ((F_WFContour) this).\u0003.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == ((F_WFContour) this).\u0002.Name)
    {
      if (((F_WFContour) this).\u0002.SelectedIndex == 0)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SortOneway;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).\u0002.SelectedIndex == 1)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SortZigzag;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).\u0002.SelectedIndex == 2)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SortSpiral;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0003.Name)
    {
      if (((F_WFContour) this).\u0003.SelectedIndex == 0)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.GroupLevel;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).\u0003.SelectedIndex == 1)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.GroupRegion;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0004.Name)
    {
      if (((F_WFContour) this).\u0004.SelectedIndex == 0)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ContourCW;
      else if (((F_WFContour) this).\u0004.SelectedIndex == 1)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ContourCCW;
    }
    else if (control2.Name == ((F_WFContour) this).\u0007.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.CutTolerance;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0017.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.Overlap;
    else if (control2.Name == ((F_WFContour) this).\u0001.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.FeedRate;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0002.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.PlungeRate;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0003.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.RetractRate;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0016.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == ((F_WFContour) this).\u0001.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.RapidRetract;
    else if (control2.Name == ((F_WFContour) this).\u0007.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.RapidRate;
    else if (control2.Name == ((F_WFContour) this).\u0014.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == ((F_WFContour) this).\u0013.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == ((F_WFContour) this).\u0012.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.EntryFeedDistance;
    else if (control2.Name == ((F_WFContour) this).\u0011.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.AirSafeDistance;
    else if (control2.Name == ((F_WFContour) this).\u0010.Name)
    {
      if (((F_WFContour) this).\u0005.Checked)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
      else
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    }
    else if (control2.Name == ((F_WFContour) this).\u0005.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == ((F_WFContour) this).\u0006.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    else if (control2.Name == ((F_WFContour) this).\u0015.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.DraftAngle;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0003.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LeadIn;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0004.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LeadOut;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    if (control2.Name == ((F_WFContour) this).cmb_leadintype.Name)
    {
      if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 0)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 1)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 2)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 3)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 4)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 5)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 6)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 7)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 8)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 9)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 10)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 11)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 12)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_WFContour) this).cmb_leadintype.SelectedIndex == 13)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    if (control2.Name == ((F_WFContour) this).cmb_leadouttype.Name)
    {
      if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 0)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 1)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 2)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 3)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 4)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 5)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 6)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 7)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 8)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 9)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 10)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 11)
      {
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_WFContour) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 12)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_WFContour) this).cmb_leadouttype.SelectedIndex == 13)
        ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    else if (control2.Name == ((F_WFContour) this).\u0005.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.SharpCornerEnable;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u000E.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.RestFinishEnable;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u000F.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage._2DContaintmentEnable;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0006.Name)
    {
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.TabsEnable;
      if (((F_WFContour) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFContour) this).\u0010.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ExtendTrimEnable;
    else if (control2.Name == ((F_WFContour) this).\u0011.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.MultPassEnable;
    else if (control2.Name == ((F_WFContour) this).\u0012.Name)
      ((F_WFContour) this).\u0001.Image = (Image) ResourceImage.ProfilieAlongToolAxis;
    ((F_WFContour) this).\u0002.Checked = false;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    ((F_WFContour) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_WFContour) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_WFContour) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_DepthStepAdvanced() => F_WFContour.Captions = new List<string>();

  public F_DepthStepAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
        this.\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices == MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices)
        this.\u0001.Checked = true;
      this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepOfIntermediateSlices;
      this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfIntermediateSlices;
      this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThanOfIntermediateSlices;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStep;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStep;
      ((F_LeadControl) this).\u0008.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MaxWidth;
      ((F_LeadControl) this).\u000E.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinWidth;
      ((F_LeadControl) this).\u000F.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseMaxWidthFlag;
      this.\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStepFlg;
      this.\u0003.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStepFlg;
      this.\u000E.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.IntermediateSlicesFlg;
      this.\u0001.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStepFlg;
      this.\u0007.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineVerticalWallsFlg;
      this.\u0006.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveDepthStepFlg;
      this.\u0005.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.TrimAdaptiveDepthStepPassesFlg;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.MinDepthStep;
      this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.MaxStepoverDistance;
      if (this.Configration.CamTriMeshType == CamTriangularMeshType.Rough)
      {
        ((F_LeadControl) this).\u0010.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg;
        this.\u0001.Visible = false;
        this.\u0003.Visible = true;
        this.\u0003.Location = new Point(5, 190);
      }
      if (this.Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
      {
        this.\u0008.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg;
        this.\u0001.Visible = true;
        this.\u0003.Visible = false;
        this.\u0001.Location = new Point(5, 190);
      }
      this.\u0001.Items.Clear();
      for (int i = 0; i <= this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Count - 1; ++i)
        this.\u0001.Items.Add((object) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep[i]);
    }
    else
    {
      this.\u0003.Visible = false;
      this.\u0001.Visible = false;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
        this.\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices == MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices)
        this.\u0001.Checked = true;
      this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepOfIntermediateSlices;
      this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfIntermediateSlices;
      this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThanOfIntermediateSlices;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStep;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStep;
      this.\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStepFlg;
      this.\u0003.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStepFlg;
      this.\u000E.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.IntermediateSlicesFlg;
      this.\u0001.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStepFlg;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.MinDepthStep;
      this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.MaxStepoverDistance;
      this.\u0001.Items.Clear();
      for (int i = 0; i <= this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Count - 1; ++i)
        this.\u0001.Items.Add((object) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep[i]);
    }
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      this.Apply();
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
    if (control2.Name == this.\u0001.Name)
    {
      DialogBoxInput dialogBoxInput = new DialogBoxInput();
      dialogBoxInput.ValueCaption = "Value";
      dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
      dialogBoxInput.FormCaption = "Value";
      dialogBoxInput.Init();
      int num = (int) dialogBoxInput.ShowDialog();
      if (dialogBoxInput.Result == DialogResult.OK)
        this.\u0001.Items.Add((object) dialogBoxInput.Value);
    }
    if (!(control2.Name == this.\u0002.Name) || !(this.\u0001.SelectedIndex >= 0 & this.\u0001.SelectedIndex <= this.\u0001.Items.Count - 1))
      return;
    this.\u0001.Items.RemoveAt(this.\u0001.SelectedIndex);
  }

  public void ControlUpdate()
  {
    this.\u0001.Enabled = this.\u0001.Checked;
    ((F_LeadControl) this).\u000E.Enabled = ((F_LeadControl) this).\u000F.Checked;
    this.\u0001.Enabled = this.\u0002.Checked;
    this.\u0002.Enabled = this.\u0003.Checked;
    this.\u0004.Enabled = this.\u000E.Checked;
    ((F_LeadControl) this).\u0005.Enabled = ((F_LeadControl) this).\u0010.Checked;
    if (this.\u0002.Checked)
    {
      this.\u0007.Enabled = true;
      this.\u0006.Enabled = false;
    }
    if (this.\u0001.Checked)
    {
      this.\u0007.Enabled = false;
      this.\u0006.Enabled = true;
    }
    if (this.Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
    {
      this.\u0006.Enabled = !this.\u0007.Checked;
      this.\u0008.Enabled = !this.\u0006.Checked;
      this.\u0007.Enabled = !this.\u0006.Checked;
      this.\u0002.Enabled = this.\u0006.Checked & this.\u0006.Enabled;
    }
    if (this.Configration.isTriangularMeshAdvanced)
      return;
    this.\u0003.Enabled = false;
    this.\u0008.Enabled = false;
  }

  public void Apply()
  {
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepOfIntermediateSlices = (double) this.\u0007.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfIntermediateSlices = (int) this.\u0006.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThanOfIntermediateSlices = (double) this.\u0005.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStep = (double) this.\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStep = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MaxWidth = (double) ((F_LeadControl) this).\u0008.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinWidth = (double) ((F_LeadControl) this).\u000E.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseMaxWidthFlag = ((F_LeadControl) this).\u000F.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStepFlg = this.\u0002.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStepFlg = this.\u0003.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.IntermediateSlicesFlg = this.\u000E.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStepFlg = this.\u0001.Checked;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg = ((F_LeadControl) this).\u0010.Checked;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg = this.\u0008.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineVerticalWallsFlg = this.\u0007.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveDepthStepFlg = this.\u0006.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.TrimAdaptiveDepthStepPassesFlg = this.\u0005.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.MinDepthStep = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.MaxStepoverDistance = (double) this.\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Clear();
      for (int index = 0; index <= this.\u0001.Items.Count - 1; ++index)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Add(Convert.ToDouble(this.\u0001.Items[index]));
      if (this.\u0002.Checked)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
      }
      else
      {
        if (!this.\u0001.Checked)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
      }
    }
    else
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepOfIntermediateSlices = (double) this.\u0007.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfIntermediateSlices = (int) this.\u0006.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThanOfIntermediateSlices = (double) this.\u0005.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStep = (double) this.\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStep = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStepFlg = this.\u0002.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStepFlg = this.\u0003.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.IntermediateSlicesFlg = this.\u000E.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStepFlg = this.\u0001.Checked;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.MinDepthStep = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.MaxStepoverDistance = (double) this.\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Clear();
      for (int index = 0; index <= this.\u0001.Items.Count - 1; ++index)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Add(Convert.ToDouble(this.\u0001.Items[index]));
      if (this.\u0002.Checked)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
      }
      else
      {
        if (!this.\u0001.Checked)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
      }
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
  }
}
