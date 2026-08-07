// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ArmoredOutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ArmoredOutputStream : BaseOutputStream
{
  public static readonly string HeaderVersion = nameof (Version);
  private static readonly byte[] encodingTable = new byte[64 /*0x40*/]
  {
    (byte) 65,
    (byte) 66,
    (byte) 67,
    (byte) 68,
    (byte) 69,
    (byte) 70,
    (byte) 71,
    (byte) 72,
    (byte) 73,
    (byte) 74,
    (byte) 75,
    (byte) 76,
    (byte) 77,
    (byte) 78,
    (byte) 79,
    (byte) 80 /*0x50*/,
    (byte) 81,
    (byte) 82,
    (byte) 83,
    (byte) 84,
    (byte) 85,
    (byte) 86,
    (byte) 87,
    (byte) 88,
    (byte) 89,
    (byte) 90,
    (byte) 97,
    (byte) 98,
    (byte) 99,
    (byte) 100,
    (byte) 101,
    (byte) 102,
    (byte) 103,
    (byte) 104,
    (byte) 105,
    (byte) 106,
    (byte) 107,
    (byte) 108,
    (byte) 109,
    (byte) 110,
    (byte) 111,
    (byte) 112 /*0x70*/,
    (byte) 113,
    (byte) 114,
    (byte) 115,
    (byte) 116,
    (byte) 117,
    (byte) 118,
    (byte) 119,
    (byte) 120,
    (byte) 121,
    (byte) 122,
    (byte) 48 /*0x30*/,
    (byte) 49,
    (byte) 50,
    (byte) 51,
    (byte) 52,
    (byte) 53,
    (byte) 54,
    (byte) 55,
    (byte) 56,
    (byte) 57,
    (byte) 43,
    (byte) 47
  };
  private readonly Stream outStream;
  private byte[] buf = new byte[3];
  private int bufPtr;
  private Crc24 crc = new Crc24();
  private int chunkCount;
  private int lastb;
  private bool start = true;
  private bool clearText;
  private bool newLine;
  private string type;
  private static readonly string NewLine = Environment.NewLine;
  private static readonly string headerStart = "-----BEGIN PGP ";
  private static readonly string headerTail = "-----";
  private static readonly string footerStart = "-----END PGP ";
  private static readonly string footerTail = "-----";
  private static readonly string Version = ArmoredOutputStream.CreateVersion();
  private readonly IDictionary<string, IList<string>> m_headers;

  private static void Encode(Stream outStream, byte[] data, int len)
  {
    byte[] buffer = new byte[4];
    int num1 = (int) data[0];
    buffer[0] = ArmoredOutputStream.encodingTable[num1 >> 2 & 63 /*0x3F*/];
    switch (len)
    {
      case 1:
        buffer[1] = ArmoredOutputStream.encodingTable[num1 << 4 & 63 /*0x3F*/];
        buffer[2] = (byte) 61;
        buffer[3] = (byte) 61;
        break;
      case 2:
        int num2 = (int) data[1];
        buffer[1] = ArmoredOutputStream.encodingTable[(num1 << 4 | num2 >> 4) & 63 /*0x3F*/];
        buffer[2] = ArmoredOutputStream.encodingTable[num2 << 2 & 63 /*0x3F*/];
        buffer[3] = (byte) 61;
        break;
      case 3:
        int num3 = (int) data[1];
        int num4 = (int) data[2];
        buffer[1] = ArmoredOutputStream.encodingTable[(num1 << 4 | num3 >> 4) & 63 /*0x3F*/];
        buffer[2] = ArmoredOutputStream.encodingTable[(num3 << 2 | num4 >> 6) & 63 /*0x3F*/];
        buffer[3] = ArmoredOutputStream.encodingTable[num4 & 63 /*0x3F*/];
        break;
    }
    outStream.Write(buffer, 0, buffer.Length);
  }

  private static void Encode3(Stream outStream, byte[] data)
  {
    int num1 = (int) data[0];
    int num2 = (int) data[1];
    int num3 = (int) data[2];
    byte[] buffer = new byte[4]
    {
      ArmoredOutputStream.encodingTable[num1 >> 2 & 63 /*0x3F*/],
      ArmoredOutputStream.encodingTable[(num1 << 4 | num2 >> 4) & 63 /*0x3F*/],
      ArmoredOutputStream.encodingTable[(num2 << 2 | num3 >> 6) & 63 /*0x3F*/],
      ArmoredOutputStream.encodingTable[num3 & 63 /*0x3F*/]
    };
    outStream.Write(buffer, 0, buffer.Length);
  }

  private static string CreateVersion()
  {
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    return $"{executingAssembly.GetCustomAttribute<AssemblyTitleAttribute>().Title} v{executingAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}";
  }

  public ArmoredOutputStream(Stream outStream)
  {
    this.outStream = outStream;
    this.m_headers = (IDictionary<string, IList<string>>) new Dictionary<string, IList<string>>(1);
    this.SetHeader(ArmoredOutputStream.HeaderVersion, ArmoredOutputStream.Version);
  }

  public ArmoredOutputStream(Stream outStream, IDictionary<string, string> headers)
    : this(outStream)
  {
    foreach (KeyValuePair<string, string> header in (IEnumerable<KeyValuePair<string, string>>) headers)
      this.m_headers[header.Key] = (IList<string>) new List<string>(1)
      {
        header.Value
      };
  }

  public void SetHeader(string name, string val)
  {
    if (val == null)
    {
      this.m_headers.Remove(name);
    }
    else
    {
      IList<string> stringList;
      if (this.m_headers.TryGetValue(name, out stringList))
      {
        stringList.Clear();
      }
      else
      {
        stringList = (IList<string>) new List<string>(1);
        this.m_headers[name] = stringList;
      }
      stringList.Add(val);
    }
  }

  public void AddHeader(string name, string val)
  {
    if (val == null || name == null)
      return;
    IList<string> stringList;
    if (!this.m_headers.TryGetValue(name, out stringList))
    {
      stringList = (IList<string>) new List<string>(1);
      this.m_headers[name] = stringList;
    }
    stringList.Add(val);
  }

  public void ResetHeaders()
  {
    IList<string> valueOrNull = CollectionUtilities.GetValueOrNull<string, IList<string>>(this.m_headers, ArmoredOutputStream.HeaderVersion);
    this.m_headers.Clear();
    if (valueOrNull == null)
      return;
    this.m_headers[ArmoredOutputStream.HeaderVersion] = valueOrNull;
  }

  public void BeginClearText(HashAlgorithmTag hashAlgorithm)
  {
    string str;
    switch (hashAlgorithm)
    {
      case HashAlgorithmTag.MD5:
        str = "MD5";
        break;
      case HashAlgorithmTag.Sha1:
        str = "SHA1";
        break;
      case HashAlgorithmTag.RipeMD160:
        str = "RIPEMD160";
        break;
      case HashAlgorithmTag.MD2:
        str = "MD2";
        break;
      case HashAlgorithmTag.Sha256:
        str = "SHA256";
        break;
      case HashAlgorithmTag.Sha384:
        str = "SHA384";
        break;
      case HashAlgorithmTag.Sha512:
        str = "SHA512";
        break;
      default:
        throw new IOException("unknown hash algorithm tag in beginClearText: " + hashAlgorithm.ToString());
    }
    this.DoWrite("-----BEGIN PGP SIGNED MESSAGE-----" + ArmoredOutputStream.NewLine);
    this.DoWrite($"Hash: {str}{ArmoredOutputStream.NewLine}{ArmoredOutputStream.NewLine}");
    this.clearText = true;
    this.newLine = true;
    this.lastb = 0;
  }

  public void EndClearText() => this.clearText = false;

  public override void WriteByte(byte value)
  {
    if (this.clearText)
    {
      this.outStream.WriteByte(value);
      if (this.newLine)
      {
        if (value != (byte) 10 || this.lastb != 13)
          this.newLine = false;
        if (value == (byte) 45)
        {
          this.outStream.WriteByte((byte) 32 /*0x20*/);
          this.outStream.WriteByte((byte) 45);
        }
      }
      if (value == (byte) 13 || value == (byte) 10 && this.lastb != 13)
        this.newLine = true;
      this.lastb = (int) value;
    }
    else
    {
      if (this.start)
      {
        switch (((uint) value & 64U /*0x40*/) <= 0U ? ((int) value & 63 /*0x3F*/) >> 2 : (int) value & 63 /*0x3F*/)
        {
          case 2:
            this.type = "SIGNATURE";
            break;
          case 5:
            this.type = "PRIVATE KEY BLOCK";
            break;
          case 6:
            this.type = "PUBLIC KEY BLOCK";
            break;
          default:
            this.type = "MESSAGE";
            break;
        }
        this.DoWrite(ArmoredOutputStream.headerStart + this.type + ArmoredOutputStream.headerTail + ArmoredOutputStream.NewLine);
        IList<string> stringList;
        if (this.m_headers.TryGetValue(ArmoredOutputStream.HeaderVersion, out stringList))
          this.WriteHeaderEntry(ArmoredOutputStream.HeaderVersion, stringList[0]);
        foreach (KeyValuePair<string, IList<string>> header in (IEnumerable<KeyValuePair<string, IList<string>>>) this.m_headers)
        {
          string key = header.Key;
          if (key != ArmoredOutputStream.HeaderVersion)
          {
            foreach (string v in (IEnumerable<string>) header.Value)
              this.WriteHeaderEntry(key, v);
          }
        }
        this.DoWrite(ArmoredOutputStream.NewLine);
        this.start = false;
      }
      if (this.bufPtr == 3)
      {
        this.crc.Update3(this.buf, 0);
        ArmoredOutputStream.Encode3(this.outStream, this.buf);
        this.bufPtr = 0;
        if ((++this.chunkCount & 15) == 0)
          this.DoWrite(ArmoredOutputStream.NewLine);
      }
      this.buf[this.bufPtr++] = value;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.type != null)
    {
      this.DoClose();
      this.type = (string) null;
      this.start = true;
    }
    base.Dispose(disposing);
  }

  private void DoClose()
  {
    if (this.bufPtr > 0)
    {
      for (int index = 0; index < this.bufPtr; ++index)
        this.crc.Update(this.buf[index]);
      ArmoredOutputStream.Encode(this.outStream, this.buf, this.bufPtr);
    }
    this.DoWrite(ArmoredOutputStream.NewLine + "=");
    Pack.UInt24_To_BE((uint) this.crc.Value, this.buf);
    ArmoredOutputStream.Encode3(this.outStream, this.buf);
    this.DoWrite(ArmoredOutputStream.NewLine);
    this.DoWrite(ArmoredOutputStream.footerStart);
    this.DoWrite(this.type);
    this.DoWrite(ArmoredOutputStream.footerTail);
    this.DoWrite(ArmoredOutputStream.NewLine);
    this.outStream.Flush();
  }

  private void WriteHeaderEntry(string name, string v)
  {
    this.DoWrite($"{name}: {v}{ArmoredOutputStream.NewLine}");
  }

  private void DoWrite(string s)
  {
    byte[] asciiByteArray = Strings.ToAsciiByteArray(s);
    this.outStream.Write(asciiByteArray, 0, asciiByteArray.Length);
  }
}
