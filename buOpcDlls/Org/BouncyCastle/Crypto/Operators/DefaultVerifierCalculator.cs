// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.DefaultVerifierCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class DefaultVerifierCalculator : IStreamCalculator<IVerifier>
{
  private readonly SignerSink mSignerSink;

  public DefaultVerifierCalculator(ISigner signer) => this.mSignerSink = new SignerSink(signer);

  public Stream Stream => (Stream) this.mSignerSink;

  public IVerifier GetResult() => (IVerifier) new DefaultVerifierResult(this.mSignerSink.Signer);
}
