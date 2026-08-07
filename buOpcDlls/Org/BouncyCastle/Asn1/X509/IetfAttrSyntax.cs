// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.IetfAttrSyntax
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class IetfAttrSyntax : Asn1Encodable
{
  public const int ValueOctets = 1;
  public const int ValueOid = 2;
  public const int ValueUtf8 = 3;
  internal readonly GeneralNames policyAuthority;
  internal readonly Asn1EncodableVector values = new Asn1EncodableVector();
  internal int valueChoice = -1;

  public IetfAttrSyntax(Asn1Sequence seq)
  {
    int index = 0;
    if (seq[0] is Asn1TaggedObject)
    {
      this.policyAuthority = GeneralNames.GetInstance((Asn1TaggedObject) seq[0], false);
      ++index;
    }
    else if (seq.Count == 2)
    {
      this.policyAuthority = GeneralNames.GetInstance((object) seq[0]);
      ++index;
    }
    seq = seq[index] is Asn1Sequence ? (Asn1Sequence) seq[index] : throw new ArgumentException("Non-IetfAttrSyntax encoding");
    foreach (Asn1Object element in seq)
    {
      int num;
      switch (element)
      {
        case DerObjectIdentifier _:
          num = 2;
          break;
        case DerUtf8String _:
          num = 3;
          break;
        case DerOctetString _:
          num = 1;
          break;
        default:
          throw new ArgumentException("Bad value type encoding IetfAttrSyntax");
      }
      if (this.valueChoice < 0)
        this.valueChoice = num;
      if (num != this.valueChoice)
        throw new ArgumentException("Mix of value types in IetfAttrSyntax");
      this.values.Add((Asn1Encodable) element);
    }
  }

  public GeneralNames PolicyAuthority => this.policyAuthority;

  public int ValueType => this.valueChoice;

  public object[] GetValues()
  {
    if (this.ValueType == 1)
    {
      Asn1OctetString[] values = new Asn1OctetString[this.values.Count];
      for (int index = 0; index != values.Length; ++index)
        values[index] = (Asn1OctetString) this.values[index];
      return (object[]) values;
    }
    if (this.ValueType == 2)
    {
      DerObjectIdentifier[] values = new DerObjectIdentifier[this.values.Count];
      for (int index = 0; index != values.Length; ++index)
        values[index] = (DerObjectIdentifier) this.values[index];
      return (object[]) values;
    }
    DerUtf8String[] values1 = new DerUtf8String[this.values.Count];
    for (int index = 0; index != values1.Length; ++index)
      values1[index] = (DerUtf8String) this.values[index];
    return (object[]) values1;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.policyAuthority);
    elementVector.Add((Asn1Encodable) new DerSequence(this.values));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
