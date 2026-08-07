// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OrientationState
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
public class OrientationState(NodeState parent) : BaseDataVariableState<Orientation>(parent)
{
  private const string AngleUnit_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEFuZ2xlVW5pdAEAXEkALgBEXEkAAAEAdwP/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAFwAAAE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBbSQEAW0lbSQAAAQB7Sf////8BAf////8BAAAAFWCJCgIAAAAAAAkAAABBbmdsZVVuaXQBAFxJAC4ARFxJAAABAHcD/////wEB/////wAAAAA=";
  private PropertyState<EUInformation> m_angleUnit;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18779U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18811U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAFwAAAE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBbSQEAW0lbSQAAAQB7Sf////8BAf////8BAAAAFWCJCgIAAAAAAAkAAABBbmdsZVVuaXQBAFxJAC4ARFxJAAABAHcD/////wEB/////wAAAAA=");
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
    if (this.AngleUnit == null)
      return;
    this.AngleUnit.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEFuZ2xlVW5pdAEAXEkALgBEXEkAAAEAdwP/////AQH/////AAAAAA==");
  }

  public PropertyState<EUInformation> AngleUnit
  {
    get => this.m_angleUnit;
    set
    {
      if (this.m_angleUnit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_angleUnit = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_angleUnit != null)
      children.Add((BaseInstanceState) this.m_angleUnit);
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
    if (browseName.Name == "AngleUnit")
    {
      if (createOrReplace && this.AngleUnit == null)
        this.AngleUnit = replacement != null ? (PropertyState<EUInformation>) replacement : new PropertyState<EUInformation>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.AngleUnit;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
