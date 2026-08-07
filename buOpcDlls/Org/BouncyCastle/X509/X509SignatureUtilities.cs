// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509SignatureUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.X509;

internal class X509SignatureUtilities
{
  private static readonly Asn1Null derNull = (Asn1Null) DerNull.Instance;

  internal static void SetSignatureParameters(ISigner signature, Asn1Encodable parameters)
  {
    if (parameters == null)
      return;
    X509SignatureUtilities.derNull.Equals((object) parameters);
  }

  internal static string GetSignatureName(AlgorithmIdentifier sigAlgId)
  {
    Asn1Encodable parameters = sigAlgId.Parameters;
    if (parameters != null && !X509SignatureUtilities.derNull.Equals((object) parameters))
    {
      if (sigAlgId.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss))
        return X509SignatureUtilities.GetDigestAlgName(RsassaPssParameters.GetInstance((object) parameters).HashAlgorithm.Algorithm) + "withRSAandMGF1";
      if (sigAlgId.Algorithm.Equals((Asn1Object) X9ObjectIdentifiers.ECDsaWithSha2))
        return X509SignatureUtilities.GetDigestAlgName((DerObjectIdentifier) Asn1Sequence.GetInstance((object) parameters)[0]) + "withECDSA";
    }
    return SignerUtilities.GetEncodingName(sigAlgId.Algorithm) ?? sigAlgId.Algorithm.Id;
  }

  private static string GetDigestAlgName(DerObjectIdentifier digestAlgOID)
  {
    if (PkcsObjectIdentifiers.MD5.Equals((Asn1Object) digestAlgOID))
      return "MD5";
    if (OiwObjectIdentifiers.IdSha1.Equals((Asn1Object) digestAlgOID))
      return "SHA1";
    if (NistObjectIdentifiers.IdSha224.Equals((Asn1Object) digestAlgOID))
      return "SHA224";
    if (NistObjectIdentifiers.IdSha256.Equals((Asn1Object) digestAlgOID))
      return "SHA256";
    if (NistObjectIdentifiers.IdSha384.Equals((Asn1Object) digestAlgOID))
      return "SHA384";
    if (NistObjectIdentifiers.IdSha512.Equals((Asn1Object) digestAlgOID))
      return "SHA512";
    if (TeleTrusTObjectIdentifiers.RipeMD128.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD128";
    if (TeleTrusTObjectIdentifiers.RipeMD160.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD160";
    if (TeleTrusTObjectIdentifiers.RipeMD256.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD256";
    return CryptoProObjectIdentifiers.GostR3411.Equals((Asn1Object) digestAlgOID) ? "GOST3411" : digestAlgOID.Id;
  }
}
