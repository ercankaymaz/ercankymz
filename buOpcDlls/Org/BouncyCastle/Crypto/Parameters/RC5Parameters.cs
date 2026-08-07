// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.RC5Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class RC5Parameters : KeyParameter
{
  private readonly int rounds;

  public RC5Parameters(byte[] key, int rounds)
    : base(key)
  {
    if (key.Length > (int) byte.MaxValue)
      throw new ArgumentException("RC5 key length can be no greater than 255");
    this.rounds = rounds;
  }

  public int Rounds => this.rounds;
}
