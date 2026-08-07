// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IdentityCriteriaType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum IdentityCriteriaType
{
  [EnumMember(Value = "UserName_1")] UserName = 1,
  [EnumMember(Value = "Thumbprint_2")] Thumbprint = 2,
  [EnumMember(Value = "Role_3")] Role = 3,
  [EnumMember(Value = "GroupId_4")] GroupId = 4,
  [EnumMember(Value = "Anonymous_5")] Anonymous = 5,
  [EnumMember(Value = "AuthenticatedUser_6")] AuthenticatedUser = 6,
  [EnumMember(Value = "Application_7")] Application = 7,
}
