// Decompiled with JetBrains decompiler
// Type: buClass.punchParameters
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;

#nullable disable
namespace buClass;

[Serializable]
public class punchParameters : buSerilization
{
  public punchOptions Options = new punchOptions();

  public punchParameters()
  {
  }

  public punchParameters(punchParameters parameters)
  {
    this.Options = new punchOptions(parameters.Options);
  }

  public static void Decode(ArrayList AL, string Char, ref punchParameters Par)
  {
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Options);
  }

  public static void ToDef(
    punchParameters Par,
    ref ArrayList AL,
    string Char,
    int Space,
    SerilizationMode DefMode)
  {
    AL.AddRange((ICollection) Par.Options.ToDefAll(Char, Space, SerilizationMode.MultiLine));
  }
}
