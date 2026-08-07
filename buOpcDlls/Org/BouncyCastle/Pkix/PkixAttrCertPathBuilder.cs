// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixAttrCertPathBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixAttrCertPathBuilder
{
  private Exception certPathException;

  public virtual PkixCertPathBuilderResult Build(PkixBuilderParameters pkixParams)
  {
    if (!(pkixParams.GetTargetConstraintsAttrCert() is X509AttrCertStoreSelector constraintsAttrCert))
      throw new PkixCertPathBuilderException($"TargetConstraints must be an instance of {typeof (X509AttrCertStoreSelector).FullName} for {typeof (PkixAttrCertPathBuilder).FullName} class.");
    HashSet<X509V2AttributeCertificate> attributeCertificates;
    try
    {
      attributeCertificates = PkixAttrCertPathBuilder.FindAttributeCertificates((ISelector<X509V2AttributeCertificate>) constraintsAttrCert, pkixParams.GetStoresAttrCert());
    }
    catch (Exception ex)
    {
      throw new PkixCertPathBuilderException("Error finding target attribute certificate.", ex);
    }
    if (attributeCertificates.Count == 0)
      throw new PkixCertPathBuilderException("No attribute certificate found matching targetConstraints.");
    PkixCertPathBuilderResult pathBuilderResult = (PkixCertPathBuilderResult) null;
    foreach (X509V2AttributeCertificate attrCert in attributeCertificates)
    {
      X509CertStoreSelector certStoreSelector = new X509CertStoreSelector();
      X509Name[] principals = attrCert.Issuer.GetPrincipals();
      HashSet<X509Certificate> matches = new HashSet<X509Certificate>();
      for (int index = 0; index < principals.Length; ++index)
      {
        try
        {
          certStoreSelector.Subject = principals[index];
          CollectionUtilities.CollectMatches<X509Certificate>((ICollection<X509Certificate>) matches, (ISelector<X509Certificate>) certStoreSelector, (IEnumerable<IStore<X509Certificate>>) pkixParams.GetStoresCert());
        }
        catch (Exception ex)
        {
          throw new PkixCertPathBuilderException("Public key certificate for attribute certificate cannot be searched.", ex);
        }
      }
      if (matches.Count < 1)
        throw new PkixCertPathBuilderException("Public key certificate for attribute certificate cannot be found.");
      List<X509Certificate> tbvPath = new List<X509Certificate>();
      foreach (X509Certificate tbvCert in matches)
      {
        pathBuilderResult = this.Build(attrCert, tbvCert, pkixParams, (IList<X509Certificate>) tbvPath);
        if (pathBuilderResult != null)
          break;
      }
      if (pathBuilderResult != null)
        break;
    }
    if (pathBuilderResult == null && this.certPathException != null)
      throw new PkixCertPathBuilderException("Possible certificate chain could not be validated.", this.certPathException);
    return pathBuilderResult != null || this.certPathException != null ? pathBuilderResult : throw new PkixCertPathBuilderException("Unable to find certificate chain.");
  }

  private PkixCertPathBuilderResult Build(
    X509V2AttributeCertificate attrCert,
    X509Certificate tbvCert,
    PkixBuilderParameters pkixParams,
    IList<X509Certificate> tbvPath)
  {
    if (tbvPath.Contains(tbvCert))
      return (PkixCertPathBuilderResult) null;
    if (pkixParams.GetExcludedCerts().Contains(tbvCert))
      return (PkixCertPathBuilderResult) null;
    if (pkixParams.MaxPathLength != -1 && tbvPath.Count - 1 > pkixParams.MaxPathLength)
      return (PkixCertPathBuilderResult) null;
    tbvPath.Add(tbvCert);
    PkixCertPathBuilderResult pathBuilderResult = (PkixCertPathBuilderResult) null;
    PkixAttrCertPathValidator certPathValidator = new PkixAttrCertPathValidator();
    try
    {
      if (PkixCertPathValidatorUtilities.IsIssuerTrustAnchor(tbvCert, pkixParams.GetTrustAnchors()))
      {
        PkixCertPath certPath = new PkixCertPath(tbvPath);
        PkixCertPathValidatorResult pathValidatorResult;
        try
        {
          pathValidatorResult = certPathValidator.Validate(certPath, (PkixParameters) pkixParams);
        }
        catch (Exception ex)
        {
          throw new Exception("Certification path could not be validated.", ex);
        }
        return new PkixCertPathBuilderResult(certPath, pathValidatorResult.TrustAnchor, pathValidatorResult.PolicyTree, pathValidatorResult.SubjectPublicKey);
      }
      try
      {
        PkixCertPathValidatorUtilities.AddAdditionalStoresFromAltNames(tbvCert, (PkixParameters) pkixParams);
      }
      catch (CertificateParsingException ex)
      {
        throw new Exception("No additional X.509 stores can be added from certificate locations.", (Exception) ex);
      }
      ISet<X509Certificate> issuerCerts;
      try
      {
        issuerCerts = (ISet<X509Certificate>) PkixCertPathValidatorUtilities.FindIssuerCerts(tbvCert, pkixParams);
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot find issuer certificate for certificate in certification path.", ex);
      }
      if (issuerCerts.Count < 1)
        throw new Exception("No issuer certificate for certificate in certification path found.");
      foreach (X509Certificate x509Certificate in (IEnumerable<X509Certificate>) issuerCerts)
      {
        if (!PkixCertPathValidatorUtilities.IsSelfIssued(x509Certificate))
        {
          pathBuilderResult = this.Build(attrCert, x509Certificate, pkixParams, tbvPath);
          if (pathBuilderResult != null)
            break;
        }
      }
    }
    catch (Exception ex)
    {
      this.certPathException = new Exception("No valid certification path could be build.", ex);
    }
    if (pathBuilderResult == null)
      tbvPath.Remove(tbvCert);
    return pathBuilderResult;
  }

  internal static HashSet<X509V2AttributeCertificate> FindAttributeCertificates(
    ISelector<X509V2AttributeCertificate> attrCertSelector,
    IList<IStore<X509V2AttributeCertificate>> attrCertStores)
  {
    HashSet<X509V2AttributeCertificate> attributeCertificates = new HashSet<X509V2AttributeCertificate>();
    foreach (IStore<X509V2AttributeCertificate> attrCertStore in (IEnumerable<IStore<X509V2AttributeCertificate>>) attrCertStores)
    {
      try
      {
        attributeCertificates.UnionWith(attrCertStore.EnumerateMatches(attrCertSelector));
      }
      catch (Exception ex)
      {
        throw new Exception("Problem while picking certificates from X.509 store.", ex);
      }
    }
    return attributeCertificates;
  }
}
