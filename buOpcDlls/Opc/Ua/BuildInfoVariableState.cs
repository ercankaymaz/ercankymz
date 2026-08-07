// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BuildInfoVariableState
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
public class BuildInfoVariableState(NodeState parent) : BaseDataVariableState<BuildInfo>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAFQAAAEJ1aWxkSW5mb1R5cGVJbnN0YW5jZQEA6wsBAOsL6wsAAAEAUgH/////AQH/////BgAAABVwiQoCAAAAAAAKAAAAUHJvZHVjdFVyaQEA7AsALwA/7AsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAQAAAATWFudWZhY3R1cmVyTmFtZQEA7QsALwA/7QsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAUHJvZHVjdE5hbWUBAO4LAC8AP+4LAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAADwAAAFNvZnR3YXJlVmVyc2lvbgEA7wsALwA/7wsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAQnVpbGROdW1iZXIBAPALAC8AP/ALAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACQAAAEJ1aWxkRGF0ZQEA8QsALwA/8QsAAAEAJgH/////AQEAAAAAAECPQP////8AAAAA";
  private BaseDataVariableState<string> m_productUri;
  private BaseDataVariableState<string> m_manufacturerName;
  private BaseDataVariableState<string> m_productName;
  private BaseDataVariableState<string> m_softwareVersion;
  private BaseDataVariableState<string> m_buildNumber;
  private BaseDataVariableState<DateTime> m_buildDate;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 3051U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 338U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAFQAAAEJ1aWxkSW5mb1R5cGVJbnN0YW5jZQEA6wsBAOsL6wsAAAEAUgH/////AQH/////BgAAABVwiQoCAAAAAAAKAAAAUHJvZHVjdFVyaQEA7AsALwA/7AsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAQAAAATWFudWZhY3R1cmVyTmFtZQEA7QsALwA/7QsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAUHJvZHVjdE5hbWUBAO4LAC8AP+4LAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAADwAAAFNvZnR3YXJlVmVyc2lvbgEA7wsALwA/7wsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAQnVpbGROdW1iZXIBAPALAC8AP/ALAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACQAAAEJ1aWxkRGF0ZQEA8QsALwA/8QsAAAEAJgH/////AQEAAAAAAECPQP////8AAAAA");
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

  public BaseDataVariableState<string> ProductUri
  {
    get => this.m_productUri;
    set
    {
      if (this.m_productUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_productUri = value;
    }
  }

  public BaseDataVariableState<string> ManufacturerName
  {
    get => this.m_manufacturerName;
    set
    {
      if (this.m_manufacturerName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_manufacturerName = value;
    }
  }

  public BaseDataVariableState<string> ProductName
  {
    get => this.m_productName;
    set
    {
      if (this.m_productName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_productName = value;
    }
  }

  public BaseDataVariableState<string> SoftwareVersion
  {
    get => this.m_softwareVersion;
    set
    {
      if (this.m_softwareVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_softwareVersion = value;
    }
  }

  public BaseDataVariableState<string> BuildNumber
  {
    get => this.m_buildNumber;
    set
    {
      if (this.m_buildNumber != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_buildNumber = value;
    }
  }

  public BaseDataVariableState<DateTime> BuildDate
  {
    get => this.m_buildDate;
    set
    {
      if (this.m_buildDate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_buildDate = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_productUri != null)
      children.Add((BaseInstanceState) this.m_productUri);
    if (this.m_manufacturerName != null)
      children.Add((BaseInstanceState) this.m_manufacturerName);
    if (this.m_productName != null)
      children.Add((BaseInstanceState) this.m_productName);
    if (this.m_softwareVersion != null)
      children.Add((BaseInstanceState) this.m_softwareVersion);
    if (this.m_buildNumber != null)
      children.Add((BaseInstanceState) this.m_buildNumber);
    if (this.m_buildDate != null)
      children.Add((BaseInstanceState) this.m_buildDate);
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
      case "ProductUri":
        if (createOrReplace && this.ProductUri == null)
          this.ProductUri = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ProductUri;
        break;
      case "ManufacturerName":
        if (createOrReplace && this.ManufacturerName == null)
          this.ManufacturerName = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ManufacturerName;
        break;
      case "ProductName":
        if (createOrReplace && this.ProductName == null)
          this.ProductName = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ProductName;
        break;
      case "SoftwareVersion":
        if (createOrReplace && this.SoftwareVersion == null)
          this.SoftwareVersion = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SoftwareVersion;
        break;
      case "BuildNumber":
        if (createOrReplace && this.BuildNumber == null)
          this.BuildNumber = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.BuildNumber;
        break;
      case "BuildDate":
        if (createOrReplace && this.BuildDate == null)
          this.BuildDate = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.BuildDate;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
