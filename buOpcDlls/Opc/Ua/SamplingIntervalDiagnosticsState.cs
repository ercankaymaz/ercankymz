// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SamplingIntervalDiagnosticsState
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
public class SamplingIntervalDiagnosticsState(NodeState parent) : 
  BaseDataVariableState<SamplingIntervalDiagnosticsDataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJwAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc1R5cGVJbnN0YW5jZQEAdQgBAHUIdQgAAAEAWAP/////AQH/////BAAAABVgiQoCAAAAAAAQAAAAU2FtcGxpbmdJbnRlcnZhbAEAdggALwA/dggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAU2FtcGxlZE1vbml0b3JlZEl0ZW1zQ291bnQBALEtAC8AP7EtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABNYXhTYW1wbGVkTW9uaXRvcmVkSXRlbXNDb3VudAEAsi0ALwA/si0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAIwAAAERpc2FibGVkTW9uaXRvcmVkSXRlbXNTYW1wbGluZ0NvdW50AQCzLQAvAD+zLQAAAAf/////AQH/////AAAAAA==";
  private BaseDataVariableState<double> m_samplingInterval;
  private BaseDataVariableState<uint> m_sampledMonitoredItemsCount;
  private BaseDataVariableState<uint> m_maxSampledMonitoredItemsCount;
  private BaseDataVariableState<uint> m_disabledMonitoredItemsSamplingCount;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2165U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 856U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJwAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc1R5cGVJbnN0YW5jZQEAdQgBAHUIdQgAAAEAWAP/////AQH/////BAAAABVgiQoCAAAAAAAQAAAAU2FtcGxpbmdJbnRlcnZhbAEAdggALwA/dggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAU2FtcGxlZE1vbml0b3JlZEl0ZW1zQ291bnQBALEtAC8AP7EtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABNYXhTYW1wbGVkTW9uaXRvcmVkSXRlbXNDb3VudAEAsi0ALwA/si0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAIwAAAERpc2FibGVkTW9uaXRvcmVkSXRlbXNTYW1wbGluZ0NvdW50AQCzLQAvAD+zLQAAAAf/////AQH/////AAAAAA==");
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

  public BaseDataVariableState<double> SamplingInterval
  {
    get => this.m_samplingInterval;
    set
    {
      if (this.m_samplingInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_samplingInterval = value;
    }
  }

  public BaseDataVariableState<uint> SampledMonitoredItemsCount
  {
    get => this.m_sampledMonitoredItemsCount;
    set
    {
      if (this.m_sampledMonitoredItemsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sampledMonitoredItemsCount = value;
    }
  }

  public BaseDataVariableState<uint> MaxSampledMonitoredItemsCount
  {
    get => this.m_maxSampledMonitoredItemsCount;
    set
    {
      if (this.m_maxSampledMonitoredItemsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxSampledMonitoredItemsCount = value;
    }
  }

  public BaseDataVariableState<uint> DisabledMonitoredItemsSamplingCount
  {
    get => this.m_disabledMonitoredItemsSamplingCount;
    set
    {
      if (this.m_disabledMonitoredItemsSamplingCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_disabledMonitoredItemsSamplingCount = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_samplingInterval != null)
      children.Add((BaseInstanceState) this.m_samplingInterval);
    if (this.m_sampledMonitoredItemsCount != null)
      children.Add((BaseInstanceState) this.m_sampledMonitoredItemsCount);
    if (this.m_maxSampledMonitoredItemsCount != null)
      children.Add((BaseInstanceState) this.m_maxSampledMonitoredItemsCount);
    if (this.m_disabledMonitoredItemsSamplingCount != null)
      children.Add((BaseInstanceState) this.m_disabledMonitoredItemsSamplingCount);
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
      case "SamplingInterval":
        if (createOrReplace && this.SamplingInterval == null)
          this.SamplingInterval = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SamplingInterval;
        break;
      case "SampledMonitoredItemsCount":
        if (createOrReplace && this.SampledMonitoredItemsCount == null)
          this.SampledMonitoredItemsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SampledMonitoredItemsCount;
        break;
      case "MaxSampledMonitoredItemsCount":
        if (createOrReplace && this.MaxSampledMonitoredItemsCount == null)
          this.MaxSampledMonitoredItemsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxSampledMonitoredItemsCount;
        break;
      case "DisabledMonitoredItemsSamplingCount":
        if (createOrReplace && this.DisabledMonitoredItemsSamplingCount == null)
          this.DisabledMonitoredItemsSamplingCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DisabledMonitoredItemsSamplingCount;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
