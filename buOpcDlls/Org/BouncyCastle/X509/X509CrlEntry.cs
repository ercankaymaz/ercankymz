// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509CrlEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Utilities;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509CrlEntry : X509ExtensionBase
{
  private CrlEntry c;
  private bool isIndirect;
  private X509Name previousCertificateIssuer;
  private X509Name certificateIssuer;
  private volatile bool hashValueSet;
  private volatile int hashValue;

  public X509CrlEntry(CrlEntry c)
  {
    this.c = c;
    this.certificateIssuer = this.loadCertificateIssuer();
  }

  public X509CrlEntry(CrlEntry c, bool isIndirect, X509Name previousCertificateIssuer)
  {
    this.c = c;
    this.isIndirect = isIndirect;
    this.previousCertificateIssuer = previousCertificateIssuer;
    this.certificateIssuer = this.loadCertificateIssuer();
  }

  private X509Name loadCertificateIssuer()
  {
    if (!this.isIndirect)
      return (X509Name) null;
    Asn1OctetString extensionValue = this.GetExtensionValue(X509Extensions.CertificateIssuer);
    if (extensionValue == null)
      return this.previousCertificateIssuer;
    try
    {
      GeneralName[] names = GeneralNames.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue)).GetNames();
      for (int index = 0; index < names.Length; ++index)
      {
        if (names[index].TagNo == 4)
          return X509Name.GetInstance((object) names[index].Name);
      }
    }
    catch (Exception ex)
    {
    }
    return (X509Name) null;
  }

  public X509Name GetCertificateIssuer() => this.certificateIssuer;

  protected override X509Extensions GetX509Extensions() => this.c.Extensions;

  public byte[] GetEncoded()
  {
    try
    {
      return this.c.GetDerEncoded();
    }
    catch (Exception ex)
    {
      throw new CrlException(ex.ToString());
    }
  }

  public BigInteger SerialNumber => this.c.UserCertificate.Value;

  public DateTime RevocationDate => this.c.RevocationDate.ToDateTime();

  public bool HasExtensions => this.c.Extensions != null;

  public override bool Equals(object other)
  {
    if (this == other)
      return true;
    return other is X509CrlEntry x509CrlEntry && (!this.hashValueSet || !x509CrlEntry.hashValueSet || this.hashValue == x509CrlEntry.hashValue) && this.c.Equals((object) x509CrlEntry.c);
  }

  public override int GetHashCode()
  {
    if (!this.hashValueSet)
    {
      this.hashValue = this.c.GetHashCode();
      this.hashValueSet = true;
    }
    return this.hashValue;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("        userCertificate: ").Append((object) this.SerialNumber).AppendLine();
    stringBuilder.Append("         revocationDate: ").Append((object) this.RevocationDate).AppendLine();
    stringBuilder.Append("      certificateIssuer: ").Append((object) this.GetCertificateIssuer()).AppendLine();
    X509Extensions extensions = this.c.Extensions;
    if (extensions != null)
    {
      IEnumerator<DerObjectIdentifier> enumerator = extensions.ExtensionOids.GetEnumerator();
      if (enumerator.MoveNext())
      {
        stringBuilder.AppendLine("   crlEntryExtensions:");
        do
        {
          DerObjectIdentifier current = enumerator.Current;
          X509Extension extension = extensions.GetExtension(current);
          if (extension.Value == null)
          {
            stringBuilder.AppendLine();
          }
          else
          {
            Asn1Object asn1Object = X509ExtensionUtilities.FromExtensionValue(extension.Value);
            stringBuilder.Append("                       critical(").Append(extension.IsCritical).Append(") ");
            try
            {
              if (current.Equals((Asn1Object) X509Extensions.ReasonCode))
                stringBuilder.Append((object) new CrlReason(DerEnumerated.GetInstance((object) asn1Object)));
              else if (current.Equals((Asn1Object) X509Extensions.CertificateIssuer))
              {
                stringBuilder.Append("Certificate issuer: ").Append((object) GeneralNames.GetInstance((object) (Asn1Sequence) asn1Object));
              }
              else
              {
                stringBuilder.Append(current.Id);
                stringBuilder.Append(" value = ").Append(Asn1Dump.DumpAsString((Asn1Encodable) asn1Object));
              }
              stringBuilder.AppendLine();
            }
            catch (Exception ex)
            {
              stringBuilder.Append(current.Id);
              stringBuilder.Append(" value = ").Append("*****").AppendLine();
            }
          }
        }
        while (enumerator.MoveNext());
      }
    }
    return stringBuilder.ToString();
  }
}
