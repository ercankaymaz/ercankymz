// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_AnalyseSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_AnalyseSettings : Form
{
  public bool DeleteIfSameEntities;
  public bool BreakArcIfGreat180Degree;
  public SortingFirstCatchRulesType SortFirstCatchRule;
  public double SimulationDevideLength;
  public int SimulationStep;
  public double FilletRadius;
  public double ChamferLength;
  public double OffsetValue;
  public double EqualDistance;
  public double RotateAngle;
  public double ScaleRatio;
  public double ExtendLength;
  public double GridMaxValue;
  public double LastRotateAngle;
  public double TurnOverDistance;
  public int PolygonSide;
  public double KeyHoleLength;
  public double KeyHoleHeadDiameter;
  public double KeyHoleWidth;
  public double KeyHoleAngle;
  public HorizontalVertical LastMirrorType;
  public bool ShowDimension;
  public bool ShowContrraint;

  public bool IsLayerAvailable(LayerKeyedCollection Layers, Layer refLayer)
  {
    bool flag = false;
    for (int index = 0; index <= Layers.Count - 1; ++index)
    {
      if (Layers[index].Name == refLayer.Name)
      {
        flag = true;
        index = Layers.Count;
      }
    }
    return flag;
  }

  public bool IsLayerNameAvailable(LayerKeyedCollection Layers, string LayerName)
  {
    bool flag = false;
    for (int index = 0; index <= Layers.Count - 1; ++index)
    {
      if (Layers[index].Name == LayerName)
      {
        flag = true;
        index = Layers.Count;
      }
    }
    return flag;
  }

  public bool IsBlockAvailable(BlockKeyedCollection Blocks, Block refBlock)
  {
    bool flag = false;
    for (int index = 0; index <= Blocks.Count - 1; ++index)
    {
      if (Blocks[index].Name == refBlock.Name)
      {
        flag = true;
        index = Blocks.Count;
      }
    }
    return flag;
  }

  public bool IsMaterialAvailable(MaterialKeyedCollection Materials, Material refMaterial)
  {
    bool flag = false;
    for (int index = 0; index <= Materials.Count - 1; ++index)
    {
      if (Materials[index].Name == refMaterial.Name)
      {
        flag = true;
        index = Materials.Count;
      }
    }
    return flag;
  }

  public bool IsTextStyleAvailable(TextStyleKeyedCollection TextStyles, TextStyle refLabel)
  {
    bool flag = false;
    for (int index = 0; index <= TextStyles.Count - 1; ++index)
    {
      if (TextStyles[index].Name == refLabel.Name)
      {
        flag = true;
        index = TextStyles.Count;
      }
    }
    return flag;
  }

  public bool isPointInsideEntity(ICurve refCurve, Point3D refPoint, double Resolution)
  {
    double t;
    refCurve.ClosestPointTo(refPoint, out t);
    Point3D point3D = refCurve.PointAt(t);
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    return t >= refCurve.Domain.t0 & t <= refCurve.Domain.t1 && !(buConversion5.EQ(t, refCurve.Domain.t0, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, refCurve.StartPoint, Resolution)) && !(buConversion5.EQ(t, refCurve.Domain.t1, Resolution) & !buConversion5.\u003C\u003Ec.EQ(refPoint, refCurve.EndPoint, Resolution)) && buConversion5.\u003C\u003Ec.EQ(point3D, refPoint, Resolution);
  }
}
