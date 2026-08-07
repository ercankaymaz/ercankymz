// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BaseTypeState : NodeState
{
  public NodeAttributeEventHandler<bool> OnReadIsAbstract;
  public NodeAttributeEventHandler<bool> OnWriteIsAbstract;
  private NodeId m_superTypeId;
  private bool m_isAbstract;

  protected BaseTypeState(NodeClass nodeClass)
    : base(nodeClass)
  {
    this.m_isAbstract = false;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is BaseTypeState baseTypeState)
    {
      this.m_superTypeId = baseTypeState.m_superTypeId;
      this.m_isAbstract = baseTypeState.m_isAbstract;
    }
    base.Initialize(context, source);
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) new BaseTypeState(this.NodeClass));
  }

  public NodeId SuperTypeId
  {
    get => this.m_superTypeId;
    set
    {
      if ((object) this.m_superTypeId != (object) value)
        this.ChangeMasks |= NodeStateChangeMasks.References;
      this.m_superTypeId = value;
    }
  }

  public bool IsAbstract
  {
    get => this.m_isAbstract;
    set
    {
      if (this.m_isAbstract != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_isAbstract = value;
    }
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!NodeId.IsNull(this.SuperTypeId))
      node.ReferenceTable.Add(ReferenceTypeIds.HasSubtype, true, (ExpandedNodeId) this.SuperTypeId);
    switch (this.NodeClass)
    {
      case NodeClass.ObjectType:
        ((ObjectTypeNode) node).IsAbstract = this.IsAbstract;
        break;
      case NodeClass.VariableType:
        ((VariableTypeNode) node).IsAbstract = this.IsAbstract;
        break;
      case NodeClass.ReferenceType:
        ((ReferenceTypeNode) node).IsAbstract = this.IsAbstract;
        break;
      case NodeClass.DataType:
        ((DataTypeNode) node).IsAbstract = this.IsAbstract;
        break;
    }
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (!NodeId.IsNull(this.m_superTypeId))
      encoder.WriteNodeId("SuperTypeId", this.m_superTypeId);
    if (this.m_isAbstract)
      encoder.WriteBoolean("IsAbstract", this.m_isAbstract);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("SuperTypeId"))
      this.SuperTypeId = decoder.ReadNodeId("SuperTypeId");
    if (decoder.Peek("IsAbstract"))
      this.IsAbstract = decoder.ReadBoolean("IsAbstract");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (!NodeId.IsNull(this.m_superTypeId))
      attributesToSave |= NodeState.AttributesToSave.SuperTypeId;
    if (this.m_isAbstract)
      attributesToSave |= NodeState.AttributesToSave.IsAbstract;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.SuperTypeId) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_superTypeId);
    if ((attributesToSave & NodeState.AttributesToSave.IsAbstract) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteBoolean((string) null, this.m_isAbstract);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attributesToLoad)
  {
    base.Update(context, decoder, attributesToLoad);
    if ((attributesToLoad & NodeState.AttributesToSave.SuperTypeId) != NodeState.AttributesToSave.None)
      this.m_superTypeId = decoder.ReadNodeId((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.IsAbstract) == NodeState.AttributesToSave.None)
      return;
    this.m_isAbstract = decoder.ReadBoolean((string) null);
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    if (attributeId != 8U)
      return base.ReadNonValueAttribute(context, attributeId, ref value);
    bool isAbstract = this.m_isAbstract;
    if (this.OnReadIsAbstract != null)
      status = this.OnReadIsAbstract(context, (NodeState) this, ref isAbstract);
    if (ServiceResult.IsGood(status))
      value = (object) isAbstract;
    return status;
  }

  protected override ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    if (attributeId != 8U)
      return base.WriteNonValueAttribute(context, attributeId, value);
    bool? nullable = value as bool?;
    if (!nullable.HasValue)
      return (ServiceResult) 2155085824U /*0x80740000*/;
    if ((this.WriteMask & AttributeWriteMask.IsAbstract) == AttributeWriteMask.None)
      return (ServiceResult) 2151350272U /*0x803B0000*/;
    bool flag = nullable.Value;
    if (this.OnWriteIsAbstract != null)
      status = this.OnWriteIsAbstract(context, (NodeState) this, ref flag);
    if (ServiceResult.IsGood(status))
      this.IsAbstract = flag;
    return status;
  }

  protected override void PopulateBrowser(ISystemContext context, NodeBrowser browser)
  {
    base.PopulateBrowser(context, browser);
    if (!NodeId.IsNull(this.m_superTypeId) && browser.IsRequired(ReferenceTypeIds.HasSubtype, true))
      browser.Add(ReferenceTypeIds.HasSubtype, true, (ExpandedNodeId) this.m_superTypeId);
    if (context.TypeTable == null || !(this.NodeId != (object) null) || !browser.IsRequired(ReferenceTypeIds.HasSubtype, false))
      return;
    IList<NodeId> subTypes = context.TypeTable.FindSubTypes((ExpandedNodeId) this.NodeId);
    for (int index = 0; index < subTypes.Count; ++index)
      browser.Add(ReferenceTypeIds.HasSubtype, false, (ExpandedNodeId) subTypes[index]);
  }
}
