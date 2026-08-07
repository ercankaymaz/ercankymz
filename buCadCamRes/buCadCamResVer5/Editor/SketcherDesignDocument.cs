// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.SketcherDesignDocument
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using devDept.Eyeshot;

#nullable disable
namespace buCadCamResVer5.Editor;

public class SketcherDesignDocument : DesignDocument
{
  public override RegenParams GetVisualRefinement()
  {
    RegenParams visualRefinement = base.GetVisualRefinement();
    return new RegenParams(visualRefinement.Deviation / 10.0, visualRefinement.Angle);
  }
}
