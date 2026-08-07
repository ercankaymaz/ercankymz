// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamItem : buSerilization5
{
  public string Name;
  public buEntity refEntitiy;
  public Entity solidEntity;
  public static byte f003B3F;
  public int SimStep;
  public bool StepRun;
  public static RollerBendRuntimeSettings varRollerBendRuntime = (RollerBendRuntimeSettings) new FoamCreatePanelOptions();
  public static RollerBendSettings varRollerBendSetting = (RollerBendSettings) new FoamEntities();
  public string Name;
  public string Explanation;
  public double SheetWidth;
  public double TotalBendingLength;
  public double Thickness;
  public double LeftAngle;
  public buEntity refEntitiy;
  public Entity solidEntity;
  public List<Point3D> matPoints;
  public List<RollerBendMove> Moves;
  public List<RollerBendMove> SimulationMoves;

  public void CreateSimulationPoints(
    List<RollerBendMove> Moves,
    ref List<RollerBendMove> SimulationMoves)
  {
    // ISSUE: unable to decompile the method.
  }

  public FoamItem() => ((pageInfo) this).\u002Ector();

  public FoamItem(RollerJob data)
  {
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
    if (((FoamItem) data).refEntitiy != null)
      buDiametricDim.Copy(((FoamItem) data).refEntitiy, ref this.refEntitiy);
    if (((FoamItem) data).solidEntity == null)
      return;
    buRadialDim.Copy(((FoamItem) data).solidEntity, ref this.solidEntity);
  }

  public static ArrayList ToDef(List<ProfileJob> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) FoamBlock.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) c);
    }
    return def;
  }
}
