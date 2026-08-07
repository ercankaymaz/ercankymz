// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.EnvelopedDataHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal class EnvelopedDataHelper
{
  public static object CreateContentCipher(
    bool forEncryption,
    ICipherParameters encKey,
    AlgorithmIdentifier encryptionAlgID)
  {
    return CipherFactory.CreateContentCipher(forEncryption, encKey, encryptionAlgID);
  }

  public AlgorithmIdentifier GenerateEncryptionAlgID(
    DerObjectIdentifier encryptionOID,
    KeyParameter encKey,
    SecureRandom random)
  {
    return AlgorithmIdentifierFactory.GenerateEncryptionAlgID(encryptionOID, encKey.KeyLength * 8, random);
  }

  public CipherKeyGenerator CreateKeyGenerator(DerObjectIdentifier algorithm, SecureRandom random)
  {
    return CipherKeyGeneratorFactory.CreateKeyGenerator(algorithm, random);
  }
}
