// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiStatusEncodable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiStatusEncodable : Asn1Encodable
{
  public static readonly PkiStatusEncodable granted = new PkiStatusEncodable(PkiStatus.Granted);
  public static readonly PkiStatusEncodable grantedWithMods = new PkiStatusEncodable(PkiStatus.GrantedWithMods);
  public static readonly PkiStatusEncodable rejection = new PkiStatusEncodable(PkiStatus.Rejection);
  public static readonly PkiStatusEncodable waiting = new PkiStatusEncodable(PkiStatus.Waiting);
  public static readonly PkiStatusEncodable revocationWarning = new PkiStatusEncodable(PkiStatus.RevocationWarning);
  public static readonly PkiStatusEncodable revocationNotification = new PkiStatusEncodable(PkiStatus.RevocationNotification);
  public static readonly PkiStatusEncodable keyUpdateWaiting = new PkiStatusEncodable(PkiStatus.KeyUpdateWarning);
  private readonly DerInteger status;

  public static PkiStatusEncodable GetInstance(object obj)
  {
    if (obj == null)
      return (PkiStatusEncodable) null;
    return obj is PkiStatusEncodable pkiStatusEncodable ? pkiStatusEncodable : new PkiStatusEncodable(DerInteger.GetInstance(obj));
  }

  public static PkiStatusEncodable GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PkiStatusEncodable.GetInstance((object) DerInteger.GetInstance(taggedObject, declaredExplicit));
  }

  private PkiStatusEncodable(PkiStatus status)
    : this(new DerInteger((int) status))
  {
  }

  private PkiStatusEncodable(DerInteger status) => this.status = status;

  public virtual BigInteger Value => this.status.Value;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.status;
}
