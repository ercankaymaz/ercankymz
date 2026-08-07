// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Check
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto;

internal static class Check
{
  internal static void DataLength(bool condition, string message)
  {
    if (!condition)
      return;
    Check.ThrowDataLengthException(message);
  }

  internal static void DataLength(byte[] buf, int off, int len, string message)
  {
    if (off <= buf.Length - len)
      return;
    Check.ThrowDataLengthException(message);
  }

  internal static void OutputLength(bool condition, string message)
  {
    if (!condition)
      return;
    Check.ThrowOutputLengthException(message);
  }

  internal static void OutputLength(byte[] buf, int off, int len, string message)
  {
    if (off <= buf.Length - len)
      return;
    Check.ThrowOutputLengthException(message);
  }

  internal static void ThrowDataLengthException(string message)
  {
    throw new DataLengthException(message);
  }

  internal static void ThrowOutputLengthException(string message)
  {
    throw new OutputLengthException(message);
  }
}
