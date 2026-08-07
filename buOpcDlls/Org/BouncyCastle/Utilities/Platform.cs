// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Platform
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Globalization;
using System.Security;

#nullable disable
namespace Org.BouncyCastle.Utilities;

internal static class Platform
{
  private static readonly CompareInfo InvariantCompareInfo = CultureInfo.InvariantCulture.CompareInfo;

  internal static bool EqualsIgnoreCase(string a, string b)
  {
    return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
  }

  internal static string GetEnvironmentVariable(string variable)
  {
    try
    {
      return Environment.GetEnvironmentVariable(variable);
    }
    catch (SecurityException ex)
    {
      return (string) null;
    }
  }

  internal static int IndexOf(string source, char value)
  {
    return Platform.InvariantCompareInfo.IndexOf(source, value, CompareOptions.Ordinal);
  }

  internal static int IndexOf(string source, string value)
  {
    return Platform.InvariantCompareInfo.IndexOf(source, value, CompareOptions.Ordinal);
  }

  internal static int IndexOf(string source, char value, int startIndex)
  {
    return Platform.InvariantCompareInfo.IndexOf(source, value, startIndex, CompareOptions.Ordinal);
  }

  internal static int IndexOf(string source, string value, int startIndex)
  {
    return Platform.InvariantCompareInfo.IndexOf(source, value, startIndex, CompareOptions.Ordinal);
  }

  internal static bool Is64BitProcess => Environment.Is64BitProcess;

  internal static int LastIndexOf(string source, string value)
  {
    return Platform.InvariantCompareInfo.LastIndexOf(source, value, CompareOptions.Ordinal);
  }

  internal static bool StartsWith(string source, string prefix)
  {
    return Platform.InvariantCompareInfo.IsPrefix(source, prefix, CompareOptions.Ordinal);
  }

  internal static bool StartsWithIgnoreCase(string source, string prefix)
  {
    return Platform.InvariantCompareInfo.IsPrefix(source, prefix, CompareOptions.OrdinalIgnoreCase);
  }

  internal static bool EndsWith(string source, string suffix)
  {
    return Platform.InvariantCompareInfo.IsSuffix(source, suffix, CompareOptions.Ordinal);
  }

  internal static string GetTypeName(object obj) => Platform.GetTypeName(obj.GetType());

  internal static string GetTypeName(Type t) => t.FullName;
}
