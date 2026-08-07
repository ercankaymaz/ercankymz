// Decompiled with JetBrains decompiler
// Type: buComm.FTP.FTPConnectProperties
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

#nullable disable
namespace buComm.FTP;

public class FTPConnectProperties
{
  public FTPClient ftpClient = (FTPClient) null;
  public static FTPConnectProperties ftpConnectionProperties;
  public static int TotalLineCount;
  public static int SentLineCount;
  public static double SendPersentage;
  public static byte f000073;
  public string IP;
  public int Port;
  public string UserName;
  public string Password;
}
