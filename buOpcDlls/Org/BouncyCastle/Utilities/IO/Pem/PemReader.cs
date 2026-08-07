// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Pem.PemReader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Pem;

public class PemReader : IDisposable
{
  private const int LineLength = 64 /*0x40*/;
  private readonly TextReader m_reader;
  private readonly MemoryStream m_buffer;
  private readonly StreamWriter m_textBuffer;
  private readonly Stack<int> m_pushback = new Stack<int>();

  public PemReader(TextReader reader)
  {
    this.m_reader = reader ?? throw new ArgumentNullException(nameof (reader));
    this.m_buffer = new MemoryStream();
    this.m_textBuffer = new StreamWriter((Stream) this.m_buffer);
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.m_reader.Dispose();
  }

  public TextReader Reader => this.m_reader;

  public PemObject ReadPemObject()
  {
    while (this.SeekDash())
    {
      if (!this.ConsumeDash())
        throw new IOException("no data after consuming leading dashes");
      this.SkipWhiteSpace();
      if (this.Expect("BEGIN"))
      {
        this.SkipWhiteSpace();
        if (!this.BufferUntilStopChar('-', false))
          throw new IOException("ran out of data before consuming type");
        string type = this.BufferedString().Trim();
        if (!this.ConsumeDash())
          throw new IOException("ran out of data consuming header");
        this.SkipWhiteSpace();
        List<PemHeader> headers = new List<PemHeader>();
        while (this.SeekColon(64 /*0x40*/))
        {
          if (!this.BufferUntilStopChar(':', false))
            throw new IOException("ran out of data reading header key value");
          string name = this.BufferedString().Trim();
          if (this.Read() != 58)
            throw new IOException("expected colon");
          if (!this.BufferUntilStopChar('\n', false))
            throw new IOException("ran out of data before consuming header value");
          this.SkipWhiteSpace();
          string val = this.BufferedString().Trim();
          headers.Add(new PemHeader(name, val));
        }
        this.SkipWhiteSpace();
        if (!this.BufferUntilStopChar('-', true))
          throw new IOException("ran out of data before consuming payload");
        string data = this.BufferedString();
        if (!this.SeekDash())
          throw new IOException("did not find leading '-'");
        if (!this.ConsumeDash())
          throw new IOException("no data after consuming trailing dashes");
        if (!this.Expect("END " + type))
          throw new IOException($"END {type} was not found.");
        if (!this.SeekDash())
          throw new IOException("did not find ending '-'");
        this.ConsumeDash();
        return new PemObject(type, (IList<PemHeader>) headers, Base64.Decode(data));
      }
    }
    return (PemObject) null;
  }

  private string BufferedString()
  {
    this.m_textBuffer.Flush();
    string str = Strings.FromUtf8ByteArray(this.m_buffer.ToArray());
    this.m_buffer.Position = 0L;
    this.m_buffer.SetLength(0L);
    return str;
  }

  private bool SeekDash()
  {
    int num;
    do
      ;
    while ((num = this.Read()) >= 0 && num != 45);
    this.PushBack(num);
    return num >= 0;
  }

  private bool SeekColon(int upTo)
  {
    int num = 0;
    bool flag = false;
    List<int> intList = new List<int>();
    for (; upTo >= 0 && num >= 0; --upTo)
    {
      num = this.Read();
      intList.Add(num);
      if (num == 58)
      {
        flag = true;
        break;
      }
    }
    int count = intList.Count;
    while (--count >= 0)
      this.PushBack(intList[count]);
    return flag;
  }

  private bool ConsumeDash()
  {
    int num;
    do
      ;
    while ((num = this.Read()) >= 0 && num == 45);
    this.PushBack(num);
    return num >= 0;
  }

  private void SkipWhiteSpace()
  {
    int num;
    do
      ;
    while ((num = this.Read()) >= 0 && num <= 32 /*0x20*/);
    this.PushBack(num);
  }

  private bool Expect(string value)
  {
    for (int index = 0; index < value.Length; ++index)
    {
      if (this.Read() != (int) value[index])
        return false;
    }
    return true;
  }

  private bool BufferUntilStopChar(char stopChar, bool skipWhiteSpace)
  {
    int num;
    while ((num = this.Read()) >= 0)
    {
      if (!skipWhiteSpace || num > 32 /*0x20*/)
      {
        if (num != (int) stopChar)
        {
          this.m_textBuffer.Write((char) num);
          this.m_textBuffer.Flush();
        }
        else
        {
          this.PushBack(num);
          break;
        }
      }
    }
    return num >= 0;
  }

  private void PushBack(int value) => this.m_pushback.Push(value);

  private int Read() => this.m_pushback.Count > 0 ? this.m_pushback.Pop() : this.m_reader.Read();
}
