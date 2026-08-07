// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NetworkAddressUrlState
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
public class NetworkAddressUrlState(NodeState parent) : NetworkAddressState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAE5ldHdvcmtBZGRyZXNzVXJsVHlwZUluc3RhbmNlAQCbUgEAm1KbUgAA/////wIAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJxSAC8BALU/nFIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBALFEAC4ARLFEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAAwAAAFVybAEAnVIALwA/nVIAAAAM/////wEB/////wAAAAA=";
  private BaseDataVariableState<string> m_url;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21147U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAE5ldHdvcmtBZGRyZXNzVXJsVHlwZUluc3RhbmNlAQCbUgEAm1KbUgAA/////wIAAAAVYIkKAgAAAAAAEAAAAE5ldHdvcmtJbnRlcmZhY2UBAJxSAC8BALU/nFIAAAAM/////wEB/////wEAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBALFEAC4ARLFEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAAwAAAFVybAEAnVIALwA/nVIAAAAM/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<string> Url
  {
    get => this.m_url;
    set
    {
      if (this.m_url != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_url = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_url != null)
      children.Add((BaseInstanceState) this.m_url);
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
    if (browseName.Name == "Url")
    {
      if (createOrReplace && this.Url == null)
        this.Url = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Url;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
