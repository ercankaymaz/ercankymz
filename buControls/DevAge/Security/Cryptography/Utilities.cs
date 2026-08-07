// Decompiled with JetBrains decompiler
// Type: DevAge.Security.Cryptography.Utilities
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

#nullable disable
namespace DevAge.Security.Cryptography;

public class Utilities
{
  public class DES
  {
    public static string EncryptString(string p_strInput, string p_Key8chars)
    {
      string base64String;
      using (MemoryStream p_StreamInput = new MemoryStream())
      {
        StreamWriter streamWriter = new StreamWriter((Stream) p_StreamInput);
        streamWriter.Write(p_strInput);
        streamWriter.Flush();
        p_StreamInput.Seek(0L, SeekOrigin.Begin);
        using (MemoryStream p_StreamOutput = new MemoryStream())
        {
          Utilities.DES.EncryptStream((Stream) p_StreamInput, (Stream) p_StreamOutput, p_Key8chars);
          p_StreamOutput.Flush();
          p_StreamOutput.Seek(0L, SeekOrigin.Begin);
          base64String = Convert.ToBase64String(p_StreamOutput.ToArray());
          p_StreamOutput.Close();
        }
        streamWriter.Close();
      }
      return base64String;
    }

    public static string DecryptString(string p_strInput, string p_Key8chars)
    {
      string end;
      using (MemoryStream p_StreamInput = new MemoryStream())
      {
        byte[] buffer = Convert.FromBase64String(p_strInput);
        p_StreamInput.Write(buffer, 0, buffer.Length);
        p_StreamInput.Flush();
        p_StreamInput.Seek(0L, SeekOrigin.Begin);
        using (MemoryStream p_StreamOutput = new MemoryStream())
        {
          Utilities.DES.DecryptStream((Stream) p_StreamInput, (Stream) p_StreamOutput, p_Key8chars);
          StreamReader streamReader = new StreamReader((Stream) p_StreamOutput);
          end = streamReader.ReadToEnd();
          streamReader.Close();
        }
        p_StreamInput.Close();
      }
      return end;
    }

    public static void EncryptStream(
      Stream p_StreamInput,
      Stream p_StreamOutput,
      string p_Key8chars)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(p_Key8chars);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(p_Key8chars);
      ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor();
      using (CryptoStream cryptoStream = new CryptoStream(p_StreamOutput, encryptor, CryptoStreamMode.Write))
      {
        byte[] buffer = new byte[p_StreamInput.Length];
        p_StreamInput.Read(buffer, 0, buffer.Length);
        cryptoStream.Write(buffer, 0, buffer.Length);
        cryptoStream.FlushFinalBlock();
      }
    }

    public static void DecryptStream(
      Stream p_StreamInput,
      Stream p_StreamOutput,
      string p_Key8chars)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(p_Key8chars);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(p_Key8chars);
      ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor();
      using (CryptoStream cryptoStream = new CryptoStream(p_StreamOutput, decryptor, CryptoStreamMode.Write))
      {
        byte[] buffer = new byte[p_StreamInput.Length];
        p_StreamInput.Read(buffer, 0, buffer.Length);
        cryptoStream.Write(buffer, 0, buffer.Length);
        cryptoStream.FlushFinalBlock();
      }
      p_StreamOutput.Seek(0L, SeekOrigin.Begin);
    }
  }

  public class SHA1
  {
    public static string HashPassword(string p_Password)
    {
      return Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(p_Password)));
    }
  }

  public class XmlDigitalSign
  {
    public static void GenerateKeys(out string keyPubPri, out string keyPub)
    {
      RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider(1024 /*0x0400*/);
      keyPubPri = cryptoServiceProvider.ToXmlString(true);
      keyPub = cryptoServiceProvider.ToXmlString(false);
      cryptoServiceProvider.Clear();
    }

    public static XmlElement CreateSignature(XmlDocument xmlToSign, string keyPubPri)
    {
      RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
      cryptoServiceProvider.FromXmlString(keyPubPri);
      SignedXml signedXml = new SignedXml(xmlToSign);
      signedXml.SigningKey = (AsymmetricAlgorithm) cryptoServiceProvider;
      Reference reference = new Reference("");
      signedXml.SignedInfo.CanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
      XmlDsigEnvelopedSignatureTransform signatureTransform = new XmlDsigEnvelopedSignatureTransform(false);
      reference.AddTransform((Transform) signatureTransform);
      signedXml.AddReference(reference);
      signedXml.ComputeSignature();
      return signedXml.GetXml();
    }

    public static XmlDocument CreateSignedDoc(XmlDocument xmlToSign, string keyPubPri)
    {
      XmlElement signature = Utilities.XmlDigitalSign.CreateSignature(xmlToSign, keyPubPri);
      XmlDocument signedDoc = new XmlDocument();
      signedDoc.AppendChild(signedDoc.ImportNode((XmlNode) xmlToSign.DocumentElement, true));
      signedDoc.DocumentElement.PrependChild(signedDoc.ImportNode((XmlNode) signature, true));
      return signedDoc;
    }

    public static bool CheckSignature(XmlDocument signedDoc, string keyPub)
    {
      RSACryptoServiceProvider key = new RSACryptoServiceProvider();
      key.FromXmlString(keyPub);
      SignedXml signedXml = new SignedXml(signedDoc);
      signedXml.LoadXml(Utilities.XmlDigitalSign.GetSignatureFromSignedDoc(signedDoc));
      return signedXml.CheckSignature((AsymmetricAlgorithm) key);
    }

    public static XmlElement GetSignatureFromSignedDoc(XmlDocument signedDoc)
    {
      XmlNodeList elementsByTagName = signedDoc.GetElementsByTagName("Signature");
      if (elementsByTagName.Count <= 0)
        throw new CryptographicException("Verification failed: No Signature was found in the document.");
      return elementsByTagName.Count < 2 ? (XmlElement) elementsByTagName[0] : throw new CryptographicException("Verification failed: More that one signature was found for the document.");
    }

    public static XmlDocument CreateDocWithoutSignature(XmlDocument signedDoc)
    {
      XmlDocument signedDoc1 = new XmlDocument();
      signedDoc1.AppendChild(signedDoc1.ImportNode((XmlNode) signedDoc.DocumentElement, true));
      XmlElement signatureFromSignedDoc = Utilities.XmlDigitalSign.GetSignatureFromSignedDoc(signedDoc1);
      signatureFromSignedDoc.ParentNode.RemoveChild((XmlNode) signatureFromSignedDoc);
      return signedDoc1;
    }
  }
}
