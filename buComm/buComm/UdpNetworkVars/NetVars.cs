// Decompiled with JetBrains decompiler
// Type: buComm.UdpNetworkVars.NetVars
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0005;
using buComm.ModbusTCP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;

#nullable disable
namespace buComm.UdpNetworkVars;

public class NetVars
{
  public const DataTypes lrealtype = DataTypes.dwordtype | DataTypes.uinttype;
  public const DataTypes stringtype = DataTypes.sinttype | DataTypes.uinttype;
  private int \u0001;
  private int \u0002;
  private int \u0003;
  internal List<CDataTypeCollection> \u0001;
  private string \u0001;
  private ArrayList \u0001;
  private ushort \u0001;
  private UdpClient \u0001;

  public NetVars()
  {
    ((CTelegram) this).Identity = new byte[4]
    {
      (byte) 0,
      (byte) 45,
      (byte) 83,
      (byte) 51
    };
    ((CTelegram) this).ID = 0U;
    ((CTelegram) this).Index = (ushort) 1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public int CobID
  {
    get => this.\u0001;
    set => this.\u0001 = value;
  }

  public int Port
  {
    get => this.\u0002;
    set => this.\u0002 = value;
  }

  public string IPAdress
  {
    get => this.\u0001;
    set => this.\u0001 = value;
  }

  public List<CDataTypeCollection> dataTypeCollection
  {
    get => this.\u0001;
    set
    {
      this.\u0001 = value;
      this.\u0003 = this.dataTypeCollection.Count;
    }
  }

  public CTelegram CTelegramReceive => ((ModbusCommands) this).\u0001;

  public int NumberOfTags
  {
    get => this.\u0003;
    set => this.\u0003 = value;
  }

  public void disconnect()
  {
    if (this.\u0001 == null)
      return;
    this.\u0001.Close();
  }

  public void connect()
  {
    this.\u0001 = new UdpClient(this.\u0002);
    this.\u0001.Client.ReceiveTimeout = 15000;
    ((ModbusCommands) this).\u0001 = new IPEndPoint(IPAddress.Parse(this.\u0001), this.\u0002);
  }

  public ArrayList ReadValues()
  {
    this.\u0003 = this.\u0001.Count;
    DateTime now = DateTime.Now;
    byte[] numArray = new byte[12];
    bool flag1 = false;
    bool flag2 = true;
    int num1 = 0;
    this.\u0001 = new ArrayList();
    if (this.\u0001 == null)
      this.connect();
    while ((int) numArray[8] != this.\u0001 | numArray == null | flag2 | !flag1 | this.\u0001.Count != this.\u0001.Count)
    {
      if (checked (DateTime.Now.Ticks - now.Ticks) > 100000000L)
        throw new Exception("Error receiving UDP-Messages; Check cob-ID, Port and IP-Address");
      numArray = this.\u0001.Receive(ref ((ModbusCommands) this).\u0001);
      int index = 20;
      ((ModbusCommands) this).\u0001 = (CTelegram) new NetVars();
      Buffer.BlockCopy((Array) numArray, 0, (Array) ((ModbusCommands) this).\u0001.Identity, 0, 4);
      uint[] dst1 = new uint[1];
      ushort[] dst2 = new ushort[1];
      byte[] dst3 = new byte[1];
      Buffer.BlockCopy((Array) numArray, 4, (Array) dst1, 0, 4);
      ((ModbusCommands) this).\u0001.ID = dst1[0];
      Buffer.BlockCopy((Array) numArray, 8, (Array) dst2, 0, 2);
      ((ModbusCommands) this).\u0001.Index = dst2[0];
      Buffer.BlockCopy((Array) numArray, 10, (Array) dst2, 0, 2);
      ((ModbusCommands) this).\u0001.SubIndex = dst2[0];
      ushort subIndex = ((ModbusCommands) this).\u0001.SubIndex;
      Buffer.BlockCopy((Array) numArray, 12, (Array) dst2, 0, 2);
      ((ModbusCommands) this).\u0001.Items = dst2[0];
      Buffer.BlockCopy((Array) numArray, 14, (Array) dst2, 0, 2);
      ((ModbusCommands) this).\u0001.Length = dst2[0];
      Buffer.BlockCopy((Array) numArray, 16 /*0x10*/, (Array) dst2, 0, 2);
      ((ModbusCommands) this).\u0001.Counter = dst2[0];
      Buffer.BlockCopy((Array) numArray, 18, (Array) dst3, 0, 1);
      ((ModbusCommands) this).\u0001.Flags = dst3[0];
      Buffer.BlockCopy((Array) numArray, 19, (Array) dst3, 0, 1);
      ((DataTypes) ((ModbusCommands) this).\u0001).Checksum = dst3[0];
      ((DataTypes) ((ModbusCommands) this).\u0001).Data = new byte[checked (numArray.Length - 20)];
      Buffer.BlockCopy((Array) numArray, 20, (Array) ((DataTypes) ((ModbusCommands) this).\u0001).Data, 0, ((DataTypes) ((ModbusCommands) this).\u0001).Data.Length);
      if (((ModbusCommands) this).\u0001.SubIndex == (ushort) 0 & (int) numArray[8] == this.\u0001)
      {
        flag1 = true;
        this.\u0001.Clear();
        num1 = 0;
      }
      if (checked (num1 + 1) != (int) ((ModbusCommands) this).\u0001.SubIndex & num1 != 0 & (int) numArray[8] == this.\u0001)
      {
        flag1 = false;
        this.\u0001.Clear();
      }
      if (this.\u0001 == (int) ((ModbusCommands) this).\u0001.Index)
        num1 = (int) ((ModbusCommands) this).\u0001.SubIndex;
      if (num1 != checked (\u0004.\u0001(this, this.\u0001.Count) + 1) & num1 != 0 & (int) numArray[8] == this.\u0001)
      {
        flag1 = false;
        this.\u0001.Clear();
      }
      if ((int) numArray[8] == this.\u0001 & flag1)
      {
        int num2 = 0;
        while (num2 < (int) ((ModbusCommands) this).\u0001.Items)
        {
          if (this.\u0001.Count <= this.\u0001.Count - 1)
          {
            CDataTypeCollection cdataTypeCollection = this.\u0001[this.\u0001.Count];
            if (cdataTypeCollection.DataTypes == DataTypes.booltype)
            {
              this.\u0001.Add((object) Convert.ToBoolean(numArray[index]));
              checked { ++index; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.bytetype)
            {
              this.\u0001.Add((object) numArray[index]);
              checked { ++index; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.wordtype)
            {
              this.\u0001.Add((object) Convert.ToUInt16((int) numArray[index] | (int) numArray[checked (index + 1)] << 8));
              checked { index += 2; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.dwordtype)
            {
              this.\u0001.Add((object) (uint) ((int) numArray[index] | (int) numArray[checked (index + 1)] << 8 | (int) numArray[checked (index + 2)] << 16 /*0x10*/ | (int) numArray[checked (index + 3)] << 24));
              checked { index += 4; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.sinttype)
            {
              this.\u0001.Add((object) checked ((sbyte) numArray[index]));
              checked { ++index; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.usintType)
            {
              this.\u0001.Add((object) numArray[index]);
              checked { ++index; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.inttype)
            {
              this.\u0001.Add((object) BitConverter.ToInt16(numArray, index));
              checked { index += 2; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.uinttype)
            {
              this.\u0001.Add((object) Convert.ToUInt16((int) numArray[index] | (int) numArray[checked (index + 1)] << 8));
              checked { index += 2; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.udinttype)
            {
              this.\u0001.Add((object) (uint) ((int) numArray[index] | (int) numArray[checked (index + 1)] << 8 | (int) numArray[checked (index + 2)] << 16 /*0x10*/ | (int) numArray[checked (index + 3)] << 24));
              checked { index += 4; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.dinttype)
            {
              this.\u0001.Add((object) BitConverter.ToInt32(numArray, index));
              checked { index += 4; }
            }
            if (cdataTypeCollection.DataTypes == DataTypes.realtype)
            {
              this.\u0001.Add((object) BitConverter.ToSingle(numArray, index));
              checked { index += 4; }
            }
            if (cdataTypeCollection.DataTypes == (DataTypes.dwordtype | DataTypes.uinttype))
            {
              this.\u0001.Add((object) BitConverter.ToDouble(numArray, index));
              checked { index += 8; }
            }
            if (cdataTypeCollection.DataTypes == (DataTypes.sinttype | DataTypes.uinttype))
            {
              string str = Encoding.UTF8.GetString(numArray, index, cdataTypeCollection.FieldLength);
              int length = str.Length;
              int num3 = 0;
              while (num3 < str.Length)
              {
                if (numArray[checked (index + num3)] != (byte) 0)
                {
                  checked { ++num3; }
                }
                else
                {
                  length = num3;
                  break;
                }
              }
              this.\u0001.Add((object) str.Substring(0, length));
              index = checked (index + cdataTypeCollection.FieldLength + 1);
            }
            checked { ++num2; }
          }
          else
            ++num2;
        }
      }
      if (\u0004.\u0001(this, this.\u0001.Count) <= (int) subIndex & flag1 & (int) numArray[8] == this.\u0001)
        flag2 = false;
    }
    return this.\u0001;
  }

  public void SendValues()
  {
    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
    int num1 = checked (\u0004.\u0001(this, this.\u0001.Count) + 1);
    int num2 = 0;
    int num3 = 0;
    this.\u0003 = this.\u0001.Count;
    CTelegram ctelegram = (CTelegram) new NetVars();
    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(this.\u0001), this.\u0002);
    socket.EnableBroadcast = true;
    int num4 = 0;
    while (num4 < num1)
    {
      this.\u0001 = this.\u0001 < ushort.MaxValue ? checked ((ushort) ((uint) this.\u0001 + 1U)) : (ushort) 0;
      checked { ++num3; }
      int num5 = 1;
      while (\u0004.\u0001(this, num3) == num2 & num3 != this.\u0001.Count)
      {
        checked { ++num5; }
        checked { ++num3; }
      }
      if (\u0004.\u0001(this, num3) > num2)
      {
        checked { --num3; }
        checked { --num5; }
      }
      byte[] array = new byte[20];
      uint[] src1 = new uint[1];
      int[] src2 = new int[1];
      ushort[] src3 = new ushort[1];
      short[] src4 = new short[1];
      sbyte[] src5 = new sbyte[1];
      float[] src6 = new float[1];
      double[] src7 = new double[1];
      Buffer.BlockCopy((Array) ctelegram.Identity, 0, (Array) array, 0, 4);
      src1[0] = ctelegram.ID;
      Buffer.BlockCopy((Array) src1, 0, (Array) array, 4, 4);
      ctelegram.Index = checked ((ushort) this.\u0001);
      src3[0] = ctelegram.Index;
      Buffer.BlockCopy((Array) src3, 0, (Array) array, 8, 2);
      ctelegram.SubIndex = checked ((ushort) num2);
      src3[0] = ctelegram.SubIndex;
      Buffer.BlockCopy((Array) src3, 0, (Array) array, 10, 2);
      ctelegram.Items = checked ((ushort) num5);
      src3[0] = ctelegram.Items;
      Buffer.BlockCopy((Array) src3, 0, (Array) array, 12, 2);
      ctelegram.Counter = this.\u0001;
      src3[0] = ctelegram.Counter;
      Buffer.BlockCopy((Array) src3, 0, (Array) array, 16 /*0x10*/, 2);
      array[18] = ctelegram.Flags;
      array[19] = ((DataTypes) ctelegram).Checksum;
      int num6 = 0;
      int num7 = 0;
      while (num7 < num5)
      {
        switch (this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].DataTypes)
        {
          case DataTypes.booltype:
            Array.Resize<byte>(ref array, checked (array.Length + 1));
            array[checked (20 + num6)] = Convert.ToByte(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            checked { ++num6; }
            break;
          case DataTypes.bytetype:
            Array.Resize<byte>(ref array, checked (array.Length + 1));
            array[checked (20 + num6)] = Convert.ToByte(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            checked { ++num6; }
            break;
          case DataTypes.wordtype:
            Array.Resize<byte>(ref array, checked (array.Length + 2));
            src3[0] = Convert.ToUInt16(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src3, 0, (Array) array, checked (20 + num6), 2);
            checked { num6 += 2; }
            break;
          case DataTypes.dwordtype:
            Array.Resize<byte>(ref array, checked (array.Length + 4));
            src1[0] = Convert.ToUInt32(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src1, 0, (Array) array, checked (20 + num6), 4);
            checked { num6 += 4; }
            break;
          case DataTypes.sinttype:
            Array.Resize<byte>(ref array, checked (array.Length + 1));
            src5[0] = Convert.ToSByte(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src5, 0, (Array) array, checked (20 + num6), 1);
            checked { ++num6; }
            break;
          case DataTypes.usintType:
            Array.Resize<byte>(ref array, checked (array.Length + 1));
            array[checked (20 + num6)] = Convert.ToByte(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            checked { ++num6; }
            break;
          case DataTypes.inttype:
            Array.Resize<byte>(ref array, checked (array.Length + 2));
            src4[0] = Convert.ToInt16(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src4, 0, (Array) array, checked (20 + num6), 2);
            checked { num6 += 2; }
            break;
          case DataTypes.uinttype:
            Array.Resize<byte>(ref array, checked (array.Length + 2));
            src3[0] = Convert.ToUInt16(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src3, 0, (Array) array, checked (20 + num6), 2);
            checked { num6 += 2; }
            break;
          case DataTypes.dinttype:
            Array.Resize<byte>(ref array, checked (array.Length + 4));
            src2[0] = Convert.ToInt32(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src2, 0, (Array) array, checked (20 + num6), 4);
            checked { num6 += 4; }
            break;
          case DataTypes.udinttype:
            Array.Resize<byte>(ref array, checked (array.Length + 4));
            src1[0] = Convert.ToUInt32(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src1, 0, (Array) array, checked (20 + num6), 4);
            checked { num6 += 4; }
            break;
          case DataTypes.realtype:
            Array.Resize<byte>(ref array, checked (array.Length + 4));
            src6[0] = (float) Convert.ToDouble(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src6, 0, (Array) array, checked (20 + num6), 4);
            checked { num6 += 4; }
            break;
          case DataTypes.dwordtype | DataTypes.uinttype:
            Array.Resize<byte>(ref array, checked (array.Length + 8));
            src7[0] = Convert.ToDouble(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue);
            Buffer.BlockCopy((Array) src7, 0, (Array) array, checked (20 + num6), 8);
            checked { num6 += 8; }
            break;
          case DataTypes.sinttype | DataTypes.uinttype:
            char[] chArray = new char[checked (this.\u0001[num7 + \u0004.\u0001(this, num3)].FieldLength + 1)];
            byte[] src8 = new byte[checked (this.\u0001[num7 + \u0004.\u0001(this, num3)].FieldLength + 1)];
            char[] charArray = Convert.ToString(this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].SendValue).ToCharArray();
            int length = charArray.Length;
            if (charArray.Length <= this.\u0001[checked (num7 + \u0004.\u0001(this, num3))].FieldLength)
              Array.Resize<char>(ref charArray, checked (this.\u0001[num7 + \u0004.\u0001(this, num3)].FieldLength + 1));
            charArray[length] = char.MinValue;
            Array.Resize<byte>(ref array, checked (array.Length + charArray.Length));
            int index = 0;
            while (index < charArray.Length)
            {
              src8[index] = checked ((byte) charArray[index]);
              checked { ++index; }
            }
            Buffer.BlockCopy((Array) src8, 0, (Array) array, checked (20 + num6), src8.Length);
            checked { num6 += charArray.Length; }
            break;
        }
        checked { ++num7; }
      }
      ctelegram.Length = checked ((ushort) array.Length);
      src3[0] = ctelegram.Length;
      Buffer.BlockCopy((Array) src3, 0, (Array) array, 14, 2);
      socket.SendTo(array, (EndPoint) remoteEP);
      checked { ++num2; }
      checked { ++num4; }
    }
  }

  public void CreateGVLFile(string fileName)
  {
    XmlDocument xmlDocument = new XmlDocument();
    XmlNode element1 = (XmlNode) xmlDocument.CreateElement("GVL");
    xmlDocument.AppendChild(element1);
    XmlNode element2 = (XmlNode) xmlDocument.CreateElement("Declarations");
    string str = "VAR_GLOBAL";
    int index = 0;
    while (index < this.\u0001.Count)
    {
      str = this.\u0001[index].VariableName == null ? $"{str}\n\tvariable{index.ToString()}" : $"{str}\n\t{this.\u0001[index].VariableName}";
      switch (this.\u0001[index].DataTypes)
      {
        case DataTypes.booltype:
          str += ": BOOL;";
          break;
        case DataTypes.bytetype:
          str += ": BYTE;";
          break;
        case DataTypes.wordtype:
          str += ": WORD;";
          break;
        case DataTypes.dwordtype:
          str += ": DWORD;";
          break;
        case DataTypes.sinttype:
          str += ": SINT;";
          break;
        case DataTypes.usintType:
          str += ": USINT;";
          break;
        case DataTypes.inttype:
          str += ": INT;";
          break;
        case DataTypes.uinttype:
          str += ": UINT;";
          break;
        case DataTypes.dinttype:
          str += ": DINT;";
          break;
        case DataTypes.udinttype:
          str += ": UDINT;";
          break;
        case DataTypes.realtype:
          str += ": REAL;";
          break;
        case DataTypes.dwordtype | DataTypes.uinttype:
          str += ": LREAL;";
          break;
        case DataTypes.sinttype | DataTypes.uinttype:
          str = $"{str}: STRING({this.\u0001[index].FieldLength.ToString()});";
          break;
      }
      checked { ++index; }
    }
    string data = str + "\nEND_VAR";
    XmlNode cdataSection = (XmlNode) xmlDocument.CreateCDataSection(data);
    element2.AppendChild(cdataSection);
    element1.AppendChild(element2);
    XmlNode element3 = (XmlNode) xmlDocument.CreateElement("NetvarSettings");
    XmlAttribute attribute = xmlDocument.CreateAttribute("Protocol");
    attribute.Value = "UDP";
    element3.Attributes.Append(attribute);
    XmlNode element4 = (XmlNode) xmlDocument.CreateElement("ListIdentifier");
    element4.InnerText = this.\u0001.ToString();
    element3.AppendChild(element4);
    XmlNode element5 = (XmlNode) xmlDocument.CreateElement("Pack");
    element5.InnerText = "TRUE";
    element3.AppendChild(element5);
    XmlNode element6 = (XmlNode) xmlDocument.CreateElement("Checksum");
    element6.InnerText = "FALSE";
    element3.AppendChild(element6);
    XmlNode element7 = (XmlNode) xmlDocument.CreateElement("Acknowledge");
    element7.InnerText = "FALSE";
    element3.AppendChild(element7);
    XmlNode element8 = (XmlNode) xmlDocument.CreateElement("CyclicTransmission");
    element8.InnerText = "TRUE";
    element3.AppendChild(element8);
    XmlNode element9 = (XmlNode) xmlDocument.CreateElement("TransmissionOnChange");
    element9.InnerText = "FALSE";
    element3.AppendChild(element9);
    XmlNode element10 = (XmlNode) xmlDocument.CreateElement("TransmissionOnEvent");
    element10.InnerText = "FALSE";
    element3.AppendChild(element10);
    XmlNode element11 = (XmlNode) xmlDocument.CreateElement("Interval");
    element11.InnerText = "T#50ms";
    element3.AppendChild(element11);
    XmlNode element12 = (XmlNode) xmlDocument.CreateElement("MinGap");
    element12.InnerText = "T#20ms";
    element3.AppendChild(element12);
    element1.AppendChild(element3);
    xmlDocument.Save(fileName);
  }

  public static DataTypes ConvertIntToDataTypes(int dataTypes)
  {
    DataTypes dataTypes1;
    switch (dataTypes)
    {
      case 1:
        dataTypes1 = DataTypes.booltype;
        break;
      case 2:
        dataTypes1 = DataTypes.bytetype;
        break;
      case 3:
        dataTypes1 = DataTypes.wordtype;
        break;
      case 4:
        dataTypes1 = DataTypes.dwordtype;
        break;
      case 5:
        dataTypes1 = DataTypes.sinttype;
        break;
      case 6:
        dataTypes1 = DataTypes.usintType;
        break;
      case 7:
        dataTypes1 = DataTypes.inttype;
        break;
      case 8:
        dataTypes1 = DataTypes.uinttype;
        break;
      case 9:
        dataTypes1 = DataTypes.dinttype;
        break;
      case 10:
        dataTypes1 = DataTypes.udinttype;
        break;
      case 11:
        dataTypes1 = DataTypes.realtype;
        break;
      case 12:
        dataTypes1 = DataTypes.dwordtype | DataTypes.uinttype;
        break;
      case 13:
        dataTypes1 = DataTypes.sinttype | DataTypes.uinttype;
        break;
      default:
        dataTypes1 = DataTypes.booltype;
        break;
    }
    return dataTypes1;
  }
}
