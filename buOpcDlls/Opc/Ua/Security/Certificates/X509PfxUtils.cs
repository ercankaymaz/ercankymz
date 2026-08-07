// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509PfxUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class X509PfxUtils
{
  public const int TestBlockSize = 32 /*0x20*/;

  private static X509KeyUsageFlags GetKeyUsage(X509Certificate2 cert)
  {
    X509KeyUsageFlags keyUsage = X509KeyUsageFlags.None;
    foreach (X509KeyUsageExtension keyUsageExtension in cert.Extensions.OfType<X509KeyUsageExtension>())
      keyUsage |= keyUsageExtension.KeyUsages;
    return keyUsage;
  }

  public static bool VerifyRSAKeyPair(
    X509Certificate2 certWithPublicKey,
    X509Certificate2 certWithPrivateKey,
    bool throwOnError = false)
  {
    bool flag = false;
    try
    {
      using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(certWithPrivateKey))
      {
        using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(certWithPublicKey))
        {
          if (rsaPrivateKey == null || rsaPublicKey == null)
            throw new CryptographicException("The certificate does not contain a RSA public/private key pair.");
          X509KeyUsageFlags keyUsage = X509PfxUtils.GetKeyUsage(certWithPublicKey);
          if ((keyUsage & X509KeyUsageFlags.DataEncipherment) != X509KeyUsageFlags.None)
          {
            flag = X509PfxUtils.VerifyRSAKeyPairCrypt(rsaPublicKey, rsaPrivateKey);
          }
          else
          {
            if ((keyUsage & X509KeyUsageFlags.DigitalSignature) == X509KeyUsageFlags.None)
              throw new CryptographicException("Don't know how to verify the public/private key pair.");
            flag = X509PfxUtils.VerifyRSAKeyPairSign(rsaPublicKey, rsaPrivateKey);
          }
        }
      }
    }
    catch (Exception ex)
    {
      if (throwOnError)
      {
        throwOnError = false;
        throw;
      }
    }
    return !(!flag & throwOnError) ? flag : throw new CryptographicException("The public/private key pair in the certficates do not match.");
  }

  public static X509Certificate2 CreateCertificateFromPKCS12(byte[] rawData, string password)
  {
    Exception innerException = (Exception) null;
    X509Certificate2 certificateFromPkcS12 = (X509Certificate2) null;
    X509KeyStorageFlags[] x509KeyStorageFlagsArray = new X509KeyStorageFlags[2]
    {
      X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet,
      X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet
    };
    foreach (X509KeyStorageFlags keyStorageFlags in x509KeyStorageFlagsArray)
    {
      try
      {
        certificateFromPkcS12 = new X509Certificate2(rawData, password ?? string.Empty, keyStorageFlags);
        if (X509PfxUtils.VerifyRSAKeyPair(certificateFromPkcS12, certificateFromPkcS12, true))
          return certificateFromPkcS12;
      }
      catch (Exception ex)
      {
        innerException = ex;
        certificateFromPkcS12?.Dispose();
        certificateFromPkcS12 = (X509Certificate2) null;
      }
    }
    return certificateFromPkcS12 != null ? certificateFromPkcS12 : throw new NotSupportedException("Creating X509Certificate from PKCS #12 store failed", innerException);
  }

  internal static bool VerifyRSAKeyPairCrypt(RSA rsaPublicKey, RSA rsaPrivateKey)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    new Random().NextBytes(numArray);
    byte[] data = rsaPublicKey.Encrypt(numArray, RSAEncryptionPadding.OaepSHA1);
    byte[] second = rsaPrivateKey.Decrypt(data, RSAEncryptionPadding.OaepSHA1);
    return second != null && ((IEnumerable<byte>) numArray).SequenceEqual<byte>((IEnumerable<byte>) second);
  }

  internal static bool VerifyRSAKeyPairSign(RSA rsaPublicKey, RSA rsaPrivateKey)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    new Random().NextBytes(numArray);
    byte[] signature = rsaPrivateKey.SignData(numArray, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    return rsaPublicKey.VerifyData(numArray, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
  }

  public static bool VerifyECDsaKeyPair(
    X509Certificate2 certWithPublicKey,
    X509Certificate2 certWithPrivateKey,
    bool throwOnError = false)
  {
    bool flag = false;
    using (ECDsa ecDsaPublicKey = ECDsaCertificateExtensions.GetECDsaPublicKey(certWithPrivateKey))
    {
      using (ECDsa ecDsaPrivateKey = ECDsaCertificateExtensions.GetECDsaPrivateKey(certWithPublicKey))
      {
        try
        {
          if ((X509PfxUtils.GetKeyUsage(certWithPublicKey) & X509KeyUsageFlags.DigitalSignature) != X509KeyUsageFlags.None)
            flag = X509PfxUtils.VerifyECDsaKeyPairSign(ecDsaPublicKey, ecDsaPrivateKey);
          else if (throwOnError)
            throw new CryptographicException("Don't know how to verify the public/private key pair.");
        }
        catch (Exception ex)
        {
          if (throwOnError)
          {
            throwOnError = false;
            throw;
          }
        }
      }
    }
    return !(!flag & throwOnError) ? flag : throw new CryptographicException("The public/private key pair in the certficates do not match.");
  }

  internal static bool VerifyECDsaKeyPairSign(ECDsa ecdsaPublicKey, ECDsa ecdsaPrivateKey)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    new Random().NextBytes(numArray);
    byte[] signature = ecdsaPrivateKey.SignData(numArray, HashAlgorithmName.SHA256);
    return ecdsaPublicKey.VerifyData(numArray, signature, HashAlgorithmName.SHA256);
  }
}
