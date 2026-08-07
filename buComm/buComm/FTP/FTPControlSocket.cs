// Decompiled with JetBrains decompiler
// Type: buComm.FTP.FTPControlSocket
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using dummy_ptr;
using SmartAssembly.HouseOfCards;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

#nullable disable
namespace buComm.FTP;

public class FTPControlSocket
{
  public string RemoteFolder;
  public string RemoteFileName;
  public string LocalFileName;
  public bool Connected;
  public bool Login;
  public bool UseRevolveDNS;
  public static byte f00007E;

  static FTPControlSocket()
  {
    FTPConnectProperties.ftpConnectionProperties = (FTPConnectProperties) new FTPControlSocket();
    FTPConnectProperties.TotalLineCount = 0;
    FTPConnectProperties.SentLineCount = 0;
    FTPConnectProperties.SendPersentage = 0.0;
  }

  public FTPControlSocket()
  {
    ((FTPConnectProperties) this).IP = "192.168.10.50";
    ((FTPConnectProperties) this).Port = 21;
    ((FTPConnectProperties) this).UserName = "Admin";
    ((FTPConnectProperties) this).Password = "";
    this.RemoteFolder = "/";
    this.RemoteFileName = "";
    this.LocalFileName = "";
    this.Connected = false;
    this.Login = false;
    this.UseRevolveDNS = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public abstract void m0000C9();

  public FTPControlSocket(string remoteHost, int controlPort, StreamWriter log, int timeout)
  {
    ((FTPReply) this).\u0001 = false;
    ((FTPReply) this).\u0001 = Console.Out;
    // ISSUE: reference to a compiler-generated field
    ((\u0004.\u0001) this).\u0001 = -1;
    ((MemberRefsProxy) this).\u0001 = (Socket) null;
    ((MemberRefsProxy) this).\u0001 = (StreamWriter) null;
    ((\u0003.\u0001) this).\u0001 = (StreamReader) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).UseRevolveDNS)
    {
      FTPException.remoteHostEntry = Dns.GetHostEntry(remoteHost);
      \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D.\u0001(FTPException.remoteHostEntry.AddressList[0], timeout, controlPort, log, this);
    }
    else
      \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D.\u0001(IPAddress.Parse(FTPConnectProperties.ftpConnectionProperties.IP), timeout, controlPort, log, this);
  }

  public FTPControlSocket(IPAddress remoteAddr, int controlPort, StreamWriter log, int timeout)
  {
    ((FTPReply) this).\u0001 = false;
    ((FTPReply) this).\u0001 = Console.Out;
    // ISSUE: reference to a compiler-generated field
    ((\u0004.\u0001) this).\u0001 = -1;
    ((MemberRefsProxy) this).\u0001 = (Socket) null;
    ((MemberRefsProxy) this).\u0001 = (StreamWriter) null;
    ((\u0003.\u0001) this).\u0001 = (StreamReader) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D.\u0001(remoteAddr, timeout, controlPort, log, this);
  }
}
