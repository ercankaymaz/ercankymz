// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RolePermissionType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RolePermissionType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_roleId;
  private uint m_permissions;

  public RolePermissionType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_roleId = (NodeId) null;
    this.m_permissions = 0U;
  }

  [DataMember(Name = "RoleId", IsRequired = false, Order = 1)]
  public NodeId RoleId
  {
    get => this.m_roleId;
    set => this.m_roleId = value;
  }

  [DataMember(Name = "Permissions", IsRequired = false, Order = 2)]
  public uint Permissions
  {
    get => this.m_permissions;
    set => this.m_permissions = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RolePermissionType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RolePermissionType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RolePermissionType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RolePermissionType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("RoleId", this.RoleId);
    encoder.WriteUInt32("Permissions", this.Permissions);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RoleId = decoder.ReadNodeId("RoleId");
    this.Permissions = decoder.ReadUInt32("Permissions");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RolePermissionType rolePermissionType && Utils.IsEqual((object) this.m_roleId, (object) rolePermissionType.m_roleId) && Utils.IsEqual((object) this.m_permissions, (object) rolePermissionType.m_permissions);
  }

  public virtual object Clone() => (object) (RolePermissionType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RolePermissionType rolePermissionType = (RolePermissionType) base.MemberwiseClone();
    rolePermissionType.m_roleId = (NodeId) Utils.Clone((object) this.m_roleId);
    rolePermissionType.m_permissions = (uint) Utils.Clone((object) this.m_permissions);
    return (object) rolePermissionType;
  }
}
