// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Editor.ProjectionInfo
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using devDept.Eyeshot.Entities;
using System.Drawing;

#nullable disable
namespace buCadCamResVer5.Editor;

public abstract class ProjectionInfo
{
  public static Color ProjectedCurvesColor { get; set; } = Color.BlueViolet;

  public static void SetAttributesProjectedCurve(Entity entity, float thickness)
  {
    entity.ColorMethod = colorMethodType.byEntity;
    entity.Color = ProjectionInfo.ProjectedCurvesColor;
    entity.LineWeightMethod = colorMethodType.byEntity;
    entity.LineWeight = thickness;
  }
}
