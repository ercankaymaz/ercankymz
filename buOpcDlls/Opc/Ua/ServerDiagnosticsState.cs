// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerDiagnosticsState
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
public class ServerDiagnosticsState(NodeState parent) : BaseObjectState(parent)
{
  private const string SamplingIntervalDiagnosticsArray_InitializationString = "//////////8XYIkKAgAAAAAAIAAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc0FycmF5AQDmBwAvAQB0COYHAAABAFgDAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFNlcnZlckRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDkBwEA5AfkBwAA/////wUAAAAVYIkKAgAAAAAAGAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeQEA5QcALwEAZgjlBwAAAQBbA/////8BAf////8MAAAAFWCJCgIAAAAAAA8AAABTZXJ2ZXJWaWV3Q291bnQBACwMAC8APywMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABDdXJyZW50U2Vzc2lvbkNvdW50AQAtDAAvAD8tDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAQ3VtdWxhdGVkU2Vzc2lvbkNvdW50AQAuDAAvAD8uDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAAU2VjdXJpdHlSZWplY3RlZFNlc3Npb25Db3VudAEALwwALwA/LwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFJlamVjdGVkU2Vzc2lvbkNvdW50AQAwDAAvAD8wDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU2Vzc2lvblRpbWVvdXRDb3VudAEAMQwALwA/MQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlc3Npb25BYm9ydENvdW50AQAyDAAvAD8yDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAUHVibGlzaGluZ0ludGVydmFsQ291bnQBADQMAC8APzQMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABDdXJyZW50U3Vic2NyaXB0aW9uQ291bnQBADUMAC8APzUMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdW11bGF0ZWRTdWJzY3JpcHRpb25Db3VudAEANgwALwA/NgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAFNlY3VyaXR5UmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA3DAAvAD83DAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA4DAAvAD84DAAAAAf/////AQH/////AAAAABdgiQoCAAAAAAAgAAAAU2FtcGxpbmdJbnRlcnZhbERpYWdub3N0aWNzQXJyYXkBAOYHAC8BAHQI5gcAAAEAWAMBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABwAAABTdWJzY3JpcHRpb25EaWFnbm9zdGljc0FycmF5AQDnBwAvAQB7COcHAAABAGoDAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAaAAAAU2Vzc2lvbnNEaWFnbm9zdGljc1N1bW1hcnkBALgKAC8BAOoHuAoAAP////8CAAAAF2CJCgIAAAAAABcAAABTZXNzaW9uRGlhZ25vc3RpY3NBcnJheQEAOQwALwEAlAg5DAAAAQBhAwEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAHwAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzQXJyYXkBADoMAC8BAMMIOgwAAAEAZAMBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVkRmxhZwEA6QcALgBE6QcAAAAB/////wMD/////wAAAAA=";
  private ServerDiagnosticsSummaryState m_serverDiagnosticsSummary;
  private SamplingIntervalDiagnosticsArrayState m_samplingIntervalDiagnosticsArray;
  private SubscriptionDiagnosticsArrayState m_subscriptionDiagnosticsArray;
  private SessionsDiagnosticsSummaryState m_sessionsDiagnosticsSummary;
  private PropertyState<bool> m_enabledFlag;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2020U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFNlcnZlckRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDkBwEA5AfkBwAA/////wUAAAAVYIkKAgAAAAAAGAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeQEA5QcALwEAZgjlBwAAAQBbA/////8BAf////8MAAAAFWCJCgIAAAAAAA8AAABTZXJ2ZXJWaWV3Q291bnQBACwMAC8APywMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABDdXJyZW50U2Vzc2lvbkNvdW50AQAtDAAvAD8tDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAQ3VtdWxhdGVkU2Vzc2lvbkNvdW50AQAuDAAvAD8uDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAAU2VjdXJpdHlSZWplY3RlZFNlc3Npb25Db3VudAEALwwALwA/LwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFJlamVjdGVkU2Vzc2lvbkNvdW50AQAwDAAvAD8wDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU2Vzc2lvblRpbWVvdXRDb3VudAEAMQwALwA/MQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlc3Npb25BYm9ydENvdW50AQAyDAAvAD8yDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAUHVibGlzaGluZ0ludGVydmFsQ291bnQBADQMAC8APzQMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABDdXJyZW50U3Vic2NyaXB0aW9uQ291bnQBADUMAC8APzUMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdW11bGF0ZWRTdWJzY3JpcHRpb25Db3VudAEANgwALwA/NgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAFNlY3VyaXR5UmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA3DAAvAD83DAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmVqZWN0ZWRSZXF1ZXN0c0NvdW50AQA4DAAvAD84DAAAAAf/////AQH/////AAAAABdgiQoCAAAAAAAgAAAAU2FtcGxpbmdJbnRlcnZhbERpYWdub3N0aWNzQXJyYXkBAOYHAC8BAHQI5gcAAAEAWAMBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABwAAABTdWJzY3JpcHRpb25EaWFnbm9zdGljc0FycmF5AQDnBwAvAQB7COcHAAABAGoDAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAaAAAAU2Vzc2lvbnNEaWFnbm9zdGljc1N1bW1hcnkBALgKAC8BAOoHuAoAAP////8CAAAAF2CJCgIAAAAAABcAAABTZXNzaW9uRGlhZ25vc3RpY3NBcnJheQEAOQwALwEAlAg5DAAAAQBhAwEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAHwAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzQXJyYXkBADoMAC8BAMMIOgwAAAEAZAMBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmFibGVkRmxhZwEA6QcALgBE6QcAAAAB/////wMD/////wAAAAA=");
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
    if (this.SamplingIntervalDiagnosticsArray == null)
      return;
    this.SamplingIntervalDiagnosticsArray.Initialize(context, "//////////8XYIkKAgAAAAAAIAAAAFNhbXBsaW5nSW50ZXJ2YWxEaWFnbm9zdGljc0FycmF5AQDmBwAvAQB0COYHAAABAFgDAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public ServerDiagnosticsSummaryState ServerDiagnosticsSummary
  {
    get => this.m_serverDiagnosticsSummary;
    set
    {
      if (this.m_serverDiagnosticsSummary != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverDiagnosticsSummary = value;
    }
  }

  public SamplingIntervalDiagnosticsArrayState SamplingIntervalDiagnosticsArray
  {
    get => this.m_samplingIntervalDiagnosticsArray;
    set
    {
      if (this.m_samplingIntervalDiagnosticsArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_samplingIntervalDiagnosticsArray = value;
    }
  }

  public SubscriptionDiagnosticsArrayState SubscriptionDiagnosticsArray
  {
    get => this.m_subscriptionDiagnosticsArray;
    set
    {
      if (this.m_subscriptionDiagnosticsArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_subscriptionDiagnosticsArray = value;
    }
  }

  public SessionsDiagnosticsSummaryState SessionsDiagnosticsSummary
  {
    get => this.m_sessionsDiagnosticsSummary;
    set
    {
      if (this.m_sessionsDiagnosticsSummary != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionsDiagnosticsSummary = value;
    }
  }

  public PropertyState<bool> EnabledFlag
  {
    get => this.m_enabledFlag;
    set
    {
      if (this.m_enabledFlag != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enabledFlag = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serverDiagnosticsSummary != null)
      children.Add((BaseInstanceState) this.m_serverDiagnosticsSummary);
    if (this.m_samplingIntervalDiagnosticsArray != null)
      children.Add((BaseInstanceState) this.m_samplingIntervalDiagnosticsArray);
    if (this.m_subscriptionDiagnosticsArray != null)
      children.Add((BaseInstanceState) this.m_subscriptionDiagnosticsArray);
    if (this.m_sessionsDiagnosticsSummary != null)
      children.Add((BaseInstanceState) this.m_sessionsDiagnosticsSummary);
    if (this.m_enabledFlag != null)
      children.Add((BaseInstanceState) this.m_enabledFlag);
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
      case "ServerDiagnosticsSummary":
        if (createOrReplace && this.ServerDiagnosticsSummary == null)
          this.ServerDiagnosticsSummary = replacement != null ? (ServerDiagnosticsSummaryState) replacement : new ServerDiagnosticsSummaryState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ServerDiagnosticsSummary;
        break;
      case "SamplingIntervalDiagnosticsArray":
        if (createOrReplace && this.SamplingIntervalDiagnosticsArray == null)
          this.SamplingIntervalDiagnosticsArray = replacement != null ? (SamplingIntervalDiagnosticsArrayState) replacement : new SamplingIntervalDiagnosticsArrayState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SamplingIntervalDiagnosticsArray;
        break;
      case "SubscriptionDiagnosticsArray":
        if (createOrReplace && this.SubscriptionDiagnosticsArray == null)
          this.SubscriptionDiagnosticsArray = replacement != null ? (SubscriptionDiagnosticsArrayState) replacement : new SubscriptionDiagnosticsArrayState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SubscriptionDiagnosticsArray;
        break;
      case "SessionsDiagnosticsSummary":
        if (createOrReplace && this.SessionsDiagnosticsSummary == null)
          this.SessionsDiagnosticsSummary = replacement != null ? (SessionsDiagnosticsSummaryState) replacement : new SessionsDiagnosticsSummaryState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SessionsDiagnosticsSummary;
        break;
      case "EnabledFlag":
        if (createOrReplace && this.EnabledFlag == null)
          this.EnabledFlag = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EnabledFlag;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
