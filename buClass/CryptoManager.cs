// Decompiled with JetBrains decompiler
// Type: buClass.CryptoManager
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace buClass;

public static class CryptoManager
{
  private static readonly byte[] Key = Encoding.UTF8.GetBytes("CmdLangSecureKey_2026!@#$$%^&*()");
  private static readonly byte[] IV = Encoding.UTF8.GetBytes("CmdLang_IV_16byt");

  public static string Encrypt(string plainText)
  {
    if (string.IsNullOrEmpty(plainText))
      return plainText;
    using (Aes aes = Aes.Create())
    {
      aes.Key = CryptoManager.Key;
      aes.IV = CryptoManager.IV;
      aes.Mode = CipherMode.CBC;
      aes.Padding = PaddingMode.PKCS7;
      ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
        {
          using (StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream))
            streamWriter.Write(plainText);
          return Convert.ToBase64String(memoryStream.ToArray());
        }
      }
    }
  }

  public static string Decrypt(string cipherText)
  {
    if (string.IsNullOrEmpty(cipherText))
      return cipherText;
    try
    {
      using (Aes aes = Aes.Create())
      {
        aes.Key = CryptoManager.Key;
        aes.IV = CryptoManager.IV;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
              return streamReader.ReadToEnd();
          }
        }
      }
    }
    catch
    {
      return (string) null;
    }
  }
}
