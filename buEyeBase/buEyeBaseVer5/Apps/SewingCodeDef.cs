// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingCodeDef
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingCodeDef : buSerilization5
{
  public static int OffsetY;
  public static string StraightBlockName;

  public SewingCodeDef(DoorJob data)
  {
    ((FoamRuntimeSettings) this).Name = "Job";
    ((FoamRuntimeSettings) this).GCode = "";
    ((FoamRuntimeSettings) this).Items = new List<buShape>();
    ((FoamRuntimeSettings) this).Codes = new List<string>();
    ((FoamRuntimeSettings) this).Cams = new List<camTp>();
    ((FoamRuntimeSettings) this).ErrorCodes = new List<string>();
    ((FoamRuntimeSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((FoamRuntimeSettings) this).TotalCount = 1;
    ((FoamRuntimeSettings) this).Used = 0;
    ((FoamRuntimeSettings) this).isSorted = false;
    ((FoamRuntimeSettings) this).panelEntity = (Entity) null;
    ((FoamRuntimeSettings) this).panelEntity2 = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    ((FoamRuntimeSettings) this).Material = (MaterialBase5) new ShapeMultiCenterData(((FoamRuntimeSettings) data).Material);
    if (((FoamRuntimeSettings) data).panelEntity != null)
      buVector5.CopyEntities(((FoamRuntimeSettings) data).panelEntity, ref ((FoamRuntimeSettings) this).panelEntity);
    buLineCam.Copy(((FoamRuntimeSettings) data).Items, ref ((FoamRuntimeSettings) this).Items);
    for (int index = 0; index <= ((FoamRuntimeSettings) data).ErrorCodes.Count - 1; ++index)
      ((FoamRuntimeSettings) this).ErrorCodes.Add(((FoamRuntimeSettings) this).ErrorCodes[index]);
    for (int index = 0; index <= ((FoamRuntimeSettings) data).Cams.Count - 1; ++index)
      ((FoamRuntimeSettings) this).Cams.Add(new camTp(((FoamRuntimeSettings) data).Cams[index]));
  }

  public override string ToString() => ((FoamRuntimeSettings) this).Name.ToString();

  public abstract void m001AF2();
}
