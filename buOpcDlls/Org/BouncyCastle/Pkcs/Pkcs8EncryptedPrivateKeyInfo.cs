// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs8EncryptedPrivateKeyInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs8EncryptedPrivateKeyInfo
{
  private EncryptedPrivateKeyInfo encryptedPrivateKeyInfo;

  private static EncryptedPrivateKeyInfo parseBytes(byte[] pkcs8Encoding)
  {
    try
    {
      return EncryptedPrivateKeyInfo.GetInstance((object) pkcs8Encoding);
    }
    catch (ArgumentException ex)
    {
      throw new PkcsIOException("malformed data: " + ex.Message, (Exception) ex);
    }
    catch (Exception ex)
    {
      throw new PkcsIOException("malformed data: " + ex.Message, ex);
    }
  }

  public Pkcs8EncryptedPrivateKeyInfo(EncryptedPrivateKeyInfo encryptedPrivateKeyInfo)
  {
    this.encryptedPrivateKeyInfo = encryptedPrivateKeyInfo;
  }

  public Pkcs8EncryptedPrivateKeyInfo(byte[] encryptedPrivateKeyInfo)
    : this(Pkcs8EncryptedPrivateKeyInfo.parseBytes(encryptedPrivateKeyInfo))
  {
  }

  public EncryptedPrivateKeyInfo ToAsn1Structure() => this.encryptedPrivateKeyInfo;

  public byte[] GetEncryptedData() => this.encryptedPrivateKeyInfo.GetEncryptedData();

  public byte[] GetEncoded() => this.encryptedPrivateKeyInfo.GetEncoded();

  public PrivateKeyInfo DecryptPrivateKeyInfo(IDecryptorBuilderProvider inputDecryptorProvider)
  {
    try
    {
      ICipher cipher = inputDecryptorProvider.CreateDecryptorBuilder((object) this.encryptedPrivateKeyInfo.EncryptionAlgorithm).BuildCipher((Stream) new MemoryStream(this.encryptedPrivateKeyInfo.GetEncryptedData(), false));
      byte[] numArray;
      using (cipher.Stream)
        numArray = Streams.ReadAll(cipher.Stream);
      return PrivateKeyInfo.GetInstance((object) numArray);
    }
    catch (Exception ex)
    {
      throw new PkcsException("unable to read encrypted data: " + ex.Message, ex);
    }
  }
}
