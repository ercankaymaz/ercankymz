// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDFrameState
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
public class ThreeDFrameState(NodeState parent) : FrameState(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAFwAAAFRocmVlREZyYW1lVHlwZUluc3RhbmNlAQBnSQEAZ0lnSQAAAQB+Sf////8BAf////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAbEkALwEAVklsSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBuSQAvAD9uSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAb0kALwA/b0kAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAHBJAC8AP3BJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAaEkALwEAXUloSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQCCSgAvAD+CSgAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAg0oALwA/g0oAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAIRKAC8AP4RKAAAAC/////8BAf////8AAAAA";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18791U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18814U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAFwAAAFRocmVlREZyYW1lVHlwZUluc3RhbmNlAQBnSQEAZ0lnSQAAAQB+Sf////8BAf////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAbEkALwEAVklsSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBuSQAvAD9uSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAb0kALwA/b0kAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAHBJAC8AP3BJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAaEkALwEAXUloSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQCCSgAvAD+CSgAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAg0oALwA/g0oAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAIRKAC8AP4RKAAAAC/////8BAf////8AAAAA");
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

  public ThreeDCartesianCoordinatesState CartesianCoordinates
  {
    get => (ThreeDCartesianCoordinatesState) base.CartesianCoordinates;
    set => this.CartesianCoordinates = (CartesianCoordinatesState) value;
  }

  public ThreeDOrientationState Orientation
  {
    get => (ThreeDOrientationState) base.Orientation;
    set => this.Orientation = (OrientationState) value;
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
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
          this.CartesianCoordinates = replacement != null ? (ThreeDCartesianCoordinatesState) replacement : new ThreeDCartesianCoordinatesState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CartesianCoordinates;
        break;
      case "Orientation":
        if (createOrReplace && this.Orientation == null)
          this.Orientation = replacement != null ? (ThreeDOrientationState) replacement : new ThreeDOrientationState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Orientation;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
