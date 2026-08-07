// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.Asn1DigestFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class Asn1DigestFactory : IDigestFactory
{
  private readonly IDigest mDigest;
  private readonly DerObjectIdentifier mOid;

  public static Asn1DigestFactory Get(DerObjectIdentifier oid)
  {
    return new Asn1DigestFactory(DigestUtilities.GetDigest(oid), oid);
  }

  public static Asn1DigestFactory Get(string mechanism)
  {
    DerObjectIdentifier objectIdentifier = DigestUtilities.GetObjectIdentifier(mechanism);
    return new Asn1DigestFactory(DigestUtilities.GetDigest(objectIdentifier), objectIdentifier);
  }

  public Asn1DigestFactory(IDigest digest, DerObjectIdentifier oid)
  {
    this.mDigest = digest;
    this.mOid = oid;
  }

  public virtual object AlgorithmDetails => (object) new AlgorithmIdentifier(this.mOid);

  public virtual int DigestLength => this.mDigest.GetDigestSize();

  public virtual IStreamCalculator<IBlockResult> CreateCalculator()
  {
    return (IStreamCalculator<IBlockResult>) new DfDigestStream(this.mDigest);
  }
}
