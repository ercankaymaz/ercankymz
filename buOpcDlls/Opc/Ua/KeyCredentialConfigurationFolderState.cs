// Decompiled with JetBrains decompiler
// Type: Opc.Ua.KeyCredentialConfigurationFolderState
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
public class KeyCredentialConfigurationFolderState(NodeState parent) : FolderState(parent)
{
  private const string CreateCredential_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uRm9sZGVyVHlwZUluc3RhbmNlAQBYRAEAWERYRAAA/////wEAAAAEYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private CreateCredentialMethodState m_createCredentialMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17496U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALAAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uRm9sZGVyVHlwZUluc3RhbmNlAQBYRAEAWERYRAAA/////wEAAAAEYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    if (this.CreateCredential == null)
      return;
    this.CreateCredential.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAENyZWF0ZUNyZWRlbnRpYWwBAHJEAC8BAHJEckQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzRAAuAERzRAAAlgMAAAABACoBARoAAAALAAAAUmVzb3VyY2VVcmkADP////8AAAAAAAEAKgEBGQAAAAoAAABQcm9maWxlVXJpAAz/////AAAAAAABACoBAR8AAAAMAAAARW5kcG9pbnRVcmxzAAwBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdEQALgBEdEQAAJYBAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
  }

  public CreateCredentialMethodState CreateCredential
  {
    get => this.m_createCredentialMethod;
    set
    {
      if (this.m_createCredentialMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createCredentialMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_createCredentialMethod != null)
      children.Add((BaseInstanceState) this.m_createCredentialMethod);
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
    if (browseName.Name == "CreateCredential")
    {
      if (createOrReplace && this.CreateCredential == null)
        this.CreateCredential = replacement != null ? (CreateCredentialMethodState) replacement : new CreateCredentialMethodState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.CreateCredential;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
