// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditConditionRespondEventState
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
public class AuditConditionRespondEventState(NodeState parent) : AuditConditionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uUmVzcG9uZEV2ZW50VHlwZUluc3RhbmNlAQDfIgEA3yLfIgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAOAiAC4AROAiAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAOEiAC4AROEiAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDiIgAuAETiIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEA4yIALgBE4yIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAOQiAC4AROQiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDlIgAuAETlIgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDnIgAuAETnIgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAOgiAC4AROgiAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAOkiAC4AROkiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA6iIALgBE6iIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDrIgAuAETrIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDsIgAuAETsIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDtIgAuAETtIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAO4iAC4ARO4iAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA7yIALgBE7yIAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAU2VsZWN0ZWRSZXNwb25zZQEATC4ALgBETC4AAAAH/////wEB/////wAAAAA=";
  private PropertyState<uint> m_selectedResponse;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 8927U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uUmVzcG9uZEV2ZW50VHlwZUluc3RhbmNlAQDfIgEA3yLfIgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAOAiAC4AROAiAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAOEiAC4AROEiAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDiIgAuAETiIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEA4yIALgBE4yIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAOQiAC4AROQiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDlIgAuAETlIgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDnIgAuAETnIgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAOgiAC4AROgiAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAOkiAC4AROkiAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA6iIALgBE6iIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDrIgAuAETrIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDsIgAuAETsIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDtIgAuAETtIgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAO4iAC4ARO4iAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA7yIALgBE7yIAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAU2VsZWN0ZWRSZXNwb25zZQEATC4ALgBETC4AAAAH/////wEB/////wAAAAA=");
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

  public PropertyState<uint> SelectedResponse
  {
    get => this.m_selectedResponse;
    set
    {
      if (this.m_selectedResponse != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_selectedResponse = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_selectedResponse != null)
      children.Add((BaseInstanceState) this.m_selectedResponse);
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
    if (browseName.Name == "SelectedResponse")
    {
      if (createOrReplace && this.SelectedResponse == null)
        this.SelectedResponse = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.SelectedResponse;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
