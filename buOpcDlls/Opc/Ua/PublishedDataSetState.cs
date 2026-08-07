// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataSetState
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
public class PublishedDataSetState(NodeState parent) : BaseObjectState(parent)
{
  private const string DataSetClassId_InitializationString = "//////////8VYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQB3QQAuAER3QQAAAA7/////AQH/////AAAAAA==";
  private const string ExtensionFields_InitializationString = "//////////8EYIAKAQAAAAAADwAAAEV4dGVuc2lvbkZpZWxkcwEAeTwALwEAgTx5PAAA/////wIAAAAEYYIKBAAAAAAAEQAAAEFkZEV4dGVuc2lvbkZpZWxkAQB6PAAvAQCDPHo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAezwALgBEezwAAJYCAAAAAQAqAQEYAAAACQAAAEZpZWxkTmFtZQAU/////wAAAAAAAQAqAQEZAAAACgAAAEZpZWxkVmFsdWUAGP7///8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHw8AC4ARHw8AACWAQAAAAEAKgEBFgAAAAcAAABGaWVsZElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAUAAAAUmVtb3ZlRXh0ZW5zaW9uRmllbGQBAH08AC8BAIY8fTwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB+PAAuAER+PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFB1Ymxpc2hlZERhdGFTZXRUeXBlSW5zdGFuY2UBAK04AQCtOK04AAD/////BAAAABVgiQoCAAAAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BALc4AC4ARLc4AAABAAE5/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAERhdGFTZXRNZXRhRGF0YQEAfTsALgBEfTsAAAEAuzj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAARGF0YVNldENsYXNzSWQBAHdBAC4ARHdBAAAADv////8BAf////8AAAAABGCACgEAAAAAAA8AAABFeHRlbnNpb25GaWVsZHMBAHk8AC8BAIE8eTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAejwALwEAgzx6PAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHs8AC4ARHs8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB8PAAuAER8PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQB9PAAvAQCGPH08AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfjwALgBEfjwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private PropertyState<ConfigurationVersionDataType> m_configurationVersion;
  private PropertyState<DataSetMetaDataType> m_dataSetMetaData;
  private PropertyState<Guid> m_dataSetClassId;
  private ExtensionFieldsState m_extensionFields;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14509U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFB1Ymxpc2hlZERhdGFTZXRUeXBlSW5zdGFuY2UBAK04AQCtOK04AAD/////BAAAABVgiQoCAAAAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BALc4AC4ARLc4AAABAAE5/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAERhdGFTZXRNZXRhRGF0YQEAfTsALgBEfTsAAAEAuzj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAARGF0YVNldENsYXNzSWQBAHdBAC4ARHdBAAAADv////8BAf////8AAAAABGCACgEAAAAAAA8AAABFeHRlbnNpb25GaWVsZHMBAHk8AC8BAIE8eTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAejwALwEAgzx6PAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHs8AC4ARHs8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB8PAAuAER8PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQB9PAAvAQCGPH08AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAfjwALgBEfjwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    if (this.DataSetClassId != null)
      this.DataSetClassId.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQB3QQAuAER3QQAAAA7/////AQH/////AAAAAA==");
    if (this.ExtensionFields == null)
      return;
    this.ExtensionFields.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAEV4dGVuc2lvbkZpZWxkcwEAeTwALwEAgTx5PAAA/////wIAAAAEYYIKBAAAAAAAEQAAAEFkZEV4dGVuc2lvbkZpZWxkAQB6PAAvAQCDPHo8AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAezwALgBEezwAAJYCAAAAAQAqAQEYAAAACQAAAEZpZWxkTmFtZQAU/////wAAAAAAAQAqAQEZAAAACgAAAEZpZWxkVmFsdWUAGP7///8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHw8AC4ARHw8AACWAQAAAAEAKgEBFgAAAAcAAABGaWVsZElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAUAAAAUmVtb3ZlRXh0ZW5zaW9uRmllbGQBAH08AC8BAIY8fTwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB+PAAuAER+PAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public PropertyState<ConfigurationVersionDataType> ConfigurationVersion
  {
    get => this.m_configurationVersion;
    set
    {
      if (this.m_configurationVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_configurationVersion = value;
    }
  }

  public PropertyState<DataSetMetaDataType> DataSetMetaData
  {
    get => this.m_dataSetMetaData;
    set
    {
      if (this.m_dataSetMetaData != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetMetaData = value;
    }
  }

  public PropertyState<Guid> DataSetClassId
  {
    get => this.m_dataSetClassId;
    set
    {
      if (this.m_dataSetClassId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetClassId = value;
    }
  }

  public ExtensionFieldsState ExtensionFields
  {
    get => this.m_extensionFields;
    set
    {
      if (this.m_extensionFields != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_extensionFields = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_configurationVersion != null)
      children.Add((BaseInstanceState) this.m_configurationVersion);
    if (this.m_dataSetMetaData != null)
      children.Add((BaseInstanceState) this.m_dataSetMetaData);
    if (this.m_dataSetClassId != null)
      children.Add((BaseInstanceState) this.m_dataSetClassId);
    if (this.m_extensionFields != null)
      children.Add((BaseInstanceState) this.m_extensionFields);
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
      case "ConfigurationVersion":
        if (createOrReplace && this.ConfigurationVersion == null)
          this.ConfigurationVersion = replacement != null ? (PropertyState<ConfigurationVersionDataType>) replacement : new PropertyState<ConfigurationVersionDataType>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ConfigurationVersion;
        break;
      case "DataSetMetaData":
        if (createOrReplace && this.DataSetMetaData == null)
          this.DataSetMetaData = replacement != null ? (PropertyState<DataSetMetaDataType>) replacement : new PropertyState<DataSetMetaDataType>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DataSetMetaData;
        break;
      case "DataSetClassId":
        if (createOrReplace && this.DataSetClassId == null)
          this.DataSetClassId = replacement != null ? (PropertyState<Guid>) replacement : new PropertyState<Guid>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DataSetClassId;
        break;
      case "ExtensionFields":
        if (createOrReplace && this.ExtensionFields == null)
          this.ExtensionFields = replacement != null ? (ExtensionFieldsState) replacement : new ExtensionFieldsState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ExtensionFields;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
