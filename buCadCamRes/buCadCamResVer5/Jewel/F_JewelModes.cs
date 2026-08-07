// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Jewel.F_JewelModes
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buMW;
using buMW.CamForms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using ns8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Jewel;

public class F_JewelModes : Form
{
  public JewelMode CurrentModePars = new JewelMode();
  public FormProperties PropertiesForm = new FormProperties();
  public static List<string> Captions = new List<string>();
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  public Button btn_3axwireframe;
  public Button btn_4axwireframe;
  public Button btn_3axwireframerough;
  public Button btn_3axtrimeshrough;
  public Button btn_3axtrimeshparalel;
  public Button btn_3axtrimeshconstantz;
  public Button btn_3axdrill;
  internal System.Windows.Forms.Label label_0;
  internal TextBox textBox_0;
  internal TextBox textBox_1;
  internal System.Windows.Forms.Label label_1;

  public F_JewelModes() => Class5.smethod_201(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.textBox_0.Text = this.CurrentModePars.Name;
    this.textBox_1.Text = this.CurrentModePars.Prepared;
    this.ControlUpdate();
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_JewelModes.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      this.Apply();
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
    if (control2.Name == this.btn_3axwireframe.Name)
    {
      F_WFContour fWfContour = new F_WFContour()
      {
        mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamWFContourPars.Units, 0)
      };
      fWfContour.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamWFContourPars.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamWFContourPars, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamWFContourPars);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        this.CurrentModePars.varMWCamWFContourPars.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, this.CurrentModePars.varMWCamWFContourPars);
        this.CurrentModePars.varbuCamWFContourPars = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (control2.Name == this.btn_3axwireframerough.Name)
    {
      F_WFRough fWfRough = new F_WFRough()
      {
        mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamWFContourPars.Units, 0)
      };
      fWfRough.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamWFContourPars.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamWFContourPars, fWfRough.mwCamParameter);
      fWfRough.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamWFContourPars);
      fWfRough.Init();
      int num = (int) fWfRough.ShowDialog();
      if (fWfRough.PropertiesForm.Result == DialogResult.OK)
      {
        this.CurrentModePars.varMWCamWFContourPars.MachParam = new MachiningParams(fWfRough.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfRough.mwCamParameter, this.CurrentModePars.varMWCamWFContourPars);
        this.CurrentModePars.varbuCamWFContourPars = new camParameters5(fWfRough.buCamParameter);
      }
    }
    if (control2.Name == this.btn_4axwireframe.Name)
    {
      F_WFContour4AX fWfContour4Ax = new F_WFContour4AX()
      {
        mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamWFContour4XPars.Units, 0)
      };
      fWfContour4Ax.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamWFContour4XPars.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamWFContour4XPars, fWfContour4Ax.mwCamParameter);
      fWfContour4Ax.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamWFContour4XPars);
      fWfContour4Ax.Init();
      int num = (int) fWfContour4Ax.ShowDialog();
      if (fWfContour4Ax.PropertiesForm.Result == DialogResult.OK)
      {
        this.CurrentModePars.varMWCamWFContour4XPars.MachParam = new MachiningParams(fWfContour4Ax.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour4Ax.mwCamParameter, this.CurrentModePars.varMWCamWFContour4XPars);
        this.CurrentModePars.varbuCamWFContour4XPars = new camParameters5(fWfContour4Ax.buCamParameter);
      }
    }
    if (control2.Name == this.btn_3axtrimeshrough.Name)
    {
      F_TriMeshRough fTriMeshRough = new F_TriMeshRough()
      {
        mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamMeshRoughPars.Units, 0)
      };
      fTriMeshRough.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamMeshRoughPars.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamMeshRoughPars, fTriMeshRough.mwCamParameter);
      fTriMeshRough.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamMeshRoughPars);
      fTriMeshRough.Init();
      int num = (int) fTriMeshRough.ShowDialog();
      if (fTriMeshRough.PropertiesForm.Result == DialogResult.OK)
      {
        this.CurrentModePars.varMWCamMeshRoughPars.MachParam = new MachiningParams(fTriMeshRough.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fTriMeshRough.mwCamParameter, this.CurrentModePars.varMWCamMeshRoughPars);
        this.CurrentModePars.varbuCamMeshRoughPars = new camParameters5(fTriMeshRough.buCamParameter);
      }
    }
    if (control2.Name == this.btn_3axtrimeshparalel.Name)
    {
      F_TriMeshParallelCut triMeshParallelCut = new F_TriMeshParallelCut()
      {
        mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamMeshParalelPars.Units, 0)
      };
      triMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamMeshParalelPars.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamMeshParalelPars, triMeshParallelCut.mwCamParameter);
      triMeshParallelCut.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamMeshParallelPars);
      triMeshParallelCut.Init();
      int num = (int) triMeshParallelCut.ShowDialog();
      if (triMeshParallelCut.PropertiesForm.Result == DialogResult.OK)
      {
        this.CurrentModePars.varMWCamMeshParalelPars.MachParam = new MachiningParams(triMeshParallelCut.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(triMeshParallelCut.mwCamParameter, this.CurrentModePars.varMWCamMeshParalelPars);
        this.CurrentModePars.varbuCamMeshParallelPars = new camParameters5(triMeshParallelCut.buCamParameter);
      }
    }
    if (control2.Name == this.btn_3axtrimeshconstantz.Name)
    {
      F_TriMeshParallelCut triMeshParallelCut = new F_TriMeshParallelCut()
      {
        mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamMeshContantZPars.Units, 0)
      };
      triMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamMeshContantZPars.MachParam);
      buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamMeshContantZPars, triMeshParallelCut.mwCamParameter);
      triMeshParallelCut.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamMeshConstantZPars);
      triMeshParallelCut.Init();
      int num = (int) triMeshParallelCut.ShowDialog();
      if (triMeshParallelCut.PropertiesForm.Result == DialogResult.OK)
      {
        this.CurrentModePars.varMWCamMeshContantZPars.MachParam = new MachiningParams(triMeshParallelCut.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(triMeshParallelCut.mwCamParameter, this.CurrentModePars.varMWCamMeshContantZPars);
        this.CurrentModePars.varbuCamMeshConstantZPars = new camParameters5(triMeshParallelCut.buCamParameter);
      }
    }
    if (!(control2.Name == this.btn_3axdrill.Name))
      return;
    F_DrillLine fDrillLine = new F_DrillLine()
    {
      mwCamParameter = new GeoLib(this.CurrentModePars.varMWCamDrillPars.Units, 0)
    };
    fDrillLine.mwCamParameter.MachParam = new MachiningParams(this.CurrentModePars.varMWCamDrillPars.MachParam);
    buMWCalcs.CopyGeoLibProperties(this.CurrentModePars.varMWCamDrillPars, fDrillLine.mwCamParameter);
    fDrillLine.buCamParameter = new camParameters5(this.CurrentModePars.varbuCamDrillPars);
    fDrillLine.Init();
    int num1 = (int) fDrillLine.ShowDialog();
    if (fDrillLine.PropertiesForm.Result != DialogResult.OK)
      return;
    this.CurrentModePars.varMWCamDrillPars.MachParam = new MachiningParams(fDrillLine.mwCamParameter.MachParam);
    buMWCalcs.CopyGeoLibProperties(fDrillLine.mwCamParameter, this.CurrentModePars.varMWCamDrillPars);
    this.CurrentModePars.varbuCamDrillPars = new camParameters5(fDrillLine.buCamParameter);
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.CurrentModePars.Name = this.textBox_0.Text;
    this.CurrentModePars.Prepared = this.textBox_1.Text;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
