// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramDiagnostic2State
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
public class ProgramDiagnostic2State(NodeState parent) : 
  BaseDataVariableState<ProgramDiagnostic2DataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHgAAAFByb2dyYW1EaWFnbm9zdGljMlR5cGVJbnN0YW5jZQEAFzwBABc8FzwAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAYPAAvAD8YPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAGTwALwA/GTwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBABo8AC8APxo8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAGzwALgBEGzwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBABw8AC8APxw8AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAdPAAvAD8dPAAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAePAAvAD8ePAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAB88AC8APx88AAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQAgPAAvAD8gPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQAhPAAvAD8hPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBACI8AC8APyI8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBACM8AC8APyM8AAAAE/////8BAf////8AAAAA";
  private BaseDataVariableState<NodeId> m_createSessionId;
  private BaseDataVariableState<string> m_createClientName;
  private BaseDataVariableState<DateTime> m_invocationCreationTime;
  private PropertyState<DateTime> m_lastTransitionTime;
  private BaseDataVariableState<string> m_lastMethodCall;
  private BaseDataVariableState<NodeId> m_lastMethodSessionId;
  private BaseDataVariableState<Argument[]> m_lastMethodInputArguments;
  private BaseDataVariableState<Argument[]> m_lastMethodOutputArguments;
  private BaseDataVariableState<object[]> m_lastMethodInputValues;
  private BaseDataVariableState<object[]> m_lastMethodOutputValues;
  private BaseDataVariableState<DateTime> m_lastMethodCallTime;
  private BaseDataVariableState<StatusCode> m_lastMethodReturnStatus;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15383U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24033U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHgAAAFByb2dyYW1EaWFnbm9zdGljMlR5cGVJbnN0YW5jZQEAFzwBABc8FzwAAAEA4V3/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAQ3JlYXRlU2Vzc2lvbklkAQAYPAAvAD8YPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ3JlYXRlQ2xpZW50TmFtZQEAGTwALwA/GTwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAEludm9jYXRpb25DcmVhdGlvblRpbWUBABo8AC8APxo8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAExhc3RUcmFuc2l0aW9uVGltZQEAGzwALgBEGzwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdE1ldGhvZENhbGwBABw8AC8APxw8AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABMYXN0TWV0aG9kU2Vzc2lvbklkAQAdPAAvAD8dPAAAABH/////AQH/////AAAAABdgiQoCAAAAAAAYAAAATGFzdE1ldGhvZElucHV0QXJndW1lbnRzAQAePAAvAD8ePAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGQAAAExhc3RNZXRob2RPdXRwdXRBcmd1bWVudHMBAB88AC8APx88AAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAVAAAATGFzdE1ldGhvZElucHV0VmFsdWVzAQAgPAAvAD8gPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABYAAABMYXN0TWV0aG9kT3V0cHV0VmFsdWVzAQAhPAAvAD8hPAAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABIAAABMYXN0TWV0aG9kQ2FsbFRpbWUBACI8AC8APyI8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAExhc3RNZXRob2RSZXR1cm5TdGF0dXMBACM8AC8APyM8AAAAE/////8BAf////8AAAAA");
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

  public BaseDataVariableState<NodeId> CreateSessionId
  {
    get => this.m_createSessionId;
    set
    {
      if (this.m_createSessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createSessionId = value;
    }
  }

  public BaseDataVariableState<string> CreateClientName
  {
    get => this.m_createClientName;
    set
    {
      if (this.m_createClientName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createClientName = value;
    }
  }

  public BaseDataVariableState<DateTime> InvocationCreationTime
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

  public BaseDataVariableState<string> LastMethodCall
  {
    get => this.m_lastMethodCall;
    set
    {
      if (this.m_lastMethodCall != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodCall = value;
    }
  }

  public BaseDataVariableState<NodeId> LastMethodSessionId
  {
    get => this.m_lastMethodSessionId;
    set
    {
      if (this.m_lastMethodSessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodSessionId = value;
    }
  }

  public BaseDataVariableState<Argument[]> LastMethodInputArguments
  {
    get => this.m_lastMethodInputArguments;
    set
    {
      if (this.m_lastMethodInputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodInputArguments = value;
    }
  }

  public BaseDataVariableState<Argument[]> LastMethodOutputArguments
  {
    get => this.m_lastMethodOutputArguments;
    set
    {
      if (this.m_lastMethodOutputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodOutputArguments = value;
    }
  }

  public BaseDataVariableState<object[]> LastMethodInputValues
  {
    get => this.m_lastMethodInputValues;
    set
    {
      if (this.m_lastMethodInputValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodInputValues = value;
    }
  }

  public BaseDataVariableState<object[]> LastMethodOutputValues
  {
    get => this.m_lastMethodOutputValues;
    set
    {
      if (this.m_lastMethodOutputValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodOutputValues = value;
    }
  }

  public BaseDataVariableState<DateTime> LastMethodCallTime
  {
    get => this.m_lastMethodCallTime;
    set
    {
      if (this.m_lastMethodCallTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastMethodCallTime = value;
    }
  }

  public BaseDataVariableState<StatusCode> LastMethodReturnStatus
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
    if (this.m_lastMethodInputValues != null)
      children.Add((BaseInstanceState) this.m_lastMethodInputValues);
    if (this.m_lastMethodOutputValues != null)
      children.Add((BaseInstanceState) this.m_lastMethodOutputValues);
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
              this.LastMethodCall = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodCall;
            break;
          }
          break;
        case 15:
          if (name == "CreateSessionId")
          {
            if (createOrReplace && this.CreateSessionId == null)
              this.CreateSessionId = replacement != null ? (BaseDataVariableState<NodeId>) replacement : new BaseDataVariableState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CreateSessionId;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "CreateClientName")
          {
            if (createOrReplace && this.CreateClientName == null)
              this.CreateClientName = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
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
                  this.LastMethodCallTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
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
              this.LastMethodSessionId = replacement != null ? (BaseDataVariableState<NodeId>) replacement : new BaseDataVariableState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodSessionId;
            break;
          }
          break;
        case 21:
          if (name == "LastMethodInputValues")
          {
            if (createOrReplace && this.LastMethodInputValues == null)
              this.LastMethodInputValues = replacement != null ? (BaseDataVariableState<object[]>) replacement : new BaseDataVariableState<object[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodInputValues;
            break;
          }
          break;
        case 22:
          switch (name[10])
          {
            case 'C':
              if (name == "InvocationCreationTime")
              {
                if (createOrReplace && this.InvocationCreationTime == null)
                  this.InvocationCreationTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.InvocationCreationTime;
                break;
              }
              break;
            case 'O':
              if (name == "LastMethodOutputValues")
              {
                if (createOrReplace && this.LastMethodOutputValues == null)
                  this.LastMethodOutputValues = replacement != null ? (BaseDataVariableState<object[]>) replacement : new BaseDataVariableState<object[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LastMethodOutputValues;
                break;
              }
              break;
            case 'R':
              if (name == "LastMethodReturnStatus")
              {
                if (createOrReplace && this.LastMethodReturnStatus == null)
                  this.LastMethodReturnStatus = replacement != null ? (BaseDataVariableState<StatusCode>) replacement : new BaseDataVariableState<StatusCode>((NodeState) this);
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
              this.LastMethodInputArguments = replacement != null ? (BaseDataVariableState<Argument[]>) replacement : new BaseDataVariableState<Argument[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodInputArguments;
            break;
          }
          break;
        case 25:
          if (name == "LastMethodOutputArguments")
          {
            if (createOrReplace && this.LastMethodOutputArguments == null)
              this.LastMethodOutputArguments = replacement != null ? (BaseDataVariableState<Argument[]>) replacement : new BaseDataVariableState<Argument[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LastMethodOutputArguments;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
