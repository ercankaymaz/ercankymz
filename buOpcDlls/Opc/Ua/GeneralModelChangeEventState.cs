// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GeneralModelChangeEventState
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
public class GeneralModelChangeEventState(NodeState parent) : BaseModelChangeEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEdlbmVyYWxNb2RlbENoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQBVCAEAVQhVCAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAGAOAC4ARGAOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAGEOAC4ARGEOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBiDgAuAERiDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAYw4ALgBEYw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGQOAC4ARGQOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBlDgAuAERlDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBnDgAuAERnDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGgOAC4ARGgOAAAABf////8BAf////8AAAAAF2CJCgIAAAAAAAcAAABDaGFuZ2VzAQBWCAAuAERWCAAAAQBtAwEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<ModelChangeStructureDataType[]> m_changes;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2133U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEdlbmVyYWxNb2RlbENoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQBVCAEAVQhVCAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAGAOAC4ARGAOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAGEOAC4ARGEOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBiDgAuAERiDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAYw4ALgBEYw4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGQOAC4ARGQOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBlDgAuAERlDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBnDgAuAERnDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGgOAC4ARGgOAAAABf////8BAf////8AAAAAF2CJCgIAAAAAAAcAAABDaGFuZ2VzAQBWCAAuAERWCAAAAQBtAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<ModelChangeStructureDataType[]> Changes
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
        this.Changes = replacement != null ? (PropertyState<ModelChangeStructureDataType[]>) replacement : new PropertyState<ModelChangeStructureDataType[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Changes;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
