// Decompiled with JetBrains decompiler
// Type: buCore.buImageProcessor
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.IO;

#nullable disable
namespace buCore;

public class buImageProcessor
{
  public static void LoadImage(string ImageName, ref Image returnImage, ref byte[] photoBytes)
  {
    using (MemoryStream memoryStream1 = new MemoryStream(File.ReadAllBytes(ImageName)))
    {
      using (MemoryStream memoryStream2 = new MemoryStream())
      {
        using (ImageFactory imageFactory = new ImageFactory(true))
        {
          imageFactory.Load((Stream) memoryStream1);
          imageFactory.Save((Stream) memoryStream2);
          returnImage = Image.FromStream((Stream) memoryStream2);
          photoBytes = memoryStream2.ToArray();
        }
      }
    }
  }

  public static void PhoteBytesToImage(byte[] photoBytes, ref Image returnImage)
  {
    using (MemoryStream memoryStream1 = new MemoryStream(photoBytes))
    {
      using (MemoryStream memoryStream2 = new MemoryStream())
      {
        using (ImageFactory imageFactory = new ImageFactory(true))
        {
          imageFactory.Load((Stream) memoryStream1);
          imageFactory.Save((Stream) memoryStream2);
          returnImage = Image.FromStream((Stream) memoryStream2);
        }
      }
    }
  }

  public static void Resize(byte[] photoBytes, Size newSize, ref byte[] returnPhotoBytes)
  {
    new JpegFormat().Quality = 70;
    Size size = new Size(150, 0);
    using (MemoryStream memoryStream1 = new MemoryStream(photoBytes))
    {
      using (MemoryStream memoryStream2 = new MemoryStream())
      {
        using (ImageFactory imageFactory = new ImageFactory(true))
        {
          imageFactory.Load((Stream) memoryStream1);
          imageFactory.Resize(newSize);
          imageFactory.Save((Stream) memoryStream2);
          returnPhotoBytes = memoryStream2.ToArray();
        }
      }
    }
  }
}
