// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.Base64
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public sealed class Base64
{
  private Base64()
  {
  }

  public static string ToBase64String(byte[] data) => Convert.ToBase64String(data, 0, data.Length);

  public static string ToBase64String(byte[] data, int off, int length)
  {
    return Convert.ToBase64String(data, off, length);
  }

  public static byte[] Encode(byte[] data) => Base64.Encode(data, 0, data.Length);

  public static byte[] Encode(byte[] data, int off, int length)
  {
    return Strings.ToAsciiByteArray(Convert.ToBase64String(data, off, length));
  }

  public static int Encode(byte[] data, Stream outStream)
  {
    byte[] buffer = Base64.Encode(data);
    outStream.Write(buffer, 0, buffer.Length);
    return buffer.Length;
  }

  public static int Encode(byte[] data, int off, int length, Stream outStream)
  {
    byte[] buffer = Base64.Encode(data, off, length);
    outStream.Write(buffer, 0, buffer.Length);
    return buffer.Length;
  }

  public static byte[] Decode(byte[] data)
  {
    return Convert.FromBase64String(Strings.FromAsciiByteArray(data));
  }

  public static byte[] Decode(string data) => Convert.FromBase64String(data);

  public static int Decode(string data, Stream outStream)
  {
    byte[] buffer = Base64.Decode(data);
    outStream.Write(buffer, 0, buffer.Length);
    return buffer.Length;
  }
}
