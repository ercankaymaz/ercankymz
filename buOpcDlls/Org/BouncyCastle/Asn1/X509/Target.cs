// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Target
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class Target : Asn1Encodable, IAsn1Choice
{
  private readonly GeneralName targetName;
  private readonly GeneralName targetGroup;

  public static Target GetInstance(object obj)
  {
    switch (obj)
    {
      case Target _:
        return (Target) obj;
      case Asn1TaggedObject _:
        return new Target((Asn1TaggedObject) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private Target(Asn1TaggedObject tagObj)
  {
    switch ((Target.Choice) tagObj.TagNo)
    {
      case Target.Choice.Name:
        this.targetName = GeneralName.GetInstance(tagObj, true);
        break;
      case Target.Choice.Group:
        this.targetGroup = GeneralName.GetInstance(tagObj, true);
        break;
      default:
        throw new ArgumentException("unknown tag: " + tagObj.TagNo.ToString());
    }
  }

  public Target(Target.Choice type, GeneralName name)
    : this((Asn1TaggedObject) new DerTaggedObject((int) type, (Asn1Encodable) name))
  {
  }

  public virtual GeneralName TargetGroup => this.targetGroup;

  public virtual GeneralName TargetName => this.targetName;

  public override Asn1Object ToAsn1Object()
  {
    return this.targetName != null ? (Asn1Object) new DerTaggedObject(true, 0, (Asn1Encodable) this.targetName) : (Asn1Object) new DerTaggedObject(true, 1, (Asn1Encodable) this.targetGroup);
  }

  public enum Choice
  {
    Name,
    Group,
  }
}
