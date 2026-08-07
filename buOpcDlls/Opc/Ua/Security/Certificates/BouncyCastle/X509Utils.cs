// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.BouncyCastle.X509Utils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates.BouncyCastle;

internal static class X509Utils
{
  internal static byte[] CreatePfxWithPrivateKey(
    Org.BouncyCastle.X509.X509Certificate certificate,
    string friendlyName,
    AsymmetricKeyParameter privateKey,
    string passcode,
    SecureRandom random)
  {
    using (MemoryStream memoryStream = new MemoryStream())
    {
      Pkcs12StoreBuilder pkcs12StoreBuilder = new Pkcs12StoreBuilder();
      pkcs12StoreBuilder.SetUseDerEncoding(true);
      Pkcs12Store pkcs12Store = pkcs12StoreBuilder.Build();
      X509CertificateEntry[] chain = new X509CertificateEntry[1]
      {
        new X509CertificateEntry(certificate)
      };
      if (string.IsNullOrEmpty(friendlyName))
        friendlyName = X509Utils.GetCertificateCommonName(certificate);
      pkcs12Store.SetKeyEntry(friendlyName, new AsymmetricKeyEntry(privateKey), chain);
      pkcs12Store.Save((Stream) memoryStream, passcode.ToCharArray(), random);
      return memoryStream.ToArray();
    }
  }

  internal static string GetRSAHashAlgorithm(HashAlgorithmName hashAlgorithmName)
  {
    if (hashAlgorithmName == HashAlgorithmName.SHA1)
      return "SHA1WITHRSA";
    if (hashAlgorithmName == HashAlgorithmName.SHA256)
      return "SHA256WITHRSA";
    if (hashAlgorithmName == HashAlgorithmName.SHA384)
      return "SHA384WITHRSA";
    if (!(hashAlgorithmName == HashAlgorithmName.SHA512))
      throw new CryptographicException($"The hash algorithm {hashAlgorithmName} is not supported");
    return "SHA512WITHRSA";
  }

  internal static RsaKeyParameters GetPublicKeyParameter(X509Certificate2 certificate)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(certificate))
      return X509Utils.GetPublicKeyParameter(rsaPublicKey);
  }

  internal static RsaKeyParameters GetPublicKeyParameter(RSA rsa)
  {
    RSAParameters rsaParameters = rsa.ExportParameters(false);
    return new RsaKeyParameters(false, new BigInteger(1, rsaParameters.Modulus), new BigInteger(1, rsaParameters.Exponent));
  }

  internal static RsaPrivateCrtKeyParameters GetPrivateKeyParameter(X509Certificate2 certificate)
  {
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(certificate))
      return X509Utils.GetPrivateKeyParameter(rsaPrivateKey);
  }

  internal static RsaPrivateCrtKeyParameters GetPrivateKeyParameter(RSA rsa)
  {
    RSAParameters rsaParameters = rsa.ExportParameters(true);
    return new RsaPrivateCrtKeyParameters(new BigInteger(1, rsaParameters.Modulus), new BigInteger(1, rsaParameters.Exponent), new BigInteger(1, rsaParameters.D), new BigInteger(1, rsaParameters.P), new BigInteger(1, rsaParameters.Q), new BigInteger(1, rsaParameters.DP), new BigInteger(1, rsaParameters.DQ), new BigInteger(1, rsaParameters.InverseQ));
  }

  internal static BigInteger GetSerialNumber(X509Certificate2 certificate)
  {
    return new BigInteger(1, ((IEnumerable<byte>) certificate.GetSerialNumber()).Reverse<byte>().ToArray<byte>());
  }

  internal static string GetCertificateCommonName(Org.BouncyCastle.X509.X509Certificate certificate)
  {
    IList<string> valueList = certificate.SubjectDN.GetValueList(X509Name.CN);
    return valueList.Count > 0 ? valueList[0].ToString() : string.Empty;
  }

  internal static string GeneratePasscode()
  {
    using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
    {
      byte[] numArray = new byte[18];
      randomNumberGenerator.GetBytes(numArray);
      return Convert.ToBase64String(numArray);
    }
  }

  internal static RSA SetRSAPublicKey(byte[] publicKey)
  {
    RsaKeyParameters key = PublicKeyFactory.CreateKey(publicKey) as RsaKeyParameters;
    RSAParameters parameters = new RSAParameters()
    {
      Exponent = key.Exponent.ToByteArrayUnsigned(),
      Modulus = key.Modulus.ToByteArrayUnsigned()
    };
    RSA rsa = RSA.Create();
    rsa.ImportParameters(parameters);
    return rsa;
  }
}
