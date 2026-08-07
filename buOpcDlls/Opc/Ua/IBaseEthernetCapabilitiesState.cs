// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IBaseEthernetCapabilitiesState
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
public class IBaseEthernetCapabilitiesState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAElCYXNlRXRoZXJuZXRDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBAGdeAQBnXmdeAAD/////AQAAABVgiQoCAAAAAAAOAAAAVmxhblRhZ0NhcGFibGUBAGheAC8AP2heAAAAAf////8BAf////8AAAAA";
  private BaseDataVariableState<bool> m_vlanTagCapable;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24167U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJQAAAElCYXNlRXRoZXJuZXRDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBAGdeAQBnXmdeAAD/////AQAAABVgiQoCAAAAAAAOAAAAVmxhblRhZ0NhcGFibGUBAGheAC8AP2heAAAAAf////8BAf////8AAAAA");
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

  public BaseDataVariableState<bool> VlanTagCapable
  {
    get => this.m_vlanTagCapable;
    set
    {
      if (this.m_vlanTagCapable != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_vlanTagCapable = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_vlanTagCapable != null)
      children.Add((BaseInstanceState) this.m_vlanTagCapable);
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
    if (browseName.Name == "VlanTagCapable")
    {
      if (createOrReplace && this.VlanTagCapable == null)
        this.VlanTagCapable = replacement != null ? (BaseDataVariableState<bool>) replacement : new BaseDataVariableState<bool>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.VlanTagCapable;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
