// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DatagramWriterGroupTransportState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DatagramWriterGroupTransportState(NodeState parent) : WriterGroupTransportState(parent)
{
  private const string MessageRepeatCount_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXRDb3VudAEAjlIALgBEjlIAAAAD/////wEB/////wAAAAA=";
  private const string MessageRepeatDelay_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXREZWxheQEAj1IALgBEj1IAAAEAIgH/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAERhdGFncmFtV3JpdGVyR3JvdXBUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAI1SAQCNUo1SAAD/////AgAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdENvdW50AQCOUgAuAESOUgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdERlbGF5AQCPUgAuAESPUgAAAQAiAf////8BAf////8AAAAA";
  private PropertyState<byte> m_messageRepeatCount;
  private PropertyState<double> m_messageRepeatDelay;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21133U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAERhdGFncmFtV3JpdGVyR3JvdXBUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAI1SAQCNUo1SAAD/////AgAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdENvdW50AQCOUgAuAESOUgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAATWVzc2FnZVJlcGVhdERlbGF5AQCPUgAuAESPUgAAAQAiAf////8BAf////8AAAAA");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
    if (this.MessageRepeatCount != null)
      this.MessageRepeatCount.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXRDb3VudAEAjlIALgBEjlIAAAAD/////wEB/////wAAAAA=");
    if (this.MessageRepeatDelay == null)
      return;
    this.MessageRepeatDelay.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAE1lc3NhZ2VSZXBlYXREZWxheQEAj1IALgBEj1IAAAEAIgH/////AQH/////AAAAAA==");
  }

  public PropertyState<byte> MessageRepeatCount
  {
    get => this.m_messageRepeatCount;
    set
    {
      if (this.m_messageRepeatCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_messageRepeatCount = value;
    }
  }

  public PropertyState<double> MessageRepeatDelay
  {
    get => this.m_messageRepeatDelay;
    set
    {
      if (this.m_messageRepeatDelay != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_messageRepeatDelay = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_messageRepeatCount != null)
      children.Add((BaseInstanceState) this.m_messageRepeatCount);
    if (this.m_messageRepeatDelay != null)
      children.Add((BaseInstanceState) this.m_messageRepeatDelay);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    switch (browseName.Name)
    {
      case "MessageRepeatCount":
        if (createOrReplace && this.MessageRepeatCount == null)
          this.MessageRepeatCount = replacement != null ? (PropertyState<byte>) replacement : new PropertyState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MessageRepeatCount;
        break;
      case "MessageRepeatDelay":
        if (createOrReplace && this.MessageRepeatDelay == null)
          this.MessageRepeatDelay = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MessageRepeatDelay;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
