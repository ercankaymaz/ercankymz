// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathValidatorUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.IsisMtt;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Extension;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkix;

internal static class PkixCertPathValidatorUtilities
{
  private static readonly PkixCrlUtilities CrlUtilities = new PkixCrlUtilities();
  internal static readonly string ANY_POLICY = "2.5.29.32.0";
  internal static readonly string CRL_NUMBER = X509Extensions.CrlNumber.Id;
  internal static readonly int KEY_CERT_SIGN = 5;
  internal static readonly int CRL_SIGN = 6;

  internal static TrustAnchor FindTrustAnchor(X509Certificate cert, ISet<TrustAnchor> trustAnchors)
  {
    IEnumerator<TrustAnchor> enumerator = trustAnchors.GetEnumerator();
    TrustAnchor trustAnchor = (TrustAnchor) null;
    AsymmetricKeyParameter key = (AsymmetricKeyParameter) null;
    Exception innerException = (Exception) null;
    X509CertStoreSelector certStoreSelector = new X509CertStoreSelector();
    try
    {
      certStoreSelector.Subject = PkixCertPathValidatorUtilities.GetIssuerPrincipal(cert);
    }
    catch (IOException ex)
    {
      throw new Exception("Cannot set subject search criteria for trust anchor.", (Exception) ex);
    }
    while (enumerator.MoveNext() && trustAnchor == null)
    {
      trustAnchor = enumerator.Current;
      if (trustAnchor.TrustedCert != null)
      {
        if (certStoreSelector.Match(trustAnchor.TrustedCert))
          key = trustAnchor.TrustedCert.GetPublicKey();
        else
          trustAnchor = (TrustAnchor) null;
      }
      else
      {
        if (trustAnchor.CAName != null)
        {
          if (trustAnchor.CAPublicKey != null)
          {
            try
            {
              if (PkixCertPathValidatorUtilities.GetIssuerPrincipal(cert).Equivalent(new X509Name(trustAnchor.CAName), true))
              {
                key = trustAnchor.CAPublicKey;
                goto label_14;
              }
              trustAnchor = (TrustAnchor) null;
              goto label_14;
            }
            catch (InvalidParameterException ex)
            {
              trustAnchor = (TrustAnchor) null;
              goto label_14;
            }
          }
        }
        trustAnchor = (TrustAnchor) null;
      }
label_14:
      if (key != null)
      {
        try
        {
          cert.Verify(key);
        }
        catch (Exception ex)
        {
          innerException = ex;
          trustAnchor = (TrustAnchor) null;
        }
      }
    }
    return trustAnchor != null || innerException == null ? trustAnchor : throw new Exception("TrustAnchor found but certificate validation failed.", innerException);
  }

