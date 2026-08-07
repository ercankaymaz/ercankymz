// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.AuthenticatedSafe
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class AuthenticatedSafe : Asn1Encodable
{
  private readonly ContentInfo[] info;
  private readonly bool isBer;

  private static ContentInfo[] Copy(ContentInfo[] info) => (ContentInfo[]) info.Clone();

  public static AuthenticatedSafe GetInstance(object obj)
  {
    if (obj is AuthenticatedSafe)
      return (AuthenticatedSafe) obj;
    return obj == null ? (AuthenticatedSafe) null : new AuthenticatedSafe(Asn1Sequence.GetInstance(obj));
  }

  private AuthenticatedSafe(Asn1Sequence seq)
  {
    this.info = new ContentInfo[seq.Count];
    for (int index = 0; index != this.info.Length; ++index)
      this.info[index] = ContentInfo.GetInstance((object) seq[index]);
    this.isBer = seq is BerSequence;
  }

  public AuthenticatedSafe(ContentInfo[] info)
  {
    this.info = AuthenticatedSafe.Copy(info);
    this.isBer = true;
  }

  public ContentInfo[] GetContentInfo() => AuthenticatedSafe.Copy(this.info);

  public override Asn1Object ToAsn1Object()
  {
    return this.isBer ? (Asn1Object) new BerSequence((Asn1Encodable[]) this.info) : (Asn1Object) new DerSequence((Asn1Encodable[]) this.info);
  }
}
