// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.DeleteEntitiesType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class DeleteEntitiesType : buSerilization5
{
  public double CurveToSurfaceResolution;
  public bool CutProfileStart;
  public bool CutProfileEnd;
  public double CutProfileDepthStep;
  public double CurveAngleStep;
  public bool VerticalCut;
  public bool TwistEnable;
  public double TwistStartAngle;

  public DeleteEntitiesType()
  {
    ((MarbleMachineOptionsSettings) this).StartPoint = new Point3D();
    ((MarbleMachineOptionsSettings) this).EndPoint = new Point3D();
    ((MarbleMachineOptionsSettings) this).VacuumCutDrawEntity = (Entity) null;
    ((MarbleMachineOptionsSettings) this).VacuumCutEntity = (buEntity) null;
    ((MarbleMachineOptionsSettings) this).OffsetX = 0.0;
    ((MarbleMachineOptionsSettings) this).OffsetY = 0.0;
    ((MarbleMachineOptionsSettings) this).MoveX = 0.0;
    ((MarbleMachineOptionsSettings) this).MoveY = 0.0;
    ((MarbleMachineOptionsSettings) this).RotateC = 0.0;
    ((MarbleMachineOptionsSettings) this).VacuumID = -1;
    ((MarbleMachineOptionsSettings) this).Selected = false;
    ((MarbleMachineOptionsSettings) this).Direction = HorizontalVertical.Horizontal;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DeleteEntitiesType(MarbleVacuumCut data)
  {
    ((MarbleMachineOptionsSettings) this).StartPoint = new Point3D();
    ((MarbleMachineOptionsSettings) this).EndPoint = new Point3D();
    ((MarbleMachineOptionsSettings) this).VacuumCutDrawEntity = (Entity) null;
    ((MarbleMachineOptionsSettings) this).VacuumCutEntity = (buEntity) null;
    ((MarbleMachineOptionsSettings) this).OffsetX = 0.0;
    ((MarbleMachineOptionsSettings) this).OffsetY = 0.0;
    ((MarbleMachineOptionsSettings) this).MoveX = 0.0;
    ((MarbleMachineOptionsSettings) this).MoveY = 0.0;
    ((MarbleMachineOptionsSettings) this).RotateC = 0.0;
    ((MarbleMachineOptionsSettings) this).VacuumID = -1;
    ((MarbleMachineOptionsSettings) this).Selected = false;
    ((MarbleMachineOptionsSettings) this).Direction = HorizontalVertical.Horizontal;
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
    if (((MarbleMachineOptionsSettings) data).VacuumCutEntity != null)
      buDiametricDim.Copy(((MarbleMachineOptionsSettings) data).VacuumCutEntity, ref ((MarbleMachineOptionsSettings) this).VacuumCutEntity);
    if (((MarbleMachineOptionsSettings) data).VacuumCutDrawEntity == null)
      return;
    buRadialDim.Copy(((MarbleMachineOptionsSettings) data).VacuumCutDrawEntity, ref ((MarbleMachineOptionsSettings) this).VacuumCutDrawEntity);
  }

  public static void Copy(List<MarbleVacuumCut> Items, ref List<MarbleVacuumCut> CopyItems)
  {
    CopyItems = new List<MarbleVacuumCut>();
    for (int index = 0; index <= Items.Count - 1; ++index)
      CopyItems.Add((MarbleVacuumCut) new DeleteEntitiesType(Items[index]));
  }

  public static ArrayList ToDef(MarbleVacuumCut refItem, int Space)
  {
    ArrayList def = new ArrayList();
    screenInfo.ExceptionalVariables.Clear();
    buSerilization5.ClassToString((object) refItem);
    def.AddRange((ICollection) refItem.ToDefAll("", Space, (SerilizationMode5) 1));
    return def;
  }
}
