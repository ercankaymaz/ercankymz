// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MultiStateDictionaryEntryDiscreteState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateDictionaryEntryDiscreteState(NodeState parent) : 
  MultiStateDictionaryEntryDiscreteBaseState(parent)
{
  private const string InitializationString = "//////////8VYIECAgAAAAAALQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZVR5cGVJbnN0YW5jZQEAjEoBAIxKjEoAAAAaAQH/////BAAAABdgiQoCAAAAAAAKAAAARW51bVZhbHVlcwEAj0oALgBEj0oAAAEAqh0BAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABWYWx1ZUFzVGV4dAEAkEoALgBEkEoAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAFQAAAEVudW1EaWN0aW9uYXJ5RW50cmllcwEAkUoALgBEkUoAAAARAgAAAAIAAAAAAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAkkoALgBEkkoAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 19084U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 26U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -2;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAALQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZVR5cGVJbnN0YW5jZQEAjEoBAIxKjEoAAAAaAQH/////BAAAABdgiQoCAAAAAAAKAAAARW51bVZhbHVlcwEAj0oALgBEj0oAAAEAqh0BAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABWYWx1ZUFzVGV4dAEAkEoALgBEkEoAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAFQAAAEVudW1EaWN0aW9uYXJ5RW50cmllcwEAkUoALgBEkUoAAAARAgAAAAIAAAAAAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAkkoALgBEkkoAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
