// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMProjectCurves
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMProjectCurves : Form
{
  internal CheckBox \u000E;
  internal Label \u0015;
  internal CheckBox \u000F;
  internal NumericUpDown \u0007;
  internal IContainer \u0001;
  internal Panel \u0001;
  internal Button \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Label \u0001;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal CheckBox \u0001;
  internal Button \u0002;
  internal Panel \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0002;
  internal Label \u0004;
  internal Label \u0005;
  internal PictureBox \u0001;
  internal Button \u0003;
  internal Label \u0006;
  public Button btn_cancel;
  internal ImageList \u0001;
  internal Label \u0007;
  internal Label \u0008;
  internal NumericUpDown \u0003;
  internal CheckBox \u0002;
  internal NumericUpDown \u0004;
  internal Label \u000E;
  internal NumericUpDown \u0005;
  internal Label \u000F;
  internal NumericUpDown \u0006;
  internal Label \u0010;
  internal NumericUpDown \u0007;
  internal Label \u0011;
  public Button btn_ok;
  internal Panel \u0003;
  internal Button \u0004;
  internal Panel \u0004;
  internal Button \u0005;
  internal Button \u0006;
  internal Label \u0012;
  internal TabPage \u0001;
  internal Button \u0007;
  internal Panel \u0005;
  internal CheckBox \u0003;
  internal Button \u0008;
  internal CheckBox \u0004;
  internal Button \u000E;
  internal CheckBox \u0005;
  internal Button \u000F;
  internal CheckBox \u0006;
  internal Button \u0010;
  internal CheckBox \u0007;
  internal Label \u0013;
  internal Button \u0011;
  internal Panel \u0006;
  internal Panel \u0007;
  internal Label \u0014;
  internal Button \u0012;
  internal NumericUpDown \u0008;
  internal Label \u0015;
  internal Panel \u0008;
  internal Label \u0016;
  internal TabControl \u0001;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal Label \u0017;
  internal NumericUpDown \u000E;
  internal CheckBox \u0008;
  internal CheckBox \u000E;
  internal Button \u0013;
  internal Panel \u000E;
  internal Label \u0018;
  internal RadioButton \u0008;
  internal RadioButton \u000E;
  internal Panel \u000F;
  internal RadioButton \u000F;
  internal Label \u0019;
  internal RadioButton \u0010;
  internal RadioButton \u0011;
  internal Button \u0014;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMConstantZ) this).Properties.Inited)
      return;
    ((F_MwTriMConstantZ) this).Properties.Inited = false;
    ((F_MwTriMConstantZ) this).Apply();
    ((F_MwTriMConstantZ) this).UpdateControlFromType();
    ((F_MwTriMConstantZ) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0014.Name)
    {
      F_MWTriMDynamicalHolderColl mdynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
      mdynamicalHolderColl.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      mdynamicalHolderColl.Init();
      int num = (int) mdynamicalHolderColl.ShowDialog();
      if (mdynamicalHolderColl.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(mdynamicalHolderColl.Par);
        mdynamicalHolderColl.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0013.Name)
    {
      F_MwTriMHeights fMwTriMheights = new F_MwTriMHeights();
      fMwTriMheights.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      fMwTriMheights.Init();
      int num = (int) fMwTriMheights.ShowDialog();
      if (fMwTriMheights.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(fMwTriMheights.Par);
        fMwTriMheights.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0012.Name)
    {
      F_MwTriMOffset fMwTriMoffset = new F_MwTriMOffset();
      fMwTriMoffset.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      fMwTriMoffset.Init();
      int num = (int) fMwTriMoffset.ShowDialog();
      if (fMwTriMoffset.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(fMwTriMoffset.Par);
        fMwTriMoffset.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0010.Name)
    {
      F_MwTriMRoughLink fMwTriMroughLink = new F_MwTriMRoughLink();
      fMwTriMroughLink.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      fMwTriMroughLink.Init();
      int num = (int) fMwTriMroughLink.ShowDialog();
      if (fMwTriMroughLink.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(fMwTriMroughLink.Par);
        fMwTriMroughLink.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0001.Name)
    {
      F_MwTriMRoughing fMwTriMroughing = new F_MwTriMRoughing();
      fMwTriMroughing.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      fMwTriMroughing.Init();
      int num = (int) fMwTriMroughing.ShowDialog();
      if (fMwTriMroughing.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(fMwTriMroughing.Par);
        fMwTriMroughing.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u000F.Name)
    {
      F_MwGaugeCheck fMwGaugeCheck = new F_MwGaugeCheck();
      fMwGaugeCheck.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      fMwGaugeCheck.Init();
      int num = (int) fMwGaugeCheck.ShowDialog();
      if (fMwGaugeCheck.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(fMwGaugeCheck.Par);
        fMwGaugeCheck.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0003.Name)
    {
      F_MwTriMAngleRange mwTriMangleRange = new F_MwTriMAngleRange();
      mwTriMangleRange.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      mwTriMangleRange.Init();
      int num = (int) mwTriMangleRange.ShowDialog();
      if (mwTriMangleRange.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(mwTriMangleRange.Par);
        mwTriMangleRange.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0002.Name)
    {
      F_MwTriMSurfaceQuality triMsurfaceQuality = new F_MwTriMSurfaceQuality();
      triMsurfaceQuality.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      triMsurfaceQuality.Init();
      int num = (int) triMsurfaceQuality.ShowDialog();
      if (triMsurfaceQuality.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(triMsurfaceQuality.Par);
        triMsurfaceQuality.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0008.Name)
    {
      F_MwTriMSilhouette mwTriMsilhouette = new F_MwTriMSilhouette();
      mwTriMsilhouette.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      mwTriMsilhouette.Init();
      int num = (int) mwTriMsilhouette.ShowDialog();
      if (mwTriMsilhouette.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(mwTriMsilhouette.Par);
        mwTriMsilhouette.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0005.Name)
    {
      F_MwTriMRoundCorner mwTriMroundCorner = new F_MwTriMRoundCorner();
      mwTriMroundCorner.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      mwTriMroundCorner.Init();
      int num = (int) mwTriMroundCorner.ShowDialog();
      if (mwTriMroundCorner.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(mwTriMroundCorner.Par);
        mwTriMroundCorner.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0006.Name)
    {
      F_MwTriMRestFinish mwTriMrestFinish = new F_MwTriMRestFinish();
      mwTriMrestFinish.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      mwTriMrestFinish.Init();
      int num = (int) mwTriMrestFinish.ShowDialog();
      if (mwTriMrestFinish.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(mwTriMrestFinish.Par);
        mwTriMrestFinish.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0007.Name)
    {
      F_MwTriM2dContainment triM2dContainment = new F_MwTriM2dContainment();
      triM2dContainment.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      triM2dContainment.Init();
      int num = (int) triM2dContainment.ShowDialog();
      if (triM2dContainment.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(triM2dContainment.Par);
        triM2dContainment.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0011.Name)
    {
      F_MwTriMUpDownAdvanced triMupDownAdvanced = new F_MwTriMUpDownAdvanced();
      triMupDownAdvanced.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      triMupDownAdvanced.Init();
      int num = (int) triMupDownAdvanced.ShowDialog();
      if (triMupDownAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(triMupDownAdvanced.Par);
        triMupDownAdvanced.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u000E.Name)
    {
      F_MwTriMUtility fMwTriMutility = new F_MwTriMUtility();
      fMwTriMutility.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      fMwTriMutility.Init();
      int num = (int) fMwTriMutility.ShowDialog();
      if (fMwTriMutility.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(fMwTriMutility.Par);
        fMwTriMutility.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMConstantZ) this).\u0011.Name)
    {
      F_MwTriMSpiralAdvanced triMspiralAdvanced = new F_MwTriMSpiralAdvanced();
      triMspiralAdvanced.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
      triMspiralAdvanced.Init();
      int num = (int) triMspiralAdvanced.ShowDialog();
      if (triMspiralAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMConstantZ) this).Par = new MachiningParams(triMspiralAdvanced.Par);
        triMspiralAdvanced.Dispose();
      }
    }
    if (!(control2.Name == ((F_MwTriMConstantZ) this).\u0015.Name))
      return;
    F_MwTriMDepthAdvanced triMdepthAdvanced = new F_MwTriMDepthAdvanced();
    triMdepthAdvanced.Par = new MachiningParams(((F_MwTriMConstantZ) this).Par);
    triMdepthAdvanced.Init();
    int num1 = (int) triMdepthAdvanced.ShowDialog();
    if (triMdepthAdvanced.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMConstantZ) this).Par = new MachiningParams(triMdepthAdvanced.Par);
    triMdepthAdvanced.Dispose();
  }
}
