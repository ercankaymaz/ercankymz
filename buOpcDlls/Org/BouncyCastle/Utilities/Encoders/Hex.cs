// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.Hex
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public sealed class Hex
{
  private static readonly HexEncoder encoder = new HexEncoder();

  private Hex()
  {
  }

  public static string ToHexString(byte[] data) => Hex.ToHexString(data, false);

  public static string ToHexString(byte[] data, bool upperCase)
  {
    return Hex.ToHexString(data, 0, data.Length, upperCase);
  }

  public static string ToHexString(byte[] data, int off, int length)
  {
    return Hex.ToHexString(data, off, length, false);
  }

  public static string ToHexString(byte[] data, int off, int length, bool upperCase)
  {
    string hexString = Strings.FromAsciiByteArray(Hex.Encode(data, off, length));
    if (upperCase)
      hexString = hexString.ToUpperInvariant();
    return hexString;
  }

  public static byte[] Encode(byte[] data) => Hex.Encode(data, 0, data.Length);

  public static byte[] Encode(byte[] data, int off, int length)
  {
    MemoryStream outStream = new MemoryStream(length * 2);
    Hex.encoder.Encode(data, off, length, (Stream) outStream);
    return outStream.ToArray();
  }

  public static int Encode(byte[] data, Stream outStream)
  {
    return Hex.encoder.Encode(data, 0, data.Length, outStream);
  }

  public static int Encode(byte[] data, int off, int length, Stream outStream)
  {
    return Hex.encoder.Encode(data, off, length, outStream);
  }

  public static byte[] Decode(byte[] data)
  {
    MemoryStream outStream = new MemoryStream((data.Length + 1) / 2);
    Hex.encoder.Decode(data, 0, data.Length, (Stream) outStream);
    return outStream.ToArray();
  }

  public static byte[] Decode(string data)
  {
    MemoryStream outStream = new MemoryStream((data.Length + 1) / 2);
    Hex.encoder.DecodeString(data, (Stream) outStream);
    return outStream.ToArray();
  }

  public static int Decode(string data, Stream outStream)
  {
    return Hex.encoder.DecodeString(data, outStream);
  }

  public static byte[] DecodeStrict(string str) => Hex.encoder.DecodeStrict(str, 0, str.Length);

  public static byte[] DecodeStrict(string str, int off, int len)
  {
    return Hex.encoder.DecodeStrict(str, off, len);
  }
}
