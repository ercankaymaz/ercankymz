// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditAddReferencesEventState
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
public class AuditAddReferencesEventState(NodeState parent) : AuditNodeManagementEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0QWRkUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAvCAEALwgvCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJQNAC4ARJQNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJUNAC4ARJUNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCWDQAuAESWDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlw0ALgBElw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJgNAC4ARJgNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCZDQAuAESZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCbDQAuAESbDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJwNAC4ARJwNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAJ0NAC4ARJ0NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAng0ALgBEng0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCfDQAuAESfDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCgDQAuAESgDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQChDQAuAEShDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAUmVmZXJlbmNlc1RvQWRkAQAwCAAuAEQwCAAAAQB7AQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<AddReferencesItem[]> m_referencesToAdd;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2095U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0QWRkUmVmZXJlbmNlc0V2ZW50VHlwZUluc3RhbmNlAQAvCAEALwgvCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJQNAC4ARJQNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJUNAC4ARJUNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCWDQAuAESWDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlw0ALgBElw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJgNAC4ARJgNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCZDQAuAESZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCbDQAuAESbDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJwNAC4ARJwNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAJ0NAC4ARJ0NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAng0ALgBEng0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCfDQAuAESfDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCgDQAuAESgDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQChDQAuAEShDQAAAAz/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAUmVmZXJlbmNlc1RvQWRkAQAwCAAuAEQwCAAAAQB7AQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<AddReferencesItem[]> ReferencesToAdd
  {
    get => this.m_referencesToAdd;
    set
    {
      if (this.m_referencesToAdd != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_referencesToAdd = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_referencesToAdd != null)
      children.Add((BaseInstanceState) this.m_referencesToAdd);
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
    if (browseName.Name == "ReferencesToAdd")
    {
      if (createOrReplace && this.ReferencesToAdd == null)
        this.ReferencesToAdd = replacement != null ? (PropertyState<AddReferencesItem[]>) replacement : new PropertyState<AddReferencesItem[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ReferencesToAdd;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
