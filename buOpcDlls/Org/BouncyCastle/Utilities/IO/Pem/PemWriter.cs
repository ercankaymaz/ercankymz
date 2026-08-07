// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Pem.PemWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Pem;

public class PemWriter : IDisposable
{
  private const int LineLength = 64 /*0x40*/;
  private readonly TextWriter m_writer;
  private readonly int m_nlLength;
  private readonly char[] m_buf = new char[64 /*0x40*/];

  public PemWriter(TextWriter writer)
  {
    this.m_writer = writer ?? throw new ArgumentNullException(nameof (writer));
    this.m_nlLength = Environment.NewLine.Length;
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
    this.m_writer.Dispose();
  }

  public TextWriter Writer => this.m_writer;

  public int GetOutputSize(PemObject obj)
  {
    int num1 = 2 * (obj.Type.Length + 10 + this.m_nlLength) + 6 + 4;
    if (obj.Headers.Count > 0)
    {
      foreach (PemHeader header in (IEnumerable<PemHeader>) obj.Headers)
        num1 += header.Name.Length + ": ".Length + header.Value.Length + this.m_nlLength;
      num1 += this.m_nlLength;
    }
    int num2 = (obj.Content.Length + 2) / 3 * 4;
    return num1 + (num2 + (num2 + 64 /*0x40*/ - 1) / 64 /*0x40*/ * this.m_nlLength);
  }

  public void WriteObject(PemObjectGenerator objGen)
  {
    PemObject pemObject = objGen.Generate();
    this.WritePreEncapsulationBoundary(pemObject.Type);
    if (pemObject.Headers.Count > 0)
    {
      foreach (PemHeader header in (IEnumerable<PemHeader>) pemObject.Headers)
      {
        this.m_writer.Write(header.Name);
        this.m_writer.Write(": ");
        this.m_writer.WriteLine(header.Value);
      }
      this.m_writer.WriteLine();
    }
    this.WriteEncoded(pemObject.Content);
    this.WritePostEncapsulationBoundary(pemObject.Type);
  }

  private void WriteEncoded(byte[] bytes)
  {
    bytes = Base64.Encode(bytes);
    for (int index = 0; index < bytes.Length; index += this.m_buf.Length)
    {
      int count;
      for (count = 0; count != this.m_buf.Length && index + count < bytes.Length; ++count)
        this.m_buf[count] = (char) bytes[index + count];
      this.m_writer.WriteLine(this.m_buf, 0, count);
    }
  }

  private void WritePreEncapsulationBoundary(string type)
  {
    this.m_writer.WriteLine($"-----BEGIN {type}-----");
  }

  private void WritePostEncapsulationBoundary(string type)
  {
    this.m_writer.WriteLine($"-----END {type}-----");
  }
}
