// Decompiled with JetBrains decompiler
// Type: MarbleCNC.Machines.XinjeFTP
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using System;
using System.IO;
using System.Net;

#nullable disable
namespace MarbleCNC.Machines;

public class XinjeFTP
{
  private const string FtpIp = "192.168.6.6";
  private const string FtpTargetFolder = "/Share_files_anonymity/";
  private const string FtpUser = "";
  private const string FtpPass = "";

  public static bool UploadCncFile(string localFilePath, string targetName)
  {
    try
    {
      if (!System.IO.File.Exists(localFilePath))
        return false;
      FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create($"ftp://192.168.6.6/{"/Share_files_anonymity/".Trim('/')}/{targetName}");
      ftpWebRequest.Method = "STOR";
      ftpWebRequest.Credentials = (ICredentials) new NetworkCredential("", "");
      ftpWebRequest.KeepAlive = false;
      ftpWebRequest.UsePassive = true;
      ftpWebRequest.UseBinary = true;
      ftpWebRequest.Timeout = 5000;
      byte[] buffer = System.IO.File.ReadAllBytes(localFilePath);
      ftpWebRequest.ContentLength = (long) buffer.Length;
      using (Stream requestStream = ftpWebRequest.GetRequestStream())
      {
        requestStream.Write(buffer, 0, buffer.Length);
        requestStream.Close();
      }
      using ((FtpWebResponse) ftpWebRequest.GetResponse())
      {
        Console.WriteLine($"Başarılı: {targetName} yüklendi.");
        return true;
      }
    }
    catch (WebException ex)
    {
      if (ex.Response != null)
        Console.WriteLine($"PLC REDDİ (553): {((FtpWebResponse) ex.Response).StatusDescription} | Adres: 192.168.6.6");
      return false;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Sistem Hatası: " + ex.Message);
      return false;
    }
  }
}
