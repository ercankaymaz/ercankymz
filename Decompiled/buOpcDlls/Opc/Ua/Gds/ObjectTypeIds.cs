using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ObjectTypeIds
{
	public static readonly ExpandedNodeId DirectoryType = new ExpandedNodeId(13u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId ApplicationRegistrationChangedAuditEventType = new ExpandedNodeId(26u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId CertificateDirectoryType = new ExpandedNodeId(63u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId CertificateRequestedAuditEventType = new ExpandedNodeId(91u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId CertificateDeliveredAuditEventType = new ExpandedNodeId(109u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId KeyCredentialManagementFolderType = new ExpandedNodeId(55u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId KeyCredentialServiceType = new ExpandedNodeId(1020u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId KeyCredentialRequestedAuditEventType = new ExpandedNodeId(1039u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId KeyCredentialDeliveredAuditEventType = new ExpandedNodeId(1057u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId KeyCredentialRevokedAuditEventType = new ExpandedNodeId(1075u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId AuthorizationServicesFolderType = new ExpandedNodeId(233u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId AuthorizationServiceType = new ExpandedNodeId(966u, "http://opcfoundation.org/UA/GDS/");

	public static readonly ExpandedNodeId AccessTokenIssuedAuditEventType = new ExpandedNodeId(975u, "http://opcfoundation.org/UA/GDS/");
}
