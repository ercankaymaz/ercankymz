// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Export;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class DataTypeState : BaseTypeState
{
  public NodeAttributeEventHandler<ExtensionObject> OnReadDataTypeDefinition;
  public NodeAttributeEventHandler<ExtensionObject> OnWriteDataTypeDefinition;
  private ExtensionObject m_dataTypeDefinition;

  public DataTypeState()
    : base(NodeClass.DataType)
  {
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new DataTypeState();

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType()));
  }

  public ExtensionObject DataTypeDefinition
  {
    get => this.m_dataTypeDefinition;
    set
    {
      if (this.m_dataTypeDefinition != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_dataTypeDefinition = value;
    }
  }

  public DataTypePurpose Purpose { get; set; }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (this.m_dataTypeDefinition != null)
      encoder.WriteExtensionObject("DataTypeDefinition", this.m_dataTypeDefinition);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("DataTypeDefinition"))
      this.DataTypeDefinition = decoder.ReadExtensionObject("DataTypeDefinition");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (this.m_dataTypeDefinition != null)
      attributesToSave |= NodeState.AttributesToSave.DataTypeDefinition;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.DataTypeDefinition) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteExtensionObject((string) null, this.DataTypeDefinition);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attributesToLoad)
  {
    base.Update(context, decoder, attributesToLoad);
    if ((attributesToLoad & NodeState.AttributesToSave.DataTypeDefinition) == NodeState.AttributesToSave.None)
      return;
    this.DataTypeDefinition = decoder.ReadExtensionObject((string) null);
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    if (attributeId != 23U)
      return base.ReadNonValueAttribute(context, attributeId, ref value);
    ExtensionObject dataTypeDefinition = this.m_dataTypeDefinition;
    if (this.OnReadDataTypeDefinition != null)
      status = this.OnReadDataTypeDefinition(context, (NodeState) this, ref dataTypeDefinition);
    if (ServiceResult.IsGood(status))
    {
      if (dataTypeDefinition?.Body is StructureDefinition body && (body.DefaultEncodingId == (object) null || body.DefaultEncodingId.IsNullNodeId))
        body.SetDefaultEncodingId(context, this.NodeId, (QualifiedName) null);
      value = (object) dataTypeDefinition;
    }
    return value == null && status == null ? (ServiceResult) 2150957056U /*0x80350000*/ : status;
  }

  protected override ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    if (attributeId != 23U)
      return base.WriteNonValueAttribute(context, attributeId, value);
    ExtensionObject extensionObject = value as ExtensionObject;
    if ((this.WriteMask & AttributeWriteMask.DataTypeDefinition) == AttributeWriteMask.None)
      return (ServiceResult) 2151350272U /*0x803B0000*/;
    if (this.OnWriteDataTypeDefinition != null)
      status = this.OnWriteDataTypeDefinition(context, (NodeState) this, ref extensionObject);
    if (ServiceResult.IsGood(status))
      this.m_dataTypeDefinition = extensionObject;
    return status;
  }
}
