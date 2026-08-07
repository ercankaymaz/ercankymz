// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsEnvelopedHelper
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

internal class CmsEnvelopedHelper
{
  internal static readonly CmsEnvelopedHelper Instance = new CmsEnvelopedHelper();
  private static readonly Dictionary<string, int> KeySizes = new Dictionary<string, int>();
  private static readonly Dictionary<string, string> Rfc3211WrapperNames = new Dictionary<string, string>();

  static CmsEnvelopedHelper()
  {
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.Aes128Cbc, 128 /*0x80*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.Aes192Cbc, 192 /*0xC0*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.Aes256Cbc, 256 /*0x0100*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.Camellia128Cbc, 128 /*0x80*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.Camellia192Cbc, 192 /*0xC0*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.Camellia256Cbc, 256 /*0x0100*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.DesCbc, 64 /*0x40*/);
    CmsEnvelopedHelper.KeySizes.Add(CmsEnvelopedGenerator.DesEde3Cbc, 192 /*0xC0*/);
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.Aes128Cbc, "AESRFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.Aes192Cbc, "AESRFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.Aes256Cbc, "AESRFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.Camellia128Cbc, "CAMELLIARFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.Camellia192Cbc, "CAMELLIARFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.Camellia256Cbc, "CAMELLIARFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.DesCbc, "DESRFC3211WRAP");
    CmsEnvelopedHelper.Rfc3211WrapperNames.Add(CmsEnvelopedGenerator.DesEde3Cbc, "DESEDERFC3211WRAP");
  }

  internal static RecipientInformationStore BuildRecipientInformationStore(
    Asn1Set recipientInfos,
    CmsSecureReadable secureReadable)
  {
    List<RecipientInformation> recipientInformationList = new List<RecipientInformation>();
    for (int index = 0; index != recipientInfos.Count; ++index)
    {
      RecipientInfo instance = RecipientInfo.GetInstance((object) recipientInfos[index]);
      CmsEnvelopedHelper.ReadRecipientInfo((IList<RecipientInformation>) recipientInformationList, instance, secureReadable);
    }
    return new RecipientInformationStore((IEnumerable<RecipientInformation>) recipientInformationList);
  }

  internal int GetKeySize(string oid)
  {
    if (oid == null)
      throw new ArgumentNullException(nameof (oid));
    int keySize;
    if (!CmsEnvelopedHelper.KeySizes.TryGetValue(oid, out keySize))
      throw new ArgumentException("no key size for " + oid, nameof (oid));
    return keySize;
  }

  internal string GetRfc3211WrapperName(string oid)
  {
    if (oid == null)
      throw new ArgumentNullException(nameof (oid));
    string rfc3211WrapperName;
    if (!CmsEnvelopedHelper.Rfc3211WrapperNames.TryGetValue(oid, out rfc3211WrapperName))
      throw new ArgumentException("no name for " + oid, nameof (oid));
    return rfc3211WrapperName;
  }

  private static void ReadRecipientInfo(
    IList<RecipientInformation> infos,
    RecipientInfo info,
    CmsSecureReadable secureReadable)
  {
    switch (info.Info)
    {
      case KeyTransRecipientInfo info1:
        infos.Add((RecipientInformation) new KeyTransRecipientInformation(info1, secureReadable));
        break;
      case KekRecipientInfo info2:
        infos.Add((RecipientInformation) new KekRecipientInformation(info2, secureReadable));
        break;
      case KeyAgreeRecipientInfo info3:
        KeyAgreeRecipientInformation.ReadRecipientInfo(infos, info3, secureReadable);
        break;
      case PasswordRecipientInfo info4:
        infos.Add((RecipientInformation) new PasswordRecipientInformation(info4, secureReadable));
        break;
    }
  }

  internal class CmsAuthenticatedSecureReadable : CmsSecureReadable
  {
    private AlgorithmIdentifier algorithm;
    private IMac mac;
    private CmsReadable readable;

    internal CmsAuthenticatedSecureReadable(AlgorithmIdentifier algorithm, CmsReadable readable)
    {
      this.algorithm = algorithm;
      this.readable = readable;
    }

    public AlgorithmIdentifier Algorithm => this.algorithm;

    public object CryptoObject => (object) this.mac;

    public CmsReadable GetReadable(KeyParameter sKey)
    {
      string id = this.algorithm.Algorithm.Id;
      try
      {
        this.mac = MacUtilities.GetMac(id);
        this.mac.Init((ICipherParameters) sKey);
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
        throw new CmsException("error decoding algorithm parameters.", (Exception) ex);
      }
      try
      {
        return (CmsReadable) new CmsProcessableInputStream((Stream) new TeeInputStream(this.readable.GetInputStream(), (Stream) new MacSink(this.mac)));
      }
      catch (IOException ex)
      {
        throw new CmsException("error reading content.", (Exception) ex);
      }
    }
  }

  internal class CmsEnvelopedSecureReadable : CmsSecureReadable
  {
    private AlgorithmIdentifier algorithm;
    private IBufferedCipher cipher;
    private CmsReadable readable;

    internal CmsEnvelopedSecureReadable(AlgorithmIdentifier algorithm, CmsReadable readable)
    {
      this.algorithm = algorithm;
      this.readable = readable;
    }

    public AlgorithmIdentifier Algorithm => this.algorithm;

    public object CryptoObject => (object) this.cipher;

    public CmsReadable GetReadable(KeyParameter sKey)
    {
      try
      {
        this.cipher = CipherUtilities.GetCipher(this.algorithm.Algorithm);
        Asn1Encodable parameters = this.algorithm.Parameters;
        Asn1Object asn1Object = parameters == null ? (Asn1Object) null : parameters.ToAsn1Object();
        ICipherParameters cipherParameters = (ICipherParameters) sKey;
        switch (asn1Object)
        {
          case null:
          case Asn1Null _:
            string id = this.algorithm.Algorithm.Id;
            if (id.Equals(CmsEnvelopedGenerator.DesEde3Cbc) || id.Equals("1.3.6.1.4.1.188.7.1.1.2") || id.Equals("1.2.840.113533.7.66.10"))
            {
              cipherParameters = (ICipherParameters) new ParametersWithIV(cipherParameters, new byte[8]);
              break;
            }
            break;
          default:
            cipherParameters = ParameterUtilities.GetCipherParameters(this.algorithm.Algorithm, cipherParameters, asn1Object);
            break;
        }
        this.cipher.Init(false, cipherParameters);
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
        throw new CmsException("error decoding algorithm parameters.", (Exception) ex);
      }
      try
      {
        return (CmsReadable) new CmsProcessableInputStream((Stream) new CipherStream(this.readable.GetInputStream(), this.cipher, (IBufferedCipher) null));
      }
      catch (IOException ex)
      {
        throw new CmsException("error reading content.", (Exception) ex);
      }
    }
  }
}
