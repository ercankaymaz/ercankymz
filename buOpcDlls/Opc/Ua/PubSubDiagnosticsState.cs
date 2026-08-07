// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubDiagnosticsState
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
public class PubSubDiagnosticsState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDdTAEA3UzdTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAN5MAC8AP95MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAN9MAC8BAA1N30wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA4EwALgBE4EwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDhTAAuAEThTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDiTAAuAETiTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQDkTAAvAQANTeRMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAOVMAC4AROVMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA5kwALgBE5kwAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA50wALgBE50wAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOlMAC8BAOlM6UwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQDqTAAvAD/qTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAOtMAC8AOutMAAD/////BgAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEA7EwALwEADU3sTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtTAAuAETtTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5MAC4ARO5MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70wALgBE70wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAPFMAC8BAA1N8UwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA8kwALgBE8kwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDzTAAuAETzTAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAPRMAC4ARPRMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQD2TAAvAQANTfZMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAPdMAC4ARPdMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA+EwALgBE+EwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQD5TAAuAET5TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAPtMAC8BAA1N+0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA/EwALgBE/EwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQD9TAAuAET9TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAP5MAC4ARP5MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAAE0ALwEADU0ATQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQABTQAuAEQBTQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAAJNAC4ARAJNAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAA00ALgBEA00AAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAAVNAC8BAA1NBU0AAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEABk0ALgBEBk0AAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAHTQAuAEQHTQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAAhNAC4ARAhNAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEACk0ALwA6Ck0AAP////8AAAAA";
  private BaseDataVariableState<Opc.Ua.DiagnosticsLevel> m_diagnosticsLevel;
  private PubSubDiagnosticsCounterState m_totalInformation;
  private PubSubDiagnosticsCounterState m_totalError;
  private MethodState m_resetMethod;
  private BaseDataVariableState<bool> m_subError;
  private BaseObjectState m_counters;
  private BaseObjectState m_liveValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 19677U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YkRpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDdTAEA3UzdTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAN5MAC8AP95MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAN9MAC8BAA1N30wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA4EwALgBE4EwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDhTAAuAEThTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDiTAAuAETiTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQDkTAAvAQANTeRMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAOVMAC4AROVMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA5kwALgBE5kwAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA50wALgBE50wAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOlMAC8BAOlM6UwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQDqTAAvAD/qTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAOtMAC8AOutMAAD/////BgAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEA7EwALwEADU3sTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtTAAuAETtTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5MAC4ARO5MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70wALgBE70wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAPFMAC8BAA1N8UwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA8kwALgBE8kwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDzTAAuAETzTAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAPRMAC4ARPRMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQD2TAAvAQANTfZMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAPdMAC4ARPdMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEA+EwALgBE+EwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQD5TAAuAET5TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAPtMAC8BAA1N+0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA/EwALgBE/EwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQD9TAAuAET9TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAP5MAC4ARP5MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAAE0ALwEADU0ATQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQABTQAuAEQBTQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAAJNAC4ARAJNAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAA00ALgBEA00AAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAAVNAC8BAA1NBU0AAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEABk0ALgBEBk0AAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAHTQAuAEQHTQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAAhNAC4ARAhNAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEACk0ALwA6Ck0AAP////8AAAAA");
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

  public BaseDataVariableState<Opc.Ua.DiagnosticsLevel> DiagnosticsLevel
  {
    get => this.m_diagnosticsLevel;
    set
    {
      if (this.m_diagnosticsLevel != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_diagnosticsLevel = value;
    }
  }

  public PubSubDiagnosticsCounterState TotalInformation
  {
    get => this.m_totalInformation;
    set
    {
      if (this.m_totalInformation != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_totalInformation = value;
    }
  }

  public PubSubDiagnosticsCounterState TotalError
  {
    get => this.m_totalError;
    set
    {
      if (this.m_totalError != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_totalError = value;
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

  public BaseDataVariableState<bool> SubError
  {
    get => this.m_subError;
    set
    {
      if (this.m_subError != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_subError = value;
    }
  }

  public BaseObjectState Counters
  {
    get => this.m_counters;
    set
    {
      if (this.m_counters != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_counters = value;
    }
  }

  public BaseObjectState LiveValues
  {
    get => this.m_liveValues;
    set
    {
      if (this.m_liveValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_liveValues = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_diagnosticsLevel != null)
      children.Add((BaseInstanceState) this.m_diagnosticsLevel);
    if (this.m_totalInformation != null)
      children.Add((BaseInstanceState) this.m_totalInformation);
    if (this.m_totalError != null)
      children.Add((BaseInstanceState) this.m_totalError);
    if (this.m_resetMethod != null)
      children.Add((BaseInstanceState) this.m_resetMethod);
    if (this.m_subError != null)
      children.Add((BaseInstanceState) this.m_subError);
    if (this.m_counters != null)
      children.Add((BaseInstanceState) this.m_counters);
    if (this.m_liveValues != null)
      children.Add((BaseInstanceState) this.m_liveValues);
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
        case 8:
          switch (name[0])
          {
            case 'C':
              if (name == "Counters")
              {
                if (createOrReplace && this.Counters == null)
                  this.Counters = replacement != null ? (BaseObjectState) replacement : new BaseObjectState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Counters;
                break;
              }
              break;
            case 'S':
              if (name == "SubError")
              {
                if (createOrReplace && this.SubError == null)
                  this.SubError = replacement != null ? (BaseDataVariableState<bool>) replacement : new BaseDataVariableState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SubError;
                break;
              }
              break;
          }
          break;
        case 10:
          switch (name[0])
          {
            case 'L':
              if (name == "LiveValues")
              {
                if (createOrReplace && this.LiveValues == null)
                  this.LiveValues = replacement != null ? (BaseObjectState) replacement : new BaseObjectState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LiveValues;
                break;
              }
              break;
            case 'T':
              if (name == "TotalError")
              {
                if (createOrReplace && this.TotalError == null)
                  this.TotalError = replacement != null ? (PubSubDiagnosticsCounterState) replacement : new PubSubDiagnosticsCounterState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TotalError;
                break;
              }
              break;
          }
          break;
        case 16 /*0x10*/:
          switch (name[0])
          {
            case 'D':
              if (name == "DiagnosticsLevel")
              {
                if (createOrReplace && this.DiagnosticsLevel == null)
                  this.DiagnosticsLevel = replacement != null ? (BaseDataVariableState<Opc.Ua.DiagnosticsLevel>) replacement : new BaseDataVariableState<Opc.Ua.DiagnosticsLevel>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DiagnosticsLevel;
                break;
              }
              break;
            case 'T':
              if (name == "TotalInformation")
              {
                if (createOrReplace && this.TotalInformation == null)
                  this.TotalInformation = replacement != null ? (PubSubDiagnosticsCounterState) replacement : new PubSubDiagnosticsCounterState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TotalInformation;
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
