// Decompiled with JetBrains decompiler
// Type: buComm.UdpNetworkVars.CTelegram
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

#nullable disable
namespace buComm.UdpNetworkVars;

public class CTelegram
{
  private object \u0001;
  private string \u0001;
  public byte[] Identity;
  public uint ID;
  public ushort Index;
  public ushort SubIndex;
  public ushort Items;
  public ushort Length;
  public ushort Counter;
  public byte Flags;

  public CTelegram(object value, DataTypes dataTypes)
  {
    ((CDataTypeCollection) this).\u0001 = 80 /*0x50*/;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((CDataTypeCollection) this).\u0001 = dataTypes;
    this.\u0001 = value;
  }
}
