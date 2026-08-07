// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseAnalogState
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
public class BaseAnalogState(NodeState parent) : DataItemState(parent)
{
  private const string InstrumentRange_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAAA==";
  private const string EURange_InitializationString = "//////////8VYIkKAgAAAAAABwAAAEVVUmFuZ2UBAKBEAC4ARKBEAAABAHQD/////wEB/////wAAAAA=";
  private const string EngineeringUnits_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAKFEAC4ARKFEAAABAHcD/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIECAgAAAAAAFgAAAEJhc2VBbmFsb2dUeXBlSW5zdGFuY2UBANY7AQDWO9Y7AAAAGgEB/////wMAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEAoEQALgBEoEQAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAoUQALgBEoUQAAAEAdwP/////AQH/////AAAAAA==";
  private PropertyState<Range> m_instrumentRange;
  private PropertyState<Range> m_eURange;
  private PropertyState<EUInformation> m_engineeringUnits;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15318U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 26U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAFgAAAEJhc2VBbmFsb2dUeXBlSW5zdGFuY2UBANY7AQDWO9Y7AAAAGgEB/////wMAAAAVYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEAoEQALgBEoEQAAAEAdAP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAoUQALgBEoUQAAAEAdwP/////AQH/////AAAAAA==");
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
    if (this.InstrumentRange != null)
      this.InstrumentRange.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEluc3RydW1lbnRSYW5nZQEAn0QALgBEn0QAAAEAdAP/////AQH/////AAAAAA==");
    if (this.EURange != null)
      this.EURange.Initialize(context, "//////////8VYIkKAgAAAAAABwAAAEVVUmFuZ2UBAKBEAC4ARKBEAAABAHQD/////wEB/////wAAAAA=");
    if (this.EngineeringUnits == null)
      return;
    this.EngineeringUnits.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAKFEAC4ARKFEAAABAHcD/////wEB/////wAAAAA=");
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

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_instrumentRange != null)
      children.Add((BaseInstanceState) this.m_instrumentRange);
    if (this.m_eURange != null)
      children.Add((BaseInstanceState) this.m_eURange);
    if (this.m_engineeringUnits != null)
      children.Add((BaseInstanceState) this.m_engineeringUnits);
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
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
