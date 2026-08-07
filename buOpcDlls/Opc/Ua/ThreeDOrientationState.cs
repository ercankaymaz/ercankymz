// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDOrientationState
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
public class ThreeDOrientationState(NodeState parent) : OrientationState(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHQAAAFRocmVlRE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBdSQEAXUldSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQBfSQAvAD9fSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAYEkALwA/YEkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAGFJAC8AP2FJAAAAC/////8BAf////8AAAAA";
  private BaseDataVariableState<double> m_a;
  private BaseDataVariableState<double> m_b;
  private BaseDataVariableState<double> m_c;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18781U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18812U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHQAAAFRocmVlRE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBdSQEAXUldSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQBfSQAvAD9fSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAYEkALwA/YEkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAGFJAC8AP2FJAAAAC/////8BAf////8AAAAA");
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

  public BaseDataVariableState<double> A
  {
    get => this.m_a;
    set
    {
      if (this.m_a != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_a = value;
    }
  }

  public BaseDataVariableState<double> B
  {
    get => this.m_b;
    set
    {
      if (this.m_b != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_b = value;
    }
  }

  public BaseDataVariableState<double> C
  {
    get => this.m_c;
    set
    {
      if (this.m_c != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_c = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_a != null)
      children.Add((BaseInstanceState) this.m_a);
    if (this.m_b != null)
      children.Add((BaseInstanceState) this.m_b);
    if (this.m_c != null)
      children.Add((BaseInstanceState) this.m_c);
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
      case "A":
        if (createOrReplace && this.A == null)
          this.A = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.A;
        break;
      case "B":
        if (createOrReplace && this.B == null)
          this.B = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.B;
        break;
      case "C":
        if (createOrReplace && this.C == null)
          this.C = replacement != null ? (BaseDataVariableState<double>) replacement : new BaseDataVariableState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.C;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
