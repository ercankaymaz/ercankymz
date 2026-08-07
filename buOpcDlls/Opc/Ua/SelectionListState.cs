// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SelectionListState
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
public class SelectionListState(NodeState parent) : BaseDataVariableState(parent)
{
  private const string SelectionDescriptions_InitializationString = "//////////8XYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string RestrictToList_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFJlc3RyaWN0VG9MaXN0AQC4PwAuAES4PwAAAAH/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8VYIECAgAAAAAAGQAAAFNlbGVjdGlvbkxpc3RUeXBlSW5zdGFuY2UBALU/AQC1P7U/AAAAGAEB/////wMAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAOBEAC4AROBEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAAUmVzdHJpY3RUb0xpc3QBALg/AC4ARLg/AAAAAf////8BAf////8AAAAA";
  private PropertyState<object[]> m_selections;
  private PropertyState<LocalizedText[]> m_selectionDescriptions;
  private PropertyState<bool> m_restrictToList;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 16309U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -2;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAGQAAAFNlbGVjdGlvbkxpc3RUeXBlSW5zdGFuY2UBALU/AQC1P7U/AAAAGAEB/////wMAAAAXYIkKAgAAAAAACgAAAFNlbGVjdGlvbnMBAOBEAC4AROBEAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAAUmVzdHJpY3RUb0xpc3QBALg/AC4ARLg/AAAAAf////8BAf////8AAAAA");
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
    if (this.SelectionDescriptions != null)
      this.SelectionDescriptions.Initialize(context, "//////////8XYIkKAgAAAAAAFQAAAFNlbGVjdGlvbkRlc2NyaXB0aW9ucwEA4UQALgBE4UQAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.RestrictToList == null)
      return;
    this.RestrictToList.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFJlc3RyaWN0VG9MaXN0AQC4PwAuAES4PwAAAAH/////AQH/////AAAAAA==");
  }

  public PropertyState<object[]> Selections
  {
    get => this.m_selections;
    set
    {
      if (this.m_selections != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_selections = value;
    }
  }

  public PropertyState<LocalizedText[]> SelectionDescriptions
  {
    get => this.m_selectionDescriptions;
    set
    {
      if (this.m_selectionDescriptions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_selectionDescriptions = value;
    }
  }

  public PropertyState<bool> RestrictToList
  {
    get => this.m_restrictToList;
    set
    {
      if (this.m_restrictToList != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_restrictToList = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_selections != null)
      children.Add((BaseInstanceState) this.m_selections);
    if (this.m_selectionDescriptions != null)
      children.Add((BaseInstanceState) this.m_selectionDescriptions);
    if (this.m_restrictToList != null)
      children.Add((BaseInstanceState) this.m_restrictToList);
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
      case "Selections":
        if (createOrReplace && this.Selections == null)
          this.Selections = replacement != null ? (PropertyState<object[]>) replacement : new PropertyState<object[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Selections;
        break;
      case "SelectionDescriptions":
        if (createOrReplace && this.SelectionDescriptions == null)
          this.SelectionDescriptions = replacement != null ? (PropertyState<LocalizedText[]>) replacement : new PropertyState<LocalizedText[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SelectionDescriptions;
        break;
      case "RestrictToList":
        if (createOrReplace && this.RestrictToList == null)
          this.RestrictToList = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RestrictToList;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
