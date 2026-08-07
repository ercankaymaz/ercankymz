// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.PlatformType
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;

#nullable disable
namespace buMutliTextbox;

public static class PlatformType
{
  public static Platform GetOperationSystemPlatform()
  {
    PlatformType.Struct0 struct0_0 = new PlatformType.Struct0();
    if ((Environment.OSVersion.Version.Major > 5 ? 1 : (Environment.OSVersion.Version.Major != 5 ? 0 : (Environment.OSVersion.Version.Minor >= 1 ? 1 : 0))) != 0)
      Class39.GetNativeSystemInfo(ref struct0_0);
    else
      Class39.GetSystemInfo(ref struct0_0);
    Platform operationSystemPlatform;
    switch (struct0_0.ushort_0)
    {
      case 0:
        operationSystemPlatform = Platform.X86;
        break;
      case 6:
      case 9:
        operationSystemPlatform = Platform.X64;
        break;
      default:
        operationSystemPlatform = Platform.Unknown;
        break;
    }
    return operationSystemPlatform;
  }

  internal struct Struct0
  {
    public ushort ushort_0;
    public ushort ushort_1;
    public uint uint_0;
    public IntPtr intptr_0;
    public IntPtr intptr_1;
    public UIntPtr uintptr_0;
    public uint uint_1;
    public uint uint_2;
    public uint uint_3;
    public ushort ushort_2;
    public ushort ushort_3;
  }
}
