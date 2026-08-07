// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillMove : buSerilization5
{
  public bool ContiniousTangent;
  public double PatternDistancesWidth;
  public double PatternDistancesHeight;
  public double PartDistances;
  public double EntryFeed;
  public double CuttingFeed;
  public double LeaveFeed;
  public double CRotationFeed;
  public double ConnectionFeed;
  public double BlockSpace;
  public double LeadInLength;
  public double LeadOutLength;
  public FoamSequenceHor SequenceHorizontal;
  public FoamSequenceVer SequenceVertical;
  public UpToDownType ZDirection;
  public bool ComplateClosedDrawingAfterFirstSelect;
  public bool RotateCBeforeCutting;
  public bool FromFileKeepRatio;
  public bool NonLinearCAxis;
  public bool LeaveAlwaysFromStart;
  public double LeaveAlwaysZeroZOffsetFromBlockHeight;
  public bool MoveZUpPosition;
  public bool Draw3D;
  public bool UseG1InsteadOfG0;
  public bool UseCRotationAsG0Always;
  public bool UseMultiColor;
  public bool CheckFoamSize;
  public bool CheckMachineSize;
  public bool UseRadiusFeedTable;
  public bool UseLengthFeedTable;
  public bool ShowInfoAtGCodes;
  public double CAngleOffset;
  public double MachineInitialAngle;
  public double MachineLimitX;
  public double MachineLimitY;
  public double MachineLimitZ;
  public double MachineLimitMinX;
  public double MachineLimitMinY;
  public double MachineLimitMinZ;
  public double MachineG0Speed;
  public double MachineG0TangentSpeed;
  public string pathFromFile;
  public int FoamBaseTransparency;
  public double OnlineBorderDrawOffset;
  public Color FoamBaseColor;
  public Color MarkColor;
  public Color MarkLastColor;
  public Color SortUpperColor;
  public Color SortCutColor;
  public Color LeadInColor;
  public Color LeadOutColor;

  public DrillMove()
  {
    ((QuiltingProgramSettings) this).ItemName = "";
    ((QuiltingProgramSettings) this).FileName = "";
    ((buDrillCalc) this).FileNameFull = "";
    ((buDrillCalc) this).isError = false;
    ((buDrillCalc) this).isGCodeCreated = false;
    ((buDrillCalc) this).Transparency = 120;
    ((DrillSplitedItems) this).MinPoint = new Point3D();
    ((DrillSplitedItems) this).MaxPoint = new Point3D();
    ((DrillSplitedItems) this).entOriginal = (Entity) null;
    ((DrillSplitedItems) this).entTessellenation = (Entity) null;
    ((DrillSplitedItems) this).Layers = new List<Printer3DLayer>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillMove(Printer3DJob data)
  {
    ((QuiltingProgramSettings) this).ItemName = "";
    ((QuiltingProgramSettings) this).FileName = "";
    ((buDrillCalc) this).FileNameFull = "";
    ((buDrillCalc) this).isError = false;
    ((buDrillCalc) this).isGCodeCreated = false;
    ((buDrillCalc) this).Transparency = 120;
    ((DrillSplitedItems) this).MinPoint = new Point3D();
    ((DrillSplitedItems) this).MaxPoint = new Point3D();
    ((DrillSplitedItems) this).entOriginal = (Entity) null;
    ((DrillSplitedItems) this).entTessellenation = (Entity) null;
    ((DrillSplitedItems) this).Layers = new List<Printer3DLayer>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null)
    {
      if (this.GetType() == CopiedClass.GetType())
      {
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
      ((DrillSplitedItems) this).MinPoint = new Point3D(((DrillSplitedItems) data).MinPoint.X, ((DrillSplitedItems) data).MinPoint.Y, ((DrillSplitedItems) data).MinPoint.Z);
      ((DrillSplitedItems) this).MaxPoint = new Point3D(((DrillSplitedItems) data).MaxPoint.X, ((DrillSplitedItems) data).MaxPoint.Y, ((DrillSplitedItems) data).MaxPoint.Z);
      for (int index = 0; index <= ((DrillSplitedItems) data).Layers.Count - 1; ++index)
        ((DrillSplitedItems) this).Layers.Add((Printer3DLayer) new DrillMove(((DrillSplitedItems) data).Layers[index]));
    }
    if (((DrillSplitedItems) data).entOriginal != null)
      ((DrillSplitedItems) this).entOriginal = buVector5.CopyEntities(((DrillSplitedItems) data).entOriginal);
    if (((DrillSplitedItems) data).entTessellenation == null)
      return;
    ((DrillSplitedItems) this).entTessellenation = buVector5.CopyEntities(((DrillSplitedItems) data).entTessellenation);
  }

  public override string ToString() => ((QuiltingProgramSettings) this).ItemName.ToString();

  public abstract void m001B5E();

  public DrillMove()
  {
    ((DrillSplitedItems) this).Enable = true;
    ((DrillJob) this).LevelZ = 0.0;
    ((DrillJob) this).entitiesInfill = new List<buEntity>();
    ((DrillJob) this).entitiesOffsetedSlices = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillMove(Printer3DLayer data)
  {
    ((DrillSplitedItems) this).Enable = true;
    ((DrillJob) this).LevelZ = 0.0;
    ((DrillJob) this).entitiesInfill = new List<buEntity>();
    ((DrillJob) this).entitiesOffsetedSlices = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
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
    buRadialDim.Copy(((DrillJob) data).entitiesInfill, ref ((DrillJob) this).entitiesInfill);
    buRadialDim.Copy(((DrillJob) data).entitiesOffsetedSlices, ref ((DrillJob) this).entitiesOffsetedSlices);
  }

  public override string ToString() => ((DrillJob) this).LevelZ.ToString();

  public DrillMove()
  {
    ((DrillJob) this).ShowOperationButton = false;
    ((DrillJob) this).SliceCount = 10;
    ((DrillJob) this).SliceStep = 20.0;
    ((DrillJob) this).InFill = true;
    ((DrillJob) this).InFillConnect = true;
    ((DrillJob) this).Simplify = true;
    ((DrillJob) this).ZSpiralMove = true;
    ((DrillJob) this).UseSpline = true;
    ((DrillJob) this).OffsetXY = 5.0;
    ((DrillJob) this).NozzleDiameter = 10.0;
    ((DrillJob) this).FeedSpeed = 50.0;
    ((DrillJob) this).PlungeSpeed = 10.0;
    ((DrillJob) this).TopHeight = 0.0;
    ((DrillJob) this).FilletRadius = 4.0;
    ((DrillJob) this).FilletLimitMaxAngle = 179.0;
    ((DrillJob) this).FilletLimitMinAngle = 150.0;
    ((DrillJob) this).SliceType = Printer3DSliceType.Step;
    ((DrillJob) this).SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Bezeir;
    ((DrillJob) this).SpiralConnectionDT = 0.2;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillMove(Printer3DSettings data)
  {
    ((DrillJob) this).ShowOperationButton = false;
    ((DrillJob) this).SliceCount = 10;
    ((DrillJob) this).SliceStep = 20.0;
    ((DrillJob) this).InFill = true;
    ((DrillJob) this).InFillConnect = true;
    ((DrillJob) this).Simplify = true;
    ((DrillJob) this).ZSpiralMove = true;
    ((DrillJob) this).UseSpline = true;
    ((DrillJob) this).OffsetXY = 5.0;
    ((DrillJob) this).NozzleDiameter = 10.0;
    ((DrillJob) this).FeedSpeed = 50.0;
    ((DrillJob) this).PlungeSpeed = 10.0;
    ((DrillJob) this).TopHeight = 0.0;
    ((DrillJob) this).FilletRadius = 4.0;
    ((DrillJob) this).FilletLimitMaxAngle = 179.0;
    ((DrillJob) this).FilletLimitMinAngle = 150.0;
    ((DrillJob) this).SliceType = Printer3DSliceType.Step;
    ((DrillJob) this).SpiralConnection = Printer3DSpiralNextLEvelConnectionType.Bezeir;
    ((DrillJob) this).SpiralConnectionDT = 0.2;
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
}
