// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FileTransferStateMachineState
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
public class FileTransferStateMachineState(NodeState parent) : FiniteStateMachineState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAEZpbGVUcmFuc2ZlclN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEAuz0BALs9uz0AAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBALw9AC8BAMgKvD0AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQC9PQAuAES9PQAAABH/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOM9AC8BAOM94z0AAAEB/////wAAAAA=";
  private MethodState m_resetMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15803U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEZpbGVUcmFuc2ZlclN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEAuz0BALs9uz0AAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBALw9AC8BAMgKvD0AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQC9PQAuAES9PQAAABH/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOM9AC8BAOM94z0AAAEB/////wAAAAA=");
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

  public MethodState Reset
  {
    get => this.m_resetMethod;
    set
    {
      if (this.m_resetMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_resetMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_resetMethod != null)
      children.Add((BaseInstanceState) this.m_resetMethod);
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
    if (browseName.Name == "Reset")
    {
      if (createOrReplace && this.Reset == null)
        this.Reset = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Reset;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
