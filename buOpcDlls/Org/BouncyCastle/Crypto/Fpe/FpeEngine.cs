// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Fpe.FpeEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Fpe;

public abstract class FpeEngine
{
  protected readonly IBlockCipher baseCipher;
  protected bool forEncryption;
  protected FpeParameters fpeParameters;

  protected FpeEngine(IBlockCipher baseCipher) => this.baseCipher = baseCipher;

  public virtual int ProcessBlock(byte[] inBuf, int inOff, int length, byte[] outBuf, int outOff)
  {
    if (this.fpeParameters == null)
      throw new InvalidOperationException("FPE engine not initialized");
    if (length < 0)
      throw new ArgumentException("cannot be negative", nameof (length));
    if (inBuf == null)
      throw new ArgumentNullException(nameof (inBuf));
    if (outBuf == null)
      throw new ArgumentNullException(nameof (outBuf));
    Org.BouncyCastle.Crypto.Check.DataLength(inBuf, inOff, length, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBuf, outOff, length, "output buffer too short");
    return this.forEncryption ? this.EncryptBlock(inBuf, inOff, length, outBuf, outOff) : this.DecryptBlock(inBuf, inOff, length, outBuf, outOff);
  }

  protected static bool IsOverrideSet(string propName)
  {
    string environmentVariable = Platform.GetEnvironmentVariable(propName);
    return environmentVariable != null && Platform.EqualsIgnoreCase("true", environmentVariable);
  }

  public abstract void Init(bool forEncryption, ICipherParameters parameters);

  protected abstract int EncryptBlock(
    byte[] inBuf,
    int inOff,
    int length,
    byte[] outBuf,
    int outOff);

  protected abstract int DecryptBlock(
    byte[] inBuf,
    int inOff,
    int length,
    byte[] outBuf,
    int outOff);
}
