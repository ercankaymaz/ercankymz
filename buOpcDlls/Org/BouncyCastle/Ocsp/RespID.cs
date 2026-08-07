// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.RespID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class RespID
{
  internal readonly ResponderID id;

  public RespID(ResponderID id) => this.id = id;

  public RespID(X509Name name) => this.id = new ResponderID(name);

  public RespID(AsymmetricKeyParameter publicKey)
  {
    try
    {
      this.id = new ResponderID((Asn1OctetString) new DerOctetString(DigestUtilities.CalculateDigest("SHA1", SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey).PublicKeyData.GetBytes())));
    }
    catch (Exception ex)
    {
      throw new OcspException("problem creating ID: " + ex?.ToString(), ex);
    }
  }

  public ResponderID ToAsn1Object() => this.id;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is RespID respId && this.id.Equals((object) respId.id);
  }

  public override int GetHashCode() => this.id.GetHashCode();
}
