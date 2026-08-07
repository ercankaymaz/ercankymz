// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MultiStateValueDiscreteState
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
public class MultiStateValueDiscreteState(NodeState parent) : DiscreteItemState(parent)
{
  private const string InitializationString = "//////////8VYIECAgAAAAAAIwAAAE11bHRpU3RhdGVWYWx1ZURpc2NyZXRlVHlwZUluc3RhbmNlAQDmKwEA5ivmKwAAABoBAf////8CAAAAF2CJCgIAAAAAAAoAAABFbnVtVmFsdWVzAQDpKwAuAETpKwAAAQCqHQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAFZhbHVlQXNUZXh0AQDFLAAuAETFLAAAABX/////AQH/////AAAAAA==";
  private PropertyState<EnumValueType[]> m_enumValues;
  private PropertyState<LocalizedText> m_valueAsText;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11238U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 26U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -2;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAIwAAAE11bHRpU3RhdGVWYWx1ZURpc2NyZXRlVHlwZUluc3RhbmNlAQDmKwEA5ivmKwAAABoBAf////8CAAAAF2CJCgIAAAAAAAoAAABFbnVtVmFsdWVzAQDpKwAuAETpKwAAAQCqHQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAFZhbHVlQXNUZXh0AQDFLAAuAETFLAAAABX/////AQH/////AAAAAA==");
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

  public PropertyState<EnumValueType[]> EnumValues
  {
    get => this.m_enumValues;
    set
    {
      if (this.m_enumValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enumValues = value;
    }
  }

  public PropertyState<LocalizedText> ValueAsText
  {
    get => this.m_valueAsText;
    set
    {
      if (this.m_valueAsText != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_valueAsText = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_enumValues != null)
      children.Add((BaseInstanceState) this.m_enumValues);
    if (this.m_valueAsText != null)
      children.Add((BaseInstanceState) this.m_valueAsText);
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
      case "EnumValues":
        if (createOrReplace && this.EnumValues == null)
          this.EnumValues = replacement != null ? (PropertyState<EnumValueType[]>) replacement : new PropertyState<EnumValueType[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EnumValues;
        break;
      case "ValueAsText":
        if (createOrReplace && this.ValueAsText == null)
          this.ValueAsText = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ValueAsText;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
