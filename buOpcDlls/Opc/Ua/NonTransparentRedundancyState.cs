// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NonTransparentRedundancyState
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
public class NonTransparentRedundancyState(NodeState parent) : ServerRedundancyState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAE5vblRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9wcBAPcH9wcAAP////8CAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdQwALgBEdQwAAAEAUwP/////AQH/////AAAAABdgiQoCAAAAAAAOAAAAU2VydmVyVXJpQXJyYXkBAPgHAC4ARPgHAAAADAEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<string[]> m_serverUriArray;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2039U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAE5vblRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9wcBAPcH9wcAAP////8CAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdQwALgBEdQwAAAEAUwP/////AQH/////AAAAABdgiQoCAAAAAAAOAAAAU2VydmVyVXJpQXJyYXkBAPgHAC4ARPgHAAAADAEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<string[]> ServerUriArray
  {
    get => this.m_serverUriArray;
    set
    {
      if (this.m_serverUriArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverUriArray = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serverUriArray != null)
      children.Add((BaseInstanceState) this.m_serverUriArray);
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
    if (browseName.Name == "ServerUriArray")
    {
      if (createOrReplace && this.ServerUriArray == null)
        this.ServerUriArray = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ServerUriArray;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
