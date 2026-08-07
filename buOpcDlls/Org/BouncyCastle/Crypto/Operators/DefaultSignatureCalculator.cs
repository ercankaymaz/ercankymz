// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.DefaultSignatureCalculator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class DefaultSignatureCalculator : IStreamCalculator<IBlockResult>
{
  private readonly SignerSink mSignerSink;

  public DefaultSignatureCalculator(ISigner signer) => this.mSignerSink = new SignerSink(signer);

  public Stream Stream => (Stream) this.mSignerSink;

  public IBlockResult GetResult()
  {
    return (IBlockResult) new DefaultSignatureResult(this.mSignerSink.Signer);
  }
}
