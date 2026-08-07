// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AggregateConfigurationState
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
public class AggregateConfigurationState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAEFnZ3JlZ2F0ZUNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBALMrAQCzK7MrAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAtCsALgBEtCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQC1KwAuAES1KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQC2KwAuAES2KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAtysALgBEtysAAAAB/////wEB/////wAAAAA=";
  private PropertyState<bool> m_treatUncertainAsBad;
  private PropertyState<byte> m_percentDataBad;
  private PropertyState<byte> m_percentDataGood;
  private PropertyState<bool> m_useSlopedExtrapolation;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11187U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIgAAAEFnZ3JlZ2F0ZUNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBALMrAQCzK7MrAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAtCsALgBEtCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQC1KwAuAES1KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQC2KwAuAES2KwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAtysALgBEtysAAAAB/////wEB/////wAAAAA=");
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

  public PropertyState<bool> TreatUncertainAsBad
  {
    get => this.m_treatUncertainAsBad;
    set
    {
      if (this.m_treatUncertainAsBad != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_treatUncertainAsBad = value;
    }
  }

  public PropertyState<byte> PercentDataBad
  {
    get => this.m_percentDataBad;
    set
    {
      if (this.m_percentDataBad != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_percentDataBad = value;
    }
  }

  public PropertyState<byte> PercentDataGood
  {
    get => this.m_percentDataGood;
    set
    {
      if (this.m_percentDataGood != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_percentDataGood = value;
    }
  }

  public PropertyState<bool> UseSlopedExtrapolation
  {
    get => this.m_useSlopedExtrapolation;
    set
    {
      if (this.m_useSlopedExtrapolation != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_useSlopedExtrapolation = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_treatUncertainAsBad != null)
      children.Add((BaseInstanceState) this.m_treatUncertainAsBad);
    if (this.m_percentDataBad != null)
      children.Add((BaseInstanceState) this.m_percentDataBad);
    if (this.m_percentDataGood != null)
      children.Add((BaseInstanceState) this.m_percentDataGood);
    if (this.m_useSlopedExtrapolation != null)
      children.Add((BaseInstanceState) this.m_useSlopedExtrapolation);
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
      case "TreatUncertainAsBad":
        if (createOrReplace && this.TreatUncertainAsBad == null)
          this.TreatUncertainAsBad = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TreatUncertainAsBad;
        break;
      case "PercentDataBad":
        if (createOrReplace && this.PercentDataBad == null)
          this.PercentDataBad = replacement != null ? (PropertyState<byte>) replacement : new PropertyState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PercentDataBad;
        break;
      case "PercentDataGood":
        if (createOrReplace && this.PercentDataGood == null)
          this.PercentDataGood = replacement != null ? (PropertyState<byte>) replacement : new PropertyState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PercentDataGood;
        break;
      case "UseSlopedExtrapolation":
        if (createOrReplace && this.UseSlopedExtrapolation == null)
          this.UseSlopedExtrapolation = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.UseSlopedExtrapolation;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
