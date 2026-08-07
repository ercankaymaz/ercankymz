// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buDrillCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buDrillCalc
{
  public string FileNameFull;
  public bool isError;
  public bool isGCodeCreated;
  public int Transparency;

  public Design DoNotHighlight(Entity e, Design design1)
  {
    e.Color = SewingSettings.originalColors[e];
    if (e is BlockReference blockReference)
    {
      Block block = design1.Blocks[blockReference.BlockName];
      if (block != null)
      {
        foreach (Entity entity in (EyeshotCollection<Entity>) block.Entities)
          this.DoNotHighlight(entity, design1);
      }
    }
    return design1;
  }

  public Design PipeProgressAll(Design design1, List<BendingLRAMaterialData> BendingList)
  {
    SewingSettings._sw.Start();
    int num1 = 0;
    ++SewingSettings.doneZSteps;
    SewingSettings._numOfFileBlocks = 1;
    if (design1.Blocks.Count > 1)
    {
      while (design1.Blocks.Count > SewingSettings._numOfFileBlocks)
      {
        if (design1.Blocks.Count > 1)
          design1.Blocks.RemoveAt(design1.Blocks.Count - 1);
      }
    }
    while (design1.Entities.Count > SewingSettings._numOfFileEntities & design1.Entities.Count > 0)
      design1.Entities.RemoveAt(design1.Entities.Count - 1);
    SewingSettings._surfList.Clear();
    SewingSettings._straightPartCounter = 0;
    SewingTempVars._bendPartCounter = 0;
    for (int index = 0; index <= BendingList.Count - 1; ++index)
    {
      if (((FoamWaveShapeArgs) BendingList[index]).Length > 0.0)
        design1 = ((buQuilting) this).AddStraight(((FoamWaveShapeArgs) BendingList[index]).Length, design1);
      if (((FoamWaveShapeArgs) BendingList[index]).Rotation != 0.0)
        ((QuiltingRuntimeSettings) this).RotatePipe(((FoamWaveShapeArgs) BendingList[index]).Rotation / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
      if (((FoamWaveShapeArgs) BendingList[index]).Angle != 0.0)
        design1 = ((FoamWaveShapeArgs) BendingList[index]).Angle <= 0.0 ? ((QuiltingRuntimeSettings) this).AddTurn(((FoamWaveShapeArgs) BendingList[index]).Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, ((FoamWaveShapeArgs) BendingList[index]).Radius, 0.0), design1) : ((QuiltingRuntimeSettings) this).AddTurn(((FoamWaveShapeArgs) BendingList[index]).Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, ((FoamWaveShapeArgs) BendingList[index]).Radius, 0.0), design1);
    }
    if (SewingSettings._pipeTotalLength > SewingSettings._excecutionPipe && num1 == BendingList.Count - 1)
      SewingSettings._excecutionPipe = SewingSettings._pipeTotalLength;
    foreach (Entity surf in SewingSettings._surfList)
    {
      surf.Rotate(Math.PI, Vector3D.AxisX, Point3D.Origin);
      surf.Translate((double) SewingPickType.OffsetX, (double) SewingCodeDef.OffsetY);
    }
    Block block = new Block("pipe");
    int num2;
    for (num2 = 1; num2 <= SewingSettings._straightPartCounter; ++num2)
    {
      BlockReference blockReference = new BlockReference(SewingCodeDef.StraightBlockName + num2.ToString());
      block.Entities.Add((Entity) blockReference);
    }
    for (num2 = 1; num2 <= SewingTempVars._bendPartCounter; ++num2)
    {
      BlockReference blockReference = new BlockReference(SewingSelectedPoint.BendBlockName + num2.ToString());
      block.Entities.Add((Entity) blockReference);
    }
    design1.Blocks.Add(block);
    BlockReference blockReference1 = new BlockReference("pipe");
    design1.Entities.Add((Entity) blockReference1);
    SewingSettings._sw.Stop();
    design1.Entities.Regen();
    design1.ZoomFit();
    design1.Invalidate();
    return design1;
  }

  public Design PipeProgress1(
    Design design1,
    ref int rowIndex,
    List<BendingLRAMaterialData> BendingList)
  {
    SewingSettings._sw.Start();
    double num1 = 0.0;
    ++SewingSettings.doneZSteps;
    while (design1.Blocks.Count > SewingSettings._numOfFileBlocks)
      design1.Blocks.RemoveAt(design1.Blocks.Count - 1);
    while (design1.Entities.Count > SewingSettings._numOfFileEntities & design1.Entities.Count > 0)
      design1.Entities.RemoveAt(design1.Entities.Count - 1);
    SewingSettings._surfList.Clear();
    SewingSettings._straightPartCounter = 0;
    SewingTempVars._bendPartCounter = 0;
    while (num1 < SewingSettings._excecutionPipe)
    {
      if (SewingSettings._excecutionPipe >= num1 + ((FoamWaveShapeArgs) BendingList[rowIndex]).Length)
      {
        design1 = ((buQuilting) this).AddStraight(((FoamWaveShapeArgs) BendingList[rowIndex]).Length, design1);
        num1 += ((FoamWaveShapeArgs) BendingList[rowIndex]).Length;
        if (SewingSettings._excecutionPipe - num1 < (double) SewingPickType.PipeExecStep)
          SewingSettings._excecutionPipe = num1;
        if (SewingSettings._excecutionPipe > num1)
        {
          ((QuiltingRuntimeSettings) this).RotatePipe(((FoamWaveShapeArgs) BendingList[rowIndex]).Rotation / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
        }
        else
        {
          if (((FoamWaveShapeArgs) BendingList[rowIndex]).Rotation < 0.0)
            --SewingSettings.doneZSteps;
          else
            ++SewingSettings.doneZSteps;
          double num2 = (double) (SewingSettings.doneZSteps * SewingPickType.StepZ);
          if (num2 >= ((FoamWaveShapeArgs) BendingList[rowIndex]).Rotation & num2 > 0.0 | num2 <= ((FoamWaveShapeArgs) BendingList[rowIndex]).Rotation & num2 < 0.0)
          {
            num2 = ((FoamWaveShapeArgs) BendingList[rowIndex]).Rotation;
            SewingSettings.doneZSteps = 0;
          }
          else
            SewingSettings._excecutionPipe -= (double) SewingPickType.PipeExecStep;
          ((QuiltingRuntimeSettings) this).RotatePipe(num2 / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
        }
        if (SewingSettings._excecutionPipe >= num1 + ((QuiltingProgramSettings) this).CurveUnbending(rowIndex, BendingList))
        {
          if (((FoamWaveShapeArgs) BendingList[rowIndex]).Angle > 0.0)
          {
            design1 = ((QuiltingRuntimeSettings) this).AddTurn(((FoamWaveShapeArgs) BendingList[rowIndex]).Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, ((FoamWaveShapeArgs) BendingList[rowIndex]).Radius, 0.0), design1);
            num1 += ((QuiltingProgramSettings) this).CurveUnbending(rowIndex, BendingList);
          }
          if (rowIndex == SewingSettings._pipeRowQuantity - 1)
            break;
        }
        else
        {
          double mm = SewingSettings._excecutionPipe - num1;
          if (mm > 0.0)
          {
            design1 = ((QuiltingRuntimeSettings) this).AddTurn(((QuiltingProgramSettings) this).AnglePortion(mm, rowIndex, BendingList) / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, ((FoamWaveShapeArgs) BendingList[rowIndex]).Radius, 0.0), design1);
            num1 += mm;
          }
        }
      }
      else
      {
        design1 = ((buQuilting) this).AddStraight(SewingSettings._excecutionPipe - num1, design1);
        double num3 = num1 + (SewingSettings._excecutionPipe - num1);
        break;
      }
    }
    if (SewingSettings._pipeTotalLength > SewingSettings._excecutionPipe)
    {
      design1 = ((buQuilting) this).AddStraightBack(SewingSettings._pipeTotalLength - SewingSettings._excecutionPipe, design1);
      if (rowIndex == SewingSettings._pipeRowQuantity - 1)
        SewingSettings._excecutionPipe = SewingSettings._pipeTotalLength;
    }
    foreach (Entity surf in SewingSettings._surfList)
    {
      surf.Rotate(Math.PI, Vector3D.AxisX, Point3D.Origin);
      surf.Translate((double) SewingPickType.OffsetX, (double) SewingCodeDef.OffsetY);
    }
    Block block1 = new Block("pipe");
    int num4;
    for (num4 = 1; num4 <= SewingSettings._straightPartCounter; ++num4)
    {
      BlockReference blockReference = new BlockReference(SewingCodeDef.StraightBlockName + num4.ToString());
      block1.Entities.Add((Entity) blockReference);
    }
    for (num4 = 1; num4 <= SewingTempVars._bendPartCounter; ++num4)
    {
      BlockReference blockReference = new BlockReference(SewingSelectedPoint.BendBlockName + num4.ToString());
      block1.Entities.Add((Entity) blockReference);
    }
    design1.Blocks.Add(block1);
    BlockReference blockReference1 = new BlockReference("pipe");
    design1.Entities.Add((Entity) blockReference1);
    try
    {
      BlockReference blockReference2 = new BlockReference(SewingSelectedPoint.StraightbackBlockName);
      block1.Entities.Add((Entity) blockReference2);
    }
    catch
    {
    }
    if (SewingSettings._excecutionPipe == SewingSettings._pipeTotalLength)
    {
      ((FoamCalcVars) this).\u0001.Enabled = false;
      SewingSettings._sw.Stop();
    }
    else
      ((FoamCalcVars) this).\u0001.Enabled = true;
    List<Entity> list = new List<Entity>();
    Block block2 = new Block(SewingSelectedPoint.MachineBlockName);
    foreach (int machineCollisionEntity in SewingSettings.machineCollisionEntities)
      block2.Entities.Add(design1.Entities[machineCollisionEntity]);
    BlockReference blockReference3 = new BlockReference(SewingSelectedPoint.MachineBlockName);
    design1.Blocks.Add(block2);
    list.Add((Entity) blockReference3);
    list.Add(design1.Entities[design1.Entities.Count - 1]);
    if (((SewingDevideOptions) FoamCalcVars.varPipeBendingProgramSettings).CollisionCheck)
    {
      SewingSettings._cd = new CollisionDetection((IList<Entity>) list, design1.Blocks, SewingSettings._firstOnly, SewingSelectedPoint._checkMethod);
      SewingSettings._cd.DoWork();
      if ((SewingSettings._cd.Result == null ? 0 : (SewingSettings._cd.Result.Length != 0 ? 1 : 0)) != 0)
      {
        SewingSettings._entityCollisionIndex = ((QuiltingProgramSettings) this).GetCollisionIndex(design1);
        SewingSettings.collidedEntities.Add(design1.Entities[SewingSettings._entityCollisionIndex]);
        design1.Entities[SewingSettings._entityCollisionIndex].ColorMethod = colorMethodType.byEntity;
        ((QuiltingProgramSettings) this).Highlight(design1.Entities[SewingSettings._entityCollisionIndex], SewingSettings.collisionColor, design1);
        ((FoamCalcVars) this).\u0001.Enabled = false;
        ((FoamCalcVars) this).\u0002.Enabled = true;
        SewingSettings._sw.Stop();
      }
    }
    SewingSettings._sw.Stop();
    design1.Entities.Regen();
    design1.Invalidate();
    return design1;
  }

  static buDrillCalc()
  {
    FoamCalcVars.UnitLength = LengthUnit.mm;
    FoamCalcVars.UnitsSpeed = SpeedUnit.mmPerSec;
    FoamCalcVars.LangPipeBendStatus = new List<string>();
    FoamCalcVars.LangPipeBendMessage = new List<string>();
    FoamCalcVars.LangPipeBendCaptions = new List<string>();
    FoamCalcVars.LangPipeBendCommands = new List<string>();
    FoamCalcVars.EntityID = 1;
    FoamCalcVars.varPipeBendingProgramSettings = (PipeBendingProgramSettings) new DrillCalcItem();
    FoamCalcVars.varTemps = (PipeBendTempVars) new DrillItemBase();
    FoamCalcVars.varPipeBendingSettings = (PipeBendSettings) new DrillCalcItem();
    FoamCalcVars.varPipeBendingRunSettings = (PipeBendRuntimeSettings) new DrillItemBase();
    FoamCalcVars.DiskBlocks = new List<PipeBendDiskBlocks>();
    FoamCalcVars.frmDiskBlocks = (F_BendingRotaryDisk) null;
    FoamCalcVars.UnlockString = "";
  }

  public buDrillCalc()
  {
    ((FoamEditorSettings) this).Name = "PipeBend";
    ((FoamEditorSettings) this).PipeDiameter = 40.0;
    ((FoamEditorSettings) this).BendingList = new List<BendingLRAMaterialData>();
    ((FoamEditorSettings) this).Moves = new List<PipeBendMove>();
    ((FoamEditorSettings) this).SimMoves = new List<PipeBendSimulationMove>();
    ((FoamTempVars) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((FoamTempVars) this).BlockList = new List<Block>();
    ((FoamTempVars) this).EntityList = new List<Entity>();
    ((FoamTempVars) this).calcEntities = new List<buEntity>();
    ((FoamTempVars) this).AuxEntityList = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buDrillCalc(PipeBendJob data)
  {
    ((FoamEditorSettings) this).Name = "PipeBend";
    ((FoamEditorSettings) this).PipeDiameter = 40.0;
    ((FoamEditorSettings) this).BendingList = new List<BendingLRAMaterialData>();
    ((FoamEditorSettings) this).Moves = new List<PipeBendMove>();
    ((FoamEditorSettings) this).SimMoves = new List<PipeBendSimulationMove>();
    ((FoamTempVars) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((FoamTempVars) this).BlockList = new List<Block>();
    ((FoamTempVars) this).EntityList = new List<Entity>();
    ((FoamTempVars) this).calcEntities = new List<buEntity>();
    ((FoamTempVars) this).AuxEntityList = new List<Entity>();
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
    ((FoamTempVars) this).Material = (MaterialBase5) new ShapeMultiCenterData(((FoamTempVars) data).Material);
  }

  public override string ToString()
  {
    return "BendingList: " + ((FoamEditorSettings) this).BendingList.Count.ToString();
  }

  public abstract void m001B12();

  public buDrillCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buDrillCalc(
    double xpos,
    double ypos,
    double zpos,
    double bendpos,
    double rotatepos,
    PipeBendMoveCommand Cmd)
  {
    // ISSUE: unable to decompile the method.
  }

  public buDrillCalc(RollerBendMove data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(RollerBendMove Base, ref RollerBendMove Copied)
  {
    Copied = (RollerBendMove) new FoamPattern(Base);
  }

  public static void Copy(List<RollerBendMove> RefList, ref List<RollerBendMove> CopyList)
  {
    CopyList.Clear();
    for (int index = 0; index <= RefList.Count - 1; ++index)
      CopyList.Add((RollerBendMove) new FoamPattern(RefList[index]));
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001B19();

  public buDrillCalc()
  {
    ((FoamWaveShapeArgs) this).Name = "Mat";
    ((FoamWaveShapeArgs) this).Orders = new List<BendingLRAMaterialData>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buDrillCalc(BendingLRAMaterial data)
  {
    ((FoamWaveShapeArgs) this).Name = "Mat";
    ((FoamWaveShapeArgs) this).Orders = new List<BendingLRAMaterialData>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    ((FoamWaveShapeArgs) this).Orders = new List<BendingLRAMaterialData>();
    for (int index = 0; index <= ((FoamWaveShapeArgs) data).Orders.Count - 1; ++index)
      ((FoamWaveShapeArgs) this).Orders.Add((BendingLRAMaterialData) new buDrillCalc(((FoamWaveShapeArgs) data).Orders[index]));
  }

  public static void Copy(BendingLRAMaterial Base, ref BendingLRAMaterial Copied)
  {
    Copied = (BendingLRAMaterial) new buDrillCalc(Base);
  }

  public static void Copy(List<BendingLRAMaterial> Base, ref List<BendingLRAMaterial> Copied)
  {
    Copied.Clear();
    Copied = new List<BendingLRAMaterial>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add((BendingLRAMaterial) new buDrillCalc(Base[index]));
  }

  public override string ToString() => "Name: " + ((FoamWaveShapeArgs) this).Name.ToString();

  public abstract void m001B1F();

  public buDrillCalc()
  {
    ((FoamWaveShapeArgs) this).Enable = true;
    ((FoamWaveShapeArgs) this).Length = 0.0;
    ((FoamWaveShapeArgs) this).Rotation = 0.0;
    ((FoamWaveShapeArgs) this).Angle = 0.0;
    ((FoamWaveShapeArgs) this).Radius = 0.0;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buDrillCalc(BendingLRAMaterialData data)
  {
    ((FoamWaveShapeArgs) this).Enable = true;
    ((FoamWaveShapeArgs) this).Length = 0.0;
    ((FoamWaveShapeArgs) this).Rotation = 0.0;
    ((FoamWaveShapeArgs) this).Angle = 0.0;
    ((FoamWaveShapeArgs) this).Radius = 0.0;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
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

  public static void Copy(BendingLRAMaterialData Base, ref BendingLRAMaterialData Copied)
  {
    Copied = (BendingLRAMaterialData) new buDrillCalc(Base);
  }

  public static void Copy(
    List<BendingLRAMaterialData> Base,
    ref List<BendingLRAMaterialData> Copied)
  {
    Copied.Clear();
    Copied = new List<BendingLRAMaterialData>();
    for (int index = 0; index <= Base.Count - 1; ++index)
      Copied.Add((BendingLRAMaterialData) new buDrillCalc(Base[index]));
  }

  public override string ToString()
  {
    return $"L: {((FoamWaveShapeArgs) this).Length.ToString()} - R: {((FoamWaveShapeArgs) this).Rotation.ToString()} - A: {((FoamWaveShapeArgs) this).Angle.ToString()} - Cr: {((FoamWaveShapeArgs) this).Radius.ToString()}";
  }

  public abstract void m001B25();

  public buDrillCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buDrillCalc(
    double xpos,
    double ypos,
    double zpos,
    double bendpos,
    double rotatepos,
    PipeBendMoveCommand Cmd)
  {
    // ISSUE: unable to decompile the method.
  }

  public buDrillCalc(
    double xpos,
    double ypos,
    double zpos,
    double apos,
    double cpos,
    double bendpos,
    double rotatepos,
    double ypreasure,
    double xbending,
    double rad,
    PipeBendMoveCommand Cmd)
  {
    // ISSUE: unable to decompile the method.
  }

  public buDrillCalc(
    double xpos,
    double ypos,
    double zpos,
    double apos,
    double cpos,
    double bendpos,
    double rotatepos,
    double ypreasure,
    double xbending,
    double rad,
    bool movepipe,
    int indexmove,
    PipeBendMoveCommand Cmd)
  {
    // ISSUE: unable to decompile the method.
  }

  public buDrillCalc(PipeBendSimulationMove data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static bool EQ(PipeBendSimulationMove A, PipeBendSimulationMove B)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(PipeBendSimulationMove Base, ref PipeBendSimulationMove Copied)
  {
    Copied = (PipeBendSimulationMove) new buDrillCalc(Base);
  }

  public static void Copy(
    List<PipeBendSimulationMove> RefList,
    ref List<PipeBendSimulationMove> CopyList)
  {
    CopyList.Clear();
    for (int index = 0; index <= RefList.Count - 1; ++index)
      CopyList.Add((PipeBendSimulationMove) new buDrillCalc(RefList[index]));
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001B2F();

  public buDrillCalc()
  {
    ((buSewingCalc) this).Diameter = 40.0;
    ((SewingMain) this).Length = 1000.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buDrillCalc(PipeBendData data)
  {
    ((buSewingCalc) this).Diameter = 40.0;
    ((SewingMain) this).Length = 1000.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    return $"Diameter: {((buSewingCalc) this).Diameter.ToString()} - Length: {((SewingMain) this).Length.ToString()}";
  }

  public abstract void m001B33();

  public buDrillCalc()
  {
    ((SewingMain) this).BlockPipeDiameter = 60.0;
    ((SewingEntityCustomData) this).DiskDiameter = 200.0;
    ((SewingEntityCustomData) this).DiskHeight = 80.0;
    ((SewingEntityCustomData) this).DiskThickness = 10.0;
    ((SewingEntityCustomData) this).DiskBlockWidth = 50.0;
    ((SewingEntityCustomData) this).DiskBlockLength = 50.0;
    ((SewingEntityCustomData) this).BlockWidth = 200.0;
    ((SewingEntityCustomData) this).BlockHeight = 80.0;
    ((SewingDevideOptions) this).BlockDepth = 150.0;
    ((SewingDevideOptions) this).entityDisk = (Entity) null;
    ((SewingDevideOptions) this).entityBlock = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buDrillCalc(PipeBendDiskBlocks data)
  {
    ((SewingMain) this).BlockPipeDiameter = 60.0;
    ((SewingEntityCustomData) this).DiskDiameter = 200.0;
    ((SewingEntityCustomData) this).DiskHeight = 80.0;
    ((SewingEntityCustomData) this).DiskThickness = 10.0;
    ((SewingEntityCustomData) this).DiskBlockWidth = 50.0;
    ((SewingEntityCustomData) this).DiskBlockLength = 50.0;
    ((SewingEntityCustomData) this).BlockWidth = 200.0;
    ((SewingEntityCustomData) this).BlockHeight = 80.0;
    ((SewingDevideOptions) this).BlockDepth = 150.0;
    ((SewingDevideOptions) this).entityDisk = (Entity) null;
    ((SewingDevideOptions) this).entityBlock = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    if (((SewingDevideOptions) data).entityDisk != null)
      buRadialDim.Copy(((SewingDevideOptions) data).entityDisk, ref ((SewingDevideOptions) this).entityDisk);
    if (((SewingDevideOptions) data).entityBlock == null)
      return;
    buRadialDim.Copy(((SewingDevideOptions) data).entityBlock, ref ((SewingDevideOptions) this).entityBlock);
  }

  public static void Copy(PipeBendDiskBlocks Source, ref PipeBendDiskBlocks Target)
  {
    Target = (PipeBendDiskBlocks) new buDrillCalc(Source);
  }
}
