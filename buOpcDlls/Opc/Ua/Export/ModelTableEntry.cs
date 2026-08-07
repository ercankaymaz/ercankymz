// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.ModelTableEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Export;

[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
[Serializable]
public class ModelTableEntry
{
  private RolePermission[] rolePermissionsField;
  private ModelTableEntry[] requiredModelField;
  private string modelUriField;
  private string xmlSchemaUriField;
  private string versionField;
  private DateTime publicationDateField;
  private bool publicationDateFieldSpecified;
  private ushort accessRestrictionsField;

  public ModelTableEntry() => this.accessRestrictionsField = (ushort) 0;

  [XmlArrayItem(IsNullable = false)]
  public RolePermission[] RolePermissions
  {
    get => this.rolePermissionsField;
    set => this.rolePermissionsField = value;
  }

  [XmlElement("RequiredModel")]
  public ModelTableEntry[] RequiredModel
  {
    get => this.requiredModelField;
    set => this.requiredModelField = value;
  }

  [XmlAttribute]
  public string ModelUri
  {
    get => this.modelUriField;
    set => this.modelUriField = value;
  }

  [XmlAttribute]
  public string XmlSchemaUri
  {
    get => this.xmlSchemaUriField;
    set => this.xmlSchemaUriField = value;
  }

  [XmlAttribute]
  public string Version
  {
    get => this.versionField;
    set => this.versionField = value;
  }

  [XmlAttribute]
  public DateTime PublicationDate
  {
    get => this.publicationDateField;
    set => this.publicationDateField = value;
  }

  [XmlIgnore]
  public bool PublicationDateSpecified
  {
    get => this.publicationDateFieldSpecified;
    set => this.publicationDateFieldSpecified = value;
  }

  [XmlAttribute]
  [DefaultValue(typeof (ushort), "0")]
  public ushort AccessRestrictions
  {
    get => this.accessRestrictionsField;
    set => this.accessRestrictionsField = value;
  }
}
