// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NonTransparentNetworkRedundancyState
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
public class NonTransparentNetworkRedundancyState(NodeState parent) : NonTransparentRedundancyState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKwAAAE5vblRyYW5zcGFyZW50TmV0d29ya1JlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAKkuAQCpLqkuAAD/////AwAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAKouAC4ARKouAAABAFMD/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAFNlcnZlclVyaUFycmF5AQCrLgAuAESrLgAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABMAAABTZXJ2ZXJOZXR3b3JrR3JvdXBzAQCsLgAuAESsLgAAAQCoLgEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<NetworkGroupDataType[]> m_serverNetworkGroups;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11945U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKwAAAE5vblRyYW5zcGFyZW50TmV0d29ya1JlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAKkuAQCpLqkuAAD/////AwAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAKouAC4ARKouAAABAFMD/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAFNlcnZlclVyaUFycmF5AQCrLgAuAESrLgAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABMAAABTZXJ2ZXJOZXR3b3JrR3JvdXBzAQCsLgAuAESsLgAAAQCoLgEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<NetworkGroupDataType[]> ServerNetworkGroups
  {
    get => this.m_serverNetworkGroups;
    set
    {
      if (this.m_serverNetworkGroups != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverNetworkGroups = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serverNetworkGroups != null)
      children.Add((BaseInstanceState) this.m_serverNetworkGroups);
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
    if (browseName.Name == "ServerNetworkGroups")
    {
      if (createOrReplace && this.ServerNetworkGroups == null)
        this.ServerNetworkGroups = replacement != null ? (PropertyState<NetworkGroupDataType[]>) replacement : new PropertyState<NetworkGroupDataType[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ServerNetworkGroups;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
