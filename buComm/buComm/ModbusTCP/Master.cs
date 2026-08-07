// Decompiled with JetBrains decompiler
// Type: buComm.ModbusTCP.Master
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0005;
using buComm.FTP;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace buComm.ModbusTCP;

public class Master
{
  public const ModbusModeTypes WriteSingleCoil = ModbusModeTypes.ReadCoils | ModbusModeTypes.ReadInputRegister;
  public const ModbusModeTypes WriteMultipleCoils = ModbusModeTypes.ReadDiscreteInputs | ModbusModeTypes.ReadInputRegister;
  public const ModbusModeTypes WriteSingleRegister = ModbusModeTypes.ReadHoldingRegister | ModbusModeTypes.ReadInputRegister;
  public const ModbusModeTypes WriteMultipleRegister = (ModbusModeTypes) 8;
  public const byte excIllegalFunction = 1;
  public const byte excIllegalDataAdr = 2;
  public const byte excIllegalDataVal = 3;
  public const byte excSlaveDeviceFailure = 4;
  public const byte excAck = 5;
  public const byte excSlaveIsBusy = 6;
  public const byte excGatePathUnavailable = 10;
  public const byte excExceptionNotConnected = 253;
  public const byte excExceptionConnectionLost = 254;
  public const byte excExceptionTimeout = 255 /*0xFF*/;
  private static ushort \u0001;
  private static ushort \u0002;
  private static bool \u0001;
  public static ushort localAdress;
  internal Socket \u0001;
  internal byte[] \u0001;

