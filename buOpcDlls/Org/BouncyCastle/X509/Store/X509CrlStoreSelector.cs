// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Store.X509CrlStoreSelector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509.Store;

public class X509CrlStoreSelector : ISelector<X509Crl>, ICloneable
{
  private X509Certificate certificateChecking;
  private DateTime? dateAndTime;
  private IList<X509Name> issuers;
  private BigInteger maxCrlNumber;
  private BigInteger minCrlNumber;
  private X509V2AttributeCertificate attrCertChecking;
  private bool completeCrlEnabled;
  private bool deltaCrlIndicatorEnabled;
  private byte[] issuingDistributionPoint;
  private bool issuingDistributionPointEnabled;
  private BigInteger maxBaseCrlNumber;

  public X509CrlStoreSelector()
  {
  }

  public X509CrlStoreSelector(X509CrlStoreSelector o)
  {
    this.certificateChecking = o.CertificateChecking;
    this.dateAndTime = o.DateAndTime;
    this.issuers = o.Issuers;
    this.maxCrlNumber = o.MaxCrlNumber;
    this.minCrlNumber = o.MinCrlNumber;
    this.deltaCrlIndicatorEnabled = o.DeltaCrlIndicatorEnabled;
    this.completeCrlEnabled = o.CompleteCrlEnabled;
    this.maxBaseCrlNumber = o.MaxBaseCrlNumber;
    this.attrCertChecking = o.AttrCertChecking;
    this.issuingDistributionPointEnabled = o.IssuingDistributionPointEnabled;
    this.issuingDistributionPoint = o.IssuingDistributionPoint;
  }

  public virtual object Clone() => (object) new X509CrlStoreSelector(this);

  public X509Certificate CertificateChecking
  {
    get => this.certificateChecking;
    set => this.certificateChecking = value;
  }

  public DateTime? DateAndTime
  {
    get => this.dateAndTime;
    set => this.dateAndTime = value;
  }

  public IList<X509Name> Issuers
  {
    get => (IList<X509Name>) new List<X509Name>((IEnumerable<X509Name>) this.issuers);
    set => this.issuers = (IList<X509Name>) new List<X509Name>((IEnumerable<X509Name>) value);
  }

  public BigInteger MaxCrlNumber
  {
    get => this.maxCrlNumber;
    set => this.maxCrlNumber = value;
  }

  public BigInteger MinCrlNumber
  {
    get => this.minCrlNumber;
    set => this.minCrlNumber = value;
  }

  public X509V2AttributeCertificate AttrCertChecking
  {
    get => this.attrCertChecking;
    set => this.attrCertChecking = value;
  }

  public bool CompleteCrlEnabled
  {
    get => this.completeCrlEnabled;
    set => this.completeCrlEnabled = value;
  }

  public bool DeltaCrlIndicatorEnabled
  {
    get => this.deltaCrlIndicatorEnabled;
    set => this.deltaCrlIndicatorEnabled = value;
  }

  public byte[] IssuingDistributionPoint
  {
    get => Arrays.Clone(this.issuingDistributionPoint);
    set => this.issuingDistributionPoint = Arrays.Clone(value);
  }

  public bool IssuingDistributionPointEnabled
  {
    get => this.issuingDistributionPointEnabled;
    set => this.issuingDistributionPointEnabled = value;
  }

  public BigInteger MaxBaseCrlNumber
  {
    get => this.maxBaseCrlNumber;
    set => this.maxBaseCrlNumber = value;
  }

  public virtual bool Match(X509Crl c)
  {
    if (c == null)
      return false;
    if (this.dateAndTime.HasValue)
    {
      DateTime dateTime = this.dateAndTime.Value;
      DateTime thisUpdate = c.ThisUpdate;
      DateTime? nextUpdate = c.NextUpdate;
      if (dateTime.CompareTo(thisUpdate) < 0 || !nextUpdate.HasValue || dateTime.CompareTo(nextUpdate.Value) >= 0)
        return false;
    }
    if (this.issuers != null)
    {
      X509Name issuerDn = c.IssuerDN;
      bool flag = false;
      foreach (X509Name issuer in (IEnumerable<X509Name>) this.issuers)
      {
        if (issuer.Equivalent(issuerDn, true))
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return false;
    }
    if (this.maxCrlNumber != null || this.minCrlNumber != null)
    {
      Asn1OctetString extensionValue = c.GetExtensionValue(X509Extensions.CrlNumber);
      if (extensionValue == null)
        return false;
      BigInteger positiveValue = DerInteger.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue)).PositiveValue;
      if (this.maxCrlNumber != null && positiveValue.CompareTo(this.maxCrlNumber) > 0 || this.minCrlNumber != null && positiveValue.CompareTo(this.minCrlNumber) < 0)
        return false;
    }
    DerInteger derInteger = (DerInteger) null;
    try
    {
      Asn1OctetString extensionValue = c.GetExtensionValue(X509Extensions.DeltaCrlIndicator);
      if (extensionValue != null)
        derInteger = DerInteger.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
    }
    catch (Exception ex)
    {
      return false;
    }
    if (derInteger == null)
    {
      if (this.DeltaCrlIndicatorEnabled)
        return false;
    }
    else if (this.CompleteCrlEnabled || this.maxBaseCrlNumber != null && derInteger.PositiveValue.CompareTo(this.maxBaseCrlNumber) > 0)
      return false;
    if (this.issuingDistributionPointEnabled)
    {
      Asn1OctetString extensionValue = c.GetExtensionValue(X509Extensions.IssuingDistributionPoint);
      if (this.issuingDistributionPoint == null)
      {
        if (extensionValue != null)
          return false;
      }
      else if (!Arrays.AreEqual(extensionValue.GetOctets(), this.issuingDistributionPoint))
        return false;
    }
    return true;
  }
}
