// Decompiled with JetBrains decompiler
// Type: buComm.FTP.FTPException
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using buClass;
using SmartAssembly.HouseOfCards;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace buComm.FTP;

public class FTPException : Exception
{
  public static IPHostEntry remoteHostEntry;

  public void Logout()
  {
    ((FTPReply) this).\u0001.Flush();
    ((FTPReply) this).\u0001 = (TextWriter) null;
    ((MemberRefsProxy) this).\u0001.Close();
    ((\u0003.\u0001) this).\u0001.Close();
  }

  protected internal byte[] ToByteArray(ushort val)
  {
    return new byte[2]
    {
      (byte) ((uint) val >> 8),
      (byte) ((uint) val & (uint) byte.MaxValue)
    };
  }

  internal Socket \u0001()
  {
    string str1 = \u0005.\u0004.\u0001((FTPControlSocket) this, "PASV");
    \u0005.\u0004.\u0001("227", str1, (FTPControlSocket) this);
    int num1 = str1.IndexOf('(');
    int num2 = str1.IndexOf(')');
    if ((num1 >= 0 ? 0 : (num2 < 0 ? 1 : 0)) != 0)
    {
      num1 = str1.ToUpper().LastIndexOf("MODE") + 4;
      num2 = str1.Length;
    }
    string str2 = str1.Substring(num1 + 1, num2 - (num1 + 1));
    int[] numArray = new int[6];
    int length = str2.Length;
    int num3 = 0;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; (index < length ? (num3 <= 6 ? 1 : 0) : 0) != 0; ++index)
    {
      char c = str2[index];
      if (char.IsDigit(c))
        stringBuilder.Append(c);
      else if (c != ',')
        throw new FTPReply("Malformed PASV reply: " + str1);
      if ((c == ',' ? 1 : (index + 1 == length ? 1 : 0)) != 0)
      {
        try
        {
          numArray[num3++] = int.Parse(stringBuilder.ToString());
          stringBuilder.Length = 0;
        }
        catch (FormatException ex)
        {
          buLog.addLog("Malformed PASV reply: " + str1, "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "Malformed PASV reply: " + str1);
        }
      }
    }
    string hostNameOrAddress = $"{numArray[0].ToString()}.{numArray[1].ToString()}.{numArray[2].ToString()}.{numArray[3].ToString()}";
    int port = (numArray[4] << 8) + numArray[5];
    if (((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).UseRevolveDNS)
    {
      if (FTPException.remoteHostEntry == null)
        FTPException.remoteHostEntry = Dns.GetHostEntry(hostNameOrAddress);
      IPEndPoint remoteEP = new IPEndPoint(FTPException.remoteHostEntry.AddressList[0], port);
      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      // ISSUE: reference to a compiler-generated field
      \u0005.\u0004.\u0001((FTPControlSocket) this, socket, ((\u0004.\u0001) this).\u0001);
      socket.Connect((EndPoint) remoteEP);
      return socket;
    }
    IPEndPoint remoteEP1 = new IPEndPoint(IPAddress.Parse(FTPConnectProperties.ftpConnectionProperties.IP), port);
    Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    // ISSUE: reference to a compiler-generated field
    \u0005.\u0004.\u0001((FTPControlSocket) this, socket1, ((\u0004.\u0001) this).\u0001);
    socket1.Connect((EndPoint) remoteEP1);
    return socket1;
  }

  public int ReplyCode
  {
    [SpecialName] get => ((\u0003.\u0002) this).\u0001;
  }
}
