// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DatagramConnectionTransportState
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
public class DatagramConnectionTransportState(NodeState parent) : ConnectionTransportState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAERhdGFncmFtQ29ubmVjdGlvblRyYW5zcG9ydFR5cGVJbnN0YW5jZQEA2DoBANg62DoAAP////8BAAAABGCACgEAAAAAABAAAABEaXNjb3ZlcnlBZGRyZXNzAQDgOgAvAQCZUuA6AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMjsALwEAtT8yOwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAq0QALgBEq0QAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private NetworkAddressState m_discoveryAddress;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15064U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJwAAAERhdGFncmFtQ29ubmVjdGlvblRyYW5zcG9ydFR5cGVJbnN0YW5jZQEA2DoBANg62DoAAP////8BAAAABGCACgEAAAAAABAAAABEaXNjb3ZlcnlBZGRyZXNzAQDgOgAvAQCZUuA6AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMjsALwEAtT8yOwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAq0QALgBEq0QAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public NetworkAddressState DiscoveryAddress
  {
    get => this.m_discoveryAddress;
    set
    {
      if (this.m_discoveryAddress != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_discoveryAddress = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_discoveryAddress != null)
      children.Add((BaseInstanceState) this.m_discoveryAddress);
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
    if (browseName.Name == "DiscoveryAddress")
    {
      if (createOrReplace && this.DiscoveryAddress == null)
        this.DiscoveryAddress = replacement != null ? (NetworkAddressState) replacement : new NetworkAddressState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.DiscoveryAddress;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
