// Decompiled with JetBrains decompiler
// Type: ns5.Struct2
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using System;
using Win32Types;

#nullable disable
namespace ns5;

internal struct Struct2
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
