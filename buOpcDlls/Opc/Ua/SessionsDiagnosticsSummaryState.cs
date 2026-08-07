// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionsDiagnosticsSummaryState
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
public class SessionsDiagnosticsSummaryState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAFNlc3Npb25zRGlhZ25vc3RpY3NTdW1tYXJ5VHlwZUluc3RhbmNlAQDqBwEA6gfqBwAA/////wIAAAAXYIkKAgAAAAAAFwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5AQDrBwAvAQCUCOsHAAABAGEDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAfAAAAU2Vzc2lvblNlY3VyaXR5RGlhZ25vc3RpY3NBcnJheQEA7AcALwEAwwjsBwAAAQBkAwEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private SessionDiagnosticsArrayState m_sessionDiagnosticsArray;
  private SessionSecurityDiagnosticsArrayState m_sessionSecurityDiagnosticsArray;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2026U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAFNlc3Npb25zRGlhZ25vc3RpY3NTdW1tYXJ5VHlwZUluc3RhbmNlAQDqBwEA6gfqBwAA/////wIAAAAXYIkKAgAAAAAAFwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5AQDrBwAvAQCUCOsHAAABAGEDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAfAAAAU2Vzc2lvblNlY3VyaXR5RGlhZ25vc3RpY3NBcnJheQEA7AcALwEAwwjsBwAAAQBkAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public SessionDiagnosticsArrayState SessionDiagnosticsArray
  {
    get => this.m_sessionDiagnosticsArray;
    set
    {
      if (this.m_sessionDiagnosticsArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionDiagnosticsArray = value;
    }
  }

  public SessionSecurityDiagnosticsArrayState SessionSecurityDiagnosticsArray
  {
    get => this.m_sessionSecurityDiagnosticsArray;
    set
    {
      if (this.m_sessionSecurityDiagnosticsArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionSecurityDiagnosticsArray = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sessionDiagnosticsArray != null)
      children.Add((BaseInstanceState) this.m_sessionDiagnosticsArray);
    if (this.m_sessionSecurityDiagnosticsArray != null)
      children.Add((BaseInstanceState) this.m_sessionSecurityDiagnosticsArray);
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
      case "SessionDiagnosticsArray":
        if (createOrReplace && this.SessionDiagnosticsArray == null)
          this.SessionDiagnosticsArray = replacement != null ? (SessionDiagnosticsArrayState) replacement : new SessionDiagnosticsArrayState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SessionDiagnosticsArray;
        break;
      case "SessionSecurityDiagnosticsArray":
        if (createOrReplace && this.SessionSecurityDiagnosticsArray == null)
          this.SessionSecurityDiagnosticsArray = replacement != null ? (SessionSecurityDiagnosticsArrayState) replacement : new SessionSecurityDiagnosticsArrayState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SessionSecurityDiagnosticsArray;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
