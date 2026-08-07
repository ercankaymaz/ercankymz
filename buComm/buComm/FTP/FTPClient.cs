// Decompiled with JetBrains decompiler
// Type: buComm.FTP.FTPClient
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0005;
using buClass;
using dummy_ptr;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buComm.FTP;

public class FTPClient
{
  public const FTPConnectMode PASV = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const FTPTransferType ASCII = FTPTransferType.ACTIVE;
  public const FTPTransferType BINARY = (FTPTransferType) 2;
  private static string \u0001;
  private static string \u0002;
  private static string \u0003;
  internal FTPControlSocket \u0001;
  internal Socket \u0001;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    ushort id,
    byte unit,
    byte function,
    byte exception,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public event FtpFileSendEventHandler FileSending;

  public int Timeout
  {
    set
    {
      ((FTPConnect) this).\u0001 = value;
      \u0004.\u0001(value, this.\u0001);
    }
  }

  public FTPConnectMode ConnectMode
  {
    set
    {
      // ISSUE: unable to decompile the method.
    }
  }

  public FTPReply LastValidReply => ((FTPConnect) this).\u0001;

  public StreamWriter LogStream
  {
    set => \u0004.\u0001(value, this.\u0001);
  }

  public FTPTransferType TransferType
  {
    get => ((FTPConnect) this).\u0001;
    set
    {
      string str = FTPClient.\u0003;
      if (value.Equals((object) (FTPTransferType) 2))
        str = FTPClient.\u0002;
      ((FTPConnect) this).\u0001 = \u0004.\u0001("200", \u0004.\u0001(this.\u0001, "TYPE " + str), this.\u0001);
      ((FTPConnect) this).\u0001 = value;
    }
  }

  public FTPClient(string remoteHost)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(string remoteHost, int controlPort)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(IPAddress remoteAddr)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(IPAddress remoteAddr, int controlPort)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(string remoteHost, StreamWriter log, int timeout)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(string remoteHost, int controlPort, StreamWriter log, int timeout)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(IPAddress remoteAddr, StreamWriter log, int timeout)
  {
    // ISSUE: unable to decompile the method.
  }

  public FTPClient(IPAddress remoteAddr, int controlPort, StreamWriter log, int timeout)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool Login(string user, string password)
  {
    FTPReply ftpReply1 = \u0004.\u0001("331", \u0004.\u0001(this.\u0001, "USER " + user), this.\u0001);
    FTPReply ftpReply2 = \u0004.\u0001("230", \u0004.\u0001(this.\u0001, "PASS " + password), this.\u0001);
    return ftpReply1 != null & ftpReply2 != null && ((Strings) ftpReply1).get_ReplyCode().Trim() == "331" & ((Strings) ftpReply2).get_ReplyCode().Trim() == "230";
  }

