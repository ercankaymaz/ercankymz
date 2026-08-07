// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ViewState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ViewState : NodeState
{
  public NodeAttributeEventHandler<byte> OnReadEventNotifier;
  public NodeAttributeEventHandler<byte> OnWriteEventNotifier;
  public NodeAttributeEventHandler<bool> OnReadContainsNoLoops;
  public NodeAttributeEventHandler<bool> OnWriteContainsNoLoops;
  private byte m_eventNotifier;
  private bool m_containsNoLoops;

  public ViewState()
    : base(NodeClass.View)
  {
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new ViewState();

  protected override void Initialize(ISystemContext context)
  {
    this.SymbolicName = "View1";
    this.NodeId = (NodeId) null;
    this.BrowseName = new QualifiedName(this.SymbolicName, (ushort) 1);
    this.DisplayName = (LocalizedText) this.SymbolicName;
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.EventNotifier = (byte) 0;
    this.ContainsNoLoops = false;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is ViewState viewState)
    {
      this.m_eventNotifier = viewState.m_eventNotifier;
      this.m_containsNoLoops = viewState.m_containsNoLoops;
    }
    base.Initialize(context, source);
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType()));
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

  public bool ContainsNoLoops
  {
    get => this.m_containsNoLoops;
    set
    {
      if (this.m_containsNoLoops != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_containsNoLoops = value;
    }
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!(node is ViewNode viewNode))
      return;
    viewNode.EventNotifier = this.EventNotifier;
    viewNode.ContainsNoLoops = this.ContainsNoLoops;
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (this.m_eventNotifier != (byte) 0)
      encoder.WriteByte("EventNotifier", this.m_eventNotifier);
    if (this.m_containsNoLoops)
      encoder.WriteBoolean("ContainsNoLoops", this.m_containsNoLoops);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("EventNotifier"))
      this.EventNotifier = decoder.ReadByte("EventNotifier");
    if (decoder.Peek("ContainsNoLoops"))
      this.ContainsNoLoops = decoder.ReadBoolean("ContainsNoLoops");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (this.m_eventNotifier != (byte) 0)
      attributesToSave |= NodeState.AttributesToSave.EventNotifier;
    if (this.m_containsNoLoops)
      attributesToSave |= NodeState.AttributesToSave.ContainsNoLoops;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.EventNotifier) != NodeState.AttributesToSave.None)
      encoder.WriteByte((string) null, this.m_eventNotifier);
    if ((attributesToSave & NodeState.AttributesToSave.ContainsNoLoops) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteBoolean((string) null, this.m_containsNoLoops);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attributesToLoad)
  {
    base.Update(context, decoder, attributesToLoad);
    if ((attributesToLoad & NodeState.AttributesToSave.EventNotifier) != NodeState.AttributesToSave.None)
      this.m_eventNotifier = decoder.ReadByte((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.ContainsNoLoops) == NodeState.AttributesToSave.None)
      return;
    this.m_containsNoLoops = decoder.ReadBoolean((string) null);
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 11:
        bool containsNoLoops = this.m_containsNoLoops;
        if (this.OnReadContainsNoLoops != null)
          status = this.OnReadContainsNoLoops(context, (NodeState) this, ref containsNoLoops);
        if (ServiceResult.IsGood(status))
          value = (object) containsNoLoops;
        return status;
      case 12:
        byte eventNotifier = this.m_eventNotifier;
        if (this.OnReadEventNotifier != null)
          status = this.OnReadEventNotifier(context, (NodeState) this, ref eventNotifier);
        if (ServiceResult.IsGood(status))
          value = (object) eventNotifier;
        return status;
      default:
        return base.ReadNonValueAttribute(context, attributeId, ref value);
    }
  }

  protected override ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 11:
        bool? nullable1 = value as bool?;
        if (!nullable1.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.ContainsNoLoops) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        bool flag = nullable1.Value;
        if (this.OnWriteContainsNoLoops != null)
          status = this.OnWriteContainsNoLoops(context, (NodeState) this, ref flag);
        if (ServiceResult.IsGood(status))
          this.ContainsNoLoops = flag;
        return status;
      case 12:
        byte? nullable2 = value as byte?;
        if (!nullable2.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.EventNotifier) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        byte num = nullable2.Value;
        if (this.OnWriteEventNotifier != null)
          status = this.OnWriteEventNotifier(context, (NodeState) this, ref num);
        if (ServiceResult.IsGood(status))
          this.EventNotifier = num;
        return status;
      default:
        return base.WriteNonValueAttribute(context, attributeId, value);
    }
  }
}
