// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using buClass;
using buComm.FTP;
using buComm.ModbusTCP;
using buComm.UdpNetworkVars;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace \u0005;

internal class \u0004
{
  public \u0004([In] byte[] obj0) => \u0005.\u0004.\u0001(obj0, (\u0004.\u0003.\u0004) this);

  public \u0004()
  {
  }

  static \u0004()
  {
    \u0004.\u0003.\u0005.\u0001 = new int[3]{ 3, 3, 11 };
    \u0004.\u0003.\u0005.\u0002 = new int[3]{ 2, 3, 7 };
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0003 = new int[19]
    {
      16 /*0x10*/,
      17,
      18,
      0,
      8,
      7,
      9,
      6,
      10,
      5,
      11,
      4,
      12,
      3,
      13,
      2,
      14,
      1,
      15
    };
  }

  static \u0004()
  {
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0001 = new int[19]
    {
      16 /*0x10*/,
      17,
      18,
      0,
      8,
      7,
      9,
      6,
      10,
      5,
      11,
      4,
      12,
      3,
      13,
      2,
      14,
      1,
      15
    };
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0001 = new byte[16 /*0x10*/]
    {
      (byte) 0,
      (byte) 8,
      (byte) 4,
      (byte) 12,
      (byte) 2,
      (byte) 10,
      (byte) 6,
      (byte) 14,
      (byte) 1,
      (byte) 9,
      (byte) 5,
      (byte) 13,
      (byte) 3,
      (byte) 11,
      (byte) 7,
      (byte) 15
    };
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0001 = new short[286];
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0002 = new byte[286];
    int index1;
    // ISSUE: reference to a compiler-generated field
    for (index1 = 0; index1 < 144 /*0x90*/; \u0004.\u0004.\u0002[index1++] = (byte) 8)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0004.\u0001[index1] = \u0005.\u0004.\u0001(48 /*0x30*/ + index1 << 8);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 256 /*0x0100*/; \u0004.\u0004.\u0002[index1++] = (byte) 9)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0004.\u0001[index1] = \u0005.\u0004.\u0001(256 /*0x0100*/ + index1 << 7);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 280; \u0004.\u0004.\u0002[index1++] = (byte) 7)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0004.\u0001[index1] = \u0005.\u0004.\u0001(index1 - 256 /*0x0100*/ << 9);
    }
    // ISSUE: reference to a compiler-generated field
    for (; index1 < 286; \u0004.\u0004.\u0002[index1++] = (byte) 8)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0004.\u0001[index1] = \u0005.\u0004.\u0001(index1 - 88 << 8);
    }
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0002 = new short[30];
    // ISSUE: reference to a compiler-generated field
    \u0004.\u0004.\u0003 = new byte[30];
    for (int index2 = 0; index2 < 30; ++index2)
    {
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0004.\u0002[index2] = \u0005.\u0004.\u0001(index2 << 11);
      // ISSUE: reference to a compiler-generated field
      \u0004.\u0004.\u0003[index2] = (byte) 5;
    }
  }

  public \u0004([In] byte[] obj0)
    : this(obj0, false)
  {
  }

  static void \u0001([In] int obj0, [In] FTPControlSocket obj1)
  {
    // ISSUE: reference to a compiler-generated field
    ((\u0004.\u0001) obj1).\u0001 = obj0;
    if (((MemberRefsProxy) obj1).\u0001 == null)
      throw new SystemException("Failed to set timeout - no control socket");
    // ISSUE: reference to a compiler-generated field
    \u0005.\u0004.\u0001(obj1, ((MemberRefsProxy) obj1).\u0001, ((\u0004.\u0001) obj1).\u0001);
  }

  static byte[] \u0001(
    [In] Master obj0,
    [In] ushort obj1,
    [In] byte obj2,
    [In] ushort obj3,
    [In] ushort obj4,
    [In] ushort obj5,
    [In] ushort obj6)
  {
    byte[] numArray = new byte[(int) obj6 * 2 + 17];
    byte[] bytes1 = BitConverter.GetBytes((short) obj1);
    numArray[0] = bytes1[1];
    numArray[1] = bytes1[0];
    byte[] bytes2 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) (11 + (int) obj6 * 2)));
    numArray[4] = bytes2[0];
    numArray[5] = bytes2[1];
    numArray[6] = obj2;
    numArray[7] = (byte) 23;
    byte[] bytes3 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj3));
    numArray[8] = bytes3[0];
    numArray[9] = bytes3[1];
    byte[] bytes4 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj4));
    numArray[10] = bytes4[0];
    numArray[11] = bytes4[1];
    byte[] bytes5 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj5));
    numArray[12] = bytes5[0];
    numArray[13] = bytes5[1];
    byte[] bytes6 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj6));
    numArray[14] = bytes6[0];
    numArray[15] = bytes6[1];
    numArray[16 /*0x10*/] = (byte) ((uint) obj6 * 2U);
    return numArray;
  }

  static string \u0001([In] int obj0)
  {
    int num1 = obj0;
    byte[] numArray1 = \u0005.\u0003.\u0001;
    int index1 = num1;
    int index2 = index1 + 1;
    int num2 = (int) numArray1[index1];
    int count;
    if ((num2 & 128 /*0x80*/) == 0)
    {
      count = num2;
      if (count == 0)
        return string.Empty;
    }
    else if ((num2 & 64 /*0x40*/) == 0)
    {
      count = ((num2 & 63 /*0x3F*/) << 8) + (int) \u0005.\u0003.\u0001[index2++];
    }
    else
    {
      int num3 = (num2 & 31 /*0x1F*/) << 24;
      byte[] numArray2 = \u0005.\u0003.\u0001;
      int index3 = index2;
      int num4 = index3 + 1;
      int num5 = (int) numArray2[index3] << 16 /*0x10*/;
      int num6 = num3 + num5;
      byte[] numArray3 = \u0005.\u0003.\u0001;
      int index4 = num4;
      int num7 = index4 + 1;
      int num8 = (int) numArray3[index4] << 8;
      int num9 = num6 + num8;
      byte[] numArray4 = \u0005.\u0003.\u0001;
      int index5 = num7;
      index2 = index5 + 1;
      int num10 = (int) numArray4[index5];
      count = num9 + num10;
    }
    try
    {
      byte[] bytes = Convert.FromBase64String(Encoding.UTF8.GetString(\u0005.\u0003.\u0001, index2, count));
      string str = string.Intern(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
      if (\u0004.\u0003.\u0001.\u0001)
        \u0005.\u0004.\u0001(str, obj0);
      return str;
    }
    catch
    {
      return (string) null;
    }
  }

  static \u0004.\u0003.\u0004 \u0001([In] \u0004.\u0003.\u0005 obj0)
  {
    byte[] destinationArray = new byte[((\u0004.\u0003.\u0006) obj0).\u0003];
    Array.Copy((Array) obj0.\u0002, ((\u0004.\u0003.\u0006) obj0).\u0002, (Array) destinationArray, 0, ((\u0004.\u0003.\u0006) obj0).\u0003);
    return (\u0004.\u0003.\u0004) new \u0005.\u0004(destinationArray);
  }

  static int \u0001([In] \u0004.\u0003.\u0007 obj0) => obj0.ReadByte() | obj0.ReadByte() << 8;

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncWriteVar_ToPlc")]
  static extern unsafe uint \u0001([In] byte* obj0, [In] byte* obj1);

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_DisConnect")]
  static extern void \u0001();

  static void \u0001([In] Master obj0, [In] ushort obj1, [In] byte obj2, [In] byte obj3, [In] byte obj4)
  {
    if ((obj0.\u0001 == null ? 1 : (((FTPConnectMode) obj0).\u0002 == null ? 1 : 0)) != 0)
      return;
    if (obj4 == (byte) 254)
    {
      ((FTPConnectMode) obj0).\u0002 = (Socket) null;
      obj0.\u0001 = (Socket) null;
    }
    if (((FTPTransferType) obj0).\u0001 == null)
      return;
    ((FTPTransferType) obj0).\u0001(obj1, obj2, obj3, obj4);
  }

  static FTPReply \u0001([In] string obj0, [In] string obj1, [In] FTPControlSocket obj2)
  {
    string replyCode = obj1.Substring(0, 3);
    string msg = obj1.Substring(4);
    FTPReply ftpReply = (FTPReply) new GetString(replyCode, msg);
    if (!replyCode.Equals(obj0))
      throw new MemberRefsProxy(msg, replyCode);
    return ftpReply;
  }

  static void \u0001([In] FTPControlSocket obj0)
  {
    NetworkStream networkStream = new NetworkStream(((MemberRefsProxy) obj0).\u0001, true);
    ((MemberRefsProxy) obj0).\u0001 = new StreamWriter((Stream) networkStream);
    ((\u0003.\u0001) obj0).\u0001 = new StreamReader((Stream) networkStream);
  }

  static \u0004.\u0003.\u0004 \u0001([In] \u0004.\u0003.\u0005 obj0)
  {
    byte[] destinationArray = new byte[((\u0004.\u0003.\u0006) obj0).\u0002];
    Array.Copy((Array) obj0.\u0002, 0, (Array) destinationArray, 0, ((\u0004.\u0003.\u0006) obj0).\u0002);
    return (\u0004.\u0003.\u0004) new \u0005.\u0004(destinationArray);
  }

  static void \u0001([In] FTPControlSocket obj0, [In] Socket obj1, [In] int obj2)
  {
    if (obj2 <= 0)
      return;
    obj1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, obj2);
    obj1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, obj2);
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarDINTFromPlc2")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] int* obj2, [In] byte* obj3);

  static void \u0001([In] string obj0, [In] Stream obj1, [In] FTPClient obj2)
  {
    \u0005.\u0004.\u0001(obj0, obj2);
    StreamWriter streamWriter = new StreamWriter(obj1);
    StreamReader streamReader = new StreamReader((Stream) \u0005.\u0004.\u0001(obj2));
    IOException ioException = (IOException) null;
    try
    {
      string format;
      while ((format = streamReader.ReadLine()) != null)
      {
        streamWriter.Write(format, (object) 0, (object) format.Length);
        streamWriter.WriteLine();
      }
    }
    catch (IOException ex)
    {
      ioException = ex;
    }
    finally
    {
      streamWriter.Close();
    }
    try
    {
      streamReader.Close();
    }
    catch (IOException ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
    if (ioException != null)
      throw ioException;
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SetDeviceAddress")]
  static extern unsafe void \u0001([In] byte* obj0);

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_GetState")]
  static extern int \u0001();

  static byte[] \u0001([In] byte[] obj0, [In] ushort obj1, [In] Master obj2)
  {
    byte[] numArray;
    if (((FTPConnectMode) obj2).\u0002.Connected)
    {
      try
      {
        ((FTPConnectMode) obj2).\u0002.Send(obj0, 0, obj0.Length, SocketFlags.None);
        int num1 = ((FTPConnectMode) obj2).\u0002.Receive(((FTPConnectMode) obj2).\u0002, 0, ((FTPConnectMode) obj2).\u0002.Length, SocketFlags.None);
        byte num2 = ((FTPConnectMode) obj2).\u0002[6];
        byte num3 = ((FTPConnectMode) obj2).\u0002[7];
        if (num1 == 0)
          \u0005.\u0004.\u0001(obj2, obj1, num2, obj0[7], (byte) 254);
        if (num3 > (byte) 128 /*0x80*/)
        {
          byte num4 = (byte) ((uint) num3 - 128U /*0x80*/);
          \u0005.\u0004.\u0001(obj2, obj1, num2, num4, ((FTPConnectMode) obj2).\u0002[8]);
          numArray = (byte[]) null;
          goto label_12;
        }
        byte[] destinationArray;
        if ((num3 < (byte) 5 ? 0 : (num3 != (byte) 23 ? 1 : 0)) != 0)
        {
          destinationArray = new byte[2];
          Array.Copy((Array) ((FTPConnectMode) obj2).\u0002, 10, (Array) destinationArray, 0, 2);
        }
        else
        {
          destinationArray = new byte[(int) ((FTPConnectMode) obj2).\u0002[8]];
          Array.Copy((Array) ((FTPConnectMode) obj2).\u0002, 9, (Array) destinationArray, 0, (int) ((FTPConnectMode) obj2).\u0002[8]);
        }
        numArray = destinationArray;
        goto label_12;
      }
      catch (SystemException ex)
      {
        \u0005.\u0004.\u0001(obj2, obj1, obj0[6], obj0[7], (byte) 254);
      }
    }
    else
      \u0005.\u0004.\u0001(obj2, obj1, obj0[6], obj0[7], (byte) 254);
    numArray = (byte[]) null;
label_12:
    return numArray;
  }

  static void \u0001([In] Master obj0, [In] byte[] obj1, [In] ushort obj2)
  {
    if ((obj0.\u0001 == null ? 0 : (obj0.\u0001.Connected ? 1 : 0)) != 0)
    {
      try
      {
        obj0.\u0001.BeginSend(obj1, 0, obj1.Length, SocketFlags.None, new AsyncCallback(obj0.\u0001), (object) null);
        obj0.\u0001.BeginReceive(obj0.\u0001, 0, obj0.\u0001.Length, SocketFlags.None, new AsyncCallback(((Master.ResponseData) obj0).\u0002), (object) obj0.\u0001);
      }
      catch (SystemException ex)
      {
        \u0005.\u0004.\u0001(obj0, obj2, obj1[6], obj1[7], (byte) 254);
      }
    }
    else
      \u0005.\u0004.\u0001(obj0, obj2, obj1[6], obj1[7], (byte) 254);
  }

  static string \u0001([In] FTPControlSocket obj0)
  {
    string str1 = ((\u0003.\u0001) obj0).\u0001.ReadLine();
    StringBuilder stringBuilder = (str1 == null ? 1 : (str1.Length == 0 ? 1 : 0)) == 0 ? new StringBuilder(str1) : throw new IOException("Unexpected null reply received");
    if (((FTPReply) obj0).\u0001)
      ((FTPReply) obj0).\u0001.WriteLine(stringBuilder.ToString());
    string str2 = stringBuilder.ToString().Substring(0, 3);
    if (stringBuilder[3] == '-')
    {
      bool flag = false;
      while (!flag)
      {
        string str3 = ((\u0003.\u0001) obj0).\u0001.ReadLine();
        if (str3 == null)
          throw new IOException("Unexpected null reply received");
        if (((FTPReply) obj0).\u0001)
          ((FTPReply) obj0).\u0001.WriteLine(str3);
        if ((str3.Length <= 3 || !str3.Substring(0, 3).Equals(str2) ? 0 : (str3[3] == ' ' ? 1 : 0)) != 0)
        {
          stringBuilder.Append(str3.Substring(3));
          flag = true;
        }
        else
        {
          stringBuilder.Append(" ");
          stringBuilder.Append(str3);
        }
      }
    }
    return stringBuilder.ToString();
  }

  static Socket \u0001([In] FTPControlSocket obj0, [In] FTPConnectMode obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  static int \u0001([In] \u0004.\u0003.\u0004 obj0, [In] \u0004.\u0003.\u0002 obj1)
  {
    int index1;
    if ((index1 = \u0005.\u0004.\u0001(obj1, 9)) >= 0)
    {
      int num1;
      if ((num1 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001[index1]) >= 0)
      {
        \u0005.\u0004.\u0001(obj1, num1 & 15);
        return num1 >> 4;
      }
      int num2 = -(num1 >> 4);
      int num3 = num1 & 15;
      int num4;
      if ((num4 = \u0005.\u0004.\u0001(obj1, num3)) >= 0)
      {
        int num5 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001[num2 | num4 >> 9];
        \u0005.\u0004.\u0001(obj1, num5 & 15);
        return num5 >> 4;
      }
      int num6 = ((\u0004.\u0003.\u0005) obj1).\u0003;
      int num7 = \u0005.\u0004.\u0001(obj1, num6);
      int num8 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001[num2 | num7 >> 9];
      if ((num8 & 15) > num6)
        return -1;
      \u0005.\u0004.\u0001(obj1, num8 & 15);
      return num8 >> 4;
    }
    int num9 = ((\u0004.\u0003.\u0005) obj1).\u0003;
    int index2 = \u0005.\u0004.\u0001(obj1, num9);
    int num10 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001[index2];
    if (num10 < 0 || (num10 & 15) > num9)
      return -1;
    \u0005.\u0004.\u0001(obj1, num10 & 15);
    return num10 >> 4;
  }

  static void \u0001([In] \u0004.\u0003.\u0003 obj0, [In] int obj1)
  {
    \u0004.\u0003.\u0003 obj2 = obj0;
    int num1 = ((\u0004.\u0003.\u0005) obj0).\u0002;
    int num2 = num1 + 1;
    ((\u0004.\u0003.\u0005) obj2).\u0002 = num2;
    if (num1 == 32768 /*0x8000*/)
      throw new InvalidOperationException();
    byte[] numArray = ((\u0004.\u0003.\u0005) obj0).\u0001;
    \u0004.\u0003.\u0003 obj3 = obj0;
    int num3 = ((\u0004.\u0003.\u0005) obj0).\u0001;
    int num4 = num3 + 1;
    ((\u0004.\u0003.\u0005) obj3).\u0001 = num4;
    int index = num3;
    int num5 = (int) (byte) obj1;
    numArray[index] = (byte) num5;
    ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 & (int) short.MaxValue;
  }

  static int \u0001([In] \u0004.\u0003.\u0002 obj0, [In] int obj1)
  {
    if (((\u0004.\u0003.\u0005) obj0).\u0003 < obj1)
    {
      if (((\u0004.\u0003.\u0004) obj0).\u0001 == ((\u0004.\u0003.\u0005) obj0).\u0002)
        return -1;
      \u0004.\u0003.\u0002 obj2 = obj0;
      int num1 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001;
      byte[] numArray1 = ((\u0004.\u0003.\u0004) obj0).\u0001;
      \u0004.\u0003.\u0002 obj3 = obj0;
      int num2 = ((\u0004.\u0003.\u0004) obj0).\u0001;
      int num3 = num2 + 1;
      ((\u0004.\u0003.\u0004) obj3).\u0001 = num3;
      int index1 = num2;
      int num4 = (int) numArray1[index1] & (int) byte.MaxValue;
      byte[] numArray2 = ((\u0004.\u0003.\u0004) obj0).\u0001;
      \u0004.\u0003.\u0002 obj4 = obj0;
      int num5 = ((\u0004.\u0003.\u0004) obj0).\u0001;
      int num6 = num5 + 1;
      ((\u0004.\u0003.\u0004) obj4).\u0001 = num6;
      int index2 = num5;
      int num7 = ((int) numArray2[index2] & (int) byte.MaxValue) << 8;
      int num8 = (num4 | num7) << ((\u0004.\u0003.\u0005) obj0).\u0003;
      int num9 = num1 | num8;
      ((\u0004.\u0003.\u0005) obj2).\u0001 = (uint) num9;
      ((\u0004.\u0003.\u0005) obj0).\u0003 = ((\u0004.\u0003.\u0005) obj0).\u0003 + 16 /*0x10*/;
    }
    return (int) ((long) ((\u0004.\u0003.\u0005) obj0).\u0001 & (long) ((1 << obj1) - 1));
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SetDeviceName")]
  static extern unsafe void \u0001([In] byte* obj0);

  static bool \u0001([In] \u0004.\u0003.\u0001 obj0)
  {
    int num1 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001);
    while (num1 >= 258)
    {
      switch (obj0.\u0001)
      {
        case 7:
          int num2;
          while (((num2 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001, ((\u0004.\u0003.\u0002) obj0).\u0001)) & -256) == 0)
          {
            \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001, num2);
            if (--num1 < 258)
              return true;
          }
          if (num2 >= 257)
          {
            ((\u0004.\u0003.\u0002) obj0).\u0003 = \u0004.\u0003.\u0001.\u0001[num2 - 257];
            obj0.\u0002 = \u0004.\u0003.\u0001.\u0002[num2 - 257];
            goto case 8;
          }
          if (num2 < 0)
            return false;
          ((\u0004.\u0003.\u0004) obj0).\u0002 = (\u0004.\u0003.\u0004) null;
          ((\u0004.\u0003.\u0003) obj0).\u0001 = (\u0004.\u0003.\u0004) null;
          obj0.\u0001 = 2;
          return true;
        case 8:
          if (obj0.\u0002 > 0)
          {
            obj0.\u0001 = 8;
            int num3 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, obj0.\u0002);
            if (num3 < 0)
              return false;
            \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, obj0.\u0002);
            ((\u0004.\u0003.\u0002) obj0).\u0003 = ((\u0004.\u0003.\u0002) obj0).\u0003 + num3;
          }
          obj0.\u0001 = 9;
          goto case 9;
        case 9:
          int index = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0004) obj0).\u0002, ((\u0004.\u0003.\u0002) obj0).\u0001);
          if (index < 0)
            return false;
          ((\u0004.\u0003.\u0002) obj0).\u0004 = \u0004.\u0003.\u0001.\u0003[index];
          obj0.\u0002 = \u0004.\u0003.\u0001.\u0004[index];
          goto case 10;
        case 10:
          if (obj0.\u0002 > 0)
          {
            obj0.\u0001 = 10;
            int num4 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, obj0.\u0002);
            if (num4 < 0)
              return false;
            \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, obj0.\u0002);
            ((\u0004.\u0003.\u0002) obj0).\u0004 = ((\u0004.\u0003.\u0002) obj0).\u0004 + num4;
          }
          \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001, ((\u0004.\u0003.\u0002) obj0).\u0003, ((\u0004.\u0003.\u0002) obj0).\u0004);
          num1 -= ((\u0004.\u0003.\u0002) obj0).\u0003;
          obj0.\u0001 = 7;
          continue;
        default:
          continue;
      }
    }
    return true;
  }

  static byte[] \u0001([In] ushort obj0, [In] ushort obj1, [In] ushort obj2, [In] Master obj3, [In] byte obj4, [In] byte obj5)
  {
    byte[] numArray = new byte[12];
    byte[] bytes1 = BitConverter.GetBytes((short) obj1);
    numArray[0] = bytes1[1];
    numArray[1] = bytes1[0];
    numArray[5] = (byte) 6;
    numArray[6] = obj5;
    numArray[7] = obj4;
    byte[] bytes2 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj0));
    numArray[8] = bytes2[0];
    numArray[9] = bytes2[1];
    byte[] bytes3 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj2));
    numArray[10] = bytes3[0];
    numArray[11] = bytes3[1];
    return numArray;
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarBOOLFromPlc")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] bool* obj2);

  static string \u0001([In] int obj0)
  {
    lock (\u0004.\u0003.\u0001.\u0001)
    {
      string str;
      \u0004.\u0003.\u0001.\u0001.TryGetValue(obj0, out str);
      if (str != null)
        return str;
    }
    return \u0005.\u0004.\u0001(obj0);
  }

  static void \u0001([In] IPEndPoint obj0, [In] FTPControlSocket obj1)
  {
    byte[] bytes = BitConverter.GetBytes(obj0.Address.Address);
    byte[] byteArray = ((FTPException) obj1).ToByteArray((ushort) obj0.Port);
    string str = new StringBuilder("PORT ").Append((short) bytes[0]).Append(",").Append((short) bytes[1]).Append(",").Append((short) bytes[2]).Append(",").Append((short) bytes[3]).Append(",").Append((short) byteArray[0]).Append(",").Append((short) byteArray[1]).ToString();
    \u0005.\u0004.\u0001("200", \u0005.\u0004.\u0001(obj1, str), obj1);
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarLREALFromPlc")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] double* obj2, [In] byte* obj3);

  static int \u0001([In] int obj0, [In] byte[] obj1, [In] int obj2, [In] \u0004.\u0003.\u0003 obj3)
  {
    int num1 = ((\u0004.\u0003.\u0005) obj3).\u0001;
    if (obj0 > ((\u0004.\u0003.\u0005) obj3).\u0002)
      obj0 = ((\u0004.\u0003.\u0005) obj3).\u0002;
    else
      num1 = ((\u0004.\u0003.\u0005) obj3).\u0001 - ((\u0004.\u0003.\u0005) obj3).\u0002 + obj0 & (int) short.MaxValue;
    int num2 = obj0;
    int length = obj0 - num1;
    if (length > 0)
    {
      Array.Copy((Array) ((\u0004.\u0003.\u0005) obj3).\u0001, 32768 /*0x8000*/ - length, (Array) obj1, obj2, length);
      obj2 += length;
      obj0 = num1;
    }
    Array.Copy((Array) ((\u0004.\u0003.\u0005) obj3).\u0001, num1 - obj0, (Array) obj1, obj2, obj0);
    ((\u0004.\u0003.\u0005) obj3).\u0002 = ((\u0004.\u0003.\u0005) obj3).\u0002 - num2;
    if (((\u0004.\u0003.\u0005) obj3).\u0002 < 0)
      throw new InvalidOperationException();
    return num2;
  }

  static int \u0001([In] \u0004.\u0003.\u0007 obj0)
  {
    return \u0005.\u0004.\u0001(obj0) | \u0005.\u0004.\u0001(obj0) << 16 /*0x10*/;
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarINTFromPlc")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] short* obj2);

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_Log")]
  static extern int \u0001();

  static double \u0001([In] byte[] obj0) => BitConverter.ToDouble(obj0, 0);

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarREALFromPlc")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] float* obj2, [In] byte* obj3);

  static bool \u0001([In] \u0004.\u0003.\u0005 obj0, [In] \u0004.\u0003.\u0002 obj1)
  {
    while (true)
    {
      switch (((\u0004.\u0003.\u0006) obj0).\u0001)
      {
        case 0:
          ((\u0004.\u0003.\u0006) obj0).\u0002 = \u0005.\u0004.\u0001(obj1, 5);
          if (((\u0004.\u0003.\u0006) obj0).\u0002 >= 0)
          {
            ((\u0004.\u0003.\u0006) obj0).\u0002 = ((\u0004.\u0003.\u0006) obj0).\u0002 + 257;
            \u0005.\u0004.\u0001(obj1, 5);
            ((\u0004.\u0003.\u0006) obj0).\u0001 = 1;
            goto case 1;
          }
          goto label_23;
        case 1:
          ((\u0004.\u0003.\u0006) obj0).\u0003 = \u0005.\u0004.\u0001(obj1, 5);
          if (((\u0004.\u0003.\u0006) obj0).\u0003 >= 0)
          {
            ((\u0004.\u0003.\u0006) obj0).\u0003 = ((\u0004.\u0003.\u0006) obj0).\u0003 + 1;
            \u0005.\u0004.\u0001(obj1, 5);
            ((\u0004.\u0003.\u0006) obj0).\u0005 = ((\u0004.\u0003.\u0006) obj0).\u0002 + ((\u0004.\u0003.\u0006) obj0).\u0003;
            obj0.\u0002 = new byte[((\u0004.\u0003.\u0006) obj0).\u0005];
            ((\u0004.\u0003.\u0006) obj0).\u0001 = 2;
            goto case 2;
          }
          goto label_24;
        case 2:
          ((\u0004.\u0003.\u0006) obj0).\u0004 = \u0005.\u0004.\u0001(obj1, 4);
          if (((\u0004.\u0003.\u0006) obj0).\u0004 >= 0)
          {
            ((\u0004.\u0003.\u0006) obj0).\u0004 = ((\u0004.\u0003.\u0006) obj0).\u0004 + 4;
            \u0005.\u0004.\u0001(obj1, 4);
            obj0.\u0001 = new byte[19];
            // ISSUE: reference to a compiler-generated field
            ((\u0004.\u0004) obj0).\u0007 = 0;
            ((\u0004.\u0003.\u0006) obj0).\u0001 = 3;
            goto case 3;
          }
          goto label_25;
        case 3:
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          for (; ((\u0004.\u0004) obj0).\u0007 < ((\u0004.\u0003.\u0006) obj0).\u0004; ((\u0004.\u0004) obj0).\u0007 = ((\u0004.\u0004) obj0).\u0007 + 1)
          {
            int num = \u0005.\u0004.\u0001(obj1, 3);
            if (num < 0)
              return false;
            \u0005.\u0004.\u0001(obj1, 3);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            obj0.\u0001[\u0004.\u0004.\u0003[((\u0004.\u0004) obj0).\u0007]] = (byte) num;
          }
          obj0.\u0001 = (\u0004.\u0003.\u0004) new \u0005.\u0004(obj0.\u0001);
          obj0.\u0001 = (byte[]) null;
          // ISSUE: reference to a compiler-generated field
          ((\u0004.\u0004) obj0).\u0007 = 0;
          ((\u0004.\u0003.\u0006) obj0).\u0001 = 4;
          goto case 4;
        case 4:
          int num1;
          while (((num1 = \u0005.\u0004.\u0001(obj0.\u0001, obj1)) & -16) == 0)
          {
            byte[] numArray = obj0.\u0002;
            \u0004.\u0003.\u0005 obj = obj0;
            // ISSUE: reference to a compiler-generated field
            int num2 = ((\u0004.\u0004) obj0).\u0007;
            int num3 = num2 + 1;
            // ISSUE: reference to a compiler-generated field
            ((\u0004.\u0004) obj).\u0007 = num3;
            int index = num2;
            // ISSUE: reference to a compiler-generated field
            int num4 = (int) (((\u0004.\u0004) obj0).\u0001 = (byte) num1);
            numArray[index] = (byte) num4;
            // ISSUE: reference to a compiler-generated field
            if (((\u0004.\u0004) obj0).\u0007 == ((\u0004.\u0003.\u0006) obj0).\u0005)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
            {
              // ISSUE: reference to a compiler-generated field
              ((\u0004.\u0004) obj0).\u0001 = (byte) 0;
            }
            ((\u0004.\u0003.\u0006) obj0).\u0006 = num1 - 16 /*0x10*/;
            ((\u0004.\u0003.\u0006) obj0).\u0001 = 5;
            goto case 5;
          }
          goto label_27;
        case 5:
          int num5 = \u0004.\u0003.\u0005.\u0002[((\u0004.\u0003.\u0006) obj0).\u0006];
          int num6 = \u0005.\u0004.\u0001(obj1, num5);
          if (num6 >= 0)
          {
            \u0005.\u0004.\u0001(obj1, num5);
            int num7 = num6 + \u0004.\u0003.\u0005.\u0001[((\u0004.\u0003.\u0006) obj0).\u0006];
            while (num7-- > 0)
            {
              byte[] numArray = obj0.\u0002;
              \u0004.\u0003.\u0005 obj = obj0;
              // ISSUE: reference to a compiler-generated field
              int num8 = ((\u0004.\u0004) obj0).\u0007;
              int num9 = num8 + 1;
              // ISSUE: reference to a compiler-generated field
              ((\u0004.\u0004) obj).\u0007 = num9;
              int index = num8;
              // ISSUE: reference to a compiler-generated field
              int num10 = (int) ((\u0004.\u0004) obj0).\u0001;
              numArray[index] = (byte) num10;
            }
            // ISSUE: reference to a compiler-generated field
            if (((\u0004.\u0004) obj0).\u0007 != ((\u0004.\u0003.\u0006) obj0).\u0005)
            {
              ((\u0004.\u0003.\u0006) obj0).\u0001 = 4;
              continue;
            }
            goto label_30;
          }
          goto label_29;
        default:
          continue;
      }
    }
label_23:
    return false;
label_24:
    return false;
label_25:
    return false;
label_27:
    return false;
label_29:
    return false;
label_30:
    return true;
  }

  static int \u0001([In] \u0004.\u0003.\u0002 obj0) => ((\u0004.\u0003.\u0005) obj0).\u0003;

  static bool \u0001([In] \u0004.\u0003.\u0002 obj0)
  {
    return ((\u0004.\u0003.\u0004) obj0).\u0001 == ((\u0004.\u0003.\u0005) obj0).\u0002;
  }

  static void \u0001([In] \u0004.\u0003.\u0002 obj0)
  {
    ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 >> (((\u0004.\u0003.\u0005) obj0).\u0003 & 7);
    ((\u0004.\u0003.\u0005) obj0).\u0003 = ((\u0004.\u0003.\u0005) obj0).\u0003 & -8;
  }

  static bool \u0001([In] \u0004.\u0003.\u0001 obj0)
  {
    switch (obj0.\u0001)
    {
      case 2:
        if (((\u0004.\u0003.\u0002) obj0).\u0001)
        {
          obj0.\u0001 = 12;
          return false;
        }
        int num1 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, 3);
        if (num1 < 0)
          return false;
        \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, 3);
        if ((num1 & 1) != 0)
          ((\u0004.\u0003.\u0002) obj0).\u0001 = true;
        switch (num1 >> 1)
        {
          case 0:
            \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001);
            obj0.\u0001 = 3;
            break;
          case 1:
            ((\u0004.\u0003.\u0003) obj0).\u0001 = \u0004.\u0003.\u0005.\u0001;
            ((\u0004.\u0003.\u0004) obj0).\u0002 = \u0004.\u0003.\u0005.\u0002;
            obj0.\u0001 = 7;
            break;
          case 2:
            ((\u0004.\u0003.\u0003) obj0).\u0001 = (\u0004.\u0003.\u0005) new \u0005.\u0004();
            obj0.\u0001 = 6;
            break;
        }
        return true;
      case 3:
        if ((((\u0004.\u0003.\u0002) obj0).\u0005 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, 16 /*0x10*/)) < 0)
          return false;
        \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, 16 /*0x10*/);
        obj0.\u0001 = 4;
        goto case 4;
      case 4:
        if (\u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, 16 /*0x10*/) < 0)
          return false;
        \u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001, 16 /*0x10*/);
        obj0.\u0001 = 5;
        goto case 5;
      case 5:
        int num2 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001, ((\u0004.\u0003.\u0002) obj0).\u0001, ((\u0004.\u0003.\u0002) obj0).\u0005);
        ((\u0004.\u0003.\u0002) obj0).\u0005 = ((\u0004.\u0003.\u0002) obj0).\u0005 - num2;
        if (((\u0004.\u0003.\u0002) obj0).\u0005 != 0)
          return !\u0005.\u0004.\u0001(((\u0004.\u0003.\u0002) obj0).\u0001);
        obj0.\u0001 = 2;
        return true;
      case 6:
        if (!\u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001, ((\u0004.\u0003.\u0002) obj0).\u0001))
          return false;
        ((\u0004.\u0003.\u0003) obj0).\u0001 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001);
        ((\u0004.\u0003.\u0004) obj0).\u0002 = \u0005.\u0004.\u0001(((\u0004.\u0003.\u0003) obj0).\u0001);
        obj0.\u0001 = 7;
        goto case 7;
      case 7:
      case 8:
      case 9:
      case 10:
        return \u0005.\u0004.\u0001(obj0);
      case 12:
        return false;
      default:
        return false;
    }
  }

  static void \u0001([In] string obj0, [In] FTPClient obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  static void \u0001([In] \u0004.\u0003.\u0002 obj0, [In] int obj1)
  {
    ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 >> obj1;
    ((\u0004.\u0003.\u0005) obj0).\u0003 = ((\u0004.\u0003.\u0005) obj0).\u0003 - obj1;
  }

  static int \u0001([In] \u0004.\u0003.\u0003 obj0, [In] \u0004.\u0003.\u0002 obj1, [In] int obj2)
  {
    obj2 = Math.Min(Math.Min(obj2, 32768 /*0x8000*/ - ((\u0004.\u0003.\u0005) obj0).\u0002), \u0005.\u0004.\u0001(obj1));
    int num1 = 32768 /*0x8000*/ - ((\u0004.\u0003.\u0005) obj0).\u0001;
    int num2;
    if (obj2 > num1)
    {
      num2 = \u0005.\u0004.\u0001(obj1, ((\u0004.\u0003.\u0005) obj0).\u0001, ((\u0004.\u0003.\u0005) obj0).\u0001, num1);
      if (num2 == num1)
        num2 += \u0005.\u0004.\u0001(obj1, ((\u0004.\u0003.\u0005) obj0).\u0001, 0, obj2 - num1);
    }
    else
      num2 = \u0005.\u0004.\u0001(obj1, ((\u0004.\u0003.\u0005) obj0).\u0001, ((\u0004.\u0003.\u0005) obj0).\u0001, obj2);
    ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 + num2 & (int) short.MaxValue;
    ((\u0004.\u0003.\u0005) obj0).\u0002 = ((\u0004.\u0003.\u0005) obj0).\u0002 + num2;
    return num2;
  }

  static short \u0001([In] int obj0)
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    return (short) ((int) \u0004.\u0004.\u0001[obj0 & 15] << 12 | (int) \u0004.\u0004.\u0001[obj0 >> 4 & 15] << 8 | (int) \u0004.\u0004.\u0001[obj0 >> 8 & 15] << 4 | (int) \u0004.\u0004.\u0001[obj0 >> 12]);
  }

  static int \u0001([In] NetVars obj0, [In] int obj1)
  {
    int num1 = 0;
    int index = 0;
    while (index < obj0.\u0001.Count & index < obj1)
    {
      int num2 = num1;
      if (obj0.\u0001[index].DataTypes == DataTypes.booltype | obj0.\u0001[index].DataTypes == DataTypes.bytetype | obj0.\u0001[index].DataTypes == DataTypes.sinttype | obj0.\u0001[index].DataTypes == DataTypes.usintType)
        checked { ++num1; }
      if (obj0.\u0001[index].DataTypes == DataTypes.wordtype | obj0.\u0001[index].DataTypes == DataTypes.inttype | obj0.\u0001[index].DataTypes == DataTypes.uinttype)
      {
        checked { num1 += 2; }
        int num3 = num1;
        if (num3 % 256 /*0x0100*/ <= num2 % 256 /*0x0100*/ & num3 % 256 /*0x0100*/ != 0)
          num1 = checked ((int) unchecked (256.0 * Math.Ceiling((double) num2 / 256.0)) + 2);
      }
      if (obj0.\u0001[index].DataTypes == DataTypes.dwordtype | obj0.\u0001[index].DataTypes == DataTypes.udinttype | obj0.\u0001[index].DataTypes == DataTypes.dinttype | obj0.\u0001[index].DataTypes == DataTypes.realtype)
      {
        checked { num1 += 4; }
        int num4 = num1;
        if (num4 % 256 /*0x0100*/ <= num2 % 256 /*0x0100*/ & num4 % 256 /*0x0100*/ != 0)
          num1 = checked ((int) unchecked (256.0 * Math.Ceiling((double) num2 / 256.0)) + 4);
      }
      if (obj0.\u0001[index].DataTypes == (DataTypes.dwordtype | DataTypes.uinttype))
      {
        checked { num1 += 8; }
        int num5 = num1;
        if (num5 % 256 /*0x0100*/ <= num2 % 256 /*0x0100*/ & num5 % 256 /*0x0100*/ != 0)
          num1 = checked ((int) unchecked (256.0 * Math.Ceiling((double) num2 / 256.0)) + 8);
      }
      if (obj0.\u0001[index].DataTypes == (DataTypes.sinttype | DataTypes.uinttype))
      {
        num1 = checked (num1 + obj0.\u0001[index].FieldLength + 1);
        int num6 = num1;
        if (num6 % 256 /*0x0100*/ <= num2 % 256 /*0x0100*/ & num6 % 256 /*0x0100*/ != 0)
          num1 = checked ((int) unchecked (256.0 * Math.Ceiling((double) num2 / 256.0)) + obj0.\u0001[index].FieldLength + 1);
      }
      checked { ++index; }
    }
    int num7 = checked ((int) Math.Floor(unchecked ((double) num1 / 256.0)));
    if (num1 % 256 /*0x0100*/ == 0 & num7 > 0)
      checked { --num7; }
    return num7;
  }

  static byte[] \u0001([In] byte[] obj0)
  {
    // ISSUE: unable to decompile the method.
  }

  static string \u0001([In] FTPControlSocket obj0, [In] string obj1)
  {
    if (((FTPReply) obj0).\u0001)
      ((FTPReply) obj0).\u0001.WriteLine("---> " + obj1);
    ((MemberRefsProxy) obj0).\u0001.Write(obj1 + "\r\n");
    ((MemberRefsProxy) obj0).\u0001.Flush();
    return !(obj1 == "QUIT") ? \u0005.\u0004.\u0001(obj0) : "QUIT";
  }

  static void \u0001([In] StreamWriter obj0, [In] FTPControlSocket obj1)
  {
    if (obj0 == null)
      return;
    ((FTPReply) obj1).\u0001 = (TextWriter) obj0;
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_ConnectByIP")]
  static extern int \u0001();

  static NetworkStream \u0001([In] FTPClient obj0)
  {
    // ISSUE: unable to decompile the method.
  }

  static void \u0001([In] string obj0, [In] FTPClient obj1, [In] bool obj2, [In] Stream obj3)
  {
    BufferedStream bufferedStream = new BufferedStream(obj3);
    \u0005.\u0004.\u0001(obj2, obj0, obj1);
    BinaryWriter binaryWriter = new BinaryWriter((Stream) \u0005.\u0004.\u0001(obj1));
    byte[] buffer = new byte[512 /*0x0200*/];
    int count;
    while ((count = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
      binaryWriter.Write(buffer, 0, count);
    bufferedStream.Close();
    binaryWriter.Flush();
    binaryWriter.Close();
  }

  static void \u0001([In] string obj0, [In] int obj1)
  {
    try
    {
      lock (\u0004.\u0003.\u0001.\u0001)
        \u0004.\u0003.\u0001.\u0001.Add(obj1, obj0);
    }
    catch
    {
    }
  }

  static void \u0001([In] bool obj0, [In] FTPControlSocket obj1) => ((FTPReply) obj1).\u0001 = obj0;

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarDINTFromPlc")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] int* obj2);

  static int \u0001([In] int obj0, [In] \u0004.\u0003.\u0001 obj1, [In] byte[] obj2, [In] int obj3)
  {
    int num1 = 0;
    do
    {
      if (obj1.\u0001 != 11)
        goto label_2;
label_1:
      continue;
label_2:
      int num2 = \u0005.\u0004.\u0001(obj0, obj2, obj3, ((\u0004.\u0003.\u0003) obj1).\u0001);
      obj3 += num2;
      num1 += num2;
      obj0 -= num2;
      if (obj0 != 0)
        goto label_1;
      goto label_4;
    }
    while (\u0005.\u0004.\u0001(obj1) || ((\u0004.\u0003.\u0005) ((\u0004.\u0003.\u0003) obj1).\u0001).\u0002 > 0 && obj1.\u0001 != 11);
    goto label_5;
label_4:
    return num1;
label_5:
    return num1;
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarBOOLFromPlc2")]
  static extern unsafe int \u0001([In] string[] obj0, [In] int obj1, [In] byte* obj2, [In] byte* obj3);

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_Init")]
  static extern int \u0001();

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SyncReadVarSTRINGFromPlc")]
  static extern unsafe int \u0001([In] string[] obj0, [In] byte* obj1);

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SymbolsCount")]
  static extern uint \u0001();

  static void \u0001([In] string obj0, [In] bool obj1, [In] string obj2, [In] FTPClient obj3)
  {
    Stream stream = (Stream) new FileStream(obj0, FileMode.Open, FileAccess.Read);
    \u0005.\u0004.\u0001(obj2, obj3, obj1, stream);
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_SetDeviceIP")]
  static extern unsafe void \u0001([In] byte* obj0);

  static ushort \u0001([In] ushort obj0)
  {
    return (ushort) (((int) obj0 & 65280) >> 8 | ((int) obj0 & (int) byte.MaxValue) << 8);
  }

  static FTPReply \u0001([In] string obj0, [In] string[] obj1, [In] FTPControlSocket obj2)
  {
    FTPReply ftpReply1;
    if (obj0 == "QUIT")
    {
      ftpReply1 = (FTPReply) new GetString("", "");
    }
    else
    {
      string replyCode = obj0.Substring(0, 3);
      string msg = obj0.Substring(4);
      FTPReply ftpReply2 = (FTPReply) new GetString(replyCode, msg);
      for (int index = 0; index < obj1.Length; ++index)
      {
        if (replyCode.Equals(obj1[index]))
        {
          ftpReply1 = ftpReply2;
          goto label_8;
        }
      }
      throw new MemberRefsProxy(msg, replyCode);
    }
label_8:
    return ftpReply1;
  }

  static void \u0001([In] int obj0, [In] int obj1, [In] \u0004.\u0003.\u0002 obj2, [In] byte[] obj3)
  {
    if (((\u0004.\u0003.\u0004) obj2).\u0001 < ((\u0004.\u0003.\u0005) obj2).\u0002)
      throw new InvalidOperationException();
    int num = obj1 + obj0;
    if (0 > obj1 || obj1 > num || num > obj3.Length)
      throw new ArgumentOutOfRangeException();
    if ((obj0 & 1) != 0)
    {
      ((\u0004.\u0003.\u0005) obj2).\u0001 = ((\u0004.\u0003.\u0005) obj2).\u0001 | (uint) (((int) obj3[obj1++] & (int) byte.MaxValue) << ((\u0004.\u0003.\u0005) obj2).\u0003);
      ((\u0004.\u0003.\u0005) obj2).\u0003 = ((\u0004.\u0003.\u0005) obj2).\u0003 + 8;
    }
    ((\u0004.\u0003.\u0004) obj2).\u0001 = obj3;
    ((\u0004.\u0003.\u0004) obj2).\u0001 = obj1;
    ((\u0004.\u0003.\u0005) obj2).\u0002 = num;
  }

  static byte[] \u0001(
    [In] Master obj0,
    [In] ushort obj1,
    [In] byte obj2,
    [In] ushort obj3,
    [In] ushort obj4,
    [In] ushort obj5,
    [In] byte obj6)
  {
    byte[] numArray = new byte[(int) obj5 + 11];
    byte[] bytes1 = BitConverter.GetBytes((short) obj1);
    numArray[0] = bytes1[1];
    numArray[1] = bytes1[0];
    byte[] bytes2 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) (5 + (int) obj5)));
    numArray[4] = bytes2[0];
    numArray[5] = bytes2[1];
    numArray[6] = obj2;
    numArray[7] = obj6;
    byte[] bytes3 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj3));
    numArray[8] = bytes3[0];
    numArray[9] = bytes3[1];
    if (obj6 >= (byte) 15)
    {
      byte[] bytes4 = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short) obj4));
      numArray[10] = bytes4[0];
      numArray[11] = bytes4[1];
      numArray[12] = (byte) ((uint) obj5 - 2U);
    }
    return numArray;
  }

  static void \u0001([In] \u0004.\u0003.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    if ((((\u0004.\u0003.\u0005) obj0).\u0002 = ((\u0004.\u0003.\u0005) obj0).\u0002 + obj1) > 32768 /*0x8000*/)
      throw new InvalidOperationException();
    int sourceIndex = ((\u0004.\u0003.\u0005) obj0).\u0001 - obj2 & (int) short.MaxValue;
    int num1 = 32768 /*0x8000*/ - obj1;
    if (sourceIndex <= num1 && ((\u0004.\u0003.\u0005) obj0).\u0001 < num1)
    {
      if (obj1 <= obj2)
      {
        Array.Copy((Array) ((\u0004.\u0003.\u0005) obj0).\u0001, sourceIndex, (Array) ((\u0004.\u0003.\u0005) obj0).\u0001, ((\u0004.\u0003.\u0005) obj0).\u0001, obj1);
        ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 + obj1;
      }
      else
      {
        while (obj1-- > 0)
        {
          byte[] numArray = ((\u0004.\u0003.\u0005) obj0).\u0001;
          \u0004.\u0003.\u0003 obj = obj0;
          int num2 = ((\u0004.\u0003.\u0005) obj0).\u0001;
          int num3 = num2 + 1;
          ((\u0004.\u0003.\u0005) obj).\u0001 = num3;
          int index = num2;
          int num4 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001[sourceIndex++];
          numArray[index] = (byte) num4;
        }
      }
    }
    else
      \u0005.\u0004.\u0001(obj0, sourceIndex, obj1);
  }

  static void \u0001([In] string obj0, [In] FTPClient obj1, [In] string obj2)
  {
    \u0005.\u0004.\u0001(obj0, obj1);
    FileInfo fileInfo = new FileInfo(obj2);
    BinaryWriter binaryWriter = new BinaryWriter((Stream) new FileStream(obj2, FileMode.OpenOrCreate));
    BinaryReader binaryReader = new BinaryReader((Stream) \u0005.\u0004.\u0001(obj1));
    byte[] buffer = new byte[4096 /*0x1000*/];
    IOException ioException = (IOException) null;
    try
    {
      int count;
      while ((count = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
        binaryWriter.Write(buffer, 0, count);
    }
    catch (IOException ex)
    {
      ioException = ex;
    }
    finally
    {
      binaryWriter.Close();
      if ((ioException == null ? 0 : (System.IO.File.Exists(fileInfo.FullName) ? 1 : 0)) != 0)
        System.IO.File.Delete(fileInfo.FullName);
    }
    try
    {
      binaryReader.Close();
    }
    catch (IOException ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
    if (ioException != null)
      throw ioException;
  }

  static void \u0001([In] bool obj0, [In] string obj1, [In] FTPClient obj2)
  {
    // ISSUE: unable to decompile the method.
  }

  static int \u0001([In] \u0004.\u0003.\u0003 obj0)
  {
    return 32768 /*0x8000*/ - ((\u0004.\u0003.\u0005) obj0).\u0002;
  }

  static void \u0001([In] Stream obj0, [In] FTPClient obj1, [In] bool obj2, [In] string obj3)
  {
    StreamReader streamReader = new StreamReader(obj0);
    \u0005.\u0004.\u0001(obj2, obj3, obj1);
    StreamWriter streamWriter = new StreamWriter((Stream) \u0005.\u0004.\u0001(obj1));
    FTPConnectProperties.SendPersentage = 0.0;
    int num = 1000;
    if (FTPConnectProperties.TotalLineCount > 0)
      num = Convert.ToInt32((double) FTPConnectProperties.TotalLineCount / 100.0);
    string format;
    while ((format = streamReader.ReadLine()) != null)
    {
      streamWriter.Write(format, (object) 0, (object) format.Length);
      streamWriter.Write("\r\n", (object) 0, (object) "\r\n".Length);
      ++FTPConnectProperties.SentLineCount;
      if (FTPConnectProperties.SentLineCount % num == 0 && FTPConnectProperties.TotalLineCount > 0)
      {
        FTPConnectProperties.SendPersentage = (double) FTPConnectProperties.SentLineCount / (double) FTPConnectProperties.TotalLineCount;
        if (obj1.\u0001 != null)
        {
          obj1.\u0001(new FtpFileSendEventArg()
          {
            ActualLineIndex = FTPConnectProperties.SentLineCount,
            TotalLineCount = FTPConnectProperties.TotalLineCount,
            SendPersentage = FTPConnectProperties.SendPersentage
          });
          Application.DoEvents();
        }
      }
    }
    streamReader.Close();
    streamWriter.Flush();
    streamWriter.Close();
  }

  static void \u0001([In] \u0004.\u0003.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    while (obj2-- > 0)
    {
      byte[] numArray = ((\u0004.\u0003.\u0005) obj0).\u0001;
      \u0004.\u0003.\u0003 obj = obj0;
      int num1 = ((\u0004.\u0003.\u0005) obj0).\u0001;
      int num2 = num1 + 1;
      ((\u0004.\u0003.\u0005) obj).\u0001 = num2;
      int index = num1;
      int num3 = (int) ((\u0004.\u0003.\u0005) obj0).\u0001[obj1++];
      numArray[index] = (byte) num3;
      ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 & (int) short.MaxValue;
      obj1 &= (int) short.MaxValue;
    }
  }

  static int \u0001([In] \u0004.\u0003.\u0002 obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
  {
    int num1 = 0;
    while (((\u0004.\u0003.\u0005) obj0).\u0003 > 0 && obj3 > 0)
    {
      obj1[obj2++] = (byte) ((\u0004.\u0003.\u0005) obj0).\u0001;
      ((\u0004.\u0003.\u0005) obj0).\u0001 = ((\u0004.\u0003.\u0005) obj0).\u0001 >> 8;
      ((\u0004.\u0003.\u0005) obj0).\u0003 = ((\u0004.\u0003.\u0005) obj0).\u0003 - 8;
      --obj3;
      ++num1;
    }
    if (obj3 == 0)
      return num1;
    int num2 = ((\u0004.\u0003.\u0005) obj0).\u0002 - ((\u0004.\u0003.\u0004) obj0).\u0001;
    if (obj3 > num2)
      obj3 = num2;
    Array.Copy((Array) ((\u0004.\u0003.\u0004) obj0).\u0001, ((\u0004.\u0003.\u0004) obj0).\u0001, (Array) obj1, obj2, obj3);
    ((\u0004.\u0003.\u0004) obj0).\u0001 = ((\u0004.\u0003.\u0004) obj0).\u0001 + obj3;
    if ((((\u0004.\u0003.\u0004) obj0).\u0001 - ((\u0004.\u0003.\u0005) obj0).\u0002 & 1) != 0)
    {
      \u0004.\u0003.\u0002 obj4 = obj0;
      byte[] numArray = ((\u0004.\u0003.\u0004) obj0).\u0001;
      \u0004.\u0003.\u0002 obj5 = obj0;
      int num3 = ((\u0004.\u0003.\u0004) obj0).\u0001;
      int num4 = num3 + 1;
      ((\u0004.\u0003.\u0004) obj5).\u0001 = num4;
      int index = num3;
      int num5 = (int) numArray[index] & (int) byte.MaxValue;
      ((\u0004.\u0003.\u0005) obj4).\u0001 = (uint) num5;
      ((\u0004.\u0003.\u0005) obj0).\u0003 = 8;
    }
    return num1 + obj3;
  }

  static void \u0001([In] string obj0, [In] Stream obj1, [In] FTPClient obj2)
  {
    \u0005.\u0004.\u0001(obj0, obj2);
    BinaryWriter binaryWriter = new BinaryWriter(obj1);
    BinaryReader binaryReader = new BinaryReader((Stream) \u0005.\u0004.\u0001(obj2));
    byte[] buffer = new byte[4096 /*0x1000*/];
    IOException ioException = (IOException) null;
    try
    {
      int count;
      while ((count = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
        binaryWriter.Write(buffer, 0, count);
    }
    catch (IOException ex)
    {
      ioException = ex;
    }
    finally
    {
      binaryWriter.Close();
    }
    try
    {
      binaryReader.Close();
    }
    catch (IOException ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
    if (ioException != null)
      throw ioException;
  }

  static void \u0001([In] FTPClient obj0)
  {
    string[] strArray = new string[2]{ "226", "250" };
    string str = \u0005.\u0004.\u0001(obj0.\u0001);
    ((FTPConnect) obj0).\u0001 = \u0005.\u0004.\u0001(str, strArray, obj0.\u0001);
  }

  static Socket \u0001([In] FTPControlSocket obj0)
  {
    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    IPEndPoint localEP = new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0], 0);
    socket.Bind((EndPoint) localEP);
    socket.Listen(5);
    int port = ((IPEndPoint) socket.LocalEndPoint).Port;
    IPAddress address = ((IPEndPoint) socket.LocalEndPoint).Address;
    \u0005.\u0004.\u0001((IPEndPoint) socket.LocalEndPoint, obj0);
    return socket;
  }

  static bool \u0001(
    [In] string obj0,
    [In] List<string> obj1,
    [In] List<double> obj2,
    [In] List<string> obj3,
    [In] string obj4)
  {
    if (obj3.Count > 0 & obj1.Count > 0)
    {
      for (int index1 = 0; index1 <= obj3.Count - 1; ++index1)
      {
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        for (int startIndex = 0; startIndex <= obj3[index1].Length - 1; ++startIndex)
        {
          double num4 = (double) Convert.ToByte(Convert.ToChar(obj3[index1].Substring(startIndex, 1)));
          num1 += num4 * 17.92;
        }
        for (int startIndex = 0; startIndex <= obj1[0].Length - 1; ++startIndex)
        {
          double num5 = (double) Convert.ToByte(Convert.ToChar(obj1[0].Substring(startIndex, 1)));
          num2 += num5 * 47.93;
        }
        for (int startIndex = 0; startIndex <= obj4.Length - 1; ++startIndex)
        {
          double num6 = (double) Convert.ToByte(Convert.ToChar(obj4.Substring(startIndex, 1)));
          num3 += num6 * 51.95;
        }
        double num7 = (num1 + num2 + num3) * 9.912;
        for (int index2 = 0; index2 <= obj2.Count - 1; ++index2)
        {
          if (Math.Abs(obj2[index2] - num7) < 0.0001)
            return true;
        }
      }
      throw new RegisterException(obj0);
    }
    throw new RegisterException(obj0);
  }

  static void \u0001([In] byte[] obj0, [In] \u0004.\u0003.\u0004 obj1)
  {
    int[] numArray1 = new int[16 /*0x10*/];
    int[] numArray2 = new int[16 /*0x10*/];
    for (int index1 = 0; index1 < obj0.Length; ++index1)
    {
      int index2 = (int) obj0[index1];
      if (index2 > 0)
        ++numArray1[index2];
    }
    int num1 = 0;
    int length = 512 /*0x0200*/;
    for (int index = 1; index <= 15; ++index)
    {
      numArray2[index] = num1;
      num1 += numArray1[index] << 16 /*0x10*/ - index;
      if (index >= 10)
      {
        int num2 = numArray2[index] & 130944;
        int num3 = num1 & 130944;
        length += num3 - num2 >> 16 /*0x10*/ - index;
      }
    }
    ((\u0004.\u0003.\u0005) obj1).\u0001 = new short[length];
    int num4 = 512 /*0x0200*/;
    for (int index3 = 15; index3 >= 10; --index3)
    {
      int num5 = num1 & 130944;
      num1 -= numArray1[index3] << 16 /*0x10*/ - index3;
      for (int index4 = num1 & 130944; index4 < num5; index4 += 128 /*0x80*/)
      {
        ((\u0004.\u0003.\u0005) obj1).\u0001[(int) \u0005.\u0004.\u0001(index4)] = (short) (-num4 << 4 | index3);
        num4 += 1 << index3 - 9;
      }
    }
    for (int index5 = 0; index5 < obj0.Length; ++index5)
    {
      int index6 = (int) obj0[index5];
      if (index6 != 0)
      {
        int num6 = numArray2[index6];
        int index7 = (int) \u0005.\u0004.\u0001(num6);
        if (index6 <= 9)
        {
          do
          {
            ((\u0004.\u0003.\u0005) obj1).\u0001[index7] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < 512 /*0x0200*/);
        }
        else
        {
          int num7 = (int) ((\u0004.\u0003.\u0005) obj1).\u0001[index7 & 511 /*0x01FF*/];
          int num8 = 1 << (num7 & 15);
          int num9 = -(num7 >> 4);
          do
          {
            ((\u0004.\u0003.\u0005) obj1).\u0001[num9 | index7 >> 9] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < num8);
        }
        numArray2[index6] = num6 + (1 << 16 /*0x10*/ - index6);
      }
    }
  }

  static int \u0001([In] \u0004.\u0003.\u0002 obj0)
  {
    return ((\u0004.\u0003.\u0005) obj0).\u0002 - ((\u0004.\u0003.\u0004) obj0).\u0001 + (((\u0004.\u0003.\u0005) obj0).\u0003 >> 3);
  }

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_Connect")]
  static extern int \u0001();

  [DllImport("buPLCHandlerCore.dll", EntryPoint = "buPlcHandler_GetSymbols")]
  static extern unsafe uint \u0001([In] int obj0, [In] byte* obj1, [In] ref int obj2);

  static int \u0001([In] \u0004.\u0003.\u0003 obj0) => ((\u0004.\u0003.\u0005) obj0).\u0002;
}
