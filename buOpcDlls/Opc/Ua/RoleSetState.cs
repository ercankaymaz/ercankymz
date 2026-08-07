// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RoleSetState
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
public class RoleSetState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAEwAAAFJvbGVTZXRUeXBlSW5zdGFuY2UBAPc8AQD3PPc8AAD/////AgAAAARhggoEAAAAAAAHAAAAQWRkUm9sZQEAfT4ALwEAfT59PgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAH4+AC4ARH4+AACWAgAAAAEAKgEBFwAAAAgAAABSb2xlTmFtZQAM/////wAAAAAAAQAqAQEbAAAADAAAAE5hbWVzcGFjZVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAfz4ALgBEfz4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABSZW1vdmVSb2xlAQCAPgAvAQCAPoA+AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAgT4ALgBEgT4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private AddRoleMethodState m_addRoleMethod;
  private RemoveRoleMethodState m_removeRoleMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15607U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAEwAAAFJvbGVTZXRUeXBlSW5zdGFuY2UBAPc8AQD3PPc8AAD/////AgAAAARhggoEAAAAAAAHAAAAQWRkUm9sZQEAfT4ALwEAfT59PgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAH4+AC4ARH4+AACWAgAAAAEAKgEBFwAAAAgAAABSb2xlTmFtZQAM/////wAAAAAAAQAqAQEbAAAADAAAAE5hbWVzcGFjZVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAfz4ALgBEfz4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABSZW1vdmVSb2xlAQCAPgAvAQCAPoA+AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAgT4ALgBEgT4AAJYBAAAAAQAqAQEZAAAACgAAAFJvbGVOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public AddRoleMethodState AddRole
  {
    get => this.m_addRoleMethod;
    set
    {
      if (this.m_addRoleMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addRoleMethod = value;
    }
  }

  public RemoveRoleMethodState RemoveRole
  {
    get => this.m_removeRoleMethod;
    set
    {
      if (this.m_removeRoleMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeRoleMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_addRoleMethod != null)
      children.Add((BaseInstanceState) this.m_addRoleMethod);
    if (this.m_removeRoleMethod != null)
      children.Add((BaseInstanceState) this.m_removeRoleMethod);
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
      case "AddRole":
        if (createOrReplace && this.AddRole == null)
          this.AddRole = replacement != null ? (AddRoleMethodState) replacement : new AddRoleMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AddRole;
        break;
      case "RemoveRole":
        if (createOrReplace && this.RemoveRole == null)
          this.RemoveRole = replacement != null ? (RemoveRoleMethodState) replacement : new RemoveRoleMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RemoveRole;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
