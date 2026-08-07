// Decompiled with JetBrains decompiler
// Type: buComm.ModbusTCP.ModbusCommands
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using buClass;
using buComm.UdpNetworkVars;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buComm.ModbusTCP;

public class ModbusCommands
{
  private IPEndPoint \u0001;
  private CTelegram \u0001;
  public static byte f000037;
  private static string \u0001;
  private static string \u0002;
  public Master ModbusMaster;
  public string IPAddress;

  public ModbusCommands()
  {
    ((NetVars) this).\u0001 = 1;
    ((NetVars) this).\u0002 = 1202;
    ((NetVars) this).\u0003 = 0;
    ((NetVars) this).\u0001 = new List<CDataTypeCollection>();
    ((NetVars) this).\u0001 = "190.201.100.100";
    ((NetVars) this).\u0001 = new ArrayList();
    ((NetVars) this).\u0001 = (ushort) 0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public abstract void m00004F();

  public ModbusCommands()
  {
    ((ModbusModeTypes) this).Port = (ushort) 502;
    ((ModbusModeTypes) this).ReadWriteMode = "";
    ((ModbusModeTypes) this).ModeValue = "";
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (buSystem.strIDScale != "IUTvstjutru784gfsbtNYRJGdrebgre75RFSDVCSD-?YT?_?.<+!%+^&GSDGDSGA5&bdfbdrb" | buSystem.strTest != "AtWR65*-vftyfc74dafqw124fFSTEWFEEVAEARHGFVSDVERGVd89eet98rbFREGRAVRETTBYWFVDetrqVVR" | buSystem.valCheckFactor != 97245796635758.766 | buSystem.valMidPointConstant != -598745789953.89551 | buSystem.a1 != ModbusCommands.\u0001 | buSystem.a2 != ModbusCommands.\u0002)
      throw new RegisterException(nameof (ModbusCommands));
  }

  public void Connect()
  {
    this.ModbusMaster = new Master(this.IPAddress, ((ModbusModeTypes) this).Port);
    this.ModbusMaster.OnResponseData += new Master.ResponseData(this.\u0001);
    this.ModbusMaster.OnException += new Master.ExceptionData(this.\u0001);
  }

  public void Disconnect()
  {
    if (this.ModbusMaster == null)
      return;
    this.ModbusMaster.Dispose();
    this.ModbusMaster = (Master) null;
  }

  private void \u0001([In] ushort obj0, [In] byte obj1, [In] byte obj2, [In] byte[] obj3)
  {
    switch (obj0)
    {
    }
  }

  private void \u0001([In] ushort obj0, [In] byte obj1, [In] byte obj2, [In] byte obj3)
  {
    string str = "Modbus says error: ";
    switch (obj3)
    {
      case 1:
        str += "Illegal function!";
        break;
      case 2:
        str += "Illegal data adress!";
        break;
      case 3:
        str += "Illegal data value!";
        break;
      case 4:
        str += "Slave device failure!";
        break;
      case 5:
        str += "Acknoledge!";
        break;
      case 10:
        str += "Gateway path unavailbale!";
        break;
      case 253:
        str += "Not connected!";
        break;
      case 254:
        str += "Connection is lost!";
        break;
      case byte.MaxValue:
        str += "Slave timed out!";
        break;
    }
    int num = (int) MessageBox.Show($"{$"{str} | ID: {obj0.ToString()} , unit: {obj1.ToString()} , function: {obj2.ToString()} , exception: {obj3.ToString()}"} , Adress : {Master.localAdress.ToString()} , Mode: {((ModbusModeTypes) this).ReadWriteMode}{Master.localAdress.ToString()} , Mode: {((ModbusModeTypes) this).ReadWriteMode} , Value: {((ModbusModeTypes) this).ModeValue}", "Modbus slave exception");
  }

  public void ChangeBytesForWrite(ref byte[] by)
  {
    byte[] numArray = new byte[by.Length];
    if (numArray.Length == 2)
    {
      numArray[0] = by[1];
      numArray[1] = by[0];
    }
    if (numArray.Length == 4)
    {
      numArray[0] = by[3];
      numArray[1] = by[2];
      numArray[2] = by[1];
      numArray[3] = by[0];
    }
    if (numArray.Length == 6)
    {
      numArray[0] = by[5];
      numArray[1] = by[4];
      numArray[2] = by[3];
      numArray[3] = by[2];
      numArray[4] = by[1];
      numArray[5] = by[0];
    }
    if (numArray.Length == 8)
    {
      numArray[0] = by[7];
      numArray[1] = by[6];
      numArray[2] = by[5];
      numArray[3] = by[4];
      numArray[4] = by[3];
      numArray[5] = by[2];
      numArray[6] = by[1];
      numArray[7] = by[0];
    }
    for (int index = 0; index <= numArray.Length - 1; ++index)
      by[index] = numArray[index];
  }

  public void ChangeBytesForRead(ref byte[] by)
  {
    byte[] numArray = new byte[by.Length];
    if (numArray.Length == 2)
    {
      numArray[0] = by[1];
      numArray[1] = by[0];
    }
    if (numArray.Length == 4)
    {
      numArray[0] = by[1];
      numArray[1] = by[0];
      numArray[2] = by[3];
      numArray[3] = by[2];
    }
    if (numArray.Length == 6)
    {
      numArray[0] = by[1];
      numArray[1] = by[0];
      numArray[2] = by[3];
      numArray[3] = by[2];
      numArray[4] = by[5];
      numArray[5] = by[4];
    }
    if (numArray.Length == 8)
    {
      numArray[0] = by[1];
      numArray[1] = by[0];
      numArray[2] = by[3];
      numArray[3] = by[2];
      numArray[4] = by[5];
      numArray[5] = by[4];
      numArray[6] = by[7];
      numArray[7] = by[6];
    }
    for (int index = 0; index <= numArray.Length - 1; ++index)
      by[index] = numArray[index];
  }

  public void ReadHoldInt(ModbusModeTypes Mode, byte Unit, ushort Address, ref int Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadHoldInt);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadHoldingRegister((ushort) Mode, Unit, Address, (ushort) 1, ref numArray);
    if (numArray.Length == 1)
      Value = (int) numArray[0];
    if (numArray.Length == 2)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = (int) numArray[0] + 256 /*0x0100*/ * (int) numArray[1];
      if (Value > 32768 /*0x8000*/)
        Value -= 65536 /*0x010000*/;
    }
    Thread.Sleep(10);
  }

  public void ReadInt(ModbusModeTypes Mode, byte Unit, ushort Address, ref int Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadInt);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadInputRegister((ushort) Mode, Unit, Address, (ushort) 1, ref numArray);
    if (numArray.Length == 1)
      Value = (int) numArray[0];
    if (numArray.Length == 2)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = (int) numArray[0] + 256 /*0x0100*/ * (int) numArray[1];
      if (Value > 32768 /*0x8000*/)
        Value -= 65536 /*0x010000*/;
    }
    Thread.Sleep(10);
  }

  public void ReadDInt(ModbusModeTypes Mode, byte Unit, ushort Address, ref int Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadDInt);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadInputRegister((ushort) Mode, Unit, Address, (ushort) 2, ref numArray);
    if (numArray.Length == 1)
      Value = (int) numArray[0];
    if (numArray.Length == 2)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = (int) numArray[0] + 256 /*0x0100*/ * (int) numArray[1];
      if (Value > 32768 /*0x8000*/)
        Value -= 65536 /*0x010000*/;
    }
    if (numArray.Length == 4)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = BitConverter.ToInt32(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void ReadReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref float Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadInputRegister((ushort) Mode, Unit, Address, (ushort) 2, ref numArray);
    if (numArray.Length == 4)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = BitConverter.ToSingle(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void ReadHoldReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref float Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadHoldReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadHoldingRegister((ushort) Mode, Unit, Address, (ushort) 2, ref numArray);
    if (numArray.Length == 4)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = BitConverter.ToSingle(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void ReadReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadInputRegister((ushort) Mode, Unit, Address, (ushort) 2, ref numArray);
    if (numArray.Length == 4)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = (double) BitConverter.ToSingle(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void ReadHoldReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadHoldReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadHoldingRegister((ushort) Mode, Unit, Address, (ushort) 2, ref numArray);
    if (numArray.Length == 4)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = (double) BitConverter.ToSingle(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void ReadLReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadLReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadInputRegister((ushort) Mode, Unit, Address, (ushort) 4, ref numArray);
    if (numArray.Length == 8)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = BitConverter.ToDouble(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void ReadHoldLReal(ModbusModeTypes Mode, byte Unit, ushort Address, ref double Value)
  {
    byte[] numArray = (byte[]) null;
    ((ModbusModeTypes) this).ReadWriteMode = nameof (ReadHoldLReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.ReadHoldingRegister((ushort) Mode, Unit, Address, (ushort) 4, ref numArray);
    if (numArray.Length == 8)
    {
      this.ChangeBytesForRead(ref numArray);
      Value = BitConverter.ToDouble(numArray, 0);
    }
    Thread.Sleep(10);
  }

  public void WriteCoil(ModbusModeTypes Mode, byte Unit, ushort Address, bool Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteCoil);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    this.ModbusMaster.WriteSingleCoils((ushort) Mode, Unit, Address, Value);
    Thread.Sleep(10);
  }

  public void WriteInt(ModbusModeTypes Mode, byte Unit, ushort Address, int Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteInt);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes((short) Value);
    this.ChangeBytesForWrite(ref bytes);
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, bytes);
    Thread.Sleep(10);
  }

  public void WriteDInt(ModbusModeTypes Mode, byte Unit, ushort Address, int Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteDInt);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes(Value);
    this.ChangeBytesForWrite(ref bytes);
    byte[] values1 = new byte[2]{ bytes[0], bytes[1] };
    byte[] values2 = new byte[2]{ bytes[2], bytes[3] };
    int startAddress = (int) Address + 1;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, values2);
    Thread.Sleep(10);
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress, values1);
    Thread.Sleep(10);
  }

  public void WriteReal(ModbusModeTypes Mode, byte Unit, ushort Address, float Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes(Value);
    this.ChangeBytesForWrite(ref bytes);
    byte[] values1 = new byte[2]{ bytes[0], bytes[1] };
    byte[] values2 = new byte[2]{ bytes[2], bytes[3] };
    int startAddress = (int) Address + 1;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, values2);
    Thread.Sleep(10);
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress, values1);
    Thread.Sleep(10);
  }

  public void WriteReal(ModbusModeTypes Mode, byte Unit, ushort Address, double Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes((float) Value);
    this.ChangeBytesForWrite(ref bytes);
    byte[] values1 = new byte[2]{ bytes[0], bytes[1] };
    byte[] values2 = new byte[2]{ bytes[2], bytes[3] };
    int startAddress = (int) Address + 1;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, values2);
    Thread.Sleep(10);
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress, values1);
    Thread.Sleep(10);
  }

  public void WriteLReal(ModbusModeTypes Mode, byte Unit, ushort Address, double Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteLReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes(Value);
    this.ChangeBytesForWrite(ref bytes);
    byte[] values1 = new byte[2]{ bytes[0], bytes[1] };
    byte[] values2 = new byte[2]{ bytes[2], bytes[3] };
    byte[] values3 = new byte[2]{ bytes[4], bytes[5] };
    byte[] values4 = new byte[2]{ bytes[6], bytes[7] };
    int startAddress1 = (int) Address + 1;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, values4);
    Thread.Sleep(10);
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress1, values3);
    Thread.Sleep(10);
    int startAddress2 = (int) Address + 2;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress2, values2);
    Thread.Sleep(10);
    int startAddress3 = (int) Address + 3;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress3, values1);
    Thread.Sleep(10);
  }

  public void WriteHoldLReal(ModbusModeTypes Mode, byte Unit, ushort Address, double Value)
  {
    ((ModbusModeTypes) this).ReadWriteMode = nameof (WriteHoldLReal);
    ((ModbusModeTypes) this).ModeValue = Value.ToString();
    byte[] bytes = BitConverter.GetBytes(Value);
    this.ChangeBytesForWrite(ref bytes);
    byte[] values1 = new byte[2]{ bytes[0], bytes[1] };
    byte[] values2 = new byte[2]{ bytes[2], bytes[3] };
    byte[] values3 = new byte[2]{ bytes[4], bytes[5] };
    byte[] values4 = new byte[2]{ bytes[6], bytes[7] };
    int startAddress1 = (int) Address + 1;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, Address, values4);
    Thread.Sleep(10);
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress1, values3);
    Thread.Sleep(10);
    int startAddress2 = (int) Address + 2;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress2, values2);
    Thread.Sleep(10);
    int startAddress3 = (int) Address + 3;
    this.ModbusMaster.WriteSingleRegister((ushort) Mode, Unit, (ushort) startAddress3, values1);
    Thread.Sleep(10);
  }
}
