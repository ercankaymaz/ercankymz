// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AlarmMetricsState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AlarmMetricsState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAEFsYXJtTWV0cmljc1R5cGVJbnN0YW5jZQEAf0MBAH9Df0MAAP////8JAAAAFWCJCgIAAAAAAAoAAABBbGFybUNvdW50AQCAQwAvAD+AQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBHRgAvAD9HRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABNYXhpbXVtQWN0aXZlU3RhdGUBAIFDAC8AP4FDAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAE1heGltdW1VbkFjawEAgkMALwA/gkMAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3VycmVudEFsYXJtUmF0ZQEAhEMALwEAfUOEQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAhUMALgBEhUMAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heGltdW1BbGFybVJhdGUBAIZDAC8BAH1DhkMAAAAL/////wEB/////wEAAAAVYIkKAgAAAAAABAAAAFJhdGUBAIdDAC4ARIdDAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhpbXVtUmVBbGFybUNvdW50AQCDQwAvAD+DQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQXZlcmFnZUFsYXJtUmF0ZQEAiEMALwEAfUOIQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAiUMALgBEiUMAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQDqSAAvAQDqSOpIAAABAQEAAAABAPkLAAEATwgAAAAA";
  private BaseDataVariableState<uint> m_alarmCount;
  private BaseDataVariableState<DateTime> m_startTime;
  private BaseDataVariableState<double> m_maximumActiveState;
  private BaseDataVariableState<double> m_maximumUnAck;
  private AlarmRateVariableState m_currentAlarmRate;
  private AlarmRateVariableState m_maximumAlarmRate;
  private BaseDataVariableState<uint> m_maximumReAlarmCount;
  private AlarmRateVariableState m_averageAlarmRate;
  private MethodState m_resetMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17279U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGAAAAEFsYXJtTWV0cmljc1R5cGVJbnN0YW5jZQEAf0MBAH9Df0MAAP////8JAAAAFWCJCgIAAAAAAAoAAABBbGFybUNvdW50AQCAQwAvAD+AQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBHRgAvAD9HRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABNYXhpbXVtQWN0aXZlU3RhdGUBAIFDAC8AP4FDAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAE1heGltdW1VbkFjawEAgkMALwA/gkMAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3VycmVudEFsYXJtUmF0ZQEAhEMALwEAfUOEQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAhUMALgBEhUMAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heGltdW1BbGFybVJhdGUBAIZDAC8BAH1DhkMAAAAL/////wEB/////wEAAAAVYIkKAgAAAAAABAAAAFJhdGUBAIdDAC4ARIdDAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhpbXVtUmVBbGFybUNvdW50AQCDQwAvAD+DQwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQXZlcmFnZUFsYXJtUmF0ZQEAiEMALwEAfUOIQwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAiUMALgBEiUMAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQDqSAAvAQDqSOpIAAABAQEAAAABAPkLAAEATwgAAAAA");
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

  public BaseDataVariableState<uint> AlarmCount
  {
    get => this.m_alarmCount;
    set
    {
      if (this.m_alarmCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_alarmCount = value;
    }
  }

  public BaseDataVariableState<DateTime> StartTime
  {
    get => this.m_startTime;
    set
    {
      if (this.m_startTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_startTime = value;
    }
  }

  public BaseDataVariableState<double> MaximumActiveState
  {
    get => this.m_maximumActiveState;
    set
    {
      if (this.m_maximumActiveState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maximumActiveState = value;
    }
  }

  public BaseDataVariableState<double> MaximumUnAck
  {
    get => this.m_maximumUnAck;
    set
    {
      if (this.m_maximumUnAck != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maximumUnAck = value;
    }
  }

  public AlarmRateVariableState CurrentAlarmRate
  {
    get => this.m_currentAlarmRate;
    set
    {
      if (this.m_currentAlarmRate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentAlarmRate = value;
    }
  }

  public AlarmRateVariableState MaximumAlarmRate
  {
    get => this.m_maximumAlarmRate;
    set
    {
      if (this.m_maximumAlarmRate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maximumAlarmRate = value;
    }
  }

  public BaseDataVariableState<uint> MaximumReAlarmCount
  {
    get => this.m_maximumReAlarmCount;
    set
    {
      if (this.m_maximumReAlarmCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maximumReAlarmCount = value;
    }
  }

  public AlarmRateVariableState AverageAlarmRate
  {
    get => this.m_averageAlarmRate;
    set
    {
      if (this.m_averageAlarmRate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_averageAlarmRate = value;
    }
  }

  public MethodState Reset
  {
    get => this.m_resetMethod;
    set
    {
      if (this.m_resetMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_resetMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_alarmCount != null)
      children.Add((BaseInstanceState) this.m_alarmCount);
    if (this.m_startTime != null)
      children.Add((BaseInstanceState) this.m_startTime);
    if (this.m_maximumActiveState != null)
      children.Add((BaseInstanceState) this.m_maximumActiveState);
    if (this.m_maximumUnAck != null)
      children.Add((BaseInstanceState) this.m_maximumUnAck);
    if (this.m_currentAlarmRate != null)
      children.Add((BaseInstanceState) this.m_currentAlarmRate);
    if (this.m_maximumAlarmRate != null)
      children.Add((BaseInstanceState) this.m_maximumAlarmRate);
    if (this.m_maximumReAlarmCount != null)
      children.Add((BaseInstanceState) this.m_maximumReAlarmCount);
    if (this.m_averageAlarmRate != null)
      children.Add((BaseInstanceState) this.m_averageAlarmRate);
    if (this.m_resetMethod != null)
      children.Add((BaseInstanceState) this.m_resetMethod);
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
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 5:
          if (name == "Reset")
          {
            if (createOrReplace && this.Reset == null)
              this.Reset = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Reset;
            break;
          }
          break;
        case 9:
          if (name == "StartTime")
          {
            if (createOrReplace && this.StartTime == null)
              this.StartTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.StartTime;
            break;
          }
          break;
        case 10:
          if (name == "AlarmCount")
          {
            if (createOrReplace && this.AlarmCount == null)
              this.AlarmCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AlarmCount;
            break;
          }
          break;
        case 12:
          if (name == "MaximumUnAck")
          {
            if (createOrReplace && this.MaximumUnAck == null)
              this.MaximumUnAck = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaximumUnAck;
            break;
          }
          break;
        case 16 /*0x10*/:
          switch (name[0])
          {
            case 'A':
              if (name == "AverageAlarmRate")
              {
                if (createOrReplace && this.AverageAlarmRate == null)
                  this.AverageAlarmRate = replacement != null ? (AlarmRateVariableState) replacement : new AlarmRateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AverageAlarmRate;
                break;
              }
              break;
            case 'C':
              if (name == "CurrentAlarmRate")
              {
                if (createOrReplace && this.CurrentAlarmRate == null)
                  this.CurrentAlarmRate = replacement != null ? (AlarmRateVariableState) replacement : new AlarmRateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CurrentAlarmRate;
                break;
              }
              break;
            case 'M':
              if (name == "MaximumAlarmRate")
              {
                if (createOrReplace && this.MaximumAlarmRate == null)
                  this.MaximumAlarmRate = replacement != null ? (AlarmRateVariableState) replacement : new AlarmRateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaximumAlarmRate;
                break;
              }
              break;
          }
          break;
        case 18:
          if (name == "MaximumActiveState")
          {
            if (createOrReplace && this.MaximumActiveState == null)
              this.MaximumActiveState = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaximumActiveState;
            break;
          }
          break;
        case 19:
          if (name == "MaximumReAlarmCount")
          {
            if (createOrReplace && this.MaximumReAlarmCount == null)
              this.MaximumReAlarmCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaximumReAlarmCount;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
