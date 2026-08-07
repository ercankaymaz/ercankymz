// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.PKMacStreamCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crmf;

internal class PKMacStreamCalculator : IStreamCalculator<DefaultPKMacResult>
{
  private readonly MacSink _stream;

  public PKMacStreamCalculator(IMac mac) => this._stream = new MacSink(mac);

  public Stream Stream => (Stream) this._stream;

  public DefaultPKMacResult GetResult() => new DefaultPKMacResult(this._stream.Mac);
}
