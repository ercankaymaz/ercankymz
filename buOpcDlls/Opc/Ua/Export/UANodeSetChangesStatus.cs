// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UANodeSetChangesStatus
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
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[XmlRoot(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable = false)]
[ComVisible(true)]
[Serializable]
public class UANodeSetChangesStatus
{
  private NodeSetStatus[] nodesToAddField;
  private NodeSetStatus[] referencesToAddField;
  private NodeSetStatus[] nodesToDeleteField;
  private NodeSetStatus[] referencesToDeleteField;
  private DateTime lastModifiedField;
  private bool lastModifiedFieldSpecified;
  private string transactionIdField;

  [XmlArrayItem("Status", IsNullable = false)]
  public NodeSetStatus[] NodesToAdd
  {
    get => this.nodesToAddField;
    set => this.nodesToAddField = value;
  }

  [XmlArrayItem("Status", IsNullable = false)]
  public NodeSetStatus[] ReferencesToAdd
  {
    get => this.referencesToAddField;
    set => this.referencesToAddField = value;
  }

  [XmlArrayItem("Status", IsNullable = false)]
  public NodeSetStatus[] NodesToDelete
  {
    get => this.nodesToDeleteField;
    set => this.nodesToDeleteField = value;
  }

  [XmlArrayItem("Status", IsNullable = false)]
  public NodeSetStatus[] ReferencesToDelete
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
}
