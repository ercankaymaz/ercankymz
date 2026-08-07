// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.ITranslator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public interface ITranslator
{
  int GetEncodedBlockSize();

  int Encode(byte[] input, int inOff, int length, byte[] outBytes, int outOff);

  int GetDecodedBlockSize();

  int Decode(byte[] input, int inOff, int length, byte[] outBytes, int outOff);
}
