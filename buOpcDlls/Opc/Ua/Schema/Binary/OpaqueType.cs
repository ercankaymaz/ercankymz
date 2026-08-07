// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Schema.Binary.OpaqueType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua.Schema.Binary;

[XmlInclude(typeof (EnumeratedType))]
[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class OpaqueType : TypeDescription
{
  private int lengthInBitsField;
  private bool lengthInBitsFieldSpecified;
  private bool byteOrderSignificantField;

  public OpaqueType() => this.byteOrderSignificantField = false;

  [XmlAttribute]
  public int LengthInBits
  {
    get => this.lengthInBitsField;
    set => this.lengthInBitsField = value;
  }

  [XmlIgnore]
  public bool LengthInBitsSpecified
  {
    get => this.lengthInBitsFieldSpecified;
    set => this.lengthInBitsFieldSpecified = value;
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool ByteOrderSignificant
  {
    get => this.byteOrderSignificantField;
    set => this.byteOrderSignificantField = value;
  }
}
