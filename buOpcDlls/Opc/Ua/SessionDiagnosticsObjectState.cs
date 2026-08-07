// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionDiagnosticsObjectState
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
public class SessionDiagnosticsObjectState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAFNlc3Npb25EaWFnbm9zdGljc09iamVjdFR5cGVJbnN0YW5jZQEA7QcBAO0H7QcAAP////8DAAAAFWCJCgIAAAAAABIAAABTZXNzaW9uRGlhZ25vc3RpY3MBAO4HAC8BAJUI7gcAAAEAYQP/////AQH/////KwAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQA7DAAvAD87DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAU2Vzc2lvbk5hbWUBADwMAC8APzwMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABEAAABDbGllbnREZXNjcmlwdGlvbgEAPQwALwA/PQwAAAEANAH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2VydmVyVXJpAQA+DAAvAD8+DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAARW5kcG9pbnRVcmwBAD8MAC8APz8MAAAADP////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABMb2NhbGVJZHMBAEAMAC8AP0AMAAABACcBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAUAAAAQWN0dWFsU2Vzc2lvblRpbWVvdXQBAEEMAC8AP0EMAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAE1heFJlc3BvbnNlTWVzc2FnZVNpemUBAEIMAC8AP0IMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABDbGllbnRDb25uZWN0aW9uVGltZQEAQwwALwA/QwwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAQ2xpZW50TGFzdENvbnRhY3RUaW1lAQBEDAAvAD9EDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABDdXJyZW50U3Vic2NyaXB0aW9uc0NvdW50AQBFDAAvAD9FDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VycmVudE1vbml0b3JlZEl0ZW1zQ291bnQBAEYMAC8AP0YMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABDdXJyZW50UHVibGlzaFJlcXVlc3RzSW5RdWV1ZQEARwwALwA/RwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFRvdGFsUmVxdWVzdENvdW50AQDCIgAvAD/CIgAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABVbmF1dGhvcml6ZWRSZXF1ZXN0Q291bnQBAHMuAC8AP3MuAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABSZWFkQ291bnQBAE8MAC8AP08MAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEhpc3RvcnlSZWFkQ291bnQBAFAMAC8AP1AMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFdyaXRlQ291bnQBAFEMAC8AP1EMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAEhpc3RvcnlVcGRhdGVDb3VudAEAUgwALwA/UgwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAQ2FsbENvdW50AQBTDAAvAD9TDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABkAAABDcmVhdGVNb25pdG9yZWRJdGVtc0NvdW50AQBUDAAvAD9UDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABkAAABNb2RpZnlNb25pdG9yZWRJdGVtc0NvdW50AQBVDAAvAD9VDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABYAAABTZXRNb25pdG9yaW5nTW9kZUNvdW50AQBWDAAvAD9WDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABIAAABTZXRUcmlnZ2VyaW5nQ291bnQBAFcMAC8AP1cMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAERlbGV0ZU1vbml0b3JlZEl0ZW1zQ291bnQBAFgMAC8AP1gMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAENyZWF0ZVN1YnNjcmlwdGlvbkNvdW50AQBZDAAvAD9ZDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABcAAABNb2RpZnlTdWJzY3JpcHRpb25Db3VudAEAWgwALwA/WgwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAU2V0UHVibGlzaGluZ01vZGVDb3VudAEAWwwALwA/WwwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUHVibGlzaENvdW50AQBcDAAvAD9cDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABSZXB1Ymxpc2hDb3VudAEAXQwALwA/XQwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAVHJhbnNmZXJTdWJzY3JpcHRpb25zQ291bnQBAF4MAC8AP14MAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAERlbGV0ZVN1YnNjcmlwdGlvbnNDb3VudAEAXwwALwA/XwwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQWRkTm9kZXNDb3VudAEAYAwALwA/YAwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQWRkUmVmZXJlbmNlc0NvdW50AQBhDAAvAD9hDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEZWxldGVOb2Rlc0NvdW50AQBiDAAvAD9iDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABEZWxldGVSZWZlcmVuY2VzQ291bnQBAGMMAC8AP2MMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEJyb3dzZUNvdW50AQBkDAAvAD9kDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABCcm93c2VOZXh0Q291bnQBAGUMAC8AP2UMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAIgAAAFRyYW5zbGF0ZUJyb3dzZVBhdGhzVG9Ob2RlSWRzQ291bnQBAGYMAC8AP2YMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFF1ZXJ5Rmlyc3RDb3VudAEAZwwALwA/ZwwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAUXVlcnlOZXh0Q291bnQBAGgMAC8AP2gMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFJlZ2lzdGVyTm9kZXNDb3VudAEAaQwALwA/aQwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAUAAAAVW5yZWdpc3Rlck5vZGVzQ291bnQBAGoMAC8AP2oMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzAQDvBwAvAQDECO8HAAABAGQD/////wEB/////wkAAAAVYIkKAgAAAAAACQAAAFNlc3Npb25JZAEAawwALwA/awwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAENsaWVudFVzZXJJZE9mU2Vzc2lvbgEAbAwALwA/bAwAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAAEwAAAENsaWVudFVzZXJJZEhpc3RvcnkBAG0MAC8AP20MAAAADAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAFwAAAEF1dGhlbnRpY2F0aW9uTWVjaGFuaXNtAQBuDAAvAD9uDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAARW5jb2RpbmcBAG8MAC8AP28MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABEAAABUcmFuc3BvcnRQcm90b2NvbAEAcAwALwA/cAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAcQwALwA/cQwAAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkBAHIMAC8AP3IMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABEAAABDbGllbnRDZXJ0aWZpY2F0ZQEAcwwALwA/cwwAAAAP/////wEB/////wAAAAAXYIkKAgAAAAAAHAAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzQXJyYXkBAPAHAC8BAHsI8AcAAAEAagMBAAAAAQAAAAAAAAABAf////8AAAAA";
  private SessionDiagnosticsVariableState m_sessionDiagnostics;
  private SessionSecurityDiagnosticsState m_sessionSecurityDiagnostics;
  private SubscriptionDiagnosticsArrayState m_subscriptionDiagnosticsArray;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2029U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAFNlc3Npb25EaWFnbm9zdGljc09iamVjdFR5cGVJbnN0YW5jZQEA7QcBAO0H7QcAAP////8DAAAAFWCJCgIAAAAAABIAAABTZXNzaW9uRGlhZ25vc3RpY3MBAO4HAC8BAJUI7gcAAAEAYQP/////AQH/////KwAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQA7DAAvAD87DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAU2Vzc2lvbk5hbWUBADwMAC8APzwMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABEAAABDbGllbnREZXNjcmlwdGlvbgEAPQwALwA/PQwAAAEANAH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2VydmVyVXJpAQA+DAAvAD8+DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAARW5kcG9pbnRVcmwBAD8MAC8APz8MAAAADP////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABMb2NhbGVJZHMBAEAMAC8AP0AMAAABACcBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAUAAAAQWN0dWFsU2Vzc2lvblRpbWVvdXQBAEEMAC8AP0EMAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAE1heFJlc3BvbnNlTWVzc2FnZVNpemUBAEIMAC8AP0IMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABDbGllbnRDb25uZWN0aW9uVGltZQEAQwwALwA/QwwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAQ2xpZW50TGFzdENvbnRhY3RUaW1lAQBEDAAvAD9EDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABDdXJyZW50U3Vic2NyaXB0aW9uc0NvdW50AQBFDAAvAD9FDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VycmVudE1vbml0b3JlZEl0ZW1zQ291bnQBAEYMAC8AP0YMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABDdXJyZW50UHVibGlzaFJlcXVlc3RzSW5RdWV1ZQEARwwALwA/RwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFRvdGFsUmVxdWVzdENvdW50AQDCIgAvAD/CIgAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABVbmF1dGhvcml6ZWRSZXF1ZXN0Q291bnQBAHMuAC8AP3MuAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABSZWFkQ291bnQBAE8MAC8AP08MAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEhpc3RvcnlSZWFkQ291bnQBAFAMAC8AP1AMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFdyaXRlQ291bnQBAFEMAC8AP1EMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAEhpc3RvcnlVcGRhdGVDb3VudAEAUgwALwA/UgwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAQ2FsbENvdW50AQBTDAAvAD9TDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABkAAABDcmVhdGVNb25pdG9yZWRJdGVtc0NvdW50AQBUDAAvAD9UDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABkAAABNb2RpZnlNb25pdG9yZWRJdGVtc0NvdW50AQBVDAAvAD9VDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABYAAABTZXRNb25pdG9yaW5nTW9kZUNvdW50AQBWDAAvAD9WDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABIAAABTZXRUcmlnZ2VyaW5nQ291bnQBAFcMAC8AP1cMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAERlbGV0ZU1vbml0b3JlZEl0ZW1zQ291bnQBAFgMAC8AP1gMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAENyZWF0ZVN1YnNjcmlwdGlvbkNvdW50AQBZDAAvAD9ZDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABcAAABNb2RpZnlTdWJzY3JpcHRpb25Db3VudAEAWgwALwA/WgwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAWAAAAU2V0UHVibGlzaGluZ01vZGVDb3VudAEAWwwALwA/WwwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUHVibGlzaENvdW50AQBcDAAvAD9cDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABSZXB1Ymxpc2hDb3VudAEAXQwALwA/XQwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAVHJhbnNmZXJTdWJzY3JpcHRpb25zQ291bnQBAF4MAC8AP14MAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAERlbGV0ZVN1YnNjcmlwdGlvbnNDb3VudAEAXwwALwA/XwwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQWRkTm9kZXNDb3VudAEAYAwALwA/YAwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQWRkUmVmZXJlbmNlc0NvdW50AQBhDAAvAD9hDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEZWxldGVOb2Rlc0NvdW50AQBiDAAvAD9iDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAABUAAABEZWxldGVSZWZlcmVuY2VzQ291bnQBAGMMAC8AP2MMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEJyb3dzZUNvdW50AQBkDAAvAD9kDAAAAQBnA/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABCcm93c2VOZXh0Q291bnQBAGUMAC8AP2UMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAIgAAAFRyYW5zbGF0ZUJyb3dzZVBhdGhzVG9Ob2RlSWRzQ291bnQBAGYMAC8AP2YMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFF1ZXJ5Rmlyc3RDb3VudAEAZwwALwA/ZwwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAUXVlcnlOZXh0Q291bnQBAGgMAC8AP2gMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAFJlZ2lzdGVyTm9kZXNDb3VudAEAaQwALwA/aQwAAAEAZwP/////AQH/////AAAAABVgiQoCAAAAAAAUAAAAVW5yZWdpc3Rlck5vZGVzQ291bnQBAGoMAC8AP2oMAAABAGcD/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzAQDvBwAvAQDECO8HAAABAGQD/////wEB/////wkAAAAVYIkKAgAAAAAACQAAAFNlc3Npb25JZAEAawwALwA/awwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAENsaWVudFVzZXJJZE9mU2Vzc2lvbgEAbAwALwA/bAwAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAAEwAAAENsaWVudFVzZXJJZEhpc3RvcnkBAG0MAC8AP20MAAAADAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAFwAAAEF1dGhlbnRpY2F0aW9uTWVjaGFuaXNtAQBuDAAvAD9uDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAARW5jb2RpbmcBAG8MAC8AP28MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABEAAABUcmFuc3BvcnRQcm90b2NvbAEAcAwALwA/cAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAcQwALwA/cQwAAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkBAHIMAC8AP3IMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABEAAABDbGllbnRDZXJ0aWZpY2F0ZQEAcwwALwA/cwwAAAAP/////wEB/////wAAAAAXYIkKAgAAAAAAHAAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzQXJyYXkBAPAHAC8BAHsI8AcAAAEAagMBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public SessionDiagnosticsVariableState SessionDiagnostics
  {
    get => this.m_sessionDiagnostics;
    set
    {
      if (this.m_sessionDiagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionDiagnostics = value;
    }
  }

  public SessionSecurityDiagnosticsState SessionSecurityDiagnostics
  {
    get => this.m_sessionSecurityDiagnostics;
    set
    {
      if (this.m_sessionSecurityDiagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionSecurityDiagnostics = value;
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

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sessionDiagnostics != null)
      children.Add((BaseInstanceState) this.m_sessionDiagnostics);
    if (this.m_sessionSecurityDiagnostics != null)
      children.Add((BaseInstanceState) this.m_sessionSecurityDiagnostics);
    if (this.m_subscriptionDiagnosticsArray != null)
      children.Add((BaseInstanceState) this.m_subscriptionDiagnosticsArray);
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
      case "SessionDiagnostics":
        if (createOrReplace && this.SessionDiagnostics == null)
          this.SessionDiagnostics = replacement != null ? (SessionDiagnosticsVariableState) replacement : new SessionDiagnosticsVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SessionDiagnostics;
        break;
      case "SessionSecurityDiagnostics":
        if (createOrReplace && this.SessionSecurityDiagnostics == null)
          this.SessionSecurityDiagnostics = replacement != null ? (SessionSecurityDiagnosticsState) replacement : new SessionSecurityDiagnosticsState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SessionSecurityDiagnostics;
        break;
      case "SubscriptionDiagnosticsArray":
        if (createOrReplace && this.SubscriptionDiagnosticsArray == null)
          this.SubscriptionDiagnosticsArray = replacement != null ? (SubscriptionDiagnosticsArrayState) replacement : new SubscriptionDiagnosticsArrayState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SubscriptionDiagnosticsArray;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
