// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineGCodeExecutionResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineGCodeExecutionResult : buSerilization5
{
  public const buFile5.PLYToSchematic.\u0001 \u0005 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0006 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0007 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0008 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u000E = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u000F = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0010 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0011 = ; // Unable to render the field
  public const buFile5.PLYToSchematic.\u0001 \u0012 = ; // Unable to render the field

  public void CopyCamEntities(List<Entity> refEntity, ref List<Entity> CopiedEntity)
  {
    for (int index = 0; index <= refEntity.Count - 1; ++index)
    {
      Entity CopiedEntity1 = (Entity) null;
      this.CopyCamEntities(refEntity[index], ref CopiedEntity1);
      CopiedEntity.Add(CopiedEntity1);
    }
  }

  public void CopyCamEntities(Entity refEntity, ref Entity CopiedEntity)
  {
    try
    {
      if (refEntity.GetType() == typeof (buLinearPathCam))
        CopiedEntity = (Entity) new CustomData((LinearPath) refEntity);
      else if (refEntity.GetType() == typeof (buCompositeCurveCam))
        CopiedEntity = (Entity) new CustomData((CompositeCurve) refEntity);
      else if (refEntity.GetType() == typeof (buArcCam))
        CopiedEntity = (Entity) new CustomData((Arc) refEntity);
      else if (refEntity.GetType() == typeof (buLineCam))
        CopiedEntity = (Entity) new CustomData((Line) refEntity);
      else if (refEntity.GetType() == typeof (buUpperLineEnt))
        CopiedEntity = (Entity) new MyFileSerializer((Line) refEntity);
      else
        buVector5.CopyEntities(refEntity, ref CopiedEntity);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public MaterialKeyedCollection MaterialCopy(MaterialKeyedCollection baseItem)
  {
    MaterialKeyedCollection materialKeyedCollection = new MaterialKeyedCollection();
    materialKeyedCollection.Clear();
    for (int index1 = 0; index1 <= baseItem.Count - 1; ++index1)
    {
      bool flag = true;
      for (int index2 = 0; index2 <= materialKeyedCollection.Count - 1; ++index2)
      {
        if (baseItem[index1].Name == materialKeyedCollection[index2].Name)
          flag = false;
      }
      if (flag)
      {
        Material material = (Material) baseItem[index1].Clone();
        materialKeyedCollection.Add(material);
      }
    }
    return materialKeyedCollection;
  }
}
