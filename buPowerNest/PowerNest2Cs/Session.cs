// Decompiled with JetBrains decompiler
// Type: PowerNest2Cs.Session
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using \u0005;
using System;

#nullable disable
namespace PowerNest2Cs;

public class Session : Wrappable
{
  internal Session()
  {
  }

  ~Session()
  {
    if (!(this.__Ptr != IntPtr.Zero))
      return;
    try
    {
      \u0003.\u0001(this.__Ptr);
      this.__Ptr = IntPtr.Zero;
    }
    catch
    {
    }
  }

  public IntPtr Ptr => this.__Ptr;
}
