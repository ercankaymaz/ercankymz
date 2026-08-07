// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs8EncryptedPrivateKeyInfoBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs8EncryptedPrivateKeyInfoBuilder
{
  private PrivateKeyInfo privateKeyInfo;

  public Pkcs8EncryptedPrivateKeyInfoBuilder(byte[] privateKeyInfo)
    : this(PrivateKeyInfo.GetInstance((object) privateKeyInfo))
  {
  }

  public Pkcs8EncryptedPrivateKeyInfoBuilder(PrivateKeyInfo privateKeyInfo)
  {
    this.privateKeyInfo = privateKeyInfo;
  }

  public Pkcs8EncryptedPrivateKeyInfo Build(ICipherBuilder encryptor)
  {
    try
    {
      MemoryStream memoryStream = new MemoryStream();
      using (Stream stream = encryptor.BuildCipher((Stream) memoryStream).Stream)
        this.privateKeyInfo.EncodeTo(stream);
      return new Pkcs8EncryptedPrivateKeyInfo(new EncryptedPrivateKeyInfo((AlgorithmIdentifier) encryptor.AlgorithmDetails, memoryStream.ToArray()));
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException("cannot encode privateKeyInfo");
    }
  }
}
