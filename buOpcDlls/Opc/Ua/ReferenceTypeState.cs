// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ReferenceTypeState : BaseTypeState
{
  public NodeAttributeEventHandler<LocalizedText> OnReadInverseName;
  public NodeAttributeEventHandler<LocalizedText> OnWriteInverseName;
  public NodeAttributeEventHandler<bool> OnReadSymmetric;
  public NodeAttributeEventHandler<bool> OnWriteSymmetric;
  private LocalizedText m_inverseName;
  private bool m_symmetric;

  public ReferenceTypeState()
    : base(NodeClass.ReferenceType)
  {
    this.m_inverseName = (LocalizedText) null;
    this.m_symmetric = false;
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new ReferenceTypeState();

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.InverseName = (LocalizedText) null;
    this.Symmetric = false;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is ReferenceTypeState referenceTypeState)
    {
      this.m_inverseName = referenceTypeState.m_inverseName;
      this.m_symmetric = referenceTypeState.m_symmetric;
    }
    base.Initialize(context, source);
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType()));
  }

  public LocalizedText InverseName
  {
    get => this.m_inverseName;
    set
    {
      if ((object) this.m_inverseName != (object) value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_inverseName = value;
    }
  }

  public bool Symmetric
  {
    get => this.m_symmetric;
    set
    {
      if (this.m_symmetric != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_symmetric = value;
    }
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!(node is ReferenceTypeNode referenceTypeNode))
      return;
    referenceTypeNode.InverseName = this.InverseName;
    referenceTypeNode.Symmetric = this.Symmetric;
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (!LocalizedText.IsNullOrEmpty(this.m_inverseName))
      encoder.WriteLocalizedText("InverseName", this.m_inverseName);
    if (this.m_symmetric)
      encoder.WriteBoolean("Symmetric", this.m_symmetric);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("InverseName"))
      this.InverseName = decoder.ReadLocalizedText("InverseName");
    if (decoder.Peek("Symmetric"))
      this.Symmetric = decoder.ReadBoolean("Symmetric");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (!LocalizedText.IsNullOrEmpty(this.m_inverseName))
      attributesToSave |= NodeState.AttributesToSave.InverseName;
    if (this.m_symmetric)
      attributesToSave |= NodeState.AttributesToSave.Symmetric;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.InverseName) != NodeState.AttributesToSave.None)
      encoder.WriteLocalizedText((string) null, this.m_inverseName);
    if ((attributesToSave & NodeState.AttributesToSave.Symmetric) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteBoolean((string) null, this.m_symmetric);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attibutesToLoad)
  {
    base.Update(context, decoder, attibutesToLoad);
    if ((attibutesToLoad & NodeState.AttributesToSave.InverseName) != NodeState.AttributesToSave.None)
      this.m_inverseName = decoder.ReadLocalizedText((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.Symmetric) == NodeState.AttributesToSave.None)
      return;
    this.m_symmetric = decoder.ReadBoolean((string) null);
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 9:
        bool symmetric = this.m_symmetric;
        if (this.OnReadSymmetric != null)
          status = this.OnReadSymmetric(context, (NodeState) this, ref symmetric);
        if (ServiceResult.IsGood(status))
          value = (object) symmetric;
        return status;
      case 10:
        LocalizedText inverseName = this.m_inverseName;
        if (this.OnReadInverseName != null)
          status = this.OnReadInverseName(context, (NodeState) this, ref inverseName);
        if (ServiceResult.IsGood(status))
        {
          if (inverseName == (LocalizedText) null)
            status = (ServiceResult) 2150957056U /*0x80350000*/;
          else
            value = (object) inverseName;
        }
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
      case 9:
        bool? nullable = value as bool?;
        if (!nullable.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.Symmetric) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        bool flag = nullable.Value;
        if (this.OnWriteSymmetric != null)
          status = this.OnWriteSymmetric(context, (NodeState) this, ref flag);
        if (ServiceResult.IsGood(status))
          this.Symmetric = flag;
        return status;
      case 10:
        LocalizedText localizedText = value as LocalizedText;
        if (localizedText == (LocalizedText) null && value != null)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.InverseName) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteInverseName != null)
          status = this.OnWriteInverseName(context, (NodeState) this, ref localizedText);
        if (ServiceResult.IsGood(status))
          this.InverseName = localizedText;
        return status;
      default:
        return base.WriteNonValueAttribute(context, attributeId, value);
    }
  }
}
