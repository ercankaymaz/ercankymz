// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.KeyTransRecipientInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class KeyTransRecipientInformation : RecipientInformation
{
  private KeyTransRecipientInfo info;

  internal KeyTransRecipientInformation(
    KeyTransRecipientInfo info,
    CmsSecureReadable secureReadable)
    : base(info.KeyEncryptionAlgorithm, secureReadable)
  {
    this.info = info;
    this.rid = new RecipientID();
    RecipientIdentifier recipientIdentifier = info.RecipientIdentifier;
    try
    {
      if (recipientIdentifier.IsTagged)
      {
        this.rid.SubjectKeyIdentifier = Asn1OctetString.GetInstance((object) recipientIdentifier.ID).GetOctets();
      }
      else
      {
        Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber instance = Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber.GetInstance((object) recipientIdentifier.ID);
        this.rid.Issuer = instance.Name;
        this.rid.SerialNumber = instance.SerialNumber.Value;
      }
    }
    catch (IOException ex)
    {
      throw new ArgumentException("invalid rid in KeyTransRecipientInformation");
    }
  }

  private string GetExchangeEncryptionAlgorithmName(AlgorithmIdentifier algo)
  {
    DerObjectIdentifier algorithm = algo.Algorithm;
    if (PkcsObjectIdentifiers.RsaEncryption.Equals((Asn1Object) algorithm))
      return "RSA//PKCS1Padding";
    return PkcsObjectIdentifiers.IdRsaesOaep.Equals((Asn1Object) algorithm) ? $"RSA//OAEPWITH{DigestUtilities.GetAlgorithmName(RsaesOaepParameters.GetInstance((object) algo.Parameters).HashAlgorithm.Algorithm)}ANDMGF1Padding" : algorithm.Id;
  }

  internal KeyParameter UnwrapKey(ICipherParameters key)
  {
    byte[] octets = this.info.EncryptedKey.GetOctets();
    try
    {
      if (this.keyEncAlg.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsaesOaep))
      {
        IKeyUnwrapper keyUnwrapper = (IKeyUnwrapper) new Asn1KeyUnwrapper(this.keyEncAlg.Algorithm, this.keyEncAlg.Parameters, key);
        return ParameterUtilities.CreateKeyParameter(this.GetContentAlgorithmName(), keyUnwrapper.Unwrap(octets, 0, octets.Length).Collect());
      }
      IWrapper wrapper = WrapperUtilities.GetWrapper(this.GetExchangeEncryptionAlgorithmName(this.keyEncAlg));
      wrapper.Init(false, key);
      return ParameterUtilities.CreateKeyParameter(this.GetContentAlgorithmName(), wrapper.Unwrap(octets, 0, octets.Length));
    }
    catch (SecurityUtilityException ex)
    {
      throw new CmsException("couldn't create cipher.", (Exception) ex);
    }
    catch (InvalidKeyException ex)
    {
      throw new CmsException("key invalid in message.", (Exception) ex);
    }
    catch (DataLengthException ex)
    {
      throw new CmsException("illegal blocksize in message.", (Exception) ex);
    }
    catch (InvalidCipherTextException ex)
    {
      throw new CmsException("bad padding in message.", (Exception) ex);
    }
  }

  public override CmsTypedStream GetContentStream(ICipherParameters key)
  {
    return this.GetContentFromSessionKey(this.UnwrapKey(key));
  }
}
