// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.TargetInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class TargetInformation : Asn1Encodable
{
  private readonly Asn1Sequence targets;

  public static TargetInformation GetInstance(object obj)
  {
    switch (obj)
    {
      case TargetInformation _:
        return (TargetInformation) obj;
      case Asn1Sequence _:
        return new TargetInformation((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private TargetInformation(Asn1Sequence targets) => this.targets = targets;

  public virtual Targets[] GetTargetsObjects()
  {
    Targets[] targetsObjects = new Targets[this.targets.Count];
    for (int index = 0; index < this.targets.Count; ++index)
      targetsObjects[index] = Targets.GetInstance((object) this.targets[index]);
    return targetsObjects;
  }

  public TargetInformation(Targets targets)
  {
    this.targets = (Asn1Sequence) new DerSequence((Asn1Encodable) targets);
  }

  public TargetInformation(Target[] targets)
    : this(new Targets(targets))
  {
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.targets;
}
