// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConfigurationLocation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ConfigurationLocation
{
  private string m_filePath;

  [DataMember(IsRequired = true, Order = 0)]
  public string FilePath
  {
    get => this.m_filePath;
    set => this.m_filePath = value;
  }
}
