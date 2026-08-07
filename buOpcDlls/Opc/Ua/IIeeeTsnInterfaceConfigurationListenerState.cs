// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeTsnInterfaceConfigurationListenerState
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
public class IIeeeTsnInterfaceConfigurationListenerState(NodeState parent) : 
  IIeeeTsnInterfaceConfigurationState(parent)
{
  private const string ReceiveOffset_InitializationString = "//////////8VYIkKAgAAAAAADQAAAFJlY2VpdmVPZmZzZXQBAIZeAC8AP4ZeAAAAB/////8BAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAMgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvbkxpc3RlbmVyVHlwZUluc3RhbmNlAQCDXgEAg16DXgAA/////wIAAAAVYIkKAgAAAAAACgAAAE1hY0FkZHJlc3MBAIReAC8AP4ReAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCGXgAvAD+GXgAAAAf/////AQH/////AAAAAA==";
  private BaseDataVariableState<uint> m_receiveOffset;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24195U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAMgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvbkxpc3RlbmVyVHlwZUluc3RhbmNlAQCDXgEAg16DXgAA/////wIAAAAVYIkKAgAAAAAACgAAAE1hY0FkZHJlc3MBAIReAC8AP4ReAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCGXgAvAD+GXgAAAAf/////AQH/////AAAAAA==");
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
    if (this.ReceiveOffset == null)
      return;
    this.ReceiveOffset.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAFJlY2VpdmVPZmZzZXQBAIZeAC8AP4ZeAAAAB/////8BAf////8AAAAA");
  }

  public BaseDataVariableState<uint> ReceiveOffset
  {
    get => this.m_receiveOffset;
    set
    {
      if (this.m_receiveOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_receiveOffset = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_receiveOffset != null)
      children.Add((BaseInstanceState) this.m_receiveOffset);
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
    if (browseName.Name == "ReceiveOffset")
    {
      if (createOrReplace && this.ReceiveOffset == null)
        this.ReceiveOffset = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ReceiveOffset;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
