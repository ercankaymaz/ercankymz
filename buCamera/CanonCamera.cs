// Decompiled with JetBrains decompiler
// Type: buCamera.Canoncamera.CanonCamera
// Assembly: buCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 458B46D1-65F2-4D88-8223-244FCE315356
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCamera.dll

using EDSDKLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace buCamera.Canoncamera;

public class CanonCamera
{
  private IntPtr _camera;
  private CanonSDK _sdk;
  private string _lastSavePath;
  private PictureBox _lastPictureBox;
  private bool _downloaded;
  private EDSDK.EdsObjectEventHandler _myObjectEventHandler;
  private EDSDK.EdsObjectEventHandler _takePhotoEventHandler;
  private TaskCompletionSource<bool> _photoTaskCompletionSource;
  public readonly Dictionary<string, uint> TvValues = new Dictionary<string, uint>()
  {
    {
      "30''",
      16U /*0x10*/
    },
    {
      "25''",
      19U
    },
    {
      "15''",
      24U
    },
    {
      "13''",
      27U
    },
    {
      "10''",
      29U
    },
    {
      "8''",
      32U /*0x20*/
    },
    {
      "6''",
      35U
    },
    {
      "5''",
      37U
    },
    {
      "4''",
      40U
    },
    {
      "3''2",
      43U
    },
    {
      "2''5",
      45U
    },
    {
      "2''",
      48U /*0x30*/
    },
    {
      "1''6",
      51U
    },
    {
      "1''3",
      53U
    },
    {
      "1''",
      56U
    },
    {
      "0''8",
      59U
    },
    {
      "0''6",
      61U
    },
    {
      "0''5",
      64U /*0x40*/
    },
    {
      "0''4",
      67U
    },
    {
      "0''3",
      69U
    },
    {
      "1/4",
      72U
    },
    {
      "1/5",
      75U
    },
    {
      "1/6",
      77U
    },
    {
      "1/8",
      80U /*0x50*/
    },
    {
      "1/13",
      85U
    },
    {
      "1/15",
      88U
    },
    {
      "1/20",
      92U
    },
    {
      "1/25",
      93U
    },
    {
      "1/30",
      96U /*0x60*/
    },
    {
      "1/40",
      99U
    },
    {
      "1/50",
      101U
    },
    {
      "1/60",
      104U
    },
    {
      "1/80",
      107U
    },
    {
      "1/100",
      109U
    },
    {
      "1/125",
      112U /*0x70*/
    },
    {
      "1/160",
      115U
    },
    {
      "1/200",
      117U
    },
    {
      "1/250",
      120U
    },
    {
      "1/320",
      123U
    },
    {
      "1/400",
      125U
    },
    {
      "1/500",
      128U /*0x80*/
    },
    {
      "1/640",
      131U
    },
    {
      "1/800",
      133U
    },
    {
      "1/1000",
      136U
    },
    {
      "1/1250",
      139U
    },
    {
      "1/1600",
      141U
    },
    {
      "1/2000",
      144U /*0x90*/
    },
    {
      "1/2500",
      147U
    },
    {
      "1/3200",
      149U
    },
    {
      "1/4000",
      152U
    }
  };
  public readonly Dictionary<string, uint> IsoValues = new Dictionary<string, uint>()
  {
    {
      "Auto",
      0U
    },
    {
      "100",
      72U
    },
    {
      "200",
      80U /*0x50*/
    },
    {
      "400",
      88U
    },
    {
      "800",
      96U /*0x60*/
    },
    {
      "1600",
      104U
    },
    {
      "3200",
      112U /*0x70*/
    },
    {
      "6400",
      120U
    }
  };
  public readonly Dictionary<string, uint> AvValues = new Dictionary<string, uint>()
  {
    {
      "4.5",
      43U
    },
    {
      "5.0",
      45U
    },
    {
      "5.6",
      48U /*0x30*/
    },
    {
      "6.3",
      51U
    },
    {
      "7.1",
      53U
    },
    {
      "8.0",
      56U
    },
    {
      "9.0",
      59U
    },
    {
      "10",
      61U
    },
    {
      "11",
      64U /*0x40*/
    },
    {
      "13",
      67U
    },
    {
      "14",
      69U
    },
    {
      "16",
      72U
    },
    {
      "18",
      75U
    },
    {
      "20",
      77U
    },
    {
      "22",
      80U /*0x50*/
    },
    {
      "25",
      83U
    },
    {
      "29",
      85U
    }
  };

