// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataItemsState
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
public class PublishedDataItemsState(NodeState parent) : PublishedDataSetState(parent)
{
  private const string AddVariables_InitializationString = "//////////8EYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string RemoveVariables_InitializationString = "//////////8EYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAFB1Ymxpc2hlZERhdGFJdGVtc1R5cGVJbnN0YW5jZQEAxjgBAMY4xjgAAP////8FAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA0DgALgBE0DgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCFOwAuAESFOwAAAQC7OP////8BAf////8AAAAAF2CJCgIAAAAAAA0AAABQdWJsaXNoZWREYXRhAQDUOAAuAETUOAAAAQDBNwEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<PublishedVariableDataType[]> m_publishedData;
  private PublishedDataItemsAddVariablesMethodState m_addVariablesMethod;
  private PublishedDataItemsRemoveVariablesMethodState m_removeVariablesMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14534U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAFB1Ymxpc2hlZERhdGFJdGVtc1R5cGVJbnN0YW5jZQEAxjgBAMY4xjgAAP////8FAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA0DgALgBE0DgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCFOwAuAESFOwAAAQC7OP////8BAf////8AAAAAF2CJCgIAAAAAAA0AAABQdWJsaXNoZWREYXRhAQDUOAAuAETUOAAAAQDBNwEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    if (this.AddVariables != null)
      this.AddVariables.Initialize(context, "//////////8EYYIKBAAAAAAADAAAAEFkZFZhcmlhYmxlcwEA2zgALwEA2zjbOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBANw4AC4ARNw4AACWBAAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBIQAAAA4AAABQcm9tb3RlZEZpZWxkcwABAQAAAAEAAAAAAAAAAAEAKgEBIwAAAA4AAABWYXJpYWJsZXNUb0FkZAEAwTcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA3TgALgBE3TgAAJYCAAAAAQAqAQEoAAAAFwAAAE5ld0NvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.RemoveVariables == null)
      return;
    this.RemoveVariables.Initialize(context, "//////////8EYYIKBAAAAAAADwAAAFJlbW92ZVZhcmlhYmxlcwEA3jgALwEA3jjeOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAN84AC4ARN84AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASQAAAARAAAAVmFyaWFibGVzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDgOAAuAETgOAAAlgIAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public PropertyState<PublishedVariableDataType[]> PublishedData
  {
    get => this.m_publishedData;
    set
    {
      if (this.m_publishedData != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishedData = value;
    }
  }

  public PublishedDataItemsAddVariablesMethodState AddVariables
  {
    get => this.m_addVariablesMethod;
    set
    {
      if (this.m_addVariablesMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addVariablesMethod = value;
    }
  }

  public PublishedDataItemsRemoveVariablesMethodState RemoveVariables
  {
    get => this.m_removeVariablesMethod;
    set
    {
      if (this.m_removeVariablesMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeVariablesMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_publishedData != null)
      children.Add((BaseInstanceState) this.m_publishedData);
    if (this.m_addVariablesMethod != null)
      children.Add((BaseInstanceState) this.m_addVariablesMethod);
    if (this.m_removeVariablesMethod != null)
      children.Add((BaseInstanceState) this.m_removeVariablesMethod);
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
      case "PublishedData":
        if (createOrReplace && this.PublishedData == null)
          this.PublishedData = replacement != null ? (PropertyState<PublishedVariableDataType[]>) replacement : new PropertyState<PublishedVariableDataType[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PublishedData;
        break;
      case "AddVariables":
        if (createOrReplace && this.AddVariables == null)
          this.AddVariables = replacement != null ? (PublishedDataItemsAddVariablesMethodState) replacement : new PublishedDataItemsAddVariablesMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AddVariables;
        break;
      case "RemoveVariables":
        if (createOrReplace && this.RemoveVariables == null)
          this.RemoveVariables = replacement != null ? (PublishedDataItemsRemoveVariablesMethodState) replacement : new PublishedDataItemsRemoveVariablesMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RemoveVariables;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
