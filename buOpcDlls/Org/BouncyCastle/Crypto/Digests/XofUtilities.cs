// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.XofUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

internal class XofUtilities
{
  internal static byte[] LeftEncode(long strLen)
  {
    byte num1 = 1;
    long num2 = strLen;
    while ((num2 >>= 8) != 0L)
      ++num1;
    byte[] numArray = new byte[(int) num1 + 1];
    numArray[0] = num1;
    for (int index = 1; index <= (int) num1; ++index)
      numArray[index] = (byte) (strLen >> 8 * ((int) num1 - index));
    return numArray;
  }

  internal static byte[] RightEncode(long strLen)
  {
    byte index1 = 1;
    long num = strLen;
    while ((num >>= 8) != 0L)
      ++index1;
    byte[] numArray = new byte[(int) index1 + 1];
    numArray[(int) index1] = index1;
    for (int index2 = 0; index2 < (int) index1; ++index2)
      numArray[index2] = (byte) (strLen >> 8 * ((int) index1 - index2 - 1));
    return numArray;
  }

  internal static byte[] Encode(byte X)
  {
    return Arrays.Concatenate(XofUtilities.LeftEncode(8L), new byte[1]
    {
      X
    });
  }

  internal static byte[] Encode(byte[] inBuf, int inOff, int len)
  {
    return inBuf.Length == len ? Arrays.Concatenate(XofUtilities.LeftEncode((long) (len * 8)), inBuf) : Arrays.Concatenate(XofUtilities.LeftEncode((long) (len * 8)), Arrays.CopyOfRange(inBuf, inOff, inOff + len));
  }
}
