// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoricalDataConfigurationState
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
public class HistoricalDataConfigurationState(NodeState parent) : BaseObjectState(parent)
{
  private const string AggregateFunctions_InitializationString = "//////////8EYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAA";
  private const string Definition_InitializationString = "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BABQJAC4ARBQJAAAADP////8BAf////8AAAAA";
  private const string MaxTimeInterval_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAAA==";
  private const string MinTimeInterval_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1pblRpbWVJbnRlcnZhbAEAFgkALgBEFgkAAAEAIgH/////AQH/////AAAAAA==";
  private const string ExceptionDeviation_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAEV4Y2VwdGlvbkRldmlhdGlvbgEAFwkALgBEFwkAAAAL/////wEB/////wAAAAA=";
  private const string ExceptionDeviationFormat_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAEV4Y2VwdGlvbkRldmlhdGlvbkZvcm1hdAEAGAkALgBEGAkAAAEAegP/////AQH/////AAAAAA==";
  private const string StartOfArchive_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAA";
  private const string StartOfOnlineArchive_InitializationString = "//////////8VYIkKAgAAAAAAFAAAAFN0YXJ0T2ZPbmxpbmVBcmNoaXZlAQDsLAAuAETsLAAAAQAmAf////8BAf////8AAAAA";
  private const string ServerTimestampSupported_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAFNlcnZlclRpbWVzdGFtcFN1cHBvcnRlZAEAlEoALgBElEoAAAAB/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEhpc3RvcmljYWxEYXRhQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEADgkBAA4JDgkAAP////8LAAAABGCACgEAAAAAABYAAABBZ2dyZWdhdGVDb25maWd1cmF0aW9uAQDzCwAvAQCzK/MLAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAoCsALgBEoCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQChKwAuAEShKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQCiKwAuAESiKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAoysALgBEoysAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAAFWCJCgIAAAAAAAcAAABTdGVwcGVkAQATCQAuAEQTCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARGVmaW5pdGlvbgEAFAkALgBEFAkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAATWluVGltZUludGVydmFsAQAWCQAuAEQWCQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABFeGNlcHRpb25EZXZpYXRpb24BABcJAC4ARBcJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABFeGNlcHRpb25EZXZpYXRpb25Gb3JtYXQBABgJAC4ARBgJAAABAHoD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABTdGFydE9mT25saW5lQXJjaGl2ZQEA7CwALgBE7CwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCUSgAuAESUSgAAAAH/////AQH/////AAAAAA==";
  private AggregateConfigurationState m_aggregateConfiguration;
  private FolderState m_aggregateFunctions;
  private PropertyState<bool> m_stepped;
  private PropertyState<string> m_definition;
  private PropertyState<double> m_maxTimeInterval;
  private PropertyState<double> m_minTimeInterval;
  private PropertyState<double> m_exceptionDeviation;
  private PropertyState<Opc.Ua.ExceptionDeviationFormat> m_exceptionDeviationFormat;
  private PropertyState<DateTime> m_startOfArchive;
  private PropertyState<DateTime> m_startOfOnlineArchive;
  private PropertyState<bool> m_serverTimestampSupported;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2318U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEhpc3RvcmljYWxEYXRhQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEADgkBAA4JDgkAAP////8LAAAABGCACgEAAAAAABYAAABBZ2dyZWdhdGVDb25maWd1cmF0aW9uAQDzCwAvAQCzK/MLAAD/////BAAAABVgiQoCAAAAAAATAAAAVHJlYXRVbmNlcnRhaW5Bc0JhZAEAoCsALgBEoCsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFBlcmNlbnREYXRhQmFkAQChKwAuAEShKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUGVyY2VudERhdGFHb29kAQCiKwAuAESiKwAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAVXNlU2xvcGVkRXh0cmFwb2xhdGlvbgEAoysALgBEoysAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAAFWCJCgIAAAAAAAcAAABTdGVwcGVkAQATCQAuAEQTCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARGVmaW5pdGlvbgEAFAkALgBEFAkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAATWluVGltZUludGVydmFsAQAWCQAuAEQWCQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABFeGNlcHRpb25EZXZpYXRpb24BABcJAC4ARBcJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABFeGNlcHRpb25EZXZpYXRpb25Gb3JtYXQBABgJAC4ARBgJAAABAHoD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABTdGFydE9mT25saW5lQXJjaGl2ZQEA7CwALgBE7CwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCUSgAuAESUSgAAAAH/////AQH/////AAAAAA==");
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
    if (this.AggregateFunctions != null)
      this.AggregateFunctions.Initialize(context, "//////////8EYIAKAQAAAAAAEgAAAEFnZ3JlZ2F0ZUZ1bmN0aW9ucwEAZC4ALwA9ZC4AAP////8AAAAA");
    if (this.Definition != null)
      this.Definition.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAERlZmluaXRpb24BABQJAC4ARBQJAAAADP////8BAf////8AAAAA");
    if (this.MaxTimeInterval != null)
      this.MaxTimeInterval.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1heFRpbWVJbnRlcnZhbAEAFQkALgBEFQkAAAEAIgH/////AQH/////AAAAAA==");
    if (this.MinTimeInterval != null)
      this.MinTimeInterval.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1pblRpbWVJbnRlcnZhbAEAFgkALgBEFgkAAAEAIgH/////AQH/////AAAAAA==");
    if (this.ExceptionDeviation != null)
      this.ExceptionDeviation.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAEV4Y2VwdGlvbkRldmlhdGlvbgEAFwkALgBEFwkAAAAL/////wEB/////wAAAAA=");
    if (this.ExceptionDeviationFormat != null)
      this.ExceptionDeviationFormat.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAEV4Y2VwdGlvbkRldmlhdGlvbkZvcm1hdAEAGAkALgBEGAkAAAEAegP/////AQH/////AAAAAA==");
    if (this.StartOfArchive != null)
      this.StartOfArchive.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFN0YXJ0T2ZBcmNoaXZlAQDrLAAuAETrLAAAAQAmAf////8BAf////8AAAAA");
    if (this.StartOfOnlineArchive != null)
      this.StartOfOnlineArchive.Initialize(context, "//////////8VYIkKAgAAAAAAFAAAAFN0YXJ0T2ZPbmxpbmVBcmNoaXZlAQDsLAAuAETsLAAAAQAmAf////8BAf////8AAAAA");
    if (this.ServerTimestampSupported == null)
      return;
    this.ServerTimestampSupported.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAFNlcnZlclRpbWVzdGFtcFN1cHBvcnRlZAEAlEoALgBElEoAAAAB/////wEB/////wAAAAA=");
  }

  public AggregateConfigurationState AggregateConfiguration
  {
    get => this.m_aggregateConfiguration;
    set
    {
      if (this.m_aggregateConfiguration != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_aggregateConfiguration = value;
    }
  }

  public FolderState AggregateFunctions
  {
    get => this.m_aggregateFunctions;
    set
    {
      if (this.m_aggregateFunctions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_aggregateFunctions = value;
    }
  }

  public PropertyState<bool> Stepped
  {
    get => this.m_stepped;
    set
    {
      if (this.m_stepped != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_stepped = value;
    }
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

  public PropertyState<double> MaxTimeInterval
  {
    get => this.m_maxTimeInterval;
    set
    {
      if (this.m_maxTimeInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxTimeInterval = value;
    }
  }

  public PropertyState<double> MinTimeInterval
  {
    get => this.m_minTimeInterval;
    set
    {
      if (this.m_minTimeInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_minTimeInterval = value;
    }
  }

  public PropertyState<double> ExceptionDeviation
  {
    get => this.m_exceptionDeviation;
    set
    {
      if (this.m_exceptionDeviation != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_exceptionDeviation = value;
    }
  }

  public PropertyState<Opc.Ua.ExceptionDeviationFormat> ExceptionDeviationFormat
  {
    get => this.m_exceptionDeviationFormat;
    set
    {
      if (this.m_exceptionDeviationFormat != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_exceptionDeviationFormat = value;
    }
  }

  public PropertyState<DateTime> StartOfArchive
  {
    get => this.m_startOfArchive;
    set
    {
      if (this.m_startOfArchive != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_startOfArchive = value;
    }
  }

  public PropertyState<DateTime> StartOfOnlineArchive
  {
    get => this.m_startOfOnlineArchive;
    set
    {
      if (this.m_startOfOnlineArchive != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_startOfOnlineArchive = value;
    }
  }

  public PropertyState<bool> ServerTimestampSupported
  {
    get => this.m_serverTimestampSupported;
    set
    {
      if (this.m_serverTimestampSupported != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverTimestampSupported = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_aggregateConfiguration != null)
      children.Add((BaseInstanceState) this.m_aggregateConfiguration);
    if (this.m_aggregateFunctions != null)
      children.Add((BaseInstanceState) this.m_aggregateFunctions);
    if (this.m_stepped != null)
      children.Add((BaseInstanceState) this.m_stepped);
    if (this.m_definition != null)
      children.Add((BaseInstanceState) this.m_definition);
    if (this.m_maxTimeInterval != null)
      children.Add((BaseInstanceState) this.m_maxTimeInterval);
    if (this.m_minTimeInterval != null)
      children.Add((BaseInstanceState) this.m_minTimeInterval);
    if (this.m_exceptionDeviation != null)
      children.Add((BaseInstanceState) this.m_exceptionDeviation);
    if (this.m_exceptionDeviationFormat != null)
      children.Add((BaseInstanceState) this.m_exceptionDeviationFormat);
    if (this.m_startOfArchive != null)
      children.Add((BaseInstanceState) this.m_startOfArchive);
    if (this.m_startOfOnlineArchive != null)
      children.Add((BaseInstanceState) this.m_startOfOnlineArchive);
    if (this.m_serverTimestampSupported != null)
      children.Add((BaseInstanceState) this.m_serverTimestampSupported);
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
        case 7:
          if (name == "Stepped")
          {
            if (createOrReplace && this.Stepped == null)
              this.Stepped = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Stepped;
            break;
          }
          break;
        case 10:
          if (name == "Definition")
          {
            if (createOrReplace && this.Definition == null)
              this.Definition = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Definition;
            break;
          }
          break;
        case 14:
          if (name == "StartOfArchive")
          {
            if (createOrReplace && this.StartOfArchive == null)
              this.StartOfArchive = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.StartOfArchive;
            break;
          }
          break;
        case 15:
          switch (name[1])
          {
            case 'a':
              if (name == "MaxTimeInterval")
              {
                if (createOrReplace && this.MaxTimeInterval == null)
                  this.MaxTimeInterval = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxTimeInterval;
                break;
              }
              break;
            case 'i':
              if (name == "MinTimeInterval")
              {
                if (createOrReplace && this.MinTimeInterval == null)
                  this.MinTimeInterval = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MinTimeInterval;
                break;
              }
              break;
          }
          break;
        case 18:
          switch (name[0])
          {
            case 'A':
              if (name == "AggregateFunctions")
              {
                if (createOrReplace && this.AggregateFunctions == null)
                  this.AggregateFunctions = replacement != null ? (FolderState) replacement : new FolderState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AggregateFunctions;
                break;
              }
              break;
            case 'E':
              if (name == "ExceptionDeviation")
              {
                if (createOrReplace && this.ExceptionDeviation == null)
                  this.ExceptionDeviation = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ExceptionDeviation;
                break;
              }
              break;
          }
          break;
        case 20:
          if (name == "StartOfOnlineArchive")
          {
            if (createOrReplace && this.StartOfOnlineArchive == null)
              this.StartOfOnlineArchive = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.StartOfOnlineArchive;
            break;
          }
          break;
        case 22:
          if (name == "AggregateConfiguration")
          {
            if (createOrReplace && this.AggregateConfiguration == null)
              this.AggregateConfiguration = replacement != null ? (AggregateConfigurationState) replacement : new AggregateConfigurationState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AggregateConfiguration;
            break;
          }
          break;
        case 24:
          switch (name[0])
          {
            case 'E':
              if (name == "ExceptionDeviationFormat")
              {
                if (createOrReplace && this.ExceptionDeviationFormat == null)
                  this.ExceptionDeviationFormat = replacement != null ? (PropertyState<Opc.Ua.ExceptionDeviationFormat>) replacement : new PropertyState<Opc.Ua.ExceptionDeviationFormat>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ExceptionDeviationFormat;
                break;
              }
              break;
            case 'S':
              if (name == "ServerTimestampSupported")
              {
                if (createOrReplace && this.ServerTimestampSupported == null)
                  this.ServerTimestampSupported = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerTimestampSupported;
                break;
              }
              break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
