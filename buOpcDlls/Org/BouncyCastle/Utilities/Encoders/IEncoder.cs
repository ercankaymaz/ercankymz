// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.IEncoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public interface IEncoder
{
  int Encode(byte[] data, int off, int length, Stream outStream);

  int Decode(byte[] data, int off, int length, Stream outStream);

  int DecodeString(string data, Stream outStream);
}
