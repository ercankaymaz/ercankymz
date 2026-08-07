// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal static class SikeUtilities
{
  internal static ulong[][] InitArray(uint size1, uint size2)
  {
    ulong[][] numArray = new ulong[(int) size1][];
    for (int index = 0; (long) index < (long) size1; ++index)
      numArray[index] = new ulong[(int) size2];
    return numArray;
  }

  internal static ulong[][][] InitArray(uint size1, uint size2, uint size3)
  {
    ulong[][][] numArray = new ulong[(int) size1][][];
    for (int index1 = 0; (long) index1 < (long) size1; ++index1)
    {
      numArray[index1] = new ulong[(int) size2][];
      for (int index2 = 0; (long) index2 < (long) size2; ++index2)
        numArray[index1][index2] = new ulong[(int) size3];
    }
    return numArray;
  }

  internal static ulong[][][][] InitArray(uint size1, uint size2, uint size3, uint size4)
  {
    ulong[][][][] numArray = new ulong[(int) size1][][][];
    for (int index1 = 0; (long) index1 < (long) size1; ++index1)
    {
      numArray[index1] = new ulong[(int) size2][][];
      for (int index2 = 0; (long) index2 < (long) size2; ++index2)
      {
        numArray[index1][index2] = new ulong[(int) size3][];
        for (int index3 = 0; (long) index3 < (long) size3; ++index3)
          numArray[index1][index2][index3] = new ulong[(int) size4];
      }
    }
    return numArray;
  }
}
