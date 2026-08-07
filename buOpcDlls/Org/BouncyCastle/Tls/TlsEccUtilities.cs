// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsEccUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsEccUtilities
{
  public static TlsECConfig CreateNamedECConfig(TlsContext context, int namedGroup)
  {
    return NamedGroup.GetCurveBits(namedGroup) >= 1 ? new TlsECConfig(namedGroup) : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public static int GetMinimumCurveBits(int cipherSuite)
  {
    return !TlsEccUtilities.IsEccCipherSuite(cipherSuite) ? 0 : 1;
  }

  public static bool IsEccCipherSuite(int cipherSuite)
  {
    switch (TlsUtilities.GetKeyExchangeAlgorithm(cipherSuite))
    {
      case 16 /*0x10*/:
      case 17:
      case 18:
      case 19:
      case 20:
      case 24:
        return true;
      default:
        return false;
    }
  }

  public static void CheckPointEncoding(int namedGroup, byte[] encoding)
  {
    if (TlsUtilities.IsNullOrEmpty<byte>(encoding))
      throw new TlsFatalAlert((short) 47);
    switch (namedGroup)
    {
      case 29:
      case 30:
        break;
      default:
        switch (encoding[0])
        {
          case 4:
            return;
          default:
            throw new TlsFatalAlert((short) 47);
        }
    }
  }

  public static TlsECConfig ReceiveECDHConfig(TlsContext context, Stream input)
  {
    int num = TlsUtilities.ReadUint8(input) == (short) 3 ? TlsUtilities.ReadUint16(input) : throw new TlsFatalAlert((short) 40);
    if (NamedGroup.RefersToAnECDHCurve(num))
    {
      int[] clientSupportedGroups = context.SecurityParameters.ClientSupportedGroups;
      if (clientSupportedGroups == null || Arrays.Contains(clientSupportedGroups, num))
        return new TlsECConfig(num);
    }
    throw new TlsFatalAlert((short) 47);
  }

  public static void WriteECConfig(TlsECConfig ecConfig, Stream output)
  {
    TlsEccUtilities.WriteNamedECParameters(ecConfig.NamedGroup, output);
  }

  public static void WriteNamedECParameters(int namedGroup, Stream output)
  {
    if (!NamedGroup.RefersToASpecificCurve(namedGroup))
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.WriteUint8((short) 3, output);
    TlsUtilities.CheckUint16(namedGroup);
    TlsUtilities.WriteUint16(namedGroup, output);
  }
}