  public bool CameraDetected { get; private set; } = false;

  public CanonCamera(CanonSDK sdk)
  {
    this._sdk = sdk;
    IntPtr outCameraListRef;
    int cameraList = (int) EDSDK.EdsGetCameraList(out outCameraListRef);
    int outCount;
    int childCount = (int) EDSDK.EdsGetChildCount(outCameraListRef, out outCount);
    if (outCount > 0)
    {
      int childAtIndex = (int) EDSDK.EdsGetChildAtIndex(outCameraListRef, 0, out this._camera);
      int num1 = (int) EDSDK.EdsOpenSession(this._camera);
      this.CameraDetected = true;
      this._myObjectEventHandler = (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
      {
        if (inEvent == 516U || inEvent == 520U)
        {
          this.DownloadDirItem(inRef, this._lastSavePath);
          this._downloaded = true;
          this._photoTaskCompletionSource?.TrySetResult(true);
        }
        return 0;
      });
      uint num2 = EDSDK.EdsSetPropertyData(this._camera, 11U, 0, 4, (object) 1U);
      if (num2 > 0U)
      {
        int num3 = (int) MessageBox.Show("SaveTo failed: " + num2.ToString());
      }
      uint num4 = EDSDK.EdsSetCapacity(this._camera, new EDSDK.EdsCapacity()
      {
        NumberOfFreeClusters = int.MaxValue,
        BytesPerSector = 4096 /*0x1000*/,
        Reset = 1
      });
      if (num4 <= 0U)
        return;
      int num5 = (int) MessageBox.Show("SetCapacity failed: " + num4.ToString());
    }
    else
    {
      this.CameraDetected = true;
      throw new Exception("No camera found");
    }
  }

  private EDSDK.EdsObjectEventHandler MyObjectEventHandler
  {
    get
    {
      return (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
      {
        if (inEvent == 516U || inEvent == 520U)
        {
          this.DownloadDirItem(inRef, this._lastSavePath);
          this.DisplayImageInPictureBoxV2(this._lastSavePath, this._lastPictureBox);
          this._downloaded = true;
        }
        return 0;
      });
    }
  }

  public void CloseSession()
  {
    if (!(this._camera != IntPtr.Zero))
      return;
    int num1 = (int) EDSDK.EdsCloseSession(this._camera);
    int num2 = (int) EDSDK.EdsRelease(this._camera);
  }

  public void SetImageQualityToLargeJpeg()
  {
    uint inPropertyID = 256 /*0x0100*/;
    uint[] numArray = new uint[2]
    {
      1048591U /*0x10000F*/,
      2031631U
    };
    int num1 = Marshal.SizeOf(typeof (uint));
    IntPtr num2 = Marshal.AllocHGlobal(num1);
    try
    {
      int num3 = (int) EDSDK.EdsSetCapacity(this._camera, new EDSDK.EdsCapacity()
      {
        NumberOfFreeClusters = int.MaxValue,
        BytesPerSector = 4096 /*0x1000*/,
        Reset = 1
      });
      uint num4 = 0;
      bool flag = false;
      foreach (uint val in numArray)
      {
        Marshal.WriteInt32(num2, (int) val);
        for (int index = 0; index < 3; ++index)
        {
          num4 = EDSDK.EdsSetPropertyData(this._camera, inPropertyID, 0, num1, (object) num2);
          switch (num4)
          {
            case 0:
              flag = true;
              goto label_7;
            case 2147483675 /*0x8000001B*/:
              Thread.Sleep(500);
              continue;
            default:
              goto label_7;
          }
        }
label_7:
        if (flag)
          break;
      }
      if (flag)
        return;
      Console.WriteLine("Could not force JPEG. Error: " + num4.ToString());
    }
    catch (Exception ex)
    {
      Console.WriteLine("Exception setting image quality: " + ex.Message);
    }
    finally
    {
      Marshal.FreeHGlobal(num2);
    }
  }

