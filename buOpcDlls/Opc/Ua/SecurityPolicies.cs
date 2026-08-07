// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SecurityPolicies
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class SecurityPolicies
{
  public const string BaseUri = "http://opcfoundation.org/UA/SecurityPolicy#";
  public const string None = "http://opcfoundation.org/UA/SecurityPolicy#None";
  public const string Basic128Rsa15 = "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15";
  public const string Basic256 = "http://opcfoundation.org/UA/SecurityPolicy#Basic256";
  public const string Aes128_Sha256_RsaOaep = "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep";
  public const string Basic256Sha256 = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
  public const string Aes256_Sha256_RsaPss = "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss";
  public const string Https = "http://opcfoundation.org/UA/SecurityPolicy#Https";

  private static bool IsPlatformSupportedUri(string name)
  {
    return !name.Equals("Aes256_Sha256_RsaPss") || RsaUtils.IsSupportingRSAPssSign.Value;
  }

  public static string GetUri(string displayName)
  {
    foreach (FieldInfo field in typeof (SecurityPolicies).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (field.Name == displayName && SecurityPolicies.IsPlatformSupportedUri(field.Name))
        return (string) field.GetValue((object) typeof (SecurityPolicies));
    }
    return (string) null;
  }

  public static string GetDisplayName(string policyUri)
  {
    foreach (FieldInfo field in typeof (SecurityPolicies).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (policyUri == (string) field.GetValue((object) typeof (SecurityPolicies)) && SecurityPolicies.IsPlatformSupportedUri(field.Name))
        return field.Name;
    }
    return (string) null;
  }

  public static string[] GetDisplayNames()
  {
    FieldInfo[] fields = typeof (SecurityPolicies).GetFields(BindingFlags.Static | BindingFlags.Public);
    List<string> stringList = new List<string>();
    for (int index = 1; index < fields.Length - 1; ++index)
    {
      if (SecurityPolicies.IsPlatformSupportedUri(fields[index].Name))
        stringList.Add(fields[index].Name);
    }
    return stringList.ToArray();
  }

  public static string[] GetDefaultUris()
  {
    string[] strArray = new string[3]
    {
      "Basic256Sha256",
      "Aes128_Sha256_RsaOaep",
      "Aes256_Sha256_RsaPss"
    };
    List<string> stringList = new List<string>();
    foreach (string displayName in strArray)
    {
      string uri = SecurityPolicies.GetUri(displayName);
      if (uri != null)
        stringList.Add(uri);
    }
    return stringList.ToArray();
  }

  public static EncryptedData Encrypt(
    X509Certificate2 certificate,
    string securityPolicyUri,
    byte[] plainText)
  {
    EncryptedData encryptedData = new EncryptedData();
    encryptedData.Algorithm = (string) null;
    encryptedData.Data = plainText;
    if (plainText == null || string.IsNullOrEmpty(securityPolicyUri))
      return encryptedData;
    switch (securityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
        encryptedData.Algorithm = "http://www.w3.org/2001/04/xmlenc#rsa-oaep";
        encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, RsaUtils.Padding.OaepSHA1);
        goto case "http://opcfoundation.org/UA/SecurityPolicy#None";
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        encryptedData.Algorithm = "http://www.w3.org/2001/04/xmlenc#rsa-1_5";
        encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, RsaUtils.Padding.Pkcs1);
        goto case "http://opcfoundation.org/UA/SecurityPolicy#None";
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        encryptedData.Algorithm = "http://opcfoundation.org/UA/security/rsa-oaep-sha2-256";
        encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, RsaUtils.Padding.OaepSHA256);
        goto case "http://opcfoundation.org/UA/SecurityPolicy#None";
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        return encryptedData;
      default:
        throw ServiceResultException.Create(2153054208U /*0x80550000*/, "Unsupported security policy: {0}", (object) securityPolicyUri);
    }
  }

  public static byte[] Decrypt(
    X509Certificate2 certificate,
    string securityPolicyUri,
    EncryptedData dataToDecrypt)
  {
    if (dataToDecrypt == null)
      return (byte[]) null;
    if (string.IsNullOrEmpty(securityPolicyUri))
      return dataToDecrypt.Data;
    switch (securityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
        if (dataToDecrypt.Algorithm == "http://www.w3.org/2001/04/xmlenc#rsa-oaep")
          return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, RsaUtils.Padding.OaepSHA1);
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        if (dataToDecrypt.Algorithm == "http://www.w3.org/2001/04/xmlenc#rsa-1_5")
          return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, RsaUtils.Padding.Pkcs1);
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        if (dataToDecrypt.Algorithm == "http://opcfoundation.org/UA/security/rsa-oaep-sha2-256")
          return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, RsaUtils.Padding.OaepSHA256);
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        if (string.IsNullOrEmpty(dataToDecrypt.Algorithm))
          return dataToDecrypt.Data;
        break;
      default:
        throw ServiceResultException.Create(2153054208U /*0x80550000*/, "Unsupported security policy: {0}", (object) securityPolicyUri);
    }
    throw ServiceResultException.Create(2149580800U /*0x80200000*/, "Unexpected encryption algorithm : {0}", (object) dataToDecrypt.Algorithm);
  }

  public static SignatureData Sign(
    X509Certificate2 certificate,
    string securityPolicyUri,
    byte[] dataToSign)
  {
    SignatureData signatureData = new SignatureData();
    if (dataToSign == null || string.IsNullOrEmpty(securityPolicyUri))
      return signatureData;
    switch (securityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        signatureData.Algorithm = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
        signatureData.Signature = RsaUtils.Rsa_Sign(new ArraySegment<byte>(dataToSign), certificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        signatureData.Algorithm = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
        signatureData.Signature = RsaUtils.Rsa_Sign(new ArraySegment<byte>(dataToSign), certificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        signatureData.Algorithm = "http://opcfoundation.org/UA/security/rsa-pss-sha2-256";
        signatureData.Signature = RsaUtils.Rsa_Sign(new ArraySegment<byte>(dataToSign), certificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        signatureData.Algorithm = (string) null;
        signatureData.Signature = (byte[]) null;
        break;
      default:
        throw ServiceResultException.Create(2153054208U /*0x80550000*/, "Unsupported security policy: {0}", (object) securityPolicyUri);
    }
    return signatureData;
  }

  public static bool Verify(
    X509Certificate2 certificate,
    string securityPolicyUri,
    byte[] dataToVerify,
    SignatureData signature)
  {
    if (signature == null || string.IsNullOrEmpty(securityPolicyUri))
      return true;
    switch (securityPolicyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        if (!(signature.Algorithm == "http://www.w3.org/2000/09/xmldsig#rsa-sha1"))
          throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Unexpected signature algorithm for Basic256/Basic128Rsa15: {0}\nExpected signature algorithm: {1}", (object) signature.Algorithm, (object) "http://www.w3.org/2000/09/xmldsig#rsa-sha1");
        return RsaUtils.Rsa_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        if (signature.Algorithm == "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256")
          return RsaUtils.Rsa_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Unexpected signature algorithm for Basic256Sha256/Aes128_Sha256_RsaOaep: {0}\nExpected signature algorithm: {1}", (object) signature.Algorithm, (object) "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        if (signature.Algorithm == "http://opcfoundation.org/UA/security/rsa-pss-sha2-256")
          return RsaUtils.Rsa_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        throw ServiceResultException.Create(2148728832U /*0x80130000*/, "Unexpected signature algorithm for Aes256_Sha256_RsaPss: {0}\nExpected signature algorithm : {1}", (object) signature.Algorithm, (object) "http://opcfoundation.org/UA/security/rsa-pss-sha2-256");
      case "http://opcfoundation.org/UA/SecurityPolicy#None":
        return true;
      default:
        throw ServiceResultException.Create(2153054208U /*0x80550000*/, "Unsupported security policy: {0}", (object) securityPolicyUri);
    }
  }
}
