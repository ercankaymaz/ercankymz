// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubGroupDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PubSubGroupDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private bool m_enabled;
  private MessageSecurityMode m_securityMode;
  private string m_securityGroupId;
  private EndpointDescriptionCollection m_securityKeyServices;
  private uint m_maxNetworkMessageSize;
  private KeyValuePairCollection m_groupProperties;

  public PubSubGroupDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_enabled = true;
    this.m_securityMode = MessageSecurityMode.Invalid;
    this.m_securityGroupId = (string) null;
    this.m_securityKeyServices = new EndpointDescriptionCollection();
    this.m_maxNetworkMessageSize = 0U;
    this.m_groupProperties = new KeyValuePairCollection();
  }

  [DataMember(Name = "Name", IsRequired = false, Order = 1)]
  public string Name
  {
    get => this.m_name;
    set => this.m_name = value;
  }

  [DataMember(Name = "Enabled", IsRequired = false, Order = 2)]
  public bool Enabled
  {
    get => this.m_enabled;
    set => this.m_enabled = value;
  }

  [DataMember(Name = "SecurityMode", IsRequired = false, Order = 3)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(Name = "SecurityGroupId", IsRequired = false, Order = 4)]
  public string SecurityGroupId
  {
    get => this.m_securityGroupId;
    set => this.m_securityGroupId = value;
  }

  [DataMember(Name = "SecurityKeyServices", IsRequired = false, Order = 5)]
  public EndpointDescriptionCollection SecurityKeyServices
  {
    get => this.m_securityKeyServices;
    set
    {
      this.m_securityKeyServices = value;
      if (value != null)
        return;
      this.m_securityKeyServices = new EndpointDescriptionCollection();
    }
  }

  [DataMember(Name = "MaxNetworkMessageSize", IsRequired = false, Order = 6)]
  public uint MaxNetworkMessageSize
  {
    get => this.m_maxNetworkMessageSize;
    set => this.m_maxNetworkMessageSize = value;
  }

  [DataMember(Name = "GroupProperties", IsRequired = false, Order = 7)]
  public KeyValuePairCollection GroupProperties
  {
    get => this.m_groupProperties;
    set
    {
      this.m_groupProperties = value;
      if (value != null)
        return;
      this.m_groupProperties = new KeyValuePairCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PubSubGroupDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubGroupDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubGroupDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubGroupDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteBoolean("Enabled", this.Enabled);
    encoder.WriteEnumerated("SecurityMode", (Enum) this.SecurityMode);
    encoder.WriteString("SecurityGroupId", this.SecurityGroupId);
    encoder.WriteEncodeableArray("SecurityKeyServices", (IList<IEncodeable>) this.SecurityKeyServices.ToArray(), typeof (EndpointDescription));
    encoder.WriteUInt32("MaxNetworkMessageSize", this.MaxNetworkMessageSize);
    encoder.WriteEncodeableArray("GroupProperties", (IList<IEncodeable>) this.GroupProperties.ToArray(), typeof (KeyValuePair));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Enabled = decoder.ReadBoolean("Enabled");
    this.SecurityMode = (MessageSecurityMode) decoder.ReadEnumerated("SecurityMode", typeof (MessageSecurityMode));
    this.SecurityGroupId = decoder.ReadString("SecurityGroupId");
    this.SecurityKeyServices = (EndpointDescriptionCollection) (EndpointDescription[]) decoder.ReadEncodeableArray("SecurityKeyServices", typeof (EndpointDescription));
    this.MaxNetworkMessageSize = decoder.ReadUInt32("MaxNetworkMessageSize");
    this.GroupProperties = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("GroupProperties", typeof (KeyValuePair));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PubSubGroupDataType subGroupDataType && Utils.IsEqual((object) this.m_name, (object) subGroupDataType.m_name) && Utils.IsEqual((object) this.m_enabled, (object) subGroupDataType.m_enabled) && Utils.IsEqual((object) this.m_securityMode, (object) subGroupDataType.m_securityMode) && Utils.IsEqual((object) this.m_securityGroupId, (object) subGroupDataType.m_securityGroupId) && Utils.IsEqual((object) this.m_securityKeyServices, (object) subGroupDataType.m_securityKeyServices) && Utils.IsEqual((object) this.m_maxNetworkMessageSize, (object) subGroupDataType.m_maxNetworkMessageSize) && Utils.IsEqual((object) this.m_groupProperties, (object) subGroupDataType.m_groupProperties);
  }

  public virtual object Clone() => (object) (PubSubGroupDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubGroupDataType subGroupDataType = (PubSubGroupDataType) base.MemberwiseClone();
    subGroupDataType.m_name = (string) Utils.Clone((object) this.m_name);
    subGroupDataType.m_enabled = (bool) Utils.Clone((object) this.m_enabled);
    subGroupDataType.m_securityMode = (MessageSecurityMode) Utils.Clone((object) this.m_securityMode);
    subGroupDataType.m_securityGroupId = (string) Utils.Clone((object) this.m_securityGroupId);
    subGroupDataType.m_securityKeyServices = (EndpointDescriptionCollection) Utils.Clone((object) this.m_securityKeyServices);
    subGroupDataType.m_maxNetworkMessageSize = (uint) Utils.Clone((object) this.m_maxNetworkMessageSize);
    subGroupDataType.m_groupProperties = (KeyValuePairCollection) Utils.Clone((object) this.m_groupProperties);
    return (object) subGroupDataType;
  }
}
