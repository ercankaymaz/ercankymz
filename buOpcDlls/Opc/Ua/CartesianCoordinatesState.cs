// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CartesianCoordinatesState
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
public class CartesianCoordinatesState(NodeState parent) : 
  BaseDataVariableState<CartesianCoordinates>(parent)
{
  private const string LengthUnit_InitializationString = "//////////8VYIkKAgAAAAAACgAAAExlbmd0aFVuaXQBAFVJAC4ARFVJAAABAHcD/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAIAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBUSQEAVElUSQAAAQB5Sf////8BAf////8BAAAAFWCJCgIAAAAAAAoAAABMZW5ndGhVbml0AQBVSQAuAERVSQAAAQB3A/////8BAf////8AAAAA";
  private PropertyState<EUInformation> m_lengthUnit;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18772U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18809U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAIAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBUSQEAVElUSQAAAQB5Sf////8BAf////8BAAAAFWCJCgIAAAAAAAoAAABMZW5ndGhVbml0AQBVSQAuAERVSQAAAQB3A/////8BAf////8AAAAA");
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
    if (this.LengthUnit == null)
      return;
    this.LengthUnit.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAExlbmd0aFVuaXQBAFVJAC4ARFVJAAABAHcD/////wEB/////wAAAAA=");
  }

  public PropertyState<EUInformation> LengthUnit
  {
    get => this.m_lengthUnit;
    set
    {
      if (this.m_lengthUnit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lengthUnit = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_lengthUnit != null)
      children.Add((BaseInstanceState) this.m_lengthUnit);
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
    if (browseName.Name == "LengthUnit")
    {
      if (createOrReplace && this.LengthUnit == null)
        this.LengthUnit = replacement != null ? (PropertyState<EUInformation>) replacement : new PropertyState<EUInformation>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.LengthUnit;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
