// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAuthenticatedDataGenerator
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
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsAuthenticatedDataGenerator : CmsAuthenticatedGenerator
{
  public CmsAuthenticatedDataGenerator()
  {
  }

  public CmsAuthenticatedDataGenerator(SecureRandom random)
    : base(random)
  {
  }

  private CmsAuthenticatedData Generate(
    CmsProcessable content,
    string macOid,
    CipherKeyGenerator keyGen)
  {
    KeyParameter keyParameter;
    AlgorithmIdentifier algorithmIdentifier;
    Asn1OctetString content1;
    Asn1OctetString mac1;
    try
    {
      byte[] key = keyGen.GenerateKey();
      keyParameter = ParameterUtilities.CreateKeyParameter(macOid, key);
      Asn1Encodable asn1Parameters = this.GenerateAsn1Parameters(macOid, key);
      algorithmIdentifier = this.GetAlgorithmIdentifier(macOid, keyParameter, asn1Parameters, out ICipherParameters _);
      IMac mac2 = MacUtilities.GetMac(macOid);
      mac2.Init((ICipherParameters) keyParameter);
      MemoryStream output = new MemoryStream();
      using (TeeOutputStream outStream = new TeeOutputStream((Stream) output, (Stream) new MacSink(mac2)))
        content.Write((Stream) outStream);
      content1 = (Asn1OctetString) new BerOctetString(output.ToArray());
      mac1 = (Asn1OctetString) new DerOctetString(MacUtilities.DoFinal(mac2));
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
    ContentInfo encapsulatedContent = new ContentInfo(CmsObjectIdentifiers.Data, (Asn1Encodable) content1);
    return new CmsAuthenticatedData(new ContentInfo(CmsObjectIdentifiers.AuthenticatedData, (Asn1Encodable) new AuthenticatedData((OriginatorInfo) null, (Asn1Set) new DerSet(elementVector), algorithmIdentifier, (AlgorithmIdentifier) null, encapsulatedContent, (Asn1Set) null, mac1, (Asn1Set) null)));
  }

  public CmsAuthenticatedData Generate(CmsProcessable content, string encryptionOid)
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
}
