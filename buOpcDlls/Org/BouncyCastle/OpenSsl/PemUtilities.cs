// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.OpenSsl.PemUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.OpenSsl;

internal sealed class PemUtilities
{
  static PemUtilities()
  {
    Enums.GetArbitraryValue<PemUtilities.PemBaseAlg>().ToString();
    Enums.GetArbitraryValue<PemUtilities.PemMode>().ToString();
  }

  private static void ParseDekAlgName(
    string dekAlgName,
    out PemUtilities.PemBaseAlg baseAlg,
    out PemUtilities.PemMode mode)
  {
    try
    {
      mode = PemUtilities.PemMode.ECB;
      if (!(dekAlgName == "DES-EDE") && !(dekAlgName == "DES-EDE3"))
      {
        int length = dekAlgName.LastIndexOf('-');
        if (length >= 0)
        {
          baseAlg = Enums.GetEnumValue<PemUtilities.PemBaseAlg>(dekAlgName.Substring(0, length));
          mode = Enums.GetEnumValue<PemUtilities.PemMode>(dekAlgName.Substring(length + 1));
          return;
        }
      }
      else
      {
        baseAlg = Enums.GetEnumValue<PemUtilities.PemBaseAlg>(dekAlgName);
        return;
      }
    }
    catch (ArgumentException ex)
    {
    }
    throw new EncryptionException("Unknown DEK algorithm: " + dekAlgName);
  }

  internal static byte[] Crypt(
    bool encrypt,
    byte[] bytes,
    char[] password,
    string dekAlgName,
    byte[] iv)
  {
    PemUtilities.PemBaseAlg baseAlg;
    PemUtilities.PemMode mode;
    PemUtilities.ParseDekAlgName(dekAlgName, out baseAlg, out mode);
    string str1;
    switch (mode)
    {
      case PemUtilities.PemMode.CBC:
      case PemUtilities.PemMode.ECB:
        str1 = "PKCS5Padding";
        break;
      case PemUtilities.PemMode.CFB:
      case PemUtilities.PemMode.OFB:
        str1 = "NoPadding";
        break;
      default:
        throw new EncryptionException("Unknown DEK algorithm: " + dekAlgName);
    }
    byte[] numArray = iv;
    string str2;
    switch (baseAlg)
    {
      case PemUtilities.PemBaseAlg.AES_128:
      case PemUtilities.PemBaseAlg.AES_192:
      case PemUtilities.PemBaseAlg.AES_256:
        str2 = "AES";
        if (numArray.Length > 8)
        {
          numArray = new byte[8];
          Array.Copy((Array) iv, 0, (Array) numArray, 0, numArray.Length);
          break;
        }
        break;
      case PemUtilities.PemBaseAlg.BF:
        str2 = "BLOWFISH";
        break;
      case PemUtilities.PemBaseAlg.DES:
        str2 = "DES";
        break;
      case PemUtilities.PemBaseAlg.DES_EDE:
      case PemUtilities.PemBaseAlg.DES_EDE3:
        str2 = "DESede";
        break;
      case PemUtilities.PemBaseAlg.RC2:
      case PemUtilities.PemBaseAlg.RC2_40:
      case PemUtilities.PemBaseAlg.RC2_64:
        str2 = "RC2";
        break;
      default:
        throw new EncryptionException("Unknown DEK algorithm: " + dekAlgName);
    }
    IBufferedCipher cipher = CipherUtilities.GetCipher($"{str2}/{mode.ToString()}/{str1}");
    ICipherParameters parameters = PemUtilities.GetCipherParameters(password, baseAlg, numArray);
    if (mode != PemUtilities.PemMode.ECB)
      parameters = (ICipherParameters) new ParametersWithIV(parameters, iv);
    cipher.Init(encrypt, parameters);
    return cipher.DoFinal(bytes);
  }

  private static ICipherParameters GetCipherParameters(
    char[] password,
    PemUtilities.PemBaseAlg baseAlg,
    byte[] salt)
  {
    int keySize;
    string algorithm;
    switch (baseAlg)
    {
      case PemUtilities.PemBaseAlg.AES_128:
        keySize = 128 /*0x80*/;
        algorithm = "AES128";
        break;
      case PemUtilities.PemBaseAlg.AES_192:
        keySize = 192 /*0xC0*/;
        algorithm = "AES192";
        break;
      case PemUtilities.PemBaseAlg.AES_256:
        keySize = 256 /*0x0100*/;
        algorithm = "AES256";
        break;
      case PemUtilities.PemBaseAlg.BF:
        keySize = 128 /*0x80*/;
        algorithm = "BLOWFISH";
        break;
      case PemUtilities.PemBaseAlg.DES:
        keySize = 64 /*0x40*/;
        algorithm = "DES";
        break;
      case PemUtilities.PemBaseAlg.DES_EDE:
        keySize = 128 /*0x80*/;
        algorithm = "DESEDE";
        break;
      case PemUtilities.PemBaseAlg.DES_EDE3:
        keySize = 192 /*0xC0*/;
        algorithm = "DESEDE3";
        break;
      case PemUtilities.PemBaseAlg.RC2:
        keySize = 128 /*0x80*/;
        algorithm = "RC2";
        break;
      case PemUtilities.PemBaseAlg.RC2_40:
        keySize = 40;
        algorithm = "RC2";
        break;
      case PemUtilities.PemBaseAlg.RC2_64:
        keySize = 64 /*0x40*/;
        algorithm = "RC2";
        break;
      default:
        return (ICipherParameters) null;
    }
    OpenSslPbeParametersGenerator parametersGenerator = new OpenSslPbeParametersGenerator();
    parametersGenerator.Init(PbeParametersGenerator.Pkcs5PasswordToBytes(password), salt);
    return parametersGenerator.GenerateDerivedParameters(algorithm, keySize);
  }

  private enum PemBaseAlg
  {
    AES_128,
    AES_192,
    AES_256,
    BF,
    DES,
    DES_EDE,
    DES_EDE3,
    RC2,
    RC2_40,
    RC2_64,
  }

  private enum PemMode
  {
    CBC,
    CFB,
    ECB,
    OFB,
  }
}
