// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelMode
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class jewelMode : buSerilization
{
  public jewelOperationModeType OperationMode = jewelOperationModeType.Spindle;
  public jewelCamModeType CamMode = jewelCamModeType.Contour3AX;
  public jewelCamOperationType CamOperation = jewelCamOperationType.Contour;
  public jewelCurveType FormMode = jewelCurveType.Flat;
  public CamOffsetType OffsetType = CamOffsetType.Center;
  public jewelMaterialType MaterialMode = jewelMaterialType.Ring;
  public geoArc ArcShapeData = new geoArc();
  public Pnt3D pntCamRotateCenter = new Pnt3D();
  public Pnt3D ArcCenter = new Pnt3D();
  public double RingRotateCenterX = 0.0;
  public double RingRotateCenterZ = 0.0;
  public double BraceletRotateCenterX = 0.0;
  public double BraceletRotateCenterZ = 0.0;
  public double SpindleSpeed = 15000.0;
  public double EngravingSpeed = 3000.0;
  public double DiamondCutSpeed1 = 3000.0;
  public double DiamondCutSpeed2 = 3000.0;
  public double LatheSpeed = 3000.0;
  public double LaserSpeed = 3000.0;
  public bool TangentCalculationMode = false;
  public bool SlideEnable = true;
  public double StepSafeDistance = 10.0;
  public bool StepZAbsoluteMode = true;
  public CamMoveUpType CamCoreMoveUpType = CamMoveUpType.Incremental;
  public double ExtraDepth = 0.0;
  public bool ResetCAxis = false;
  public int Stiffness = 5;
  public bool Mirror = false;
  public bool ConvexMachiningFor3Axis = false;
  public bool SyncMode = false;
  public double SyncRatio = 1.0;
  public bool ReadSurfaceEllipse = false;
  public bool BAxisFor3Axis = false;

  public jewelMode()
  {
  }

  public jewelMode(jewelMode data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }
}
