// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerConnectionTransportState
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
public class BrokerConnectionTransportState(NodeState parent) : ConnectionTransportState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAEJyb2tlckNvbm5lY3Rpb25UcmFuc3BvcnRUeXBlSW5zdGFuY2UBADM7AQAzOzM7AAD/////AgAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBADQ7AC4ARDQ7AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABBdXRoZW50aWNhdGlvblByb2ZpbGVVcmkBAEo7AC4AREo7AAAADP////8BAf////8AAAAA";
  private PropertyState<string> m_resourceUri;
  private PropertyState<string> m_authenticationProfileUri;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15155U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJQAAAEJyb2tlckNvbm5lY3Rpb25UcmFuc3BvcnRUeXBlSW5zdGFuY2UBADM7AQAzOzM7AAD/////AgAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBADQ7AC4ARDQ7AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABBdXRoZW50aWNhdGlvblByb2ZpbGVVcmkBAEo7AC4AREo7AAAADP////8BAf////8AAAAA");
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

  public PropertyState<string> ResourceUri
  {
    get => this.m_resourceUri;
    set
    {
      if (this.m_resourceUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_resourceUri = value;
    }
  }

  public PropertyState<string> AuthenticationProfileUri
  {
    get => this.m_authenticationProfileUri;
    set
    {
      if (this.m_authenticationProfileUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_authenticationProfileUri = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_resourceUri != null)
      children.Add((BaseInstanceState) this.m_resourceUri);
    if (this.m_authenticationProfileUri != null)
      children.Add((BaseInstanceState) this.m_authenticationProfileUri);
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
      case "ResourceUri":
        if (createOrReplace && this.ResourceUri == null)
          this.ResourceUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ResourceUri;
        break;
      case "AuthenticationProfileUri":
        if (createOrReplace && this.AuthenticationProfileUri == null)
          this.AuthenticationProfileUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AuthenticationProfileUri;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
