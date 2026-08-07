// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buOrdinateDim
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buOrdinateDim : buEntity
{
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal Panel \u0001;
  public FormProperties Properties;
  public new static List<string> Captions;
  public MachineTableType CamTable;
  internal IContainer \u0001;

  public static void Copy(List<List<buEntity>> refEntities, ref List<List<Entity>> copiedEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      List<Entity> copiedEntities1 = new List<Entity>();
      buDiametricDim.Copy(refEntities[index], ref copiedEntities1);
      if (copiedEntities1.Count > 0)
        copiedEntities.Add(copiedEntities1);
    }
  }

  public static void Copy(List<buEntity> refEntities, ref List<ICurve> copiedEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buAngularDim.Copy(refEntities[index], ref copiedEntity);
      if (copiedEntity != null && copiedEntity is ICurve)
        copiedEntities.Add((ICurve) copiedEntity);
    }
  }

  public static void Copy(List<Entity> refEntities, ref List<buEntity> copiedEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buAngularDim.Copy(refEntities[index], ref copiedEntity);
      if (copiedEntity != null)
        copiedEntities.Add(copiedEntity);
    }
  }

  public static void Copy(List<List<Entity>> refEntities, ref List<List<buEntity>> copiedEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      List<buEntity> copiedEntities1 = new List<buEntity>();
      buOrdinateDim.Copy(refEntities[index], ref copiedEntities1);
      if (copiedEntities1 != null && copiedEntities1.Count > 0)
        copiedEntities.Add(copiedEntities1);
    }
  }

  public static void Copy(List<ICurve> refEntities, ref List<buEntity> copiedEntities)
  {
    List<Entity> refEntities1 = new List<Entity>();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      refEntities1.Add((Entity) refEntities[index]);
    buOrdinateDim.Copy(refEntities1, ref copiedEntities);
  }
}
