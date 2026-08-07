// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.PasswordRecipientInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal class PasswordRecipientInfoGenerator : RecipientInfoGenerator
{
  private static readonly CmsEnvelopedHelper Helper = CmsEnvelopedHelper.Instance;
  private AlgorithmIdentifier keyDerivationAlgorithm;
  private KeyParameter keyEncryptionKey;
  private string keyEncryptionKeyOID;

  internal PasswordRecipientInfoGenerator()
  {
  }

  internal AlgorithmIdentifier KeyDerivationAlgorithm
  {
    set => this.keyDerivationAlgorithm = value;
  }

  internal KeyParameter KeyEncryptionKey
  {
    set => this.keyEncryptionKey = value;
  }

  internal string KeyEncryptionKeyOID
  {
    set => this.keyEncryptionKeyOID = value;
  }

  public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
  {
    byte[] key = contentEncryptionKey.GetKey();
    string rfc3211WrapperName = PasswordRecipientInfoGenerator.Helper.GetRfc3211WrapperName(this.keyEncryptionKeyOID);
    IWrapper wrapper = WrapperUtilities.GetWrapper(rfc3211WrapperName);
    byte[] numArray = new byte[Platform.StartsWithIgnoreCase(rfc3211WrapperName, "DES") ? 8 : 16 /*0x10*/];
    random.NextBytes(numArray);
    ParametersWithIV parameters1 = new ParametersWithIV((ICipherParameters) this.keyEncryptionKey, numArray);
    wrapper.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) parameters1, random));
    Asn1OctetString encryptedKey = (Asn1OctetString) new DerOctetString(wrapper.Wrap(key, 0, key.Length));
    DerSequence parameters2 = new DerSequence((Asn1Encodable) new DerObjectIdentifier(this.keyEncryptionKeyOID), (Asn1Encodable) new DerOctetString(numArray));
    return new RecipientInfo(new PasswordRecipientInfo(this.keyDerivationAlgorithm, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgPwriKek, (Asn1Encodable) parameters2), encryptedKey));
  }
}
