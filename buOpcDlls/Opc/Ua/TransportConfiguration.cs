// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransportConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class TransportConfiguration
{
  private string m_uriScheme;
  private string m_typeName;

  public TransportConfiguration()
  {
  }

  public TransportConfiguration(string urlScheme, Type type)
  {
    this.m_uriScheme = urlScheme;
    this.m_typeName = type.AssemblyQualifiedName;
  }

  [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 0)]
  public string UriScheme
  {
    get => this.m_uriScheme;
    set => this.m_uriScheme = value;
  }

  [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
  public string TypeName
  {
    get => this.m_typeName;
    set => this.m_typeName = value;
  }
}
