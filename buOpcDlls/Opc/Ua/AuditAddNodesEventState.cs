// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditAddNodesEventState
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
public class AuditAddNodesEventState(NodeState parent) : AuditNodeManagementEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0QWRkTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEAKwgBACsIKwgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQB4DQAuAER4DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQB5DQAuAER5DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAeg0ALgBEeg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAHsNAC4ARHsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQB8DQAuAER8DQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAfQ0ALgBEfQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAfw0ALgBEfw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCADQAuAESADQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCBDQAuAESBDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAIINAC4ARIINAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAgw0ALgBEgw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAhA0ALgBEhA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAhQ0ALgBEhQ0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACgAAAE5vZGVzVG9BZGQBACwIAC4ARCwIAAABAHgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<AddNodesItem[]> m_nodesToAdd;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2091U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0QWRkTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEAKwgBACsIKwgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQB4DQAuAER4DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQB5DQAuAER5DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAeg0ALgBEeg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAHsNAC4ARHsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQB8DQAuAER8DQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAfQ0ALgBEfQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAfw0ALgBEfw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCADQAuAESADQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCBDQAuAESBDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAIINAC4ARIINAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAgw0ALgBEgw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAhA0ALgBEhA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAhQ0ALgBEhQ0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACgAAAE5vZGVzVG9BZGQBACwIAC4ARCwIAAABAHgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public PropertyState<AddNodesItem[]> NodesToAdd
  {
    get => this.m_nodesToAdd;
    set
    {
      if (this.m_nodesToAdd != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_nodesToAdd = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_nodesToAdd != null)
      children.Add((BaseInstanceState) this.m_nodesToAdd);
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
    if (browseName.Name == "NodesToAdd")
    {
      if (createOrReplace && this.NodesToAdd == null)
        this.NodesToAdd = replacement != null ? (PropertyState<AddNodesItem[]>) replacement : new PropertyState<AddNodesItem[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NodesToAdd;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
