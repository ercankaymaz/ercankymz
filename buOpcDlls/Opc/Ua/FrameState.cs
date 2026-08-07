// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FrameState
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
public class FrameState(NodeState parent) : BaseDataVariableState<Frame>(parent)
{
  private const string Constant_InitializationString = "//////////8VYIkKAgAAAAAACAAAAENvbnN0YW50AQBkSQAuAERkSQAAAAH/////AQH/////AAAAAA==";
  private const string BaseFrame_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAA=";
  private const string FixedBase_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAEQAAAEZyYW1lVHlwZUluc3RhbmNlAQBiSQEAYkliSQAAAQB9Sf////8BAf////8FAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAcUkALwEAVElxSQAAAQB5Sf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAY0kALwEAW0ljSQAAAQB7Sf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABDb25zdGFudAEAZEkALgBEZEkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=";
  private CartesianCoordinatesState m_cartesianCoordinates;
  private OrientationState m_orientation;
  private PropertyState<bool> m_constant;
  private BaseDataVariableState<NodeId> m_baseFrame;
  private PropertyState<bool> m_fixedBase;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18786U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18813U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAEQAAAEZyYW1lVHlwZUluc3RhbmNlAQBiSQEAYkliSQAAAQB9Sf////8BAf////8FAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAcUkALwEAVElxSQAAAQB5Sf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAY0kALwEAW0ljSQAAAQB7Sf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABDb25zdGFudAEAZEkALgBEZEkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=");
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
    if (this.Constant != null)
      this.Constant.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAENvbnN0YW50AQBkSQAuAERkSQAAAAH/////AQH/////AAAAAA==");
    if (this.BaseFrame != null)
      this.BaseFrame.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAA=");
    if (this.FixedBase == null)
      return;
    this.FixedBase.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=");
  }

  public CartesianCoordinatesState CartesianCoordinates
  {
    get => this.m_cartesianCoordinates;
    set
    {
      if (this.m_cartesianCoordinates != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_cartesianCoordinates = value;
    }
  }

  public OrientationState Orientation
  {
    get => this.m_orientation;
    set
    {
      if (this.m_orientation != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_orientation = value;
    }
  }

  public PropertyState<bool> Constant
  {
    get => this.m_constant;
    set
    {
      if (this.m_constant != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_constant = value;
    }
  }

  public BaseDataVariableState<NodeId> BaseFrame
  {
    get => this.m_baseFrame;
    set
    {
      if (this.m_baseFrame != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_baseFrame = value;
    }
  }

  public PropertyState<bool> FixedBase
  {
    get => this.m_fixedBase;
    set
    {
      if (this.m_fixedBase != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_fixedBase = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_cartesianCoordinates != null)
      children.Add((BaseInstanceState) this.m_cartesianCoordinates);
    if (this.m_orientation != null)
      children.Add((BaseInstanceState) this.m_orientation);
    if (this.m_constant != null)
      children.Add((BaseInstanceState) this.m_constant);
    if (this.m_baseFrame != null)
      children.Add((BaseInstanceState) this.m_baseFrame);
    if (this.m_fixedBase != null)
      children.Add((BaseInstanceState) this.m_fixedBase);
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
      case "CartesianCoordinates":
        if (createOrReplace && this.CartesianCoordinates == null)
          this.CartesianCoordinates = replacement != null ? (CartesianCoordinatesState) replacement : new CartesianCoordinatesState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CartesianCoordinates;
        break;
      case "Orientation":
        if (createOrReplace && this.Orientation == null)
          this.Orientation = replacement != null ? (OrientationState) replacement : new OrientationState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Orientation;
        break;
      case "Constant":
        if (createOrReplace && this.Constant == null)
          this.Constant = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Constant;
        break;
      case "BaseFrame":
        if (createOrReplace && this.BaseFrame == null)
          this.BaseFrame = replacement != null ? (BaseDataVariableState<NodeId>) replacement : new BaseDataVariableState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.BaseFrame;
        break;
      case "FixedBase":
        if (createOrReplace && this.FixedBase == null)
          this.FixedBase = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FixedBase;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
