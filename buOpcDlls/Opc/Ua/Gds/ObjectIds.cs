// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Gds.ObjectIds
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class ObjectIds
{
  public static readonly ExpandedNodeId OPCUAGDSNamespaceMetadata = new ExpandedNodeId(721U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId DirectoryType_Applications = new ExpandedNodeId(14U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups = new ExpandedNodeId(511U /*0x01FF*/, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup = new ExpandedNodeId(512U /*0x0200*/, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList = new ExpandedNodeId(513U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList = new ExpandedNodeId(547U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList = new ExpandedNodeId(581U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialManagementFolderType_ServiceName_Placeholder = new ExpandedNodeId(61U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId KeyCredentialManagement = new ExpandedNodeId(1008U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId AuthorizationServicesFolderType_ServiceName_Placeholder = new ExpandedNodeId(234U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId AuthorizationServices = new ExpandedNodeId(959U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory = new ExpandedNodeId(141U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_Applications = new ExpandedNodeId(142U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups = new ExpandedNodeId(614U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup = new ExpandedNodeId(615U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultApplicationGroup_TrustList = new ExpandedNodeId(616U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup = new ExpandedNodeId(649U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultHttpsGroup_TrustList = new ExpandedNodeId(650U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup = new ExpandedNodeId(683U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId Directory_CertificateGroups_DefaultUserTokenGroup_TrustList = new ExpandedNodeId(684U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId ApplicationRecordDataType_Encoding_DefaultBinary = new ExpandedNodeId(134U, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId ApplicationRecordDataType_Encoding_DefaultXml = new ExpandedNodeId((uint) sbyte.MaxValue, "http://opcfoundation.org/UA/GDS/");
  public static readonly ExpandedNodeId ApplicationRecordDataType_Encoding_DefaultJson = new ExpandedNodeId(8001U, "http://opcfoundation.org/UA/GDS/");
}
