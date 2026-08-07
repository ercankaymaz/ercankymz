// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryUpdateEventState
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
public class AuditHistoryUpdateEventState(NodeState parent) : AuditUpdateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0SGlzdG9yeVVwZGF0ZUV2ZW50VHlwZUluc3RhbmNlAQA4CAEAOAg4CAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMwNAC4ARMwNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAM0NAC4ARM0NAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDODQAuAETODQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAzw0ALgBEzw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBANANAC4ARNANAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDRDQAuAETRDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDTDQAuAETTDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBANQNAC4ARNQNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABANUNAC4ARNUNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA1g0ALgBE1g0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDXDQAuAETXDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDYDQAuAETYDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDZDQAuAETZDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAvwoALgBEvwoAAAAR/////wEB/////wAAAAA=";
  private PropertyState<NodeId> m_parameterDataTypeId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2104U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0SGlzdG9yeVVwZGF0ZUV2ZW50VHlwZUluc3RhbmNlAQA4CAEAOAg4CAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMwNAC4ARMwNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAM0NAC4ARM0NAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDODQAuAETODQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAzw0ALgBEzw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBANANAC4ARNANAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDRDQAuAETRDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDTDQAuAETTDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBANQNAC4ARNQNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABANUNAC4ARNUNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA1g0ALgBE1g0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDXDQAuAETXDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDYDQAuAETYDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDZDQAuAETZDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAvwoALgBEvwoAAAAR/////wEB/////wAAAAA=");
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

  public PropertyState<NodeId> ParameterDataTypeId
  {
    get => this.m_parameterDataTypeId;
    set
    {
      if (this.m_parameterDataTypeId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_parameterDataTypeId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_parameterDataTypeId != null)
      children.Add((BaseInstanceState) this.m_parameterDataTypeId);
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
    if (browseName.Name == "ParameterDataTypeId")
    {
      if (createOrReplace && this.ParameterDataTypeId == null)
        this.ParameterDataTypeId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ParameterDataTypeId;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
