// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsEnvelopedDataStreamGenerator
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

public class CmsEnvelopedDataStreamGenerator : CmsEnvelopedGenerator
{
  private object _originatorInfo;
  private object _unprotectedAttributes;
  private int _bufferSize;
  private bool _berEncodeRecipientSet;

  public CmsEnvelopedDataStreamGenerator()
  {
  }

  public CmsEnvelopedDataStreamGenerator(SecureRandom random)
    : base(random)
  {
  }

  public void SetBufferSize(int bufferSize) => this._bufferSize = bufferSize;

  public void SetBerEncodeRecipients(bool berEncodeRecipientSet)
  {
    this._berEncodeRecipientSet = berEncodeRecipientSet;
  }

  private DerInteger Version
  {
    get
    {
      return new DerInteger(this._originatorInfo != null || this._unprotectedAttributes != null ? 2 : 0);
    }
  }

  private Stream Open(Stream outStream, string encryptionOid, CipherKeyGenerator keyGen)
  {
    byte[] key = keyGen.GenerateKey();
    KeyParameter keyParameter = ParameterUtilities.CreateKeyParameter(encryptionOid, key);
    Asn1Encodable asn1Parameters = this.GenerateAsn1Parameters(encryptionOid, key);
    ICipherParameters cipherParameters;
    AlgorithmIdentifier algorithmIdentifier = this.GetAlgorithmIdentifier(encryptionOid, keyParameter, asn1Parameters, out cipherParameters);
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
    return this.Open(outStream, algorithmIdentifier, cipherParameters, recipientInfos);
  }

  private Stream Open(
    Stream outStream,
    AlgorithmIdentifier encAlgID,
    ICipherParameters cipherParameters,
    Asn1EncodableVector recipientInfos)
  {
    try
    {
      BerSequenceGenerator cGen = new BerSequenceGenerator(outStream);
      cGen.AddObject((Asn1Object) CmsObjectIdentifiers.EnvelopedData);
      BerSequenceGenerator envGen = new BerSequenceGenerator(cGen.GetRawOutputStream(), 0, true);
      envGen.AddObject((Asn1Object) this.Version);
      Stream rawOutputStream = envGen.GetRawOutputStream();
      using (Asn1Generator asn1Generator = this._berEncodeRecipientSet ? (Asn1Generator) new BerSetGenerator(rawOutputStream) : (Asn1Generator) new DerSetGenerator(rawOutputStream))
      {
        foreach (Asn1Encodable recipientInfo in recipientInfos)
          asn1Generator.AddObject(recipientInfo);
      }
      BerSequenceGenerator eiGen = new BerSequenceGenerator(rawOutputStream);
      eiGen.AddObject((Asn1Object) CmsObjectIdentifiers.Data);
      eiGen.AddObject((Asn1Encodable) encAlgID);
      BerOctetStringGenerator octGen = new BerOctetStringGenerator(eiGen.GetRawOutputStream(), 0, false);
      Stream octetOutputStream = octGen.GetOctetOutputStream(this._bufferSize);
      IBufferedCipher cipher = CipherUtilities.GetCipher(encAlgID.Algorithm);
      cipher.Init(true, (ICipherParameters) new ParametersWithRandom(cipherParameters, this.m_random));
      IBufferedCipher writeCipher = cipher;
      return (Stream) new CmsEnvelopedDataStreamGenerator.CmsEnvelopedDataOutputStream((CmsEnvelopedGenerator) this, new CipherStream(octetOutputStream, (IBufferedCipher) null, writeCipher), cGen, envGen, eiGen, octGen);
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

  public Stream Open(Stream outStream, string encryptionOid)
  {
    CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
    keyGenerator.Init(new KeyGenerationParameters(this.m_random, keyGenerator.DefaultStrength));
    return this.Open(outStream, encryptionOid, keyGenerator);
  }

  public Stream Open(Stream outStream, string encryptionOid, int keySize)
  {
    CipherKeyGenerator keyGenerator = GeneratorUtilities.GetKeyGenerator(encryptionOid);
    keyGenerator.Init(new KeyGenerationParameters(this.m_random, keySize));
    return this.Open(outStream, encryptionOid, keyGenerator);
  }

  private class CmsEnvelopedDataOutputStream : BaseOutputStream
  {
    private readonly CmsEnvelopedGenerator _outer;
    private readonly CipherStream _out;
    private readonly BerSequenceGenerator _cGen;
    private readonly BerSequenceGenerator _envGen;
    private readonly BerSequenceGenerator _eiGen;
    private readonly BerOctetStringGenerator _octGen;

    public CmsEnvelopedDataOutputStream(
      CmsEnvelopedGenerator outer,
      CipherStream outStream,
      BerSequenceGenerator cGen,
      BerSequenceGenerator envGen,
      BerSequenceGenerator eiGen,
      BerOctetStringGenerator octGen)
    {
      this._outer = outer;
      this._out = outStream;
      this._cGen = cGen;
      this._envGen = envGen;
      this._eiGen = eiGen;
      this._octGen = octGen;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this._out.Write(buffer, offset, count);
    }

    public override void WriteByte(byte value) => this._out.WriteByte(value);

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        this._out.Dispose();
        this._octGen.Dispose();
        this._eiGen.Dispose();
        if (this._outer.unprotectedAttributeGenerator != null)
          this._envGen.AddObject((Asn1Object) new DerTaggedObject(false, 1, (Asn1Encodable) new BerSet(this._outer.unprotectedAttributeGenerator.GetAttributes((IDictionary<CmsAttributeTableParameter, object>) new Dictionary<CmsAttributeTableParameter, object>()).ToAsn1EncodableVector())));
        this._envGen.Dispose();
        this._cGen.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
