// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.KeyTransRecipientInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class KeyTransRecipientInfoGenerator : RecipientInfoGenerator
{
  private readonly IKeyWrapper m_keyWrapper;
  private IssuerAndSerialNumber m_issuerAndSerialNumber;
  private Asn1OctetString m_subjectKeyIdentifier;

  public KeyTransRecipientInfoGenerator(X509Certificate recipCert, IKeyWrapper keyWrapper)
    : this(new IssuerAndSerialNumber(recipCert.IssuerDN, new DerInteger(recipCert.SerialNumber)), keyWrapper)
  {
  }

  public KeyTransRecipientInfoGenerator(
    IssuerAndSerialNumber issuerAndSerial,
    IKeyWrapper keyWrapper)
  {
    this.m_issuerAndSerialNumber = issuerAndSerial;
    this.m_keyWrapper = keyWrapper;
  }

  public KeyTransRecipientInfoGenerator(byte[] subjectKeyID, IKeyWrapper keyWrapper)
  {
    this.m_subjectKeyIdentifier = (Asn1OctetString) new DerOctetString(subjectKeyID);
    this.m_keyWrapper = keyWrapper;
  }

  public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
  {
    AlgorithmIdentifier algorithmDetails = this.AlgorithmDetails;
    byte[] wrappedKey = this.GenerateWrappedKey(contentEncryptionKey);
    return new RecipientInfo(new KeyTransRecipientInfo(this.m_issuerAndSerialNumber == null ? new RecipientIdentifier(this.m_subjectKeyIdentifier) : new RecipientIdentifier(this.m_issuerAndSerialNumber), algorithmDetails, (Asn1OctetString) new DerOctetString(wrappedKey)));
  }

  protected virtual AlgorithmIdentifier AlgorithmDetails
  {
    get => (AlgorithmIdentifier) this.m_keyWrapper.AlgorithmDetails;
  }

  protected virtual byte[] GenerateWrappedKey(KeyParameter contentEncryptionKey)
  {
    return this.m_keyWrapper.Wrap(contentEncryptionKey.GetKey()).Collect();
  }
}
