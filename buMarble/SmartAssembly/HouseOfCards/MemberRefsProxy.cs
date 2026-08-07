// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.MemberRefsProxy
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buControls.Controls;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
  public buSpin spn_toolspeed;
  public static byte f000B7E;

  [SpecialName]
  internal static bool \u0001()
  {
    try
    {
      switch (Process.GetCurrentProcess().MainModule.ModuleName.ToLower())
      {
        case "w3wp.exe":
          return true;
        case "aspnet_wp.exe":
          return true;
      }
    }
    catch
    {
    }
    return false;
  }
}
