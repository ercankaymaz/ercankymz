// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ArrayItemState
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
public class ArrayItemState(NodeState parent) : DataItemState(parent)
{
  private const string InstrumentRange_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAFQAAAEFycmF5SXRlbVR5cGVJbnN0YW5jZQEA9S4BAPUu9S4AAAAYAAAAAAEB/////wUAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEA+S4ALgBE+S4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEA+i4ALgBE+i4AAAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAVGl0bGUBAPsuAC4ARPsuAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBeGlzU2NhbGVUeXBlAQD8LgAuAET8LgAAAQAtL/////8BAf////8AAAAA";
  private PropertyState<Range> m_instrumentRange;
  private PropertyState<Range> m_eURange;
  private PropertyState<EUInformation> m_engineeringUnits;
  private PropertyState<LocalizedText> m_title;
  private PropertyState<AxisScaleEnumeration> m_axisScaleType;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12021U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => 0;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAFQAAAEFycmF5SXRlbVR5cGVJbnN0YW5jZQEA9S4BAPUu9S4AAAAYAAAAAAEB/////wUAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEA+S4ALgBE+S4AAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEA+i4ALgBE+i4AAAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAVGl0bGUBAPsuAC4ARPsuAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBeGlzU2NhbGVUeXBlAQD8LgAuAET8LgAAAQAtL/////8BAf////8AAAAA");
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
    if (this.InstrumentRange == null)
      return;
    this.InstrumentRange.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEA+C4ALgBE+C4AAAEAdAP/////AQH/////AAAAAA==");
  }

  public PropertyState<Range> InstrumentRange
  {
    get => this.m_instrumentRange;
    set
    {
      if (this.m_instrumentRange != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_instrumentRange = value;
    }
  }

  public PropertyState<Range> EURange
  {
    get => this.m_eURange;
    set
    {
      if (this.m_eURange != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_eURange = value;
    }
  }

  public PropertyState<EUInformation> EngineeringUnits
  {
    get => this.m_engineeringUnits;
    set
    {
      if (this.m_engineeringUnits != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_engineeringUnits = value;
    }
  }

  public PropertyState<LocalizedText> Title
  {
    get => this.m_title;
    set
    {
      if (this.m_title != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_title = value;
    }
  }

  public PropertyState<AxisScaleEnumeration> AxisScaleType
  {
    get => this.m_axisScaleType;
    set
    {
      if (this.m_axisScaleType != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_axisScaleType = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_instrumentRange != null)
      children.Add((BaseInstanceState) this.m_instrumentRange);
    if (this.m_eURange != null)
      children.Add((BaseInstanceState) this.m_eURange);
    if (this.m_engineeringUnits != null)
      children.Add((BaseInstanceState) this.m_engineeringUnits);
    if (this.m_title != null)
      children.Add((BaseInstanceState) this.m_title);
    if (this.m_axisScaleType != null)
      children.Add((BaseInstanceState) this.m_axisScaleType);
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
      case "InstrumentRange":
        if (createOrReplace && this.InstrumentRange == null)
          this.InstrumentRange = replacement != null ? (PropertyState<Range>) replacement : new PropertyState<Range>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.InstrumentRange;
        break;
      case "EURange":
        if (createOrReplace && this.EURange == null)
          this.EURange = replacement != null ? (PropertyState<Range>) replacement : new PropertyState<Range>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EURange;
        break;
      case "EngineeringUnits":
        if (createOrReplace && this.EngineeringUnits == null)
          this.EngineeringUnits = replacement != null ? (PropertyState<EUInformation>) replacement : new PropertyState<EUInformation>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EngineeringUnits;
        break;
      case "Title":
        if (createOrReplace && this.Title == null)
          this.Title = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Title;
        break;
      case "AxisScaleType":
        if (createOrReplace && this.AxisScaleType == null)
          this.AxisScaleType = replacement != null ? (PropertyState<AxisScaleEnumeration>) replacement : new PropertyState<AxisScaleEnumeration>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AxisScaleType;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
