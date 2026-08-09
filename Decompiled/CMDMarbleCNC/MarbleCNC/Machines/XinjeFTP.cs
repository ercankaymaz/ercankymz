using System;
using System.IO;
using System.Net;

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
			if (!File.Exists(localFilePath))
			{
				return false;
			}
			string text = "/Share_files_anonymity/".Trim('/');
			string requestUriString = "ftp://192.168.6.6/" + text + "/" + targetName;
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(requestUriString);
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential("", "");
			ftpWebRequest.KeepAlive = false;
			ftpWebRequest.UsePassive = true;
			ftpWebRequest.UseBinary = true;
			ftpWebRequest.Timeout = 5000;
			byte[] array = File.ReadAllBytes(localFilePath);
			ftpWebRequest.ContentLength = array.Length;
			using (Stream stream = ftpWebRequest.GetRequestStream())
			{
				stream.Write(array, 0, array.Length);
				stream.Close();
			}
			using ((FtpWebResponse)ftpWebRequest.GetResponse())
			{
				Console.WriteLine("Başarılı: " + targetName + " yüklendi.");
				return true;
			}
		}
		catch (WebException ex)
		{
			if (ex.Response != null)
			{
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ex.Response;
				Console.WriteLine("PLC REDDİ (553): " + ftpWebResponse.StatusDescription + " | Adres: 192.168.6.6");
			}
			return false;
		}
		catch (Exception ex2)
		{
			Console.WriteLine("Sistem Hatası: " + ex2.Message);
			return false;
		}
	}
}
