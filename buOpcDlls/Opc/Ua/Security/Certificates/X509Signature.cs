// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509Signature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class X509Signature
{
  public byte[] Tbs { get; private set; }

  public byte[] Signature { get; private set; }

  public byte[] SignatureAlgorithmIdentifier { get; private set; }

  public string SignatureAlgorithm { get; private set; }

  public HashAlgorithmName Name { get; private set; }

  public X509Signature(byte[] signedBlob) => this.Decode(signedBlob);

  public X509Signature(byte[] tbs, byte[] signature, byte[] signatureAlgorithmIdentifier)
  {
    this.Tbs = tbs;
    this.Signature = signature;
    this.SignatureAlgorithmIdentifier = signatureAlgorithmIdentifier;
    this.SignatureAlgorithm = X509Signature.DecodeAlgorithm(signatureAlgorithmIdentifier);
    this.Name = Oids.GetHashAlgorithmName(this.SignatureAlgorithm);
  }

  public byte[] Encode()
  {
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    System.Formats.Asn1.Asn1Tag sequence = System.Formats.Asn1.Asn1Tag.Sequence;
    asnWriter.PushSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
    asnWriter.WriteEncodedValue((System.ReadOnlySpan<byte>) this.Tbs);
    if (this.SignatureAlgorithmIdentifier != null)
    {
      asnWriter.WriteEncodedValue((System.ReadOnlySpan<byte>) this.SignatureAlgorithmIdentifier);
    }
    else
    {
      asnWriter.PushSequence();
      string rsaOid = Oids.GetRSAOid(this.Name);
      asnWriter.WriteObjectIdentifier(rsaOid);
      asnWriter.WriteNull();
      asnWriter.PopSequence();
    }
    asnWriter.WriteBitString((System.ReadOnlySpan<byte>) this.Signature);
    asnWriter.PopSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
    return asnWriter.Encode();
  }

  private void Decode(byte[] crl)
  {
    try
    {
      System.Formats.Asn1.AsnReader asnReader = new System.Formats.Asn1.AsnReader((System.ReadOnlyMemory<byte>) crl, System.Formats.Asn1.AsnEncodingRules.DER).ReadSequence(new System.Formats.Asn1.Asn1Tag?(System.Formats.Asn1.Asn1Tag.Sequence));
      this.Tbs = asnReader != null ? asnReader.ReadEncodedValue().ToArray() : throw new CryptographicException("No valid data in the X509 signature.");
      this.SignatureAlgorithm = asnReader.ReadSequence().ReadObjectIdentifier();
      this.Name = Oids.GetHashAlgorithmName(this.SignatureAlgorithm);
      int unusedBitCount;
      this.Signature = asnReader.ReadBitString(out unusedBitCount);
      if (unusedBitCount != 0)
        throw new AsnContentException("Unexpected data in signature.");
      asnReader.ThrowIfNotEmpty();
    }
    catch (AsnContentException ex)
    {
      throw new CryptographicException("Failed to decode the X509 signature.", (Exception) ex);
    }
  }

  public bool Verify(X509Certificate2 certificate)
  {
    string signatureAlgorithm = this.SignatureAlgorithm;
    if (signatureAlgorithm != null)
    {
      switch (signatureAlgorithm.Length)
      {
        case 17:
          if (signatureAlgorithm == "1.2.840.10045.4.1")
            break;
          goto label_13;
        case 19:
          switch (signatureAlgorithm[18])
          {
            case '2':
              if (signatureAlgorithm == "1.2.840.10045.4.3.2")
                break;
              goto label_13;
            case '3':
              if (signatureAlgorithm == "1.2.840.10045.4.3.3")
                break;
              goto label_13;
            case '4':
              if (!(signatureAlgorithm == "1.2.840.10045.4.3.4"))
                goto label_13;
              break;
            default:
              goto label_13;
          }
          break;
        case 20:
          if (signatureAlgorithm == "1.2.840.113549.1.1.5")
            goto label_14;
          goto label_13;
        case 21:
          switch (signatureAlgorithm[20])
          {
            case '1':
              if (signatureAlgorithm == "1.2.840.113549.1.1.11")
                goto label_14;
              goto label_13;
            case '2':
              if (signatureAlgorithm == "1.2.840.113549.1.1.12")
                goto label_14;
              goto label_13;
            case '3':
              if (signatureAlgorithm == "1.2.840.113549.1.1.13")
                goto label_14;
              goto label_13;
            default:
              goto label_13;
          }
        default:
          goto label_13;
      }
      return this.VerifyForECDsa(certificate);
label_14:
      return this.VerifyForRSA(certificate, RSASignaturePadding.Pkcs1);
    }
label_13:
    throw new CryptographicException("Failed to verify signature due to unknown signature algorithm.");
  }

  private bool VerifyForRSA(X509Certificate2 certificate, RSASignaturePadding padding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(certificate))
      return rsaPublicKey.VerifyData(this.Tbs, this.Signature, this.Name, padding);
  }

  private bool VerifyForECDsa(X509Certificate2 certificate)
  {
    using (ECDsa ecDsaPublicKey = ECDsaCertificateExtensions.GetECDsaPublicKey(certificate))
    {
      byte[] signature = X509Signature.DecodeECDsa((System.ReadOnlyMemory<byte>) this.Signature, ecDsaPublicKey.KeySize);
      return ecDsaPublicKey.VerifyData(this.Tbs, signature, this.Name);
    }
  }

  private static string DecodeAlgorithm(byte[] oid)
  {
    System.Formats.Asn1.AsnReader asnReader1 = new System.Formats.Asn1.AsnReader((System.ReadOnlyMemory<byte>) oid, System.Formats.Asn1.AsnEncodingRules.DER);
    System.Formats.Asn1.AsnReader asnReader2 = asnReader1.ReadSequence();
    asnReader1.ThrowIfNotEmpty();
    string str = asnReader2.ReadObjectIdentifier();
    if (asnReader2.HasData)
      asnReader2.ReadNull();
    asnReader2.ThrowIfNotEmpty();
    return str;
  }

  private static byte[] EncodeECDsa(byte[] signature)
  {
    AsnWriter asnWriter = new AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
    System.Formats.Asn1.Asn1Tag sequence = System.Formats.Asn1.Asn1Tag.Sequence;
    asnWriter.PushSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
    int num = signature.Length / 2;
    asnWriter.WriteIntegerUnsigned(new System.ReadOnlySpan<byte>(signature, 0, num));
    asnWriter.WriteIntegerUnsigned(new System.ReadOnlySpan<byte>(signature, num, num));
    asnWriter.PopSequence(new System.Formats.Asn1.Asn1Tag?(sequence));
    return asnWriter.Encode();
  }

  private static byte[] DecodeECDsa(System.ReadOnlyMemory<byte> signature, int keySize)
  {
    System.Formats.Asn1.AsnReader asnReader1 = new System.Formats.Asn1.AsnReader(signature, System.Formats.Asn1.AsnEncodingRules.DER);
    System.Formats.Asn1.AsnReader asnReader2 = asnReader1.ReadSequence();
    asnReader1.ThrowIfNotEmpty();
    System.ReadOnlyMemory<byte> readOnlyMemory1 = asnReader2.ReadIntegerBytes();
    System.ReadOnlyMemory<byte> readOnlyMemory2 = asnReader2.ReadIntegerBytes();
    asnReader2.ThrowIfNotEmpty();
    keySize >>= 3;
    if (readOnlyMemory1.Span[0] == (byte) 0 && readOnlyMemory1.Length > keySize)
      readOnlyMemory1 = readOnlyMemory1.Slice(1);
    if (readOnlyMemory2.Span[0] == (byte) 0 && readOnlyMemory2.Length > keySize)
      readOnlyMemory2 = readOnlyMemory2.Slice(1);
    byte[] array = new byte[2 * keySize];
    int start1 = keySize - readOnlyMemory1.Length;
    readOnlyMemory1.CopyTo(new Memory<byte>(array, start1, readOnlyMemory1.Length));
    int start2 = 2 * keySize - readOnlyMemory2.Length;
    readOnlyMemory2.CopyTo(new Memory<byte>(array, start2, readOnlyMemory2.Length));
    return array;
  }
}
