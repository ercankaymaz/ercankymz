// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Store.X509AttrCertStoreSelector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509.Store;

public class X509AttrCertStoreSelector : ISelector<X509V2AttributeCertificate>, ICloneable
{
  private X509V2AttributeCertificate attributeCert;
  private DateTime? attributeCertificateValid;
  private AttributeCertificateHolder holder;
  private AttributeCertificateIssuer issuer;
  private BigInteger serialNumber;
  private ISet<GeneralName> targetNames = (ISet<GeneralName>) new HashSet<GeneralName>();
  private ISet<GeneralName> targetGroups = (ISet<GeneralName>) new HashSet<GeneralName>();

  public X509AttrCertStoreSelector()
  {
  }

  private X509AttrCertStoreSelector(X509AttrCertStoreSelector o)
  {
    this.attributeCert = o.attributeCert;
    this.attributeCertificateValid = o.attributeCertificateValid;
    this.holder = o.holder;
    this.issuer = o.issuer;
    this.serialNumber = o.serialNumber;
    this.targetGroups = (ISet<GeneralName>) new HashSet<GeneralName>((IEnumerable<GeneralName>) o.targetGroups);
    this.targetNames = (ISet<GeneralName>) new HashSet<GeneralName>((IEnumerable<GeneralName>) o.targetNames);
  }

  public bool Match(X509V2AttributeCertificate attrCert)
  {
    if (attrCert == null || this.attributeCert != null && !this.attributeCert.Equals((object) attrCert) || this.serialNumber != null && !attrCert.SerialNumber.Equals(this.serialNumber) || this.holder != null && !attrCert.Holder.Equals((object) this.holder) || this.issuer != null && !attrCert.Issuer.Equals((object) this.issuer) || this.attributeCertificateValid.HasValue && !attrCert.IsValid(this.attributeCertificateValid.Value))
      return false;
    if (this.targetNames.Count > 0 || this.targetGroups.Count > 0)
    {
      Asn1OctetString extensionValue = attrCert.GetExtensionValue(X509Extensions.TargetInformation);
      if (extensionValue != null)
      {
        TargetInformation instance;
        try
        {
          instance = TargetInformation.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
        }
        catch (Exception ex)
        {
          return false;
        }
        Targets[] targetsObjects = instance.GetTargetsObjects();
        if (this.targetNames.Count > 0)
        {
          bool flag = false;
          for (int index = 0; index < targetsObjects.Length && !flag; ++index)
          {
            foreach (Target target in targetsObjects[index].GetTargets())
            {
              GeneralName targetName = target.TargetName;
              if (targetName != null && this.targetNames.Contains(targetName))
              {
                flag = true;
                break;
              }
            }
          }
          if (!flag)
            return false;
        }
        if (this.targetGroups.Count > 0)
        {
          bool flag = false;
          for (int index = 0; index < targetsObjects.Length && !flag; ++index)
          {
            foreach (Target target in targetsObjects[index].GetTargets())
            {
              GeneralName targetGroup = target.TargetGroup;
              if (targetGroup != null && this.targetGroups.Contains(targetGroup))
              {
                flag = true;
                break;
              }
            }
          }
          if (!flag)
            return false;
        }
      }
    }
    return true;
  }

  public object Clone() => (object) new X509AttrCertStoreSelector(this);

  public X509V2AttributeCertificate AttributeCert
  {
    get => this.attributeCert;
    set => this.attributeCert = value;
  }

  public DateTime? AttributeCertificateValid
  {
    get => this.attributeCertificateValid;
    set => this.attributeCertificateValid = value;
  }

  public AttributeCertificateHolder Holder
  {
    get => this.holder;
    set => this.holder = value;
  }

  public AttributeCertificateIssuer Issuer
  {
    get => this.issuer;
    set => this.issuer = value;
  }

  public BigInteger SerialNumber
  {
    get => this.serialNumber;
    set => this.serialNumber = value;
  }

  public void AddTargetName(GeneralName name) => this.targetNames.Add(name);

  public void AddTargetName(byte[] name)
  {
    this.AddTargetName(GeneralName.GetInstance((object) Asn1Object.FromByteArray(name)));
  }

  public void SetTargetNames(IEnumerable<object> names)
  {
    this.targetNames = this.ExtractGeneralNames(names);
  }

  public IEnumerable<GeneralName> GetTargetNames()
  {
    return CollectionUtilities.Proxy<GeneralName>((IEnumerable<GeneralName>) this.targetNames);
  }

  public void AddTargetGroup(GeneralName group) => this.targetGroups.Add(group);

  public void AddTargetGroup(byte[] name)
  {
    this.AddTargetGroup(GeneralName.GetInstance((object) Asn1Object.FromByteArray(name)));
  }

  public void SetTargetGroups(IEnumerable<object> names)
  {
    this.targetGroups = this.ExtractGeneralNames(names);
  }

  public IEnumerable<GeneralName> GetTargetGroups()
  {
    return CollectionUtilities.Proxy<GeneralName>((IEnumerable<GeneralName>) this.targetGroups);
  }

  private ISet<GeneralName> ExtractGeneralNames(IEnumerable<object> names)
  {
    HashSet<GeneralName> generalNames = new HashSet<GeneralName>();
    if (names != null)
    {
      foreach (object name in names)
        generalNames.Add(GeneralName.GetInstance(name));
    }
    return (ISet<GeneralName>) generalNames;
  }
}
