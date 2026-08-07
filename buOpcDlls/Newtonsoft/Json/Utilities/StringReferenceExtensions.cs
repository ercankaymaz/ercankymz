// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.StringReferenceExtensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class StringReferenceExtensions
{
  public static int IndexOf(this StringReference s, char c, int startIndex, int length)
  {
    int num = Array.IndexOf<char>(s.Chars, c, s.StartIndex + startIndex, length);
    return num == -1 ? -1 : num - s.StartIndex;
  }

  public static bool StartsWith(this StringReference s, string text)
  {
    if (text.Length > s.Length)
      return false;
    char[] chars = s.Chars;
    for (int index = 0; index < text.Length; ++index)
    {
      if ((int) text[index] != (int) chars[index + s.StartIndex])
        return false;
    }
    return true;
  }

  public static bool EndsWith(this StringReference s, string text)
  {
    if (text.Length > s.Length)
      return false;
    char[] chars = s.Chars;
    int num = s.StartIndex + s.Length - text.Length;
    for (int index = 0; index < text.Length; ++index)
    {
      if ((int) text[index] != (int) chars[index + num])
        return false;
    }
    return true;
  }
}
