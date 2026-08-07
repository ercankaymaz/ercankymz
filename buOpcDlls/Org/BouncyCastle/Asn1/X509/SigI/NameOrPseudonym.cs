// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SigI.NameOrPseudonym
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.SigI;

public class NameOrPseudonym : Asn1Encodable, IAsn1Choice
{
  private readonly DirectoryString pseudonym;
  private readonly DirectoryString surname;
  private readonly Asn1Sequence givenName;

  public static NameOrPseudonym GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case NameOrPseudonym _:
        return (NameOrPseudonym) obj;
      case IAsn1String _:
        return new NameOrPseudonym(DirectoryString.GetInstance(obj));
      case Asn1Sequence _:
        return new NameOrPseudonym((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public NameOrPseudonym(DirectoryString pseudonym) => this.pseudonym = pseudonym;

  private NameOrPseudonym(Asn1Sequence seq)
  {
    if (seq.Count != 2)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.surname = seq[0] is IAsn1String ? DirectoryString.GetInstance((object) seq[0]) : throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) seq[0]));
    this.givenName = Asn1Sequence.GetInstance((object) seq[1]);
  }

  public NameOrPseudonym(string pseudonym)
    : this(new DirectoryString(pseudonym))
  {
  }

  public NameOrPseudonym(DirectoryString surname, Asn1Sequence givenName)
  {
    this.surname = surname;
    this.givenName = givenName;
  }

  public DirectoryString Pseudonym => this.pseudonym;

  public DirectoryString Surname => this.surname;

  public DirectoryString[] GetGivenName()
  {
    DirectoryString[] givenName = new DirectoryString[this.givenName.Count];
    int num = 0;
    foreach (object obj in this.givenName)
      givenName[num++] = DirectoryString.GetInstance(obj);
    return givenName;
  }

  public override Asn1Object ToAsn1Object()
  {
    return this.pseudonym != null ? this.pseudonym.ToAsn1Object() : (Asn1Object) new DerSequence((Asn1Encodable) this.surname, (Asn1Encodable) this.givenName);
  }
}
