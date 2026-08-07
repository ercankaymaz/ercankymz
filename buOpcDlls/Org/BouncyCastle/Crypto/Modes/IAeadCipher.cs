// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.IAeadCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public interface IAeadCipher
{
  string AlgorithmName { get; }

  void Init(bool forEncryption, ICipherParameters parameters);

  void ProcessAadByte(byte input);

  void ProcessAadBytes(byte[] inBytes, int inOff, int len);

  int ProcessByte(byte input, byte[] outBytes, int outOff);

  int ProcessBytes(byte[] inBytes, int inOff, int len, byte[] outBytes, int outOff);

  int DoFinal(byte[] outBytes, int outOff);

  byte[] GetMac();

  int GetUpdateOutputSize(int len);

  int GetOutputSize(int len);

  void Reset();
}
