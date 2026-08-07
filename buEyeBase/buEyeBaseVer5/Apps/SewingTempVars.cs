// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingTempVars : buSerilization5
{
  public static int _bendPartCounter;
  public static Circle _c1;

  public SewingTempVars(DoorRuntimeSettings data)
  {
    ((FoamRuntimeSettings) this).SelectMode = false;
    ((FoamRuntimeSettings) this).FromFileKeepRatio = true;
    ((FoamRuntimeSettings) this).pathFromFile = "C:\\";
    ((FoamRuntimeSettings) this).pathJob = "C:\\";
    ((FoamRuntimeSettings) this).MaterialHeight = 800.0;
    ((FoamRuntimeSettings) this).MaterialWidth = 2000.0;
    ((FoamRuntimeSettings) this).MaterialDepth = 20.0;
    ((FoamRuntimeSettings) this).Case1Width = 2000.0;
    ((FoamRuntimeSettings) this).Case1Height = 400.0;
    ((FoamRuntimeSettings) this).Case1Depth = 20.0;
    ((FoamRuntimeSettings) this).Case2Width = 2000.0;
    ((FoamRuntimeSettings) this).Case2Height = 400.0;
    ((FoamRuntimeSettings) this).Case2Depth = 20.0;
    ((FoamRuntimeSettings) this).CaseSpace = 50.0;
    ((FoamRuntimeSettings) this).MaterialFrontAngle = 0.0;
    ((FoamRuntimeSettings) this).MaterialBackAngle = 0.0;
    ((FoamRuntimeSettings) this).SecondToolNo = 1;
    ((FoamRuntimeSettings) this).SecondToolEnable = false;
    ((FoamRuntimeSettings) this).MaterailPurpuse = MaterialPurpose.Door;
    ((FoamRuntimeSettings) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
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
    ((FoamRuntimeSettings) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands(((FoamRuntimeSettings) data).ShapeDataParameters);
  }

  public abstract void m001AF7();
}
