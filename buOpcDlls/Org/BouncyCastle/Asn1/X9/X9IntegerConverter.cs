// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9IntegerConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public abstract class X9IntegerConverter
{
  public static int GetByteLength(ECFieldElement fe) => (fe.FieldSize + 7) / 8;

  public static int GetByteLength(ECCurve c) => (c.FieldSize + 7) / 8;

  public static byte[] IntegerToBytes(BigInteger s, int qLength)
  {
    byte[] byteArrayUnsigned = s.ToByteArrayUnsigned();
    if (qLength < byteArrayUnsigned.Length)
    {
      byte[] destinationArray = new byte[qLength];
      Array.Copy((Array) byteArrayUnsigned, byteArrayUnsigned.Length - destinationArray.Length, (Array) destinationArray, 0, destinationArray.Length);
      return destinationArray;
    }
    if (qLength <= byteArrayUnsigned.Length)
      return byteArrayUnsigned;
    byte[] destinationArray1 = new byte[qLength];
    Array.Copy((Array) byteArrayUnsigned, 0, (Array) destinationArray1, destinationArray1.Length - byteArrayUnsigned.Length, byteArrayUnsigned.Length);
    return destinationArray1;
  }
}
