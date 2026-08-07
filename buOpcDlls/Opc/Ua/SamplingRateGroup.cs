// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SamplingRateGroup
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class SamplingRateGroup
{
  private double m_start;
  private double m_increment;
  private int m_count;

  public SamplingRateGroup() => this.Initialize();

  public SamplingRateGroup(int start, int increment, int count)
  {
    this.m_start = (double) start;
    this.m_increment = (double) increment;
    this.m_count = count;
  }

  private void Initialize()
  {
    this.m_start = 1000.0;
    this.m_increment = 0.0;
    this.m_count = 0;
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, Order = 1)]
  public double Start
  {
    get => this.m_start;
    set => this.m_start = value;
  }

  [DataMember(IsRequired = false, Order = 2)]
  public double Increment
  {
    get => this.m_increment;
    set => this.m_increment = value;
  }

  [DataMember(IsRequired = false, Order = 3)]
  public int Count
  {
    get => this.m_count;
    set => this.m_count = value;
  }
}
