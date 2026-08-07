// Decompiled with JetBrains decompiler
// Type: buComm.FTP.FTPConnect
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0005;
using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buComm.FTP;

public class FTPConnect
{
  private int \u0001;
  private FTPTransferType \u0001;
  internal FTPConnectMode \u0001;
  internal FTPReply \u0001;
  public static byte f00006D;

  public void Quit()
  {
    try
    {
      this.\u0001 = \u0004.\u0001(\u0004.\u0001(((FTPClient) this).\u0001, "QUIT"), new string[2]
      {
        "221",
        "226"
      }, ((FTPClient) this).\u0001);
    }
    finally
    {
      ((FTPException) ((FTPClient) this).\u0001).Logout();
      ((FTPClient) this).\u0001 = (FTPControlSocket) null;
    }
  }

  static FTPConnect()
  {
    FTPClient.\u0001 = "yyyyMMddHHmmss";
    FTPClient.\u0002 = "I";
    FTPClient.\u0003 = "A";
  }

  public void FtpClientConnect()
  {
    try
    {
      ((FTPConnectProperties) this).ftpClient = new FTPClient(FTPConnectProperties.ftpConnectionProperties.IP);
      ((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).Connected = false;
      ((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).Connected = ((FTPConnectProperties) this).ftpClient.Login(FTPConnectProperties.ftpConnectionProperties.UserName, FTPConnectProperties.ftpConnectionProperties.Password);
    }
    catch (Exception ex)
    {
      ((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).Connected = false;
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public void FtpClientDisConnect()
  {
    try
    {
      if (((FTPConnectProperties) this).ftpClient == null)
        return;
      ((FTPConnect) ((FTPConnectProperties) this).ftpClient).Quit();
      ((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).Connected = false;
    }
    catch (Exception ex)
    {
      ((FTPControlSocket) FTPConnectProperties.ftpConnectionProperties).Connected = false;
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public bool FtpClientFileTransfer(string FileName, string RemoteFileName)
  {
    try
    {
      FTPConnectProperties.SentLineCount = 0;
      if (((FTPConnectProperties) this).ftpClient == null)
        return false;
      ((FTPConnectProperties) this).ftpClient.Put(FileName, RemoteFileName);
      return true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return false;
    }
  }

  public bool FtpClientFileRecieve(string FileName, string RemoteFileName)
  {
    try
    {
      FTPConnectProperties.SentLineCount = 0;
      if (((FTPConnectProperties) this).ftpClient == null)
        return false;
      ((FTPConnectProperties) this).ftpClient.Get(FileName, RemoteFileName);
      return true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return false;
    }
  }
}
