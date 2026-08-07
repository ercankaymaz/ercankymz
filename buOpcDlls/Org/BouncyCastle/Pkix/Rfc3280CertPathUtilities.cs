// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.Rfc3280CertPathUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkix;

internal static class Rfc3280CertPathUtilities
{
  private static readonly PkixCrlUtilities CrlUtilities = new PkixCrlUtilities();
  internal static readonly string ANY_POLICY = "2.5.29.32.0";
  internal static readonly int KEY_CERT_SIGN = 5;
  internal static readonly int CRL_SIGN = 6;
  internal static readonly string[] CrlReasons = new string[11]
  {
    "unspecified",
    "keyCompromise",
    "cACompromise",
    "affiliationChanged",
    "superseded",
    "cessationOfOperation",
    "certificateHold",
    "unknown",
    "removeFromCRL",
    "privilegeWithdrawn",
    "aACompromise"
  };

  internal static void ProcessCrlB2(DistributionPoint dp, object cert, X509Crl crl)
  {
    IssuingDistributionPoint instance1;
    try
    {
      instance1 = IssuingDistributionPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) crl, X509Extensions.IssuingDistributionPoint));
    }
    catch (Exception ex)
    {
      throw new Exception("0 Issuing distribution point extension could not be decoded.", ex);
    }
    if (instance1 == null)
      return;
    if (instance1.DistributionPoint != null)
    {
      DistributionPointName distributionPoint = IssuingDistributionPoint.GetInstance((object) instance1).DistributionPoint;
      List<GeneralName> generalNameList = new List<GeneralName>();
      if (distributionPoint.Type == 0)
      {
        foreach (GeneralName name in GeneralNames.GetInstance((object) distributionPoint.Name).GetNames())
          generalNameList.Add(name);
      }
      if (distributionPoint.Type == 1)
      {
        Asn1Sequence instance2 = Asn1Sequence.GetInstance((object) crl.IssuerDN.ToAsn1Object());
        Asn1EncodableVector elementVector = new Asn1EncodableVector(instance2.Count + 1);
        foreach (Asn1Encodable element in instance2)
          elementVector.Add(element);
        elementVector.Add(distributionPoint.Name);
        generalNameList.Add(new GeneralName(X509Name.GetInstance((object) new DerSequence(elementVector))));
      }
      bool flag = false;
      if (dp.DistributionPointName != null)
      {
        DistributionPointName distributionPointName = dp.DistributionPointName;
        GeneralName[] generalNameArray = (GeneralName[]) null;
        if (distributionPointName.Type == 0)
          generalNameArray = GeneralNames.GetInstance((object) distributionPointName.Name).GetNames();
        if (distributionPointName.Type == 1)
        {
          if (dp.CrlIssuer != null)
          {
            generalNameArray = dp.CrlIssuer.GetNames();
          }
          else
          {
            generalNameArray = new GeneralName[1];
            try
            {
              generalNameArray[0] = new GeneralName(PkixCertPathValidatorUtilities.GetIssuerPrincipal(cert));
            }
            catch (IOException ex)
            {
              throw new Exception("Could not read certificate issuer.", (Exception) ex);
            }
          }
          for (int index = 0; index < generalNameArray.Length; ++index)
          {
            Asn1Sequence instance3 = Asn1Sequence.GetInstance((object) generalNameArray[index].Name.ToAsn1Object());
            Asn1EncodableVector elementVector = new Asn1EncodableVector(instance3.Count + 1);
            foreach (Asn1Encodable element in instance3)
              elementVector.Add(element);
            elementVector.Add(distributionPointName.Name);
            generalNameArray[index] = new GeneralName(X509Name.GetInstance((object) new DerSequence(elementVector)));
          }
        }
        if (generalNameArray != null)
        {
          for (int index = 0; index < generalNameArray.Length; ++index)
          {
            if (generalNameList.Contains(generalNameArray[index]))
            {
              flag = true;
              break;
            }
          }
        }
        if (!flag)
          throw new Exception("No match for certificate CRL issuing distribution point name to cRLIssuer CRL distribution point.");
      }
      else
      {
        if (dp.CrlIssuer == null)
          throw new Exception("Either the cRLIssuer or the distributionPoint field must be contained in DistributionPoint.");
        foreach (GeneralName name in dp.CrlIssuer.GetNames())
        {
          if (generalNameList.Contains(name))
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          throw new Exception("No match for certificate CRL issuing distribution point name to cRLIssuer CRL distribution point.");
      }
    }
    BasicConstraints instance4;
    try
    {
      instance4 = BasicConstraints.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) cert, X509Extensions.BasicConstraints));
    }
    catch (Exception ex)
    {
      throw new Exception("Basic constraints extension could not be decoded.", ex);
    }
    if (instance1.OnlyContainsUserCerts && instance4 != null && instance4.IsCA())
      throw new Exception("CA Cert CRL only contains user certificates.");
    if (instance1.OnlyContainsCACerts && (instance4 == null || !instance4.IsCA()))
      throw new Exception("End CRL only contains CA certificates.");
    if (instance1.OnlyContainsAttributeCerts)
      throw new Exception("onlyContainsAttributeCerts boolean is asserted.");
  }

  internal static void ProcessCertBC(
    PkixCertPath certPath,
    int index,
    PkixNameConstraintValidator nameConstraintValidator)
  {
    IList<X509Certificate> certificates = certPath.Certificates;
    X509Certificate x509Certificate = certificates[index];
    int count = certificates.Count;
    int num = count - index;
    if (PkixCertPathValidatorUtilities.IsSelfIssued(x509Certificate) && num < count)
      return;
    X509Name subjectDn = x509Certificate.SubjectDN;
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) subjectDn.GetEncoded());
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Exception extracting subject name when checking subtrees.", ex, index);
    }
    try
    {
      nameConstraintValidator.CheckPermittedDN(instance1);
      nameConstraintValidator.CheckExcludedDN(instance1);
    }
    catch (PkixNameConstraintValidatorException ex)
    {
      throw new PkixCertPathValidatorException("Subtree check for certificate subject failed.", (Exception) ex, index);
    }
    GeneralNames instance2;
    try
    {
      instance2 = GeneralNames.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) x509Certificate, X509Extensions.SubjectAlternativeName));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Subject alternative name extension could not be decoded.", ex, index);
    }
    foreach (string name1 in (IEnumerable<string>) X509Name.GetInstance((object) instance1).GetValueList(X509Name.EmailAddress))
    {
      GeneralName name2 = new GeneralName(1, name1);
      try
      {
        nameConstraintValidator.CheckPermittedName(name2);
        nameConstraintValidator.CheckExcludedName(name2);
      }
      catch (PkixNameConstraintValidatorException ex)
      {
        throw new PkixCertPathValidatorException("Subtree check for certificate subject alternative email failed.", (Exception) ex, index);
      }
    }
    if (instance2 == null)
      return;
    GeneralName[] names;
    try
    {
      names = instance2.GetNames();
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Subject alternative name contents could not be decoded.", ex, index);
    }
    foreach (GeneralName name in names)
    {
      try
      {
        nameConstraintValidator.CheckPermittedName(name);
        nameConstraintValidator.CheckExcludedName(name);
      }
      catch (PkixNameConstraintValidatorException ex)
      {
        throw new PkixCertPathValidatorException("Subtree check for certificate subject alternative name failed.", (Exception) ex, index);
      }
    }
  }

  internal static void PrepareNextCertA(PkixCertPath certPath, int index)
  {
    X509Certificate certificate = certPath.Certificates[index];
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.PolicyMappings));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Policy mappings extension could not be decoded.", ex, index);
    }
    if (instance1 == null)
      return;
    Asn1Sequence asn1Sequence = instance1;
    for (int index1 = 0; index1 < asn1Sequence.Count; ++index1)
    {
      DerObjectIdentifier instance2;
      DerObjectIdentifier instance3;
      try
      {
        Asn1Sequence instance4 = Asn1Sequence.GetInstance((object) asn1Sequence[index1]);
        instance2 = DerObjectIdentifier.GetInstance((object) instance4[0]);
        instance3 = DerObjectIdentifier.GetInstance((object) instance4[1]);
      }
      catch (Exception ex)
      {
        throw new PkixCertPathValidatorException("Policy mappings extension contents could not be decoded.", ex, index);
      }
      if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(instance2.Id))
        throw new PkixCertPathValidatorException("IssuerDomainPolicy is anyPolicy", (Exception) null, index);
      if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(instance3.Id))
        throw new PkixCertPathValidatorException("SubjectDomainPolicy is anyPolicy,", (Exception) null, index);
    }
  }

  internal static PkixPolicyNode ProcessCertD(
    PkixCertPath certPath,
    int index,
    HashSet<string> acceptablePolicies,
    PkixPolicyNode validPolicyTree,
    IList<PkixPolicyNode>[] policyNodes,
    int inhibitAnyPolicy)
  {
    IList<X509Certificate> certificates = certPath.Certificates;
    X509Certificate x509Certificate = certificates[index];
    int count = certificates.Count;
    int index1 = count - index;
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) x509Certificate, X509Extensions.CertificatePolicies));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Could not read certificate policies extension from certificate.", ex, index);
    }
    if (instance1 == null || validPolicyTree == null)
      return (PkixPolicyNode) null;
    HashSet<string> other1 = new HashSet<string>();
    foreach (Asn1Encodable asn1Encodable in instance1)
    {
      PolicyInformation instance2 = PolicyInformation.GetInstance((object) asn1Encodable.ToAsn1Object());
      DerObjectIdentifier policyIdentifier = instance2.PolicyIdentifier;
      other1.Add(policyIdentifier.Id);
      if (!Rfc3280CertPathUtilities.ANY_POLICY.Equals(policyIdentifier.Id))
      {
        HashSet<PolicyQualifierInfo> qualifierSet;
        try
        {
          qualifierSet = PkixCertPathValidatorUtilities.GetQualifierSet(instance2.PolicyQualifiers);
        }
        catch (PkixCertPathValidatorException ex)
        {
          throw new PkixCertPathValidatorException("Policy qualifier info set could not be build.", (Exception) ex, index);
        }
        if (!PkixCertPathValidatorUtilities.ProcessCertD1i(index1, policyNodes, policyIdentifier, qualifierSet))
          PkixCertPathValidatorUtilities.ProcessCertD1ii(index1, policyNodes, policyIdentifier, qualifierSet);
      }
    }
    if (acceptablePolicies.Count >= 1 && !acceptablePolicies.Contains(Rfc3280CertPathUtilities.ANY_POLICY))
    {
      HashSet<string> other2 = new HashSet<string>();
      foreach (string acceptablePolicy in acceptablePolicies)
      {
        if (other1.Contains(acceptablePolicy))
          other2.Add(acceptablePolicy);
      }
      acceptablePolicies.Clear();
      acceptablePolicies.UnionWith((IEnumerable<string>) other2);
    }
    else
    {
      acceptablePolicies.Clear();
      acceptablePolicies.UnionWith((IEnumerable<string>) other1);
    }
    if (inhibitAnyPolicy > 0 || index1 < count && PkixCertPathValidatorUtilities.IsSelfIssued(x509Certificate))
    {
      foreach (Asn1Encodable asn1Encodable in instance1)
      {
        PolicyInformation instance3 = PolicyInformation.GetInstance((object) asn1Encodable.ToAsn1Object());
        if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(instance3.PolicyIdentifier.Id))
        {
          HashSet<PolicyQualifierInfo> qualifierSet = PkixCertPathValidatorUtilities.GetQualifierSet(instance3.PolicyQualifiers);
          using (IEnumerator<PkixPolicyNode> enumerator1 = policyNodes[index1 - 1].GetEnumerator())
          {
label_47:
            while (enumerator1.MoveNext())
            {
              PkixPolicyNode current1 = enumerator1.Current;
              using (IEnumerator<string> enumerator2 = current1.ExpectedPolicies.GetEnumerator())
              {
                while (true)
                {
                  if (enumerator2.MoveNext())
                  {
                    string current2 = enumerator2.Current;
                    bool flag = false;
                    foreach (PkixPolicyNode child in current1.Children)
                    {
                      if (current2.Equals(child.ValidPolicy))
                      {
                        flag = true;
                        break;
                      }
                    }
                    if (!flag)
                    {
                      PkixPolicyNode child = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), index1, (ISet<string>) new HashSet<string>()
                      {
                        current2
                      }, current1, (ISet<PolicyQualifierInfo>) qualifierSet, current2, false);
                      current1.AddChild(child);
                      policyNodes[index1].Add(child);
                    }
                  }
                  else
                    goto label_47;
                }
              }
            }
            break;
          }
        }
      }
    }
    PkixPolicyNode validPolicyTree1 = validPolicyTree;
    for (int index2 = index1 - 1; index2 >= 0; --index2)
    {
      IList<PkixPolicyNode> policyNode = policyNodes[index2];
      for (int index3 = 0; index3 < policyNode.Count; ++index3)
      {
        PkixPolicyNode _node = policyNode[index3];
        if (!_node.HasChildren)
        {
          validPolicyTree1 = PkixCertPathValidatorUtilities.RemovePolicyNode(validPolicyTree1, policyNodes, _node);
          if (validPolicyTree1 == null)
            break;
        }
      }
    }
    ISet<string> criticalExtensionOids = x509Certificate.GetCriticalExtensionOids();
    if (criticalExtensionOids != null)
    {
      bool flag = criticalExtensionOids.Contains(X509Extensions.CertificatePolicies.Id);
      foreach (PkixPolicyNode pkixPolicyNode in (IEnumerable<PkixPolicyNode>) policyNodes[index1])
        pkixPolicyNode.IsCritical = flag;
    }
    return validPolicyTree1;
  }

  internal static void ProcessCrlB1(DistributionPoint dp, object cert, X509Crl crl)
  {
    Asn1Object extensionValue = PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) crl, X509Extensions.IssuingDistributionPoint);
    bool flag1 = false;
    if (extensionValue != null && IssuingDistributionPoint.GetInstance((object) extensionValue).IsIndirectCrl)
      flag1 = true;
    byte[] encoded = crl.IssuerDN.GetEncoded();
    bool flag2 = false;
    if (dp.CrlIssuer != null)
    {
      GeneralName[] names = dp.CrlIssuer.GetNames();
      for (int index = 0; index < names.Length; ++index)
      {
        if (names[index].TagNo == 4)
        {
          try
          {
            if (Arrays.AreEqual(names[index].Name.GetEncoded(), encoded))
              flag2 = true;
          }
          catch (IOException ex)
          {
            throw new Exception("CRL issuer information from distribution point cannot be decoded.", (Exception) ex);
          }
        }
      }
      if (flag2 && !flag1)
        throw new Exception("Distribution point contains cRLIssuer field but CRL is not indirect.");
      if (!flag2)
        throw new Exception("CRL issuer of CRL does not match CRL issuer of distribution point.");
    }
    else if (crl.IssuerDN.Equivalent(PkixCertPathValidatorUtilities.GetIssuerPrincipal(cert), true))
      flag2 = true;
    if (!flag2)
      throw new Exception("Cannot find matching CRL issuer for certificate.");
  }

  internal static ReasonsMask ProcessCrlD(X509Crl crl, DistributionPoint dp)
  {
    IssuingDistributionPoint instance;
    try
    {
      instance = IssuingDistributionPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) crl, X509Extensions.IssuingDistributionPoint));
    }
    catch (Exception ex)
    {
      throw new Exception("issuing distribution point extension could not be decoded.", ex);
    }
    if (instance != null && instance.OnlySomeReasons != null && dp.Reasons != null)
      return new ReasonsMask(dp.Reasons.IntValue).Intersect(new ReasonsMask(instance.OnlySomeReasons.IntValue));
    return (instance == null || instance.OnlySomeReasons == null) && dp.Reasons == null ? ReasonsMask.AllReasons : (dp.Reasons != null ? new ReasonsMask(dp.Reasons.IntValue) : ReasonsMask.AllReasons).Intersect(instance != null ? new ReasonsMask(instance.OnlySomeReasons.IntValue) : ReasonsMask.AllReasons);
  }

  internal static HashSet<AsymmetricKeyParameter> ProcessCrlF(
    X509Crl crl,
    object cert,
    X509Certificate defaultCRLSignCert,
    AsymmetricKeyParameter defaultCRLSignKey,
    PkixParameters paramsPKIX,
    IList<X509Certificate> certPathCerts)
  {
    X509CertStoreSelector certStoreSelector = new X509CertStoreSelector();
    try
    {
      certStoreSelector.Subject = crl.IssuerDN;
    }
    catch (IOException ex)
    {
      throw new Exception("Subject criteria for certificate selector to find issuer certificate for CRL could not be set.", (Exception) ex);
    }
    HashSet<X509Certificate> matches = new HashSet<X509Certificate>();
    try
    {
      CollectionUtilities.CollectMatches<X509Certificate>((ICollection<X509Certificate>) matches, (ISelector<X509Certificate>) certStoreSelector, (IEnumerable<IStore<X509Certificate>>) paramsPKIX.GetStoresCert());
    }
    catch (Exception ex)
    {
      throw new Exception("Issuer certificate for CRL cannot be searched.", ex);
    }
    matches.Add(defaultCRLSignCert);
    List<X509Certificate> x509CertificateList = new List<X509Certificate>();
    List<AsymmetricKeyParameter> asymmetricKeyParameterList = new List<AsymmetricKeyParameter>();
    foreach (X509Certificate x509Certificate in matches)
    {
      if (x509Certificate.Equals((object) defaultCRLSignCert))
      {
        x509CertificateList.Add(x509Certificate);
        asymmetricKeyParameterList.Add(defaultCRLSignKey);
      }
      else
      {
        try
        {
          PkixCertPathBuilder pkixCertPathBuilder = new PkixCertPathBuilder();
          X509CertStoreSelector targetConstraintsCert = new X509CertStoreSelector();
          targetConstraintsCert.Certificate = x509Certificate;
          PkixBuilderParameters instance = PkixBuilderParameters.GetInstance(paramsPKIX);
          instance.SetTargetConstraintsCert((ISelector<X509Certificate>) targetConstraintsCert);
          if (certPathCerts.Contains(x509Certificate))
            instance.IsRevocationEnabled = false;
          else
            instance.IsRevocationEnabled = true;
          PkixBuilderParameters pkixParams = instance;
          IList<X509Certificate> certificates = pkixCertPathBuilder.Build(pkixParams).CertPath.Certificates;
          x509CertificateList.Add(x509Certificate);
          asymmetricKeyParameterList.Add(PkixCertPathValidatorUtilities.GetNextWorkingKey(certificates, 0));
        }
        catch (PkixCertPathBuilderException ex)
        {
          throw new Exception("CertPath for CRL signer failed to validate.", (Exception) ex);
        }
        catch (PkixCertPathValidatorException ex)
        {
          throw new Exception("Public key of issuer certificate of CRL could not be retrieved.", (Exception) ex);
        }
      }
    }
    HashSet<AsymmetricKeyParameter> asymmetricKeyParameterSet = new HashSet<AsymmetricKeyParameter>();
    Exception exception = (Exception) null;
    for (int index = 0; index < x509CertificateList.Count; ++index)
    {
      bool[] keyUsage = x509CertificateList[index].GetKeyUsage();
      if (keyUsage != null && (keyUsage.Length < 7 || !keyUsage[Rfc3280CertPathUtilities.CRL_SIGN]))
        exception = new Exception("Issuer certificate key usage extension does not permit CRL signing.");
      else
        asymmetricKeyParameterSet.Add(asymmetricKeyParameterList[index]);
    }
    if (asymmetricKeyParameterSet.Count == 0 && exception == null)
      throw new Exception("Cannot find a valid issuer certificate.");
    if (asymmetricKeyParameterSet.Count == 0 && exception != null)
      throw exception;
    return asymmetricKeyParameterSet;
  }

  internal static AsymmetricKeyParameter ProcessCrlG(
    X509Crl crl,
    HashSet<AsymmetricKeyParameter> keys)
  {
    Exception innerException = (Exception) null;
    foreach (AsymmetricKeyParameter key in keys)
    {
      try
      {
        crl.Verify(key);
        return key;
      }
      catch (Exception ex)
      {
        innerException = ex;
      }
    }
    throw new Exception("Cannot verify CRL.", innerException);
  }

  internal static X509Crl ProcessCrlH(HashSet<X509Crl> deltaCrls, AsymmetricKeyParameter key)
  {
    Exception innerException = (Exception) null;
    foreach (X509Crl deltaCrl in deltaCrls)
    {
      try
      {
        deltaCrl.Verify(key);
        return deltaCrl;
      }
      catch (Exception ex)
      {
        innerException = ex;
      }
    }
    if (innerException != null)
      throw new Exception("Cannot verify delta CRL.", innerException);
    return (X509Crl) null;
  }

  private static void CheckCrl(
    DistributionPoint dp,
    PkixParameters paramsPKIX,
    X509Certificate cert,
    DateTime validDate,
    X509Certificate defaultCRLSignCert,
    AsymmetricKeyParameter defaultCRLSignKey,
    CertStatus certStatus,
    ReasonsMask reasonMask,
    IList<X509Certificate> certPathCerts)
  {
    DateTime utcNow = DateTime.UtcNow;
    if (validDate.Ticks > utcNow.Ticks)
      throw new Exception("Validation time is in future.");
    ISet<X509Crl> completeCrls = PkixCertPathValidatorUtilities.GetCompleteCrls(dp, (object) cert, utcNow, paramsPKIX);
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
            HashSet<AsymmetricKeyParameter> keys = Rfc3280CertPathUtilities.ProcessCrlF(current, (object) cert, defaultCRLSignCert, defaultCRLSignKey, paramsPKIX, certPathCerts);
            AsymmetricKeyParameter key = Rfc3280CertPathUtilities.ProcessCrlG(current, keys);
            X509Crl x509Crl = (X509Crl) null;
            if (paramsPKIX.IsUseDeltasEnabled)
              x509Crl = Rfc3280CertPathUtilities.ProcessCrlH(PkixCertPathValidatorUtilities.GetDeltaCrls(utcNow, paramsPKIX, current), key);
            if (paramsPKIX.ValidityModel != 1 && cert.NotAfter.Ticks < current.ThisUpdate.Ticks)
              throw new Exception("No valid CRL for current time found.");
            Rfc3280CertPathUtilities.ProcessCrlB1(dp, (object) cert, current);
            Rfc3280CertPathUtilities.ProcessCrlB2(dp, (object) cert, current);
            Rfc3280CertPathUtilities.ProcessCrlC(x509Crl, current, paramsPKIX);
            Rfc3280CertPathUtilities.ProcessCrlI(validDate, x509Crl, (object) cert, certStatus, paramsPKIX);
            Rfc3280CertPathUtilities.ProcessCrlJ(validDate, current, (object) cert, certStatus);
            if (certStatus.Status == 8)
              certStatus.Status = 11;
            reasonMask.AddReasons(mask);
            ISet<string> criticalExtensionOids1 = current.GetCriticalExtensionOids();
            if (criticalExtensionOids1 != null)
            {
              ISet<string> stringSet = (ISet<string>) new HashSet<string>((IEnumerable<string>) criticalExtensionOids1);
              stringSet.Remove(X509Extensions.IssuingDistributionPoint.Id);
              stringSet.Remove(X509Extensions.DeltaCrlIndicator.Id);
              if (stringSet.Count > 0)
                throw new Exception("CRL contains unsupported critical extensions.");
            }
            if (x509Crl != null)
            {
              ISet<string> criticalExtensionOids2 = x509Crl.GetCriticalExtensionOids();
              if (criticalExtensionOids2 != null)
              {
                ISet<string> stringSet = (ISet<string>) new HashSet<string>((IEnumerable<string>) criticalExtensionOids2);
                stringSet.Remove(X509Extensions.IssuingDistributionPoint.Id);
                stringSet.Remove(X509Extensions.DeltaCrlIndicator.Id);
                if (stringSet.Count > 0)
                  throw new Exception("Delta CRL contains unsupported critical extension.");
              }
            }
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

  internal static void CheckCrls(
    PkixParameters paramsPKIX,
    X509Certificate cert,
    DateTime validDate,
    X509Certificate sign,
    AsymmetricKeyParameter workingPublicKey,
    IList<X509Certificate> certPathCerts)
  {
    Exception exception = (Exception) null;
    CrlDistPoint instance;
    try
    {
      instance = CrlDistPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) cert, X509Extensions.CrlDistributionPoints));
    }
    catch (Exception ex)
    {
      throw new Exception("CRL distribution point extension could not be read.", ex);
    }
    try
    {
      PkixCertPathValidatorUtilities.AddAdditionalStoresFromCrlDistributionPoint(instance, paramsPKIX);
    }
    catch (Exception ex)
    {
      throw new Exception("No additional CRL locations could be decoded from CRL distribution point extension.", ex);
    }
    CertStatus certStatus = new CertStatus();
    ReasonsMask reasonMask = new ReasonsMask();
    bool flag = false;
    if (instance != null)
    {
      DistributionPoint[] distributionPoints;
      try
      {
        distributionPoints = instance.GetDistributionPoints();
      }
      catch (Exception ex)
      {
        throw new Exception("Distribution points could not be read.", ex);
      }
      if (distributionPoints != null)
      {
        for (int index = 0; index < distributionPoints.Length && certStatus.Status == 11 && !reasonMask.IsAllReasons; ++index)
        {
          PkixParameters paramsPKIX1 = (PkixParameters) paramsPKIX.Clone();
          try
          {
            Rfc3280CertPathUtilities.CheckCrl(distributionPoints[index], paramsPKIX1, cert, validDate, sign, workingPublicKey, certStatus, reasonMask, certPathCerts);
            flag = true;
          }
          catch (Exception ex)
          {
            exception = ex;
          }
        }
      }
    }
    if (certStatus.Status == 11)
    {
      if (!reasonMask.IsAllReasons)
      {
        try
        {
          Rfc3280CertPathUtilities.CheckCrl(new DistributionPoint(new DistributionPointName(0, (Asn1Encodable) new GeneralNames(new GeneralName(4, (Asn1Encodable) cert.IssuerDN))), (ReasonFlags) null, (GeneralNames) null), (PkixParameters) paramsPKIX.Clone(), cert, validDate, sign, workingPublicKey, certStatus, reasonMask, certPathCerts);
          flag = true;
        }
        catch (Exception ex)
        {
          exception = ex;
        }
      }
    }
    if (!flag)
      throw exception;
    if (certStatus.Status != 11)
      throw new Exception($"{"Certificate revocation after " + certStatus.RevocationDate.Value.ToString("ddd MMM dd HH:mm:ss K yyyy")}, reason: {Rfc3280CertPathUtilities.CrlReasons[certStatus.Status]}");
    if (!reasonMask.IsAllReasons && certStatus.Status == 11)
      certStatus.Status = 12;
    if (certStatus.Status == 12)
      throw new Exception("Certificate status could not be determined.");
  }

  internal static PkixPolicyNode PrepareCertB(
    PkixCertPath certPath,
    int index,
    IList<PkixPolicyNode>[] policyNodes,
    PkixPolicyNode validPolicyTree,
    int policyMapping)
  {
    IList<X509Certificate> certificates = certPath.Certificates;
    X509Certificate extensions = certificates[index];
    int depth = certificates.Count - index;
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) extensions, X509Extensions.PolicyMappings));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Policy mappings extension could not be decoded.", ex, index);
    }
    PkixPolicyNode validPolicyTree1 = validPolicyTree;
    if (instance1 != null)
    {
      Asn1Sequence asn1Sequence1 = instance1;
      Dictionary<string, ISet<string>> d = new Dictionary<string, ISet<string>>();
      HashSet<string> stringSet1 = new HashSet<string>();
      for (int index1 = 0; index1 < asn1Sequence1.Count; ++index1)
      {
        Asn1Sequence asn1Sequence2 = (Asn1Sequence) asn1Sequence1[index1];
        string id1 = ((DerObjectIdentifier) asn1Sequence2[0]).Id;
        string id2 = ((DerObjectIdentifier) asn1Sequence2[1]).Id;
        ISet<string> stringSet2;
        if (d.TryGetValue(id1, out stringSet2))
        {
          stringSet2.Add(id2);
        }
        else
        {
          stringSet2 = (ISet<string>) new HashSet<string>();
          stringSet2.Add(id2);
          d[id1] = stringSet2;
          stringSet1.Add(id1);
        }
      }
      using (HashSet<string>.Enumerator enumerator1 = stringSet1.GetEnumerator())
      {
label_62:
        while (enumerator1.MoveNext())
        {
          string current1 = enumerator1.Current;
          if (policyMapping > 0)
          {
            bool flag = false;
            foreach (PkixPolicyNode pkixPolicyNode in (IEnumerable<PkixPolicyNode>) policyNodes[depth])
            {
              if (pkixPolicyNode.ValidPolicy.Equals(current1))
              {
                flag = true;
                pkixPolicyNode.ExpectedPolicies = CollectionUtilities.GetValueOrNull<string, ISet<string>>((IDictionary<string, ISet<string>>) d, current1);
                break;
              }
            }
            if (!flag)
            {
              foreach (PkixPolicyNode pkixPolicyNode in (IEnumerable<PkixPolicyNode>) policyNodes[depth])
              {
                if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(pkixPolicyNode.ValidPolicy))
                {
                  Asn1Sequence instance2;
                  try
                  {
                    instance2 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) extensions, X509Extensions.CertificatePolicies));
                  }
                  catch (Exception ex)
                  {
                    throw new PkixCertPathValidatorException("Certificate policies extension could not be decoded.", ex, index);
                  }
                  ISet<PolicyQualifierInfo> policyQualifiers = (ISet<PolicyQualifierInfo>) null;
                  foreach (Asn1Encodable asn1Encodable in instance2)
                  {
                    PolicyInformation instance3;
                    try
                    {
                      instance3 = PolicyInformation.GetInstance((object) asn1Encodable.ToAsn1Object());
                    }
                    catch (Exception ex)
                    {
                      throw new PkixCertPathValidatorException("Policy information could not be decoded.", ex, index);
                    }
                    if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(instance3.PolicyIdentifier.Id))
                    {
                      try
                      {
                        policyQualifiers = (ISet<PolicyQualifierInfo>) PkixCertPathValidatorUtilities.GetQualifierSet(instance3.PolicyQualifiers);
                        break;
                      }
                      catch (PkixCertPathValidatorException ex)
                      {
                        throw new PkixCertPathValidatorException("Policy qualifier info set could not be decoded.", (Exception) ex, index);
                      }
                    }
                  }
                  bool critical = false;
                  ISet<string> criticalExtensionOids = extensions.GetCriticalExtensionOids();
                  if (criticalExtensionOids != null)
                    critical = criticalExtensionOids.Contains(X509Extensions.CertificatePolicies.Id);
                  PkixPolicyNode parent = pkixPolicyNode.Parent;
                  if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(parent.ValidPolicy))
                  {
                    PkixPolicyNode child = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), depth, CollectionUtilities.GetValueOrNull<string, ISet<string>>((IDictionary<string, ISet<string>>) d, current1), parent, policyQualifiers, current1, critical);
                    parent.AddChild(child);
                    policyNodes[depth].Add(child);
                    break;
                  }
                  break;
                }
              }
            }
          }
          else if (policyMapping <= 0)
          {
            using (List<PkixPolicyNode>.Enumerator enumerator2 = new List<PkixPolicyNode>((IEnumerable<PkixPolicyNode>) policyNodes[depth]).GetEnumerator())
            {
label_50:
              PkixPolicyNode current2;
              do
              {
                if (enumerator2.MoveNext())
                  current2 = enumerator2.Current;
                else
                  goto label_62;
              }
              while (!current2.ValidPolicy.Equals(current1));
              current2.Parent.RemoveChild(current2);
              int index2 = depth - 1;
              while (true)
              {
                if (index2 >= 0)
                {
                  foreach (PkixPolicyNode _node in new List<PkixPolicyNode>((IEnumerable<PkixPolicyNode>) policyNodes[index2]))
                  {
                    if (!_node.HasChildren)
                    {
                      validPolicyTree1 = PkixCertPathValidatorUtilities.RemovePolicyNode(validPolicyTree1, policyNodes, _node);
                      if (validPolicyTree1 == null)
                        break;
                    }
                  }
                  --index2;
                }
                else
                  goto label_50;
              }
            }
          }
        }
      }
    }
    return validPolicyTree1;
  }

  internal static ISet<X509Crl>[] ProcessCrlA1ii(
    DateTime currentDate,
    PkixParameters paramsPKIX,
    X509Certificate cert,
    X509Crl crl)
  {
    X509CrlStoreSelector crlSelector = new X509CrlStoreSelector();
    crlSelector.CertificateChecking = cert;
    try
    {
      crlSelector.Issuers = (IList<X509Name>) new List<X509Name>()
      {
        crl.IssuerDN
      };
    }
    catch (IOException ex)
    {
      throw new Exception("Cannot extract issuer from CRL." + ex?.ToString(), (Exception) ex);
    }
    crlSelector.CompleteCrlEnabled = true;
    ISet<X509Crl> crls = Rfc3280CertPathUtilities.CrlUtilities.FindCrls(crlSelector, paramsPKIX, currentDate);
    HashSet<X509Crl> x509CrlSet = new HashSet<X509Crl>();
    if (paramsPKIX.IsUseDeltasEnabled)
    {
      try
      {
        x509CrlSet.UnionWith((IEnumerable<X509Crl>) PkixCertPathValidatorUtilities.GetDeltaCrls(currentDate, paramsPKIX, crl));
      }
      catch (Exception ex)
      {
        throw new Exception("Exception obtaining delta CRLs.", ex);
      }
    }
    return new ISet<X509Crl>[2]
    {
      crls,
      (ISet<X509Crl>) x509CrlSet
    };
  }

  internal static ISet<X509Crl> ProcessCrlA1i(
    DateTime currentDate,
    PkixParameters paramsPKIX,
    X509Certificate cert,
    X509Crl crl)
  {
    HashSet<X509Crl> x509CrlSet = new HashSet<X509Crl>();
    if (paramsPKIX.IsUseDeltasEnabled)
    {
      CrlDistPoint instance;
      try
      {
        instance = CrlDistPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) cert, X509Extensions.FreshestCrl));
      }
      catch (Exception ex)
      {
        throw new Exception("Freshest CRL extension could not be decoded from certificate.", ex);
      }
      if (instance == null)
      {
        try
        {
          instance = CrlDistPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) crl, X509Extensions.FreshestCrl));
        }
        catch (Exception ex)
        {
          throw new Exception("Freshest CRL extension could not be decoded from CRL.", ex);
        }
      }
      if (instance != null)
      {
        try
        {
          PkixCertPathValidatorUtilities.AddAdditionalStoresFromCrlDistributionPoint(instance, paramsPKIX);
        }
        catch (Exception ex)
        {
          throw new Exception("No new delta CRL locations could be added from Freshest CRL extension.", ex);
        }
        try
        {
          x509CrlSet.UnionWith((IEnumerable<X509Crl>) PkixCertPathValidatorUtilities.GetDeltaCrls(currentDate, paramsPKIX, crl));
        }
        catch (Exception ex)
        {
          throw new Exception("Exception obtaining delta CRLs.", ex);
        }
      }
    }
    return (ISet<X509Crl>) x509CrlSet;
  }

  internal static void ProcessCertF(
    PkixCertPath certPath,
    int index,
    PkixPolicyNode validPolicyTree,
    int explicitPolicy)
  {
    if (explicitPolicy <= 0 && validPolicyTree == null)
      throw new PkixCertPathValidatorException("No valid policy tree found when one expected.", (Exception) null, index);
  }

  internal static void ProcessCertA(
    PkixCertPath certPath,
    PkixParameters paramsPKIX,
    int index,
    AsymmetricKeyParameter workingPublicKey,
    X509Name workingIssuerName,
    X509Certificate sign)
  {
    IList<X509Certificate> certificates = certPath.Certificates;
    X509Certificate cert = certificates[index];
    try
    {
      cert.Verify(workingPublicKey);
    }
    catch (GeneralSecurityException ex)
    {
      throw new PkixCertPathValidatorException("Could not validate certificate signature.", (Exception) ex, index);
    }
    try
    {
      cert.CheckValidity(PkixCertPathValidatorUtilities.GetValidCertDateFromValidityModel(paramsPKIX, certPath, index));
    }
    catch (CertificateExpiredException ex)
    {
      throw new PkixCertPathValidatorException("Could not validate certificate: " + ex.Message, (Exception) ex, index);
    }
    catch (CertificateNotYetValidException ex)
    {
      throw new PkixCertPathValidatorException("Could not validate certificate: " + ex.Message, (Exception) ex, index);
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Could not validate time of certificate.", ex, index);
    }
    if (paramsPKIX.IsRevocationEnabled)
    {
      try
      {
        Rfc3280CertPathUtilities.CheckCrls(paramsPKIX, cert, PkixCertPathValidatorUtilities.GetValidCertDateFromValidityModel(paramsPKIX, certPath, index), sign, workingPublicKey, certificates);
      }
      catch (Exception ex)
      {
        Exception innerException = ex.InnerException ?? ex;
        throw new PkixCertPathValidatorException(ex.Message, innerException, index);
      }
    }
    X509Name issuerPrincipal = PkixCertPathValidatorUtilities.GetIssuerPrincipal(cert);
    if (!issuerPrincipal.Equivalent(workingIssuerName, true))
      throw new PkixCertPathValidatorException($"IssuerName({issuerPrincipal?.ToString()}) does not match SubjectName({workingIssuerName?.ToString()}) of signing certificate.", (Exception) null, index);
  }

  internal static int PrepareNextCertI1(PkixCertPath certPath, int index, int explicitPolicy)
  {
    X509Certificate certificate = certPath.Certificates[index];
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.PolicyConstraints));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Policy constraints extension cannot be decoded.", ex, index);
    }
    if (instance1 != null)
    {
      foreach (Asn1Encodable asn1Encodable in instance1)
      {
        try
        {
          Asn1TaggedObject instance2 = Asn1TaggedObject.GetInstance((object) asn1Encodable);
          if (instance2.HasContextTag(0))
          {
            int intValueExact = DerInteger.GetInstance(instance2, false).IntValueExact;
            if (intValueExact < explicitPolicy)
              return intValueExact;
            break;
          }
        }
        catch (ArgumentException ex)
        {
          throw new PkixCertPathValidatorException("Policy constraints extension contents cannot be decoded.", (Exception) ex, index);
        }
      }
    }
    return explicitPolicy;
  }

  internal static int PrepareNextCertI2(PkixCertPath certPath, int index, int policyMapping)
  {
    X509Certificate certificate = certPath.Certificates[index];
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.PolicyConstraints));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Policy constraints extension cannot be decoded.", ex, index);
    }
    if (instance1 != null)
    {
      foreach (Asn1Encodable asn1Encodable in instance1)
      {
        try
        {
          Asn1TaggedObject instance2 = Asn1TaggedObject.GetInstance((object) asn1Encodable);
          if (instance2.HasContextTag(1))
          {
            int intValueExact = DerInteger.GetInstance(instance2, false).IntValueExact;
            if (intValueExact < policyMapping)
              return intValueExact;
            break;
          }
        }
        catch (ArgumentException ex)
        {
          throw new PkixCertPathValidatorException("Policy constraints extension contents cannot be decoded.", (Exception) ex, index);
        }
      }
    }
    return policyMapping;
  }

  internal static void PrepareNextCertG(
    PkixCertPath certPath,
    int index,
    PkixNameConstraintValidator nameConstraintValidator)
  {
    X509Certificate certificate = certPath.Certificates[index];
    NameConstraints nameConstraints = (NameConstraints) null;
    try
    {
      Asn1Sequence instance = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.NameConstraints));
      if (instance != null)
        nameConstraints = NameConstraints.GetInstance((object) instance);
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Name constraints extension could not be decoded.", ex, index);
    }
    if (nameConstraints == null)
      return;
    Asn1Sequence permittedSubtrees = nameConstraints.PermittedSubtrees;
    if (permittedSubtrees != null)
    {
      try
      {
        nameConstraintValidator.IntersectPermittedSubtree(permittedSubtrees);
      }
      catch (Exception ex)
      {
        throw new PkixCertPathValidatorException("Permitted subtrees cannot be build from name constraints extension.", ex, index);
      }
    }
    Asn1Sequence excludedSubtrees = nameConstraints.ExcludedSubtrees;
    if (excludedSubtrees == null)
      return;
    try
    {
      foreach (object obj in excludedSubtrees)
      {
        GeneralSubtree instance = GeneralSubtree.GetInstance(obj);
        nameConstraintValidator.AddExcludedSubtree(instance);
      }
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Excluded subtrees cannot be build from name constraints extension.", ex, index);
    }
  }

  internal static int PrepareNextCertJ(PkixCertPath certPath, int index, int inhibitAnyPolicy)
  {
    X509Certificate certificate = certPath.Certificates[index];
    DerInteger instance;
    try
    {
      instance = DerInteger.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.InhibitAnyPolicy));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Inhibit any-policy extension cannot be decoded.", ex, index);
    }
    if (instance != null)
    {
      int intValueExact = instance.IntValueExact;
      if (intValueExact < inhibitAnyPolicy)
        return intValueExact;
    }
    return inhibitAnyPolicy;
  }

  internal static void PrepareNextCertK(PkixCertPath certPath, int index)
  {
    X509Certificate certificate = certPath.Certificates[index];
    BasicConstraints instance;
    try
    {
      instance = BasicConstraints.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.BasicConstraints));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Basic constraints extension cannot be decoded.", ex, index);
    }
    if (instance == null)
      throw new PkixCertPathValidatorException("Intermediate certificate lacks BasicConstraints");
    if (!instance.IsCA())
      throw new PkixCertPathValidatorException("Not a CA certificate");
  }

  internal static int PrepareNextCertL(PkixCertPath certPath, int index, int maxPathLength)
  {
    if (PkixCertPathValidatorUtilities.IsSelfIssued(certPath.Certificates[index]))
      return maxPathLength;
    if (maxPathLength <= 0)
      throw new PkixCertPathValidatorException("Max path length not greater than zero", (Exception) null, index);
    return maxPathLength - 1;
  }

  internal static int PrepareNextCertM(PkixCertPath certPath, int index, int maxPathLength)
  {
    X509Certificate certificate = certPath.Certificates[index];
    BasicConstraints instance;
    try
    {
      instance = BasicConstraints.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.BasicConstraints));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Basic constraints extension cannot be decoded.", ex, index);
    }
    if (instance != null)
    {
      BigInteger pathLenConstraint = instance.PathLenConstraint;
      if (pathLenConstraint != null)
      {
        int intValue = pathLenConstraint.IntValue;
        if (intValue < maxPathLength)
          return intValue;
      }
    }
    return maxPathLength;
  }

  internal static void PrepareNextCertN(PkixCertPath certPath, int index)
  {
    bool[] keyUsage = certPath.Certificates[index].GetKeyUsage();
    if (keyUsage != null && !keyUsage[Rfc3280CertPathUtilities.KEY_CERT_SIGN])
      throw new PkixCertPathValidatorException("Issuer certificate keyusage extension is critical and does not permit key signing.", (Exception) null, index);
  }

  internal static void PrepareNextCertO(
    PkixCertPath certPath,
    int index,
    ISet<string> criticalExtensions,
    IEnumerable<PkixCertPathChecker> checkers)
  {
    X509Certificate certificate = certPath.Certificates[index];
    foreach (PkixCertPathChecker checker in checkers)
    {
      try
      {
        checker.Check(certificate, criticalExtensions);
      }
      catch (PkixCertPathValidatorException ex)
      {
        throw new PkixCertPathValidatorException(ex.Message, ex.InnerException, index);
      }
    }
    if (criticalExtensions.Count > 0)
      throw new PkixCertPathValidatorException("Certificate has unsupported critical extension.", (Exception) null, index);
  }

  internal static int PrepareNextCertH1(PkixCertPath certPath, int index, int explicitPolicy)
  {
    return !PkixCertPathValidatorUtilities.IsSelfIssued(certPath.Certificates[index]) && explicitPolicy != 0 ? explicitPolicy - 1 : explicitPolicy;
  }

  internal static int PrepareNextCertH2(PkixCertPath certPath, int index, int policyMapping)
  {
    return !PkixCertPathValidatorUtilities.IsSelfIssued(certPath.Certificates[index]) && policyMapping != 0 ? policyMapping - 1 : policyMapping;
  }

  internal static int PrepareNextCertH3(PkixCertPath certPath, int index, int inhibitAnyPolicy)
  {
    return !PkixCertPathValidatorUtilities.IsSelfIssued(certPath.Certificates[index]) && inhibitAnyPolicy != 0 ? inhibitAnyPolicy - 1 : inhibitAnyPolicy;
  }

  internal static int WrapupCertA(int explicitPolicy, X509Certificate cert)
  {
    if (!PkixCertPathValidatorUtilities.IsSelfIssued(cert) && explicitPolicy != 0)
      --explicitPolicy;
    return explicitPolicy;
  }

  internal static int WrapupCertB(PkixCertPath certPath, int index, int explicitPolicy)
  {
    X509Certificate certificate = certPath.Certificates[index];
    Asn1Sequence instance1;
    try
    {
      instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.PolicyConstraints));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Policy constraints could not be decoded.", ex, index);
    }
    if (instance1 != null)
    {
      foreach (object obj in instance1)
      {
        Asn1TaggedObject instance2 = Asn1TaggedObject.GetInstance(obj);
        if (instance2.HasContextTag(0))
        {
          int intValueExact;
          try
          {
            intValueExact = DerInteger.GetInstance(instance2, false).IntValueExact;
          }
          catch (Exception ex)
          {
            throw new PkixCertPathValidatorException("Policy constraints requireExplicitPolicy field could not be decoded.", ex, index);
          }
          if (intValueExact == 0)
            return 0;
          break;
        }
      }
    }
    return explicitPolicy;
  }

  internal static void WrapupCertF(
    PkixCertPath certPath,
    int index,
    IEnumerable<PkixCertPathChecker> checkers,
    ISet<string> criticalExtensions)
  {
    X509Certificate certificate = certPath.Certificates[index];
    foreach (PkixCertPathChecker checker in checkers)
    {
      try
      {
        checker.Check(certificate, criticalExtensions);
      }
      catch (PkixCertPathValidatorException ex)
      {
        throw new PkixCertPathValidatorException("Additional certificate path checker failed.", (Exception) ex, index);
      }
    }
    if (criticalExtensions.Count > 0)
      throw new PkixCertPathValidatorException("Certificate has unsupported critical extension", (Exception) null, index);
  }

  internal static PkixPolicyNode WrapupCertG(
    PkixCertPath certPath,
    PkixParameters paramsPKIX,
    ISet<string> userInitialPolicySet,
    int index,
    IList<PkixPolicyNode>[] policyNodes,
    PkixPolicyNode validPolicyTree,
    HashSet<string> acceptablePolicies)
  {
    int count = certPath.Certificates.Count;
    PkixPolicyNode pkixPolicyNode1;
    if (validPolicyTree == null)
    {
      if (paramsPKIX.IsExplicitPolicyRequired)
        throw new PkixCertPathValidatorException("Explicit policy requested but none available.", (Exception) null, index);
      pkixPolicyNode1 = (PkixPolicyNode) null;
    }
    else if (PkixCertPathValidatorUtilities.IsAnyPolicy(userInitialPolicySet))
    {
      if (paramsPKIX.IsExplicitPolicyRequired)
      {
        if (acceptablePolicies.Count < 1)
          throw new PkixCertPathValidatorException("Explicit policy requested but none available.", (Exception) null, index);
        HashSet<PkixPolicyNode> pkixPolicyNodeSet = new HashSet<PkixPolicyNode>();
        foreach (IEnumerable<PkixPolicyNode> policyNode in policyNodes)
        {
          foreach (PkixPolicyNode pkixPolicyNode2 in policyNode)
          {
            if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(pkixPolicyNode2.ValidPolicy))
            {
              foreach (PkixPolicyNode child in pkixPolicyNode2.Children)
                pkixPolicyNodeSet.Add(child);
            }
          }
        }
        foreach (PkixPolicyNode pkixPolicyNode3 in pkixPolicyNodeSet)
          acceptablePolicies.Contains(pkixPolicyNode3.ValidPolicy);
        if (validPolicyTree != null)
        {
          for (int index1 = count - 1; index1 >= 0; --index1)
          {
            IList<PkixPolicyNode> policyNode = policyNodes[index1];
            for (int index2 = 0; index2 < policyNode.Count; ++index2)
            {
              PkixPolicyNode _node = policyNode[index2];
              if (!_node.HasChildren)
                validPolicyTree = PkixCertPathValidatorUtilities.RemovePolicyNode(validPolicyTree, policyNodes, _node);
            }
          }
        }
      }
      pkixPolicyNode1 = validPolicyTree;
    }
    else
    {
      HashSet<PkixPolicyNode> pkixPolicyNodeSet = new HashSet<PkixPolicyNode>();
      foreach (IEnumerable<PkixPolicyNode> policyNode in policyNodes)
      {
        foreach (PkixPolicyNode pkixPolicyNode4 in policyNode)
        {
          if (Rfc3280CertPathUtilities.ANY_POLICY.Equals(pkixPolicyNode4.ValidPolicy))
          {
            foreach (PkixPolicyNode child in pkixPolicyNode4.Children)
            {
              if (!Rfc3280CertPathUtilities.ANY_POLICY.Equals(child.ValidPolicy))
                pkixPolicyNodeSet.Add(child);
            }
          }
        }
      }
      foreach (PkixPolicyNode _node in pkixPolicyNodeSet)
      {
        if (!userInitialPolicySet.Contains(_node.ValidPolicy))
          validPolicyTree = PkixCertPathValidatorUtilities.RemovePolicyNode(validPolicyTree, policyNodes, _node);
      }
      if (validPolicyTree != null)
      {
        for (int index3 = count - 1; index3 >= 0; --index3)
        {
          IList<PkixPolicyNode> policyNode = policyNodes[index3];
          for (int index4 = 0; index4 < policyNode.Count; ++index4)
          {
            PkixPolicyNode _node = policyNode[index4];
            if (!_node.HasChildren)
              validPolicyTree = PkixCertPathValidatorUtilities.RemovePolicyNode(validPolicyTree, policyNodes, _node);
          }
        }
      }
      pkixPolicyNode1 = validPolicyTree;
    }
    return pkixPolicyNode1;
  }

  internal static void ProcessCrlC(
    X509Crl deltaCRL,
    X509Crl completeCRL,
    PkixParameters pkixParams)
  {
    if (deltaCRL == null)
      return;
    IssuingDistributionPoint instance1;
    try
    {
      instance1 = IssuingDistributionPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) completeCRL, X509Extensions.IssuingDistributionPoint));
    }
    catch (Exception ex)
    {
      throw new Exception("000 Issuing distribution point extension could not be decoded.", ex);
    }
    if (!pkixParams.IsUseDeltasEnabled)
      return;
    if (!deltaCRL.IssuerDN.Equivalent(completeCRL.IssuerDN, true))
      throw new Exception("Complete CRL issuer does not match delta CRL issuer.");
    IssuingDistributionPoint instance2;
    try
    {
      instance2 = IssuingDistributionPoint.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) deltaCRL, X509Extensions.IssuingDistributionPoint));
    }
    catch (Exception ex)
    {
      throw new Exception("Issuing distribution point extension from delta CRL could not be decoded.", ex);
    }
    if (!object.Equals((object) instance1, (object) instance2))
      throw new Exception("Issuing distribution point extension from delta CRL and complete CRL does not match.");
    Asn1Object extensionValue1;
    try
    {
      extensionValue1 = PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) completeCRL, X509Extensions.AuthorityKeyIdentifier);
    }
    catch (Exception ex)
    {
      throw new Exception("Authority key identifier extension could not be extracted from complete CRL.", ex);
    }
    Asn1Object extensionValue2;
    try
    {
      extensionValue2 = PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) deltaCRL, X509Extensions.AuthorityKeyIdentifier);
    }
    catch (Exception ex)
    {
      throw new Exception("Authority key identifier extension could not be extracted from delta CRL.", ex);
    }
    if (extensionValue1 == null)
      throw new Exception("CRL authority key identifier is null.");
    if (extensionValue2 == null)
      throw new Exception("Delta CRL authority key identifier is null.");
    if (!extensionValue1.Equals(extensionValue2))
      throw new Exception("Delta CRL authority key identifier does not match complete CRL authority key identifier.");
  }

  internal static void ProcessCrlI(
    DateTime validDate,
    X509Crl deltacrl,
    object cert,
    CertStatus certStatus,
    PkixParameters pkixParams)
  {
    if (!pkixParams.IsUseDeltasEnabled || deltacrl == null)
      return;
    PkixCertPathValidatorUtilities.GetCertStatus(validDate, deltacrl, cert, certStatus);
  }

  internal static void ProcessCrlJ(
    DateTime validDate,
    X509Crl completecrl,
    object cert,
    CertStatus certStatus)
  {
    if (certStatus.Status != 11)
      return;
    PkixCertPathValidatorUtilities.GetCertStatus(validDate, completecrl, cert, certStatus);
  }

  internal static PkixPolicyNode ProcessCertE(
    PkixCertPath certPath,
    int index,
    PkixPolicyNode validPolicyTree)
  {
    X509Certificate certificate = certPath.Certificates[index];
    Asn1Sequence instance;
    try
    {
      instance = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) certificate, X509Extensions.CertificatePolicies));
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Could not read certificate policies extension from certificate.", ex, index);
    }
    if (instance == null)
      validPolicyTree = (PkixPolicyNode) null;
    return validPolicyTree;
  }
}
