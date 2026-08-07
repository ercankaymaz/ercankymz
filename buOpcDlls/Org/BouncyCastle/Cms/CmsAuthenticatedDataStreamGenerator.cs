// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAuthenticatedDataStreamGenerator
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

public class CmsAuthenticatedDataStreamGenerator : CmsAuthenticatedGenerator
{
  private int _bufferSize;
  private bool _berEncodeRecipientSet;

  public CmsAuthenticatedDataStreamGenerator()
  {
  }

  public CmsAuthenticatedDataStreamGenerator(SecureRandom random)
    : base(random)
  {
  }

  public void SetBufferSize(int bufferSize) => this._bufferSize = bufferSize;

  public void SetBerEncodeRecipients(bool berEncodeRecipientSet)
  {
    this._berEncodeRecipientSet = berEncodeRecipientSet;
  }

  private Stream Open(Stream outStr, string macOid, CipherKeyGenerator keyGen)
  {
    byte[] key = keyGen.GenerateKey();
    KeyParameter keyParameter = ParameterUtilities.CreateKeyParameter(macOid, key);
    Asn1Encodable asn1Parameters = this.GenerateAsn1Parameters(macOid, key);
    AlgorithmIdentifier algorithmIdentifier = this.GetAlgorithmIdentifier(macOid, keyParameter, asn1Parameters, out ICipherParameters _);
    Asn1EncodableVector recipientInfos = new Asn1EncodableVector(this.recipientInfoGenerators.Count);
    foreach (RecipientInfoGenerator recipientInfoGenerator in (IEnumerable<RecipientInfoGenerator>) this.recipientInfoGenerators)
    {
      try
      {
        recipientInfos.Add((Asn1Encodable) recipientInfoGenerator.Generate(keyParameter, this.m_random));
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
    return this.Open(outStr, algorithmIdentifier, (ICipherParameters) keyParameter, recipientInfos);
  }

  protected Stream Open(
    Stream outStr,
    AlgorithmIdentifier macAlgId,
    ICipherParameters cipherParameters,
    Asn1EncodableVector recipientInfos)
  {
    try
    {
      BerSequenceGenerator cGen = new BerSequenceGenerator(outStr);
      cGen.AddObject((Asn1Object) CmsObjectIdentifiers.AuthenticatedData);
      BerSequenceGenerator authGen = new BerSequenceGenerator(cGen.GetRawOutputStream(), 0, true);
      authGen.AddObject((Asn1Object) new DerInteger(AuthenticatedData.CalculateVersion((OriginatorInfo) null)));
      Stream rawOutputStream = authGen.GetRawOutputStream();
      using (Asn1Generator asn1Generator = this._berEncodeRecipientSet ? (Asn1Generator) new BerSetGenerator(rawOutputStream) : (Asn1Generator) new DerSetGenerator(rawOutputStream))
      {
        foreach (Asn1Encodable recipientInfo in recipientInfos)
          asn1Generator.AddObject(recipientInfo);
      }
      authGen.AddObject((Asn1Encodable) macAlgId);
      BerSequenceGenerator eiGen = new BerSequenceGenerator(rawOutputStream);
      eiGen.AddObject((Asn1Object) CmsObjectIdentifiers.Data);
      BerOctetStringGenerator octGen = new BerOctetStringGenerator(eiGen.GetRawOutputStream(), 0, true);
      Stream octetOutputStream = octGen.GetOctetOutputStream(this._bufferSize);
      IMac mac = MacUtilities.GetMac(macAlgId.Algorithm);
      mac.Init(cipherParameters);
      MacSink tee = new MacSink(mac);
      return (Stream) new CmsAuthenticatedDataStreamGenerator.CmsAuthenticatedDataOutputStream((Stream) new TeeOutputStream(octetOutputStream, (Stream) tee), mac, cGen, authGen, eiGen, octGen);
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
  }

  public Stream Open(Stream outStr, string encryptionOid)
  {
    CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
    keyGenerator.Init(new KeyGenerationParameters(this.m_random, keyGenerator.DefaultStrength));
    return this.Open(outStr, encryptionOid, keyGenerator);
  }

  public Stream Open(Stream outStr, string encryptionOid, int keySize)
  {
    CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
    keyGenerator.Init(new KeyGenerationParameters(this.m_random, keySize));
    return this.Open(outStr, encryptionOid, keyGenerator);
  }

  private class CmsAuthenticatedDataOutputStream : BaseOutputStream
  {
    private readonly Stream macStream;
    private readonly IMac mac;
    private readonly BerSequenceGenerator cGen;
    private readonly BerSequenceGenerator authGen;
    private readonly BerSequenceGenerator eiGen;
    private readonly BerOctetStringGenerator octGen;

    public CmsAuthenticatedDataOutputStream(
      Stream macStream,
      IMac mac,
      BerSequenceGenerator cGen,
      BerSequenceGenerator authGen,
      BerSequenceGenerator eiGen,
      BerOctetStringGenerator octGen)
    {
      this.macStream = macStream;
      this.mac = mac;
      this.cGen = cGen;
      this.authGen = authGen;
      this.eiGen = eiGen;
      this.octGen = octGen;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this.macStream.Write(buffer, offset, count);
    }

    public override void WriteByte(byte value) => this.macStream.WriteByte(value);

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.macStream.Dispose();
        this.octGen.Dispose();
        this.eiGen.Dispose();
        this.authGen.AddObject((Asn1Object) new DerOctetString(MacUtilities.DoFinal(this.mac)));
        this.authGen.Dispose();
        this.cGen.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
