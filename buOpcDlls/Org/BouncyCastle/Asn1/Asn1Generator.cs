// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Generator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1Generator : IDisposable
{
  private Stream m_outStream;

  protected Asn1Generator(Stream outStream)
  {
    this.m_outStream = outStream ?? throw new ArgumentNullException(nameof (outStream));
  }

  protected abstract void Finish();

  protected Stream OutStream => this.m_outStream ?? throw new InvalidOperationException();

  public abstract void AddObject(Asn1Encodable obj);

  public abstract void AddObject(Asn1Object obj);

  public abstract Stream GetRawOutputStream();

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing || this.m_outStream == null)
      return;
    this.Finish();
    this.m_outStream = (Stream) null;
  }
}
