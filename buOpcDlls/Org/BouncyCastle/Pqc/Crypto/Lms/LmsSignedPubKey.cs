// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsSignedPubKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public class LmsSignedPubKey : IEncodable
{
  private LmsSignature signature;
  private LmsPublicKeyParameters publicKey;

  public LmsSignedPubKey(LmsSignature signature, LmsPublicKeyParameters publicKey)
  {
    this.signature = signature;
    this.publicKey = publicKey;
  }

  public LmsSignature GetSignature() => this.signature;

  public LmsPublicKeyParameters GetPublicKey() => this.publicKey;

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (o == null || this.GetType() != o.GetType())
      return false;
    LmsSignedPubKey lmsSignedPubKey = (LmsSignedPubKey) o;
    if ((this.signature != null ? (!this.signature.Equals((object) lmsSignedPubKey.signature) ? 1 : 0) : (lmsSignedPubKey.signature != null ? 1 : 0)) != 0)
      return false;
    return this.publicKey == null ? lmsSignedPubKey.publicKey == null : this.publicKey.Equals((object) lmsSignedPubKey.publicKey);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * (this.signature != null ? this.signature.GetHashCode() : 0) + (this.publicKey != null ? this.publicKey.GetHashCode() : 0);
  }

  public byte[] GetEncoded()
  {
    return Composer.Compose().Bytes(this.signature.GetEncoded()).Bytes(this.publicKey.GetEncoded()).Build();
  }
}
