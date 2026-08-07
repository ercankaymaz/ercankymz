// Decompiled with JetBrains decompiler
// Type: CmdLanguage.API.CryptoManager
// Assembly: CmdLangAPI, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDC57675-BB9D-4653-8FAD-2A25490EEE99
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\CmdLangAPI.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace CmdLanguage.API;

internal static class CryptoManager
{
  private static readonly byte[] Key = Encoding.UTF8.GetBytes("CmdLangSecureKey_2026!@#$$%^&*()");
  private static readonly byte[] IV = Encoding.UTF8.GetBytes("CmdLang_IV_16byt");

  public static string Decrypt(string cipherText)
  {
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
