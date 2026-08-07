// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UAMethod
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
public class UAMethod : UAInstance
{
  private UAMethodArgument[] argumentDescriptionField;
  private bool executableField;
  private bool userExecutableField;
  private string methodDeclarationIdField;

  public UAMethod()
  {
    this.executableField = true;
    this.userExecutableField = true;
  }

  [XmlElement("ArgumentDescription")]
  public UAMethodArgument[] ArgumentDescription
  {
    get => this.argumentDescriptionField;
    set => this.argumentDescriptionField = value;
  }

  [XmlAttribute]
  [DefaultValue(true)]
  public bool Executable
  {
    get => this.executableField;
    set => this.executableField = value;
  }

  [XmlAttribute]
  [DefaultValue(true)]
  public bool UserExecutable
  {
    get => this.userExecutableField;
    set => this.userExecutableField = value;
  }

  [XmlAttribute]
  public string MethodDeclarationId
  {
    get => this.methodDeclarationIdField;
    set => this.methodDeclarationIdField = value;
  }
}
