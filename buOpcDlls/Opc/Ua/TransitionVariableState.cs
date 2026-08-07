// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransitionVariableState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransitionVariableState(NodeState parent) : BaseDataVariableState<LocalizedText>(parent)
{
  private const string Name_InitializationString = "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMwKAC4ARMwKAAAAFP////8BAf////8AAAAA";
  private const string Number_InitializationString = "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAA=";
  private const string TransitionTime_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAA";
  private const string EffectiveTransitionTime_InitializationString = "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQDALAAuAETALAAAAQAmAf////8BAf////8AAAAA";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHgAAAFRyYW5zaXRpb25WYXJpYWJsZVR5cGVJbnN0YW5jZQEAygoBAMoKygoAAAAV/////wEB/////wUAAAAVYIkKAgAAAAAAAgAAAElkAQDLCgAuAETLCgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAEAAAATmFtZQEAzAoALgBEzAoAAAAU/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAwCwALgBEwCwAAAEAJgH/////AQH/////AAAAAA==";
  private PropertyState m_id;
  private PropertyState<QualifiedName> m_name;
  private PropertyState<uint> m_number;
  private PropertyState<DateTime> m_transitionTime;
  private PropertyState<DateTime> m_effectiveTransitionTime;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2762U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHgAAAFRyYW5zaXRpb25WYXJpYWJsZVR5cGVJbnN0YW5jZQEAygoBAMoKygoAAAAV/////wEB/////wUAAAAVYIkKAgAAAAAAAgAAAElkAQDLCgAuAETLCgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAEAAAATmFtZQEAzAoALgBEzAoAAAAU/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAwCwALgBEwCwAAAEAJgH/////AQH/////AAAAAA==");
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
    if (this.Name != null)
      this.Name.Initialize(context, "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMwKAC4ARMwKAAAAFP////8BAf////8AAAAA");
    if (this.Number != null)
      this.Number.Initialize(context, "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAA=");
    if (this.TransitionTime != null)
      this.TransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAA");
    if (this.EffectiveTransitionTime == null)
      return;
    this.EffectiveTransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQDALAAuAETALAAAAQAmAf////8BAf////8AAAAA");
  }

  public PropertyState Id
  {
    get => this.m_id;
    set
    {
      if (this.m_id != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_id = value;
    }
  }

  public PropertyState<QualifiedName> Name
  {
    get => this.m_name;
    set
    {
      if (this.m_name != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_name = value;
    }
  }

  public PropertyState<uint> Number
  {
    get => this.m_number;
    set
    {
      if (this.m_number != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_number = value;
    }
  }

  public PropertyState<DateTime> TransitionTime
  {
    get => this.m_transitionTime;
    set
    {
      if (this.m_transitionTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transitionTime = value;
    }
  }

  public PropertyState<DateTime> EffectiveTransitionTime
  {
    get => this.m_effectiveTransitionTime;
    set
    {
      if (this.m_effectiveTransitionTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_effectiveTransitionTime = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_id != null)
      children.Add((BaseInstanceState) this.m_id);
    if (this.m_name != null)
      children.Add((BaseInstanceState) this.m_name);
    if (this.m_number != null)
      children.Add((BaseInstanceState) this.m_number);
    if (this.m_transitionTime != null)
      children.Add((BaseInstanceState) this.m_transitionTime);
    if (this.m_effectiveTransitionTime != null)
      children.Add((BaseInstanceState) this.m_effectiveTransitionTime);
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
      case "Id":
        if (createOrReplace && this.Id == null)
          this.Id = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Id;
        break;
      case "Name":
        if (createOrReplace && this.Name == null)
          this.Name = replacement != null ? (PropertyState<QualifiedName>) replacement : new PropertyState<QualifiedName>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Name;
        break;
      case "Number":
        if (createOrReplace && this.Number == null)
          this.Number = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Number;
        break;
      case "TransitionTime":
        if (createOrReplace && this.TransitionTime == null)
          this.TransitionTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TransitionTime;
        break;
      case "EffectiveTransitionTime":
        if (createOrReplace && this.EffectiveTransitionTime == null)
          this.EffectiveTransitionTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EffectiveTransitionTime;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
