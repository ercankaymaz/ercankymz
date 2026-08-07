// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.ScvpReqRes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class ScvpReqRes : Asn1Encodable
{
  private readonly ContentInfo request;
  private readonly ContentInfo response;

  public static ScvpReqRes GetInstance(object obj)
  {
    if (obj is ScvpReqRes)
      return (ScvpReqRes) obj;
    return obj != null ? new ScvpReqRes(Asn1Sequence.GetInstance(obj)) : (ScvpReqRes) null;
  }

  private ScvpReqRes(Asn1Sequence seq)
  {
    if (seq[0] is Asn1TaggedObject asn1TaggedObject)
    {
      this.request = ContentInfo.GetInstance(asn1TaggedObject, true);
      this.response = ContentInfo.GetInstance((object) seq[1]);
    }
    else
    {
      this.request = (ContentInfo) null;
      this.response = ContentInfo.GetInstance((object) seq[0]);
    }
  }

  public ScvpReqRes(ContentInfo response)
    : this((ContentInfo) null, response)
  {
  }

  public ScvpReqRes(ContentInfo request, ContentInfo response)
  {
    this.request = request;
    this.response = response;
  }

  public virtual ContentInfo Request => this.request;

  public virtual ContentInfo Response => this.response;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.request);
    elementVector.Add((Asn1Encodable) this.response);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
