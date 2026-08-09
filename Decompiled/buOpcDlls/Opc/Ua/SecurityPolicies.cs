using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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
		if (name.Equals("Aes256_Sha256_RsaPss") && !RsaUtils.IsSupportingRSAPssSign.Value)
		{
			return false;
		}
		return true;
	}

	public static string GetUri(string displayName)
	{
		FieldInfo[] fields = typeof(SecurityPolicies).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.Name == displayName && IsPlatformSupportedUri(fieldInfo.Name))
			{
				return (string)fieldInfo.GetValue(typeof(SecurityPolicies));
			}
		}
		return null;
	}

	public static string GetDisplayName(string policyUri)
	{
		FieldInfo[] fields = typeof(SecurityPolicies).GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (policyUri == (string)fieldInfo.GetValue(typeof(SecurityPolicies)) && IsPlatformSupportedUri(fieldInfo.Name))
			{
				return fieldInfo.Name;
			}
		}
		return null;
	}

	public static string[] GetDisplayNames()
	{
		FieldInfo[] fields = typeof(SecurityPolicies).GetFields(BindingFlags.Static | BindingFlags.Public);
		List<string> list = new List<string>();
		for (int i = 1; i < fields.Length - 1; i++)
		{
			if (IsPlatformSupportedUri(fields[i].Name))
			{
				list.Add(fields[i].Name);
			}
		}
		return list.ToArray();
	}

	public static string[] GetDefaultUris()
	{
		string[] obj = new string[3] { "Basic256Sha256", "Aes128_Sha256_RsaOaep", "Aes256_Sha256_RsaPss" };
		List<string> list = new List<string>();
		string[] array = obj;
		for (int i = 0; i < array.Length; i++)
		{
			string uri = GetUri(array[i]);
			if (uri != null)
			{
				list.Add(uri);
			}
		}
		return list.ToArray();
	}

	public static EncryptedData Encrypt(X509Certificate2 certificate, string securityPolicyUri, byte[] plainText)
	{
		EncryptedData encryptedData = new EncryptedData();
		encryptedData.Algorithm = null;
		encryptedData.Data = plainText;
		if (plainText == null)
		{
			return encryptedData;
		}
		if (string.IsNullOrEmpty(securityPolicyUri))
		{
			return encryptedData;
		}
		switch (securityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			encryptedData.Algorithm = "http://www.w3.org/2001/04/xmlenc#rsa-oaep";
			encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, RsaUtils.Padding.OaepSHA1);
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			encryptedData.Algorithm = "http://www.w3.org/2001/04/xmlenc#rsa-1_5";
			encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, RsaUtils.Padding.Pkcs1);
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			encryptedData.Algorithm = "http://opcfoundation.org/UA/security/rsa-oaep-sha2-256";
			encryptedData.Data = RsaUtils.Encrypt(plainText, certificate, RsaUtils.Padding.OaepSHA256);
			break;
		default:
			throw ServiceResultException.Create(2153054208u, "Unsupported security policy: {0}", securityPolicyUri);
		case "http://opcfoundation.org/UA/SecurityPolicy#None":
			break;
		}
		return encryptedData;
	}

	public static byte[] Decrypt(X509Certificate2 certificate, string securityPolicyUri, EncryptedData dataToDecrypt)
	{
		if (dataToDecrypt == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(securityPolicyUri))
		{
			return dataToDecrypt.Data;
		}
		switch (securityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			if (dataToDecrypt.Algorithm == "http://www.w3.org/2001/04/xmlenc#rsa-oaep")
			{
				return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, RsaUtils.Padding.OaepSHA1);
			}
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			if (dataToDecrypt.Algorithm == "http://www.w3.org/2001/04/xmlenc#rsa-1_5")
			{
				return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, RsaUtils.Padding.Pkcs1);
			}
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			if (dataToDecrypt.Algorithm == "http://opcfoundation.org/UA/security/rsa-oaep-sha2-256")
			{
				return RsaUtils.Decrypt(new ArraySegment<byte>(dataToDecrypt.Data), certificate, RsaUtils.Padding.OaepSHA256);
			}
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#None":
			if (string.IsNullOrEmpty(dataToDecrypt.Algorithm))
			{
				return dataToDecrypt.Data;
			}
			break;
		default:
			throw ServiceResultException.Create(2153054208u, "Unsupported security policy: {0}", securityPolicyUri);
		}
		throw ServiceResultException.Create(2149580800u, "Unexpected encryption algorithm : {0}", dataToDecrypt.Algorithm);
	}

	public static SignatureData Sign(X509Certificate2 certificate, string securityPolicyUri, byte[] dataToSign)
	{
		SignatureData signatureData = new SignatureData();
		if (dataToSign == null)
		{
			return signatureData;
		}
		if (string.IsNullOrEmpty(securityPolicyUri))
		{
			return signatureData;
		}
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
			signatureData.Algorithm = null;
			signatureData.Signature = null;
			break;
		default:
			throw ServiceResultException.Create(2153054208u, "Unsupported security policy: {0}", securityPolicyUri);
		}
		return signatureData;
	}

	public static bool Verify(X509Certificate2 certificate, string securityPolicyUri, byte[] dataToVerify, SignatureData signature)
	{
		if (signature == null)
		{
			return true;
		}
		if (string.IsNullOrEmpty(securityPolicyUri))
		{
			return true;
		}
		switch (securityPolicyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			if (signature.Algorithm == "http://www.w3.org/2000/09/xmldsig#rsa-sha1")
			{
				return RsaUtils.Rsa_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
			}
			throw ServiceResultException.Create(2148728832u, "Unexpected signature algorithm for Basic256/Basic128Rsa15: {0}\nExpected signature algorithm: {1}", signature.Algorithm, "http://www.w3.org/2000/09/xmldsig#rsa-sha1");
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			if (signature.Algorithm == "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256")
			{
				return RsaUtils.Rsa_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
			}
			throw ServiceResultException.Create(2148728832u, "Unexpected signature algorithm for Basic256Sha256/Aes128_Sha256_RsaOaep: {0}\nExpected signature algorithm: {1}", signature.Algorithm, "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			if (signature.Algorithm == "http://opcfoundation.org/UA/security/rsa-pss-sha2-256")
			{
				return RsaUtils.Rsa_Verify(new ArraySegment<byte>(dataToVerify), signature.Signature, certificate, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
			}
			throw ServiceResultException.Create(2148728832u, "Unexpected signature algorithm for Aes256_Sha256_RsaPss: {0}\nExpected signature algorithm : {1}", signature.Algorithm, "http://opcfoundation.org/UA/security/rsa-pss-sha2-256");
		case "http://opcfoundation.org/UA/SecurityPolicy#None":
			return true;
		default:
			throw ServiceResultException.Create(2153054208u, "Unsupported security policy: {0}", securityPolicyUri);
		}
	}
}