  public void TakeAndSavePhotoOld(string savePath, PictureBox pictureBox)
  {
    if (EDSDK.EdsSendCommand(this._camera, 0U, 0) > 0U)
      throw new Exception("Failed to take picture");
    int num1 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
    {
      if (inEvent == 516U)
      {
        IntPtr num2 = inRef;
        EDSDK.EdsDirectoryItemInfo outDirItemInfo;
        int directoryItemInfo = (int) EDSDK.EdsGetDirectoryItemInfo(num2, out outDirItemInfo);
        IntPtr outStream;
        int fileStream = (int) EDSDK.EdsCreateFileStream(savePath, EDSDK.EdsFileCreateDisposition.CreateAlways, EDSDK.EdsAccess.ReadWrite, out outStream);
        int num3 = (int) EDSDK.EdsDownload(num2, outDirItemInfo.Size, outStream);
        int num4 = (int) EDSDK.EdsDownloadComplete(num2);
        int num5 = (int) EDSDK.EdsRelease(outStream);
        int num6 = (int) EDSDK.EdsRelease(num2);
        this.DisplayImageInPictureBox(savePath, pictureBox);
      }
      return 0;
    }), IntPtr.Zero);
  }

  public async Task<bool> TakeAndSavePhotoAsync(string savePath, PictureBox pictureBox)
  {
    this._lastSavePath = savePath;
    this._lastPictureBox = pictureBox;
    this._downloaded = false;
    this._photoTaskCompletionSource = new TaskCompletionSource<bool>();
    uint err = EDSDK.EdsSendCommand(this._camera, 0U, 0);
    if (err > 0U)
      throw new Exception("Failed to take picture: " + err.ToString());
    Task delayTask = Task.Delay(7000);
    Task completedTask = await Task.WhenAny((Task) this._photoTaskCompletionSource.Task, delayTask);
    if (completedTask == delayTask)
      throw new Exception("Camera timeout: Photo was not downloaded within the expected time.");
    bool task = await this._photoTaskCompletionSource.Task;
    delayTask = (Task) null;
    completedTask = (Task) null;
    return task;
  }

  public async Task<bool> TakeAndSavePhotoFastAsync(string savePath)
  {
    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
    EDSDK.EdsObjectEventHandler oneTimeHandler = (EDSDK.EdsObjectEventHandler) null;
    oneTimeHandler = (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
    {
      if (inEvent == 520U || inEvent == 516U)
      {
        this.DownloadDirItem(inRef, savePath);
        int num = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
        tcs.TrySetResult(true);
      }
      return 0;
    });
    int num1 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, oneTimeHandler, IntPtr.Zero);
    uint err = EDSDK.EdsSendCommand(this._camera, 0U, 0);
    if (err > 0U)
    {
      int num2 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
      throw new Exception("Failed to take picture");
    }
    Task delayTask = Task.Delay(5000);
    Task completedTask = await Task.WhenAny((Task) tcs.Task, delayTask);
    if (completedTask == delayTask)
    {
      int num3 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
      throw new Exception("Camera timeout");
    }
    bool task = await tcs.Task;
    oneTimeHandler = (EDSDK.EdsObjectEventHandler) null;
    delayTask = (Task) null;
    completedTask = (Task) null;
    return task;
  }

  public async Task<bool> TakeAndSavePhotoFastAsyncV2(string savePath, int delayTime)
  {
    this._photoTaskCompletionSource = new TaskCompletionSource<bool>();
    this._takePhotoEventHandler = (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
    {
      if (inEvent == 520U || inEvent == 516U)
      {
        IntPtr num1 = inRef;
        EDSDK.EdsDirectoryItemInfo outDirItemInfo;
        int directoryItemInfo = (int) EDSDK.EdsGetDirectoryItemInfo(num1, out outDirItemInfo);
        IntPtr outStream;
        int fileStream = (int) EDSDK.EdsCreateFileStream(savePath, EDSDK.EdsFileCreateDisposition.CreateAlways, EDSDK.EdsAccess.ReadWrite, out outStream);
        int num2 = (int) EDSDK.EdsDownload(num1, outDirItemInfo.Size, outStream);
        int num3 = (int) EDSDK.EdsDownloadComplete(num1);
        int num4 = (int) EDSDK.EdsRelease(outStream);
        int num5 = (int) EDSDK.EdsRelease(num1);
        this._photoTaskCompletionSource?.TrySetResult(true);
      }
      return 0;
    });
    int num6 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, this._takePhotoEventHandler, IntPtr.Zero);
    uint err = EDSDK.EdsSendCommand(this._camera, 0U, 0);
    if (err > 0U)
    {
      int num7 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
      throw new Exception("Failed to take picture");
    }
    Task delayTask = Task.Delay(delayTime);
    Task completedTask = await Task.WhenAny((Task) this._photoTaskCompletionSource.Task, delayTask);
    int num8 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
    if (completedTask == delayTask)
      throw new Exception("Camera timeout: Image did not download fast enough.");
    bool task = await this._photoTaskCompletionSource.Task;
    delayTask = (Task) null;
    completedTask = (Task) null;
    return task;
  }

  public void TakeAndSavePhoto(string savePath, PictureBox pictureBox)
  {
    if (EDSDK.EdsSendCommand(this._camera, 0U, 0) > 0U)
      throw new Exception("Failed to take picture");
    this._takePhotoEventHandler = (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
    {
      if (inEvent == 516U)
      {
        IntPtr num1 = inRef;
        EDSDK.EdsDirectoryItemInfo outDirItemInfo;
        int directoryItemInfo = (int) EDSDK.EdsGetDirectoryItemInfo(num1, out outDirItemInfo);
        IntPtr outStream;
        int fileStream = (int) EDSDK.EdsCreateFileStream(savePath, EDSDK.EdsFileCreateDisposition.CreateAlways, EDSDK.EdsAccess.ReadWrite, out outStream);
        int num2 = (int) EDSDK.EdsDownload(num1, outDirItemInfo.Size, outStream);
        int num3 = (int) EDSDK.EdsDownloadComplete(num1);
        int num4 = (int) EDSDK.EdsRelease(outStream);
        int num5 = (int) EDSDK.EdsRelease(num1);
        this.DisplayImageInPictureBox(savePath, pictureBox);
      }
      return 0;
    });
    int num = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, this._takePhotoEventHandler, IntPtr.Zero);
  }

  public bool TakeAndSavePhotoV2(string savePath, PictureBox pictureBox, int timeoutMs = 5000)
  {
    this._lastSavePath = savePath;
    this._lastPictureBox = pictureBox;
    this._downloaded = false;
    int num1 = (int) EDSDK.EdsSetPropertyData(this._camera, 11U, 0, 4, (object) 1U);
    int num2 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 516U, this.MyObjectEventHandler, IntPtr.Zero);
    int num3 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 520U, this.MyObjectEventHandler, IntPtr.Zero);
    uint num4 = EDSDK.EdsSendCommand(this._camera, 0U, 0);
    if (num4 > 0U)
      throw new Exception("Failed to take picture: " + num4.ToString());
    Stopwatch stopwatch = Stopwatch.StartNew();
    while (!this._downloaded && stopwatch.ElapsedMilliseconds < (long) timeoutMs)
    {
      Application.DoEvents();
      Thread.Sleep(20);
    }
    int num5 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 516U, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
    int num6 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 520U, (EDSDK.EdsObjectEventHandler) null, IntPtr.Zero);
    return this._downloaded;
  }

  private void DownloadDirItem(IntPtr dirItem, string savePath)
  {
    EDSDK.EdsDirectoryItemInfo outDirItemInfo;
    Debug.WriteLine($"GetDirectoryItemInfo: 0x{EDSDK.EdsGetDirectoryItemInfo(dirItem, out outDirItemInfo):X}");
    IntPtr outStream;
    Debug.WriteLine($"CreateFileStream: 0x{EDSDK.EdsCreateFileStream(savePath, EDSDK.EdsFileCreateDisposition.CreateAlways, EDSDK.EdsAccess.ReadWrite, out outStream):X}");
    Debug.WriteLine($"Download: 0x{EDSDK.EdsDownload(dirItem, outDirItemInfo.Size, outStream):X}, expected size: {outDirItemInfo.Size}");
    Debug.WriteLine($"DownloadComplete: 0x{EDSDK.EdsDownloadComplete(dirItem):X}");
    int num1 = (int) EDSDK.EdsRelease(outStream);
    int num2 = (int) EDSDK.EdsRelease(dirItem);
    Debug.WriteLine($"File length after download: {new FileInfo(savePath).Length}");
  }

  public void DisplayImageInPictureBox(string imagePath, PictureBox pictureBox)
  {
    try
    {
      if (File.Exists(imagePath))
      {
        pictureBox.Invoke((Delegate) (() => pictureBox.Image = Image.FromFile(imagePath)));
      }
      else
      {
        int num = (int) MessageBox.Show("Image file does not exist.");
      }
    }
    catch (OutOfMemoryException ex)
    {
      Console.WriteLine("Error loading image: Out of memory or invalid image format.");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error loading image: " + ex.Message);
    }
  }

  public void DisplayImageInPictureBoxV2(string imagePath, PictureBox pictureBox)
  {
    try
    {
      if (!File.Exists(imagePath))
      {
        int num1 = (int) MessageBox.Show("Image file does not exist.");
      }
      else
      {
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.ElapsedMilliseconds < 2000L && new FileInfo(imagePath).Length == 0L)
          Thread.Sleep(50);
        if (new FileInfo(imagePath).Length == 0L)
        {
          int num2 = (int) MessageBox.Show("Image file is empty. Download may have failed.");
        }
        else
        {
          byte[] buffer = File.ReadAllBytes(imagePath);
          if (buffer.Length < 100)
          {
            int num3 = (int) MessageBox.Show("Image file too small to be valid.");
          }
          else
          {
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
              Image img = Image.FromStream((Stream) memoryStream);
              pictureBox.Invoke((Delegate) (() =>
              {
                pictureBox.Image?.Dispose();
                pictureBox.Image = (Image) new Bitmap(img);
              }));
            }
          }
        }
      }
    }
    catch (ArgumentException ex)
    {
      int num = (int) MessageBox.Show("Error loading image: file is not a valid image or is corrupted.");
    }
    catch (OutOfMemoryException ex)
    {
      int num = (int) MessageBox.Show("Error loading image: out of memory or invalid image format.");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error loading image: " + ex.Message);
    }
  }

  public void TakeAndSavePhotoNonPbox(string savePath)
  {
    if (EDSDK.EdsSendCommand(this._camera, 0U, 0) > 0U)
      throw new Exception("Failed to take picture");
    int num1 = (int) EDSDK.EdsSetObjectEventHandler(this._camera, 512U /*0x0200*/, (EDSDK.EdsObjectEventHandler) ((inEvent, inRef, inContext) =>
    {
      if (inEvent == 516U)
      {
        IntPtr num2 = inRef;
        EDSDK.EdsDirectoryItemInfo outDirItemInfo;
        int directoryItemInfo = (int) EDSDK.EdsGetDirectoryItemInfo(num2, out outDirItemInfo);
        IntPtr outStream;
        int fileStream = (int) EDSDK.EdsCreateFileStream(savePath, EDSDK.EdsFileCreateDisposition.CreateAlways, EDSDK.EdsAccess.ReadWrite, out outStream);
        int num3 = (int) EDSDK.EdsDownload(num2, outDirItemInfo.Size, outStream);
        int num4 = (int) EDSDK.EdsDownloadComplete(num2);
        int num5 = (int) EDSDK.EdsRelease(outStream);
        int num6 = (int) EDSDK.EdsRelease(num2);
      }
      return 0;
    }), IntPtr.Zero);
  }

  public void SetTv(uint tvValue)
  {
    if (EDSDK.EdsSetPropertyData(this._camera, 1030U, 0, 4, (object) tvValue) <= 0U)
      ;
  }

  public void SetIso(uint isoValue)
  {
    if (EDSDK.EdsSetPropertyData(this._camera, 1026U, 0, 4, (object) isoValue) <= 0U)
      ;
  }

  public void SetAv(uint avValue)
  {
    if (EDSDK.EdsSetPropertyData(this._camera, 1029U, 0, 4, (object) avValue) <= 0U)
      ;
  }

  public async void SetBulb(int bulbTimeInSeconds)
  {
    uint err = EDSDK.EdsSendCommand(this._camera, 2U, 0);
    if (err > 0U)
    {
      int num1 = (int) MessageBox.Show("Failed to start Bulb exposure");
    }
    else
    {
      await Task.Delay(bulbTimeInSeconds * 1000);
      err = EDSDK.EdsSendCommand(this._camera, 3U, 0);
      if (err <= 0U)
        return;
      int num2 = (int) MessageBox.Show("Failed to end Bulb exposure");
    }
  }

  public void StartLiveView()
  {
    uint outPropertyData;
    if (EDSDK.EdsGetPropertyData(this._camera, 1280U /*0x0500*/, 0, out outPropertyData) > 0U)
    {
      int num1 = (int) MessageBox.Show("Failed to get live view device");
    }
    else
    {
      if (EDSDK.EdsSetPropertyData(this._camera, 1280U /*0x0500*/, 0, 4, (object) (outPropertyData | 2U)) <= 0U)
        return;
      int num2 = (int) MessageBox.Show("Failed to start live view");
    }
  }

  public void GetLiveViewImage(PictureBox pictureBox)
  {
    Task.Run((Func<Task>) (() =>
    {
      while (true)
      {
        IntPtr outStream;
        int memoryStream1 = (int) EDSDK.EdsCreateMemoryStream(0UL, out outStream);
        IntPtr outEvfImageRef;
        int evfImageRef = (int) EDSDK.EdsCreateEvfImageRef(outStream, out outEvfImageRef);
        if (EDSDK.EdsDownloadEvfImage(this._camera, outEvfImageRef) > 0U)
        {
          int num1 = (int) EDSDK.EdsRelease(outStream);
          int num2 = (int) EDSDK.EdsRelease(outEvfImageRef);
        }
        else
        {
          IntPtr outPointer;
          int pointer = (int) EDSDK.EdsGetPointer(outStream, out outPointer);
          ulong outLength;
          int length = (int) EDSDK.EdsGetLength(outStream, out outLength);
          byte[] numArray = new byte[outLength];
          Marshal.Copy(outPointer, numArray, 0, (int) outLength);
          int num3 = (int) EDSDK.EdsRelease(outStream);
          int num4 = (int) EDSDK.EdsRelease(outEvfImageRef);
          using (MemoryStream memoryStream2 = new MemoryStream(numArray))
          {
            Bitmap bitmap = new Bitmap((Stream) memoryStream2);
            pictureBox.Invoke((Delegate) (() => pictureBox.Image = (Image) bitmap));
          }
          Thread.Sleep(30);
        }
      }
    }));
  }

  public void StopLiveView()
  {
    uint outPropertyData;
    if (EDSDK.EdsGetPropertyData(this._camera, 1280U /*0x0500*/, 0, out outPropertyData) > 0U)
    {
      int num1 = (int) MessageBox.Show("Failed to get live view device");
    }
    else
    {
      if (EDSDK.EdsSetPropertyData(this._camera, 1280U /*0x0500*/, 0, 4, (object) (outPropertyData & 4294967293U)) <= 0U)
        return;
      int num2 = (int) MessageBox.Show("Failed to stop live view");
    }
  }

  private string GetErrorDescription(uint errorCode)
  {
    switch (errorCode)
    {
      case 0:
        return "No error";
      case 7:
        return "Not supported";
      case 96 /*0x60*/:
        return "Invalid parameter";
      case 128 /*0x80*/:
        return "Device not found";
      case 129:
        return "Device busy";
      default:
        return $"Unknown error (0x{errorCode:X8})";
    }
  }
}
