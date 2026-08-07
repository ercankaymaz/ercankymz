// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Jewel.JewelMode
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buEyeBaseVer5;
using ModuleWorks;

#nullable disable
namespace buCadCamResVer5.Jewel;

public class JewelMode
{
  public string Name = "Mode";
  public string Prepared = "Noname";
  public GeoLib varMWCamMeshRoughPars = (GeoLib) null;
  public camParameters5 varbuCamMeshRoughPars = (camParameters5) null;
  public GeoLib varMWCamMeshParalelPars = (GeoLib) null;
  public camParameters5 varbuCamMeshParallelPars = (camParameters5) null;
  public GeoLib varMWCamMeshContantZPars = (GeoLib) null;
  public camParameters5 varbuCamMeshConstantZPars = (camParameters5) null;
  public GeoLib varMWCamWFPocketPars = (GeoLib) null;
  public camParameters5 varbuCamWFPocketPars = (camParameters5) null;
  public GeoLib varMWCamWFContourPars = (GeoLib) null;
  public camParameters5 varbuCamWFContourPars = (camParameters5) null;
  public GeoLib varMWCamWFContour4XPars = (GeoLib) null;
  public camParameters5 varbuCamWFContour4XPars = (camParameters5) null;
  public GeoLib varMWCamDrillPars = (GeoLib) null;
  public camParameters5 varbuCamDrillPars = (camParameters5) null;

  public JewelMode()
  {
  }

  public JewelMode(JewelMode data)
  {
    this.Name = data.Name;
    this.Prepared = data.Prepared;
    this.varbuCamDrillPars = new camParameters5(data.varbuCamDrillPars);
    this.varbuCamMeshConstantZPars = new camParameters5(data.varbuCamMeshConstantZPars);
    this.varbuCamMeshParallelPars = new camParameters5(data.varbuCamMeshParallelPars);
    this.varbuCamMeshRoughPars = new camParameters5(data.varbuCamMeshRoughPars);
    this.varbuCamWFContour4XPars = new camParameters5(data.varbuCamWFContour4XPars);
    this.varbuCamWFContourPars = new camParameters5(data.varbuCamWFContourPars);
    this.varbuCamWFPocketPars = new camParameters5(data.varbuCamWFPocketPars);
  }

  public JewelMode(
    camParameters5 buDrill,
    camParameters5 buWF3XContour,
    camParameters5 buWF4XContour,
    camParameters5 buWFRough,
    camParameters5 buTriMeshRough,
    camParameters5 buTriMeshParalel,
    camParameters5 buTriMeshConstantZ,
    GeoLib mwDrill,
    GeoLib mwWF3XContour,
    GeoLib mwWF4XContour,
    GeoLib mwWFRough,
    GeoLib mwTriMeshRough,
    GeoLib mwTriMeshParalel,
    GeoLib mwTriMeshConstantZ)
  {
    this.varbuCamDrillPars = new camParameters5(buDrill);
    this.varbuCamMeshConstantZPars = new camParameters5(buTriMeshConstantZ);
    this.varbuCamMeshParallelPars = new camParameters5(buTriMeshParalel);
    this.varbuCamMeshRoughPars = new camParameters5(buTriMeshRough);
    this.varbuCamWFContour4XPars = new camParameters5(buWF4XContour);
    this.varbuCamWFContourPars = new camParameters5(buWF3XContour);
    this.varbuCamWFPocketPars = new camParameters5(buWFRough);
  }
}
