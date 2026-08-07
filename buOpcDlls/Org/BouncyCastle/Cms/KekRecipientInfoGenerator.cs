// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.KekRecipientInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal class KekRecipientInfoGenerator : RecipientInfoGenerator
{
  private static readonly CmsEnvelopedHelper Helper = CmsEnvelopedHelper.Instance;
  private KeyParameter keyEncryptionKey;
  private string keyEncryptionKeyOID;
  private KekIdentifier kekIdentifier;
  private AlgorithmIdentifier keyEncryptionAlgorithm;

  internal KekRecipientInfoGenerator()
  {
  }

  internal KekIdentifier KekIdentifier
  {
    set => this.kekIdentifier = value;
  }

  internal KeyParameter KeyEncryptionKey
  {
    set
    {
      this.keyEncryptionKey = value;
      this.keyEncryptionAlgorithm = KekRecipientInfoGenerator.DetermineKeyEncAlg(this.keyEncryptionKeyOID, this.keyEncryptionKey);
    }
  }

  internal string KeyEncryptionKeyOID
  {
    set => this.keyEncryptionKeyOID = value;
  }

  public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
  {
    byte[] key = contentEncryptionKey.GetKey();
    IWrapper wrapper = WrapperUtilities.GetWrapper(this.keyEncryptionAlgorithm.Algorithm.Id);
    wrapper.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) this.keyEncryptionKey, random));
    return new RecipientInfo(new KekRecipientInfo(this.kekIdentifier, this.keyEncryptionAlgorithm, (Asn1OctetString) new DerOctetString(wrapper.Wrap(key, 0, key.Length))));
  }

  private static AlgorithmIdentifier DetermineKeyEncAlg(string algorithm, KeyParameter key)
  {
    if (Platform.StartsWith(algorithm, "DES"))
      return new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgCms3DesWrap, (Asn1Encodable) DerNull.Instance);
    if (Platform.StartsWith(algorithm, "RC2"))
      return new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgCmsRC2Wrap, (Asn1Encodable) new DerInteger(58));
    if (Platform.StartsWith(algorithm, "AES"))
    {
      DerObjectIdentifier algorithm1;
      switch (key.KeyLength * 8)
      {
        case 128 /*0x80*/:
          algorithm1 = NistObjectIdentifiers.IdAes128Wrap;
          break;
        case 192 /*0xC0*/:
          algorithm1 = NistObjectIdentifiers.IdAes192Wrap;
          break;
        case 256 /*0x0100*/:
          algorithm1 = NistObjectIdentifiers.IdAes256Wrap;
          break;
        default:
          throw new ArgumentException("illegal keysize in AES");
      }
      return new AlgorithmIdentifier(algorithm1);
    }
    if (Platform.StartsWith(algorithm, "SEED"))
      return new AlgorithmIdentifier(KisaObjectIdentifiers.IdNpkiAppCmsSeedWrap);
    if (!Platform.StartsWith(algorithm, "CAMELLIA"))
      throw new ArgumentException("unknown algorithm");
    DerObjectIdentifier algorithm2;
    switch (key.KeyLength * 8)
    {
      case 128 /*0x80*/:
        algorithm2 = NttObjectIdentifiers.IdCamellia128Wrap;
        break;
      case 192 /*0xC0*/:
        algorithm2 = NttObjectIdentifiers.IdCamellia192Wrap;
        break;
      case 256 /*0x0100*/:
        algorithm2 = NttObjectIdentifiers.IdCamellia256Wrap;
        break;
      default:
        throw new ArgumentException("illegal keysize in Camellia");
    }
    return new AlgorithmIdentifier(algorithm2);
  }
}
