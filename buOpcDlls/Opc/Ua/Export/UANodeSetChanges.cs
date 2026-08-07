// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UANodeSetChanges
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

[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[XmlRoot(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable = false)]
[ComVisible(true)]
[Serializable]
public class UANodeSetChanges
{
  private string[] namespaceUrisField;
  private string[] serverUrisField;
  private NodeIdAlias[] aliasesField;
  private XmlElement[] extensionsField;
  private UANode[] nodesToAddField;
  private ReferenceChange[] referencesToAddField;
  private NodeToDelete[] nodesToDeleteField;
  private ReferenceChange[] referencesToDeleteField;
  private DateTime lastModifiedField;
  private bool lastModifiedFieldSpecified;
  private string transactionIdField;
  private bool acceptAllOrNothingField;

  public UANodeSetChanges() => this.acceptAllOrNothingField = false;

  [XmlArrayItem("Uri", IsNullable = false)]
  public string[] NamespaceUris
  {
    get => this.namespaceUrisField;
    set => this.namespaceUrisField = value;
  }

  [XmlArrayItem("Uri", IsNullable = false)]
  public string[] ServerUris
  {
    get => this.serverUrisField;
    set => this.serverUrisField = value;
  }

  [XmlArrayItem("Alias", IsNullable = false)]
  public NodeIdAlias[] Aliases
  {
    get => this.aliasesField;
    set => this.aliasesField = value;
  }

  [XmlArrayItem("Extension", IsNullable = false)]
  public XmlElement[] Extensions
  {
    get => this.extensionsField;
    set => this.extensionsField = value;
  }

  [XmlArrayItem(typeof (UADataType), IsNullable = false)]
  [XmlArrayItem(typeof (UAMethod), IsNullable = false)]
  [XmlArrayItem(typeof (UAObject), IsNullable = false)]
  [XmlArrayItem(typeof (UAObjectType), IsNullable = false)]
  [XmlArrayItem(typeof (UAReferenceType), IsNullable = false)]
  [XmlArrayItem(typeof (UAVariable), IsNullable = false)]
  [XmlArrayItem(typeof (UAVariableType), IsNullable = false)]
  [XmlArrayItem(typeof (UAView), IsNullable = false)]
  public UANode[] NodesToAdd
  {
    get => this.nodesToAddField;
    set => this.nodesToAddField = value;
  }

  [XmlArrayItem("Reference", IsNullable = false)]
  public ReferenceChange[] ReferencesToAdd
  {
    get => this.referencesToAddField;
    set => this.referencesToAddField = value;
  }

  [XmlArrayItem("Node", IsNullable = false)]
  public NodeToDelete[] NodesToDelete
  {
    get => this.nodesToDeleteField;
    set => this.nodesToDeleteField = value;
  }

  [XmlArrayItem("Reference", IsNullable = false)]
  public ReferenceChange[] ReferencesToDelete
  {
    get => this.referencesToDeleteField;
    set => this.referencesToDeleteField = value;
  }

  [XmlAttribute]
  public DateTime LastModified
  {
    get => this.lastModifiedField;
    set => this.lastModifiedField = value;
  }

  [XmlIgnore]
  public bool LastModifiedSpecified
  {
    get => this.lastModifiedFieldSpecified;
    set => this.lastModifiedFieldSpecified = value;
  }

  [XmlAttribute]
  public string TransactionId
  {
    get => this.transactionIdField;
    set => this.transactionIdField = value;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool AcceptAllOrNothing
  {
    get => this.acceptAllOrNothingField;
    set => this.acceptAllOrNothingField = value;
  }
}
