// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixAttrCertPathValidator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Store;
using System;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixAttrCertPathValidator
{
  public virtual PkixCertPathValidatorResult Validate(
    PkixCertPath certPath,
    PkixParameters pkixParams)
  {
    X509V2AttributeCertificate attrCert = pkixParams.GetTargetConstraintsAttrCert() is X509AttrCertStoreSelector constraintsAttrCert ? constraintsAttrCert.AttributeCert : throw new ArgumentException("TargetConstraints must be an instance of " + typeof (X509AttrCertStoreSelector).FullName, nameof (pkixParams));
    PkixCertPath holderCertPath = Rfc3281CertPathUtilities.ProcessAttrCert1(attrCert, pkixParams);
    PkixCertPathValidatorResult pathValidatorResult = Rfc3281CertPathUtilities.ProcessAttrCert2(certPath, pkixParams);
    X509Certificate certificate = certPath.Certificates[0];
    Rfc3281CertPathUtilities.ProcessAttrCert3(certificate, pkixParams);
    Rfc3281CertPathUtilities.ProcessAttrCert4(certificate, pkixParams);
    Rfc3281CertPathUtilities.ProcessAttrCert5(attrCert, pkixParams);
    Rfc3281CertPathUtilities.ProcessAttrCert7(attrCert, certPath, holderCertPath, pkixParams);
    Rfc3281CertPathUtilities.AdditionalChecks(attrCert, pkixParams);
    DateTime fromValidityModel;
    try
    {
      fromValidityModel = PkixCertPathValidatorUtilities.GetValidCertDateFromValidityModel(pkixParams, (PkixCertPath) null, -1);
    }
    catch (Exception ex)
    {
      throw new PkixCertPathValidatorException("Could not get validity date from attribute certificate.", ex);
    }
    Rfc3281CertPathUtilities.CheckCrls(attrCert, pkixParams, certificate, fromValidityModel, certPath.Certificates);
    return pathValidatorResult;
  }
}
