// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Decode.EncodingFinder
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace buPop3.Mime.Decode;

public static class EncodingFinder
{
  public static EncodingFinder.FallbackDecoderDelegate FallbackDecoder { internal get; set; }

  [CompilerGenerated]
  [SpecialName]
  internal static Dictionary<string, Encoding> smethod_0() => EncodingFinder.dictionary_0;

  [CompilerGenerated]
  [SpecialName]
  internal static void smethod_1(Dictionary<string, Encoding> dictionary_1)
  {
    // ISSUE: reference to a compiler-generated field
    EncodingFinder.dictionary_0 = dictionary_1;
  }

  static EncodingFinder() => Class30.smethod_283();

  public static void AddMapping(string characterSet, Encoding encoding)
  {
    if (characterSet == null)
      throw new ArgumentNullException(nameof (characterSet));
    if (encoding == null)
      throw new ArgumentNullException(nameof (encoding));
    EncodingFinder.smethod_0().Add(characterSet.ToUpperInvariant(), encoding);
  }

  public delegate Encoding FallbackDecoderDelegate(string characterSet);
}
