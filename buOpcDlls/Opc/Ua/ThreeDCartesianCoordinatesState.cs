// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDCartesianCoordinatesState
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
public class ThreeDCartesianCoordinatesState(NodeState parent) : CartesianCoordinatesState(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJgAAAFRocmVlRENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBWSQEAVklWSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBYSQAvAD9YSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAWUkALwA/WUkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAFpJAC8AP1pJAAAAC/////8BAf////8AAAAA";
  private BaseDataVariableState<double> m_x;
  private BaseDataVariableState<double> m_y;
  private BaseDataVariableState<double> m_z;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18774U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18810U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJgAAAFRocmVlRENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBWSQEAVklWSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBYSQAvAD9YSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAWUkALwA/WUkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAFpJAC8AP1pJAAAAC/////8BAf////8AAAAA");
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

  public BaseDataVariableState<double> X
  {
    get => this.m_x;
    set
    {
      if (this.m_x != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_x = value;
    }
  }

  public BaseDataVariableState<double> Y
  {
    get => this.m_y;
    set
    {
      if (this.m_y != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_y = value;
    }
  }

  public BaseDataVariableState<double> Z
  {
    get => this.m_z;
    set
    {
      if (this.m_z != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_z = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_x != null)
      children.Add((BaseInstanceState) this.m_x);
    if (this.m_y != null)
      children.Add((BaseInstanceState) this.m_y);
    if (this.m_z != null)
      children.Add((BaseInstanceState) this.m_z);
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
      case "X":
        if (createOrReplace && this.X == null)
          this.X = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.X;
        break;
      case "Y":
        if (createOrReplace && this.Y == null)
          this.Y = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Y;
        break;
      case "Z":
        if (createOrReplace && this.Z == null)
          this.Z = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Z;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
