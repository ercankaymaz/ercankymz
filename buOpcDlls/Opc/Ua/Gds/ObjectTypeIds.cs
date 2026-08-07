// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Gds.ObjectTypeIds
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ObjectTypeIds
{
  public static readonly ExpandedNodeId DirectoryType = new ExpandedNodeId(13U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId ApplicationRegistrationChangedAuditEventType = new ExpandedNodeId(26U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDirectoryType = new ExpandedNodeId(63U /*0x3F*/, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateRequestedAuditEventType = new ExpandedNodeId(91U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDeliveredAuditEventType = new ExpandedNodeId(109U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialManagementFolderType = new ExpandedNodeId(55U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialServiceType = new ExpandedNodeId(1020U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialRequestedAuditEventType = new ExpandedNodeId(1039U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialDeliveredAuditEventType = new ExpandedNodeId(1057U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialRevokedAuditEventType = new ExpandedNodeId(1075U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId AuthorizationServicesFolderType = new ExpandedNodeId(233U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId AuthorizationServiceType = new ExpandedNodeId(966U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId AccessTokenIssuedAuditEventType = new ExpandedNodeId(975U, "http://opcfoundation.org/UA/GDS/");
}
