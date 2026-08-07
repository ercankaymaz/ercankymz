// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditUpdateStateEventState
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
public class AuditUpdateStateEventState(NodeState parent) : AuditUpdateMethodEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXBkYXRlU3RhdGVFdmVudFR5cGVJbnN0YW5jZQEACwkBAAsJCwkAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCuDgAuAESuDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCvDgAuAESvDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAsA4ALgBEsA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBALEOAC4ARLEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCyDgAuAESyDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAsw4ALgBEsw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAtQ4ALgBEtQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQC2DgAuAES2DgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQC3DgAuAES3DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBALgOAC4ARLgOAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAuQ4ALgBEuQ4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAug4ALgBEug4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAuw4ALgBEuw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQC8DgAuAES8DgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAL0OAC4ARL0OAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBANkKAC4ARNkKAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQDaCgAuAETaCgAAABj/////AQH/////AAAAAA==";
  private PropertyState m_oldStateId;
  private PropertyState m_newStateId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2315U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXBkYXRlU3RhdGVFdmVudFR5cGVJbnN0YW5jZQEACwkBAAsJCwkAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCuDgAuAESuDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCvDgAuAESvDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAsA4ALgBEsA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBALEOAC4ARLEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCyDgAuAESyDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAsw4ALgBEsw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAtQ4ALgBEtQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQC2DgAuAES2DgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQC3DgAuAES3DgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBALgOAC4ARLgOAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAuQ4ALgBEuQ4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAug4ALgBEug4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAuw4ALgBEuw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQC8DgAuAES8DgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAL0OAC4ARL0OAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAE9sZFN0YXRlSWQBANkKAC4ARNkKAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABOZXdTdGF0ZUlkAQDaCgAuAETaCgAAABj/////AQH/////AAAAAA==");
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

  public PropertyState OldStateId
  {
    get => this.m_oldStateId;
    set
    {
      if (this.m_oldStateId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_oldStateId = value;
    }
  }

  public PropertyState NewStateId
  {
    get => this.m_newStateId;
    set
    {
      if (this.m_newStateId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_newStateId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_oldStateId != null)
      children.Add((BaseInstanceState) this.m_oldStateId);
    if (this.m_newStateId != null)
      children.Add((BaseInstanceState) this.m_newStateId);
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
      case "OldStateId":
        if (createOrReplace && this.OldStateId == null)
          this.OldStateId = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OldStateId;
        break;
      case "NewStateId":
        if (createOrReplace && this.NewStateId == null)
          this.NewStateId = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NewStateId;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
