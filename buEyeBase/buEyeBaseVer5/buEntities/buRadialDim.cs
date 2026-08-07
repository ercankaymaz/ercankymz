// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buRadialDim
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buRadialDim : buEntity
{
  internal ImageList \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Button \u0003;
  internal Button \u0004;
  public static byte f0036FF;
  public FormProperties Properties;

  public static void Copy(List<buEntity> refEntities, ref List<buEntity> copiedEntities)
  {
    if (copiedEntities == null)
      copiedEntities = new List<buEntity>();
    copiedEntities.AddRange((IEnumerable<buEntity>) buDiametricDim.Copy(refEntities));
  }

  public static void Copy(List<List<buEntity>> refEntities, ref List<List<buEntity>> copiedEntities)
  {
    copiedEntities = new List<List<buEntity>>();
    if (refEntities == null)
      return;
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      List<buEntity> copiedEntities1 = new List<buEntity>();
      buRadialDim.Copy(refEntities[index], ref copiedEntities1);
      copiedEntities.Add(copiedEntities1);
    }
  }

  public static void Copy(Entity refEntity, ref Entity copiedEntity)
  {
    buVector5.CopyEntities(refEntity, ref copiedEntity);
  }

  public static void Copy(List<Entity> refEntity, ref List<Entity> copiedEntity)
  {
    buVector5.CopyEntities(refEntity, ref copiedEntity);
  }

  public static void Copy(EntityList refEntity, ref List<Entity> copiedEntity)
  {
    buVector5.CopyEntities(refEntity, ref copiedEntity);
  }

  public static void Copy(List<List<Entity>> refEntity, ref List<List<Entity>> copiedEntity)
  {
    buVector5.CopyEntities(refEntity, ref copiedEntity);
  }
}
