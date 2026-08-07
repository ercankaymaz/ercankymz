// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.AttributeCertificateIssuer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Collections;
using System;

#nullable disable
namespace Org.BouncyCastle.X509;

public class AttributeCertificateIssuer : ISelector<X509Certificate>, ICloneable
{
  internal readonly Asn1Encodable form;

  public AttributeCertificateIssuer(AttCertIssuer issuer) => this.form = issuer.Issuer;

  public AttributeCertificateIssuer(X509Name principal)
  {
    this.form = (Asn1Encodable) new V2Form(new GeneralNames(new GeneralName(principal)));
  }

  private object[] GetNames()
  {
    GeneralName[] names1 = (!(this.form is V2Form) ? (GeneralNames) this.form : ((V2Form) this.form).IssuerName).GetNames();
    int length = 0;
    for (int index = 0; index != names1.Length; ++index)
    {
      if (names1[index].TagNo == 4)
        ++length;
    }
    object[] names2 = new object[length];
    int num = 0;
    for (int index = 0; index != names1.Length; ++index)
    {
      if (names1[index].TagNo == 4)
        names2[num++] = (object) X509Name.GetInstance((object) names1[index].Name);
    }
    return names2;
  }

  public X509Name[] GetPrincipals()
  {
    object[] names = this.GetNames();
    int length = 0;
    for (int index = 0; index != names.Length; ++index)
    {
      if (names[index] is X509Name)
        ++length;
    }
    X509Name[] principals = new X509Name[length];
    int num = 0;
    for (int index = 0; index != names.Length; ++index)
    {
      if (names[index] is X509Name)
        principals[num++] = (X509Name) names[index];
    }
    return principals;
  }

  private bool MatchesDN(X509Name subject, GeneralNames targets)
  {
    GeneralName[] names = targets.GetNames();
    for (int index = 0; index != names.Length; ++index)
    {
      GeneralName generalName = names[index];
      if (generalName.TagNo == 4)
      {
        try
        {
          if (X509Name.GetInstance((object) generalName.Name).Equivalent(subject))
            return true;
        }
        catch (Exception ex)
        {
        }
      }
    }
    return false;
  }

  public object Clone()
  {
    return (object) new AttributeCertificateIssuer(AttCertIssuer.GetInstance((object) this.form));
  }

  public bool Match(X509Certificate x509Cert)
  {
    if (x509Cert == null)
      return false;
    if (!(this.form is V2Form))
      return this.MatchesDN(x509Cert.SubjectDN, (GeneralNames) this.form);
    V2Form form = (V2Form) this.form;
    if (form.BaseCertificateID == null)
      return this.MatchesDN(x509Cert.SubjectDN, form.IssuerName);
    return form.BaseCertificateID.Serial.HasValue(x509Cert.SerialNumber) && this.MatchesDN(x509Cert.IssuerDN, form.BaseCertificateID.Issuer);
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is AttributeCertificateIssuer certificateIssuer && this.form.Equals((object) certificateIssuer.form);
  }

  public override int GetHashCode() => this.form.GetHashCode();
}
