// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Operators.CmsContentEncryptorBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Security;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Operators;

public class CmsContentEncryptorBuilder
{
  private static readonly IDictionary<DerObjectIdentifier, int> KeySizes = (IDictionary<DerObjectIdentifier, int>) new Dictionary<DerObjectIdentifier, int>();
  private readonly DerObjectIdentifier encryptionOID;
  private readonly int keySize;
  private readonly EnvelopedDataHelper helper = new EnvelopedDataHelper();

  static CmsContentEncryptorBuilder()
  {
    CmsContentEncryptorBuilder.KeySizes[NistObjectIdentifiers.IdAes128Cbc] = 128 /*0x80*/;
    CmsContentEncryptorBuilder.KeySizes[NistObjectIdentifiers.IdAes192Cbc] = 192 /*0xC0*/;
    CmsContentEncryptorBuilder.KeySizes[NistObjectIdentifiers.IdAes256Cbc] = 256 /*0x0100*/;
    CmsContentEncryptorBuilder.KeySizes[NttObjectIdentifiers.IdCamellia128Cbc] = 128 /*0x80*/;
    CmsContentEncryptorBuilder.KeySizes[NttObjectIdentifiers.IdCamellia192Cbc] = 192 /*0xC0*/;
    CmsContentEncryptorBuilder.KeySizes[NttObjectIdentifiers.IdCamellia256Cbc] = 256 /*0x0100*/;
  }

  private static int GetKeySize(DerObjectIdentifier oid)
  {
    int num;
    return !CmsContentEncryptorBuilder.KeySizes.TryGetValue(oid, out num) ? -1 : num;
  }

  public CmsContentEncryptorBuilder(DerObjectIdentifier encryptionOID)
    : this(encryptionOID, CmsContentEncryptorBuilder.GetKeySize(encryptionOID))
  {
  }

  public CmsContentEncryptorBuilder(DerObjectIdentifier encryptionOID, int keySize)
  {
    this.encryptionOID = encryptionOID;
    this.keySize = keySize;
  }

  public ICipherBuilderWithKey Build()
  {
    return (ICipherBuilderWithKey) new Asn1CipherBuilderWithKey(this.encryptionOID, this.keySize, (SecureRandom) null);
  }
}
