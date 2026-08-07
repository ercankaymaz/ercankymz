// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscribedDataSetMirrorDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SubscribedDataSetMirrorDataType : SubscribedDataSetDataType
{
  private string m_parentNodeName;
  private RolePermissionTypeCollection m_rolePermissions;

  public SubscribedDataSetMirrorDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_parentNodeName = (string) null;
    this.m_rolePermissions = new RolePermissionTypeCollection();
  }

  [DataMember(Name = "ParentNodeName", IsRequired = false, Order = 1)]
  public string ParentNodeName
  {
    get => this.m_parentNodeName;
    set => this.m_parentNodeName = value;
  }

  [DataMember(Name = "RolePermissions", IsRequired = false, Order = 2)]
  public RolePermissionTypeCollection RolePermissions
  {
    get => this.m_rolePermissions;
    set
    {
      this.m_rolePermissions = value;
      if (value != null)
        return;
      this.m_rolePermissions = new RolePermissionTypeCollection();
    }
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.SubscribedDataSetMirrorDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscribedDataSetMirrorDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscribedDataSetMirrorDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscribedDataSetMirrorDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ParentNodeName", this.ParentNodeName);
    encoder.WriteEncodeableArray("RolePermissions", (IList<IEncodeable>) this.RolePermissions.ToArray(), typeof (RolePermissionType));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ParentNodeName = decoder.ReadString("ParentNodeName");
    this.RolePermissions = (RolePermissionTypeCollection) (RolePermissionType[]) decoder.ReadEncodeableArray("RolePermissions", typeof (RolePermissionType));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is SubscribedDataSetMirrorDataType setMirrorDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_parentNodeName, (object) setMirrorDataType.m_parentNodeName) && Utils.IsEqual((object) this.m_rolePermissions, (object) setMirrorDataType.m_rolePermissions) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (SubscribedDataSetMirrorDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SubscribedDataSetMirrorDataType setMirrorDataType = (SubscribedDataSetMirrorDataType) base.MemberwiseClone();
    setMirrorDataType.m_parentNodeName = (string) Utils.Clone((object) this.m_parentNodeName);
    setMirrorDataType.m_rolePermissions = (RolePermissionTypeCollection) Utils.Clone((object) this.m_rolePermissions);
    return (object) setMirrorDataType;
  }
}
