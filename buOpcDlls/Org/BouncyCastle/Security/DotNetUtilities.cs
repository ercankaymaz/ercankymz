// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.DotNetUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Security.Cryptography;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class DotNetUtilities
{
  public static System.Security.Cryptography.X509Certificates.X509Certificate ToX509Certificate(
    X509CertificateStructure x509Struct)
  {
    return new System.Security.Cryptography.X509Certificates.X509Certificate(x509Struct.GetDerEncoded());
  }

  public static System.Security.Cryptography.X509Certificates.X509Certificate ToX509Certificate(
    Org.BouncyCastle.X509.X509Certificate x509Cert)
  {
    return new System.Security.Cryptography.X509Certificates.X509Certificate(x509Cert.GetEncoded());
  }

  public static Org.BouncyCastle.X509.X509Certificate FromX509Certificate(System.Security.Cryptography.X509Certificates.X509Certificate x509Cert)
  {
    return new X509CertificateParser().ReadCertificate(x509Cert.GetRawCertData());
  }

  public static AsymmetricCipherKeyPair GetDsaKeyPair(DSA dsa)
  {
    return DotNetUtilities.GetDsaKeyPair(dsa.ExportParameters(true));
  }

  public static AsymmetricCipherKeyPair GetDsaKeyPair(DSAParameters dp)
  {
    DsaPublicKeyParameters dsaPublicKey = DotNetUtilities.GetDsaPublicKey(dp);
    DsaPrivateKeyParameters privateParameter = new DsaPrivateKeyParameters(new BigInteger(1, dp.X), dsaPublicKey.Parameters);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) dsaPublicKey, (AsymmetricKeyParameter) privateParameter);
  }

  public static DsaPublicKeyParameters GetDsaPublicKey(DSA dsa)
  {
    return DotNetUtilities.GetDsaPublicKey(dsa.ExportParameters(false));
  }

  public static DsaPublicKeyParameters GetDsaPublicKey(DSAParameters dp)
  {
    DsaValidationParameters parameters1 = dp.Seed != null ? new DsaValidationParameters(dp.Seed, dp.Counter) : (DsaValidationParameters) null;
    DsaParameters parameters2 = new DsaParameters(new BigInteger(1, dp.P), new BigInteger(1, dp.Q), new BigInteger(1, dp.G), parameters1);
    return new DsaPublicKeyParameters(new BigInteger(1, dp.Y), parameters2);
  }

  public static AsymmetricCipherKeyPair GetRsaKeyPair(RSA rsa)
  {
    return DotNetUtilities.GetRsaKeyPair(rsa.ExportParameters(true));
  }

  public static AsymmetricCipherKeyPair GetRsaKeyPair(RSAParameters rp)
  {
    RsaKeyParameters rsaPublicKey = DotNetUtilities.GetRsaPublicKey(rp);
    RsaPrivateCrtKeyParameters privateParameter = new RsaPrivateCrtKeyParameters(rsaPublicKey.Modulus, rsaPublicKey.Exponent, new BigInteger(1, rp.D), new BigInteger(1, rp.P), new BigInteger(1, rp.Q), new BigInteger(1, rp.DP), new BigInteger(1, rp.DQ), new BigInteger(1, rp.InverseQ));
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) rsaPublicKey, (AsymmetricKeyParameter) privateParameter);
  }

  public static RsaKeyParameters GetRsaPublicKey(RSA rsa)
  {
    return DotNetUtilities.GetRsaPublicKey(rsa.ExportParameters(false));
  }

  public static RsaKeyParameters GetRsaPublicKey(RSAParameters rp)
  {
    return new RsaKeyParameters(false, new BigInteger(1, rp.Modulus), new BigInteger(1, rp.Exponent));
  }

  public static AsymmetricCipherKeyPair GetKeyPair(AsymmetricAlgorithm privateKey)
  {
    switch (privateKey)
    {
      case DSA dsa:
        return DotNetUtilities.GetDsaKeyPair(dsa);
      case RSA rsa:
        return DotNetUtilities.GetRsaKeyPair(rsa);
      default:
        throw new ArgumentException("Unsupported algorithm specified", nameof (privateKey));
    }
  }

  public static RSA ToRSA(RsaKeyParameters rsaKey)
  {
    return (RSA) DotNetUtilities.CreateRSAProvider(DotNetUtilities.ToRSAParameters(rsaKey));
  }

  public static RSA ToRSA(RsaKeyParameters rsaKey, CspParameters csp)
  {
    return (RSA) DotNetUtilities.CreateRSAProvider(DotNetUtilities.ToRSAParameters(rsaKey), csp);
  }

  public static RSA ToRSA(RsaPrivateCrtKeyParameters privKey)
  {
    return (RSA) DotNetUtilities.CreateRSAProvider(DotNetUtilities.ToRSAParameters(privKey));
  }

  public static RSA ToRSA(RsaPrivateCrtKeyParameters privKey, CspParameters csp)
  {
    return (RSA) DotNetUtilities.CreateRSAProvider(DotNetUtilities.ToRSAParameters(privKey), csp);
  }

  public static RSA ToRSA(RsaPrivateKeyStructure privKey)
  {
    return (RSA) DotNetUtilities.CreateRSAProvider(DotNetUtilities.ToRSAParameters(privKey));
  }

  public static RSA ToRSA(RsaPrivateKeyStructure privKey, CspParameters csp)
  {
    return (RSA) DotNetUtilities.CreateRSAProvider(DotNetUtilities.ToRSAParameters(privKey), csp);
  }

  public static RSAParameters ToRSAParameters(RsaKeyParameters rsaKey)
  {
    RSAParameters rsaParameters = new RSAParameters();
    rsaParameters.Modulus = rsaKey.Modulus.ToByteArrayUnsigned();
    if (rsaKey.IsPrivate)
      rsaParameters.D = DotNetUtilities.ConvertRSAParametersField(rsaKey.Exponent, rsaParameters.Modulus.Length);
    else
      rsaParameters.Exponent = rsaKey.Exponent.ToByteArrayUnsigned();
    return rsaParameters;
  }

  public static RSAParameters ToRSAParameters(RsaPrivateCrtKeyParameters privKey)
  {
    RSAParameters rsaParameters = new RSAParameters()
    {
      Modulus = privKey.Modulus.ToByteArrayUnsigned(),
      Exponent = privKey.PublicExponent.ToByteArrayUnsigned(),
      P = privKey.P.ToByteArrayUnsigned(),
      Q = privKey.Q.ToByteArrayUnsigned()
    };
    rsaParameters.D = DotNetUtilities.ConvertRSAParametersField(privKey.Exponent, rsaParameters.Modulus.Length);
    rsaParameters.DP = DotNetUtilities.ConvertRSAParametersField(privKey.DP, rsaParameters.P.Length);
    rsaParameters.DQ = DotNetUtilities.ConvertRSAParametersField(privKey.DQ, rsaParameters.Q.Length);
    rsaParameters.InverseQ = DotNetUtilities.ConvertRSAParametersField(privKey.QInv, rsaParameters.Q.Length);
    return rsaParameters;
  }

  public static RSAParameters ToRSAParameters(RsaPrivateKeyStructure privKey)
  {
    RSAParameters rsaParameters = new RSAParameters()
    {
      Modulus = privKey.Modulus.ToByteArrayUnsigned(),
      Exponent = privKey.PublicExponent.ToByteArrayUnsigned(),
      P = privKey.Prime1.ToByteArrayUnsigned(),
      Q = privKey.Prime2.ToByteArrayUnsigned()
    };
    rsaParameters.D = DotNetUtilities.ConvertRSAParametersField(privKey.PrivateExponent, rsaParameters.Modulus.Length);
    rsaParameters.DP = DotNetUtilities.ConvertRSAParametersField(privKey.Exponent1, rsaParameters.P.Length);
    rsaParameters.DQ = DotNetUtilities.ConvertRSAParametersField(privKey.Exponent2, rsaParameters.Q.Length);
    rsaParameters.InverseQ = DotNetUtilities.ConvertRSAParametersField(privKey.Coefficient, rsaParameters.Q.Length);
    return rsaParameters;
  }

  private static byte[] ConvertRSAParametersField(BigInteger n, int size)
  {
    return BigIntegers.AsUnsignedByteArray(size, n);
  }

  private static RSACryptoServiceProvider CreateRSAProvider(RSAParameters rp)
  {
    return DotNetUtilities.CreateRSAProvider(rp, new CspParameters()
    {
      KeyContainerName = $"BouncyCastle-{Guid.NewGuid()}"
    });
  }

  private static RSACryptoServiceProvider CreateRSAProvider(RSAParameters rp, CspParameters csp)
  {
    RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(csp);
    rsaProvider.ImportParameters(rp);
    return rsaProvider;
  }
}
