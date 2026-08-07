// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ValueRanks
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class ValueRanks
{
  public const int ScalarOrOneDimension = -3;
  public const int Any = -2;
  public const int Scalar = -1;
  public const int OneOrMoreDimensions = 0;
  public const int OneDimension = 1;
  public const int TwoDimensions = 2;

  public static bool IsValid(int actualValueRank, int expectedValueRank)
  {
    if (actualValueRank == expectedValueRank)
      return true;
    switch (expectedValueRank)
    {
      case -3:
        if (actualValueRank != -1 && actualValueRank != 1)
          return false;
        break;
      case -2:
        return true;
      case 0:
        if (actualValueRank < 0)
          return false;
        break;
      default:
        return false;
    }
    return true;
  }

  public static bool IsValid(
    IList<uint> actualArrayDimensions,
    int valueRank,
    IList<uint> expectedArrayDimensions)
  {
    if (actualArrayDimensions != null && actualArrayDimensions.Count != 0)
    {
      if (valueRank == -1 || (valueRank == 1 || valueRank == -3) && actualArrayDimensions.Count != 1 || valueRank != 0 && actualArrayDimensions.Count != valueRank)
        return false;
      if (expectedArrayDimensions == null || expectedArrayDimensions.Count == 0)
        return true;
      if (expectedArrayDimensions.Count != actualArrayDimensions.Count)
        return false;
      for (int index = 0; index < expectedArrayDimensions.Count; ++index)
      {
        if ((int) expectedArrayDimensions[index] != (int) actualArrayDimensions[index] && expectedArrayDimensions[index] != 0U)
          return false;
      }
      return true;
    }
    return expectedArrayDimensions == null || expectedArrayDimensions.Count == 0;
  }
}
