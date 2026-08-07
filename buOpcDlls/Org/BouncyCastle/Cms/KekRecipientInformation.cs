// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.KekRecipientInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class KekRecipientInformation : RecipientInformation
{
  private KekRecipientInfo info;

  internal KekRecipientInformation(KekRecipientInfo info, CmsSecureReadable secureReadable)
    : base(info.KeyEncryptionAlgorithm, secureReadable)
  {
    this.info = info;
    this.rid = new RecipientID();
    this.rid.KeyIdentifier = info.KekID.KeyIdentifier.GetOctets();
  }

  public override CmsTypedStream GetContentStream(ICipherParameters key)
  {
    try
    {
      byte[] octets = this.info.EncryptedKey.GetOctets();
      IWrapper wrapper = WrapperUtilities.GetWrapper(this.keyEncAlg.Algorithm.Id);
      wrapper.Init(false, key);
      return this.GetContentFromSessionKey(ParameterUtilities.CreateKeyParameter(this.GetContentAlgorithmName(), wrapper.Unwrap(octets, 0, octets.Length)));
    }
    catch (SecurityUtilityException ex)
    {
      throw new CmsException("couldn't create cipher.", (Exception) ex);
    }
    catch (InvalidKeyException ex)
    {
      throw new CmsException("key invalid in message.", (Exception) ex);
    }
  }
}
