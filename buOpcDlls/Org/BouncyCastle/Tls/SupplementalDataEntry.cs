// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SupplementalDataEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class SupplementalDataEntry
{
  private readonly int m_dataType;
  private readonly byte[] m_data;

  public SupplementalDataEntry(int dataType, byte[] data)
  {
    this.m_dataType = dataType;
    this.m_data = data;
  }

  public int DataType => this.m_dataType;

  public byte[] Data => this.m_data;
}
