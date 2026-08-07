// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkAddressState
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
public class NetworkAddressState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGgAAAE5ldHdvcmtBZGRyZXNzVHlwZUluc3RhbmNlAQCZUgEAmVKZUgAA/////wEAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJpSAC8BALU/mlIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAK5EAC4ARK5EAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private SelectionListState<string> m_networkInterface;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21145U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGgAAAE5ldHdvcmtBZGRyZXNzVHlwZUluc3RhbmNlAQCZUgEAmVKZUgAA/////wEAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJpSAC8BALU/mlIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAK5EAC4ARK5EAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
  }

  public SelectionListState<string> NetworkInterface
  {
    get => this.m_networkInterface;
    set
    {
      if (this.m_networkInterface != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_networkInterface = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_networkInterface != null)
      children.Add((BaseInstanceState) this.m_networkInterface);
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
    if (browseName.Name == "NetworkInterface")
    {
      if (createOrReplace && this.NetworkInterface == null)
        this.NetworkInterface = replacement != null ? (SelectionListState<string>) replacement : new SelectionListState<string>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NetworkInterface;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
