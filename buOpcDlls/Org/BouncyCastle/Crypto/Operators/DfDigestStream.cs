// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.DfDigestStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

internal class DfDigestStream : IStreamCalculator<SimpleBlockResult>
{
  private readonly DigestSink mStream;

  public DfDigestStream(IDigest digest) => this.mStream = new DigestSink(digest);

  public Stream Stream => (Stream) this.mStream;

  public SimpleBlockResult GetResult()
  {
    byte[] numArray = new byte[this.mStream.Digest.GetDigestSize()];
    this.mStream.Digest.DoFinal(numArray, 0);
    return new SimpleBlockResult(numArray);
  }
}
