// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.SXprUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public sealed class SXprUtilities
{
  private SXprUtilities()
  {
  }

  private static int ReadLength(Stream input, int ch)
  {
    int num = ch - 48 /*0x30*/;
    while ((ch = input.ReadByte()) >= 0 && ch != 58)
      num = num * 10 + ch - 48 /*0x30*/;
    return num;
  }

  internal static string ReadString(Stream input, int ch)
  {
    char[] chArray = new char[SXprUtilities.ReadLength(input, ch)];
    for (int index = 0; index != chArray.Length; ++index)
      chArray[index] = (char) input.ReadByte();
    return new string(chArray);
  }

  internal static byte[] ReadBytes(Stream input, int ch)
  {
    byte[] buf = new byte[SXprUtilities.ReadLength(input, ch)];
    Streams.ReadFully(input, buf);
    return buf;
  }

  internal static S2k ParseS2k(Stream input)
  {
    SXprUtilities.SkipOpenParenthesis(input);
    SXprUtilities.ReadString(input, input.ReadByte());
    byte[] iv = SXprUtilities.ReadBytes(input, input.ReadByte());
    long iterationCount64 = long.Parse(SXprUtilities.ReadString(input, input.ReadByte()));
    SXprUtilities.SkipCloseParenthesis(input);
    return (S2k) new SXprUtilities.MyS2k(HashAlgorithmTag.Sha1, iv, iterationCount64);
  }

  internal static void SkipOpenParenthesis(Stream input)
  {
    if (input.ReadByte() != 40)
      throw new IOException("unknown character encountered");
  }

  internal static void SkipCloseParenthesis(Stream input)
  {
    if (input.ReadByte() != 41)
      throw new IOException("unknown character encountered");
  }

  private class MyS2k : S2k
  {
    private readonly long mIterationCount64;

    internal MyS2k(HashAlgorithmTag algorithm, byte[] iv, long iterationCount64)
      : base(algorithm, iv, (int) iterationCount64)
    {
      this.mIterationCount64 = iterationCount64;
    }

    public override long IterationCount => this.mIterationCount64;
  }
}
