// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RsaUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Test;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

internal static class RsaUtils
{
  internal static readonly Lazy<bool> IsSupportingRSAPssSign = new Lazy<bool>((Func<bool>) (() => !Utils.IsRunningOnMono()));

  internal static RSAEncryptionPadding GetRSAEncryptionPadding(RsaUtils.Padding padding)
  {
    switch (padding)
    {
      case RsaUtils.Padding.Pkcs1:
        return RSAEncryptionPadding.Pkcs1;
      case RsaUtils.Padding.OaepSHA1:
        return RSAEncryptionPadding.OaepSHA1;
      case RsaUtils.Padding.OaepSHA256:
        return RSAEncryptionPadding.OaepSHA256;
      default:
        throw new ServiceResultException("Invalid Padding");
    }
  }

  internal static int GetPlainTextBlockSize(
    X509Certificate2 encryptingCertificate,
    RsaUtils.Padding padding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(encryptingCertificate))
      return RsaUtils.GetPlainTextBlockSize(rsaPublicKey, padding);
  }

  internal static int GetPlainTextBlockSize(RSA rsa, RsaUtils.Padding padding)
  {
    if (rsa != null)
    {
      switch (padding)
      {
        case RsaUtils.Padding.Pkcs1:
          return rsa.KeySize / 8 - 11;
        case RsaUtils.Padding.OaepSHA1:
          return rsa.KeySize / 8 - 42;
        case RsaUtils.Padding.OaepSHA256:
          return rsa.KeySize / 8 - 66;
      }
    }
    return -1;
  }

  internal static int GetCipherTextBlockSize(
    X509Certificate2 encryptingCertificate,
    RsaUtils.Padding padding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(encryptingCertificate))
      return RsaUtils.GetCipherTextBlockSize(rsaPublicKey, padding);
  }

  internal static int GetCipherTextBlockSize(RSA rsa, RsaUtils.Padding padding)
  {
    return rsa != null ? rsa.KeySize / 8 : -1;
  }

  internal static int GetSignatureLength(X509Certificate2 signingCertificate)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(signingCertificate))
    {
      if (rsaPublicKey == null)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No public key for certificate.");
      return rsaPublicKey.KeySize / 8;
    }
  }

  internal static byte[] Rsa_Sign(
    ArraySegment<byte> dataToSign,
    X509Certificate2 signingCertificate,
    HashAlgorithmName hashAlgorithm,
    RSASignaturePadding rsaSignaturePadding)
  {
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(signingCertificate))
    {
      if (rsaPrivateKey == null)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No private key for certificate.");
      return rsaPrivateKey.SignData(dataToSign.Array, dataToSign.Offset, dataToSign.Count, hashAlgorithm, rsaSignaturePadding);
    }
  }

  internal static bool Rsa_Verify(
    ArraySegment<byte> dataToVerify,
    byte[] signature,
    X509Certificate2 signingCertificate,
    HashAlgorithmName hashAlgorithm,
    RSASignaturePadding rsaSignaturePadding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(signingCertificate))
    {
      if (rsaPublicKey == null)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No public key for certificate.");
      return rsaPublicKey.VerifyData(dataToVerify.Array, dataToVerify.Offset, dataToVerify.Count, signature, hashAlgorithm, rsaSignaturePadding);
    }
  }

  internal static byte[] Encrypt(
    byte[] dataToEncrypt,
    X509Certificate2 encryptingCertificate,
    RsaUtils.Padding padding)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(encryptingCertificate))
    {
      int num1 = rsaPublicKey != null ? RsaUtils.GetPlainTextBlockSize(rsaPublicKey, padding) : throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No public key for certificate.");
      int num2 = (dataToEncrypt.Length + 4) / num1 + 1;
      int length1 = num2 * num1;
      int length2 = num2 * RsaUtils.GetCipherTextBlockSize(rsaPublicKey, padding);
      byte[] numArray = new byte[length1];
      numArray[0] = (byte) ((int) byte.MaxValue & dataToEncrypt.Length);
      numArray[1] = (byte) ((65280 & dataToEncrypt.Length) >> 8);
      numArray[2] = (byte) ((16711680 /*0xFF0000*/ & dataToEncrypt.Length) >> 16 /*0x10*/);
      numArray[3] = (byte) ((4278190080L /*0xFF000000*/ & (long) dataToEncrypt.Length) >> 24);
      Array.Copy((Array) dataToEncrypt, 0, (Array) numArray, 4, dataToEncrypt.Length);
      byte[] array = new byte[length2];
      RsaUtils.Encrypt(new ArraySegment<byte>(numArray), rsaPublicKey, padding, new ArraySegment<byte>(array));
      return array;
    }
  }

  private static ArraySegment<byte> Encrypt(
    ArraySegment<byte> dataToEncrypt,
    RSA rsa,
    RsaUtils.Padding padding,
    ArraySegment<byte> outputBuffer)
  {
    int plainTextBlockSize = RsaUtils.GetPlainTextBlockSize(rsa, padding);
    int cipherTextBlockSize = RsaUtils.GetCipherTextBlockSize(rsa, padding);
    if (dataToEncrypt.Count % plainTextBlockSize != 0)
      Utils.LogError("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", (object) dataToEncrypt.Count, (object) plainTextBlockSize);
    byte[] array = outputBuffer.Array;
    RSAEncryptionPadding encryptionPadding = RsaUtils.GetRSAEncryptionPadding(padding);
    using (MemoryStream memoryStream = new MemoryStream(array, outputBuffer.Offset, outputBuffer.Count))
    {
      byte[] numArray = new byte[plainTextBlockSize];
      for (int offset = dataToEncrypt.Offset; offset < dataToEncrypt.Offset + dataToEncrypt.Count; offset += plainTextBlockSize)
      {
        Array.Copy((Array) dataToEncrypt.Array, offset, (Array) numArray, 0, numArray.Length);
        byte[] buffer = rsa.Encrypt(numArray, encryptionPadding);
        memoryStream.Write(buffer, 0, buffer.Length);
      }
    }
    return new ArraySegment<byte>(array, outputBuffer.Offset, dataToEncrypt.Count / plainTextBlockSize * cipherTextBlockSize);
  }

  internal static byte[] Decrypt(
    ArraySegment<byte> dataToDecrypt,
    X509Certificate2 encryptingCertificate,
    RsaUtils.Padding padding)
  {
    using (RSA rsaPrivateKey = RSACertificateExtensions.GetRSAPrivateKey(encryptingCertificate))
    {
      if (rsaPrivateKey == null)
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "No private key for certificate.");
      byte[] array = new byte[dataToDecrypt.Count / RsaUtils.GetCipherTextBlockSize(rsaPrivateKey, padding) * RsaUtils.GetPlainTextBlockSize(encryptingCertificate, padding)];
      ArraySegment<byte> arraySegment = RsaUtils.Decrypt(dataToDecrypt, rsaPrivateKey, padding, new ArraySegment<byte>(array));
      int length = 0 + (int) arraySegment.Array[arraySegment.Offset] + ((int) arraySegment.Array[arraySegment.Offset + 1] << 8) + ((int) arraySegment.Array[arraySegment.Offset + 2] << 16 /*0x10*/) + ((int) arraySegment.Array[arraySegment.Offset + 3] << 24);
      if (length > arraySegment.Count - arraySegment.Offset - 4)
        throw ServiceResultException.Create(2159017984U /*0x80B00000*/, "Could not decrypt data. Invalid total length.");
      byte[] destinationArray = new byte[length];
      Array.Copy((Array) arraySegment.Array, arraySegment.Offset + 4, (Array) destinationArray, 0, length);
      return destinationArray;
    }
  }

  private static ArraySegment<byte> Decrypt(
    ArraySegment<byte> dataToDecrypt,
    RSA rsa,
    RsaUtils.Padding padding,
    ArraySegment<byte> outputBuffer)
  {
    int cipherTextBlockSize = RsaUtils.GetCipherTextBlockSize(rsa, padding);
    int plainTextBlockSize = RsaUtils.GetPlainTextBlockSize(rsa, padding);
    if (dataToDecrypt.Count % cipherTextBlockSize != 0)
      Utils.LogError("Message is not an integral multiple of the block size. Length = {0}, BlockSize = {1}.", (object) dataToDecrypt.Count, (object) cipherTextBlockSize);
    byte[] array = outputBuffer.Array;
    RSAEncryptionPadding encryptionPadding = RsaUtils.GetRSAEncryptionPadding(padding);
    using (MemoryStream memoryStream = new MemoryStream(array, outputBuffer.Offset, outputBuffer.Count))
    {
      byte[] numArray = new byte[cipherTextBlockSize];
      for (int offset = dataToDecrypt.Offset; offset < dataToDecrypt.Offset + dataToDecrypt.Count; offset += cipherTextBlockSize)
      {
        Array.Copy((Array) dataToDecrypt.Array, offset, (Array) numArray, 0, numArray.Length);
        byte[] buffer = rsa.Decrypt(numArray, encryptionPadding);
        memoryStream.Write(buffer, 0, buffer.Length);
      }
    }
    return new ArraySegment<byte>(array, outputBuffer.Offset, dataToDecrypt.Count / cipherTextBlockSize * plainTextBlockSize);
  }

  internal static bool TryVerifyRSAPssSign(RSA publicKey, RSA privateKey)
  {
    try
    {
      RandomSource randomSource = new RandomSource();
      byte[] data = new byte[16 /*0x10*/];
      byte[] bytes = data;
      randomSource.NextBytes(bytes, 0, 16 /*0x10*/);
      byte[] signature = privateKey.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
      return publicKey.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
    }
    catch
    {
      return false;
    }
  }

  public enum Padding
  {
    Pkcs1,
    OaepSHA1,
    OaepSHA256,
  }
}
