// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.SignerID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509.Store;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class SignerID : X509CertStoreSelector
{
  public override int GetHashCode()
  {
    int hashCode = Arrays.GetHashCode(this.SubjectKeyIdentifier);
    BigInteger serialNumber = this.SerialNumber;
    if (serialNumber != null)
      hashCode ^= serialNumber.GetHashCode();
    X509Name issuer = this.Issuer;
    if (issuer != null)
      hashCode ^= issuer.GetHashCode();
    return hashCode;
  }

  public override bool Equals(object obj)
  {
    return obj != this && obj is SignerID signerId && Arrays.AreEqual(this.SubjectKeyIdentifier, signerId.SubjectKeyIdentifier) && object.Equals((object) this.SerialNumber, (object) signerId.SerialNumber) && X509CertStoreSelector.IssuersMatch(this.Issuer, signerId.Issuer);
  }
}
