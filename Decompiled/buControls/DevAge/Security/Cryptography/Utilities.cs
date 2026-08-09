using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace DevAge.Security.Cryptography;

public class Utilities
{
	public class DES
	{
		public static string EncryptString(string p_strInput, string p_Key8chars)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StreamWriter streamWriter = new StreamWriter(memoryStream);
				streamWriter.Write(p_strInput);
				streamWriter.Flush();
				memoryStream.Seek(0L, SeekOrigin.Begin);
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					EncryptStream(memoryStream, memoryStream2, p_Key8chars);
					memoryStream2.Flush();
					memoryStream2.Seek(0L, SeekOrigin.Begin);
					result = Convert.ToBase64String(memoryStream2.ToArray());
					memoryStream2.Close();
				}
				streamWriter.Close();
			}
			return result;
		}

		public static string DecryptString(string p_strInput, string p_Key8chars)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] array = Convert.FromBase64String(p_strInput);
				memoryStream.Write(array, 0, array.Length);
				memoryStream.Flush();
				memoryStream.Seek(0L, SeekOrigin.Begin);
				using (MemoryStream memoryStream2 = new MemoryStream())
				{
					DecryptStream(memoryStream, memoryStream2, p_Key8chars);
					StreamReader streamReader = new StreamReader(memoryStream2);
					result = streamReader.ReadToEnd();
					streamReader.Close();
				}
				memoryStream.Close();
			}
			return result;
		}

		public static void EncryptStream(Stream p_StreamInput, Stream p_StreamOutput, string p_Key8chars)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(p_Key8chars);
			dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(p_Key8chars);
			ICryptoTransform transform = dESCryptoServiceProvider.CreateEncryptor();
			using CryptoStream cryptoStream = new CryptoStream(p_StreamOutput, transform, CryptoStreamMode.Write);
			byte[] array = new byte[p_StreamInput.Length];
			p_StreamInput.Read(array, 0, array.Length);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
		}

		public static void DecryptStream(Stream p_StreamInput, Stream p_StreamOutput, string p_Key8chars)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(p_Key8chars);
			dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(p_Key8chars);
			ICryptoTransform transform = dESCryptoServiceProvider.CreateDecryptor();
			using (CryptoStream cryptoStream = new CryptoStream(p_StreamOutput, transform, CryptoStreamMode.Write))
			{
				byte[] array = new byte[p_StreamInput.Length];
				p_StreamInput.Read(array, 0, array.Length);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
			}
			p_StreamOutput.Seek(0L, SeekOrigin.Begin);
		}
	}

	public class SHA1
	{
		public static string HashPassword(string p_Password)
		{
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] bytes = Encoding.UTF8.GetBytes(p_Password);
			byte[] inArray = sHA1CryptoServiceProvider.ComputeHash(bytes);
			return Convert.ToBase64String(inArray);
		}
	}

	public class XmlDigitalSign
	{
		public static void GenerateKeys(out string keyPubPri, out string keyPub)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024);
			keyPubPri = rSACryptoServiceProvider.ToXmlString(includePrivateParameters: true);
			keyPub = rSACryptoServiceProvider.ToXmlString(includePrivateParameters: false);
			rSACryptoServiceProvider.Clear();
		}

		public static XmlElement CreateSignature(XmlDocument xmlToSign, string keyPubPri)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.FromXmlString(keyPubPri);
			SignedXml signedXml = new SignedXml(xmlToSign);
			signedXml.SigningKey = rSACryptoServiceProvider;
			Reference reference = new Reference("");
			signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
			XmlDsigEnvelopedSignatureTransform transform = new XmlDsigEnvelopedSignatureTransform(includeComments: false);
			reference.AddTransform(transform);
			signedXml.AddReference(reference);
			signedXml.ComputeSignature();
			return signedXml.GetXml();
		}

		public static XmlDocument CreateSignedDoc(XmlDocument xmlToSign, string keyPubPri)
		{
			XmlElement node = CreateSignature(xmlToSign, keyPubPri);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.AppendChild(xmlDocument.ImportNode(xmlToSign.DocumentElement, deep: true));
			xmlDocument.DocumentElement.PrependChild(xmlDocument.ImportNode(node, deep: true));
			return xmlDocument;
		}

		public static bool CheckSignature(XmlDocument signedDoc, string keyPub)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.FromXmlString(keyPub);
			SignedXml signedXml = new SignedXml(signedDoc);
			signedXml.LoadXml(GetSignatureFromSignedDoc(signedDoc));
			return signedXml.CheckSignature(rSACryptoServiceProvider);
		}

		public static XmlElement GetSignatureFromSignedDoc(XmlDocument signedDoc)
		{
			XmlNodeList elementsByTagName = signedDoc.GetElementsByTagName("Signature");
			if (elementsByTagName.Count > 0)
			{
				if (elementsByTagName.Count >= 2)
				{
					throw new CryptographicException("Verification failed: More that one signature was found for the document.");
				}
				return (XmlElement)elementsByTagName[0];
			}
			throw new CryptographicException("Verification failed: No Signature was found in the document.");
		}

		public static XmlDocument CreateDocWithoutSignature(XmlDocument signedDoc)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.AppendChild(xmlDocument.ImportNode(signedDoc.DocumentElement, deep: true));
			XmlElement signatureFromSignedDoc = GetSignatureFromSignedDoc(xmlDocument);
			signatureFromSignedDoc.ParentNode.RemoveChild(signatureFromSignedDoc);
			return xmlDocument;
		}
	}
}
