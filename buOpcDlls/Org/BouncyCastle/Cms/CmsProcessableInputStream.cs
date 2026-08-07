// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsProcessableInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsProcessableInputStream : CmsProcessable, CmsReadable
{
  private readonly Stream input;
  private bool used;

  public CmsProcessableInputStream(Stream input) => this.input = input;

  public virtual Stream GetInputStream()
  {
    this.CheckSingleUsage();
    return this.input;
  }

  public virtual void Write(Stream output)
  {
    this.CheckSingleUsage();
    Streams.PipeAll(this.input, output);
    this.input.Dispose();
  }

  protected virtual void CheckSingleUsage()
  {
    lock (this)
      this.used = !this.used ? true : throw new InvalidOperationException("CmsProcessableInputStream can only be used once");
  }
}
