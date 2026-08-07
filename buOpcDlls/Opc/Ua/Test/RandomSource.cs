// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Test.RandomSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Test;

[ComVisible(true)]
public class RandomSource : IRandomSource
{
  private Random m_random;

  public RandomSource() => this.m_random = new Random();

  public RandomSource(int seed) => this.m_random = new Random(seed);

  public void NextBytes(byte[] bytes, int offset, int count)
  {
    if (bytes == null)
      throw new ArgumentNullException(nameof (bytes));
    if (offset < 0 || offset != 0 && offset >= bytes.Length)
      throw new ArgumentOutOfRangeException(nameof (offset));
    if (count < 0 || offset + count > bytes.Length)
      throw new ArgumentOutOfRangeException(nameof (count));
    if (bytes.Length == 0)
      return;
    if (offset == 0 && count == bytes.Length)
    {
      this.m_random.NextBytes(bytes);
    }
    else
    {
      byte[] numArray = new byte[count];
      this.m_random.NextBytes(numArray);
      Array.Copy((Array) numArray, 0, (Array) bytes, offset, count);
    }
  }

  public int NextInt32(int max)
  {
    if (max < 0)
      throw new ArgumentOutOfRangeException(nameof (max));
    if (max < int.MaxValue)
      ++max;
    return this.m_random.Next(max);
  }
}
