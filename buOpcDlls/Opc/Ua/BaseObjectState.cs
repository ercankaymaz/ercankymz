// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseObjectState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BaseObjectState : BaseInstanceState
{
  public NodeAttributeEventHandler<byte> OnReadEventNotifier;
  public NodeAttributeEventHandler<byte> OnWriteEventNotifier;
  private byte m_eventNotifier;

  public BaseObjectState(NodeState parent)
    : base(NodeClass.Object, parent)
  {
    this.m_eventNotifier = (byte) 0;
    if (parent == null)
      return;
    this.ReferenceTypeId = ReferenceTypeIds.HasComponent;
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new BaseObjectState(parent);

  protected override void Initialize(ISystemContext context)
  {
    this.SymbolicName = Utils.Format("{0}_Instance1", (object) "BaseObjectType");
    this.NodeId = (NodeId) null;
    this.BrowseName = new QualifiedName(this.SymbolicName, (ushort) 1);
    this.DisplayName = (LocalizedText) this.SymbolicName;
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.TypeDefinitionId = this.GetDefaultTypeDefinitionId(context.NamespaceUris);
    this.NumericId = 58U;
    this.EventNotifier = (byte) 0;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is BaseObjectState baseObjectState)
      this.m_eventNotifier = baseObjectState.m_eventNotifier;
    base.Initialize(context, source);
  }

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return (NodeId) 58U;
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType(), (object) this.Parent));
  }

  public byte EventNotifier
  {
    get => this.m_eventNotifier;
    set
    {
      if ((int) this.m_eventNotifier != (int) value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_eventNotifier = value;
    }
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!(node is ObjectNode objectNode))
      return;
    objectNode.EventNotifier = this.EventNotifier;
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (this.m_eventNotifier != (byte) 0)
      encoder.WriteByte("EventNotifier", this.m_eventNotifier);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("EventNotifier"))
      this.EventNotifier = decoder.ReadByte("EventNotifier");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (this.m_eventNotifier != (byte) 0)
      attributesToSave |= NodeState.AttributesToSave.EventNotifier;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.EventNotifier) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteByte((string) null, this.m_eventNotifier);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attibutesToLoad)
  {
    base.Update(context, decoder, attibutesToLoad);
    if ((attibutesToLoad & NodeState.AttributesToSave.EventNotifier) == NodeState.AttributesToSave.None)
      return;
    this.m_eventNotifier = decoder.ReadByte((string) null);
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    if (attributeId != 12U)
      return base.ReadNonValueAttribute(context, attributeId, ref value);
    byte eventNotifier = this.m_eventNotifier;
    if (this.OnReadEventNotifier != null)
      status = this.OnReadEventNotifier(context, (NodeState) this, ref eventNotifier);
    if (ServiceResult.IsGood(status))
      value = (object) eventNotifier;
    return status;
  }

  protected override ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    if (attributeId != 12U)
      return base.WriteNonValueAttribute(context, attributeId, value);
    byte? nullable = value as byte?;
    if (!nullable.HasValue)
      return (ServiceResult) 2155085824U /*0x80740000*/;
    if ((this.WriteMask & AttributeWriteMask.EventNotifier) == AttributeWriteMask.None)
      return (ServiceResult) 2151350272U /*0x803B0000*/;
    byte num = nullable.Value;
    if (this.OnWriteEventNotifier != null)
      status = this.OnWriteEventNotifier(context, (NodeState) this, ref num);
    if (ServiceResult.IsGood(status))
      this.EventNotifier = num;
    return status;
  }
}
