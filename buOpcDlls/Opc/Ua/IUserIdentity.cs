// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IUserIdentity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IUserIdentity
{
  string DisplayName { get; }

  string PolicyId { get; }

  UserTokenType TokenType { get; }

  XmlQualifiedName IssuedTokenType { get; }

  bool SupportsSignatures { get; }

  NodeIdCollection GrantedRoleIds { get; set; }

  UserIdentityToken GetIdentityToken();
}
