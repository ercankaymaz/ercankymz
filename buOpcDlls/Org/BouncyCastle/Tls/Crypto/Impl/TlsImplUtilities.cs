// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.TlsImplUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public abstract class TlsImplUtilities
{
  public static bool IsSsl(TlsCryptoParameters cryptoParams) => cryptoParams.ServerVersion.IsSsl;

  public static bool IsTlsV10(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv10.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV10(TlsCryptoParameters cryptoParams)
  {
    return TlsImplUtilities.IsTlsV10(cryptoParams.ServerVersion);
  }

  public static bool IsTlsV11(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv11.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV11(TlsCryptoParameters cryptoParams)
  {
    return TlsImplUtilities.IsTlsV11(cryptoParams.ServerVersion);
  }

  public static bool IsTlsV12(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv12.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV12(TlsCryptoParameters cryptoParams)
  {
    return TlsImplUtilities.IsTlsV12(cryptoParams.ServerVersion);
  }

  public static bool IsTlsV13(ProtocolVersion version)
  {
    return ProtocolVersion.TLSv13.IsEqualOrEarlierVersionOf(version.GetEquivalentTlsVersion());
  }

  public static bool IsTlsV13(TlsCryptoParameters cryptoParams)
  {
    return TlsImplUtilities.IsTlsV13(cryptoParams.ServerVersion);
  }

  public static byte[] CalculateKeyBlock(TlsCryptoParameters cryptoParams, int length)
  {
    SecurityParameters securityParameters = cryptoParams.SecurityParameters;
    TlsSecret masterSecret = securityParameters.MasterSecret;
    int prfAlgorithm1 = securityParameters.PrfAlgorithm;
    byte[] numArray = Arrays.Concatenate(securityParameters.ServerRandom, securityParameters.ClientRandom);
    int prfAlgorithm2 = prfAlgorithm1;
    byte[] seed = numArray;
    int length1 = length;
    return masterSecret.DeriveUsingPrf(prfAlgorithm2, "key expansion", seed, length1).Extract();
  }
}
