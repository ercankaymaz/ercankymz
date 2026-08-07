// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsSrpUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsSrpUtilities
{
  public static void AddSrpExtension(IDictionary<int, byte[]> extensions, byte[] identity)
  {
    extensions[12] = TlsSrpUtilities.CreateSrpExtension(identity);
  }

  public static byte[] GetSrpExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 12);
    return extensionData != null ? TlsSrpUtilities.ReadSrpExtension(extensionData) : (byte[]) null;
  }

  public static byte[] CreateSrpExtension(byte[] identity)
  {
    return identity != null ? TlsUtilities.EncodeOpaque8(identity) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static byte[] ReadSrpExtension(byte[] extensionData)
  {
    return extensionData != null ? TlsUtilities.DecodeOpaque8(extensionData, 1) : throw new ArgumentNullException(nameof (extensionData));
  }

  public static BigInteger ReadSrpParameter(Stream input)
  {
    return new BigInteger(1, TlsUtilities.ReadOpaque16(input, 1));
  }

  public static void WriteSrpParameter(BigInteger x, Stream output)
  {
    TlsUtilities.WriteOpaque16(BigIntegers.AsUnsignedByteArray(x), output);
  }

  public static bool IsSrpCipherSuite(int cipherSuite)
  {
    switch (TlsUtilities.GetKeyExchangeAlgorithm(cipherSuite))
    {
      case 21:
      case 22:
      case 23:
        return true;
      default:
        return false;
    }
  }
}
