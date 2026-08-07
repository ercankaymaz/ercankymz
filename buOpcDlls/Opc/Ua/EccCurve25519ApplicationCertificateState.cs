// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EccCurve25519ApplicationCertificateState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class EccCurve25519ApplicationCertificateState(NodeState parent) : 
  EccApplicationCertificateState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALwAAAEVjY0N1cnZlMjU1MTlBcHBsaWNhdGlvbkNlcnRpZmljYXRlVHlwZUluc3RhbmNlAQD2WwEA9lv2WwAA/////wAAAAA=";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 23542U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALwAAAEVjY0N1cnZlMjU1MTlBcHBsaWNhdGlvbkNlcnRpZmljYXRlVHlwZUluc3RhbmNlAQD2WwEA9lv2WwAA/////wAAAAA=");
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
}
