// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UANode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Export;

[XmlInclude(typeof (UAType))]
[XmlInclude(typeof (UAReferenceType))]
[XmlInclude(typeof (UADataType))]
[XmlInclude(typeof (UAVariableType))]
[XmlInclude(typeof (UAObjectType))]
[XmlInclude(typeof (UAInstance))]
[XmlInclude(typeof (UAView))]
[XmlInclude(typeof (UAMethod))]
[XmlInclude(typeof (UAVariable))]
[XmlInclude(typeof (UAObject))]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
[Serializable]
public class UANode
{
  private LocalizedText[] displayNameField;
  private LocalizedText[] descriptionField;
  private string[] categoryField;
  private string documentationField;
  private Reference[] referencesField;
  private RolePermission[] rolePermissionsField;
  private XmlElement[] extensionsField;
  private string nodeIdField;
  private string browseNameField;
  private uint writeMaskField;
  private uint userWriteMaskField;
  private ushort accessRestrictionsField;
  private bool accessRestrictionsFieldSpecified;
  private bool hasNoPermissionsField;
  private string symbolicNameField;
  private ReleaseStatus releaseStatusField;

  public UANode()
  {
    this.writeMaskField = 0U;
    this.userWriteMaskField = 0U;
    this.hasNoPermissionsField = false;
    this.releaseStatusField = ReleaseStatus.Released;
  }

  [XmlElement("DisplayName")]
  public LocalizedText[] DisplayName
  {
    get => this.displayNameField;
    set => this.displayNameField = value;
  }

  [XmlElement("Description")]
  public LocalizedText[] Description
  {
    get => this.descriptionField;
    set => this.descriptionField = value;
  }

  [XmlElement("Category")]
  public string[] Category
  {
    get => this.categoryField;
    set => this.categoryField = value;
  }

  public string Documentation
  {
    get => this.documentationField;
    set => this.documentationField = value;
  }

  [XmlArrayItem(IsNullable = false)]
  public Reference[] References
  {
    get => this.referencesField;
    set => this.referencesField = value;
  }

  [XmlArrayItem(IsNullable = false)]
  public RolePermission[] RolePermissions
  {
    get => this.rolePermissionsField;
    set => this.rolePermissionsField = value;
  }

  [XmlArrayItem("Extension", IsNullable = false)]
  public XmlElement[] Extensions
  {
    get => this.extensionsField;
    set => this.extensionsField = value;
  }

  [XmlAttribute]
  public string NodeId
  {
    get => this.nodeIdField;
    set => this.nodeIdField = value;
  }

  [XmlAttribute]
  public string BrowseName
  {
    get => this.browseNameField;
    set => this.browseNameField = value;
  }

  [XmlAttribute]
  [DefaultValue(typeof (uint), "0")]
  public uint WriteMask
  {
    get => this.writeMaskField;
    set => this.writeMaskField = value;
  }

  [XmlAttribute]
  [DefaultValue(typeof (uint), "0")]
  public uint UserWriteMask
  {
    get => this.userWriteMaskField;
    set => this.userWriteMaskField = value;
  }

  [XmlAttribute]
  public ushort AccessRestrictions
  {
    get => this.accessRestrictionsField;
    set => this.accessRestrictionsField = value;
  }

  [XmlIgnore]
  public bool AccessRestrictionsSpecified
  {
    get => this.accessRestrictionsFieldSpecified;
    set => this.accessRestrictionsFieldSpecified = value;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool HasNoPermissions
  {
    get => this.hasNoPermissionsField;
    set => this.hasNoPermissionsField = value;
  }

  [XmlAttribute]
  public string SymbolicName
  {
    get => this.symbolicNameField;
    set => this.symbolicNameField = value;
  }

  [XmlAttribute]
  [DefaultValue(ReleaseStatus.Released)]
  public ReleaseStatus ReleaseStatus
  {
    get => this.releaseStatusField;
    set => this.releaseStatusField = value;
  }
}
