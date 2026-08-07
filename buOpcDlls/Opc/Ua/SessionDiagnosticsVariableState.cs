// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionDiagnosticsVariableState
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
public class SessionDiagnosticsVariableState(NodeState parent) : 
  BaseDataVariableState<SessionDiagnosticsDataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25EaWFnbm9zdGljc1ZhcmlhYmxlVHlwZUluc3RhbmNlAQCVCAEAlQiVCAAAAQBhA/////8BAf////8rAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAJYIAC8AP5YIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTZXNzaW9uTmFtZQEAlwgALwA/lwgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudERlc2NyaXB0aW9uAQCYCAAvAD+YCAAAAQA0Af////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXJ2ZXJVcmkBAJkIAC8AP5kIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAmggALwA/mggAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACQAAAExvY2FsZUlkcwEAmwgALwA/mwgAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABQAAABBY3R1YWxTZXNzaW9uVGltZW91dAEAnAgALwA/nAgAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATWF4UmVzcG9uc2VNZXNzYWdlU2l6ZQEA6gsALwA/6gsAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAENsaWVudENvbm5lY3Rpb25UaW1lAQCdCAAvAD+dCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRMYXN0Q29udGFjdFRpbWUBAJ4IAC8AP54IAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAEN1cnJlbnRTdWJzY3JpcHRpb25zQ291bnQBAJ8IAC8AP58IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdXJyZW50TW9uaXRvcmVkSXRlbXNDb3VudAEAoAgALwA/oAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAEN1cnJlbnRQdWJsaXNoUmVxdWVzdHNJblF1ZXVlAQChCAAvAD+hCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVG90YWxSZXF1ZXN0Q291bnQBAMQiAC8AP8QiAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFVuYXV0aG9yaXplZFJlcXVlc3RDb3VudAEAdC4ALwA/dC4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFJlYWRDb3VudAEAqQgALwA/qQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASGlzdG9yeVJlYWRDb3VudAEAqggALwA/qggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAV3JpdGVDb3VudAEAqwgALwA/qwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAASGlzdG9yeVVwZGF0ZUNvdW50AQCsCAAvAD+sCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABDYWxsQ291bnQBAK0IAC8AP60IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAENyZWF0ZU1vbml0b3JlZEl0ZW1zQ291bnQBAK4IAC8AP64IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1vZGlmeU1vbml0b3JlZEl0ZW1zQ291bnQBAK8IAC8AP68IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAFNldE1vbml0b3JpbmdNb2RlQ291bnQBALAIAC8AP7AIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFNldFRyaWdnZXJpbmdDb3VudAEAsQgALwA/sQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGVsZXRlTW9uaXRvcmVkSXRlbXNDb3VudAEAsggALwA/sggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ3JlYXRlU3Vic2NyaXB0aW9uQ291bnQBALMIAC8AP7MIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAE1vZGlmeVN1YnNjcmlwdGlvbkNvdW50AQC0CAAvAD+0CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABYAAABTZXRQdWJsaXNoaW5nTW9kZUNvdW50AQC1CAAvAD+1CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABQdWJsaXNoQ291bnQBALYIAC8AP7YIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFJlcHVibGlzaENvdW50AQC3CAAvAD+3CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABUcmFuc2ZlclN1YnNjcmlwdGlvbnNDb3VudAEAuAgALwA/uAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAYAAAARGVsZXRlU3Vic2NyaXB0aW9uc0NvdW50AQC5CAAvAD+5CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBZGROb2Rlc0NvdW50AQC6CAAvAD+6CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBZGRSZWZlcmVuY2VzQ291bnQBALsIAC8AP7sIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERlbGV0ZU5vZGVzQ291bnQBALwIAC8AP7wIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAERlbGV0ZVJlZmVyZW5jZXNDb3VudAEAvQgALwA/vQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQnJvd3NlQ291bnQBAL4IAC8AP74IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJyb3dzZU5leHRDb3VudAEAvwgALwA/vwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAiAAAAVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHNDb3VudAEAwAgALwA/wAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUXVlcnlGaXJzdENvdW50AQDBCAAvAD/BCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABRdWVyeU5leHRDb3VudAEAwggALwA/wggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUmVnaXN0ZXJOb2Rlc0NvdW50AQCqCgAvAD+qCgAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABVbnJlZ2lzdGVyTm9kZXNDb3VudAEAqwoALwA/qwoAAAEAZwP/////AQH/////AAAAAA==";
  private BaseDataVariableState<NodeId> m_sessionId;
  private BaseDataVariableState<string> m_sessionName;
  private BaseDataVariableState<ApplicationDescription> m_clientDescription;
  private BaseDataVariableState<string> m_serverUri;
  private BaseDataVariableState<string> m_endpointUrl;
  private BaseDataVariableState<string[]> m_localeIds;
  private BaseDataVariableState<double> m_actualSessionTimeout;
  private BaseDataVariableState<uint> m_maxResponseMessageSize;
  private BaseDataVariableState<DateTime> m_clientConnectionTime;
  private BaseDataVariableState<DateTime> m_clientLastContactTime;
  private BaseDataVariableState<uint> m_currentSubscriptionsCount;
  private BaseDataVariableState<uint> m_currentMonitoredItemsCount;
  private BaseDataVariableState<uint> m_currentPublishRequestsInQueue;
  private BaseDataVariableState<ServiceCounterDataType> m_totalRequestCount;
  private BaseDataVariableState<uint> m_unauthorizedRequestCount;
  private BaseDataVariableState<ServiceCounterDataType> m_readCount;
  private BaseDataVariableState<ServiceCounterDataType> m_historyReadCount;
  private BaseDataVariableState<ServiceCounterDataType> m_writeCount;
  private BaseDataVariableState<ServiceCounterDataType> m_historyUpdateCount;
  private BaseDataVariableState<ServiceCounterDataType> m_callCount;
  private BaseDataVariableState<ServiceCounterDataType> m_createMonitoredItemsCount;
  private BaseDataVariableState<ServiceCounterDataType> m_modifyMonitoredItemsCount;
  private BaseDataVariableState<ServiceCounterDataType> m_setMonitoringModeCount;
  private BaseDataVariableState<ServiceCounterDataType> m_setTriggeringCount;
  private BaseDataVariableState<ServiceCounterDataType> m_deleteMonitoredItemsCount;
  private BaseDataVariableState<ServiceCounterDataType> m_createSubscriptionCount;
  private BaseDataVariableState<ServiceCounterDataType> m_modifySubscriptionCount;
  private BaseDataVariableState<ServiceCounterDataType> m_setPublishingModeCount;
  private BaseDataVariableState<ServiceCounterDataType> m_publishCount;
  private BaseDataVariableState<ServiceCounterDataType> m_republishCount;
  private BaseDataVariableState<ServiceCounterDataType> m_transferSubscriptionsCount;
  private BaseDataVariableState<ServiceCounterDataType> m_deleteSubscriptionsCount;
  private BaseDataVariableState<ServiceCounterDataType> m_addNodesCount;
  private BaseDataVariableState<ServiceCounterDataType> m_addReferencesCount;
  private BaseDataVariableState<ServiceCounterDataType> m_deleteNodesCount;
  private BaseDataVariableState<ServiceCounterDataType> m_deleteReferencesCount;
  private BaseDataVariableState<ServiceCounterDataType> m_browseCount;
  private BaseDataVariableState<ServiceCounterDataType> m_browseNextCount;
  private BaseDataVariableState<ServiceCounterDataType> m_translateBrowsePathsToNodeIdsCount;
  private BaseDataVariableState<ServiceCounterDataType> m_queryFirstCount;
  private BaseDataVariableState<ServiceCounterDataType> m_queryNextCount;
  private BaseDataVariableState<ServiceCounterDataType> m_registerNodesCount;
  private BaseDataVariableState<ServiceCounterDataType> m_unregisterNodesCount;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2197U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 865U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25EaWFnbm9zdGljc1ZhcmlhYmxlVHlwZUluc3RhbmNlAQCVCAEAlQiVCAAAAQBhA/////8BAf////8rAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAJYIAC8AP5YIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTZXNzaW9uTmFtZQEAlwgALwA/lwgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudERlc2NyaXB0aW9uAQCYCAAvAD+YCAAAAQA0Af////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXJ2ZXJVcmkBAJkIAC8AP5kIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAmggALwA/mggAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAACQAAAExvY2FsZUlkcwEAmwgALwA/mwgAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABQAAABBY3R1YWxTZXNzaW9uVGltZW91dAEAnAgALwA/nAgAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATWF4UmVzcG9uc2VNZXNzYWdlU2l6ZQEA6gsALwA/6gsAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAENsaWVudENvbm5lY3Rpb25UaW1lAQCdCAAvAD+dCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRMYXN0Q29udGFjdFRpbWUBAJ4IAC8AP54IAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAEN1cnJlbnRTdWJzY3JpcHRpb25zQ291bnQBAJ8IAC8AP58IAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABDdXJyZW50TW9uaXRvcmVkSXRlbXNDb3VudAEAoAgALwA/oAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHQAAAEN1cnJlbnRQdWJsaXNoUmVxdWVzdHNJblF1ZXVlAQChCAAvAD+hCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVG90YWxSZXF1ZXN0Q291bnQBAMQiAC8AP8QiAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFVuYXV0aG9yaXplZFJlcXVlc3RDb3VudAEAdC4ALwA/dC4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFJlYWRDb3VudAEAqQgALwA/qQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASGlzdG9yeVJlYWRDb3VudAEAqggALwA/qggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAV3JpdGVDb3VudAEAqwgALwA/qwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAASGlzdG9yeVVwZGF0ZUNvdW50AQCsCAAvAD+sCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABDYWxsQ291bnQBAK0IAC8AP60IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAENyZWF0ZU1vbml0b3JlZEl0ZW1zQ291bnQBAK4IAC8AP64IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1vZGlmeU1vbml0b3JlZEl0ZW1zQ291bnQBAK8IAC8AP68IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAFNldE1vbml0b3JpbmdNb2RlQ291bnQBALAIAC8AP7AIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFNldFRyaWdnZXJpbmdDb3VudAEAsQgALwA/sQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGVsZXRlTW9uaXRvcmVkSXRlbXNDb3VudAEAsggALwA/sggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ3JlYXRlU3Vic2NyaXB0aW9uQ291bnQBALMIAC8AP7MIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAE1vZGlmeVN1YnNjcmlwdGlvbkNvdW50AQC0CAAvAD+0CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABYAAABTZXRQdWJsaXNoaW5nTW9kZUNvdW50AQC1CAAvAD+1CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABQdWJsaXNoQ291bnQBALYIAC8AP7YIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFJlcHVibGlzaENvdW50AQC3CAAvAD+3CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABUcmFuc2ZlclN1YnNjcmlwdGlvbnNDb3VudAEAuAgALwA/uAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAYAAAARGVsZXRlU3Vic2NyaXB0aW9uc0NvdW50AQC5CAAvAD+5CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABBZGROb2Rlc0NvdW50AQC6CAAvAD+6CAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBZGRSZWZlcmVuY2VzQ291bnQBALsIAC8AP7sIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERlbGV0ZU5vZGVzQ291bnQBALwIAC8AP7wIAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAERlbGV0ZVJlZmVyZW5jZXNDb3VudAEAvQgALwA/vQgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQnJvd3NlQ291bnQBAL4IAC8AP74IAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJyb3dzZU5leHRDb3VudAEAvwgALwA/vwgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAiAAAAVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHNDb3VudAEAwAgALwA/wAgAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAUXVlcnlGaXJzdENvdW50AQDBCAAvAD/BCAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABRdWVyeU5leHRDb3VudAEAwggALwA/wggAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUmVnaXN0ZXJOb2Rlc0NvdW50AQCqCgAvAD+qCgAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABVbnJlZ2lzdGVyTm9kZXNDb3VudAEAqwoALwA/qwoAAAEAZwP/////AQH/////AAAAAA==");
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

  public BaseDataVariableState<NodeId> SessionId
  {
    get => this.m_sessionId;
    set
    {
      if (this.m_sessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionId = value;
    }
  }

  public BaseDataVariableState<string> SessionName
  {
    get => this.m_sessionName;
    set
    {
      if (this.m_sessionName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionName = value;
    }
  }

  public BaseDataVariableState<ApplicationDescription> ClientDescription
  {
    get => this.m_clientDescription;
    set
    {
      if (this.m_clientDescription != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientDescription = value;
    }
  }

  public BaseDataVariableState<string> ServerUri
  {
    get => this.m_serverUri;
    set
    {
      if (this.m_serverUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverUri = value;
    }
  }

  public BaseDataVariableState<string> EndpointUrl
  {
    get => this.m_endpointUrl;
    set
    {
      if (this.m_endpointUrl != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_endpointUrl = value;
    }
  }

  public BaseDataVariableState<string[]> LocaleIds
  {
    get => this.m_localeIds;
    set
    {
      if (this.m_localeIds != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_localeIds = value;
    }
  }

  public BaseDataVariableState<double> ActualSessionTimeout
  {
    get => this.m_actualSessionTimeout;
    set
    {
      if (this.m_actualSessionTimeout != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_actualSessionTimeout = value;
    }
  }

  public BaseDataVariableState<uint> MaxResponseMessageSize
  {
    get => this.m_maxResponseMessageSize;
    set
    {
      if (this.m_maxResponseMessageSize != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxResponseMessageSize = value;
    }
  }

  public BaseDataVariableState<DateTime> ClientConnectionTime
  {
    get => this.m_clientConnectionTime;
    set
    {
      if (this.m_clientConnectionTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientConnectionTime = value;
    }
  }

  public BaseDataVariableState<DateTime> ClientLastContactTime
  {
    get => this.m_clientLastContactTime;
    set
    {
      if (this.m_clientLastContactTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientLastContactTime = value;
    }
  }

  public BaseDataVariableState<uint> CurrentSubscriptionsCount
  {
    get => this.m_currentSubscriptionsCount;
    set
    {
      if (this.m_currentSubscriptionsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentSubscriptionsCount = value;
    }
  }

  public BaseDataVariableState<uint> CurrentMonitoredItemsCount
  {
    get => this.m_currentMonitoredItemsCount;
    set
    {
      if (this.m_currentMonitoredItemsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentMonitoredItemsCount = value;
    }
  }

  public BaseDataVariableState<uint> CurrentPublishRequestsInQueue
  {
    get => this.m_currentPublishRequestsInQueue;
    set
    {
      if (this.m_currentPublishRequestsInQueue != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentPublishRequestsInQueue = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> TotalRequestCount
  {
    get => this.m_totalRequestCount;
    set
    {
      if (this.m_totalRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_totalRequestCount = value;
    }
  }

  public BaseDataVariableState<uint> UnauthorizedRequestCount
  {
    get => this.m_unauthorizedRequestCount;
    set
    {
      if (this.m_unauthorizedRequestCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_unauthorizedRequestCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> ReadCount
  {
    get => this.m_readCount;
    set
    {
      if (this.m_readCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_readCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> HistoryReadCount
  {
    get => this.m_historyReadCount;
    set
    {
      if (this.m_historyReadCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_historyReadCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> WriteCount
  {
    get => this.m_writeCount;
    set
    {
      if (this.m_writeCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_writeCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> HistoryUpdateCount
  {
    get => this.m_historyUpdateCount;
    set
    {
      if (this.m_historyUpdateCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_historyUpdateCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> CallCount
  {
    get => this.m_callCount;
    set
    {
      if (this.m_callCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_callCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> CreateMonitoredItemsCount
  {
    get => this.m_createMonitoredItemsCount;
    set
    {
      if (this.m_createMonitoredItemsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createMonitoredItemsCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> ModifyMonitoredItemsCount
  {
    get => this.m_modifyMonitoredItemsCount;
    set
    {
      if (this.m_modifyMonitoredItemsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_modifyMonitoredItemsCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> SetMonitoringModeCount
  {
    get => this.m_setMonitoringModeCount;
    set
    {
      if (this.m_setMonitoringModeCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_setMonitoringModeCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> SetTriggeringCount
  {
    get => this.m_setTriggeringCount;
    set
    {
      if (this.m_setTriggeringCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_setTriggeringCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> DeleteMonitoredItemsCount
  {
    get => this.m_deleteMonitoredItemsCount;
    set
    {
      if (this.m_deleteMonitoredItemsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteMonitoredItemsCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> CreateSubscriptionCount
  {
    get => this.m_createSubscriptionCount;
    set
    {
      if (this.m_createSubscriptionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createSubscriptionCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> ModifySubscriptionCount
  {
    get => this.m_modifySubscriptionCount;
    set
    {
      if (this.m_modifySubscriptionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_modifySubscriptionCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> SetPublishingModeCount
  {
    get => this.m_setPublishingModeCount;
    set
    {
      if (this.m_setPublishingModeCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_setPublishingModeCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> PublishCount
  {
    get => this.m_publishCount;
    set
    {
      if (this.m_publishCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> RepublishCount
  {
    get => this.m_republishCount;
    set
    {
      if (this.m_republishCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_republishCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> TransferSubscriptionsCount
  {
    get => this.m_transferSubscriptionsCount;
    set
    {
      if (this.m_transferSubscriptionsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transferSubscriptionsCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> DeleteSubscriptionsCount
  {
    get => this.m_deleteSubscriptionsCount;
    set
    {
      if (this.m_deleteSubscriptionsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteSubscriptionsCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> AddNodesCount
  {
    get => this.m_addNodesCount;
    set
    {
      if (this.m_addNodesCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addNodesCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> AddReferencesCount
  {
    get => this.m_addReferencesCount;
    set
    {
      if (this.m_addReferencesCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addReferencesCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> DeleteNodesCount
  {
    get => this.m_deleteNodesCount;
    set
    {
      if (this.m_deleteNodesCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteNodesCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> DeleteReferencesCount
  {
    get => this.m_deleteReferencesCount;
    set
    {
      if (this.m_deleteReferencesCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteReferencesCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> BrowseCount
  {
    get => this.m_browseCount;
    set
    {
      if (this.m_browseCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_browseCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> BrowseNextCount
  {
    get => this.m_browseNextCount;
    set
    {
      if (this.m_browseNextCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_browseNextCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> TranslateBrowsePathsToNodeIdsCount
  {
    get => this.m_translateBrowsePathsToNodeIdsCount;
    set
    {
      if (this.m_translateBrowsePathsToNodeIdsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_translateBrowsePathsToNodeIdsCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> QueryFirstCount
  {
    get => this.m_queryFirstCount;
    set
    {
      if (this.m_queryFirstCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_queryFirstCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> QueryNextCount
  {
    get => this.m_queryNextCount;
    set
    {
      if (this.m_queryNextCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_queryNextCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> RegisterNodesCount
  {
    get => this.m_registerNodesCount;
    set
    {
      if (this.m_registerNodesCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_registerNodesCount = value;
    }
  }

  public BaseDataVariableState<ServiceCounterDataType> UnregisterNodesCount
  {
    get => this.m_unregisterNodesCount;
    set
    {
      if (this.m_unregisterNodesCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_unregisterNodesCount = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sessionId != null)
      children.Add((BaseInstanceState) this.m_sessionId);
    if (this.m_sessionName != null)
      children.Add((BaseInstanceState) this.m_sessionName);
    if (this.m_clientDescription != null)
      children.Add((BaseInstanceState) this.m_clientDescription);
    if (this.m_serverUri != null)
      children.Add((BaseInstanceState) this.m_serverUri);
    if (this.m_endpointUrl != null)
      children.Add((BaseInstanceState) this.m_endpointUrl);
    if (this.m_localeIds != null)
      children.Add((BaseInstanceState) this.m_localeIds);
    if (this.m_actualSessionTimeout != null)
      children.Add((BaseInstanceState) this.m_actualSessionTimeout);
    if (this.m_maxResponseMessageSize != null)
      children.Add((BaseInstanceState) this.m_maxResponseMessageSize);
    if (this.m_clientConnectionTime != null)
      children.Add((BaseInstanceState) this.m_clientConnectionTime);
    if (this.m_clientLastContactTime != null)
      children.Add((BaseInstanceState) this.m_clientLastContactTime);
    if (this.m_currentSubscriptionsCount != null)
      children.Add((BaseInstanceState) this.m_currentSubscriptionsCount);
    if (this.m_currentMonitoredItemsCount != null)
      children.Add((BaseInstanceState) this.m_currentMonitoredItemsCount);
    if (this.m_currentPublishRequestsInQueue != null)
      children.Add((BaseInstanceState) this.m_currentPublishRequestsInQueue);
    if (this.m_totalRequestCount != null)
      children.Add((BaseInstanceState) this.m_totalRequestCount);
    if (this.m_unauthorizedRequestCount != null)
      children.Add((BaseInstanceState) this.m_unauthorizedRequestCount);
    if (this.m_readCount != null)
      children.Add((BaseInstanceState) this.m_readCount);
    if (this.m_historyReadCount != null)
      children.Add((BaseInstanceState) this.m_historyReadCount);
    if (this.m_writeCount != null)
      children.Add((BaseInstanceState) this.m_writeCount);
    if (this.m_historyUpdateCount != null)
      children.Add((BaseInstanceState) this.m_historyUpdateCount);
    if (this.m_callCount != null)
      children.Add((BaseInstanceState) this.m_callCount);
    if (this.m_createMonitoredItemsCount != null)
      children.Add((BaseInstanceState) this.m_createMonitoredItemsCount);
    if (this.m_modifyMonitoredItemsCount != null)
      children.Add((BaseInstanceState) this.m_modifyMonitoredItemsCount);
    if (this.m_setMonitoringModeCount != null)
      children.Add((BaseInstanceState) this.m_setMonitoringModeCount);
    if (this.m_setTriggeringCount != null)
      children.Add((BaseInstanceState) this.m_setTriggeringCount);
    if (this.m_deleteMonitoredItemsCount != null)
      children.Add((BaseInstanceState) this.m_deleteMonitoredItemsCount);
    if (this.m_createSubscriptionCount != null)
      children.Add((BaseInstanceState) this.m_createSubscriptionCount);
    if (this.m_modifySubscriptionCount != null)
      children.Add((BaseInstanceState) this.m_modifySubscriptionCount);
    if (this.m_setPublishingModeCount != null)
      children.Add((BaseInstanceState) this.m_setPublishingModeCount);
    if (this.m_publishCount != null)
      children.Add((BaseInstanceState) this.m_publishCount);
    if (this.m_republishCount != null)
      children.Add((BaseInstanceState) this.m_republishCount);
    if (this.m_transferSubscriptionsCount != null)
      children.Add((BaseInstanceState) this.m_transferSubscriptionsCount);
    if (this.m_deleteSubscriptionsCount != null)
      children.Add((BaseInstanceState) this.m_deleteSubscriptionsCount);
    if (this.m_addNodesCount != null)
      children.Add((BaseInstanceState) this.m_addNodesCount);
    if (this.m_addReferencesCount != null)
      children.Add((BaseInstanceState) this.m_addReferencesCount);
    if (this.m_deleteNodesCount != null)
      children.Add((BaseInstanceState) this.m_deleteNodesCount);
    if (this.m_deleteReferencesCount != null)
      children.Add((BaseInstanceState) this.m_deleteReferencesCount);
    if (this.m_browseCount != null)
      children.Add((BaseInstanceState) this.m_browseCount);
    if (this.m_browseNextCount != null)
      children.Add((BaseInstanceState) this.m_browseNextCount);
    if (this.m_translateBrowsePathsToNodeIdsCount != null)
      children.Add((BaseInstanceState) this.m_translateBrowsePathsToNodeIdsCount);
    if (this.m_queryFirstCount != null)
      children.Add((BaseInstanceState) this.m_queryFirstCount);
    if (this.m_queryNextCount != null)
      children.Add((BaseInstanceState) this.m_queryNextCount);
    if (this.m_registerNodesCount != null)
      children.Add((BaseInstanceState) this.m_registerNodesCount);
    if (this.m_unregisterNodesCount != null)
      children.Add((BaseInstanceState) this.m_unregisterNodesCount);
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
        case 9:
          switch (name[2])
          {
            case 'a':
              if (name == "ReadCount")
              {
                if (createOrReplace && this.ReadCount == null)
                  this.ReadCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ReadCount;
                break;
              }
              break;
            case 'c':
              if (name == "LocaleIds")
              {
                if (createOrReplace && this.LocaleIds == null)
                  this.LocaleIds = replacement != null ? (BaseDataVariableState<string[]>) replacement : new BaseDataVariableState<string[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LocaleIds;
                break;
              }
              break;
            case 'l':
              if (name == "CallCount")
              {
                if (createOrReplace && this.CallCount == null)
                  this.CallCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CallCount;
                break;
              }
              break;
            case 'r':
              if (name == "ServerUri")
              {
                if (createOrReplace && this.ServerUri == null)
                  this.ServerUri = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerUri;
                break;
              }
              break;
            case 's':
              if (name == "SessionId")
              {
                if (createOrReplace && this.SessionId == null)
                  this.SessionId = replacement != null ? (BaseDataVariableState<NodeId>) replacement : new BaseDataVariableState<NodeId>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SessionId;
                break;
              }
              break;
          }
          break;
        case 10:
          if (name == "WriteCount")
          {
            if (createOrReplace && this.WriteCount == null)
              this.WriteCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.WriteCount;
            break;
          }
          break;
        case 11:
          switch (name[0])
          {
            case 'B':
              if (name == "BrowseCount")
              {
                if (createOrReplace && this.BrowseCount == null)
                  this.BrowseCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.BrowseCount;
                break;
              }
              break;
            case 'E':
              if (name == "EndpointUrl")
              {
                if (createOrReplace && this.EndpointUrl == null)
                  this.EndpointUrl = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EndpointUrl;
                break;
              }
              break;
            case 'S':
              if (name == "SessionName")
              {
                if (createOrReplace && this.SessionName == null)
                  this.SessionName = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SessionName;
                break;
              }
              break;
          }
          break;
        case 12:
          if (name == "PublishCount")
          {
            if (createOrReplace && this.PublishCount == null)
              this.PublishCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.PublishCount;
            break;
          }
          break;
        case 13:
          if (name == "AddNodesCount")
          {
            if (createOrReplace && this.AddNodesCount == null)
              this.AddNodesCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddNodesCount;
            break;
          }
          break;
        case 14:
          switch (name[0])
          {
            case 'Q':
              if (name == "QueryNextCount")
              {
                if (createOrReplace && this.QueryNextCount == null)
                  this.QueryNextCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.QueryNextCount;
                break;
              }
              break;
            case 'R':
              if (name == "RepublishCount")
              {
                if (createOrReplace && this.RepublishCount == null)
                  this.RepublishCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RepublishCount;
                break;
              }
              break;
          }
          break;
        case 15:
          switch (name[0])
          {
            case 'B':
              if (name == "BrowseNextCount")
              {
                if (createOrReplace && this.BrowseNextCount == null)
                  this.BrowseNextCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.BrowseNextCount;
                break;
              }
              break;
            case 'Q':
              if (name == "QueryFirstCount")
              {
                if (createOrReplace && this.QueryFirstCount == null)
                  this.QueryFirstCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.QueryFirstCount;
                break;
              }
              break;
          }
          break;
        case 16 /*0x10*/:
          switch (name[0])
          {
            case 'D':
              if (name == "DeleteNodesCount")
              {
                if (createOrReplace && this.DeleteNodesCount == null)
                  this.DeleteNodesCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteNodesCount;
                break;
              }
              break;
            case 'H':
              if (name == "HistoryReadCount")
              {
                if (createOrReplace && this.HistoryReadCount == null)
                  this.HistoryReadCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.HistoryReadCount;
                break;
              }
              break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'C':
              if (name == "ClientDescription")
              {
                if (createOrReplace && this.ClientDescription == null)
                  this.ClientDescription = replacement != null ? (BaseDataVariableState<ApplicationDescription>) replacement : new BaseDataVariableState<ApplicationDescription>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ClientDescription;
                break;
              }
              break;
            case 'T':
              if (name == "TotalRequestCount")
              {
                if (createOrReplace && this.TotalRequestCount == null)
                  this.TotalRequestCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TotalRequestCount;
                break;
              }
              break;
          }
          break;
        case 18:
          switch (name[0])
          {
            case 'A':
              if (name == "AddReferencesCount")
              {
                if (createOrReplace && this.AddReferencesCount == null)
                  this.AddReferencesCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AddReferencesCount;
                break;
              }
              break;
            case 'H':
              if (name == "HistoryUpdateCount")
              {
                if (createOrReplace && this.HistoryUpdateCount == null)
                  this.HistoryUpdateCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.HistoryUpdateCount;
                break;
              }
              break;
            case 'R':
              if (name == "RegisterNodesCount")
              {
                if (createOrReplace && this.RegisterNodesCount == null)
                  this.RegisterNodesCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RegisterNodesCount;
                break;
              }
              break;
            case 'S':
              if (name == "SetTriggeringCount")
              {
                if (createOrReplace && this.SetTriggeringCount == null)
                  this.SetTriggeringCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SetTriggeringCount;
                break;
              }
              break;
          }
          break;
        case 20:
          switch (name[0])
          {
            case 'A':
              if (name == "ActualSessionTimeout")
              {
                if (createOrReplace && this.ActualSessionTimeout == null)
                  this.ActualSessionTimeout = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ActualSessionTimeout;
                break;
              }
              break;
            case 'C':
              if (name == "ClientConnectionTime")
              {
                if (createOrReplace && this.ClientConnectionTime == null)
                  this.ClientConnectionTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ClientConnectionTime;
                break;
              }
              break;
            case 'U':
              if (name == "UnregisterNodesCount")
              {
                if (createOrReplace && this.UnregisterNodesCount == null)
                  this.UnregisterNodesCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UnregisterNodesCount;
                break;
              }
              break;
          }
          break;
        case 21:
          switch (name[0])
          {
            case 'C':
              if (name == "ClientLastContactTime")
              {
                if (createOrReplace && this.ClientLastContactTime == null)
                  this.ClientLastContactTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ClientLastContactTime;
                break;
              }
              break;
            case 'D':
              if (name == "DeleteReferencesCount")
              {
                if (createOrReplace && this.DeleteReferencesCount == null)
                  this.DeleteReferencesCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteReferencesCount;
                break;
              }
              break;
          }
          break;
        case 22:
          switch (name[3])
          {
            case 'M':
              if (name == "SetMonitoringModeCount")
              {
                if (createOrReplace && this.SetMonitoringModeCount == null)
                  this.SetMonitoringModeCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SetMonitoringModeCount;
                break;
              }
              break;
            case 'P':
              if (name == "SetPublishingModeCount")
              {
                if (createOrReplace && this.SetPublishingModeCount == null)
                  this.SetPublishingModeCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SetPublishingModeCount;
                break;
              }
              break;
            case 'R':
              if (name == "MaxResponseMessageSize")
              {
                if (createOrReplace && this.MaxResponseMessageSize == null)
                  this.MaxResponseMessageSize = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxResponseMessageSize;
                break;
              }
              break;
          }
          break;
        case 23:
          switch (name[0])
          {
            case 'C':
              if (name == "CreateSubscriptionCount")
              {
                if (createOrReplace && this.CreateSubscriptionCount == null)
                  this.CreateSubscriptionCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CreateSubscriptionCount;
                break;
              }
              break;
            case 'M':
              if (name == "ModifySubscriptionCount")
              {
                if (createOrReplace && this.ModifySubscriptionCount == null)
                  this.ModifySubscriptionCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ModifySubscriptionCount;
                break;
              }
              break;
          }
          break;
        case 24:
          switch (name[0])
          {
            case 'D':
              if (name == "DeleteSubscriptionsCount")
              {
                if (createOrReplace && this.DeleteSubscriptionsCount == null)
                  this.DeleteSubscriptionsCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteSubscriptionsCount;
                break;
              }
              break;
            case 'U':
              if (name == "UnauthorizedRequestCount")
              {
                if (createOrReplace && this.UnauthorizedRequestCount == null)
                  this.UnauthorizedRequestCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UnauthorizedRequestCount;
                break;
              }
              break;
          }
          break;
        case 25:
          switch (name[1])
          {
            case 'e':
              if (name == "DeleteMonitoredItemsCount")
              {
                if (createOrReplace && this.DeleteMonitoredItemsCount == null)
                  this.DeleteMonitoredItemsCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteMonitoredItemsCount;
                break;
              }
              break;
            case 'o':
              if (name == "ModifyMonitoredItemsCount")
              {
                if (createOrReplace && this.ModifyMonitoredItemsCount == null)
                  this.ModifyMonitoredItemsCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ModifyMonitoredItemsCount;
                break;
              }
              break;
            case 'r':
              if (name == "CreateMonitoredItemsCount")
              {
                if (createOrReplace && this.CreateMonitoredItemsCount == null)
                  this.CreateMonitoredItemsCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CreateMonitoredItemsCount;
                break;
              }
              break;
            case 'u':
              if (name == "CurrentSubscriptionsCount")
              {
                if (createOrReplace && this.CurrentSubscriptionsCount == null)
                  this.CurrentSubscriptionsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CurrentSubscriptionsCount;
                break;
              }
              break;
          }
          break;
        case 26:
          switch (name[0])
          {
            case 'C':
              if (name == "CurrentMonitoredItemsCount")
              {
                if (createOrReplace && this.CurrentMonitoredItemsCount == null)
                  this.CurrentMonitoredItemsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CurrentMonitoredItemsCount;
                break;
              }
              break;
            case 'T':
              if (name == "TransferSubscriptionsCount")
              {
                if (createOrReplace && this.TransferSubscriptionsCount == null)
                  this.TransferSubscriptionsCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TransferSubscriptionsCount;
                break;
              }
              break;
          }
          break;
        case 29:
          if (name == "CurrentPublishRequestsInQueue")
          {
            if (createOrReplace && this.CurrentPublishRequestsInQueue == null)
              this.CurrentPublishRequestsInQueue = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CurrentPublishRequestsInQueue;
            break;
          }
          break;
        case 34:
          if (name == "TranslateBrowsePathsToNodeIdsCount")
          {
            if (createOrReplace && this.TranslateBrowsePathsToNodeIdsCount == null)
              this.TranslateBrowsePathsToNodeIdsCount = replacement != null ? (BaseDataVariableState<ServiceCounterDataType>) replacement : new BaseDataVariableState<ServiceCounterDataType>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.TranslateBrowsePathsToNodeIdsCount;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
