// Decompiled with JetBrains decompiler
// Type: buClass.SimulationMValues
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SimulationMValues : buSerilization
{
  public double M0 = -1.0;
  public double M1 = -1.0;
  public double M2 = -1.0;
  public double M3 = -1.0;
  public double M4 = -1.0;
  public double M5 = -1.0;
  public double M6 = -1.0;
  public double M7 = -1.0;
  public double M8 = -1.0;
  public double M9 = -1.0;
  public double M10 = -1.0;
  public double M11 = -1.0;
  public double M12 = -1.0;
  public double M13 = -1.0;
  public double M14 = -1.0;
  public double M15 = -1.0;
  public double M16 = -1.0;
  public double M17 = -1.0;
  public double M18 = -1.0;
  public double M19 = -1.0;
  public double M20 = -1.0;
  public double M21 = -1.0;
  public double M22 = -1.0;
  public double M23 = -1.0;
  public double M24 = -1.0;
  public double M25 = -1.0;
  public double M26 = -1.0;
  public double M27 = -1.0;
  public double M28 = -1.0;
  public double M29 = -1.0;
  public double M30 = -1.0;
  public double M31 = -1.0;
  public double M32 = -1.0;
  public double M33 = -1.0;
  public double M34 = -1.0;
  public double M35 = -1.0;
  public double M36 = -1.0;
  public double M37 = -1.0;
  public double M38 = -1.0;
  public double M39 = -1.0;
  public double M40 = -1.0;
  public double M41 = -1.0;
  public double M42 = -1.0;
  public double M43 = -1.0;
  public double M44 = -1.0;
  public double M45 = -1.0;
  public double M46 = -1.0;
  public double M47 = -1.0;
  public double M48 = -1.0;
  public double M49 = -1.0;
  public double M50 = -1.0;
  public double M51 = -1.0;
  public double M52 = -1.0;
  public double M53 = -1.0;
  public double M54 = -1.0;
  public double M55 = -1.0;
  public double M56 = -1.0;
  public double M57 = -1.0;
  public double M58 = -1.0;
  public double M59 = -1.0;
  public double M60 = -1.0;
  public double M61 = -1.0;
  public double M62 = -1.0;
  public double M63 = -1.0;
  public double M64 = -1.0;
  public double M65 = -1.0;
  public double M66 = -1.0;
  public double M67 = -1.0;
  public double M68 = -1.0;
  public double M69 = -1.0;
  public double M70 = -1.0;
  public double M71 = -1.0;
  public double M72 = -1.0;
  public double M73 = -1.0;
  public double M74 = -1.0;
  public double M75 = -1.0;
  public double M76 = -1.0;
  public double M77 = -1.0;
  public double M78 = -1.0;
  public double M79 = -1.0;
  public double M80 = -1.0;
  public double M81 = -1.0;
  public double M82 = -1.0;
  public double M83 = -1.0;
  public double M84 = -1.0;
  public double M85 = -1.0;
  public double M86 = -1.0;
  public double M87 = -1.0;
  public double M88 = -1.0;
  public double M89 = -1.0;
  public double M90 = -1.0;
  public double M91 = -1.0;
  public double M92 = -1.0;
  public double M93 = -1.0;
  public double M94 = -1.0;
  public double M95 = -1.0;
  public double M96 = -1.0;
  public double M97 = -1.0;
  public double M98 = -1.0;
  public double M99 = -1.0;
  public double M100 = -1.0;
  public double M101 = -1.0;
  public double M102 = -1.0;
  public double M103 = -1.0;
  public double M104 = -1.0;
  public double M105 = -1.0;
  public double M106 = -1.0;
  public double M107 = -1.0;
  public double M108 = -1.0;
  public double M109 = -1.0;

  public SimulationMValues()
  {
  }

  public SimulationMValues(SimulationMValues data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
}
