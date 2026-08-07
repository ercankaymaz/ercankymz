// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataItemState
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
public class DataItemState(NodeState parent) : BaseDataVariableState(parent)
{
  private const string Definition_InitializationString = "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BAD4JAC4ARD4JAAAADP////8BAf////8AAAAA";
  private const string ValuePrecision_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFZhbHVlUHJlY2lzaW9uAQA/CQAuAEQ/CQAAAAv/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8VYIECAgAAAAAAFAAAAERhdGFJdGVtVHlwZUluc3RhbmNlAQA9CQEAPQk9CQAAABgBAf////8CAAAAFWCJCgIAAAAAAAoAAABEZWZpbml0aW9uAQA+CQAuAEQ+CQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVmFsdWVQcmVjaXNpb24BAD8JAC4ARD8JAAAAC/////8BAf////8AAAAA";
  private PropertyState<string> m_definition;
  private PropertyState<double> m_valuePrecision;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2365U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -2;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAFAAAAERhdGFJdGVtVHlwZUluc3RhbmNlAQA9CQEAPQk9CQAAABgBAf////8CAAAAFWCJCgIAAAAAAAoAAABEZWZpbml0aW9uAQA+CQAuAEQ+CQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVmFsdWVQcmVjaXNpb24BAD8JAC4ARD8JAAAAC/////8BAf////8AAAAA");
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
    if (this.Definition != null)
      this.Definition.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BAD4JAC4ARD4JAAAADP////8BAf////8AAAAA");
    if (this.ValuePrecision == null)
      return;
    this.ValuePrecision.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFZhbHVlUHJlY2lzaW9uAQA/CQAuAEQ/CQAAAAv/////AQH/////AAAAAA==");
  }

  public PropertyState<string> Definition
  {
    get => this.m_definition;
    set
    {
      if (this.m_definition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_definition = value;
    }
  }

  public PropertyState<double> ValuePrecision
  {
    get => this.m_valuePrecision;
    set
    {
      if (this.m_valuePrecision != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_valuePrecision = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_definition != null)
      children.Add((BaseInstanceState) this.m_definition);
    if (this.m_valuePrecision != null)
      children.Add((BaseInstanceState) this.m_valuePrecision);
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
      case "Definition":
        if (createOrReplace && this.Definition == null)
          this.Definition = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Definition;
        break;
      case "ValuePrecision":
        if (createOrReplace && this.ValuePrecision == null)
          this.ValuePrecision = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ValuePrecision;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
