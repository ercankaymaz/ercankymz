// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleOffsetCalculationParameters
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class marbleOffsetCalculationParameters
{
  public double ShapeTriangleCrossAngle;
  public double ShapeTrapezLength1;
  public double ShapeTrapezLength2;
  public double ShapeTrapezHeight;
  public double ShapeTrapezTopAngle;
  public double ShapeTrapezBottomAngle;
  public double ShapeTrapezLeftAngle;
  public double ShapeTrapezRightAngle;
  public double ShapeSlotWidth;
  public double ShapeSlotHeight;
  public double ShapeSlotAngle;
  public double ShapeArcPieRadius;
  public double ShapeArcPieSweepAngle;

  public override string ToString()
  {
    return "ToolLenCalc :" + ((MarbleRuntimeSettings) this).OnlyDrawing.ToString();
  }

  public abstract void m001ECF();
}
