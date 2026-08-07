// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.CipherKeyGeneratorFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

public static class CipherKeyGeneratorFactory
{
  public static CipherKeyGenerator CreateKeyGenerator(
    DerObjectIdentifier algorithm,
    SecureRandom random)
  {
    if (NistObjectIdentifiers.IdAes128Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 128 /*0x80*/);
    if (NistObjectIdentifiers.IdAes192Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 192 /*0xC0*/);
    if (NistObjectIdentifiers.IdAes256Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 256 /*0x0100*/);
    if (PkcsObjectIdentifiers.DesEde3Cbc.Equals((Asn1Object) algorithm))
    {
      DesEdeKeyGenerator keyGenerator = new DesEdeKeyGenerator();
      keyGenerator.Init(new KeyGenerationParameters(random, 192 /*0xC0*/));
      return (CipherKeyGenerator) keyGenerator;
    }
    if (NttObjectIdentifiers.IdCamellia128Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 128 /*0x80*/);
    if (NttObjectIdentifiers.IdCamellia192Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 192 /*0xC0*/);
    if (NttObjectIdentifiers.IdCamellia256Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 256 /*0x0100*/);
    if (KisaObjectIdentifiers.IdSeedCbc.Equals((Asn1Object) algorithm) || AlgorithmIdentifierFactory.CAST5_CBC.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 128 /*0x80*/);
    if (OiwObjectIdentifiers.DesCbc.Equals((Asn1Object) algorithm))
    {
      DesKeyGenerator keyGenerator = new DesKeyGenerator();
      keyGenerator.Init(new KeyGenerationParameters(random, 64 /*0x40*/));
      return (CipherKeyGenerator) keyGenerator;
    }
    if (PkcsObjectIdentifiers.rc4.Equals((Asn1Object) algorithm) || PkcsObjectIdentifiers.RC2Cbc.Equals((Asn1Object) algorithm))
      return CipherKeyGeneratorFactory.CreateCipherKeyGenerator(random, 128 /*0x80*/);
    throw new InvalidOperationException("cannot recognise cipher: " + algorithm?.ToString());
  }

  private static CipherKeyGenerator CreateCipherKeyGenerator(SecureRandom random, int keySize)
  {
    CipherKeyGenerator cipherKeyGenerator = new CipherKeyGenerator();
    cipherKeyGenerator.Init(new KeyGenerationParameters(random, keySize));
    return cipherKeyGenerator;
  }
}
