// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleConvexConcaveCalculationPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class marbleConvexConcaveCalculationPars
{
  public double ShapeArcPieAngle;
  public double ShapeShipNoseWidth;
  public double ShapeShipNoseHeight;
  public double ShapeShipNoseTopAngle;
  public double ShapeShipNoseBottomAngle;
  public double ShapeShipNoseLeftAngle;
  public double ShapeShipNoseRightAngle;
  public double ShapeShipNoseArcXDistance;
  public double ShapeShipNoseArcYDistance;
  public double ShapeShipNoseRadius;
  public double ShapeArcBigRadius;
  public double ShapeArcSmallRadius;
  public double ShapeArcSweepAngle;

  public marbleConvexConcaveCalculationPars()
  {
    ((MarbleRuntimeSettings) this).ToolBaseLength = 0.0;
    ((MarbleRuntimeSettings) this).checkToolLength = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleConvexConcaveCalculationPars(ToolCheckOption data)
  {
    ((MarbleRuntimeSettings) this).ToolBaseLength = 0.0;
    ((MarbleRuntimeSettings) this).checkToolLength = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return "checkToolLength :" + ((MarbleRuntimeSettings) this).checkToolLength.ToString();
  }

  public abstract void m001ED3();
}
