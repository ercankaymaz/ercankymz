// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeTsnMacAddressState
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
public class IIeeeTsnMacAddressState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string SourceAddress_InitializationString = "//////////8XYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAElJZWVlVHNuTWFjQWRkcmVzc1R5cGVJbnN0YW5jZQEAh14BAIdeh14AAP////8CAAAAF2CJCgIAAAAAABIAAABEZXN0aW5hdGlvbkFkZHJlc3MBAIheAC8AP4heAAAAAwEAAAABAAAABgAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=";
  private BaseDataVariableState<byte[]> m_destinationAddress;
  private BaseDataVariableState<byte[]> m_sourceAddress;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24199U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAElJZWVlVHNuTWFjQWRkcmVzc1R5cGVJbnN0YW5jZQEAh14BAIdeh14AAP////8CAAAAF2CJCgIAAAAAABIAAABEZXN0aW5hdGlvbkFkZHJlc3MBAIheAC8AP4heAAAAAwEAAAABAAAABgAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=");
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
    if (this.SourceAddress == null)
      return;
    this.SourceAddress.Initialize(context, "//////////8XYIkKAgAAAAAADQAAAFNvdXJjZUFkZHJlc3MBAIleAC8AP4leAAAAAwEAAAABAAAABgAAAAEB/////wAAAAA=");
  }

  public BaseDataVariableState<byte[]> DestinationAddress
  {
    get => this.m_destinationAddress;
    set
    {
      if (this.m_destinationAddress != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_destinationAddress = value;
    }
  }

  public BaseDataVariableState<byte[]> SourceAddress
  {
    get => this.m_sourceAddress;
    set
    {
      if (this.m_sourceAddress != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sourceAddress = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_destinationAddress != null)
      children.Add((BaseInstanceState) this.m_destinationAddress);
    if (this.m_sourceAddress != null)
      children.Add((BaseInstanceState) this.m_sourceAddress);
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
      case "DestinationAddress":
        if (createOrReplace && this.DestinationAddress == null)
          this.DestinationAddress = replacement != null ? (BaseDataVariableState<byte[]>) replacement : new BaseDataVariableState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DestinationAddress;
        break;
      case "SourceAddress":
        if (createOrReplace && this.SourceAddress == null)
          this.SourceAddress = replacement != null ? (BaseDataVariableState<byte[]>) replacement : new BaseDataVariableState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SourceAddress;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
