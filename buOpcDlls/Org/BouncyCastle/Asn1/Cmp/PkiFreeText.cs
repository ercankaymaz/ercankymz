// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiFreeText
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiFreeText : Asn1Encodable
{
  private readonly Asn1Sequence m_strings;

  public static PkiFreeText GetInstance(object obj)
  {
    if (obj == null)
      return (PkiFreeText) null;
    return obj is PkiFreeText pkiFreeText ? pkiFreeText : new PkiFreeText(Asn1Sequence.GetInstance(obj));
  }

  public static PkiFreeText GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PkiFreeText.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  internal PkiFreeText(Asn1Sequence seq)
  {
    foreach (Asn1Encodable asn1Encodable in seq)
    {
      if (!(asn1Encodable is DerUtf8String))
        throw new ArgumentException("attempt to insert non UTF8 STRING into PkiFreeText");
    }
    this.m_strings = seq;
  }

  public PkiFreeText(DerUtf8String p)
  {
    this.m_strings = (Asn1Sequence) new DerSequence((Asn1Encodable) p);
  }

  public PkiFreeText(string p)
    : this(new DerUtf8String(p))
  {
  }

  public PkiFreeText(DerUtf8String[] strs)
  {
    this.m_strings = (Asn1Sequence) new DerSequence((Asn1Encodable[]) strs);
  }

  public PkiFreeText(string[] strs)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(strs.Length);
    for (int index = 0; index < strs.Length; ++index)
      elementVector.Add((Asn1Encodable) new DerUtf8String(strs[index]));
    this.m_strings = (Asn1Sequence) new DerSequence(elementVector);
  }

  public virtual int Count => this.m_strings.Count;

  public DerUtf8String this[int index] => (DerUtf8String) this.m_strings[index];

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_strings;
}
