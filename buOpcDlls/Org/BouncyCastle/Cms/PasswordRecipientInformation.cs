// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.PasswordRecipientInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class PasswordRecipientInformation : RecipientInformation
{
  private readonly PasswordRecipientInfo info;

  internal PasswordRecipientInformation(
    PasswordRecipientInfo info,
    CmsSecureReadable secureReadable)
    : base(info.KeyEncryptionAlgorithm, secureReadable)
  {
    this.info = info;
    this.rid = new RecipientID();
  }

  public virtual AlgorithmIdentifier KeyDerivationAlgorithm => this.info.KeyDerivationAlgorithm;

  public override CmsTypedStream GetContentStream(ICipherParameters key)
  {
    try
    {
      Asn1Sequence parameters1 = (Asn1Sequence) AlgorithmIdentifier.GetInstance((object) this.info.KeyEncryptionAlgorithm).Parameters;
      byte[] octets = this.info.EncryptedKey.GetOctets();
      string id = DerObjectIdentifier.GetInstance((object) parameters1[0]).Id;
      IWrapper wrapper = WrapperUtilities.GetWrapper(CmsEnvelopedHelper.Instance.GetRfc3211WrapperName(id));
      Asn1OctetString instance = Asn1OctetString.GetInstance((object) parameters1[1]);
      ICipherParameters parameters2 = (ICipherParameters) new ParametersWithIV((ICipherParameters) ((CmsPbeKey) key).GetEncoded(id), instance.GetOctets());
      wrapper.Init(false, parameters2);
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
