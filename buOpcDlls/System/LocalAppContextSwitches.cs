// Decompiled with JetBrains decompiler
// Type: System.LocalAppContextSwitches
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System;

internal static class LocalAppContextSwitches
{
  private static int s_useNonRandomizedHashSeed;

  public static bool UseNonRandomizedHashSeed
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)] get
    {
      return LocalAppContextSwitches.GetCachedSwitchValue("Switch.System.Data.UseNonRandomizedHashSeed", ref LocalAppContextSwitches.s_useNonRandomizedHashSeed);
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static bool GetCachedSwitchValue(string switchName, ref int cachedSwitchValue)
  {
    if (cachedSwitchValue < 0)
      return false;
    return cachedSwitchValue > 0 || LocalAppContextSwitches.GetCachedSwitchValueInternal(switchName, ref cachedSwitchValue);
  }

  private static bool GetCachedSwitchValueInternal(string switchName, ref int cachedSwitchValue)
  {
    bool isEnabled1;
    if (!AppContext.TryGetSwitch(switchName, out isEnabled1))
      isEnabled1 = LocalAppContextSwitches.GetSwitchDefaultValue(switchName);
    bool isEnabled2;
    AppContext.TryGetSwitch("TestSwitch.LocalAppContext.DisableCaching", out isEnabled2);
    if (!isEnabled2)
      cachedSwitchValue = isEnabled1 ? 1 : -1;
    return isEnabled1;
  }

  private static bool GetSwitchDefaultValue(string switchName)
  {
    return switchName == "Switch.System.Runtime.Serialization.SerializationGuard";
  }
}
