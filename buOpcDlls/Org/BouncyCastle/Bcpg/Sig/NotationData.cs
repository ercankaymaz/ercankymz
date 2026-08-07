// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.NotationData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class NotationData : SignatureSubpacket
{
  public const int HeaderFlagLength = 4;
  public const int HeaderNameLength = 2;
  public const int HeaderValueLength = 2;

  public NotationData(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.NotationData, critical, isLongLength, data)
  {
  }

  public NotationData(
    bool critical,
    bool humanReadable,
    string notationName,
    string notationValue)
    : base(SignatureSubpacketTag.NotationData, critical, false, NotationData.CreateData(humanReadable, notationName, notationValue))
  {
  }

  private static byte[] CreateData(bool humanReadable, string notationName, string notationValue)
  {
    MemoryStream memoryStream = new MemoryStream();
    memoryStream.WriteByte(humanReadable ? (byte) 128 /*0x80*/ : (byte) 0);
    memoryStream.WriteByte((byte) 0);
    memoryStream.WriteByte((byte) 0);
    memoryStream.WriteByte((byte) 0);
    byte[] bytes1 = Encoding.UTF8.GetBytes(notationName);
    int count1 = Math.Min(bytes1.Length, (int) byte.MaxValue);
    byte[] bytes2 = Encoding.UTF8.GetBytes(notationValue);
    int count2 = Math.Min(bytes2.Length, (int) byte.MaxValue);
    memoryStream.WriteByte((byte) (count1 >> 8));
    memoryStream.WriteByte((byte) count1);
    memoryStream.WriteByte((byte) (count2 >> 8));
    memoryStream.WriteByte((byte) count2);
    memoryStream.Write(bytes1, 0, count1);
    memoryStream.Write(bytes2, 0, count2);
    return memoryStream.ToArray();
  }

  public bool IsHumanReadable => this.data[0] == (byte) 128 /*0x80*/;

  public string GetNotationName()
  {
    return Encoding.UTF8.GetString(this.data, 8, ((int) this.data[4] << 8) + (int) this.data[5]);
  }

  public string GetNotationValue()
  {
    return Encoding.UTF8.GetString(this.data, 8 + (((int) this.data[4] << 8) + (int) this.data[5]), ((int) this.data[6] << 8) + (int) this.data[7]);
  }

  public byte[] GetNotationValueBytes()
  {
    int num = ((int) this.data[4] << 8) + (int) this.data[5];
    int length = ((int) this.data[6] << 8) + (int) this.data[7];
    int sourceIndex = 8 + num;
    byte[] destinationArray = new byte[length];
    Array.Copy((Array) this.data, sourceIndex, (Array) destinationArray, 0, length);
    return destinationArray;
  }
}
