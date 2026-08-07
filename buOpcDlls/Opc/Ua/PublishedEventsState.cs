// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedEventsState
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
public class PublishedEventsState(NodeState parent) : PublishedDataSetState(parent)
{
  private const string ModifyFieldSelection_InitializationString = "//////////8EYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVJbnN0YW5jZQEA7DgBAOw47DgAAP////8GAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA9jgALgBE9jgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCNOwAuAESNOwAAAQC7OP////8BAf////8AAAAAFWDJCgIAAAATAAAAUHViU3ViRXZlbnROb3RpZmllcgAADQAAAEV2ZW50Tm90aWZpZXIBAPo4AC4ARPo4AAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABTZWxlY3RlZEZpZWxkcwEA+zgALgBE+zgAAAEAWQIBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAYAAABGaWx0ZXIBAPw4AC4ARPw4AAABAEoC/////wEB/////wAAAAAEYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<NodeId> m_pubSubEventNotifier;
  private PropertyState<SimpleAttributeOperand[]> m_selectedFields;
  private PropertyState<ContentFilter> m_filter;
  private PublishedEventsTypeModifyFieldSelectionMethodState m_modifyFieldSelectionMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14572U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVJbnN0YW5jZQEA7DgBAOw47DgAAP////8GAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA9jgALgBE9jgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCNOwAuAESNOwAAAQC7OP////8BAf////8AAAAAFWDJCgIAAAATAAAAUHViU3ViRXZlbnROb3RpZmllcgAADQAAAEV2ZW50Tm90aWZpZXIBAPo4AC4ARPo4AAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABTZWxlY3RlZEZpZWxkcwEA+zgALgBE+zgAAAEAWQIBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAYAAABGaWx0ZXIBAPw4AC4ARPw4AAABAEoC/////wEB/////wAAAAAEYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    if (this.ModifyFieldSelection == null)
      return;
    this.ModifyFieldSelection.Initialize(context, "//////////8EYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public PropertyState<NodeId> PubSubEventNotifier
  {
    get => this.m_pubSubEventNotifier;
    set
    {
      if (this.m_pubSubEventNotifier != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_pubSubEventNotifier = value;
    }
  }

  public PropertyState<SimpleAttributeOperand[]> SelectedFields
  {
    get => this.m_selectedFields;
    set
    {
      if (this.m_selectedFields != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_selectedFields = value;
    }
  }

  public PropertyState<ContentFilter> Filter
  {
    get => this.m_filter;
    set
    {
      if (this.m_filter != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_filter = value;
    }
  }

  public PublishedEventsTypeModifyFieldSelectionMethodState ModifyFieldSelection
  {
    get => this.m_modifyFieldSelectionMethod;
    set
    {
      if (this.m_modifyFieldSelectionMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_modifyFieldSelectionMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_pubSubEventNotifier != null)
      children.Add((BaseInstanceState) this.m_pubSubEventNotifier);
    if (this.m_selectedFields != null)
      children.Add((BaseInstanceState) this.m_selectedFields);
    if (this.m_filter != null)
      children.Add((BaseInstanceState) this.m_filter);
    if (this.m_modifyFieldSelectionMethod != null)
      children.Add((BaseInstanceState) this.m_modifyFieldSelectionMethod);
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
      case "EventNotifier":
        if (createOrReplace && this.PubSubEventNotifier == null)
          this.PubSubEventNotifier = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PubSubEventNotifier;
        break;
      case "SelectedFields":
        if (createOrReplace && this.SelectedFields == null)
          this.SelectedFields = replacement != null ? (PropertyState<SimpleAttributeOperand[]>) replacement : new PropertyState<SimpleAttributeOperand[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SelectedFields;
        break;
      case "Filter":
        if (createOrReplace && this.Filter == null)
          this.Filter = replacement != null ? (PropertyState<ContentFilter>) replacement : new PropertyState<ContentFilter>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Filter;
        break;
      case "ModifyFieldSelection":
        if (createOrReplace && this.ModifyFieldSelection == null)
          this.ModifyFieldSelection = replacement != null ? (PublishedEventsTypeModifyFieldSelectionMethodState) replacement : new PublishedEventsTypeModifyFieldSelectionMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ModifyFieldSelection;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
