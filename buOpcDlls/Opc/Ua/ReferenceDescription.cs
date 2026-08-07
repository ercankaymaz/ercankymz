// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceDescription
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
public class ReferenceDescription : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
  private Opc.Ua.NodeId m_referenceTypeId;
  private bool m_isForward;
  private ExpandedNodeId m_nodeId;
  private QualifiedName m_browseName;
  private LocalizedText m_displayName;
  private NodeClass m_nodeClass;
  private ExpandedNodeId m_typeDefinition;
  private bool m_unfiltered;

  public ReferenceDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_referenceTypeId = (Opc.Ua.NodeId) null;
    this.m_isForward = true;
    this.m_nodeId = (ExpandedNodeId) null;
    this.m_browseName = (QualifiedName) null;
    this.m_displayName = (LocalizedText) null;
    this.m_nodeClass = NodeClass.Unspecified;
    this.m_typeDefinition = (ExpandedNodeId) null;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 1)]
  public Opc.Ua.NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "IsForward", IsRequired = false, Order = 2)]
  public bool IsForward
  {
    get => this.m_isForward;
    set => this.m_isForward = value;
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 3)]
  public ExpandedNodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "BrowseName", IsRequired = false, Order = 4)]
  public QualifiedName BrowseName
  {
    get => this.m_browseName;
    set => this.m_browseName = value;
  }

  [DataMember(Name = "DisplayName", IsRequired = false, Order = 5)]
  public LocalizedText DisplayName
  {
    get => this.m_displayName;
    set => this.m_displayName = value;
  }

  [DataMember(Name = "NodeClass", IsRequired = false, Order = 6)]
  public NodeClass NodeClass
  {
    get => this.m_nodeClass;
    set => this.m_nodeClass = value;
  }

  [DataMember(Name = "TypeDefinition", IsRequired = false, Order = 7)]
  public ExpandedNodeId TypeDefinition
  {
    get => this.m_typeDefinition;
    set => this.m_typeDefinition = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReferenceDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IsForward", this.IsForward);
    encoder.WriteExpandedNodeId("NodeId", this.NodeId);
    encoder.WriteQualifiedName("BrowseName", this.BrowseName);
    encoder.WriteLocalizedText("DisplayName", this.DisplayName);
    encoder.WriteEnumerated("NodeClass", (Enum) this.NodeClass);
    encoder.WriteExpandedNodeId("TypeDefinition", this.TypeDefinition);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IsForward = decoder.ReadBoolean("IsForward");
    this.NodeId = decoder.ReadExpandedNodeId("NodeId");
    this.BrowseName = decoder.ReadQualifiedName("BrowseName");
    this.DisplayName = decoder.ReadLocalizedText("DisplayName");
    this.NodeClass = (NodeClass) decoder.ReadEnumerated("NodeClass", typeof (NodeClass));
    this.TypeDefinition = decoder.ReadExpandedNodeId("TypeDefinition");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ReferenceDescription referenceDescription && Utils.IsEqual((object) this.m_referenceTypeId, (object) referenceDescription.m_referenceTypeId) && Utils.IsEqual((object) this.m_isForward, (object) referenceDescription.m_isForward) && Utils.IsEqual((object) this.m_nodeId, (object) referenceDescription.m_nodeId) && Utils.IsEqual((object) this.m_browseName, (object) referenceDescription.m_browseName) && Utils.IsEqual((object) this.m_displayName, (object) referenceDescription.m_displayName) && Utils.IsEqual((object) this.m_nodeClass, (object) referenceDescription.m_nodeClass) && Utils.IsEqual((object) this.m_typeDefinition, (object) referenceDescription.m_typeDefinition);
  }

  public virtual object Clone() => (object) (ReferenceDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReferenceDescription referenceDescription = (ReferenceDescription) base.MemberwiseClone();
    referenceDescription.m_referenceTypeId = (Opc.Ua.NodeId) Utils.Clone((object) this.m_referenceTypeId);
    referenceDescription.m_isForward = (bool) Utils.Clone((object) this.m_isForward);
    referenceDescription.m_nodeId = (ExpandedNodeId) Utils.Clone((object) this.m_nodeId);
    referenceDescription.m_browseName = (QualifiedName) Utils.Clone((object) this.m_browseName);
    referenceDescription.m_displayName = (LocalizedText) Utils.Clone((object) this.m_displayName);
    referenceDescription.m_nodeClass = (NodeClass) Utils.Clone((object) this.m_nodeClass);
    referenceDescription.m_typeDefinition = (ExpandedNodeId) Utils.Clone((object) this.m_typeDefinition);
    return (object) referenceDescription;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      if (this.m_displayName != (LocalizedText) null && !string.IsNullOrEmpty(this.m_displayName.Text))
        return this.m_displayName.Text;
      if (!QualifiedName.IsNull(this.m_browseName))
        return this.m_browseName.Name;
      return Utils.Format("(unknown {0})", (object) this.m_nodeClass.ToString().ToLower());
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public void SetReferenceType(BrowseResultMask resultMask, Opc.Ua.NodeId referenceTypeId, bool isForward)
  {
    this.m_referenceTypeId = (resultMask & BrowseResultMask.ReferenceTypeId) == BrowseResultMask.None ? (Opc.Ua.NodeId) null : referenceTypeId;
    if ((resultMask & BrowseResultMask.IsForward) != BrowseResultMask.None)
      this.m_isForward = isForward;
    else
      this.m_isForward = false;
  }

  public void SetTargetAttributes(
    BrowseResultMask resultMask,
    NodeClass nodeClass,
    QualifiedName browseName,
    LocalizedText displayName,
    ExpandedNodeId typeDefinition)
  {
    this.m_nodeClass = (resultMask & BrowseResultMask.NodeClass) == BrowseResultMask.None ? NodeClass.Unspecified : nodeClass;
    this.m_browseName = (resultMask & BrowseResultMask.BrowseName) == BrowseResultMask.None ? (QualifiedName) null : browseName;
    this.m_displayName = (resultMask & BrowseResultMask.DisplayName) == BrowseResultMask.None ? (LocalizedText) null : displayName;
    if ((resultMask & BrowseResultMask.TypeDefinition) != BrowseResultMask.None)
      this.m_typeDefinition = typeDefinition;
    else
      this.m_typeDefinition = (ExpandedNodeId) null;
  }

  public bool Unfiltered
  {
    get => this.m_unfiltered;
    set => this.m_unfiltered = value;
  }
}
