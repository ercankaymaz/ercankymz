// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ArmoredInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ArmoredInputStream : BaseInputStream
{
  private static readonly byte[] decodingTable = new byte[128 /*0x80*/];
  private bool detectMissingChecksum;
  private Stream input;
  private bool start = true;
  private byte[] outBuf = new byte[3];
  private int bufPtr = 3;
  private Crc24 crc = new Crc24();
  private bool crcFound;
  private bool hasHeaders = true;
  private string header;
  private bool newLineFound;
  private bool clearText;
  private bool restart;
  private IList<string> headerList = (IList<string>) new List<string>();
  private int lastC;
  private bool isEndOfStream;

  static ArmoredInputStream()
  {
    Arrays.Fill(ArmoredInputStream.decodingTable, byte.MaxValue);
    for (int index = 65; index <= 90; ++index)
      ArmoredInputStream.decodingTable[index] = (byte) (index - 65);
    for (int index = 97; index <= 122; ++index)
      ArmoredInputStream.decodingTable[index] = (byte) (index - 97 + 26);
    for (int index = 48 /*0x30*/; index <= 57; ++index)
      ArmoredInputStream.decodingTable[index] = (byte) (index - 48 /*0x30*/ + 52);
    ArmoredInputStream.decodingTable[43] = (byte) 62;
    ArmoredInputStream.decodingTable[47] = (byte) 63 /*0x3F*/;
  }

  private static int Decode(int in0, int in1, int in2, int in3, byte[] result)
  {
    if (in3 < 0)
      throw new EndOfStreamException("unexpected end of file in armored stream.");
    if (in2 == 61)
    {
      int num1 = (int) ArmoredInputStream.decodingTable[in0];
      int num2 = (int) ArmoredInputStream.decodingTable[in1];
      if ((num1 | num2) >= 128 /*0x80*/)
        throw new IOException("invalid armor");
      result[2] = (byte) (num1 << 2 | num2 >> 4);
      return 2;
    }
    if (in3 == 61)
    {
      int num3 = (int) ArmoredInputStream.decodingTable[in0];
      int num4 = (int) ArmoredInputStream.decodingTable[in1];
      int num5 = (int) ArmoredInputStream.decodingTable[in2];
      if ((num3 | num4 | num5) >= 128 /*0x80*/)
        throw new IOException("invalid armor");
      result[1] = (byte) (num3 << 2 | num4 >> 4);
      result[2] = (byte) (num4 << 4 | num5 >> 2);
      return 1;
    }
    int num6 = (int) ArmoredInputStream.decodingTable[in0];
    int num7 = (int) ArmoredInputStream.decodingTable[in1];
    int num8 = (int) ArmoredInputStream.decodingTable[in2];
    int num9 = (int) ArmoredInputStream.decodingTable[in3];
    if ((num6 | num7 | num8 | num9) >= 128 /*0x80*/)
      throw new IOException("invalid armor");
    result[0] = (byte) (num6 << 2 | num7 >> 4);
    result[1] = (byte) (num7 << 4 | num8 >> 2);
    result[2] = (byte) (num8 << 6 | num9);
    return 0;
  }

  public ArmoredInputStream(Stream input)
    : this(input, true)
  {
  }

  public ArmoredInputStream(Stream input, bool hasHeaders)
  {
    this.input = input;
    this.hasHeaders = hasHeaders;
    if (hasHeaders)
      this.ParseHeaders();
    this.start = false;
  }

  private bool ParseHeaders()
  {
    this.header = (string) null;
    int num1 = 0;
    bool headers = false;
    this.headerList = (IList<string>) new List<string>();
    if (this.restart)
    {
      headers = true;
    }
    else
    {
      int num2;
      while ((num2 = this.input.ReadByte()) >= 0)
      {
        if (num2 != 45 || num1 != 0 && num1 != 10 && num1 != 13)
        {
          num1 = num2;
        }
        else
        {
          headers = true;
          break;
        }
      }
    }
    if (headers)
    {
      StringBuilder stringBuilder = new StringBuilder("-");
      bool flag1 = false;
      bool flag2 = false;
      if (this.restart)
        stringBuilder.Append('-');
      int num3;
      while ((num3 = this.input.ReadByte()) >= 0)
      {
        if (num1 == 13 && num3 == 10)
          flag2 = true;
        if ((!flag1 || num1 == 13 || num3 != 10) && (!flag1 || num3 != 13))
        {
          if (num3 == 13 || num1 != 13 && num3 == 10)
          {
            string str = stringBuilder.ToString();
            if (str.Trim().Length >= 1)
            {
              if (this.headerList.Count > 0 && str.IndexOf(':') < 0)
                throw new IOException("invalid armor header");
              this.headerList.Add(str);
              stringBuilder.Length = 0;
            }
            else
              break;
          }
          if (num3 != 10 && num3 != 13)
          {
            stringBuilder.Append((char) num3);
            flag1 = false;
          }
          else if (num3 == 13 || num1 != 13 && num3 == 10)
            flag1 = true;
          num1 = num3;
        }
        else
          break;
      }
      if (flag2)
        this.input.ReadByte();
    }
    if (this.headerList.Count > 0)
      this.header = this.headerList[0];
    this.clearText = "-----BEGIN PGP SIGNED MESSAGE-----".Equals(this.header);
    this.newLineFound = true;
    return headers;
  }

  public bool IsClearText() => this.clearText;

  public bool IsEndOfStream() => this.isEndOfStream;

  public string GetArmorHeaderLine() => this.header;

  public string[] GetArmorHeaders()
  {
    if (this.headerList.Count <= 1)
      return (string[]) null;
    string[] armorHeaders = new string[this.headerList.Count - 1];
    for (int index = 0; index != armorHeaders.Length; ++index)
      armorHeaders[index] = this.headerList[index + 1];
    return armorHeaders;
  }

  private int ReadIgnoreSpace()
  {
    int num;
    do
    {
      num = this.input.ReadByte();
    }
    while (num == 32 /*0x20*/ || num == 9 || num == 12 || num == 11);
    return num < 128 /*0x80*/ ? num : throw new IOException("invalid armor");
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    int num1;
    int num2;
    for (num1 = 0; num1 < count; buffer[offset + num1++] = (byte) num2)
    {
      num2 = this.ReadByte();
      if (num2 < 0)
        break;
    }
    return num1;
  }

  public override int ReadByte()
  {
    if (this.start)
    {
      if (this.hasHeaders)
        this.ParseHeaders();
      this.crc.Reset();
      this.start = false;
    }
    if (this.clearText)
    {
      int num = this.input.ReadByte();
      switch (num)
      {
        case 10:
          if (this.lastC == 13)
            goto default;
          goto case 13;
        case 13:
          this.newLineFound = true;
          break;
        default:
          if (this.newLineFound && num == 45)
          {
            num = this.input.ReadByte();
            if (num == 45)
            {
              this.clearText = false;
              this.start = true;
              this.restart = true;
            }
            else
              num = this.input.ReadByte();
            this.newLineFound = false;
            break;
          }
          if (num != 10 && this.lastC != 13)
          {
            this.newLineFound = false;
            break;
          }
          break;
      }
      this.lastC = num;
      if (num < 0)
        this.isEndOfStream = true;
      return num;
    }
    if (this.bufPtr > 2 || this.crcFound)
    {
      int in0 = this.ReadIgnoreSpace();
      switch (in0)
      {
        case 10:
        case 13:
          in0 = this.ReadIgnoreSpace();
          while (true)
          {
            switch (in0)
            {
              case 10:
              case 13:
                in0 = this.ReadIgnoreSpace();
                continue;
              case 45:
                goto label_28;
              case 61:
                goto label_23;
              default:
                goto label_34;
            }
          }
label_23:
          this.bufPtr = ArmoredInputStream.Decode(this.ReadIgnoreSpace(), this.ReadIgnoreSpace(), this.ReadIgnoreSpace(), this.ReadIgnoreSpace(), this.outBuf);
          if (this.bufPtr != 0)
            throw new IOException("malformed crc in armored message.");
          this.crcFound = true;
          if ((int) Pack.BE_To_UInt24(this.outBuf) != this.crc.Value)
            throw new IOException("crc check failed in armored message.");
          return this.ReadByte();
label_28:
          int num;
          do
            ;
          while ((num = this.input.ReadByte()) >= 0 && num != 10 && num != 13);
          this.crcFound = this.crcFound || !this.detectMissingChecksum ? false : throw new IOException("crc check not found");
          this.start = true;
          this.bufPtr = 3;
          if (num < 0)
            this.isEndOfStream = true;
          return -1;
      }
label_34:
      if (in0 < 0)
      {
        this.isEndOfStream = true;
        return -1;
      }
      this.bufPtr = ArmoredInputStream.Decode(in0, this.ReadIgnoreSpace(), this.ReadIgnoreSpace(), this.ReadIgnoreSpace(), this.outBuf);
      if (this.bufPtr == 0)
      {
        this.crc.Update3(this.outBuf, 0);
      }
      else
      {
        for (int bufPtr = this.bufPtr; bufPtr < 3; ++bufPtr)
          this.crc.Update(this.outBuf[bufPtr]);
      }
    }
    return (int) this.outBuf[this.bufPtr++];
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.input.Dispose();
    base.Dispose(disposing);
  }

  public virtual void SetDetectMissingCrc(bool detectMissing)
  {
    this.detectMissingChecksum = detectMissing;
  }
}
