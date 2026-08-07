// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.Rfc3281CertPathUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

internal static class Rfc3281CertPathUtilities
{
  internal static void ProcessAttrCert7(
    X509V2AttributeCertificate attrCert,
    PkixCertPath certPath,
    PkixCertPath holderCertPath,
    PkixParameters pkixParams)
  {
    ISet<string> criticalExtensionOids = attrCert.GetCriticalExtensionOids();
    if (criticalExtensionOids.Contains(X509Extensions.TargetInformation.Id))
    {
      try
      {
        TargetInformation.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) attrCert, X509Extensions.TargetInformation));
      }
      catch (Exception ex)
      {
        throw new PkixCertPathValidatorException("Target information extension could not be read.", ex);
      }
    }
    criticalExtensionOids.Remove(X509Extensions.TargetInformation.Id);
    foreach (PkixAttrCertChecker attrCertChecker in (IEnumerable<PkixAttrCertChecker>) pkixParams.GetAttrCertCheckers())
      attrCertChecker.Check(attrCert, certPath, holderCertPath, (ICollection<string>) criticalExtensionOids);
    if (criticalExtensionOids.Count > 0)
      throw new PkixCertPathValidatorException("Attribute certificate contains unsupported critical extensions: " + criticalExtensionOids?.ToString());
  }

  internal static void CheckCrls(
    X509V2AttributeCertificate attrCert,
    PkixParameters paramsPKIX,
    X509Certificate issuerCert,
    DateTime validDate,
    IList<X509Certificate> certPathCerts)
  {
    if (!paramsPKIX.IsRevocationEnabled)
      return;
    if (attrCert.GetExtensionValue(X509Extensions.NoRevAvail) != null)
    {
      if (attrCert.GetExtensionValue(X509Extensions.CrlDistributionPoints) != null || attrCert.GetExtensionValue(X509Extensions.AuthorityInfoAccess) != null)
        throw new PkixCertPathValidatorException("No rev avail extension is set, but also an AC revocation pointer.");
    }
    else
    {
      CrlDistPoint instance1;
      try
      {
        instance1 = CrlDistPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) attrCert, X509Extensions.CrlDistributionPoints));
      }
      catch (Exception ex)
      {
        throw new PkixCertPathValidatorException("CRL distribution point extension could not be read.", ex);
      }
      try
      {
        PkixCertPathValidatorUtilities.AddAdditionalStoresFromCrlDistributionPoint(instance1, paramsPKIX);
      }
      catch (Exception ex)
      {
        throw new PkixCertPathValidatorException("No additional CRL locations could be decoded from CRL distribution point extension.", ex);
      }
      CertStatus certStatus1 = new CertStatus();
      ReasonsMask reasonMask1 = new ReasonsMask();
      Exception innerException = (Exception) null;
      bool flag = false;
      if (instance1 != null)
      {
        DistributionPoint[] distributionPoints;
        try
        {
          distributionPoints = instance1.GetDistributionPoints();
        }
        catch (Exception ex)
        {
          throw new PkixCertPathValidatorException("Distribution points could not be read.", ex);
        }
        try
        {
          for (int index = 0; index < distributionPoints.Length; ++index)
          {
            if (certStatus1.Status == 11)
            {
              if (!reasonMask1.IsAllReasons)
              {
                PkixParameters paramsPKIX1 = (PkixParameters) paramsPKIX.Clone();
                Rfc3281CertPathUtilities.CheckCrl(distributionPoints[index], attrCert, paramsPKIX1, validDate, issuerCert, certStatus1, reasonMask1, certPathCerts);
                flag = true;
              }
              else
                break;
            }
            else
              break;
          }
        }
        catch (Exception ex)
        {
          innerException = new Exception("No valid CRL for distribution point found.", ex);
        }
      }
      if (certStatus1.Status == 11)
      {
        if (!reasonMask1.IsAllReasons)
        {
          try
          {
            X509Name instance2;
            try
            {
              instance2 = X509Name.GetInstance((object) attrCert.Issuer.GetPrincipals()[0].GetEncoded());
            }
            catch (Exception ex)
            {
              throw new Exception("Issuer from certificate for CRL could not be reencoded.", ex);
            }
            DistributionPoint dp = new DistributionPoint(new DistributionPointName(0, (Asn1Encodable) new GeneralNames(new GeneralName(4, (Asn1Encodable) instance2))), (ReasonFlags) null, (GeneralNames) null);
            PkixParameters pkixParameters = (PkixParameters) paramsPKIX.Clone();
            X509V2AttributeCertificate attrCert1 = attrCert;
            PkixParameters paramsPKIX2 = pkixParameters;
            DateTime validDate1 = validDate;
            X509Certificate issuerCert1 = issuerCert;
            CertStatus certStatus2 = certStatus1;
            ReasonsMask reasonMask2 = reasonMask1;
            IList<X509Certificate> certPathCerts1 = certPathCerts;
            Rfc3281CertPathUtilities.CheckCrl(dp, attrCert1, paramsPKIX2, validDate1, issuerCert1, certStatus2, reasonMask2, certPathCerts1);
            flag = true;
          }
          catch (Exception ex)
          {
            innerException = new Exception("No valid CRL for distribution point found.", ex);
          }
        }
      }
      if (!flag)
        throw new PkixCertPathValidatorException("No valid CRL found.", innerException);
      if (certStatus1.Status != 11)
        throw new PkixCertPathValidatorException($"Attribute certificate revocation after {certStatus1.RevocationDate.Value.ToString("ddd MMM dd HH:mm:ss K yyyy")}, reason: {Rfc3280CertPathUtilities.CrlReasons[certStatus1.Status]}");
      if (!reasonMask1.IsAllReasons && certStatus1.Status == 11)
        certStatus1.Status = 12;
      if (certStatus1.Status == 12)
        throw new PkixCertPathValidatorException("Attribute certificate status could not be determined.");
    }
  }

  internal static void AdditionalChecks(
    X509V2AttributeCertificate attrCert,
    PkixParameters pkixParams)
  {
    foreach (string prohibitedAcAttribute in (IEnumerable<string>) pkixParams.GetProhibitedACAttributes())
    {
      if (attrCert.GetAttributes(prohibitedAcAttribute) != null)
        throw new PkixCertPathValidatorException($"Attribute certificate contains prohibited attribute: {prohibitedAcAttribute}.");
    }
    foreach (string necessaryAcAttribute in (IEnumerable<string>) pkixParams.GetNecessaryACAttributes())
    {
      if (attrCert.GetAttributes(necessaryAcAttribute) == null)
        throw new PkixCertPathValidatorException($"Attribute certificate does not contain necessary attribute: {necessaryAcAttribute}.");
    }
  }

  internal static void ProcessAttrCert5(
    X509V2AttributeCertificate attrCert,
    PkixParameters pkixParams)
  {
    try
    {
      attrCert.CheckValidity(PkixCertPathValidatorUtilities.GetValidDate(pkixParams));
    }
    catch (CertificateExpiredException ex)
    {
      throw new PkixCertPathValidatorException("Attribute certificate is not valid.", (Exception) ex);
    }
    catch (CertificateNotYetValidException ex)
    {
      throw new PkixCertPathValidatorException("Attribute certificate is not valid.", (Exception) ex);
    }
  }

  internal static void ProcessAttrCert4(X509Certificate acIssuerCert, PkixParameters pkixParams)
  {
    foreach (TrustAnchor trustedAcIssuer in (IEnumerable<TrustAnchor>) pkixParams.GetTrustedACIssuers())
    {
      IDictionary<DerObjectIdentifier, string> rfC2253Symbols = X509Name.RFC2253Symbols;
      if (acIssuerCert.SubjectDN.ToString(false, rfC2253Symbols).Equals(trustedAcIssuer.CAName) || acIssuerCert.Equals((object) trustedAcIssuer.TrustedCert))
        return;
    }
    throw new PkixCertPathValidatorException("Attribute certificate issuer is not directly trusted.");
  }

  internal static void ProcessAttrCert3(X509Certificate acIssuerCert, PkixParameters pkixParams)
  {
    if (acIssuerCert.GetKeyUsage() != null && !acIssuerCert.GetKeyUsage()[0] && !acIssuerCert.GetKeyUsage()[1])
      throw new PkixCertPathValidatorException("Attribute certificate issuer public key cannot be used to validate digital signatures.");
    if (acIssuerCert.GetBasicConstraints() != -1)
      throw new PkixCertPathValidatorException("Attribute certificate issuer is also a public key certificate issuer.");
  }

  internal static PkixCertPathValidatorResult ProcessAttrCert2(
    PkixCertPath certPath,
    PkixParameters pkixParams)
  {
    PkixCertPathValidator certPathValidator = new PkixCertPathValidator();
    try
    {
      return certPathValidator.Validate(certPath, pkixParams);
    }
    catch (PkixCertPathValidatorException ex)
    {
      throw new PkixCertPathValidatorException("Certification path for issuer certificate of attribute certificate could not be validated.", (Exception) ex);
    }
  }

  internal static PkixCertPath ProcessAttrCert1(
    X509V2AttributeCertificate attrCert,
    PkixParameters pkixParams)
  {
    PkixCertPathBuilderResult pathBuilderResult = (PkixCertPathBuilderResult) null;
    HashSet<X509Certificate> matches = new HashSet<X509Certificate>();
    if (attrCert.Holder.GetIssuer() != null)
    {
      X509CertStoreSelector certStoreSelector = new X509CertStoreSelector();
      certStoreSelector.SerialNumber = attrCert.Holder.SerialNumber;
      foreach (X509Name x509Name in attrCert.Holder.GetIssuer())
      {
        try
        {
          certStoreSelector.Issuer = x509Name;
          CollectionUtilities.CollectMatches<X509Certificate>((ICollection<X509Certificate>) matches, (ISelector<X509Certificate>) certStoreSelector, (IEnumerable<IStore<X509Certificate>>) pkixParams.GetStoresCert());
        }
        catch (Exception ex)
        {
          throw new PkixCertPathValidatorException("Public key certificate for attribute certificate cannot be searched.", ex);
        }
      }
      if (matches.Count < 1)
        throw new PkixCertPathValidatorException("Public key certificate specified in base certificate ID for attribute certificate cannot be found.");
    }
    if (attrCert.Holder.GetEntityNames() != null)
    {
      X509CertStoreSelector certStoreSelector = new X509CertStoreSelector();
      foreach (X509Name entityName in attrCert.Holder.GetEntityNames())
      {
        try
        {
          certStoreSelector.Issuer = entityName;
          CollectionUtilities.CollectMatches<X509Certificate>((ICollection<X509Certificate>) matches, (ISelector<X509Certificate>) certStoreSelector, (IEnumerable<IStore<X509Certificate>>) pkixParams.GetStoresCert());
        }
        catch (Exception ex)
        {
          throw new PkixCertPathValidatorException("Public key certificate for attribute certificate cannot be searched.", ex);
        }
      }
      if (matches.Count < 1)
        throw new PkixCertPathValidatorException("Public key certificate specified in entity name for attribute certificate cannot be found.");
    }
    PkixBuilderParameters instance = PkixBuilderParameters.GetInstance(pkixParams);
    PkixCertPathValidatorException validatorException = (PkixCertPathValidatorException) null;
    foreach (X509Certificate x509Certificate in matches)
    {
      instance.SetTargetConstraintsCert((ISelector<X509Certificate>) new X509CertStoreSelector()
      {
        Certificate = x509Certificate
      });
      PkixCertPathBuilder pkixCertPathBuilder = new PkixCertPathBuilder();
      try
      {
        pathBuilderResult = pkixCertPathBuilder.Build(instance);
      }
      catch (PkixCertPathBuilderException ex)
      {
        validatorException = new PkixCertPathValidatorException("Certification path for public key certificate of attribute certificate could not be build.", (Exception) ex);
      }
    }
    if (validatorException != null)
      throw validatorException;
    return pathBuilderResult.CertPath;
  }

  private static void CheckCrl(
    DistributionPoint dp,
    X509V2AttributeCertificate attrCert,
    PkixParameters paramsPKIX,
    DateTime validDate,
    X509Certificate issuerCert,
    CertStatus certStatus,
    ReasonsMask reasonMask,
    IList<X509Certificate> certPathCerts)
  {
    if (attrCert.GetExtensionValue(X509Extensions.NoRevAvail) != null)
      return;
    DateTime utcNow = DateTime.UtcNow;
    if (validDate.CompareTo(utcNow) > 0)
      throw new Exception("Validation time is in future.");
    ISet<X509Crl> completeCrls = PkixCertPathValidatorUtilities.GetCompleteCrls(dp, (object) attrCert, utcNow, paramsPKIX);
    bool flag = false;
    Exception exception = (Exception) null;
    IEnumerator<X509Crl> enumerator = completeCrls.GetEnumerator();
    while (enumerator.MoveNext() && certStatus.Status == 11)
    {
      if (!reasonMask.IsAllReasons)
      {
        try
        {
          X509Crl current = enumerator.Current;
          ReasonsMask mask = Rfc3280CertPathUtilities.ProcessCrlD(current, dp);
          if (mask.HasNewReasons(reasonMask))
          {
            HashSet<AsymmetricKeyParameter> keys = Rfc3280CertPathUtilities.ProcessCrlF(current, (object) attrCert, (X509Certificate) null, (AsymmetricKeyParameter) null, paramsPKIX, certPathCerts);
            AsymmetricKeyParameter key = Rfc3280CertPathUtilities.ProcessCrlG(current, keys);
            X509Crl x509Crl = (X509Crl) null;
            if (paramsPKIX.IsUseDeltasEnabled)
              x509Crl = Rfc3280CertPathUtilities.ProcessCrlH(PkixCertPathValidatorUtilities.GetDeltaCrls(utcNow, paramsPKIX, current), key);
            if (paramsPKIX.ValidityModel != 1 && attrCert.NotAfter.CompareTo(current.ThisUpdate) < 0)
              throw new Exception("No valid CRL for current time found.");
            Rfc3280CertPathUtilities.ProcessCrlB1(dp, (object) attrCert, current);
            Rfc3280CertPathUtilities.ProcessCrlB2(dp, (object) attrCert, current);
            Rfc3280CertPathUtilities.ProcessCrlC(x509Crl, current, paramsPKIX);
            Rfc3280CertPathUtilities.ProcessCrlI(validDate, x509Crl, (object) attrCert, certStatus, paramsPKIX);
            Rfc3280CertPathUtilities.ProcessCrlJ(validDate, current, (object) attrCert, certStatus);
            if (certStatus.Status == 8)
              certStatus.Status = 11;
            reasonMask.AddReasons(mask);
            flag = true;
          }
        }
        catch (Exception ex)
        {
          exception = ex;
        }
      }
      else
        break;
    }
    if (!flag)
      throw exception;
  }
}
