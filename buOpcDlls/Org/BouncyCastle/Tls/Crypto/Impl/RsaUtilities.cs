// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.RsaUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public abstract class RsaUtilities
{
  private static readonly byte[] RSAPSSParams_256_A;
  private static readonly byte[] RSAPSSParams_384_A;
  private static readonly byte[] RSAPSSParams_512_A;
  private static readonly byte[] RSAPSSParams_256_B;
  private static readonly byte[] RSAPSSParams_384_B;
  private static readonly byte[] RSAPSSParams_512_B;

  static RsaUtilities()
  {
    AlgorithmIdentifier algorithmIdentifier1 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256);
    AlgorithmIdentifier algorithmIdentifier2 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384);
    AlgorithmIdentifier algorithmIdentifier3 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512);
    AlgorithmIdentifier algorithmIdentifier4 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256, (Asn1Encodable) DerNull.Instance);
    AlgorithmIdentifier algorithmIdentifier5 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384, (Asn1Encodable) DerNull.Instance);
    AlgorithmIdentifier algorithmIdentifier6 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512, (Asn1Encodable) DerNull.Instance);
    AlgorithmIdentifier maskGenAlgorithm1 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier1);
    AlgorithmIdentifier maskGenAlgorithm2 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier2);
    AlgorithmIdentifier maskGenAlgorithm3 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier3);
    AlgorithmIdentifier maskGenAlgorithm4 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier4);
    AlgorithmIdentifier maskGenAlgorithm5 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier5);
    AlgorithmIdentifier maskGenAlgorithm6 = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier6);
    DerInteger saltLength1 = new DerInteger(TlsCryptoUtilities.GetHashOutputSize(4));
    DerInteger saltLength2 = new DerInteger(TlsCryptoUtilities.GetHashOutputSize(5));
    DerInteger saltLength3 = new DerInteger(TlsCryptoUtilities.GetHashOutputSize(6));
    DerInteger trailerField = new DerInteger(1);
    try
    {
      RsaUtilities.RSAPSSParams_256_A = new RsassaPssParameters(algorithmIdentifier1, maskGenAlgorithm1, saltLength1, trailerField).GetEncoded("DER");
      RsaUtilities.RSAPSSParams_384_A = new RsassaPssParameters(algorithmIdentifier2, maskGenAlgorithm2, saltLength2, trailerField).GetEncoded("DER");
      RsaUtilities.RSAPSSParams_512_A = new RsassaPssParameters(algorithmIdentifier3, maskGenAlgorithm3, saltLength3, trailerField).GetEncoded("DER");
      RsaUtilities.RSAPSSParams_256_B = new RsassaPssParameters(algorithmIdentifier4, maskGenAlgorithm4, saltLength1, trailerField).GetEncoded("DER");
      RsaUtilities.RSAPSSParams_384_B = new RsassaPssParameters(algorithmIdentifier5, maskGenAlgorithm5, saltLength2, trailerField).GetEncoded("DER");
      RsaUtilities.RSAPSSParams_512_B = new RsassaPssParameters(algorithmIdentifier6, maskGenAlgorithm6, saltLength3, trailerField).GetEncoded("DER");
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException(ex.Message);
    }
  }

  public static bool SupportsPkcs1(AlgorithmIdentifier pubKeyAlgID)
  {
    DerObjectIdentifier algorithm = pubKeyAlgID.Algorithm;
    return PkcsObjectIdentifiers.RsaEncryption.Equals((Asn1Object) algorithm) || X509ObjectIdentifiers.IdEARsa.Equals((Asn1Object) algorithm);
  }

  public static bool SupportsPss_Pss(short signatureAlgorithm, AlgorithmIdentifier pubKeyAlgID)
  {
    DerObjectIdentifier algorithm = pubKeyAlgID.Algorithm;
    if (!PkcsObjectIdentifiers.IdRsassaPss.Equals((Asn1Object) algorithm))
      return false;
    Asn1Encodable parameters = pubKeyAlgID.Parameters;
    switch (parameters)
    {
      case null:
      case DerNull _:
        switch (signatureAlgorithm)
        {
          case 9:
          case 10:
          case 11:
            return true;
          default:
            return false;
        }
      default:
        byte[] encoded;
        try
        {
          encoded = parameters.ToAsn1Object().GetEncoded("DER");
        }
        catch (Exception ex)
        {
          return false;
        }
        byte[] a1;
        byte[] a2;
        switch (signatureAlgorithm)
        {
          case 9:
            a1 = RsaUtilities.RSAPSSParams_256_A;
            a2 = RsaUtilities.RSAPSSParams_256_B;
            break;
          case 10:
            a1 = RsaUtilities.RSAPSSParams_384_A;
            a2 = RsaUtilities.RSAPSSParams_384_B;
            break;
          case 11:
            a1 = RsaUtilities.RSAPSSParams_512_A;
            a2 = RsaUtilities.RSAPSSParams_512_B;
            break;
          default:
            return false;
        }
        return Arrays.AreEqual(a1, encoded) || Arrays.AreEqual(a2, encoded);
    }
  }

  public static bool SupportsPss_Rsae(AlgorithmIdentifier pubKeyAlgID)
  {
    DerObjectIdentifier algorithm = pubKeyAlgID.Algorithm;
    return PkcsObjectIdentifiers.RsaEncryption.Equals((Asn1Object) algorithm);
  }
}