  internal static bool IsIssuerTrustAnchor(X509Certificate cert, ISet<TrustAnchor> trustAnchors)
  {
    try
    {
      return PkixCertPathValidatorUtilities.FindTrustAnchor(cert, trustAnchors) != null;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  internal static void AddAdditionalStoresFromAltNames(
    X509Certificate cert,
    PkixParameters pkixParams)
  {
    IList<IList<object>> alternativeNames = cert.GetIssuerAlternativeNames();
    if (alternativeNames == null)
      return;
    foreach (IList<object> objectList in (IEnumerable<IList<object>>) alternativeNames)
    {
      if (objectList.Count >= 2 && objectList[0].Equals((object) 6))
        PkixCertPathValidatorUtilities.AddAdditionalStoreFromLocation((string) objectList[1], pkixParams);
    }
  }

  internal static DateTime GetValidDate(PkixParameters paramsPKIX)
  {
    DateTime? date = paramsPKIX.Date;
    return !date.HasValue ? DateTime.UtcNow : date.Value;
  }

  internal static X509Name GetIssuerPrincipal(object obj)
  {
    switch (obj)
    {
      case X509Certificate x509Certificate:
        return x509Certificate.IssuerDN;
      case X509V2AttributeCertificate attributeCertificate:
        return attributeCertificate.Issuer.GetPrincipals()[0];
      default:
        throw new InvalidOperationException();
    }
  }

  internal static X509Name GetIssuerPrincipal(X509V2AttributeCertificate attrCert)
  {
    return attrCert.Issuer.GetPrincipals()[0];
  }

  internal static X509Name GetIssuerPrincipal(X509Certificate cert) => cert.IssuerDN;

  internal static bool IsSelfIssued(X509Certificate cert)
  {
    return cert.SubjectDN.Equivalent(cert.IssuerDN, true);
  }

  internal static AlgorithmIdentifier GetAlgorithmIdentifier(AsymmetricKeyParameter key)
  {
    try
    {
      return SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(key).AlgorithmID;
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Subject public key cannot be decoded.", ex);
    }
  }

  internal static bool IsAnyPolicy(ISet<string> policySet)
  {
    return policySet == null || policySet.Count < 1 || policySet.Contains(PkixCertPathValidatorUtilities.ANY_POLICY);
  }

  internal static void AddAdditionalStoreFromLocation(string location, PkixParameters pkixParams)
  {
    if (!pkixParams.IsAdditionalLocationsEnabled)
      return;
    try
    {
      if (Platform.StartsWith(location, "ldap://"))
      {
        location = location.Substring(7);
        int length = location.IndexOf('/');
        if (length != -1)
        {
          string str1 = "ldap://" + location.Substring(0, length);
        }
        else
        {
          string str2 = "ldap://" + location;
        }
        throw new NotImplementedException("LDAP cert/CRL stores");
      }
    }
    catch (Exception ex)
    {
      throw new Exception("Exception adding X.509 stores.");
    }
  }

  private static BigInteger GetSerialNumber(object cert)
  {
    return cert is X509Certificate ? ((X509Certificate) cert).SerialNumber : ((X509V2AttributeCertificate) cert).SerialNumber;
  }

  internal static HashSet<PolicyQualifierInfo> GetQualifierSet(Asn1Sequence qualifiers)
  {
    HashSet<PolicyQualifierInfo> qualifierSet = new HashSet<PolicyQualifierInfo>();
    if (qualifiers != null)
    {
      foreach (Asn1Encodable qualifier in qualifiers)
      {
        try
        {
          qualifierSet.Add(PolicyQualifierInfo.GetInstance((object) qualifier.ToAsn1Object()));
        }
        catch (IOException ex)
        {
          throw new PkixCertPathValidatorException("Policy qualifier info cannot be decoded.", (Exception) ex);
        }
      }
    }
    return qualifierSet;
  }

  internal static PkixPolicyNode RemovePolicyNode(
    PkixPolicyNode validPolicyTree,
    IList<PkixPolicyNode>[] policyNodes,
    PkixPolicyNode _node)
  {
    PkixPolicyNode parent = _node.Parent;
    if (validPolicyTree == null)
      return (PkixPolicyNode) null;
    if (parent == null)
    {
      for (int index = 0; index < policyNodes.Length; ++index)
        policyNodes[index] = (IList<PkixPolicyNode>) new List<PkixPolicyNode>();
      return (PkixPolicyNode) null;
    }
    parent.RemoveChild(_node);
    PkixCertPathValidatorUtilities.RemovePolicyNodeRecurse(policyNodes, _node);
    return validPolicyTree;
  }

  private static void RemovePolicyNodeRecurse(
    IList<PkixPolicyNode>[] policyNodes,
    PkixPolicyNode _node)
  {
    policyNodes[_node.Depth].Remove(_node);
    if (!_node.HasChildren)
      return;
    foreach (PkixPolicyNode child in _node.Children)
      PkixCertPathValidatorUtilities.RemovePolicyNodeRecurse(policyNodes, child);
  }

  internal static void PrepareNextCertB1(
    int i,
    IList<PkixPolicyNode>[] policyNodes,
    string id_p,
    IDictionary<string, HashSet<string>> m_idp,
    X509Certificate cert)
  {
    foreach (PkixPolicyNode pkixPolicyNode in (IEnumerable<PkixPolicyNode>) policyNodes[i])
    {
      if (pkixPolicyNode.ValidPolicy.Equals(id_p))
      {
        pkixPolicyNode.ExpectedPolicies = (ISet<string>) CollectionUtilities.GetValueOrNull<string, HashSet<string>>(m_idp, id_p);
        return;
      }
    }
    foreach (PkixPolicyNode pkixPolicyNode in (IEnumerable<PkixPolicyNode>) policyNodes[i])
    {
      if (PkixCertPathValidatorUtilities.ANY_POLICY.Equals(pkixPolicyNode.ValidPolicy))
      {
        Asn1Sequence instance1;
        try
        {
          instance1 = Asn1Sequence.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) cert, X509Extensions.CertificatePolicies));
        }
        catch (Exception ex)
        {
          throw new Exception("Certificate policies cannot be decoded.", ex);
        }
        ISet<PolicyQualifierInfo> policyQualifiers = (ISet<PolicyQualifierInfo>) null;
        foreach (Asn1Encodable asn1Encodable in instance1)
        {
          PolicyInformation instance2;
          try
          {
            instance2 = PolicyInformation.GetInstance((object) asn1Encodable);
          }
          catch (Exception ex)
          {
            throw new Exception("Policy information cannot be decoded.", ex);
          }
          if (PkixCertPathValidatorUtilities.ANY_POLICY.Equals(instance2.PolicyIdentifier.Id))
          {
            try
            {
              policyQualifiers = (ISet<PolicyQualifierInfo>) PkixCertPathValidatorUtilities.GetQualifierSet(instance2.PolicyQualifiers);
              break;
            }
            catch (PkixCertPathValidatorException ex)
            {
              throw new PkixCertPathValidatorException("Policy qualifier info set could not be built.", (Exception) ex);
            }
          }
        }
        bool critical = false;
        ISet<string> criticalExtensionOids = cert.GetCriticalExtensionOids();
        if (criticalExtensionOids != null)
          critical = criticalExtensionOids.Contains(X509Extensions.CertificatePolicies.Id);
        PkixPolicyNode parent = pkixPolicyNode.Parent;
        if (!PkixCertPathValidatorUtilities.ANY_POLICY.Equals(parent.ValidPolicy))
          break;
        PkixPolicyNode child = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), i, (ISet<string>) CollectionUtilities.GetValueOrNull<string, HashSet<string>>(m_idp, id_p), parent, policyQualifiers, id_p, critical);
        parent.AddChild(child);
        policyNodes[i].Add(child);
        break;
      }
    }
  }

  internal static PkixPolicyNode PrepareNextCertB2(
    int i,
    IList<PkixPolicyNode>[] policyNodes,
    string id_p,
    PkixPolicyNode validPolicyTree)
  {
    int index1 = 0;
    foreach (PkixPolicyNode child in new List<PkixPolicyNode>((IEnumerable<PkixPolicyNode>) policyNodes[i]))
    {
      if (!child.ValidPolicy.Equals(id_p))
      {
        ++index1;
      }
      else
      {
        child.Parent.RemoveChild(child);
        policyNodes[i].RemoveAt(index1);
        for (int index2 = i - 1; index2 >= 0; --index2)
        {
          IList<PkixPolicyNode> policyNode = policyNodes[index2];
          for (int index3 = 0; index3 < policyNode.Count; ++index3)
          {
            PkixPolicyNode _node = policyNode[index3];
            if (!_node.HasChildren)
            {
              validPolicyTree = PkixCertPathValidatorUtilities.RemovePolicyNode(validPolicyTree, policyNodes, _node);
              if (validPolicyTree == null)
                break;
            }
          }
        }
      }
    }
    return validPolicyTree;
  }

  internal static void GetCertStatus(
    DateTime validDate,
    X509Crl crl,
    object cert,
    CertStatus certStatus)
  {
    X509Crl x509Crl;
    try
    {
      x509Crl = new X509Crl(CertificateList.GetInstance((object) (Asn1Sequence) Asn1Object.FromByteArray(crl.GetEncoded())));
    }
    catch (Exception ex)
    {
      throw new Exception("X509Crl could not be created.", ex);
    }
    X509CrlEntry revokedCertificate = x509Crl.GetRevokedCertificate(PkixCertPathValidatorUtilities.GetSerialNumber(cert));
    if (revokedCertificate == null)
      return;
    X509Name issuerPrincipal = PkixCertPathValidatorUtilities.GetIssuerPrincipal(cert);
    if (!issuerPrincipal.Equivalent(revokedCertificate.GetCertificateIssuer(), true) && !issuerPrincipal.Equivalent(crl.IssuerDN, true))
      return;
    int num = 0;
    if (revokedCertificate.HasExtensions)
    {
      try
      {
        DerEnumerated instance = DerEnumerated.GetInstance((object) PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) revokedCertificate, X509Extensions.ReasonCode));
        if (instance != null)
          num = instance.IntValueExact;
      }
      catch (Exception ex)
      {
        throw new Exception("Reason code CRL entry extension could not be decoded.", ex);
      }
    }
    DateTime revocationDate = revokedCertificate.RevocationDate;
    if (validDate.Ticks < revocationDate.Ticks)
    {
      switch (num)
      {
        case 0:
        case 1:
        case 2:
        case 10:
          break;
        default:
          return;
      }
    }
    certStatus.Status = num;
    certStatus.RevocationDate = new DateTime?(revocationDate);
  }

  internal static AsymmetricKeyParameter GetNextWorkingKey(IList<X509Certificate> certs, int index)
  {
    AsymmetricKeyParameter publicKey1 = certs[index].GetPublicKey();
    if (!(publicKey1 is DsaPublicKeyParameters))
      return publicKey1;
    DsaPublicKeyParameters nextWorkingKey = (DsaPublicKeyParameters) publicKey1;
    if (nextWorkingKey.Parameters != null)
      return (AsymmetricKeyParameter) nextWorkingKey;
    for (int index1 = index + 1; index1 < certs.Count; ++index1)
    {
      AsymmetricKeyParameter publicKey2 = certs[index1].GetPublicKey();
      DsaPublicKeyParameters publicKeyParameters = publicKey2 is DsaPublicKeyParameters ? (DsaPublicKeyParameters) publicKey2 : throw new PkixCertPathValidatorException("DSA parameters cannot be inherited from previous certificate.");
      if (publicKeyParameters.Parameters != null)
      {
        DsaParameters parameters = publicKeyParameters.Parameters;
        try
        {
          return (AsymmetricKeyParameter) new DsaPublicKeyParameters(nextWorkingKey.Y, parameters);
        }
        catch (Exception ex)
        {
          throw new Exception(ex.Message);
        }
      }
    }
    throw new PkixCertPathValidatorException("DSA parameters cannot be inherited from previous certificate.");
  }

  internal static DateTime GetValidCertDateFromValidityModel(
    PkixParameters paramsPkix,
    PkixCertPath certPath,
    int index)
  {
    if (1 != paramsPkix.ValidityModel || index <= 0)
      return PkixCertPathValidatorUtilities.GetValidDate(paramsPkix);
    X509Certificate certificate = certPath.Certificates[index - 1];
    if (index - 1 == 0)
    {
      Asn1GeneralizedTime asn1GeneralizedTime = (Asn1GeneralizedTime) null;
      try
      {
        byte[] octets = certificate.GetExtensionValue(IsisMttObjectIdentifiers.IdIsisMttATDateOfCertGen)?.GetOctets();
        if (octets != null)
          asn1GeneralizedTime = Asn1GeneralizedTime.GetInstance((object) octets);
      }
      catch (ArgumentException ex)
      {
        throw new Exception("Date of cert gen extension could not be read.", (Exception) ex);
      }
      if (asn1GeneralizedTime != null)
      {
        try
        {
          return asn1GeneralizedTime.ToDateTime();
        }
        catch (ArgumentException ex)
        {
          throw new Exception("Date from date of cert gen extension could not be parsed.", (Exception) ex);
        }
      }
    }
    return certificate.NotBefore;
  }

  internal static void GetCrlIssuersFromDistributionPoint(
    DistributionPoint dp,
    ICollection<X509Name> issuerPrincipals,
    X509CrlStoreSelector selector,
    PkixParameters pkixParameters)
  {
    List<X509Name> x509NameList = new List<X509Name>();
    if (dp.CrlIssuer != null)
    {
      GeneralName[] names = dp.CrlIssuer.GetNames();
      for (int index = 0; index < names.Length; ++index)
      {
        if (names[index].TagNo == 4)
        {
          try
          {
            x509NameList.Add(X509Name.GetInstance((object) names[index].Name.ToAsn1Object()));
          }
          catch (IOException ex)
          {
            throw new Exception("CRL issuer information from distribution point cannot be decoded.", (Exception) ex);
          }
        }
      }
    }
    else
    {
      if (dp.DistributionPointName == null)
        throw new Exception("CRL issuer is omitted from distribution point but no distributionPoint field present.");
      x509NameList.AddRange((IEnumerable<X509Name>) issuerPrincipals);
    }
    selector.Issuers = (IList<X509Name>) x509NameList;
  }

  internal static ISet<X509Crl> GetCompleteCrls(
    DistributionPoint dp,
    object certObj,
    DateTime currentDate,
    PkixParameters pkixParameters)
  {
    X509Name issuerPrincipal = PkixCertPathValidatorUtilities.GetIssuerPrincipal(certObj);
    X509CrlStoreSelector crlStoreSelector = new X509CrlStoreSelector();
    try
    {
      PkixCertPathValidatorUtilities.GetCrlIssuersFromDistributionPoint(dp, (ICollection<X509Name>) new HashSet<X509Name>()
      {
        issuerPrincipal
      }, crlStoreSelector, pkixParameters);
    }
    catch (Exception ex)
    {
      throw new Exception("Could not get issuer information from distribution point.", ex);
    }
    switch (certObj)
    {
      case X509Certificate x509Certificate:
        crlStoreSelector.CertificateChecking = x509Certificate;
        break;
      case X509V2AttributeCertificate attributeCertificate:
        crlStoreSelector.AttrCertChecking = attributeCertificate;
        break;
    }
    crlStoreSelector.CompleteCrlEnabled = true;
    ISet<X509Crl> crls = PkixCertPathValidatorUtilities.CrlUtilities.FindCrls(crlStoreSelector, pkixParameters, currentDate);
    return crls.Count >= 1 ? crls : throw new Exception($"No CRLs found for issuer \"{issuerPrincipal?.ToString()}\"");
  }

  internal static HashSet<X509Crl> GetDeltaCrls(
    DateTime currentDate,
    PkixParameters pkixParameters,
    X509Crl completeCRL)
  {
    X509CrlStoreSelector crlSelector = new X509CrlStoreSelector();
    try
    {
      crlSelector.Issuers = (IList<X509Name>) new List<X509Name>()
      {
        completeCRL.IssuerDN
      };
    }
    catch (IOException ex)
    {
      throw new Exception("Cannot extract issuer from CRL.", (Exception) ex);
    }
    BigInteger bigInteger = (BigInteger) null;
    try
    {
      Asn1Object extensionValue = PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) completeCRL, X509Extensions.CrlNumber);
      if (extensionValue != null)
        bigInteger = DerInteger.GetInstance((object) extensionValue).PositiveValue;
    }
    catch (Exception ex)
    {
      throw new Exception("CRL number extension could not be extracted from CRL.", ex);
    }
    byte[] numArray = (byte[]) null;
    try
    {
      Asn1Object extensionValue = PkixCertPathValidatorUtilities.GetExtensionValue((IX509Extension) completeCRL, X509Extensions.IssuingDistributionPoint);
      if (extensionValue != null)
        numArray = extensionValue.GetDerEncoded();
    }
    catch (Exception ex)
    {
      throw new Exception("Issuing distribution point extension value could not be read.", ex);
    }
    crlSelector.MinCrlNumber = bigInteger == null ? (BigInteger) null : bigInteger.Add(BigInteger.One);
    crlSelector.IssuingDistributionPoint = numArray;
    crlSelector.IssuingDistributionPointEnabled = true;
    crlSelector.MaxBaseCrlNumber = bigInteger;
    ISet<X509Crl> crls = PkixCertPathValidatorUtilities.CrlUtilities.FindCrls(crlSelector, pkixParameters, currentDate);
    HashSet<X509Crl> deltaCrls = new HashSet<X509Crl>();
    foreach (X509Crl crl in (IEnumerable<X509Crl>) crls)
    {
      if (PkixCertPathValidatorUtilities.IsDeltaCrl(crl))
        deltaCrls.Add(crl);
    }
    return deltaCrls;
  }

  private static bool IsDeltaCrl(X509Crl crl)
  {
    return crl.GetCriticalExtensionOids().Contains(X509Extensions.DeltaCrlIndicator.Id);
  }

  internal static void AddAdditionalStoresFromCrlDistributionPoint(
    CrlDistPoint crldp,
    PkixParameters pkixParams)
  {
    if (crldp == null)
      return;
    DistributionPoint[] distributionPoints;
    try
    {
      distributionPoints = crldp.GetDistributionPoints();
    }
    catch (Exception ex)
    {
      throw new Exception("Distribution points could not be read.", ex);
    }
    for (int index1 = 0; index1 < distributionPoints.Length; ++index1)
    {
      DistributionPointName distributionPointName = distributionPoints[index1].DistributionPointName;
      if (distributionPointName != null && distributionPointName.Type == 0)
      {
        GeneralName[] names = GeneralNames.GetInstance((object) distributionPointName.Name).GetNames();
        for (int index2 = 0; index2 < names.Length; ++index2)
        {
          if (names[index2].TagNo == 6)
            PkixCertPathValidatorUtilities.AddAdditionalStoreFromLocation(DerIA5String.GetInstance((object) names[index2].Name).GetString(), pkixParams);
        }
      }
    }
  }

  internal static bool ProcessCertD1i(
    int index,
    IList<PkixPolicyNode>[] policyNodes,
    DerObjectIdentifier pOid,
    HashSet<PolicyQualifierInfo> pq)
  {
    foreach (PkixPolicyNode parent in (IEnumerable<PkixPolicyNode>) policyNodes[index - 1])
    {
      if (parent.ExpectedPolicies.Contains(pOid.Id))
      {
        PkixPolicyNode child = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), index, (ISet<string>) new HashSet<string>()
        {
          pOid.Id
        }, parent, (ISet<PolicyQualifierInfo>) pq, pOid.Id, false);
        parent.AddChild(child);
        policyNodes[index].Add(child);
        return true;
      }
    }
    return false;
  }

  internal static void ProcessCertD1ii(
    int index,
    IList<PkixPolicyNode>[] policyNodes,
    DerObjectIdentifier _poid,
    HashSet<PolicyQualifierInfo> _pq)
  {
    foreach (PkixPolicyNode parent in (IEnumerable<PkixPolicyNode>) policyNodes[index - 1])
    {
      if (PkixCertPathValidatorUtilities.ANY_POLICY.Equals(parent.ValidPolicy))
      {
        PkixPolicyNode child = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), index, (ISet<string>) new HashSet<string>()
        {
          _poid.Id
        }, parent, (ISet<PolicyQualifierInfo>) _pq, _poid.Id, false);
        parent.AddChild(child);
        policyNodes[index].Add(child);
        break;
      }
    }
  }

  internal static HashSet<X509Certificate> FindIssuerCerts(
    X509Certificate cert,
    PkixBuilderParameters pkixBuilderParameters)
  {
    X509CertStoreSelector certStoreSelector = new X509CertStoreSelector();
    try
    {
      certStoreSelector.Subject = cert.IssuerDN;
    }
    catch (IOException ex)
    {
      throw new Exception("Subject criteria for certificate selector to find issuer certificate could not be set.", (Exception) ex);
    }
    HashSet<X509Certificate> matches = new HashSet<X509Certificate>();
    try
    {
      CollectionUtilities.CollectMatches<X509Certificate>((ICollection<X509Certificate>) matches, (ISelector<X509Certificate>) certStoreSelector, (IEnumerable<IStore<X509Certificate>>) pkixBuilderParameters.GetStoresCert());
    }
    catch (Exception ex)
    {
      throw new Exception("Issuer certificate cannot be searched.", ex);
    }
    return matches;
  }

  internal static Asn1Object GetExtensionValue(IX509Extension extensions, DerObjectIdentifier oid)
  {
    return X509ExtensionUtilities.FromExtensionValue(extensions, oid);
  }
}
