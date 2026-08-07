// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OrderedListState
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
public class OrderedListState(NodeState parent) : BaseObjectState(parent)
{
  private const string NodeVersion_InitializationString = "//////////8VYIkKAgAAAAAACwAAAE5vZGVWZXJzaW9uAQDlWwAuAETlWwAAAAz/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAE9yZGVyZWRMaXN0VHlwZUluc3RhbmNlAQDeWwEA3lveWwAAAQAAAAApAAEAVQgBAAAAFWCJCgIAAAAAAAsAAABOb2RlVmVyc2lvbgEA5VsALgBE5VsAAAAM/////wEB/////wAAAAA=";
  private PropertyState<string> m_nodeVersion;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 23518U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFwAAAE9yZGVyZWRMaXN0VHlwZUluc3RhbmNlAQDeWwEA3lveWwAAAQAAAAApAAEAVQgBAAAAFWCJCgIAAAAAAAsAAABOb2RlVmVyc2lvbgEA5VsALgBE5VsAAAAM/////wEB/////wAAAAA=");
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
    if (this.NodeVersion == null)
      return;
    this.NodeVersion.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAE5vZGVWZXJzaW9uAQDlWwAuAETlWwAAAAz/////AQH/////AAAAAA==");
  }

  public PropertyState<string> NodeVersion
  {
    get => this.m_nodeVersion;
    set
    {
      if (this.m_nodeVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_nodeVersion = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_nodeVersion != null)
      children.Add((BaseInstanceState) this.m_nodeVersion);
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
    if (browseName.Name == "NodeVersion")
    {
      if (createOrReplace && this.NodeVersion == null)
        this.NodeVersion = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NodeVersion;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
