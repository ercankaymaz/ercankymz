// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReaderGroupMessageState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ReaderGroupMessageState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAFJlYWRlckdyb3VwTWVzc2FnZVR5cGVJbnN0YW5jZQEAY1IBAGNSY1IAAP////8AAAAA";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21091U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAFJlYWRlckdyb3VwTWVzc2FnZVR5cGVJbnN0YW5jZQEAY1IBAGNSY1IAAP////8AAAAA");
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
}
