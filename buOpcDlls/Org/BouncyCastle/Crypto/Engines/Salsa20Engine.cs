// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.Salsa20Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class Salsa20Engine : IStreamCipher
{
  public static readonly int DEFAULT_ROUNDS = 20;
  private const int StateSize = 16 /*0x10*/;
  private static readonly uint[] TAU_SIGMA = Pack.LE_To_UInt32(Strings.ToAsciiByteArray("expand 16-byte kexpand 32-byte k"), 0, 8);
  protected int rounds;
  internal int index;
  internal uint[] engineState = new uint[16 /*0x10*/];
  internal uint[] x = new uint[16 /*0x10*/];
  internal byte[] keyStream = new byte[64 /*0x40*/];
  internal bool initialised;
  private uint cW0;
  private uint cW1;
  private uint cW2;

  internal static void PackTauOrSigma(int keyLength, uint[] state, int stateOffset)
  {
    int index = (keyLength - 16 /*0x10*/) / 4;
    state[stateOffset] = Salsa20Engine.TAU_SIGMA[index];
    state[stateOffset + 1] = Salsa20Engine.TAU_SIGMA[index + 1];
    state[stateOffset + 2] = Salsa20Engine.TAU_SIGMA[index + 2];
    state[stateOffset + 3] = Salsa20Engine.TAU_SIGMA[index + 3];
  }

  public Salsa20Engine()
    : this(Salsa20Engine.DEFAULT_ROUNDS)
  {
  }

  public Salsa20Engine(int rounds)
  {
    this.rounds = rounds > 0 && (rounds & 1) == 0 ? rounds : throw new ArgumentException("'rounds' must be a positive, even number");
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    byte[] ivBytes = parameters is ParametersWithIV parametersWithIv ? parametersWithIv.GetIV() : throw new ArgumentException(this.AlgorithmName + " Init requires an IV", nameof (parameters));
    if (ivBytes == null || ivBytes.Length != this.NonceSize)
      throw new ArgumentException($"{this.AlgorithmName} requires exactly {this.NonceSize.ToString()} bytes of IV");
    ICipherParameters parameters1 = parametersWithIv.Parameters;
    if (parameters1 == null)
    {
      if (!this.initialised)
        throw new InvalidOperationException(this.AlgorithmName + " KeyParameter can not be null for first initialisation");
      this.SetKey((byte[]) null, ivBytes);
    }
    else
    {
      if (!(parameters1 is KeyParameter))
        throw new ArgumentException(this.AlgorithmName + " Init parameters must contain a KeyParameter (or null for re-init)");
      this.SetKey(((KeyParameter) parameters1).GetKey(), ivBytes);
    }
    this.Reset();
    this.initialised = true;
  }

  protected virtual int NonceSize => 8;

  public virtual string AlgorithmName
  {
    get
    {
      string algorithmName = "Salsa20";
      if (this.rounds != Salsa20Engine.DEFAULT_ROUNDS)
        algorithmName = $"{algorithmName}/{this.rounds.ToString()}";
      return algorithmName;
    }
  }

  public virtual byte ReturnByte(byte input)
  {
    if (this.LimitExceeded())
      throw new MaxBytesExceededException("2^70 byte limit per IV; Change IV");
    if (this.index == 0)
    {
      this.GenerateKeyStream(this.keyStream);
      this.AdvanceCounter();
    }
    int num = (int) (byte) ((uint) this.keyStream[this.index] ^ (uint) input);
    this.index = this.index + 1 & 63 /*0x3F*/;
    return (byte) num;
  }

  protected virtual void AdvanceCounter()
  {
    if (++this.engineState[8] != 0U)
      return;
    ++this.engineState[9];
  }

  public virtual void ProcessBytes(
    byte[] inBytes,
    int inOff,
    int len,
    byte[] outBytes,
    int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, len, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, len, "output buffer too short");
    if (this.LimitExceeded((uint) len))
      throw new MaxBytesExceededException("2^70 byte limit per IV would be exceeded; Change IV");
    for (int index = 0; index < len; ++index)
    {
      if (this.index == 0)
      {
        this.GenerateKeyStream(this.keyStream);
        this.AdvanceCounter();
      }
      outBytes[index + outOff] = (byte) ((uint) this.keyStream[this.index] ^ (uint) inBytes[index + inOff]);
      this.index = this.index + 1 & 63 /*0x3F*/;
    }
  }

  public virtual void Reset()
  {
    this.index = 0;
    this.ResetLimitCounter();
    this.ResetCounter();
  }

  protected virtual void ResetCounter()
  {
    uint[] engineState = this.engineState;
    this.engineState[9] = 0U;
    engineState[8] = 0U;
  }

  protected virtual void SetKey(byte[] keyBytes, byte[] ivBytes)
  {
    if (keyBytes != null)
    {
      if (keyBytes.Length != 16 /*0x10*/ && keyBytes.Length != 32 /*0x20*/)
        throw new ArgumentException(this.AlgorithmName + " requires 128 bit or 256 bit key");
      int index = (keyBytes.Length - 16 /*0x10*/) / 4;
      this.engineState[0] = Salsa20Engine.TAU_SIGMA[index];
      this.engineState[5] = Salsa20Engine.TAU_SIGMA[index + 1];
      this.engineState[10] = Salsa20Engine.TAU_SIGMA[index + 2];
      this.engineState[15] = Salsa20Engine.TAU_SIGMA[index + 3];
      Pack.LE_To_UInt32(keyBytes, 0, this.engineState, 1, 4);
      Pack.LE_To_UInt32(keyBytes, keyBytes.Length - 16 /*0x10*/, this.engineState, 11, 4);
    }
    Pack.LE_To_UInt32(ivBytes, 0, this.engineState, 6, 2);
  }

  protected virtual void GenerateKeyStream(byte[] output)
  {
    Salsa20Engine.SalsaCore(this.rounds, this.engineState, this.x);
    Pack.UInt32_To_LE(this.x, output, 0);
  }

  internal static void SalsaCore(int rounds, uint[] input, uint[] output)
  {
    if (input.Length < 16 /*0x10*/)
      throw new ArgumentException();
    if (output.Length < 16 /*0x10*/)
      throw new ArgumentException();
    if (rounds % 2 != 0)
      throw new ArgumentException("Number of rounds must be even");
    uint a1 = input[0];
    uint num1 = input[1];
    uint c1 = input[2];
    uint num2 = input[3];
    uint num3 = input[4];
    uint a2 = input[5];
    uint num4 = input[6];
    uint c2 = input[7];
    uint c3 = input[8];
    uint num5 = input[9];
    uint a3 = input[10];
    uint num6 = input[11];
    uint num7 = input[12];
    uint c4 = input[13];
    uint num8 = input[14];
    uint a4 = input[15];
    for (int index = rounds; index > 0; index -= 2)
    {
      Salsa20Engine.QuarterRound(ref a1, ref num3, ref c3, ref num7);
      Salsa20Engine.QuarterRound(ref a2, ref num5, ref c4, ref num1);
      Salsa20Engine.QuarterRound(ref a3, ref num8, ref c1, ref num4);
      Salsa20Engine.QuarterRound(ref a4, ref num2, ref c2, ref num6);
      Salsa20Engine.QuarterRound(ref a1, ref num1, ref c1, ref num2);
      Salsa20Engine.QuarterRound(ref a2, ref num4, ref c2, ref num3);
      Salsa20Engine.QuarterRound(ref a3, ref num6, ref c3, ref num5);
      Salsa20Engine.QuarterRound(ref a4, ref num7, ref c4, ref num8);
    }
    output[0] = a1 + input[0];
    output[1] = num1 + input[1];
    output[2] = c1 + input[2];
    output[3] = num2 + input[3];
    output[4] = num3 + input[4];
    output[5] = a2 + input[5];
    output[6] = num4 + input[6];
    output[7] = c2 + input[7];
    output[8] = c3 + input[8];
    output[9] = num5 + input[9];
    output[10] = a3 + input[10];
    output[11] = num6 + input[11];
    output[12] = num7 + input[12];
    output[13] = c4 + input[13];
    output[14] = num8 + input[14];
    output[15] = a4 + input[15];
  }

  internal void ResetLimitCounter()
  {
    this.cW0 = 0U;
    this.cW1 = 0U;
    this.cW2 = 0U;
  }

  internal bool LimitExceeded()
  {
    return ++this.cW0 == 0U && ++this.cW1 == 0U && (++this.cW2 & 32U /*0x20*/) > 0U;
  }

  internal bool LimitExceeded(uint len)
  {
    uint cW0 = this.cW0;
    this.cW0 += len;
    return this.cW0 < cW0 && ++this.cW1 == 0U && (++this.cW2 & 32U /*0x20*/) > 0U;
  }

  private static void QuarterRound(ref uint a, ref uint b, ref uint c, ref uint d)
  {
    b ^= Integers.RotateLeft(a + d, 7);
    c ^= Integers.RotateLeft(b + a, 9);
    d ^= Integers.RotateLeft(c + b, 13);
    a ^= Integers.RotateLeft(d + c, 18);
  }
}
