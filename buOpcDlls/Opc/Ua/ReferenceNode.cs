// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceNode
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
public class ReferenceNode : 
  IEncodeable,
  ICloneable,
  IJsonEncodeable,
  IReference,
  IComparable,
  IFormattable
{
  private NodeId m_referenceTypeId;
  private bool m_isInverse;
  private ExpandedNodeId m_targetId;

  public ReferenceNode() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_referenceTypeId = (NodeId) null;
    this.m_isInverse = true;
    this.m_targetId = (ExpandedNodeId) null;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 1)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "IsInverse", IsRequired = false, Order = 2)]
  public bool IsInverse
  {
    get => this.m_isInverse;
    set => this.m_isInverse = value;
  }

  [DataMember(Name = "TargetId", IsRequired = false, Order = 3)]
  public ExpandedNodeId TargetId
  {
    get => this.m_targetId;
    set => this.m_targetId = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReferenceNode;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceNode_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceNode_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceNode_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteBoolean("IsInverse", this.IsInverse);
    encoder.WriteExpandedNodeId("TargetId", this.TargetId);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.IsInverse = decoder.ReadBoolean("IsInverse");
    this.TargetId = decoder.ReadExpandedNodeId("TargetId");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    if ((object) this == (object) encodeable)
      return true;
    ReferenceNode referenceNode = encodeable as ReferenceNode;
    return !(referenceNode == (object) null) && Utils.IsEqual((object) this.m_referenceTypeId, (object) referenceNode.m_referenceTypeId) && Utils.IsEqual((object) this.m_isInverse, (object) referenceNode.m_isInverse) && Utils.IsEqual((object) this.m_targetId, (object) referenceNode.m_targetId);
  }

  public virtual object Clone() => (object) (ReferenceNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReferenceNode referenceNode = (ReferenceNode) base.MemberwiseClone();
    referenceNode.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    referenceNode.m_isInverse = (bool) Utils.Clone((object) this.m_isInverse);
    referenceNode.m_targetId = (ExpandedNodeId) Utils.Clone((object) this.m_targetId);
    return (object) referenceNode;
  }

  public ReferenceNode(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    this.m_referenceTypeId = referenceTypeId;
    this.m_isInverse = isInverse;
    this.m_targetId = targetId;
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    string str = (string) null;
    if (this.m_referenceTypeId != (object) null && this.m_referenceTypeId.IdType == IdType.Numeric && this.m_referenceTypeId.NamespaceIndex == (ushort) 0)
      str = ReferenceTypes.GetBrowseName((uint) this.m_referenceTypeId.Identifier);
    if (str == null)
      str = Utils.Format("{0}", (object) this.m_referenceTypeId);
    return this.m_isInverse ? Utils.Format("<!{0}>{1}", (object) str, (object) this.m_targetId) : Utils.Format("<{0}>{1}", (object) str, (object) this.m_targetId);
  }

  public override bool Equals(object obj) => this.CompareTo(obj) == 0;

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<NodeId>(this.m_referenceTypeId);
    hashCode.Add<bool>(this.m_isInverse);
    hashCode.Add<ExpandedNodeId>(this.m_targetId);
    return hashCode.ToHashCode();
  }

  public static bool operator ==(ReferenceNode a, object b)
  {
    return (object) a == null ? b == null : a.CompareTo(b) == 0;
  }

  public static bool operator !=(ReferenceNode a, object b)
  {
    return (object) a == null ? b != null : a.CompareTo(b) != 0;
  }

  public int CompareTo(object obj)
  {
    if (obj == null)
      return 1;
    if (obj == (object) this)
      return 0;
    ReferenceNode referenceNode = obj as ReferenceNode;
    if (referenceNode == (object) null)
      return -1;
    if ((object) this.m_referenceTypeId == null)
      return (object) referenceNode.m_referenceTypeId != null ? -1 : 0;
    int num = this.m_referenceTypeId.CompareTo((object) referenceNode.m_referenceTypeId);
    if (num != 0)
      return num;
    if (referenceNode.m_isInverse != this.m_isInverse)
      return !this.m_isInverse ? -1 : 1;
    if ((object) this.m_targetId != null)
      return this.m_targetId.CompareTo((object) referenceNode.m_targetId);
    return (object) referenceNode.m_targetId != null ? -1 : 0;
  }
}
