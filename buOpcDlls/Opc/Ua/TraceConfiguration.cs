// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TraceConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class TraceConfiguration
{
  private string m_outputFilePath;
  private bool m_deleteOnLoad;
  private int m_traceMasks;

  public TraceConfiguration() => this.Initialize();

  private void Initialize()
  {
    this.m_outputFilePath = (string) null;
    this.m_deleteOnLoad = false;
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, Order = 0)]
  public string OutputFilePath
  {
    get => this.m_outputFilePath;
    set => this.m_outputFilePath = value;
  }

  [DataMember(IsRequired = false, Order = 1)]
  public bool DeleteOnLoad
  {
    get => this.m_deleteOnLoad;
    set => this.m_deleteOnLoad = value;
  }

  [DataMember(IsRequired = false, Order = 2)]
  public int TraceMasks
  {
    get => this.m_traceMasks;
    set => this.m_traceMasks = value;
  }

  public void ApplySettings()
  {
    Utils.SetTraceLog(this.m_outputFilePath, this.m_deleteOnLoad);
    Utils.SetTraceMask(this.m_traceMasks);
    if (this.m_traceMasks == 0)
      Utils.SetTraceOutput(Utils.TraceOutput.Off);
    else
      Utils.SetTraceOutput(Utils.TraceOutput.DebugAndFile);
  }
}
