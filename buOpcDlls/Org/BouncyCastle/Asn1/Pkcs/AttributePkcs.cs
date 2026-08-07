// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.AttributePkcs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class AttributePkcs : Asn1Encodable
{
  private readonly DerObjectIdentifier attrType;
  private readonly Asn1Set attrValues;

  public static AttributePkcs GetInstance(object obj)
  {
    AttributePkcs instance = obj as AttributePkcs;
    if (obj == null || instance != null)
      return instance;
    return obj is Asn1Sequence seq ? new AttributePkcs(seq) : throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
  }

  private AttributePkcs(Asn1Sequence seq)
  {
    this.attrType = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.attrValues = Asn1Set.GetInstance((object) seq[1]);
  }

  public AttributePkcs(DerObjectIdentifier attrType, Asn1Set attrValues)
  {
    this.attrType = attrType;
    this.attrValues = attrValues;
  }

  public DerObjectIdentifier AttrType => this.attrType;

  public Asn1Set AttrValues => this.attrValues;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.attrType, (Asn1Encodable) this.attrValues);
  }
}
