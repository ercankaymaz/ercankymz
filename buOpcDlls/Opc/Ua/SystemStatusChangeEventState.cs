// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SystemStatusChangeEventState
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
public class SystemStatusChangeEventState(NodeState parent) : SystemEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAFN5c3RlbVN0YXR1c0NoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQC2LAEAtiy2LAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALcsAC4ARLcsAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALgsAC4ARLgsAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC5LAAuAES5LAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAuiwALgBEuiwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALssAC4ARLssAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC8LAAuAES8LAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC+LAAuAES+LAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAL8sAC4ARL8sAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTeXN0ZW1TdGF0ZQEAsC0ALgBEsC0AAAEAVAP/////AQH/////AAAAAA==";
  private PropertyState<ServerState> m_systemState;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11446U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAFN5c3RlbVN0YXR1c0NoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQC2LAEAtiy2LAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALcsAC4ARLcsAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALgsAC4ARLgsAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC5LAAuAES5LAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAuiwALgBEuiwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALssAC4ARLssAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC8LAAuAES8LAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC+LAAuAES+LAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAL8sAC4ARL8sAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTeXN0ZW1TdGF0ZQEAsC0ALgBEsC0AAAEAVAP/////AQH/////AAAAAA==");
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

  public PropertyState<ServerState> SystemState
  {
    get => this.m_systemState;
    set
    {
      if (this.m_systemState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_systemState = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_systemState != null)
      children.Add((BaseInstanceState) this.m_systemState);
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
    if (browseName.Name == "SystemState")
    {
      if (createOrReplace && this.SystemState == null)
        this.SystemState = replacement != null ? (PropertyState<ServerState>) replacement : new PropertyState<ServerState>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.SystemState;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
