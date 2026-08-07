// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1CipherBuilderWithKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1CipherBuilderWithKey : ICipherBuilderWithKey, ICipherBuilder
{
  private readonly KeyParameter encKey;
  private AlgorithmIdentifier algorithmIdentifier;

  public Asn1CipherBuilderWithKey(
    DerObjectIdentifier encryptionOID,
    int keySize,
    SecureRandom random)
  {
    random = CryptoServicesRegistrar.GetSecureRandom(random);
    this.encKey = CipherKeyGeneratorFactory.CreateKeyGenerator(encryptionOID, random).GenerateKeyParameter();
    this.algorithmIdentifier = AlgorithmIdentifierFactory.GenerateEncryptionAlgID(encryptionOID, this.encKey.KeyLength * 8, random);
  }

  public object AlgorithmDetails => (object) this.algorithmIdentifier;

  public int GetMaxOutputSize(int inputLen) => throw new NotImplementedException();

  public ICipher BuildCipher(Stream stream)
  {
    object cipher = EnvelopedDataHelper.CreateContentCipher(true, (ICipherParameters) this.encKey, this.algorithmIdentifier);
    if (cipher is IStreamCipher)
      cipher = (object) new BufferedStreamCipher((IStreamCipher) cipher);
    if (stream == null)
      stream = (Stream) new MemoryStream();
    return (ICipher) new BufferedCipherWrapper((IBufferedCipher) cipher, stream);
  }

  public ICipherParameters Key => (ICipherParameters) this.encKey;
}
