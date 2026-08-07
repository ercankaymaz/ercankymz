// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditDeleteReferencesEventState
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
public class AuditDeleteReferencesEventState(NodeState parent) : AuditNodeManagementEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0RGVsZXRlUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAxCAEAMQgxCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKINAC4ARKINAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKMNAC4ARKMNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCkDQAuAESkDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApQ0ALgBEpQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKYNAC4ARKYNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCnDQAuAESnDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCpDQAuAESpDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKoNAC4ARKoNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKsNAC4ARKsNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEArA0ALgBErA0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCtDQAuAEStDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCuDQAuAESuDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCvDQAuAESvDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAASAAAAUmVmZXJlbmNlc1RvRGVsZXRlAQAyCAAuAEQyCAAAAQCBAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<DeleteReferencesItem[]> m_referencesToDelete;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2097U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0RGVsZXRlUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAxCAEAMQgxCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKINAC4ARKINAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKMNAC4ARKMNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCkDQAuAESkDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEApQ0ALgBEpQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAKYNAC4ARKYNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCnDQAuAESnDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCpDQAuAESpDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAKoNAC4ARKoNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKsNAC4ARKsNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEArA0ALgBErA0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCtDQAuAEStDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCuDQAuAESuDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCvDQAuAESvDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAASAAAAUmVmZXJlbmNlc1RvRGVsZXRlAQAyCAAuAEQyCAAAAQCBAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<DeleteReferencesItem[]> ReferencesToDelete
  {
    get => this.m_referencesToDelete;
    set
    {
      if (this.m_referencesToDelete != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_referencesToDelete = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_referencesToDelete != null)
      children.Add((BaseInstanceState) this.m_referencesToDelete);
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
    if (browseName.Name == "ReferencesToDelete")
    {
      if (createOrReplace && this.ReferencesToDelete == null)
        this.ReferencesToDelete = replacement != null ? (PropertyState<DeleteReferencesItem[]>) replacement : new PropertyState<DeleteReferencesItem[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ReferencesToDelete;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
