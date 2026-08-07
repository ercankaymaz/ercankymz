// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.LogValuesFormatter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Text;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(1)]
[Nullable(0)]
internal sealed class LogValuesFormatter
{
  private const string NullValue = "(null)";
  private static readonly char[] FormatDelimiters = new char[2]
  {
    ',',
    ':'
  };
  private readonly string _format;
  private readonly List<string> _valueNames = new List<string>();

  public LogValuesFormatter(string format)
  {
    this.OriginalFormat = format != null ? format : throw new ArgumentNullException(nameof (format));
    ValueStringBuilder valueStringBuilder = new ValueStringBuilder(stackalloc char[256 /*0x0100*/]);
    int num = 0;
    int length = format.Length;
    while (num < length)
    {
      int braceIndex1 = LogValuesFormatter.FindBraceIndex(format, '{', num, length);
      if (num != 0 || braceIndex1 != length)
      {
        int braceIndex2 = LogValuesFormatter.FindBraceIndex(format, '}', braceIndex1, length);
        if (braceIndex2 == length)
        {
          valueStringBuilder.Append(format.AsSpan(num, length - num));
          num = length;
        }
        else
        {
          int indexOfAny = LogValuesFormatter.FindIndexOfAny(format, LogValuesFormatter.FormatDelimiters, braceIndex1, braceIndex2);
          valueStringBuilder.Append(format.AsSpan(num, braceIndex1 - num + 1));
          valueStringBuilder.Append(this._valueNames.Count.ToString());
          this._valueNames.Add(format.Substring(braceIndex1 + 1, indexOfAny - braceIndex1 - 1));
          valueStringBuilder.Append(format.AsSpan(indexOfAny, braceIndex2 - indexOfAny + 1));
          num = braceIndex2 + 1;
        }
      }
      else
      {
        this._format = format;
        return;
      }
    }
    this._format = valueStringBuilder.ToString();
  }

  public string OriginalFormat { get; private set; }

  public List<string> ValueNames => this._valueNames;

  private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex)
  {
    int braceIndex = endIndex;
    int index = startIndex;
    int num = 0;
    for (; index < endIndex; ++index)
    {
      if (num > 0 && (int) format[index] != (int) brace)
      {
        if (num % 2 == 0)
        {
          num = 0;
          braceIndex = endIndex;
        }
        else
          break;
      }
      else if ((int) format[index] == (int) brace)
      {
        if (brace == '}')
        {
          if (num == 0)
            braceIndex = index;
        }
        else
          braceIndex = index;
        ++num;
      }
    }
    return braceIndex;
  }

  private static int FindIndexOfAny(string format, char[] chars, int startIndex, int endIndex)
  {
    int num = format.IndexOfAny(chars, startIndex, endIndex - startIndex);
    return num != -1 ? num : endIndex;
  }

  public string Format([Nullable(2)] object[] values)
  {
    object[] destinationArray = values;
    if (values != null)
    {
      for (int length = 0; length < values.Length; ++length)
      {
        object obj1 = this.FormatArgument(values[length]);
        if (obj1 != values[length])
        {
          destinationArray = new object[values.Length];
          Array.Copy((Array) values, (Array) destinationArray, length);
          object[] objArray = destinationArray;
          int index1 = length;
          int index2 = index1 + 1;
          object obj2 = obj1;
          objArray[index1] = obj2;
          for (; index2 < values.Length; ++index2)
            destinationArray[index2] = this.FormatArgument(values[index2]);
          break;
        }
      }
    }
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, this._format, destinationArray ?? Array.Empty<object>());
  }

  internal string FormatWithOverwrite([Nullable(2)] object[] values)
  {
    if (values != null)
    {
      for (int index = 0; index < values.Length; ++index)
        values[index] = this.FormatArgument(values[index]);
    }
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, this._format, values ?? Array.Empty<object>());
  }

  internal string Format() => this._format;

  internal string Format([Nullable(2)] object arg0)
  {
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, this._format, this.FormatArgument(arg0));
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  internal string Format(object arg0, object arg1)
  {
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, this._format, this.FormatArgument(arg0), this.FormatArgument(arg1));
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  internal string Format(object arg0, object arg1, object arg2)
  {
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, this._format, this.FormatArgument(arg0), this.FormatArgument(arg1), this.FormatArgument(arg2));
  }

  [return: Nullable(new byte[] {0, 1, 2})]
  public KeyValuePair<string, object> GetValue([Nullable(new byte[] {1, 2})] object[] values, int index)
  {
    if (index < 0 || index > this._valueNames.Count)
      throw new IndexOutOfRangeException(nameof (index));
    return this._valueNames.Count > index ? new KeyValuePair<string, object>(this._valueNames[index], values[index]) : new KeyValuePair<string, object>("{OriginalFormat}", (object) this.OriginalFormat);
  }

  [return: Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, object>> GetValues(object[] values)
  {
    KeyValuePair<string, object>[] values1 = new KeyValuePair<string, object>[values.Length + 1];
    for (int index = 0; index != this._valueNames.Count; ++index)
      values1[index] = new KeyValuePair<string, object>(this._valueNames[index], values[index]);
    values1[values1.Length - 1] = new KeyValuePair<string, object>("{OriginalFormat}", (object) this.OriginalFormat);
    return (IEnumerable<KeyValuePair<string, object>>) values1;
  }

  private object FormatArgument(object value)
  {
    switch (value)
    {
      case null:
        return (object) "(null)";
      case string _:
        return value;
      case IEnumerable enumerable:
        ValueStringBuilder valueStringBuilder = new ValueStringBuilder(stackalloc char[256 /*0x0100*/]);
        bool flag = true;
        foreach (object obj in enumerable)
        {
          if (!flag)
            valueStringBuilder.Append(", ");
          valueStringBuilder.Append(obj != null ? obj.ToString() : "(null)");
          flag = false;
        }
        return (object) valueStringBuilder.ToString();
      default:
        return value;
    }
  }
}
