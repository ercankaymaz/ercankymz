// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MultiStateDictionaryEntryDiscreteBaseState
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
public class MultiStateDictionaryEntryDiscreteBaseState(NodeState parent) : 
  MultiStateValueDiscreteState(parent)
{
  private const string ValueAsDictionaryEntries_InitializationString = "//////////8XYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAi0oALgBEi0oAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8VYIECAgAAAAAAMQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZUJhc2VUeXBlSW5zdGFuY2UBAIVKAQCFSoVKAAAAGgEB/////wQAAAAXYIkKAgAAAAAACgAAAEVudW1WYWx1ZXMBAIhKAC4ARIhKAAABAKodAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAVmFsdWVBc1RleHQBAIlKAC4ARIlKAAAAFf////8BAf////8AAAAAF2CJCgIAAAAAABUAAABFbnVtRGljdGlvbmFyeUVudHJpZXMBAIpKAC4ARIpKAAAAEQIAAAACAAAAAAAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABgAAABWYWx1ZUFzRGljdGlvbmFyeUVudHJpZXMBAItKAC4ARItKAAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState m_enumDictionaryEntries;
  private PropertyState<NodeId[]> m_valueAsDictionaryEntries;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 19077U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 26U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -2;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAMQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZUJhc2VUeXBlSW5zdGFuY2UBAIVKAQCFSoVKAAAAGgEB/////wQAAAAXYIkKAgAAAAAACgAAAEVudW1WYWx1ZXMBAIhKAC4ARIhKAAABAKodAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAVmFsdWVBc1RleHQBAIlKAC4ARIlKAAAAFf////8BAf////8AAAAAF2CJCgIAAAAAABUAAABFbnVtRGljdGlvbmFyeUVudHJpZXMBAIpKAC4ARIpKAAAAEQIAAAACAAAAAAAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABgAAABWYWx1ZUFzRGljdGlvbmFyeUVudHJpZXMBAItKAC4ARItKAAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    if (this.ValueAsDictionaryEntries == null)
      return;
    this.ValueAsDictionaryEntries.Initialize(context, "//////////8XYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAi0oALgBEi0oAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public PropertyState EnumDictionaryEntries
  {
    get => this.m_enumDictionaryEntries;
    set
    {
      if (this.m_enumDictionaryEntries != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enumDictionaryEntries = value;
    }
  }

  public PropertyState<NodeId[]> ValueAsDictionaryEntries
  {
    get => this.m_valueAsDictionaryEntries;
    set
    {
      if (this.m_valueAsDictionaryEntries != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_valueAsDictionaryEntries = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_enumDictionaryEntries != null)
      children.Add((BaseInstanceState) this.m_enumDictionaryEntries);
    if (this.m_valueAsDictionaryEntries != null)
      children.Add((BaseInstanceState) this.m_valueAsDictionaryEntries);
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
      case "EnumDictionaryEntries":
        if (createOrReplace && this.EnumDictionaryEntries == null)
          this.EnumDictionaryEntries = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EnumDictionaryEntries;
        break;
      case "ValueAsDictionaryEntries":
        if (createOrReplace && this.ValueAsDictionaryEntries == null)
          this.ValueAsDictionaryEntries = replacement != null ? (PropertyState<NodeId[]>) replacement : new PropertyState<NodeId[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ValueAsDictionaryEntries;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
