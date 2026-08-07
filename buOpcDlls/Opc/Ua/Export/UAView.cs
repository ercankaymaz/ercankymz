// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UAView
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
public class UAView : UAInstance
{
  private bool containsNoLoopsField;
  private byte eventNotifierField;

  public UAView()
  {
    this.containsNoLoopsField = false;
    this.eventNotifierField = (byte) 0;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool ContainsNoLoops
  {
    get => this.containsNoLoopsField;
    set => this.containsNoLoopsField = value;
  }

  [XmlAttribute]
  [DefaultValue(typeof (byte), "0")]
  public byte EventNotifier
  {
    get => this.eventNotifierField;
    set => this.eventNotifierField = value;
  }
}
