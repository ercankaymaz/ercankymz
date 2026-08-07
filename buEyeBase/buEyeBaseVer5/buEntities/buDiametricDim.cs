// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buDiametricDim
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buDiametricDim : buEntity
{
  public buSpin spn_stockyminusoffset;
  public buSpin spn_stockyplusoffset;
  internal new RadioButton \u0001;
  internal new RadioButton \u0002;
  internal new buLabel \u0001;
  internal RadioButton \u0003;
  internal buLabel \u0002;

  public static void Copy(
    buEntitiesGroup EntGroup,
    ref List<Entity> copiedEntity,
    bool Inside = true,
    bool OpenEntities = true,
    bool Solid = false,
    bool Text = false)
  {
    copiedEntity.Clear();
    if (((\u0084.\u0001) EntGroup.Outside).Entities.Count > 0)
      buText.Add(((\u0084.\u0001) EntGroup.Outside).Entities, ref copiedEntity);
    if ((EntGroup.Inside == null ? 0 : (EntGroup.Inside.Count > 0 & Inside ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= EntGroup.Inside.Count - 1; ++index)
        buText.Add(((\u0084.\u0001) EntGroup.Inside[index]).Entities, ref copiedEntity);
    }
    if ((EntGroup.OpenEntities == null ? 0 : (EntGroup.OpenEntities.Count > 0 & OpenEntities ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= EntGroup.OpenEntities.Count - 1; ++index)
        buText.Add(((\u0084.\u0001) EntGroup.OpenEntities[index]).Entities, ref copiedEntity);
    }
    if ((((DimensionGroup) EntGroup).Text == null ? 0 : (((\u0084.\u0001) ((DimensionGroup) EntGroup).Text).Entities.Count > 0 & Text ? 1 : 0)) != 0)
      buText.Add(((\u0084.\u0001) ((DimensionGroup) EntGroup).Text).Entities, ref copiedEntity);
    if ((((DimensionGroup) EntGroup).Solid == null ? 0 : (((\u0084.\u0001) ((DimensionGroup) EntGroup).Solid).Entities.Count > 0 & Solid ? 1 : 0)) == 0)
      return;
    buText.Add(((\u0084.\u0001) ((DimensionGroup) EntGroup).Solid).Entities, ref copiedEntity);
  }

  public static void Copy(ICurve refEntity, ref buEntity copiedEntity, double Deviation = 0.01)
  {
    buAngularDim.Copy((Entity) refEntity, ref copiedEntity, Deviation);
  }

  public static buEntity Copy(Entity refEntity)
  {
    buEntity copiedEntity = (buEntity) null;
    buAngularDim.Copy(refEntity, ref copiedEntity);
    return copiedEntity;
  }

  public static void Copy(buEntity refEntity, ref buEntity copiedEntity)
  {
    copiedEntity = buAngularDim.Copy(refEntity);
  }

  public static List<buEntity> Copy(List<buEntity> refEntities)
  {
    List<buEntity> buEntityList = new List<buEntity>();
    if (refEntities != null)
    {
      for (int index = 0; index <= refEntities.Count - 1; ++index)
      {
        buEntity buEntity = buAngularDim.Copy(refEntities[index]);
        buEntityList.Add(buEntity);
      }
    }
    return buEntityList;
  }

  public static void Copy(List<buEntity> refEntities, ref List<Entity> copiedEntities)
  {
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buAngularDim.Copy(refEntities[index], ref copiedEntity);
      if (copiedEntity != null)
        copiedEntities.Add(copiedEntity);
    }
  }
}
