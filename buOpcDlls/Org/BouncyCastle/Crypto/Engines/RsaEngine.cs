// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RsaEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RsaEngine : IAsymmetricBlockCipher
{
  private readonly IRsa core;

  public RsaEngine()
    : this((IRsa) new RsaCoreEngine())
  {
  }

  public RsaEngine(IRsa rsa) => this.core = rsa;

  public virtual string AlgorithmName => "RSA";

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.core.Init(forEncryption, parameters);
  }

  public virtual int GetInputBlockSize() => this.core.GetInputBlockSize();

  public virtual int GetOutputBlockSize() => this.core.GetOutputBlockSize();

  public virtual byte[] ProcessBlock(byte[] inBuf, int inOff, int inLen)
  {
    return this.core.ConvertOutput(this.core.ProcessBlock(this.core.ConvertInput(inBuf, inOff, inLen)));
  }
}
