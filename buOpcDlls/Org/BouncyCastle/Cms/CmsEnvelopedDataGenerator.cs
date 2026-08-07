// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsEnvelopedDataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsEnvelopedDataGenerator : CmsEnvelopedGenerator
{
  public CmsEnvelopedDataGenerator()
  {
  }

  public CmsEnvelopedDataGenerator(SecureRandom random)
    : base(random)
  {
  }

  private CmsEnvelopedData Generate(
    CmsProcessable content,
    string encryptionOid,
    CipherKeyGenerator keyGen)
  {
    KeyParameter keyParameter;
    AlgorithmIdentifier algorithmIdentifier;
    Asn1OctetString encryptedContent;
    try
    {
      byte[] key = keyGen.GenerateKey();
      keyParameter = ParameterUtilities.CreateKeyParameter(encryptionOid, key);
      Asn1Encodable asn1Parameters = this.GenerateAsn1Parameters(encryptionOid, key);
      ICipherParameters cipherParameters;
      algorithmIdentifier = this.GetAlgorithmIdentifier(encryptionOid, keyParameter, asn1Parameters, out cipherParameters);
      IBufferedCipher cipher = CipherUtilities.GetCipher(encryptionOid);
      cipher.Init(true, (ICipherParameters) new ParametersWithRandom(cipherParameters, this.m_random));
      MemoryStream memoryStream = new MemoryStream();
      using (CipherStream outStream = new CipherStream((Stream) memoryStream, (IBufferedCipher) null, cipher))
        content.Write((Stream) outStream);
      encryptedContent = (Asn1OctetString) new BerOctetString(memoryStream.ToArray());
    }
    catch (SecurityUtilityException ex)
    {
      throw new CmsException("couldn't create cipher.", (Exception) ex);
    }
    catch (InvalidKeyException ex)
    {
      throw new CmsException("key invalid in message.", (Exception) ex);
    }
    catch (IOException ex)
    {
      throw new CmsException("exception decoding algorithm parameters.", (Exception) ex);
    }
    Asn1EncodableVector elementVector = new Asn1EncodableVector(this.recipientInfoGenerators.Count);
    foreach (RecipientInfoGenerator recipientInfoGenerator in (IEnumerable<RecipientInfoGenerator>) this.recipientInfoGenerators)
    {
      try
      {
        elementVector.Add((Asn1Encodable) recipientInfoGenerator.Generate(keyParameter, this.m_random));
      }
      catch (InvalidKeyException ex)
      {
        throw new CmsException("key inappropriate for algorithm.", (Exception) ex);
      }
      catch (GeneralSecurityException ex)
      {
        throw new CmsException("error making encrypted content.", (Exception) ex);
      }
    }
    EncryptedContentInfo encryptedContentInfo = new EncryptedContentInfo(CmsObjectIdentifiers.Data, algorithmIdentifier, encryptedContent);
    Asn1Set unprotectedAttrs = (Asn1Set) null;
    if (this.unprotectedAttributeGenerator != null)
      unprotectedAttrs = (Asn1Set) new BerSet(this.unprotectedAttributeGenerator.GetAttributes((IDictionary<CmsAttributeTableParameter, object>) new Dictionary<CmsAttributeTableParameter, object>()).ToAsn1EncodableVector());
    return new CmsEnvelopedData(new ContentInfo(CmsObjectIdentifiers.EnvelopedData, (Asn1Encodable) new EnvelopedData((OriginatorInfo) null, (Asn1Set) new DerSet(elementVector), encryptedContentInfo, unprotectedAttrs)));
  }

  public CmsEnvelopedData Generate(CmsProcessable content, string encryptionOid)
  {
    try
    {
      CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
      keyGenerator.Init(new KeyGenerationParameters(this.m_random, keyGenerator.DefaultStrength));
      return this.Generate(content, encryptionOid, keyGenerator);
    }
    catch (SecurityUtilityException ex)
    {
      throw new CmsException("can't find key generation algorithm.", (Exception) ex);
    }
  }

  public CmsEnvelopedData Generate(CmsProcessable content, ICipherBuilderWithKey cipherBuilder)
  {
    KeyParameter key;
    Asn1OctetString encryptedContent;
    try
    {
      key = (KeyParameter) cipherBuilder.Key;
      MemoryStream memoryStream = new MemoryStream();
      using (Stream stream = cipherBuilder.BuildCipher((Stream) memoryStream).Stream)
        content.Write(stream);
      encryptedContent = (Asn1OctetString) new BerOctetString(memoryStream.ToArray());
    }
    catch (SecurityUtilityException ex)
    {
      throw new CmsException("couldn't create cipher.", (Exception) ex);
    }
    catch (InvalidKeyException ex)
    {
      throw new CmsException("key invalid in message.", (Exception) ex);
    }
    catch (IOException ex)
    {
      throw new CmsException("exception decoding algorithm parameters.", (Exception) ex);
    }
    Asn1EncodableVector elementVector = new Asn1EncodableVector(this.recipientInfoGenerators.Count);
    foreach (RecipientInfoGenerator recipientInfoGenerator in (IEnumerable<RecipientInfoGenerator>) this.recipientInfoGenerators)
    {
      try
      {
        elementVector.Add((Asn1Encodable) recipientInfoGenerator.Generate(key, this.m_random));
      }
      catch (InvalidKeyException ex)
      {
        throw new CmsException("key inappropriate for algorithm.", (Exception) ex);
      }
      catch (GeneralSecurityException ex)
      {
        throw new CmsException("error making encrypted content.", (Exception) ex);
      }
    }
    EncryptedContentInfo encryptedContentInfo = new EncryptedContentInfo(CmsObjectIdentifiers.Data, (AlgorithmIdentifier) cipherBuilder.AlgorithmDetails, encryptedContent);
    Asn1Set unprotectedAttrs = (Asn1Set) null;
    if (this.unprotectedAttributeGenerator != null)
      unprotectedAttrs = (Asn1Set) new BerSet(this.unprotectedAttributeGenerator.GetAttributes((IDictionary<CmsAttributeTableParameter, object>) new Dictionary<CmsAttributeTableParameter, object>()).ToAsn1EncodableVector());
    return new CmsEnvelopedData(new ContentInfo(CmsObjectIdentifiers.EnvelopedData, (Asn1Encodable) new EnvelopedData((OriginatorInfo) null, (Asn1Set) new DerSet(elementVector), encryptedContentInfo, unprotectedAttrs)));
  }

  public CmsEnvelopedData Generate(CmsProcessable content, string encryptionOid, int keySize)
  {
    try
    {
      CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
      keyGenerator.Init(new KeyGenerationParameters(this.m_random, keySize));
      return this.Generate(content, encryptionOid, keyGenerator);
    }
    catch (SecurityUtilityException ex)
    {
      throw new CmsException("can't find key generation algorithm.", (Exception) ex);
    }
  }
}
