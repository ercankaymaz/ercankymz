// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IOrderedObjectState
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
public class IOrderedObjectState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGgAAAElPcmRlcmVkT2JqZWN0VHlwZUluc3RhbmNlAQDZWwEA2VvZWwAA/////wEAAAAVYIkKAgAAAAAADAAAAE51bWJlckluTGlzdAEA3VsALgBE3VsAAAAa/////wEB/////wAAAAA=";
  private PropertyState m_numberInList;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 23513U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGgAAAElPcmRlcmVkT2JqZWN0VHlwZUluc3RhbmNlAQDZWwEA2VvZWwAA/////wEAAAAVYIkKAgAAAAAADAAAAE51bWJlckluTGlzdAEA3VsALgBE3VsAAAAa/////wEB/////wAAAAA=");
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

  public PropertyState NumberInList
  {
    get => this.m_numberInList;
    set
    {
      if (this.m_numberInList != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_numberInList = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_numberInList != null)
      children.Add((BaseInstanceState) this.m_numberInList);
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
    if (browseName.Name == "NumberInList")
    {
      if (createOrReplace && this.NumberInList == null)
        this.NumberInList = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NumberInList;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
