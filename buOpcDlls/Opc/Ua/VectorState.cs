// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VectorState
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
public class VectorState(NodeState parent) : BaseDataVariableState<Vector>(parent)
{
  private const string VectorUnit_InitializationString = "//////////8VYIkKAgAAAAAACgAAAFZlY3RvclVuaXQBADNFAC4ARDNFAAABAHcD/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAEgAAAFZlY3RvclR5cGVJbnN0YW5jZQEAMkUBADJFMkUAAAEAd0n/////AQH/////AQAAABVgiQoCAAAAAAAKAAAAVmVjdG9yVW5pdAEAM0UALgBEM0UAAAEAdwP/////AQH/////AAAAAA==";
  private PropertyState<EUInformation> m_vectorUnit;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17714U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18807U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAEgAAAFZlY3RvclR5cGVJbnN0YW5jZQEAMkUBADJFMkUAAAEAd0n/////AQH/////AQAAABVgiQoCAAAAAAAKAAAAVmVjdG9yVW5pdAEAM0UALgBEM0UAAAEAdwP/////AQH/////AAAAAA==");
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
    if (this.VectorUnit == null)
      return;
    this.VectorUnit.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAFZlY3RvclVuaXQBADNFAC4ARDNFAAABAHcD/////wEB/////wAAAAA=");
  }

  public PropertyState<EUInformation> VectorUnit
  {
    get => this.m_vectorUnit;
    set
    {
      if (this.m_vectorUnit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_vectorUnit = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_vectorUnit != null)
      children.Add((BaseInstanceState) this.m_vectorUnit);
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
    if (browseName.Name == "VectorUnit")
    {
      if (createOrReplace && this.VectorUnit == null)
        this.VectorUnit = replacement != null ? (PropertyState<EUInformation>) replacement : new PropertyState<EUInformation>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.VectorUnit;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
