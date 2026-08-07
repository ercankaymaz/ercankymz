// Decompiled with JetBrains decompiler
// Type: buClass.camDrill
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camDrill : buSerilization
{
  public bool Enable = false;
  public bool PeckMode = false;
  public bool PeckFullRetract = false;
  public double StartHeight = 10.0;
  public double EndHeight = 0.0;
  public double StartAngle = 0.0;
  public double EndAngle = 360.0;
  public double PeckDepth = 2.0;
  public double PeckMinRetractDistance = 2.0;
  public static List<string> Captions = new List<string>();

  public camDrill()
  {
  }

  public camDrill(camDrill distance)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) distance, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public override string ToString() => "Enable: " + this.Enable.ToString();
}
