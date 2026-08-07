// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.QuiltingProgramSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class QuiltingProgramSettings : buSerilization5
{
  public const WoodItemType Text = ; // Unable to render the field
  public const WoodItemType Contouring = ; // Unable to render the field
  public const WoodItemType Contour = ; // Unable to render the field
  public static List<string> LangPrinter3DStatus;
  public static List<string> LangPrinter3DMessage;
  public static List<string> LangPrinter3DCaptions;
  public static List<string> LangPrinter3DCommands;
  public static Printer3DTempVars varTemps;
  public static Printer3DSettings varPrinter3DSettings;
  public static Printer3DRuntimeSettings varPrinter3DRunSettings;
  public static byte f003CE7;
  public string ItemName;
  public string FileName;

  public double CurveUnbending(int i, List<BendingLRAMaterialData> BendingList)
  {
    return 2.0 * ((FoamWaveShapeArgs) BendingList[i]).Radius * Math.PI / 360.0 * ((FoamWaveShapeArgs) BendingList[i]).Angle;
  }

  public double AnglePortion(double mm, int i, List<BendingLRAMaterialData> BendingList)
  {
    return mm * ((FoamWaveShapeArgs) BendingList[i]).Angle / this.CurveUnbending(i, BendingList);
  }

  public int GetCollisionIndex(Design design1)
  {
    int collisionIndex;
    for (int index1 = 0; index1 <= design1.Entities.Count - 1; ++index1)
    {
      BlockReference entity = (BlockReference) design1.Entities[index1];
      for (int index2 = 0; index2 <= SewingSettings._cd.Result.Length - 1; ++index2)
      {
        BlockReference[] array1 = SewingSettings._cd.Result[index2].CollidedEntities.Item1.Parents.ToArray();
        for (int index3 = 0; index3 <= SewingSettings._cd.Result[index2].CollidedEntities.Item1.Parents.Count - 1; ++index3)
        {
          if (this.FindBlockRef(SewingSettings._cd.Result[index2].CollidedEntities.Item1.ParentName, array1) & array1[index3].BlockName == entity.BlockName & array1[index3].InsertionPoint == entity.InsertionPoint)
          {
            collisionIndex = index1;
            goto label_17;
          }
        }
        BlockReference[] array2 = SewingSettings._cd.Result[index2].CollidedEntities.Item2.Parents.ToArray();
        for (int index4 = 0; index4 <= SewingSettings._cd.Result[index2].CollidedEntities.Item2.Parents.Count - 1; ++index4)
        {
          if (this.FindBlockRef(SewingSettings._cd.Result[index2].CollidedEntities.Item2.ParentName, array2) & array2[index4].BlockName == entity.BlockName & array2[index4].InsertionPoint == entity.InsertionPoint)
          {
            collisionIndex = index1;
            goto label_17;
          }
        }
      }
    }
    collisionIndex = 0;
label_17:
    return collisionIndex;
  }

  public bool FindBlockRef(string blockName, BlockReference[] parents)
  {
    bool blockRef;
    for (int index = 0; index < parents.Length; ++index)
    {
      if (blockName == parents[index].BlockName)
      {
        blockRef = true;
        goto label_6;
      }
    }
    blockRef = false;
label_6:
    return blockRef;
  }

  public Design Highlight(Entity e, Color c, Design design1)
  {
    if (!SewingSettings.originalColors.ContainsKey(e))
      SewingSettings.originalColors.Add(e, e.Color);
    e.Color = c;
    if (e is BlockReference blockReference)
    {
      Block block = design1.Blocks[blockReference.BlockName];
      if (block != null)
      {
        foreach (Entity entity in (EyeshotCollection<Entity>) block.Entities)
          this.Highlight(entity, c, design1);
      }
    }
    return design1;
  }
}
