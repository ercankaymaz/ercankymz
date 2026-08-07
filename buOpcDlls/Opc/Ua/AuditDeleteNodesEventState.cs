// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditDeleteNodesEventState
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
public class AuditDeleteNodesEventState(NodeState parent) : AuditNodeManagementEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0RGVsZXRlTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEALQgBAC0ILQgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCGDQAuAESGDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCHDQAuAESHDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiA0ALgBEiA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIkNAC4ARIkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCKDQAuAESKDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAiw0ALgBEiw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAjQ0ALgBEjQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCODQAuAESODQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCPDQAuAESPDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJANAC4ARJANAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAkQ0ALgBEkQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAkg0ALgBEkg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAkw0ALgBEkw0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADQAAAE5vZGVzVG9EZWxldGUBAC4IAC4ARC4IAAABAH4BAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<DeleteNodesItem[]> m_nodesToDelete;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2093U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0RGVsZXRlTm9kZXNFdmVudFR5cGVJbnN0YW5jZQEALQgBAC0ILQgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCGDQAuAESGDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCHDQAuAESHDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiA0ALgBEiA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIkNAC4ARIkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCKDQAuAESKDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAiw0ALgBEiw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAjQ0ALgBEjQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCODQAuAESODQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCPDQAuAESPDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJANAC4ARJANAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAkQ0ALgBEkQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAkg0ALgBEkg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAkw0ALgBEkw0AAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADQAAAE5vZGVzVG9EZWxldGUBAC4IAC4ARC4IAAABAH4BAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public PropertyState<DeleteNodesItem[]> NodesToDelete
  {
    get => this.m_nodesToDelete;
    set
    {
      if (this.m_nodesToDelete != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_nodesToDelete = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_nodesToDelete != null)
      children.Add((BaseInstanceState) this.m_nodesToDelete);
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
    if (browseName.Name == "NodesToDelete")
    {
      if (createOrReplace && this.NodesToDelete == null)
        this.NodesToDelete = replacement != null ? (PropertyState<DeleteNodesItem[]>) replacement : new PropertyState<DeleteNodesItem[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NodesToDelete;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
