// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixCertPathBuilder
{
  private Exception certPathException;

  public virtual PkixCertPathBuilderResult Build(PkixBuilderParameters pkixParams)
  {
    ISelector<X509Certificate> targetConstraintsCert = pkixParams.GetTargetConstraintsCert();
    HashSet<X509Certificate> matches = new HashSet<X509Certificate>();
    try
    {
      CollectionUtilities.CollectMatches<X509Certificate>((ICollection<X509Certificate>) matches, targetConstraintsCert, (IEnumerable<IStore<X509Certificate>>) pkixParams.GetStoresCert());
    }
    catch (Exception ex)
    {
      throw new PkixCertPathBuilderException("Error finding target certificate.", ex);
    }
    if (matches.Count < 1)
      throw new PkixCertPathBuilderException("No certificate found matching targetConstraints.");
    PkixCertPathBuilderResult pathBuilderResult = (PkixCertPathBuilderResult) null;
    List<X509Certificate> tbvPath = new List<X509Certificate>();
    foreach (X509Certificate tbvCert in matches)
    {
      pathBuilderResult = this.Build(tbvCert, pkixParams, (IList<X509Certificate>) tbvPath);
      if (pathBuilderResult != null)
        break;
    }
    if (pathBuilderResult == null && this.certPathException != null)
      throw new PkixCertPathBuilderException(this.certPathException.Message, this.certPathException.InnerException);
    return pathBuilderResult != null || this.certPathException != null ? pathBuilderResult : throw new PkixCertPathBuilderException("Unable to find certificate chain.");
  }

  protected virtual PkixCertPathBuilderResult Build(
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
    PkixCertPathValidator certPathValidator = new PkixCertPathValidator();
    try
    {
      if (PkixCertPathValidatorUtilities.IsIssuerTrustAnchor(tbvCert, pkixParams.GetTrustAnchors()))
      {
        PkixCertPath certPath;
        try
        {
          certPath = new PkixCertPath(tbvPath);
        }
        catch (Exception ex)
        {
          throw new Exception("Certification path could not be constructed from certificate list.", ex);
        }
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
        throw new Exception("No additiontal X.509 stores can be added from certificate locations.", (Exception) ex);
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
      foreach (X509Certificate tbvCert1 in (IEnumerable<X509Certificate>) issuerCerts)
      {
        pathBuilderResult = this.Build(tbvCert1, pkixParams, tbvPath);
        if (pathBuilderResult != null)
          break;
      }
    }
    catch (Exception ex)
    {
      this.certPathException = ex;
    }
    if (pathBuilderResult == null)
      tbvPath.Remove(tbvCert);
    return pathBuilderResult;
  }
}
