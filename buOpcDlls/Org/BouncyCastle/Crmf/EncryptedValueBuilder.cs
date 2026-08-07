// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.EncryptedValueBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class EncryptedValueBuilder
{
  private readonly IKeyWrapper wrapper;
  private readonly ICipherBuilderWithKey encryptor;
  private readonly IEncryptedValuePadder padder;

  public EncryptedValueBuilder(IKeyWrapper wrapper, ICipherBuilderWithKey encryptor)
    : this(wrapper, encryptor, (IEncryptedValuePadder) null)
  {
  }

  public EncryptedValueBuilder(
    IKeyWrapper wrapper,
    ICipherBuilderWithKey encryptor,
    IEncryptedValuePadder padder)
  {
    this.wrapper = wrapper;
    this.encryptor = encryptor;
    this.padder = padder;
  }

  public EncryptedValue Build(char[] revocationPassphrase)
  {
    return this.EncryptData(this.PadData(Strings.ToUtf8ByteArray(revocationPassphrase)));
  }

  public EncryptedValue Build(X509Certificate holder)
  {
    try
    {
      return this.EncryptData(this.PadData(holder.GetEncoded()));
    }
    catch (IOException ex)
    {
      throw new CrmfException("cannot encode certificate: " + ex.Message, (Exception) ex);
    }
  }

  public EncryptedValue Build(PrivateKeyInfo privateKeyInfo)
  {
    Pkcs8EncryptedPrivateKeyInfoBuilder privateKeyInfoBuilder = new Pkcs8EncryptedPrivateKeyInfoBuilder(privateKeyInfo);
    AlgorithmIdentifier privateKeyAlgorithm = privateKeyInfo.PrivateKeyAlgorithm;
    AlgorithmIdentifier algorithmDetails1 = (AlgorithmIdentifier) this.encryptor.AlgorithmDetails;
    try
    {
      Pkcs8EncryptedPrivateKeyInfo encryptedPrivateKeyInfo = privateKeyInfoBuilder.Build((ICipherBuilder) this.encryptor);
      DerBitString encSymmKey = new DerBitString(this.wrapper.Wrap(((KeyParameter) this.encryptor.Key).GetKey()).Collect());
      AlgorithmIdentifier algorithmDetails2 = (AlgorithmIdentifier) this.wrapper.AlgorithmDetails;
      Asn1OctetString valueHint = (Asn1OctetString) null;
      return new EncryptedValue(privateKeyAlgorithm, algorithmDetails1, encSymmKey, algorithmDetails2, valueHint, new DerBitString(encryptedPrivateKeyInfo.GetEncryptedData()));
    }
    catch (Exception ex)
    {
      throw new CrmfException("cannot wrap key: " + ex.Message, ex);
    }
  }

  private EncryptedValue EncryptData(byte[] data)
  {
    MemoryStream memoryStream = new MemoryStream();
    ICipher cipher = this.encryptor.BuildCipher((Stream) memoryStream);
    try
    {
      using (Stream stream = cipher.Stream)
        stream.Write(data, 0, data.Length);
    }
    catch (IOException ex)
    {
      throw new CrmfException("cannot process data: " + ex.Message, (Exception) ex);
    }
    AlgorithmIdentifier intendedAlg = (AlgorithmIdentifier) null;
    AlgorithmIdentifier algorithmDetails1 = (AlgorithmIdentifier) this.encryptor.AlgorithmDetails;
    DerBitString encSymmKey;
    try
    {
      encSymmKey = new DerBitString(this.wrapper.Wrap(((KeyParameter) this.encryptor.Key).GetKey()).Collect());
    }
    catch (Exception ex)
    {
      throw new CrmfException("cannot wrap key: " + ex.Message, ex);
    }
    AlgorithmIdentifier algorithmDetails2 = (AlgorithmIdentifier) this.wrapper.AlgorithmDetails;
    Asn1OctetString valueHint = (Asn1OctetString) null;
    DerBitString encValue = new DerBitString(memoryStream.ToArray());
    return new EncryptedValue(intendedAlg, algorithmDetails1, encSymmKey, algorithmDetails2, valueHint, encValue);
  }

  private byte[] PadData(byte[] data)
  {
    return this.padder != null ? this.padder.GetPaddedData(data) : data;
  }
}
