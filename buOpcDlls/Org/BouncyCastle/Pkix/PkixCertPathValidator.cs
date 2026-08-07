// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixCertPathValidator
{
  public virtual PkixCertPathValidatorResult Validate(
    PkixCertPath certPath,
    PkixParameters paramsPkix)
  {
    if (paramsPkix.GetTrustAnchors() == null)
      throw new ArgumentException("trustAnchors is null, this is not allowed for certification path validation.", nameof (paramsPkix));
    IList<X509Certificate> certificates = certPath.Certificates;
    int count = certificates.Count;
    if (count == 0)
      throw new PkixCertPathValidatorException("Certification path is empty.", (Exception) null, 0);
    ISet<string> initialPolicies = paramsPkix.GetInitialPolicies();
    TrustAnchor trustAnchor;
    try
    {
      trustAnchor = PkixCertPathValidatorUtilities.FindTrustAnchor(certificates[certificates.Count - 1], paramsPkix.GetTrustAnchors());
      if (trustAnchor == null)
        throw new PkixCertPathValidatorException("Trust anchor for certification path not found.", (Exception) null, -1);
      PkixCertPathValidator.CheckCertificate(trustAnchor.TrustedCert);
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException(ex.Message, ex.InnerException, certificates.Count - 1);
    }
    List<PkixPolicyNode>[] policyNodes = new List<PkixPolicyNode>[count + 1];
    for (int index = 0; index < policyNodes.Length; ++index)
      policyNodes[index] = new List<PkixPolicyNode>();
    PkixPolicyNode validPolicyTree1 = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), 0, (ISet<string>) new HashSet<string>()
    {
      Rfc3280CertPathUtilities.ANY_POLICY
    }, (PkixPolicyNode) null, (ISet<PolicyQualifierInfo>) new HashSet<PolicyQualifierInfo>(), Rfc3280CertPathUtilities.ANY_POLICY, false);
    policyNodes[0].Add(validPolicyTree1);
    PkixNameConstraintValidator nameConstraintValidator = new PkixNameConstraintValidator();
    HashSet<string> acceptablePolicies = new HashSet<string>();
    int explicitPolicy1 = !paramsPkix.IsExplicitPolicyRequired ? count + 1 : 0;
    int inhibitAnyPolicy1 = !paramsPkix.IsAnyPolicyInhibited ? count + 1 : 0;
    int policyMapping1 = !paramsPkix.IsPolicyMappingInhibited ? count + 1 : 0;
    X509Certificate sign = trustAnchor.TrustedCert;
    X509Name workingIssuerName;
    AsymmetricKeyParameter asymmetricKeyParameter;
    try
    {
      if (sign != null)
      {
        workingIssuerName = sign.SubjectDN;
        asymmetricKeyParameter = sign.GetPublicKey();
      }
      else
      {
        workingIssuerName = new X509Name(trustAnchor.CAName);
        asymmetricKeyParameter = trustAnchor.CAPublicKey;
      }
    }
    catch (ArgumentException ex)
    {
      throw new PkixCertPathValidatorException("Subject of trust anchor could not be (re)encoded.", (Exception) ex, -1);
    }
    try
    {
      PkixCertPathValidatorUtilities.GetAlgorithmIdentifier(asymmetricKeyParameter);
    }
    catch (PkixCertPathValidatorException ex)
    {
      throw new PkixCertPathValidatorException("Algorithm identifier of public key of trust anchor could not be read.", (Exception) ex, -1);
    }
    int maxPathLength1 = count;
    ISelector<X509Certificate> targetConstraintsCert = paramsPkix.GetTargetConstraintsCert();
    if (targetConstraintsCert != null && !targetConstraintsCert.Match(certificates[0]))
      throw new PkixCertPathValidatorException("Target certificate in certification path does not match targetConstraints.", (Exception) null, 0);
    IList<PkixCertPathChecker> certPathCheckers = paramsPkix.GetCertPathCheckers();
    foreach (PkixCertPathChecker pkixCertPathChecker in (IEnumerable<PkixCertPathChecker>) certPathCheckers)
      pkixCertPathChecker.Init(false);
    X509Certificate cert = (X509Certificate) null;
    int index1;
    for (index1 = certificates.Count - 1; index1 >= 0; --index1)
    {
      int num = count - index1;
      cert = certificates[index1];
      try
      {
        PkixCertPathValidator.CheckCertificate(cert);
      }
      catch (Exception ex)
      {
        throw new PkixCertPathValidatorException(ex.Message, ex.InnerException, index1);
      }
      Rfc3280CertPathUtilities.ProcessCertA(certPath, paramsPkix, index1, asymmetricKeyParameter, workingIssuerName, sign);
      Rfc3280CertPathUtilities.ProcessCertBC(certPath, index1, nameConstraintValidator);
      PkixPolicyNode validPolicyTree2 = Rfc3280CertPathUtilities.ProcessCertD(certPath, index1, acceptablePolicies, validPolicyTree1, (IList<PkixPolicyNode>[]) policyNodes, inhibitAnyPolicy1);
      validPolicyTree1 = Rfc3280CertPathUtilities.ProcessCertE(certPath, index1, validPolicyTree2);
      Rfc3280CertPathUtilities.ProcessCertF(certPath, index1, validPolicyTree1, explicitPolicy1);
      if (num != count)
      {
        if (cert != null && cert.Version == 1)
        {
          if (num != 1 || !cert.Equals((object) trustAnchor.TrustedCert))
            throw new PkixCertPathValidatorException("Version 1 certificates can't be used as CA ones.", (Exception) null, index1);
        }
        else
        {
          Rfc3280CertPathUtilities.PrepareNextCertA(certPath, index1);
          validPolicyTree1 = Rfc3280CertPathUtilities.PrepareCertB(certPath, index1, (IList<PkixPolicyNode>[]) policyNodes, validPolicyTree1, policyMapping1);
          Rfc3280CertPathUtilities.PrepareNextCertG(certPath, index1, nameConstraintValidator);
          int explicitPolicy2 = Rfc3280CertPathUtilities.PrepareNextCertH1(certPath, index1, explicitPolicy1);
          int policyMapping2 = Rfc3280CertPathUtilities.PrepareNextCertH2(certPath, index1, policyMapping1);
          int inhibitAnyPolicy2 = Rfc3280CertPathUtilities.PrepareNextCertH3(certPath, index1, inhibitAnyPolicy1);
          explicitPolicy1 = Rfc3280CertPathUtilities.PrepareNextCertI1(certPath, index1, explicitPolicy2);
          policyMapping1 = Rfc3280CertPathUtilities.PrepareNextCertI2(certPath, index1, policyMapping2);
          inhibitAnyPolicy1 = Rfc3280CertPathUtilities.PrepareNextCertJ(certPath, index1, inhibitAnyPolicy2);
          Rfc3280CertPathUtilities.PrepareNextCertK(certPath, index1);
          int maxPathLength2 = Rfc3280CertPathUtilities.PrepareNextCertL(certPath, index1, maxPathLength1);
          maxPathLength1 = Rfc3280CertPathUtilities.PrepareNextCertM(certPath, index1, maxPathLength2);
          Rfc3280CertPathUtilities.PrepareNextCertN(certPath, index1);
          ISet<string> criticalExtensionOids = cert.GetCriticalExtensionOids();
          ISet<string> criticalExtensions;
          if (criticalExtensionOids != null)
          {
            criticalExtensions = (ISet<string>) new HashSet<string>((IEnumerable<string>) criticalExtensionOids);
            criticalExtensions.Remove(X509Extensions.KeyUsage.Id);
            criticalExtensions.Remove(X509Extensions.CertificatePolicies.Id);
            criticalExtensions.Remove(X509Extensions.PolicyMappings.Id);
            criticalExtensions.Remove(X509Extensions.InhibitAnyPolicy.Id);
            criticalExtensions.Remove(X509Extensions.IssuingDistributionPoint.Id);
            criticalExtensions.Remove(X509Extensions.DeltaCrlIndicator.Id);
            criticalExtensions.Remove(X509Extensions.PolicyConstraints.Id);
            criticalExtensions.Remove(X509Extensions.BasicConstraints.Id);
            criticalExtensions.Remove(X509Extensions.SubjectAlternativeName.Id);
            criticalExtensions.Remove(X509Extensions.NameConstraints.Id);
          }
          else
            criticalExtensions = (ISet<string>) new HashSet<string>();
          Rfc3280CertPathUtilities.PrepareNextCertO(certPath, index1, criticalExtensions, (IEnumerable<PkixCertPathChecker>) certPathCheckers);
          sign = cert;
          workingIssuerName = sign.SubjectDN;
          try
          {
            asymmetricKeyParameter = PkixCertPathValidatorUtilities.GetNextWorkingKey(certPath.Certificates, index1);
          }
          catch (PkixCertPathValidatorException ex)
          {
            throw new PkixCertPathValidatorException("Next working key could not be retrieved.", (Exception) ex, index1);
          }
          PkixCertPathValidatorUtilities.GetAlgorithmIdentifier(asymmetricKeyParameter);
        }
      }
    }
    int explicitPolicy3 = Rfc3280CertPathUtilities.WrapupCertA(explicitPolicy1, cert);
    int num1 = Rfc3280CertPathUtilities.WrapupCertB(certPath, index1 + 1, explicitPolicy3);
    ISet<string> criticalExtensionOids1 = cert.GetCriticalExtensionOids();
    ISet<string> criticalExtensions1;
    if (criticalExtensionOids1 != null)
    {
      criticalExtensions1 = (ISet<string>) new HashSet<string>((IEnumerable<string>) criticalExtensionOids1);
      criticalExtensions1.Remove(X509Extensions.KeyUsage.Id);
      criticalExtensions1.Remove(X509Extensions.CertificatePolicies.Id);
      criticalExtensions1.Remove(X509Extensions.PolicyMappings.Id);
      criticalExtensions1.Remove(X509Extensions.InhibitAnyPolicy.Id);
      criticalExtensions1.Remove(X509Extensions.IssuingDistributionPoint.Id);
      criticalExtensions1.Remove(X509Extensions.DeltaCrlIndicator.Id);
      criticalExtensions1.Remove(X509Extensions.PolicyConstraints.Id);
      criticalExtensions1.Remove(X509Extensions.BasicConstraints.Id);
      criticalExtensions1.Remove(X509Extensions.SubjectAlternativeName.Id);
      criticalExtensions1.Remove(X509Extensions.NameConstraints.Id);
      criticalExtensions1.Remove(X509Extensions.CrlDistributionPoints.Id);
      criticalExtensions1.Remove(X509Extensions.ExtendedKeyUsage.Id);
    }
    else
      criticalExtensions1 = (ISet<string>) new HashSet<string>();
    Rfc3280CertPathUtilities.WrapupCertF(certPath, index1 + 1, (IEnumerable<PkixCertPathChecker>) certPathCheckers, criticalExtensions1);
    PkixPolicyNode policyTree = Rfc3280CertPathUtilities.WrapupCertG(certPath, paramsPkix, initialPolicies, index1 + 1, (IList<PkixPolicyNode>[]) policyNodes, validPolicyTree1, acceptablePolicies);
    if (num1 <= 0 && policyTree == null)
      throw new PkixCertPathValidatorException("Path processing failed on policy.", (Exception) null, index1);
    return new PkixCertPathValidatorResult(trustAnchor, policyTree, cert.GetPublicKey());
  }

  internal static void CheckCertificate(X509Certificate cert)
  {
    try
    {
      TbsCertificateStructure.GetInstance((object) cert.CertificateStructure.TbsCertificate);
    }
    catch (CertificateEncodingException ex)
    {
      throw new Exception("unable to process TBSCertificate", (Exception) ex);
    }
  }
}
