// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Attr.ImageAttrib
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Attr;

public class ImageAttrib : UserAttributeSubpacket
{
  private static readonly byte[] Zeroes = new byte[12];
  private int hdrLength;
  private int _version;
  private int _encoding;
  private byte[] imageData;

  public ImageAttrib(byte[] data)
    : this(false, data)
  {
  }

  public ImageAttrib(bool forceLongLength, byte[] data)
    : base(UserAttributeSubpacketTag.ImageAttribute, forceLongLength, data)
  {
    this.hdrLength = ((int) data[1] & (int) byte.MaxValue) << 8 | (int) data[0] & (int) byte.MaxValue;
    this._version = (int) data[2] & (int) byte.MaxValue;
    this._encoding = (int) data[3] & (int) byte.MaxValue;
    this.imageData = new byte[data.Length - this.hdrLength];
    Array.Copy((Array) data, this.hdrLength, (Array) this.imageData, 0, this.imageData.Length);
  }

  public ImageAttrib(ImageAttrib.Format imageType, byte[] imageData)
    : this(ImageAttrib.ToByteArray(imageType, imageData))
  {
  }

  private static byte[] ToByteArray(ImageAttrib.Format imageType, byte[] imageData)
  {
    MemoryStream memoryStream = new MemoryStream();
    memoryStream.WriteByte((byte) 16 /*0x10*/);
    memoryStream.WriteByte((byte) 0);
    memoryStream.WriteByte((byte) 1);
    memoryStream.WriteByte((byte) imageType);
    memoryStream.Write(ImageAttrib.Zeroes, 0, ImageAttrib.Zeroes.Length);
    memoryStream.Write(imageData, 0, imageData.Length);
    return memoryStream.ToArray();
  }

  public virtual int Version => this._version;

  public virtual int Encoding => this._encoding;

  public virtual byte[] GetImageData() => this.imageData;

  public enum Format : byte
  {
    Jpeg = 1,
  }
}
