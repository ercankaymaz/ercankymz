// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.GeneralNames
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class GeneralNames : Asn1Encodable
{
  private readonly GeneralName[] m_names;

  public static GeneralNames GetInstance(object obj)
  {
    if (obj == null)
      return (GeneralNames) null;
    return obj is GeneralNames generalNames ? generalNames : new GeneralNames(Asn1Sequence.GetInstance(obj));
  }

  public static GeneralNames GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return GeneralNames.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static GeneralNames FromExtensions(X509Extensions extensions, DerObjectIdentifier extOid)
  {
    return GeneralNames.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, extOid));
  }

  private static GeneralName[] Copy(GeneralName[] names) => (GeneralName[]) names.Clone();

  public GeneralNames(GeneralName name)
  {
    this.m_names = new GeneralName[1]{ name };
  }

  public GeneralNames(GeneralName[] names) => this.m_names = GeneralNames.Copy(names);

  private GeneralNames(Asn1Sequence seq)
  {
    this.m_names = seq.MapElements<GeneralName>(new Func<Asn1Encodable, GeneralName>(GeneralName.GetInstance));
  }

  public GeneralName[] GetNames() => GeneralNames.Copy(this.m_names);

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable[]) this.m_names);
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("GeneralNames:");
    foreach (GeneralName name in this.m_names)
      stringBuilder.Append("    ").Append((object) name).AppendLine();
    return stringBuilder.ToString();
  }
}
