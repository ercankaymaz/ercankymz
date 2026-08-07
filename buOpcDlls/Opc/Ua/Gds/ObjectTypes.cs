// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Gds.ObjectTypes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ObjectTypes
{
  public const uint DirectoryType = 13;
  public const uint ApplicationRegistrationChangedAuditEventType = 26;
  public const uint CertificateDirectoryType = 63 /*0x3F*/;
  public const uint CertificateRequestedAuditEventType = 91;
  public const uint CertificateDeliveredAuditEventType = 109;
  public const uint KeyCredentialManagementFolderType = 55;
  public const uint KeyCredentialServiceType = 1020;
  public const uint KeyCredentialRequestedAuditEventType = 1039;
  public const uint KeyCredentialDeliveredAuditEventType = 1057;
  public const uint KeyCredentialRevokedAuditEventType = 1075;
  public const uint AuthorizationServicesFolderType = 233;
  public const uint AuthorizationServiceType = 966;
  public const uint AccessTokenIssuedAuditEventType = 975;
}
