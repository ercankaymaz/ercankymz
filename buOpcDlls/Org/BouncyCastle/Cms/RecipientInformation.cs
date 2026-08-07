// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.RecipientInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public abstract class RecipientInformation
{
  internal RecipientID rid = new RecipientID();
  internal AlgorithmIdentifier keyEncAlg;
  internal CmsSecureReadable secureReadable;
  private byte[] resultMac;

  internal RecipientInformation(AlgorithmIdentifier keyEncAlg, CmsSecureReadable secureReadable)
  {
    this.keyEncAlg = keyEncAlg;
    this.secureReadable = secureReadable;
  }

  internal string GetContentAlgorithmName() => this.secureReadable.Algorithm.Algorithm.Id;

  public RecipientID RecipientID => this.rid;

  public AlgorithmIdentifier KeyEncryptionAlgorithmID => this.keyEncAlg;

  public string KeyEncryptionAlgOid => this.keyEncAlg.Algorithm.Id;

  public Asn1Object KeyEncryptionAlgParams => this.keyEncAlg.Parameters?.ToAsn1Object();

  internal CmsTypedStream GetContentFromSessionKey(KeyParameter sKey)
  {
    CmsReadable readable = this.secureReadable.GetReadable(sKey);
    try
    {
      return new CmsTypedStream(readable.GetInputStream());
    }
    catch (IOException ex)
    {
      throw new CmsException("error getting .", (Exception) ex);
    }
  }

  public byte[] GetContent(ICipherParameters key)
  {
    try
    {
      return CmsUtilities.StreamToByteArray(this.GetContentStream(key).ContentStream);
    }
    catch (IOException ex)
    {
      throw new Exception("unable to parse internal stream: " + ex?.ToString());
    }
  }

  public byte[] GetMac()
  {
    if (this.resultMac == null && this.secureReadable.CryptoObject is IMac cryptoObject)
      this.resultMac = MacUtilities.DoFinal(cryptoObject);
    return Arrays.Clone(this.resultMac);
  }

  public abstract CmsTypedStream GetContentStream(ICipherParameters key);
}
