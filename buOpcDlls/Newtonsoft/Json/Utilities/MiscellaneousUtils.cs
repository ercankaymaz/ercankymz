// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.MiscellaneousUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Text.RegularExpressions;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class MiscellaneousUtils
{
  [NullableContext(2)]
  [Conditional("DEBUG")]
  public static void Assert([DoesNotReturnIf(false)] bool condition, string message = null)
  {
  }

  [NullableContext(2)]
  public static bool ValueEquals(object objA, object objB)
  {
    if (objA == objB)
      return true;
    if (objA == null || objB == null)
      return false;
    if (!(objA.GetType() != objB.GetType()))
      return objA.Equals(objB);
    if (ConvertUtils.IsInteger(objA) && ConvertUtils.IsInteger(objB))
      return Convert.ToDecimal(objA, (IFormatProvider) CultureInfo.CurrentCulture).Equals(Convert.ToDecimal(objB, (IFormatProvider) CultureInfo.CurrentCulture));
    switch (objA)
    {
      case double _:
      case float _:
      case Decimal _:
        switch (objB)
        {
          case double _:
          case float _:
          case Decimal _:
            return MathUtils.ApproxEquals(Convert.ToDouble(objA, (IFormatProvider) CultureInfo.CurrentCulture), Convert.ToDouble(objB, (IFormatProvider) CultureInfo.CurrentCulture));
        }
        break;
    }
    return false;
  }

  public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(
    string paramName,
    object actualValue,
    string message)
  {
    string message1 = message + Environment.NewLine + "Actual value was {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, actualValue);
    return new ArgumentOutOfRangeException(paramName, message1);
  }

  public static string ToString([Nullable(2)] object value)
  {
    if (value == null)
      return "{null}";
    return !(value is string str) ? value.ToString() : $"\"{str}\"";
  }

  public static int ByteArrayCompare(byte[] a1, byte[] a2)
  {
    int num1 = a1.Length.CompareTo(a2.Length);
    if (num1 != 0)
      return num1;
    for (int index = 0; index < a1.Length; ++index)
    {
      int num2 = a1[index].CompareTo(a2[index]);
      if (num2 != 0)
        return num2;
    }
    return 0;
  }

  [return: Nullable(2)]
  public static string GetPrefix(string qualifiedName)
  {
    string prefix;
    MiscellaneousUtils.GetQualifiedNameParts(qualifiedName, out prefix, out string _);
    return prefix;
  }

  public static string GetLocalName(string qualifiedName)
  {
    string localName;
    MiscellaneousUtils.GetQualifiedNameParts(qualifiedName, out string _, out localName);
    return localName;
  }

  public static void GetQualifiedNameParts(
    string qualifiedName,
    [Nullable(2)] out string prefix,
    out string localName)
  {
    int length = StringUtils.IndexOf(qualifiedName, ':');
    switch (length)
    {
      case -1:
      case 0:
        prefix = (string) null;
        localName = qualifiedName;
        break;
      default:
        if (qualifiedName.Length - 1 != length)
        {
          prefix = qualifiedName.Substring(0, length);
          localName = qualifiedName.Substring(length + 1);
          break;
        }
        goto case -1;
    }
  }

  internal static RegexOptions GetRegexOptions(string optionsText)
  {
    RegexOptions regexOptions = RegexOptions.None;
    for (int index = 0; index < optionsText.Length; ++index)
    {
      switch (optionsText[index])
      {
        case 'i':
          regexOptions |= RegexOptions.IgnoreCase;
          break;
        case 'm':
          regexOptions |= RegexOptions.Multiline;
          break;
        case 's':
          regexOptions |= RegexOptions.Singleline;
          break;
        case 'x':
          regexOptions |= RegexOptions.ExplicitCapture;
          break;
      }
    }
    return regexOptions;
  }
}
