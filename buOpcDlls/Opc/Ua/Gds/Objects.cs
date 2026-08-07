// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Gds.Objects
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public static class Objects
{
  public const uint OPCUAGDSNamespaceMetadata = 721;
  public const uint DirectoryType_Applications = 14;
  public const uint CertificateDirectoryType_CertificateGroups = 511 /*0x01FF*/;
  public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup = 512 /*0x0200*/;
  public const uint CertificateDirectoryType_CertificateGroups_DefaultApplicationGroup_TrustList = 513;
  public const uint CertificateDirectoryType_CertificateGroups_DefaultHttpsGroup_TrustList = 547;
  public const uint CertificateDirectoryType_CertificateGroups_DefaultUserTokenGroup_TrustList = 581;
  public const uint KeyCredentialManagementFolderType_ServiceName_Placeholder = 61;
  public const uint KeyCredentialManagement = 1008;
  public const uint AuthorizationServicesFolderType_ServiceName_Placeholder = 234;
  public const uint AuthorizationServices = 959;
  public const uint Directory = 141;
  public const uint Directory_Applications = 142;
  public const uint Directory_CertificateGroups = 614;
  public const uint Directory_CertificateGroups_DefaultApplicationGroup = 615;
  public const uint Directory_CertificateGroups_DefaultApplicationGroup_TrustList = 616;
  public const uint Directory_CertificateGroups_DefaultHttpsGroup = 649;
  public const uint Directory_CertificateGroups_DefaultHttpsGroup_TrustList = 650;
  public const uint Directory_CertificateGroups_DefaultUserTokenGroup = 683;
  public const uint Directory_CertificateGroups_DefaultUserTokenGroup_TrustList = 684;
  public const uint ApplicationRecordDataType_Encoding_DefaultBinary = 134;
  public const uint ApplicationRecordDataType_Encoding_DefaultXml = 127 /*0x7F*/;
  public const uint ApplicationRecordDataType_Encoding_DefaultJson = 8001;
}
