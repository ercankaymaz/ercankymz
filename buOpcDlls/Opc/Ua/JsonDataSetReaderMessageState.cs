// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetReaderMessageState
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
public class JsonDataSetReaderMessageState(NodeState parent) : DataSetReaderMessageState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAEpzb25EYXRhU2V0UmVhZGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAilIBAIpSilIAAP////8CAAAAFWCJCgIAAAAAABkAAABOZXR3b3JrTWVzc2FnZUNvbnRlbnRNYXNrAQCLUgAuAESLUgAAAQAmPf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQCMUgAuAESMUgAAAQAqPf////8BAf////8AAAAA";
  private PropertyState<uint> m_networkMessageContentMask;
  private PropertyState<uint> m_dataSetMessageContentMask;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21130U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEpzb25EYXRhU2V0UmVhZGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAilIBAIpSilIAAP////8CAAAAFWCJCgIAAAAAABkAAABOZXR3b3JrTWVzc2FnZUNvbnRlbnRNYXNrAQCLUgAuAESLUgAAAQAmPf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQCMUgAuAESMUgAAAQAqPf////8BAf////8AAAAA");
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

  public PropertyState<uint> NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set
    {
      if (this.m_networkMessageContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_networkMessageContentMask = value;
    }
  }

  public PropertyState<uint> DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set
    {
      if (this.m_dataSetMessageContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetMessageContentMask = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_networkMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_networkMessageContentMask);
    if (this.m_dataSetMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_dataSetMessageContentMask);
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
      case "NetworkMessageContentMask":
        if (createOrReplace && this.NetworkMessageContentMask == null)
          this.NetworkMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NetworkMessageContentMask;
        break;
      case "DataSetMessageContentMask":
        if (createOrReplace && this.DataSetMessageContentMask == null)
          this.DataSetMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DataSetMessageContentMask;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
