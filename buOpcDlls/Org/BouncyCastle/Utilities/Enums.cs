// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Enums
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Date;
using System;

#nullable disable
namespace Org.BouncyCastle.Utilities;

internal static class Enums
{
  internal static TEnum GetEnumValue<TEnum>(string s) where TEnum : struct, Enum
  {
    s = s.Length > 0 && char.IsLetter(s[0]) && s.IndexOf(',') < 0 ? s.Replace('-', '_') : throw new ArgumentException();
    s = s.Replace('/', '_');
    return (TEnum) Enum.Parse(typeof (TEnum), s, false);
  }

  internal static TEnum[] GetEnumValues<TEnum>() where TEnum : struct, Enum
  {
    return (TEnum[]) Enum.GetValues(typeof (TEnum));
  }

  internal static TEnum GetArbitraryValue<TEnum>() where TEnum : struct, Enum
  {
    TEnum[] enumValues = Enums.GetEnumValues<TEnum>();
    int index = (int) (DateTimeUtilities.CurrentUnixMs() & (long) int.MaxValue) % enumValues.Length;
    return enumValues[index];
  }
}
