// Decompiled with JetBrains decompiler
// Type: buCamera.CanonCCAPI.CanonCCAPI
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace buCamera.CanonCCAPI;

public class CanonCCAPI
{
  private static readonly HttpClient client = new HttpClient();
  private string cameraIp;
  public static string photoFile = (string) null;
  private string tvVal = (string) null;
  private string isoVal = (string) null;
  private string avVal = (string) null;

  public async Task<bool> TakePhotoAndProcessAsync(
    string saveFolder,
    string settingsFolder,
    bool isAuto = false)
  {
    try
    {
      StringContent content = new StringContent("{\"af\":true}", Encoding.UTF8, "application/json");
      if (!isAuto)
      {
        (this.tvVal, this.isoVal, this.avVal, _) = this.ReadCanonSettings(settingsFolder);
        int num1 = await this.SetShutterSpeedAsync(this.tvVal) ? 1 : 0;
        int num2 = await this.SetISOAsync(this.isoVal) ? 1 : 0;
        int num3 = await this.SetApertureAsync(this.avVal) ? 1 : 0;
      }
      List<string> beforeCapture = await this.GetPhotoListAsync();
      string sutterbtnUrl = this.cameraIp + "/ccapi/ver100/shooting/control/shutterbutton";
      HttpResponseMessage response = await buCamera.CanonCCAPI.CanonCCAPI.client.PostAsync(sutterbtnUrl, (HttpContent) content);
      if (!response.IsSuccessStatusCode)
      {
        int num = (int) MessageBox.Show("Fotoğraf çekilemedi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      await Task.Delay(1250);
      List<string> afterCapture = await this.GetPhotoListAsync();
      List<string> newFiles = afterCapture.Except<string>((IEnumerable<string>) beforeCapture).ToList<string>();
      if (newFiles.Count == 1)
      {
        string newFile = newFiles[0];
        byte[] photoBytes = await buCamera.CanonCCAPI.CanonCCAPI.client.GetByteArrayAsync($"{this.cameraIp}/ccapi/ver100/contents/sd/100CANON/{newFile}");
        Directory.CreateDirectory(saveFolder);
        string savePath = Path.Combine(saveFolder, newFile);
        File.WriteAllBytes(savePath, photoBytes);
        buCamera.CanonCCAPI.CanonCCAPI.photoFile = savePath;
        HttpResponseMessage deleteResponse = await buCamera.CanonCCAPI.CanonCCAPI.client.DeleteAsync($"{this.cameraIp}/ccapi/ver100/contents/sd/100CANON/{newFile}");
        if (deleteResponse.IsSuccessStatusCode)
        {
          Console.WriteLine("Başarıyla çekildi, kaydedildi ve kameradan silindi: " + newFile);
          return true;
        }
        int num = (int) MessageBox.Show("Fotoğraf indirildi ama kameradan silinemedi.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      int num4 = (int) MessageBox.Show("Yeni fotoğraf tespit edilemedi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Hata oluştu: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
  }

  private async Task<List<string>> GetPhotoListAsync()
  {
    try
    {
      HttpResponseMessage response = await buCamera.CanonCCAPI.CanonCCAPI.client.GetAsync(this.cameraIp + "/ccapi/ver100/contents/sd/100CANON/");
      if (response.IsSuccessStatusCode)
      {
        string jsonString = await response.Content.ReadAsStringAsync();
        JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
        JsonElement urlArray;
        if (jsonDoc.RootElement.TryGetProperty("url", out urlArray))
        {
          List<string> photoNames = new List<string>();
          foreach (JsonElement enumerate in urlArray.EnumerateArray())
          {
            JsonElement urlElement = enumerate;
            string fullUrl = urlElement.GetString();
            if (!string.IsNullOrEmpty(fullUrl))
            {
              string filename = Path.GetFileName(fullUrl);
              photoNames.Add(filename);
              filename = (string) null;
            }
            fullUrl = (string) null;
            urlElement = new JsonElement();
          }
          return photoNames;
        }
        jsonString = (string) null;
        jsonDoc = (JsonDocument) null;
        urlArray = new JsonElement();
      }
      response = (HttpResponseMessage) null;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Fotoğraf listesi alınamadı: " + ex.Message);
    }
    return new List<string>();
  }

  public async Task<bool> SetShutterSpeedAsync(string shutterSpeed)
  {
    try
    {
      string url = this.cameraIp + "/ccapi/ver100/shooting/settings/tv";
      StringContent content = new StringContent($"{{ \"value\": \"{shutterSpeed}\" }}", Encoding.UTF8, "application/json");
      HttpResponseMessage response = await buCamera.CanonCCAPI.CanonCCAPI.client.PutAsync(url, (HttpContent) content);
      if (response.IsSuccessStatusCode)
        return true;
      string error = await response.Content.ReadAsStringAsync();
      Console.WriteLine($"SetShutterSpeed failed with {shutterSpeed}. Error: {error}");
      string altShutterSpeed = shutterSpeed + ".0";
      content = new StringContent($"{{ \"value\": \"{altShutterSpeed}\" }}", Encoding.UTF8, "application/json");
      response = await buCamera.CanonCCAPI.CanonCCAPI.client.PutAsync(url, (HttpContent) content);
      if (response.IsSuccessStatusCode)
        return true;
      error = await response.Content.ReadAsStringAsync();
      int num = (int) MessageBox.Show($"Failed to set shutter speed to {shutterSpeed}. Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error setting shutter speed: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
  }

  public async Task<bool> SetISOAsync(string iso)
  {
    try
    {
      string url = this.cameraIp + "/ccapi/ver100/shooting/settings/iso";
      StringContent content = new StringContent($"{{ \"value\": \"{iso}\" }}", Encoding.UTF8, "application/json");
      HttpResponseMessage response = await buCamera.CanonCCAPI.CanonCCAPI.client.PutAsync(url, (HttpContent) content);
      if (response.IsSuccessStatusCode)
        return true;
      int num = (int) MessageBox.Show($"Failed to set ISO to {iso}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error setting ISO: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
  }

  public async Task<bool> SetApertureAsync(string aperture)
  {
    string formattedAperture = aperture.StartsWith("f") ? aperture : "f" + aperture;
    try
    {
      string url = this.cameraIp + "/ccapi/ver100/shooting/settings/av";
      StringContent content = new StringContent($"{{ \"value\": \"{formattedAperture}\" }}", Encoding.UTF8, "application/json");
      HttpResponseMessage response = await buCamera.CanonCCAPI.CanonCCAPI.client.PutAsync(url, (HttpContent) content);
      if (response.IsSuccessStatusCode)
        return true;
      int num = (int) MessageBox.Show($"Failed to set aperture to {formattedAperture}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error setting aperture: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }
  }

  public (string, string, string) ReadCameraSettingsAsync(bool isWifi, string filePath)
  {
    try
    {
      string[] strArray = File.ReadAllLines(filePath);
      string uriString = strArray.Length >= 4 ? strArray[0].Trim() : throw new FormatException("Settings file must contain exactly four lines: IP address, shutter speed, ISO, aperture.");
      string s1 = strArray[1].Trim();
      string s2 = strArray[2].Trim();
      string s3 = strArray[3].Trim();
      if (string.IsNullOrEmpty(uriString) || string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || string.IsNullOrEmpty(s3))
        throw new FormatException("Settings file contains empty or invalid lines.");
      this.cameraIp = Uri.TryCreate(uriString, UriKind.Absolute, out Uri _) && uriString.StartsWith("http://") && uriString.Contains(":") ? uriString : throw new FormatException("IP address must be in the format 'http://[IP]:[port]', e.g., 'http://192.168.1.100:8080'.");
      double result;
      if (!s1.Contains("/") && s1 != "bulb" && !double.TryParse(s1, out result))
        throw new FormatException("Shutter speed must be in the format '1/250' or 'bulb'.");
      if (!double.TryParse(s2, out result) && s2 != "auto")
        throw new FormatException("ISO must be a number like '400' or 'auto'.");
      if (!double.TryParse(s3, out result))
        throw new FormatException("Aperture must be a number like '5.6'.");
      return (s1, s2, s3);
    }
    catch (FileNotFoundException ex)
    {
      int num = (int) MessageBox.Show("Settings file not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    catch (FormatException ex)
    {
      int num = (int) MessageBox.Show("Invalid settings file format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error reading settings file: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
  }

  public (string, string, string, bool) ReadCanonSettings(string cameraSettings)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    bool result = false;
    string empty4 = string.Empty;
    string str1;
    string str2;
    string str3;
    try
    {
      string[] strArray = File.ReadAllLines(cameraSettings);
      this.cameraIp = strArray.Length >= 5 ? GetValue(strArray[0]) : throw new Exception("Camera settings file does not contain enough lines.");
      if (string.IsNullOrWhiteSpace(this.cameraIp))
        throw new Exception("IP Adress cannot be empty.");
      str1 = GetValue(strArray[1]);
      if (string.IsNullOrWhiteSpace(str1))
        throw new Exception("TV (Shutter speed) cannot be empty.");
      str2 = GetValue(strArray[2]);
      if (string.IsNullOrWhiteSpace(str2))
        throw new Exception("ISO cannot be empty.");
      str3 = GetValue(strArray[3]);
      if (string.IsNullOrWhiteSpace(str3))
        throw new Exception("AV (Aperture) cannot be empty.");
      string str4 = GetValue(strArray[4]);
      if (!bool.TryParse(str4, out result))
        throw new Exception("Invalid boolean value for Quick Mode: " + str4);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing camera settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    return (str1, str2, str3, result);

    static string GetValue(string line)
    {
      int num = line.IndexOf(": ");
      if (num == -1 || num + 2 >= line.Length)
        throw new Exception("Invalid format in line: " + line);
      return line.Substring(num + 2).Trim();
    }
  }

  public void WriteCameraSettingsAsync(
    bool isWifi,
    string filePath,
    string tv,
    string iso,
    string av)
  {
    try
    {
      if (string.IsNullOrWhiteSpace(filePath))
        throw new ArgumentNullException(nameof (filePath), "File path cannot be null or empty.");
      if (string.IsNullOrWhiteSpace(tv))
        throw new ArgumentNullException(nameof (tv), "Shutter speed cannot be null or empty.");
      if (string.IsNullOrWhiteSpace(iso))
        throw new ArgumentNullException(nameof (iso), "ISO cannot be null or empty.");
      if (string.IsNullOrWhiteSpace(av))
        throw new ArgumentNullException(nameof (av), "Aperture cannot be null or empty.");
      if (isWifi && string.IsNullOrWhiteSpace(this.cameraIp))
        throw new InvalidOperationException("Camera IP address is not set.");
      double result;
      if (!tv.Contains("/") && tv != "bulb" && !double.TryParse(tv, out result))
        throw new FormatException("Shutter speed must be in the format '1/250' or 'bulb'.");
      if (!double.TryParse(iso, out result) && iso != "auto")
        throw new FormatException("ISO must be a number like '400' or 'auto'.");
      if (!double.TryParse(av, out result))
        throw new FormatException("Aperture must be a number like '5.6'.");
      string str = File.ReadAllLines(filePath)[4].Trim();
      string[] strArray = new string[4];
      string[] contents = new string[5]
      {
        "IP Adress: " + this.cameraIp,
        "TV: " + tv,
        "ISO" + iso,
        "AV: " + av,
        "Quick Mode: " + str
      };
      File.WriteAllLines(filePath, contents);
    }
    catch (ArgumentNullException ex)
    {
      int num = (int) MessageBox.Show("Invalid input: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    catch (FormatException ex)
    {
      int num = (int) MessageBox.Show("Invalid format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    catch (IOException ex)
    {
      int num = (int) MessageBox.Show("Error writing to settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Unexpected error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
  }

  public void WriteCanonSettings(
    string cameraSettings,
    string tv,
    string iso,
    string av,
    bool isQuick)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(cameraSettings))
      {
        if (string.IsNullOrWhiteSpace(this.cameraIp))
          throw new Exception("IP Adress cannot be empty.");
        streamWriter.WriteLine("IP Adress: " + this.cameraIp);
        if (string.IsNullOrWhiteSpace(tv))
          throw new Exception("TV (Shutter speed) cannot be empty.");
        streamWriter.WriteLine("TV: " + tv);
        if (string.IsNullOrWhiteSpace(iso))
          throw new Exception("ISO cannot be empty.");
        streamWriter.WriteLine("ISO: " + iso);
        if (string.IsNullOrWhiteSpace(av))
          throw new Exception("AV (Aperture) cannot be empty.");
        streamWriter.WriteLine("AV: " + av);
        streamWriter.WriteLine($"Quick Mode: {isQuick}");
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing to camera settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
  }

  public class CanonContents
  {
    public List<buCamera.CanonCCAPI.CanonCCAPI.CanonFile> files { get; set; }
  }

  public class CanonFile
  {
    public string name { get; set; }
  }
}
