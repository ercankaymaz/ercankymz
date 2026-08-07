// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.SecurityConfigurationManagerFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Security;

[ComVisible(true)]
public static class SecurityConfigurationManagerFactory
{
  public static ISecurityConfigurationManager CreateInstance(string typeName)
  {
    if (string.IsNullOrEmpty(typeName))
      return (ISecurityConfigurationManager) new SecurityConfigurationManager();
    Type type = Type.GetType(typeName);
    if (type == (Type) null)
      throw ServiceResultException.Create(2151481344U /*0x803D0000*/, "Cannot load type: {0}", (object) typeName);
    return Activator.CreateInstance(type) is ISecurityConfigurationManager instance ? instance : throw ServiceResultException.Create(2151481344U /*0x803D0000*/, "Type does not support the ISecurityConfigurationManager interface: {0}", (object) typeName);
  }
}
