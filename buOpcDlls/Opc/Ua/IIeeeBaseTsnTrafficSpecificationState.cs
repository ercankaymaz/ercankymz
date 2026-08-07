// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeBaseTsnTrafficSpecificationState
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
public class IIeeeBaseTsnTrafficSpecificationState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAElJZWVlQmFzZVRzblRyYWZmaWNTcGVjaWZpY2F0aW9uVHlwZUluc3RhbmNlAQBzXgEAc15zXgAA/////wMAAAAVYIkKAgAAAAAAEQAAAE1heEludGVydmFsRnJhbWVzAQB0XgAvAD90XgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATWF4RnJhbWVTaXplAQB1XgAvAD91XgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAIAAAASW50ZXJ2YWwBAHZeAC8AP3ZeAAABACte/////wEB/////wAAAAA=";
  private BaseDataVariableState<ushort> m_maxIntervalFrames;
  private BaseDataVariableState<uint> m_maxFrameSize;
  private BaseDataVariableState<UnsignedRationalNumber> m_interval;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24179U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALAAAAElJZWVlQmFzZVRzblRyYWZmaWNTcGVjaWZpY2F0aW9uVHlwZUluc3RhbmNlAQBzXgEAc15zXgAA/////wMAAAAVYIkKAgAAAAAAEQAAAE1heEludGVydmFsRnJhbWVzAQB0XgAvAD90XgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATWF4RnJhbWVTaXplAQB1XgAvAD91XgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAIAAAASW50ZXJ2YWwBAHZeAC8AP3ZeAAABACte/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<ushort> MaxIntervalFrames
  {
    get => this.m_maxIntervalFrames;
    set
    {
      if (this.m_maxIntervalFrames != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxIntervalFrames = value;
    }
  }

  public BaseDataVariableState<uint> MaxFrameSize
  {
    get => this.m_maxFrameSize;
    set
    {
      if (this.m_maxFrameSize != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxFrameSize = value;
    }
  }

  public BaseDataVariableState<UnsignedRationalNumber> Interval
  {
    get => this.m_interval;
    set
    {
      if (this.m_interval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_interval = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_maxIntervalFrames != null)
      children.Add((BaseInstanceState) this.m_maxIntervalFrames);
    if (this.m_maxFrameSize != null)
      children.Add((BaseInstanceState) this.m_maxFrameSize);
    if (this.m_interval != null)
      children.Add((BaseInstanceState) this.m_interval);
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
      case "MaxIntervalFrames":
        if (createOrReplace && this.MaxIntervalFrames == null)
          this.MaxIntervalFrames = replacement != null ? (BaseDataVariableState<ushort>) replacement : new BaseDataVariableState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxIntervalFrames;
        break;
      case "MaxFrameSize":
        if (createOrReplace && this.MaxFrameSize == null)
          this.MaxFrameSize = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxFrameSize;
        break;
      case "Interval":
        if (createOrReplace && this.Interval == null)
          this.Interval = replacement != null ? (BaseDataVariableState<UnsignedRationalNumber>) replacement : new BaseDataVariableState<UnsignedRationalNumber>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Interval;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
