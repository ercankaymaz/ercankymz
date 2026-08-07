// Decompiled with JetBrains decompiler
// Type: ns10.Struct6
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ns10;

internal struct Struct6
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
