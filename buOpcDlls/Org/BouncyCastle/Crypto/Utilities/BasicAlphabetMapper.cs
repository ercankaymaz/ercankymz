// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.BasicAlphabetMapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

public class BasicAlphabetMapper : IAlphabetMapper
{
  private readonly IDictionary<char, int> m_indexMap = (IDictionary<char, int>) new Dictionary<char, int>();
  private readonly IList<char> m_charMap = (IList<char>) new List<char>();

  public BasicAlphabetMapper(string alphabet)
    : this(alphabet.ToCharArray())
  {
  }

  public BasicAlphabetMapper(char[] alphabet)
  {
    for (int index = 0; index != alphabet.Length; ++index)
    {
      if (this.m_indexMap.ContainsKey(alphabet[index]))
        throw new ArgumentException("duplicate key detected in alphabet: " + alphabet[index].ToString());
      this.m_indexMap.Add(alphabet[index], index);
      this.m_charMap.Add(alphabet[index]);
    }
  }

  public int Radix => this.m_charMap.Count;

  public byte[] ConvertToIndexes(char[] input)
  {
    byte[] indexes;
    if (this.m_charMap.Count <= 256 /*0x0100*/)
    {
      indexes = new byte[input.Length];
      for (int index = 0; index != input.Length; ++index)
      {
        int num;
        if (!this.m_indexMap.TryGetValue(input[index], out num))
          throw new InvalidOperationException();
        indexes[index] = (byte) num;
      }
    }
    else
    {
      indexes = new byte[input.Length * 2];
      for (int index = 0; index != input.Length; ++index)
      {
        int num;
        if (!this.m_indexMap.TryGetValue(input[index], out num))
          throw new InvalidOperationException();
        indexes[index * 2] = (byte) (num >> 8);
        indexes[index * 2 + 1] = (byte) num;
      }
    }
    return indexes;
  }

  public char[] ConvertToChars(byte[] input)
  {
    char[] chars;
    if (this.m_charMap.Count <= 256 /*0x0100*/)
    {
      chars = new char[input.Length];
      for (int index = 0; index != input.Length; ++index)
        chars[index] = this.m_charMap[(int) input[index]];
    }
    else
    {
      chars = (input.Length & 1) == 0 ? new char[input.Length / 2] : throw new ArgumentException("two byte radix and input string odd.Length");
      for (int index = 0; index != input.Length; index += 2)
        chars[index / 2] = this.m_charMap[(int) input[index] << 8 | (int) input[index + 1]];
    }
    return chars;
  }
}
