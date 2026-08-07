// Decompiled with JetBrains decompiler
// Type: ns4.Struct1
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ns4;

internal struct Struct1
{
  public int int_0;
  public int int_1;
  public int int_2;
  public int int_3;

  [SpecialName]
  internal uint method_0() => (uint) Math.Abs(this.int_2 - this.int_0);

  [SpecialName]
  internal uint method_1() => (uint) Math.Abs(this.int_3 - this.int_1);

  virtual string ValueType.ToString()
  {
    return $"{this.int_0.ToString()}:{this.int_1.ToString()}:{this.int_2.ToString()}:{this.int_3.ToString()}";
  }
}
