// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MostClosestPointOption
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MostClosestPointOption : buSerilization5
{
  public List<Entity> Entities;
  public static byte f0006DC;

  public MostClosestPointOption()
  {
    ((FlatViewSettings) this).Entities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MostClosestPointOption(EntitiesList contourpoints)
  {
    ((FlatViewSettings) this).Entities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    for (int index = 0; index <= ((FlatViewSettings) contourpoints).Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buDiametricDim.Copy(((FlatViewSettings) contourpoints).Entities[index], ref copiedEntity);
      if (copiedEntity != null)
        ((FlatViewSettings) this).Entities.Add(copiedEntity);
    }
  }
}
