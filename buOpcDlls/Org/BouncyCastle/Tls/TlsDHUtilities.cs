// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsDHUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsDHUtilities
{
  public static TlsDHConfig CreateNamedDHConfig(TlsContext context, int namedGroup)
  {
    if (namedGroup < 0 || NamedGroup.GetFiniteFieldBits(namedGroup) < 1)
      return (TlsDHConfig) null;
    bool padded = TlsUtilities.IsTlsV13(context);
    return new TlsDHConfig(namedGroup, padded);
  }

  public static DHGroup GetDHGroup(TlsDHConfig dhConfig)
  {
    int namedGroup = dhConfig.NamedGroup;
    return namedGroup >= 0 ? TlsDHUtilities.GetNamedDHGroup(namedGroup) : dhConfig.ExplicitGroup;
  }

  public static DHGroup GetNamedDHGroup(int namedGroup)
  {
    switch (namedGroup)
    {
      case 256 /*0x0100*/:
        return DHStandardGroups.rfc7919_ffdhe2048;
      case 257:
        return DHStandardGroups.rfc7919_ffdhe3072;
      case 258:
        return DHStandardGroups.rfc7919_ffdhe4096;
      case 259:
        return DHStandardGroups.rfc7919_ffdhe6144;
      case 260:
        return DHStandardGroups.rfc7919_ffdhe8192;
      default:
        return (DHGroup) null;
    }
  }

  public static int GetMinimumFiniteFieldBits(int cipherSuite)
  {
    return !TlsDHUtilities.IsDHCipherSuite(cipherSuite) ? 0 : 1;
  }

  public static bool IsDHCipherSuite(int cipherSuite)
  {
    switch (TlsUtilities.GetKeyExchangeAlgorithm(cipherSuite))
    {
      case 3:
      case 5:
      case 7:
      case 9:
      case 11:
      case 14:
        return true;
      default:
        return false;
    }
  }

  public static int GetNamedGroupForDHParameters(BigInteger p, BigInteger g)
  {
    int[] numArray = new int[5]
    {
      256 /*0x0100*/,
      257,
      258,
      259,
      260
    };
    foreach (int namedGroup in numArray)
    {
      DHGroup namedDhGroup = TlsDHUtilities.GetNamedDHGroup(namedGroup);
      if (namedDhGroup != null && namedDhGroup.P.Equals(p) && namedDhGroup.G.Equals(g))
        return namedGroup;
    }
    return -1;
  }

  public static DHGroup GetStandardGroupForDHParameters(BigInteger p, BigInteger g)
  {
    DHGroup[] dhGroupArray = new DHGroup[13]
    {
      DHStandardGroups.rfc7919_ffdhe2048,
      DHStandardGroups.rfc7919_ffdhe3072,
      DHStandardGroups.rfc7919_ffdhe4096,
      DHStandardGroups.rfc7919_ffdhe6144,
      DHStandardGroups.rfc7919_ffdhe8192,
      DHStandardGroups.rfc3526_1536,
      DHStandardGroups.rfc3526_2048,
      DHStandardGroups.rfc3526_3072,
      DHStandardGroups.rfc3526_4096,
      DHStandardGroups.rfc3526_6144,
      DHStandardGroups.rfc3526_8192,
      DHStandardGroups.rfc5996_768,
      DHStandardGroups.rfc5996_1024
    };
    foreach (DHGroup groupForDhParameters in dhGroupArray)
    {
      if (groupForDhParameters != null && groupForDhParameters.P.Equals(p) && groupForDhParameters.G.Equals(g))
        return groupForDhParameters;
    }
    return (DHGroup) null;
  }

  public static TlsDHConfig ReceiveDHConfig(
    TlsContext context,
    TlsDHGroupVerifier dhGroupVerifier,
    Stream input)
  {
    BigInteger p = TlsDHUtilities.ReadDHParameter(input);
    BigInteger g = TlsDHUtilities.ReadDHParameter(input);
    int groupForDhParameters = TlsDHUtilities.GetNamedGroupForDHParameters(p, g);
    if (groupForDhParameters < 0)
    {
      DHGroup dhGroup = TlsDHUtilities.GetStandardGroupForDHParameters(p, g) ?? new DHGroup(p, (BigInteger) null, g, 0);
      return dhGroupVerifier.Accept(dhGroup) ? new TlsDHConfig(dhGroup) : throw new TlsFatalAlert((short) 71);
    }
    int[] clientSupportedGroups = context.SecurityParameters.ClientSupportedGroups;
    return clientSupportedGroups == null || Arrays.Contains(clientSupportedGroups, groupForDhParameters) ? new TlsDHConfig(groupForDhParameters, false) : throw new TlsFatalAlert((short) 47);
  }

  public static BigInteger ReadDHParameter(Stream input)
  {
    return new BigInteger(1, TlsUtilities.ReadOpaque16(input, 1));
  }

  public static void WriteDHConfig(TlsDHConfig dhConfig, Stream output)
  {
    DHGroup dhGroup = TlsDHUtilities.GetDHGroup(dhConfig);
    TlsDHUtilities.WriteDHParameter(dhGroup.P, output);
    TlsDHUtilities.WriteDHParameter(dhGroup.G, output);
  }

  public static void WriteDHParameter(BigInteger x, Stream output)
  {
    TlsUtilities.WriteOpaque16(BigIntegers.AsUnsignedByteArray(x), output);
  }
}
