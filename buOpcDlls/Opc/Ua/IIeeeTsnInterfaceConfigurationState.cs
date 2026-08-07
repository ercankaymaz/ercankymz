// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeTsnInterfaceConfigurationState
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
public class IIeeeTsnInterfaceConfigurationState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InterfaceName_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEludGVyZmFjZU5hbWUBAH5eAC8AP35eAAAADP////8BAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAKgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAfF4BAHxefF4AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQB9XgAvAD99XgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAASW50ZXJmYWNlTmFtZQEAfl4ALwA/fl4AAAAM/////wEB/////wAAAAA=";
  private BaseDataVariableState<string> m_macAddress;
  private BaseDataVariableState<string> m_interfaceName;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24188U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKgAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAfF4BAHxefF4AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQB9XgAvAD99XgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAASW50ZXJmYWNlTmFtZQEAfl4ALwA/fl4AAAAM/////wEB/////wAAAAA=");
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
    if (this.InterfaceName == null)
      return;
    this.InterfaceName.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEludGVyZmFjZU5hbWUBAH5eAC8AP35eAAAADP////8BAf////8AAAAA");
  }

  public BaseDataVariableState<string> MacAddress
  {
    get => this.m_macAddress;
    set
    {
      if (this.m_macAddress != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_macAddress = value;
    }
  }

  public BaseDataVariableState<string> InterfaceName
  {
    get => this.m_interfaceName;
    set
    {
      if (this.m_interfaceName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_interfaceName = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_macAddress != null)
      children.Add((BaseInstanceState) this.m_macAddress);
    if (this.m_interfaceName != null)
      children.Add((BaseInstanceState) this.m_interfaceName);
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
      case "MacAddress":
        if (createOrReplace && this.MacAddress == null)
          this.MacAddress = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MacAddress;
        break;
      case "InterfaceName":
        if (createOrReplace && this.InterfaceName == null)
          this.InterfaceName = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.InterfaceName;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
