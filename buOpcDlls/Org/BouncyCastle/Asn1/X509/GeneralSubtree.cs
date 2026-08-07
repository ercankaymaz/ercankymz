// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.GeneralSubtree
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class GeneralSubtree : Asn1Encodable
{
  private readonly GeneralName baseName;
  private readonly DerInteger minimum;
  private readonly DerInteger maximum;

  private GeneralSubtree(Asn1Sequence seq)
  {
    this.baseName = GeneralName.GetInstance((object) seq[0]);
    switch (seq.Count)
    {
      case 1:
        break;
      case 2:
        Asn1TaggedObject instance1 = Asn1TaggedObject.GetInstance((object) seq[1]);
        switch (instance1.TagNo)
        {
          case 0:
            this.minimum = DerInteger.GetInstance(instance1, false);
            return;
          case 1:
            this.maximum = DerInteger.GetInstance(instance1, false);
            return;
          default:
            throw new ArgumentException("Bad tag number: " + instance1.TagNo.ToString());
        }
      case 3:
        Asn1TaggedObject instance2 = Asn1TaggedObject.GetInstance((object) seq[1]);
        this.minimum = instance2.TagNo == 0 ? DerInteger.GetInstance(instance2, false) : throw new ArgumentException("Bad tag number for 'minimum': " + instance2.TagNo.ToString());
        Asn1TaggedObject instance3 = Asn1TaggedObject.GetInstance((object) seq[2]);
        this.maximum = instance3.TagNo == 1 ? DerInteger.GetInstance(instance3, false) : throw new ArgumentException("Bad tag number for 'maximum': " + instance3.TagNo.ToString());
        break;
      default:
        throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    }
  }

  public GeneralSubtree(GeneralName baseName, BigInteger minimum, BigInteger maximum)
  {
    this.baseName = baseName;
    if (minimum != null)
      this.minimum = new DerInteger(minimum);
    if (maximum == null)
      return;
    this.maximum = new DerInteger(maximum);
  }

  public GeneralSubtree(GeneralName baseName)
    : this(baseName, (BigInteger) null, (BigInteger) null)
  {
  }

  public static GeneralSubtree GetInstance(Asn1TaggedObject o, bool isExplicit)
  {
    return new GeneralSubtree(Asn1Sequence.GetInstance(o, isExplicit));
  }

  public static GeneralSubtree GetInstance(object obj)
  {
    if (obj == null)
      return (GeneralSubtree) null;
    return obj is GeneralSubtree ? (GeneralSubtree) obj : new GeneralSubtree(Asn1Sequence.GetInstance(obj));
  }

  public GeneralName Base => this.baseName;

  public BigInteger Minimum => this.minimum != null ? this.minimum.Value : BigInteger.Zero;

  public BigInteger Maximum => this.maximum != null ? this.maximum.Value : (BigInteger) null;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.baseName);
    if (this.minimum != null && !this.minimum.HasValue(0))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) this.minimum));
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.maximum);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
