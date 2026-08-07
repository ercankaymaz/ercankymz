// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Configuration.IApplicationConfigurationBuilderSecurityOptions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderSecurityOptions : 
  IApplicationConfigurationBuilderTraceConfiguration,
  IApplicationConfigurationBuilderCreate,
  IApplicationConfigurationBuilderExtension
{
  IApplicationConfigurationBuilderSecurityOptions SetAutoAcceptUntrustedCertificates(bool autoAccept);

  IApplicationConfigurationBuilderSecurityOptions SetAddAppCertToTrustedStore(bool addToTrustedStore);

  IApplicationConfigurationBuilderSecurityOptions SetRejectSHA1SignedCertificates(
    bool rejectSHA1Signed);

  IApplicationConfigurationBuilderSecurityOptions SetRejectUnknownRevocationStatus(
    bool rejectUnknownRevocationStatus);

  IApplicationConfigurationBuilderSecurityOptions SetUseValidatedCertificates(
    bool useValidatedCertificates);

  IApplicationConfigurationBuilderSecurityOptions SetSuppressNonceValidationErrors(
    bool suppressNonceValidationErrors);

  IApplicationConfigurationBuilderSecurityOptions SetSendCertificateChain(bool sendCertificateChain);

  IApplicationConfigurationBuilderSecurityOptions SetMinimumCertificateKeySize(ushort keySize);

  IApplicationConfigurationBuilderSecurityOptions AddCertificatePasswordProvider(
    ICertificatePasswordProvider certificatePasswordProvider);
}
