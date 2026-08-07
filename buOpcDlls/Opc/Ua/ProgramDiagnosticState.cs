// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramDiagnosticState
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
public class ProgramDiagnosticState(NodeState parent) : 
  BaseDataVariableState<ProgramDiagnosticDataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHQAAAFByb2dyYW1EaWFnbm9zdGljVHlwZUluc3RhbmNlAQBMCQEATAlMCQAAAQB+A/////8BAf////8KAAAAFWCJCgIAAAAAAA8AAABDcmVhdGVTZXNzaW9uSWQBAE0JAC4ARE0JAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDcmVhdGVDbGllbnROYW1lAQBOCQAuAEROCQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAWAAAASW52b2NhdGlvbkNyZWF0aW9uVGltZQEATwkALgBETwkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdFRyYW5zaXRpb25UaW1lAQBQCQAuAERQCQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0TWV0aG9kQ2FsbAEAUQkALgBEUQkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAExhc3RNZXRob2RTZXNzaW9uSWQBAFIJAC4ARFIJAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABgAAABMYXN0TWV0aG9kSW5wdXRBcmd1bWVudHMBAFMJAC4ARFMJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAFQJAC4ARFQJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RNZXRob2RDYWxsVGltZQEAVQkALgBEVQkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATGFzdE1ldGhvZFJldHVyblN0YXR1cwEAVgkALgBEVgkAAAEAKwH/////AQH/////AAAAAA==";
  private PropertyState<NodeId> m_createSessionId;
  private PropertyState<string> m_createClientName;
  private PropertyState<DateTime> m_invocationCreationTime;
  private PropertyState<DateTime> m_lastTransitionTime;
  private PropertyState<string> m_lastMethodCall;
  private PropertyState<NodeId> m_lastMethodSessionId;
  private PropertyState<object[]> m_lastMethodInputArguments;
  private PropertyState<object[]> m_lastMethodOutputArguments;
  private PropertyState<DateTime> m_lastMethodCallTime;
  private PropertyState<StatusResult> m_lastMethodReturnStatus;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2380U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 894U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHQAAAFByb2dyYW1EaWFnbm9zdGljVHlwZUluc3RhbmNlAQBMCQEATAlMCQAAAQB+A/////8BAf////8KAAAAFWCJCgIAAAAAAA8AAABDcmVhdGVTZXNzaW9uSWQBAE0JAC4ARE0JAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDcmVhdGVDbGllbnROYW1lAQBOCQAuAEROCQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAWAAAASW52b2NhdGlvbkNyZWF0aW9uVGltZQEATwkALgBETwkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAASAAAATGFzdFRyYW5zaXRpb25UaW1lAQBQCQAuAERQCQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0TWV0aG9kQ2FsbAEAUQkALgBEUQkAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAExhc3RNZXRob2RTZXNzaW9uSWQBAFIJAC4ARFIJAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABgAAABMYXN0TWV0aG9kSW5wdXRBcmd1bWVudHMBAFMJAC4ARFMJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAFQJAC4ARFQJAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RNZXRob2RDYWxsVGltZQEAVQkALgBEVQkAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAWAAAATGFzdE1ldGhvZFJldHVyblN0YXR1cwEAVgkALgBEVgkAAAEAKwH/////AQH/////AAAAAA==");
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

  public PropertyState<NodeId> CreateSessionId
  {
    get => this.m_createSessionId;
    set
    {
      if (this.m_createSessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createSessionId = value;
    }
  }

  public PropertyState<string> CreateClientName
  {
    get => this.m_createClientName;
    set
    {
      if (this.m_createClientName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createClientName = value;
    }
  }

  public PropertyState<DateTime> InvocationCreationTime
  {
    get => this.m_invocationCreationTime;
    set
    {
      if (this.m_invocationCreationTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_invocationCreationTime = value;
    }
  }

  public PropertyState<DateTime> LastTransitionTime
  {
    get => this.m_lastTransitionTime;
    set
    {
      if (this.m_lastTransitionTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastTransitionTime = value;
    }
  }

  public PropertyState<string> LastMethodCall
  {
    get => this.m_lastMethodCall;
    set
    {
      if (this.m_lastMethodCall != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodCall = value;
    }
  }

  public PropertyState<NodeId> LastMethodSessionId
  {
    get => this.m_lastMethodSessionId;
    set
    {
      if (this.m_lastMethodSessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodSessionId = value;
    }
  }

  public PropertyState<object[]> LastMethodInputArguments
  {
    get => this.m_lastMethodInputArguments;
    set
    {
      if (this.m_lastMethodInputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodInputArguments = value;
    }
  }

  public PropertyState<object[]> LastMethodOutputArguments
  {
    get => this.m_lastMethodOutputArguments;
    set
    {
      if (this.m_lastMethodOutputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodOutputArguments = value;
    }
  }

  public PropertyState<DateTime> LastMethodCallTime
  {
    get => this.m_lastMethodCallTime;
    set
    {
      if (this.m_lastMethodCallTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodCallTime = value;
    }
  }

  public PropertyState<StatusResult> LastMethodReturnStatus
  {
    get => this.m_lastMethodReturnStatus;
    set
    {
      if (this.m_lastMethodReturnStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodReturnStatus = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_createSessionId != null)
      children.Add((BaseInstanceState) this.m_createSessionId);
    if (this.m_createClientName != null)
      children.Add((BaseInstanceState) this.m_createClientName);
    if (this.m_invocationCreationTime != null)
      children.Add((BaseInstanceState) this.m_invocationCreationTime);
    if (this.m_lastTransitionTime != null)
      children.Add((BaseInstanceState) this.m_lastTransitionTime);
    if (this.m_lastMethodCall != null)
      children.Add((BaseInstanceState) this.m_lastMethodCall);
    if (this.m_lastMethodSessionId != null)
      children.Add((BaseInstanceState) this.m_lastMethodSessionId);
    if (this.m_lastMethodInputArguments != null)
      children.Add((BaseInstanceState) this.m_lastMethodInputArguments);
    if (this.m_lastMethodOutputArguments != null)
      children.Add((BaseInstanceState) this.m_lastMethodOutputArguments);
    if (this.m_lastMethodCallTime != null)
      children.Add((BaseInstanceState) this.m_lastMethodCallTime);
    if (this.m_lastMethodReturnStatus != null)
      children.Add((BaseInstanceState) this.m_lastMethodReturnStatus);
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
        case 14:
          if (name == "LastMethodCall")
          {
            if (createOrReplace && this.LastMethodCall == null)
              this.LastMethodCall = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodCall;
            break;
          }
          break;
        case 15:
          if (name == "CreateSessionId")
          {
            if (createOrReplace && this.CreateSessionId == null)
              this.CreateSessionId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CreateSessionId;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "CreateClientName")
          {
            if (createOrReplace && this.CreateClientName == null)
              this.CreateClientName = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CreateClientName;
            break;
          }
          break;
        case 18:
          switch (name[4])
          {
            case 'M':
              if (name == "LastMethodCallTime")
              {
                if (createOrReplace && this.LastMethodCallTime == null)
                  this.LastMethodCallTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LastMethodCallTime;
                break;
              }
              break;
            case 'T':
              if (name == "LastTransitionTime")
              {
                if (createOrReplace && this.LastTransitionTime == null)
                  this.LastTransitionTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LastTransitionTime;
                break;
              }
              break;
          }
          break;
        case 19:
          if (name == "LastMethodSessionId")
          {
            if (createOrReplace && this.LastMethodSessionId == null)
              this.LastMethodSessionId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodSessionId;
            break;
          }
          break;
        case 22:
          switch (name[0])
          {
            case 'I':
              if (name == "InvocationCreationTime")
              {
                if (createOrReplace && this.InvocationCreationTime == null)
                  this.InvocationCreationTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.InvocationCreationTime;
                break;
              }
              break;
            case 'L':
              if (name == "LastMethodReturnStatus")
              {
                if (createOrReplace && this.LastMethodReturnStatus == null)
                  this.LastMethodReturnStatus = replacement != null ? (PropertyState<StatusResult>) replacement : new PropertyState<StatusResult>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LastMethodReturnStatus;
                break;
              }
              break;
          }
          break;
        case 24:
          if (name == "LastMethodInputArguments")
          {
            if (createOrReplace && this.LastMethodInputArguments == null)
              this.LastMethodInputArguments = replacement != null ? (PropertyState<object[]>) replacement : new PropertyState<object[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodInputArguments;
            break;
          }
          break;
        case 25:
          if (name == "LastMethodOutputArguments")
          {
            if (createOrReplace && this.LastMethodOutputArguments == null)
              this.LastMethodOutputArguments = replacement != null ? (PropertyState<object[]>) replacement : new PropertyState<object[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodOutputArguments;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
