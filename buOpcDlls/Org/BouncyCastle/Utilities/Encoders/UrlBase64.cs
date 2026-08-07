// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.UrlBase64
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class UrlBase64
{
  private static readonly IEncoder encoder = (IEncoder) new UrlBase64Encoder();

  public static byte[] Encode(byte[] data)
  {
    MemoryStream outStream = new MemoryStream();
    try
    {
      UrlBase64.encoder.Encode(data, 0, data.Length, (Stream) outStream);
    }
    catch (IOException ex)
    {
      throw new Exception("exception encoding URL safe base64 string: " + ex.Message, (Exception) ex);
    }
    return outStream.ToArray();
  }

  public static int Encode(byte[] data, Stream outStr)
  {
    return UrlBase64.encoder.Encode(data, 0, data.Length, outStr);
  }

  public static byte[] Decode(byte[] data)
  {
    MemoryStream outStream = new MemoryStream();
    try
    {
      UrlBase64.encoder.Decode(data, 0, data.Length, (Stream) outStream);
    }
    catch (IOException ex)
    {
      throw new Exception("exception decoding URL safe base64 string: " + ex.Message, (Exception) ex);
    }
    return outStream.ToArray();
  }

  public static int Decode(byte[] data, Stream outStr)
  {
    return UrlBase64.encoder.Decode(data, 0, data.Length, outStr);
  }

  public static byte[] Decode(string data)
  {
    MemoryStream outStream = new MemoryStream();
    try
    {
      UrlBase64.encoder.DecodeString(data, (Stream) outStream);
    }
    catch (IOException ex)
    {
      throw new Exception("exception decoding URL safe base64 string: " + ex.Message, (Exception) ex);
    }
    return outStream.ToArray();
  }

  public static int Decode(string data, Stream outStr)
  {
    return UrlBase64.encoder.DecodeString(data, outStr);
  }
}
