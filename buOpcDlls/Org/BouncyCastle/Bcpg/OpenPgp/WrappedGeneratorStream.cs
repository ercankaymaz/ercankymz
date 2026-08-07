// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.WrappedGeneratorStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

internal sealed class WrappedGeneratorStream : FilterStream
{
  private readonly IStreamGenerator m_generator;

  internal WrappedGeneratorStream(IStreamGenerator generator, Stream s)
    : base(s)
  {
    this.m_generator = generator ?? throw new ArgumentNullException(nameof (generator));
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.m_generator.Close();
    this.Detach(disposing);
  }
}
