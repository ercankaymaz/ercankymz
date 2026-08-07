// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SemanticChangeEventState
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
public class SemanticChangeEventState(NodeState parent) : BaseEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNlbWFudGljQ2hhbmdlRXZlbnRUeXBlSW5zdGFuY2UBALIKAQCyCrIKAAD/////CQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAaQ4ALgBEaQ4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAag4ALgBEag4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAGsOAC4ARGsOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBsDgAuAERsDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAbQ4ALgBEbQ4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAG4OAC4ARG4OAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAHAOAC4ARHAOAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAcQ4ALgBEcQ4AAAAF/////wEB/////wAAAAAXYIkKAgAAAAAABwAAAENoYW5nZXMBALMKAC4ARLMKAAABAIEDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<SemanticChangeStructureDataType[]> m_changes;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2738U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNlbWFudGljQ2hhbmdlRXZlbnRUeXBlSW5zdGFuY2UBALIKAQCyCrIKAAD/////CQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAaQ4ALgBEaQ4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAag4ALgBEag4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAGsOAC4ARGsOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBsDgAuAERsDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAbQ4ALgBEbQ4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAG4OAC4ARG4OAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAHAOAC4ARHAOAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAcQ4ALgBEcQ4AAAAF/////wEB/////wAAAAAXYIkKAgAAAAAABwAAAENoYW5nZXMBALMKAC4ARLMKAAABAIEDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public PropertyState<SemanticChangeStructureDataType[]> Changes
  {
    get => this.m_changes;
    set
    {
      if (this.m_changes != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_changes = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_changes != null)
      children.Add((BaseInstanceState) this.m_changes);
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
    if (browseName.Name == "Changes")
    {
      if (createOrReplace && this.Changes == null)
        this.Changes = replacement != null ? (PropertyState<SemanticChangeStructureDataType[]>) replacement : new PropertyState<SemanticChangeStructureDataType[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Changes;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
