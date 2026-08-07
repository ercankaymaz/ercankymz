// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public interface TlsCertificate
{
  TlsEncryptor CreateEncryptor(int tlsCertificateRole);

  TlsVerifier CreateVerifier(short signatureAlgorithm);

  Tls13Verifier CreateVerifier(int signatureScheme);

  byte[] GetEncoded();

  byte[] GetExtension(DerObjectIdentifier extensionOid);

  BigInteger SerialNumber { get; }

  string SigAlgOid { get; }

  Asn1Encodable GetSigAlgParams();

  short GetLegacySignatureAlgorithm();

  bool SupportsSignatureAlgorithm(short signatureAlgorithm);

  bool SupportsSignatureAlgorithmCA(short signatureAlgorithm);

  TlsCertificate CheckUsageInRole(int tlsCertificateRole);
}
