// Decompiled with JetBrains decompiler
// Type: System.MutableDecimal
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System;

internal struct MutableDecimal
{
  public uint Flags;
  public uint High;
  public uint Low;
  public uint Mid;
  private const uint SignMask = 2147483648 /*0x80000000*/;
  private const uint ScaleMask = 16711680 /*0xFF0000*/;
  private const int ScaleShift = 16 /*0x10*/;

  public bool IsNegative
  {
    get => (this.Flags & 2147483648U /*0x80000000*/) > 0U;
    set => this.Flags = (uint) ((int) this.Flags & int.MaxValue | (value ? int.MinValue : 0));
  }

  public int Scale
  {
    get => (int) (byte) (this.Flags >> 16 /*0x10*/);
    set => this.Flags = (uint) ((int) this.Flags & -16711681 | value << 16 /*0x10*/);
  }
}
