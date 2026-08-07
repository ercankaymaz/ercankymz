// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransparentRedundancyState
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
public class TransparentRedundancyState(NodeState parent) : ServerRedundancyState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAFRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9AcBAPQH9AcAAP////8DAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdAwALgBEdAwAAAEAUwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ3VycmVudFNlcnZlcklkAQD1BwAuAET1BwAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAUmVkdW5kYW50U2VydmVyQXJyYXkBAPYHAC4ARPYHAAABAFUDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<string> m_currentServerId;
  private PropertyState<RedundantServerDataType[]> m_redundantServerArray;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2036U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAFRyYW5zcGFyZW50UmVkdW5kYW5jeVR5cGVJbnN0YW5jZQEA9AcBAPQH9AcAAP////8DAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAdAwALgBEdAwAAAEAUwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ3VycmVudFNlcnZlcklkAQD1BwAuAET1BwAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAUmVkdW5kYW50U2VydmVyQXJyYXkBAPYHAC4ARPYHAAABAFUDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public PropertyState<string> CurrentServerId
  {
    get => this.m_currentServerId;
    set
    {
      if (this.m_currentServerId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentServerId = value;
    }
  }

  public PropertyState<RedundantServerDataType[]> RedundantServerArray
  {
    get => this.m_redundantServerArray;
    set
    {
      if (this.m_redundantServerArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_redundantServerArray = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_currentServerId != null)
      children.Add((BaseInstanceState) this.m_currentServerId);
    if (this.m_redundantServerArray != null)
      children.Add((BaseInstanceState) this.m_redundantServerArray);
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
      case "CurrentServerId":
        if (createOrReplace && this.CurrentServerId == null)
          this.CurrentServerId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CurrentServerId;
        break;
      case "RedundantServerArray":
        if (createOrReplace && this.RedundantServerArray == null)
          this.RedundantServerArray = replacement != null ? (PropertyState<RedundantServerDataType[]>) replacement : new PropertyState<RedundantServerDataType[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RedundantServerArray;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
