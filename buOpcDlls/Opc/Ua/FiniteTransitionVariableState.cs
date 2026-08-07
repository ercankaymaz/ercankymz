// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FiniteTransitionVariableState
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
public class FiniteTransitionVariableState(NodeState parent) : TransitionVariableState(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJAAAAEZpbml0ZVRyYW5zaXRpb25WYXJpYWJsZVR5cGVJbnN0YW5jZQEAzwoBAM8KzwoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDQCgAuAETQCgAAABH/////AQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2767U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJAAAAEZpbml0ZVRyYW5zaXRpb25WYXJpYWJsZVR5cGVJbnN0YW5jZQEAzwoBAM8KzwoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDQCgAuAETQCgAAABH/////AQH/////AAAAAA==");
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

  public PropertyState<NodeId> Id
  {
    get => (PropertyState<NodeId>) base.Id;
    set => this.Id = (PropertyState) value;
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
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
    if (browseName.Name == "Id")
    {
      if (createOrReplace && this.Id == null)
        this.Id = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Id;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