  public void User(string user)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001(\u0004.\u0001(this.\u0001, "USER " + user), new string[2]
    {
      "230",
      "331"
    }, this.\u0001);
  }

  public void Password(string password)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001(\u0004.\u0001(this.\u0001, "PASS " + password), new string[2]
    {
      "230",
      "202"
    }, this.\u0001);
  }

  public void Quote(string command, string[] validCodes)
  {
    string str = \u0004.\u0001(this.\u0001, command);
    if ((validCodes == null ? 0 : (validCodes.Length != 0 ? 1 : 0)) == 0)
      return;
    ((FTPConnect) this).\u0001 = \u0004.\u0001(str, validCodes, this.\u0001);
  }

  public void Put(string localPath, string remoteFile) => this.Put(localPath, remoteFile, false);

  public void Put(Stream srcStream, string remoteFile) => this.Put(srcStream, remoteFile, false);

  public void Put(string localPath, string remoteFile, bool append)
  {
    if (this.TransferType == FTPTransferType.ACTIVE)
      \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D.\u0001(append, this, localPath, remoteFile);
    else
      \u0004.\u0001(localPath, append, remoteFile, this);
    \u0004.\u0001(this);
  }

  public void Put(Stream srcStream, string remoteFile, bool append)
  {
    if (this.TransferType == FTPTransferType.ACTIVE)
      \u0004.\u0001(srcStream, this, append, remoteFile);
    else
      \u0004.\u0001(remoteFile, this, append, srcStream);
    \u0004.\u0001(this);
  }

  public void Put(byte[] bytes, string remoteFile) => this.Put(bytes, remoteFile, false);

  public void Put(byte[] bytes, string remoteFile, bool append)
  {
    \u0004.\u0001(append, remoteFile, this);
    BinaryWriter binaryWriter = new BinaryWriter((Stream) \u0004.\u0001(this));
    binaryWriter.Write(bytes, 0, bytes.Length);
    binaryWriter.Flush();
    binaryWriter.Close();
    \u0004.\u0001(this);
  }

  public void Get(string localPath, string remoteFile)
  {
    if (this.TransferType == FTPTransferType.ACTIVE)
      \u007B3e3a94b6\u002D3ce3\u002D4943\u002D9bb0\u002D2439d20be70c\u007D.\u0001(remoteFile, localPath, this);
    else
      \u0004.\u0001(remoteFile, this, localPath);
    \u0004.\u0001(this);
  }

  public void Get(Stream destStream, string remoteFile)
  {
    if (this.TransferType == FTPTransferType.ACTIVE)
      \u0004.\u0001(remoteFile, destStream, this);
    else
      \u0004.\u0001(remoteFile, destStream, this);
    \u0004.\u0001(this);
  }

  public byte[] Get(string remoteFile)
  {
    \u0004.\u0001(remoteFile, this);
    BinaryReader binaryReader = new BinaryReader((Stream) \u0004.\u0001(this));
    byte[] buffer = new byte[4096 /*0x1000*/];
    MemoryStream memoryStream = new MemoryStream(4096 /*0x1000*/);
    int count;
    while ((count = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
      memoryStream.Write(buffer, 0, count);
    memoryStream.Close();
    try
    {
      binaryReader.Close();
    }
    catch (IOException ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException((Exception) ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
    \u0004.\u0001(this);
    return memoryStream.ToArray();
  }

  public bool Site(string command)
  {
    string str = \u0004.\u0001(this.\u0001, "SITE " + command);
    string[] strArray = new string[3]{ "200", "202", "502" };
    ((FTPConnect) this).\u0001 = \u0004.\u0001(str, strArray, this.\u0001);
    return str.Substring(0, 3).Equals("200");
  }

  public string[] Dir() => this.Dir((string) null, false);

  public string[] Dir(string dirname) => this.Dir(dirname, false);

  public string[] Dir(string dirname, bool full)
  {
    // ISSUE: unable to decompile the method.
  }

  public void DebugResponses(bool on) => ((FTPReply) this.\u0001).\u0001 = on;

  public void Delete(string remoteFile)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("250", \u0004.\u0001(this.\u0001, "DELE " + remoteFile), this.\u0001);
  }

  public void Rename(string from, string to)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("350", \u0004.\u0001(this.\u0001, "RNFR " + from), this.\u0001);
    ((FTPConnect) this).\u0001 = \u0004.\u0001("250", \u0004.\u0001(this.\u0001, "RNTO " + to), this.\u0001);
  }

  public void Rmdir(string dir)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001(\u0004.\u0001(this.\u0001, "RMD " + dir), new string[2]
    {
      "250",
      "257"
    }, this.\u0001);
  }

  public void Mkdir(string dir)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("257", \u0004.\u0001(this.\u0001, "MKD " + dir), this.\u0001);
  }

  public void Chdir(string dir)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("250", \u0004.\u0001(this.\u0001, "CWD " + dir), this.\u0001);
  }

  public DateTime ModTime(string remoteFile)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("213", \u0004.\u0001(this.\u0001, "MDTM " + remoteFile), this.\u0001);
    return DateTime.ParseExact(((GetString) ((FTPConnect) this).\u0001).get_ReplyText(), FTPClient.\u0001, (IFormatProvider) null);
  }

  public string Pwd()
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("257", \u0004.\u0001(this.\u0001, "PWD"), this.\u0001);
    string str = ((GetString) ((FTPConnect) this).\u0001).get_ReplyText();
    int num1 = str.IndexOf('"');
    int num2 = str.LastIndexOf('"');
    return (num1 < 0 ? 0 : (num2 > num1 ? 1 : 0)) == 0 ? str : str.Substring(num1 + 1, num2 - (num1 + 1));
  }

  public string SystemFTP()
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001("215", \u0004.\u0001(this.\u0001, "SYST"), this.\u0001);
    return ((GetString) ((FTPConnect) this).\u0001).get_ReplyText();
  }

  public string Help(string command)
  {
    ((FTPConnect) this).\u0001 = \u0004.\u0001(\u0004.\u0001(this.\u0001, "HELP " + command), new string[2]
    {
      "211",
      "214"
    }, this.\u0001);
    return ((GetString) ((FTPConnect) this).\u0001).get_ReplyText();
  }
}
