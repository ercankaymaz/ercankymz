// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_RoughLink
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
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

public class F_RoughLink : Form
{
  internal CheckBox \u0011;
  internal System.Windows.Forms.Label \u0092;
  internal Panel \u0017;
  internal Button \u0015;
  internal CheckBox \u0012;
  internal System.Windows.Forms.Label \u0093;
  internal Button \u0016;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  public ComboBox cmb_firstentry;
  public ComboBox cmb_lastexitramp;
  public ComboBox cmb_firstentryramp;
  public ComboBox cmb_lastexit;
  public ComboBox cmb_arealinkbetweengroupramp;
  public ComboBox cmb_arealinkbetweengroup;
  public ComboBox cmb_arealinkwithingroupramp;
  public ComboBox cmb_arealinkswithingroup;
  internal Panel \u0003;
  public ComboBox cmb_linkbetweenslicesramp;
  public ComboBox cmb_linkbetweenslices;
  internal System.Windows.Forms.Label \u0007;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0004;
  public ComboBox cmb_linkbetweenregionrapm;
  public ComboBox cmb_linkbetweenregion;
  internal System.Windows.Forms.Label \u000E;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_TriMeshRough) this).\u001C.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.GlobalOffset;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u001B.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.AxialOffset;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u001A.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.RadialOffset;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0001.Name)
    {
      if (((F_TriMeshRough) this).\u0001.SelectedIndex == 0)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.RoughtOffset;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).\u0001.SelectedIndex == 1)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.RoughParalel;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).\u0001.SelectedIndex == 2)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.RoughtAdaptive;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0018.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.MachiningAngleTriangleMeshRough;
    else if (control2.Name == ((F_TriMeshRough) this).\u0002.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    else if (control2.Name == ((F_TriMeshRough) this).\u0001.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_TriMeshRough) this).\u0005.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_TriMeshRough) this).\u0006.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ConstantDeptStepTriangleMeshRough;
    else if (control2.Name == ((F_TriMeshRough) this).\u0002.Name)
    {
      if (((F_TriMeshRough) this).\u0002.SelectedIndex == 0)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.CuttingMethodOneWayTriangleMesh;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).\u0002.SelectedIndex == 1)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.CuttingMethodZigzagTriangleMeshRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).\u0002.SelectedIndex == 2)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.CuttingMethodSpiralTriangleMeshRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0003.Name)
    {
      if (((F_TriMeshRough) this).\u0003.SelectedIndex == 0)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.MachByLevelsTriangleMeshRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).\u0003.SelectedIndex == 1)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.MachByRegionsTriangleMeshRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0004.Name)
    {
      if (((F_TriMeshRough) this).\u0004.SelectedIndex == 0)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ClimbRough;
      else if (((F_TriMeshRough) this).\u0004.SelectedIndex == 1)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ConventionalRough;
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0004.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.CutTolerance;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0008.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ReverseCuttingOrder;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0001.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0002.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0003.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0015.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_TriMeshRough) this).\u0001.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_TriMeshRough) this).\u000F.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_TriMeshRough) this).\u0007.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_TriMeshRough) this).\u000E.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0016.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0010.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == ((F_TriMeshRough) this).\u000F.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == ((F_TriMeshRough) this).\u000E.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.EntryFeedDistance;
    else if (control2.Name == ((F_TriMeshRough) this).\u0008.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.AirSafeDistance;
    else if (control2.Name == ((F_TriMeshRough) this).\u0007.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.SpindleSpeed;
    else if (control2.Name == ((F_TriMeshRough) this).\u0003.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.CounterClockwiseRough;
    else if (control2.Name == ((F_TriMeshRough) this).\u0004.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.DirectionClockwiseRough;
    else if (control2.Name == ((F_TriMeshRough) this).\u0011.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.DraftAngleRough;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0017.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.MaxStepoverTriangleMeshRough;
    else if (control2.Name == ((F_TriMeshRough) this).\u0019.Name)
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_TriMeshRough) this).\u0003.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LeadIn;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    if (control2.Name == ((F_TriMeshRough) this).cmb_entryramptype.Name)
    {
      if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 0)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.FirstEntryFromRapidPlaneRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 1)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.FirstEntryUseRapidDistanceRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 2)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.FirstEntryUseFeedDistanceRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 3)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 4)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 5)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 6)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 7)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 8)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 9)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 10)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 11)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 12)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_TriMeshRough) this).cmb_entryramptype.SelectedIndex == 13)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    if (control2.Name == ((F_TriMeshRough) this).cmb_exitramptype.Name)
    {
      if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 0)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LastExitUseRapidPlaneRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 1)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LastExitUseRapidDistanceRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 2)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LastExitUseFeedDistanceRough;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 3)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 4)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 5)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 6)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 7)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineReverseTangential;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 8)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineOrthogonal;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 9)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 10)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ProfileVertical;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 11)
      {
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
        if (((F_TriMeshRough) this).\u0002.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 12)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (((F_TriMeshRough) this).cmb_exitramptype.SelectedIndex == 13)
        ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0010.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ClosedOffsetRough;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0004.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.RestRoughTriangleMesh;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0005.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.FixtureCurvesRough;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_TriMeshRough) this).\u0006.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage._2DContaintmentEnable;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0012.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.ProfilePassTriMeshRough;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0011.Name)
    {
      ((F_TriMeshRough) this).\u0001.Image = (Image) ResourceImage.SilhouetteContTriMeshRough;
      if (((F_TriMeshRough) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    ((F_TriMeshRough) this).\u0002.Checked = false;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    ((F_TriMeshRough) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_TriMeshRough) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_TriMeshRough) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RoughLink() => F_TriMeshRough.Captions = new List<string>();

  public F_RoughLink() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.\u0001.Visible = true;
      this.\u0002.Visible = true;
    }
    this.\u0004.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.UseHomePositionFlg;
    this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.UseHomePositionFlg;
    this.\u0002.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.StartFromMaximumZFlg;
    this.\u0001.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.ReturnToMaximumZFlg;
    this.cmb_firstentry.Items.Clear();
    this.cmb_firstentry.Items.Add((object) buMWCaptions.FirstEntryType[0]);
    this.cmb_firstentry.Items.Add((object) buMWCaptions.FirstEntryType[1]);
    this.cmb_firstentry.Items.Add((object) buMWCaptions.FirstEntryType[2]);
    if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.FromRapidPlane)
      this.cmb_firstentry.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseRapidDistance)
      this.cmb_firstentry.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseFeedDistance)
      this.cmb_firstentry.SelectedIndex = 2;
    this.cmb_firstentryramp.Items.Clear();
    this.cmb_firstentryramp.Items.Add((object) buMWCaptions.UseRamp[0]);
    this.cmb_firstentryramp.Items.Add((object) buMWCaptions.UseRamp[1]);
    if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed)
      this.cmb_firstentryramp.SelectedIndex = 0;
    else
      this.cmb_firstentryramp.SelectedIndex = 1;
    this.cmb_lastexit.Items.Clear();
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[0]);
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[1]);
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[2]);
    if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.BackToRapidPlane)
      this.cmb_lastexit.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseRapidDistance)
      this.cmb_lastexit.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseFeedDistance)
      this.cmb_lastexit.SelectedIndex = 2;
    this.cmb_arealinkbetweengroup.Items.Clear();
    this.cmb_arealinkbetweengroup.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_arealinkbetweengroup.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_arealinkbetweengroup.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    this.cmb_arealinkbetweengroup.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_arealinkbetweengroup.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_arealinkbetweengroup.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_arealinkbetweengroup.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_arealinkbetweengroup.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_arealinkbetweengroup.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_arealinkbetweengroup.SelectedIndex = 4;
    this.cmb_arealinkbetweengroupramp.Items.Clear();
    this.cmb_arealinkbetweengroupramp.Items.Add((object) buMWCaptions.UseRamp[0]);
    this.cmb_arealinkbetweengroupramp.Items.Add((object) buMWCaptions.UseRamp[1]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_arealinkbetweengroupramp.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_arealinkbetweengroupramp.SelectedIndex = 1;
    this.cmb_arealinkswithingroup.Items.Clear();
    this.cmb_arealinkswithingroup.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_arealinkswithingroup.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_arealinkswithingroup.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    this.cmb_arealinkswithingroup.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_arealinkswithingroup.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_arealinkswithingroup.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_arealinkswithingroup.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_arealinkswithingroup.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_arealinkswithingroup.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_arealinkswithingroup.SelectedIndex = 4;
    this.cmb_arealinkwithingroupramp.Items.Clear();
    this.cmb_arealinkwithingroupramp.Items.Add((object) buMWCaptions.UseRamp[0]);
    this.cmb_arealinkwithingroupramp.Items.Add((object) buMWCaptions.UseRamp[1]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_arealinkwithingroupramp.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_arealinkwithingroupramp.SelectedIndex = 1;
    this.cmb_linkbetweenslices.Items.Clear();
    this.cmb_linkbetweenslices.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_linkbetweenslices.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_linkbetweenslices.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_linkbetweenslices.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    this.cmb_linkbetweenslices.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_linkbetweenslices.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_linkbetweenslices.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_linkbetweenslices.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_linkbetweenslices.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_linkbetweenslices.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_linkbetweenslices.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_linkbetweenslices.SelectedIndex = 5;
    this.cmb_linkbetweenslicesramp.Items.Clear();
    this.cmb_linkbetweenslicesramp.Items.Add((object) buMWCaptions.UseRamp[0]);
    this.cmb_linkbetweenslicesramp.Items.Add((object) buMWCaptions.UseRamp[1]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_linkbetweenslicesramp.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_linkbetweenslicesramp.SelectedIndex = 1;
    this.cmb_linkbetweenregion.Items.Clear();
    this.cmb_linkbetweenregion.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_linkbetweenregion.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_linkbetweenregion.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    this.cmb_linkbetweenregion.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_linkbetweenregion.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_linkbetweenregion.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_linkbetweenregion.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_linkbetweenregion.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_linkbetweenregion.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_linkbetweenregion.SelectedIndex = 4;
    this.cmb_linkbetweenregionrapm.Items.Clear();
    this.cmb_linkbetweenregionrapm.Items.Add((object) buMWCaptions.UseRamp[0]);
    this.cmb_linkbetweenregionrapm.Items.Add((object) buMWCaptions.UseRamp[1]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_linkbetweenregionrapm.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.cmb_linkbetweenregionrapm.SelectedIndex = 1;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
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
    if (control2.Name == ((F_WFScan) this).btn_ok.Name)
    {
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_WFScan) this).btn_cancel.Name))
      return;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.LinkParams.FirstEntry.UseHomePositionFlg = this.\u0004.Checked;
    this.mwCamParameter.MachParam.LinkParams.FirstEntry.StartFromMaximumZFlg = this.\u0002.Checked;
    this.mwCamParameter.MachParam.LinkParams.LastExit.UseHomePositionFlg = this.\u0003.Checked;
    this.mwCamParameter.MachParam.LinkParams.LastExit.ReturnToMaximumZFlg = this.\u0001.Checked;
    if (this.cmb_firstentry.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.FromRapidPlane;
    else if (this.cmb_firstentry.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.UseRapidDistance;
    else if (this.cmb_firstentry.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.UseFeedDistance;
    this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed = this.cmb_firstentryramp.SelectedIndex == 0;
    if (this.cmb_lastexit.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.BackToRapidPlane;
    else if (this.cmb_lastexit.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.UseRapidDistance;
    else if (this.cmb_lastexit.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.UseFeedDistance;
    this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed = this.cmb_lastexitramp.SelectedIndex == 0;
    if (this.cmb_arealinkbetweengroup.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_arealinkbetweengroup.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_arealinkbetweengroup.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_arealinkbetweengroup.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_arealinkbetweengroup.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.cmb_arealinkbetweengroupramp.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else if (this.cmb_arealinkbetweengroupramp.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    if (this.cmb_arealinkswithingroup.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_arealinkswithingroup.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_arealinkswithingroup.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_arealinkswithingroup.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_arealinkswithingroup.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.cmb_arealinkbetweengroupramp.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else if (this.cmb_arealinkbetweengroupramp.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    if (this.cmb_linkbetweenregion.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_linkbetweenregion.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_linkbetweenregion.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_linkbetweenregion.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_linkbetweenregion.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.cmb_linkbetweenregionrapm.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else if (this.cmb_linkbetweenregionrapm.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    if (this.cmb_linkbetweenslices.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_linkbetweenslices.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_linkbetweenslices.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_linkbetweenslices.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_linkbetweenslices.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_linkbetweenslices.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.cmb_linkbetweenslicesramp.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    }
    else
    {
      if (this.cmb_linkbetweenslicesramp.SelectedIndex != 1)
        return;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();
}
