// Decompiled with JetBrains decompiler
// Type: ns3.Struct7
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using Win32Types;

#nullable disable
namespace ns3;

internal struct Struct7
{
  public IntPtr intptr_0;
  public IntPtr intptr_1;
  public int int_0;
  public int int_1;
  public int int_2;
  public int int_3;
  public uint uint_0;

  virtual string ValueType.ToString()
  {
    return $"{this.int_0.ToString()}:{this.int_1.ToString()}:{this.int_2.ToString()}:{this.int_3.ToString()}:{((SWP_Flags) this.uint_0).ToString()}";
  }
}
