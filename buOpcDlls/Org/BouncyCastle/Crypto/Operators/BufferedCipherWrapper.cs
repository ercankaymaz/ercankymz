// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.BufferedCipherWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class BufferedCipherWrapper : ICipher
{
  private readonly IBufferedCipher bufferedCipher;
  private readonly CipherStream stream;

  public BufferedCipherWrapper(IBufferedCipher bufferedCipher, Stream source)
  {
    this.bufferedCipher = bufferedCipher;
    this.stream = new CipherStream(source, bufferedCipher, bufferedCipher);
  }

  public int GetMaxOutputSize(int inputLen) => this.bufferedCipher.GetOutputSize(inputLen);

  public int GetUpdateOutputSize(int inputLen) => this.bufferedCipher.GetUpdateOutputSize(inputLen);

  public Stream Stream => (Stream) this.stream;
}
