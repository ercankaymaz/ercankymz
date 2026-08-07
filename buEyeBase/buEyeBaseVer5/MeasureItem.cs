// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MeasureItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

#nullable disable
namespace buEyeBaseVer5;

public class MeasureItem
{
  public double HoleOutsideDisX;
  public double HoleOutsideDisY;
  public double HoleAngle3Point;
  public double TappingDiameter;
  public double TappingPitch;
  public double TappingAdditional;

  public MeasureItem()
  {
    ((ShapeArray) this).Filter = (SortbuFilter) new MeasureData();
    ((ShapeArray) this).Option = (SortbuOptions) new CustomDataAdd();
    ((ShapeArray) this).CamData = (SortbuCamData) new CustomDataAdd();
    ((ShapeArray) this).ClosestPoint = (MostClosestPointOption) new SelectionOperation();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MeasureItem(SortbuSettings data)
  {
    ((ShapeArray) this).Filter = (SortbuFilter) new MeasureData();
    ((ShapeArray) this).Option = (SortbuOptions) new CustomDataAdd();
    ((ShapeArray) this).CamData = (SortbuCamData) new CustomDataAdd();
    ((ShapeArray) this).ClosestPoint = (MostClosestPointOption) new SelectionOperation();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ShapeArray) this).CamData = (SortbuCamData) new MachineConfigSettings(((ShapeArray) data).CamData);
    ((ShapeArray) this).Filter = (SortbuFilter) new CustomDataAdd(((ShapeArray) data).Filter);
    ((ShapeArray) this).Option = (SortbuOptions) new CustomDataAdd(((ShapeArray) data).Option);
  }
}
