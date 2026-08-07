// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RationalNumberState
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
public class RationalNumberState(NodeState parent) : BaseDataVariableState<RationalNumber>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAGgAAAFJhdGlvbmFsTnVtYmVyVHlwZUluc3RhbmNlAQAtRQEALUUtRQAAAQB2Sf////8BAf////8CAAAAFWCJCgIAAAAAAAkAAABOdW1lcmF0b3IBADBFAC8APzBFAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABEZW5vbWluYXRvcgEAMUUALwA/MUUAAAAH/////wEB/////wAAAAA=";
  private BaseDataVariableState<int> m_numerator;
  private BaseDataVariableState<uint> m_denominator;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17709U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18806U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAGgAAAFJhdGlvbmFsTnVtYmVyVHlwZUluc3RhbmNlAQAtRQEALUUtRQAAAQB2Sf////8BAf////8CAAAAFWCJCgIAAAAAAAkAAABOdW1lcmF0b3IBADBFAC8APzBFAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABEZW5vbWluYXRvcgEAMUUALwA/MUUAAAAH/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<int> Numerator
  {
    get => this.m_numerator;
    set
    {
      if (this.m_numerator != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_numerator = value;
    }
  }

  public BaseDataVariableState<uint> Denominator
  {
    get => this.m_denominator;
    set
    {
      if (this.m_denominator != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_denominator = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_numerator != null)
      children.Add((BaseInstanceState) this.m_numerator);
    if (this.m_denominator != null)
      children.Add((BaseInstanceState) this.m_denominator);
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
      case "Numerator":
        if (createOrReplace && this.Numerator == null)
          this.Numerator = replacement != null ? (BaseDataVariableState<int>) replacement : new BaseDataVariableState<int>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Numerator;
        break;
      case "Denominator":
        if (createOrReplace && this.Denominator == null)
          this.Denominator = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Denominator;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