  public void WriteByte(ModbusModeTypes Mode, byte Unit, ushort Address, byte Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteByte);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes((short) Value);
    ((ModbusCommands) this).ChangeBytesForWrite(ref bytes);
    ((ModbusCommands) this).ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, bytes);
    Thread.Sleep(10);
  }

  static Master()
  {
    ModbusCommands.\u0001 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
    ModbusCommands.\u0002 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  }

  public event Master.ResponseData OnResponseData;

  public event Master.ExceptionData OnException;

  public ushort timeout
  {
    get => Master.\u0001;
    set => Master.\u0001 = value;
  }

  public ushort refresh
  {
    get => Master.\u0002;
    set => Master.\u0002 = value;
  }

  public bool connected => Master.\u0001;

  public Master()
  {
    ((FTPConnectMode) this).\u0002 = new byte[2048 /*0x0800*/];
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public Master(string ip, ushort port)
  {
    ((FTPConnectMode) this).\u0002 = new byte[2048 /*0x0800*/];
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.connect(ip, port);
  }

  public void connect(string ip, ushort port)
  {
    try
    {
      if (!IPAddress.TryParse(ip, out IPAddress _))
        ip = Dns.GetHostEntry(ip).AddressList[0].ToString();
      this.\u0001 = new Socket(IPAddress.Parse(ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      this.\u0001.Connect((EndPoint) new IPEndPoint(IPAddress.Parse(ip), (int) port));
      this.\u0001.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (int) Master.\u0001);
      this.\u0001.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int) Master.\u0001);
      this.\u0001.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
      ((FTPConnectMode) this).\u0002 = new Socket(IPAddress.Parse(ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      ((FTPConnectMode) this).\u0002.Connect((EndPoint) new IPEndPoint(IPAddress.Parse(ip), (int) port));
      ((FTPConnectMode) this).\u0002.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (int) Master.\u0001);
      ((FTPConnectMode) this).\u0002.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int) Master.\u0001);
      ((FTPConnectMode) this).\u0002.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
      Master.\u0001 = true;
    }
    catch (IOException ex)
    {
      Master.\u0001 = false;
      throw ex;
    }
  }

  public void disconnect() => this.Dispose();

  ~Master() => this.Dispose();

  public void Dispose()
  {
    if (this.\u0001 != null)
    {
      if (this.\u0001.Connected)
      {
        try
        {
          this.\u0001.Shutdown(SocketShutdown.Both);
        }
        catch
        {
        }
        this.\u0001.Close();
      }
      this.\u0001 = (Socket) null;
    }
    if (((FTPConnectMode) this).\u0002 == null)
      return;
    if (((FTPConnectMode) this).\u0002.Connected)
    {
      try
      {
        ((FTPConnectMode) this).\u0002.Shutdown(SocketShutdown.Both);
      }
      catch
      {
      }
      ((FTPConnectMode) this).\u0002.Close();
    }
    ((FTPConnectMode) this).\u0002 = (Socket) null;
  }

  public void ReadCoils(ushort id, byte unit, ushort startAddress, ushort numInputs)
  {
    Master.localAdress = startAddress;
    \u0004.\u0001(this, \u0004.\u0001(startAddress, id, numInputs, this, (byte) 1, unit), id);
  }

  public void ReadCoils(
    ushort id,
    byte unit,
    ushort startAddress,
    ushort numInputs,
    ref byte[] values)
  {
    Master.localAdress = startAddress;
    values = \u0004.\u0001(\u0004.\u0001(startAddress, id, numInputs, this, (byte) 1, unit), id, this);
  }

  public void ReadDiscreteInputs(ushort id, byte unit, ushort startAddress, ushort numInputs)
  {
    \u0004.\u0001(this, \u0004.\u0001(startAddress, id, numInputs, this, (byte) 2, unit), id);
  }

  public void ReadDiscreteInputs(
    ushort id,
    byte unit,
    ushort startAddress,
    ushort numInputs,
    ref byte[] values)
  {
    Master.localAdress = startAddress;
    values = \u0004.\u0001(\u0004.\u0001(startAddress, id, numInputs, this, (byte) 2, unit), id, this);
  }

  public void ReadHoldingRegister(ushort id, byte unit, ushort startAddress, ushort numInputs)
  {
    Master.localAdress = startAddress;
    \u0004.\u0001(this, \u0004.\u0001(startAddress, id, numInputs, this, (byte) 3, unit), id);
  }

  public void ReadHoldingRegister(
    ushort id,
    byte unit,
    ushort startAddress,
    ushort numInputs,
    ref byte[] values)
  {
    Master.localAdress = startAddress;
    values = \u0004.\u0001(\u0004.\u0001(startAddress, id, numInputs, this, (byte) 3, unit), id, this);
  }

  public void ReadInputRegister(ushort id, byte unit, ushort startAddress, ushort numInputs)
  {
    Master.localAdress = startAddress;
    \u0004.\u0001(this, \u0004.\u0001(startAddress, id, numInputs, this, (byte) 4, unit), id);
  }

  public void ReadInputRegister(
    ushort id,
    byte unit,
    ushort startAddress,
    ushort numInputs,
    ref byte[] values)
  {
    Master.localAdress = startAddress;
    values = \u0004.\u0001(\u0004.\u0001(startAddress, id, numInputs, this, (byte) 4, unit), id, this);
  }

  public void WriteSingleCoils(ushort id, byte unit, ushort startAddress, bool OnOff)
  {
    Master.localAdress = startAddress;
    byte[] numArray = \u0004.\u0001(this, id, unit, startAddress, (ushort) 1, (ushort) 1, (byte) 5);
    numArray[10] = !OnOff ? (byte) 0 : byte.MaxValue;
    \u0004.\u0001(this, numArray, id);
  }

  public void WriteSingleCoils(
    ushort id,
    byte unit,
    ushort startAddress,
    bool OnOff,
    ref byte[] result)
  {
    Master.localAdress = startAddress;
    byte[] numArray = \u0004.\u0001(this, id, unit, startAddress, (ushort) 1, (ushort) 1, (byte) 5);
    numArray[10] = !OnOff ? (byte) 0 : byte.MaxValue;
    result = \u0004.\u0001(numArray, id, this);
  }

  public void WriteMultipleCoils(
    ushort id,
    byte unit,
    ushort startAddress,
    ushort numBits,
    byte[] values)
  {
    Master.localAdress = startAddress;
    byte length = Convert.ToByte(values.Length);
    byte[] destinationArray = \u0004.\u0001(this, id, unit, startAddress, numBits, (ushort) (byte) ((uint) length + 2U), (byte) 15);
    Array.Copy((Array) values, 0, (Array) destinationArray, 13, (int) length);
    \u0004.\u0001(this, destinationArray, id);
  }

  public void WriteMultipleCoils(
    ushort id,
    byte unit,
    ushort startAddress,
    ushort numBits,
    byte[] values,
    ref byte[] result)
  {
    Master.localAdress = startAddress;
    byte length = Convert.ToByte(values.Length);
    byte[] destinationArray = \u0004.\u0001(this, id, unit, startAddress, numBits, (ushort) (byte) ((uint) length + 2U), (byte) 15);
    Array.Copy((Array) values, 0, (Array) destinationArray, 13, (int) length);
    result = \u0004.\u0001(destinationArray, id, this);
  }

  public void WriteSingleRegister(ushort id, byte unit, ushort startAddress, byte[] values)
  {
    Master.localAdress = startAddress;
    byte[] numArray = \u0004.\u0001(this, id, unit, startAddress, (ushort) 1, (ushort) 1, (byte) 6);
    numArray[10] = values[0];
    numArray[11] = values[1];
    \u0004.\u0001(this, numArray, id);
  }

  public void WriteSingleRegister(
    ushort id,
    byte unit,
    ushort startAddress,
    byte[] values,
    ref byte[] result)
  {
    Master.localAdress = startAddress;
    byte[] numArray = \u0004.\u0001(this, id, unit, startAddress, (ushort) 1, (ushort) 1, (byte) 6);
    numArray[10] = values[0];
    numArray[11] = values[1];
    result = \u0004.\u0001(numArray, id, this);
  }

  public void WriteMultipleRegister(ushort id, byte unit, ushort startAddress, byte[] values)
  {
    Master.localAdress = startAddress;
    ushort uint16 = Convert.ToUInt16(values.Length);
    if ((int) uint16 % 2 > 0)
      ++uint16;
    byte[] destinationArray = \u0004.\u0001(this, id, unit, startAddress, Convert.ToUInt16((int) uint16 / 2), Convert.ToUInt16((int) uint16 + 2), (byte) 16 /*0x10*/);
    Array.Copy((Array) values, 0, (Array) destinationArray, 13, values.Length);
    \u0004.\u0001(this, destinationArray, id);
  }

  public void WriteMultipleRegister(
    ushort id,
    byte unit,
    ushort startAddress,
    byte[] values,
    ref byte[] result)
  {
    Master.localAdress = startAddress;
    ushort uint16 = Convert.ToUInt16(values.Length);
    if ((int) uint16 % 2 > 0)
      ++uint16;
    byte[] destinationArray = \u0004.\u0001(this, id, unit, startAddress, Convert.ToUInt16((int) uint16 / 2), Convert.ToUInt16((int) uint16 + 2), (byte) 16 /*0x10*/);
    Array.Copy((Array) values, 0, (Array) destinationArray, 13, values.Length);
    result = \u0004.\u0001(destinationArray, id, this);
  }

  public void ReadWriteMultipleRegister(
    ushort id,
    byte unit,
    ushort startReadAddress,
    ushort numInputs,
    ushort startWriteAddress,
    byte[] values)
  {
    Master.localAdress = startReadAddress;
    ushort uint16 = Convert.ToUInt16(values.Length);
    if ((int) uint16 % 2 > 0)
      ++uint16;
    byte[] destinationArray = \u0004.\u0001(this, id, unit, startReadAddress, numInputs, startWriteAddress, Convert.ToUInt16((int) uint16 / 2));
    Array.Copy((Array) values, 0, (Array) destinationArray, 17, values.Length);
    \u0004.\u0001(this, destinationArray, id);
  }

  public void ReadWriteMultipleRegister(
    ushort id,
    byte unit,
    ushort startReadAddress,
    ushort numInputs,
    ushort startWriteAddress,
    byte[] values,
    ref byte[] result)
  {
    Master.localAdress = startReadAddress;
    ushort uint16 = Convert.ToUInt16(values.Length);
    if ((int) uint16 % 2 > 0)
      ++uint16;
    byte[] destinationArray = \u0004.\u0001(this, id, unit, startReadAddress, numInputs, startWriteAddress, Convert.ToUInt16((int) uint16 / 2));
    Array.Copy((Array) values, 0, (Array) destinationArray, 17, values.Length);
    result = \u0004.\u0001(destinationArray, id, this);
  }

  internal void \u0001([In] IAsyncResult obj0)
  {
    if (obj0.IsCompleted)
      return;
    \u0004.\u0001(this, ushort.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 100);
  }

  public delegate void ResponseData(ushort id, byte unit, byte function, byte[] data);

  public delegate void ExceptionData(ushort id, byte unit, byte function, byte exception);
}
