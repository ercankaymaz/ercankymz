// Decompiled with JetBrains decompiler
// Type: buComm.UdpNetworkVars.CDataTypeCollection
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

#nullable disable
namespace buComm.UdpNetworkVars;

public class CDataTypeCollection
{
  public object VarValue;
  public static byte f000010;
  private int \u0001 = 80 /*0x50*/;
  private DataTypes \u0001;

  public abstract void m00002E();

  public DataTypes DataTypes
  {
    get => this.\u0001;
    set => this.\u0001 = value;
  }

  public int FieldLength
  {
    get => this.\u0001;
    set => this.\u0001 = value;
  }

  public object SendValue
  {
    get => ((CTelegram) this).\u0001;
    set => ((CTelegram) this).\u0001 = value;
  }

  public string VariableName
  {
    get => ((CTelegram) this).\u0001;
    set => ((CTelegram) this).\u0001 = value;
  }

  public CDataTypeCollection()
  {
  }

  public CDataTypeCollection(DataTypes dataTypes) => this.\u0001 = dataTypes;

  public CDataTypeCollection(DataTypes dataTypes, int fieldLength)
  {
    this.\u0001 = dataTypes;
    this.\u0001 = fieldLength;
  }

  public CDataTypeCollection(object value, DataTypes dataTypes, int fieldLength)
  {
    this.\u0001 = dataTypes;
    this.\u0001 = fieldLength;
    ((CTelegram) this).\u0001 = value;
  }
}
