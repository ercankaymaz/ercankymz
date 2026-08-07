// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OptionSetState
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
public class OptionSetState(NodeState parent) : BaseDataVariableState(parent)
{
  private const string BitMask_InitializationString = "//////////8XYIkKAgAAAAAABwAAAEJpdE1hc2sBALUtAC4ARLUtAAAAAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAFQAAAE9wdGlvblNldFR5cGVJbnN0YW5jZQEA3ywBAN8s3ywAAAAY/////wEB/////wIAAAAXYIkKAgAAAAAADwAAAE9wdGlvblNldFZhbHVlcwEA4CwALgBE4CwAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAHAAAAQml0TWFzawEAtS0ALgBEtS0AAAABAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<LocalizedText[]> m_optionSetValues;
  private PropertyState<bool[]> m_bitMask;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11487U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAFQAAAE9wdGlvblNldFR5cGVJbnN0YW5jZQEA3ywBAN8s3ywAAAAY/////wEB/////wIAAAAXYIkKAgAAAAAADwAAAE9wdGlvblNldFZhbHVlcwEA4CwALgBE4CwAAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAHAAAAQml0TWFzawEAtS0ALgBEtS0AAAABAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    if (this.BitMask == null)
      return;
    this.BitMask.Initialize(context, "//////////8XYIkKAgAAAAAABwAAAEJpdE1hc2sBALUtAC4ARLUtAAAAAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public PropertyState<LocalizedText[]> OptionSetValues
  {
    get => this.m_optionSetValues;
    set
    {
      if (this.m_optionSetValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_optionSetValues = value;
    }
  }

  public PropertyState<bool[]> BitMask
  {
    get => this.m_bitMask;
    set
    {
      if (this.m_bitMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_bitMask = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_optionSetValues != null)
      children.Add((BaseInstanceState) this.m_optionSetValues);
    if (this.m_bitMask != null)
      children.Add((BaseInstanceState) this.m_bitMask);
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
      case "OptionSetValues":
        if (createOrReplace && this.OptionSetValues == null)
          this.OptionSetValues = replacement != null ? (PropertyState<LocalizedText[]>) replacement : new PropertyState<LocalizedText[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OptionSetValues;
        break;
      case "BitMask":
        if (createOrReplace && this.BitMask == null)
          this.BitMask = replacement != null ? (PropertyState<bool[]>) replacement : new PropertyState<bool[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.BitMask;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
