// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.ErrorMsgContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class ErrorMsgContent : Asn1Encodable
{
  private readonly PkiStatusInfo m_pkiStatusInfo;
  private readonly DerInteger m_errorCode;
  private readonly PkiFreeText m_errorDetails;

  public static ErrorMsgContent GetInstance(object obj)
  {
    if (obj == null)
      return (ErrorMsgContent) null;
    return obj is ErrorMsgContent errorMsgContent ? errorMsgContent : new ErrorMsgContent(Asn1Sequence.GetInstance(obj));
  }

  public static ErrorMsgContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return ErrorMsgContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private ErrorMsgContent(Asn1Sequence seq)
  {
    this.m_pkiStatusInfo = PkiStatusInfo.GetInstance((object) seq[0]);
    for (int index = 1; index < seq.Count; ++index)
    {
      Asn1Encodable asn1Encodable = seq[index];
      if (asn1Encodable is DerInteger)
        this.m_errorCode = DerInteger.GetInstance((object) asn1Encodable);
      else
        this.m_errorDetails = PkiFreeText.GetInstance((object) asn1Encodable);
    }
  }

  public ErrorMsgContent(PkiStatusInfo pkiStatusInfo)
    : this(pkiStatusInfo, (DerInteger) null, (PkiFreeText) null)
  {
  }

  public ErrorMsgContent(
    PkiStatusInfo pkiStatusInfo,
    DerInteger errorCode,
    PkiFreeText errorDetails)
  {
    this.m_pkiStatusInfo = pkiStatusInfo != null ? pkiStatusInfo : throw new ArgumentNullException(nameof (pkiStatusInfo));
    this.m_errorCode = errorCode;
    this.m_errorDetails = errorDetails;
  }

  public virtual PkiStatusInfo PkiStatusInfo => this.m_pkiStatusInfo;

  public virtual DerInteger ErrorCode => this.m_errorCode;

  public virtual PkiFreeText ErrorDetails => this.m_errorDetails;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_pkiStatusInfo);
    elementVector.AddOptional((Asn1Encodable) this.m_errorCode, (Asn1Encodable) this.m_errorDetails);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
