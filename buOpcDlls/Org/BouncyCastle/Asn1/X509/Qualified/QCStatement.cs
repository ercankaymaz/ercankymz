// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.QCStatement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public class QCStatement : Asn1Encodable
{
  private readonly DerObjectIdentifier qcStatementId;
  private readonly Asn1Encodable qcStatementInfo;

  public static QCStatement GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case QCStatement _:
        return (QCStatement) obj;
      case Asn1Sequence _:
        return new QCStatement(Asn1Sequence.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private QCStatement(Asn1Sequence seq)
  {
    this.qcStatementId = DerObjectIdentifier.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.qcStatementInfo = seq[1];
  }

  public QCStatement(DerObjectIdentifier qcStatementId) => this.qcStatementId = qcStatementId;

  public QCStatement(DerObjectIdentifier qcStatementId, Asn1Encodable qcStatementInfo)
  {
    this.qcStatementId = qcStatementId;
    this.qcStatementInfo = qcStatementInfo;
  }

  public DerObjectIdentifier StatementId => this.qcStatementId;

  public Asn1Encodable StatementInfo => this.qcStatementInfo;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.qcStatementId);
    elementVector.AddOptional(this.qcStatementInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
