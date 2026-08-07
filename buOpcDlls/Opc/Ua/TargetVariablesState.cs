// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TargetVariablesState
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
public class TargetVariablesState(NodeState parent) : SubscribedDataSetState(parent)
{
  private const string AddTargetVariables_InitializationString = "//////////8EYYIKBAAAAAAAEgAAAEFkZFRhcmdldFZhcmlhYmxlcwEACzsALwEACzsLOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAw7AC4ARAw7AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAA07AC4ARA07AACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string RemoveTargetVariables_InitializationString = "//////////8EYYIKBAAAAAAAFQAAAFJlbW92ZVRhcmdldFZhcmlhYmxlcwEADjsALwEADjsOOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAA87AC4ARA87AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASIAAAAPAAAAVGFyZ2V0c1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAEDsALgBEEDsAAJYBAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFRhcmdldFZhcmlhYmxlc1R5cGVJbnN0YW5jZQEABzsBAAc7BzsAAP////8DAAAAF2CJCgIAAAAAAA8AAABUYXJnZXRWYXJpYWJsZXMBAAo7AC4ARAo7AAABAJg5AQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAASAAAAQWRkVGFyZ2V0VmFyaWFibGVzAQALOwAvAQALOws7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADDsALgBEDDsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBKQAAABQAAABUYXJnZXRWYXJpYWJsZXNUb0FkZAEAmDkBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEADTsALgBEDTsAAJYBAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAVAAAAUmVtb3ZlVGFyZ2V0VmFyaWFibGVzAQAOOwAvAQAOOw47AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADzsALgBEDzsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAQOwAuAEQQOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private PropertyState<FieldTargetDataType[]> m_targetVariables;
  private TargetVariablesTypeAddTargetVariablesMethodState m_addTargetVariablesMethod;
  private TargetVariablesTypeRemoveTargetVariablesMethodState m_removeTargetVariablesMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15111U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFRhcmdldFZhcmlhYmxlc1R5cGVJbnN0YW5jZQEABzsBAAc7BzsAAP////8DAAAAF2CJCgIAAAAAAA8AAABUYXJnZXRWYXJpYWJsZXMBAAo7AC4ARAo7AAABAJg5AQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAASAAAAQWRkVGFyZ2V0VmFyaWFibGVzAQALOwAvAQALOws7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADDsALgBEDDsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBKQAAABQAAABUYXJnZXRWYXJpYWJsZXNUb0FkZAEAmDkBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEADTsALgBEDTsAAJYBAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAVAAAAUmVtb3ZlVGFyZ2V0VmFyaWFibGVzAQAOOwAvAQAOOw47AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADzsALgBEDzsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAQOwAuAEQQOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    if (this.AddTargetVariables != null)
      this.AddTargetVariables.Initialize(context, "//////////8EYYIKBAAAAAAAEgAAAEFkZFRhcmdldFZhcmlhYmxlcwEACzsALwEACzsLOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAw7AC4ARAw7AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAA07AC4ARA07AACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.RemoveTargetVariables == null)
      return;
    this.RemoveTargetVariables.Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAFJlbW92ZVRhcmdldFZhcmlhYmxlcwEADjsALwEADjsOOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAA87AC4ARA87AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASIAAAAPAAAAVGFyZ2V0c1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAEDsALgBEEDsAAJYBAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public PropertyState<FieldTargetDataType[]> TargetVariables
  {
    get => this.m_targetVariables;
    set
    {
      if (this.m_targetVariables != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_targetVariables = value;
    }
  }

  public TargetVariablesTypeAddTargetVariablesMethodState AddTargetVariables
  {
    get => this.m_addTargetVariablesMethod;
    set
    {
      if (this.m_addTargetVariablesMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addTargetVariablesMethod = value;
    }
  }

  public TargetVariablesTypeRemoveTargetVariablesMethodState RemoveTargetVariables
  {
    get => this.m_removeTargetVariablesMethod;
    set
    {
      if (this.m_removeTargetVariablesMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeTargetVariablesMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_targetVariables != null)
      children.Add((BaseInstanceState) this.m_targetVariables);
    if (this.m_addTargetVariablesMethod != null)
      children.Add((BaseInstanceState) this.m_addTargetVariablesMethod);
    if (this.m_removeTargetVariablesMethod != null)
      children.Add((BaseInstanceState) this.m_removeTargetVariablesMethod);
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
      case "TargetVariables":
        if (createOrReplace && this.TargetVariables == null)
          this.TargetVariables = replacement != null ? (PropertyState<FieldTargetDataType[]>) replacement : new PropertyState<FieldTargetDataType[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TargetVariables;
        break;
      case "AddTargetVariables":
        if (createOrReplace && this.AddTargetVariables == null)
          this.AddTargetVariables = replacement != null ? (TargetVariablesTypeAddTargetVariablesMethodState) replacement : new TargetVariablesTypeAddTargetVariablesMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AddTargetVariables;
        break;
      case "RemoveTargetVariables":
        if (createOrReplace && this.RemoveTargetVariables == null)
          this.RemoveTargetVariables = replacement != null ? (TargetVariablesTypeRemoveTargetVariablesMethodState) replacement : new TargetVariablesTypeRemoveTargetVariablesMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RemoveTargetVariables;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
