// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AliasNameCategoryState
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
public class AliasNameCategoryState(NodeState parent) : FolderState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAEFsaWFzTmFtZUNhdGVnb3J5VHlwZUluc3RhbmNlAQCgWwEAoFugWwAA/////wEAAAAEYYIKBAAAAAAACQAAAEZpbmRBbGlhcwEAplsALwEAplumWwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKdbAC4ARKdbAACWAgAAAAEAKgEBJQAAABYAAABBbGlhc05hbWVTZWFyY2hQYXR0ZXJuAAz/////AAAAAAABACoBASIAAAATAAAAUmVmZXJlbmNlVHlwZUZpbHRlcgAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqFsALgBEqFsAAJYBAAAAAQAqAQEiAAAADQAAAEFsaWFzTm9kZUxpc3QBAKxbAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private FindAliasMethodState m_findAliasMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 23456U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAEFsaWFzTmFtZUNhdGVnb3J5VHlwZUluc3RhbmNlAQCgWwEAoFugWwAA/////wEAAAAEYYIKBAAAAAAACQAAAEZpbmRBbGlhcwEAplsALwEAplumWwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKdbAC4ARKdbAACWAgAAAAEAKgEBJQAAABYAAABBbGlhc05hbWVTZWFyY2hQYXR0ZXJuAAz/////AAAAAAABACoBASIAAAATAAAAUmVmZXJlbmNlVHlwZUZpbHRlcgAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAqFsALgBEqFsAAJYBAAAAAQAqAQEiAAAADQAAAEFsaWFzTm9kZUxpc3QBAKxbAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public FindAliasMethodState FindAlias
  {
    get => this.m_findAliasMethod;
    set
    {
      if (this.m_findAliasMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_findAliasMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_findAliasMethod != null)
      children.Add((BaseInstanceState) this.m_findAliasMethod);
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
    if (browseName.Name == "FindAlias")
    {
      if (createOrReplace && this.FindAlias == null)
        this.FindAlias = replacement != null ? (FindAliasMethodState) replacement : new FindAliasMethodState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.FindAlias;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
