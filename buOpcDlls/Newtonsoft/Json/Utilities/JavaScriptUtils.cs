// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.JavaScriptUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
internal static class JavaScriptUtils
{
  internal static readonly bool[] SingleQuoteCharEscapeFlags = new bool[128 /*0x80*/];
  internal static readonly bool[] DoubleQuoteCharEscapeFlags = new bool[128 /*0x80*/];
  internal static readonly bool[] HtmlCharEscapeFlags = new bool[128 /*0x80*/];
  private const int UnicodeTextLength = 6;
  private const string EscapedUnicodeText = "!";

  static JavaScriptUtils()
  {
    IList<char> first = (IList<char>) new List<char>()
    {
      '\n',
      '\r',
      '\t',
      '\\',
      '\f',
      '\b'
    };
    for (int index = 0; index < 32 /*0x20*/; ++index)
      first.Add((char) index);
    foreach (char index in first.Union<char>((IEnumerable<char>) new char[1]
    {
      '\''
    }))
      JavaScriptUtils.SingleQuoteCharEscapeFlags[(int) index] = true;
    foreach (char index in first.Union<char>((IEnumerable<char>) new char[1]
    {
      '"'
    }))
      JavaScriptUtils.DoubleQuoteCharEscapeFlags[(int) index] = true;
    foreach (char index in first.Union<char>((IEnumerable<char>) new char[5]
    {
      '"',
      '\'',
      '<',
      '>',
      '&'
    }))
      JavaScriptUtils.HtmlCharEscapeFlags[(int) index] = true;
  }

  public static bool[] GetCharEscapeFlags(StringEscapeHandling stringEscapeHandling, char quoteChar)
  {
    if (stringEscapeHandling == StringEscapeHandling.EscapeHtml)
      return JavaScriptUtils.HtmlCharEscapeFlags;
    return quoteChar == '"' ? JavaScriptUtils.DoubleQuoteCharEscapeFlags : JavaScriptUtils.SingleQuoteCharEscapeFlags;
  }

  public static bool ShouldEscapeJavaScriptString([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] string s, bool[] charEscapeFlags)
  {
    if (s == null)
      return false;
    for (int index1 = 0; index1 < s.Length; ++index1)
    {
      char index2 = s[index1];
      if ((int) index2 >= charEscapeFlags.Length || charEscapeFlags[(int) index2])
        return true;
    }
    return false;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public static void WriteEscapedJavaScriptString(
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(1)] TextWriter writer,
    string s,
    char delimiter,
    bool appendDelimiters,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(1)] bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling,
    IArrayPool<char> bufferPool,
    ref char[] writeBuffer)
  {
    if (appendDelimiters)
      writer.Write(delimiter);
    if (!StringUtils.IsNullOrEmpty(s))
    {
      int num1 = JavaScriptUtils.FirstCharToEscape(s, charEscapeFlags, stringEscapeHandling);
      switch (num1)
      {
        case -1:
          writer.Write(s);
          break;
        case 0:
          for (int index = num1; index < s.Length; ++index)
          {
            char c = s[index];
            if ((int) c >= charEscapeFlags.Length || charEscapeFlags[(int) c])
            {
              string a;
              switch (c)
              {
                case '\b':
                  a = "\\b";
                  break;
                case '\t':
                  a = "\\t";
                  break;
                case '\n':
                  a = "\\n";
                  break;
                case '\f':
                  a = "\\f";
                  break;
                case '\r':
                  a = "\\r";
                  break;
                case '\\':
                  a = "\\\\";
                  break;
                case '\u0085':
                  a = "\\u0085";
                  break;
                case '\u2028':
                  a = "\\u2028";
                  break;
                case '\u2029':
                  a = "\\u2029";
                  break;
                default:
                  if ((int) c >= charEscapeFlags.Length && stringEscapeHandling != StringEscapeHandling.EscapeNonAscii)
                  {
                    a = (string) null;
                    break;
                  }
                  if (c == '\'' && stringEscapeHandling != StringEscapeHandling.EscapeHtml)
                  {
                    a = "\\'";
                    break;
                  }
                  if (c == '"' && stringEscapeHandling != StringEscapeHandling.EscapeHtml)
                  {
                    a = "\\\"";
                    break;
                  }
                  if (writeBuffer == null || writeBuffer.Length < 6)
                    writeBuffer = BufferUtils.EnsureBufferSize(bufferPool, 6, writeBuffer);
                  StringUtils.ToCharAsUnicode(c, writeBuffer);
                  a = "!";
                  break;
              }
              if (a != null)
              {
                bool flag = string.Equals(a, "!", StringComparison.Ordinal);
                if (index > num1)
                {
                  int minSize = index - num1 + (flag ? 6 : 0);
                  int num2 = flag ? 6 : 0;
                  if (writeBuffer == null || writeBuffer.Length < minSize)
                  {
                    char[] destinationArray = BufferUtils.RentBuffer(bufferPool, minSize);
                    if (flag)
                      Array.Copy((Array) writeBuffer, (Array) destinationArray, 6);
                    BufferUtils.ReturnBuffer(bufferPool, writeBuffer);
                    writeBuffer = destinationArray;
                  }
                  s.CopyTo(num1, writeBuffer, num2, minSize - num2);
                  writer.Write(writeBuffer, num2, minSize - num2);
                }
                num1 = index + 1;
                if (!flag)
                  writer.Write(a);
                else
                  writer.Write(writeBuffer, 0, 6);
              }
            }
          }
          int num3 = s.Length - num1;
          if (num3 > 0)
          {
            if (writeBuffer == null || writeBuffer.Length < num3)
              writeBuffer = BufferUtils.EnsureBufferSize(bufferPool, num3, writeBuffer);
            s.CopyTo(num1, writeBuffer, 0, num3);
            writer.Write(writeBuffer, 0, num3);
            break;
          }
          break;
        default:
          if (writeBuffer == null || writeBuffer.Length < num1)
            writeBuffer = BufferUtils.EnsureBufferSize(bufferPool, num1, writeBuffer);
          s.CopyTo(0, writeBuffer, 0, num1);
          writer.Write(writeBuffer, 0, num1);
          goto case 0;
      }
    }
    if (!appendDelimiters)
      return;
    writer.Write(delimiter);
  }

  public static string ToEscapedJavaScriptString(
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] string value,
    char delimiter,
    bool appendDelimiters,
    StringEscapeHandling stringEscapeHandling)
  {
    bool[] charEscapeFlags = JavaScriptUtils.GetCharEscapeFlags(stringEscapeHandling, delimiter);
    using (StringWriter stringWriter = StringUtils.CreateStringWriter(value != null ? value.Length : 16 /*0x10*/))
    {
      char[] writeBuffer = (char[]) null;
      JavaScriptUtils.WriteEscapedJavaScriptString((TextWriter) stringWriter, value, delimiter, appendDelimiters, charEscapeFlags, stringEscapeHandling, (IArrayPool<char>) null, ref writeBuffer);
      return stringWriter.ToString();
    }
  }

  private static int FirstCharToEscape(
    string s,
    bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling)
  {
    for (int index1 = 0; index1 != s.Length; ++index1)
    {
      char index2 = s[index1];
      if ((int) index2 < charEscapeFlags.Length)
      {
        if (charEscapeFlags[(int) index2])
          return index1;
      }
      else if (stringEscapeHandling == StringEscapeHandling.EscapeNonAscii || index2 == '\u0085' || index2 == '\u2028' || index2 == '\u2029')
        return index1;
    }
    return -1;
  }

  public static Task WriteEscapedJavaScriptStringAsync(
    TextWriter writer,
    string s,
    char delimiter,
    bool appendDelimiters,
    bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling,
    JsonTextWriter client,
    char[] writeBuffer,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    if (cancellationToken.IsCancellationRequested)
      return cancellationToken.FromCanceled();
    if (appendDelimiters)
      return JavaScriptUtils.WriteEscapedJavaScriptStringWithDelimitersAsync(writer, s, delimiter, charEscapeFlags, stringEscapeHandling, client, writeBuffer, cancellationToken);
    return StringUtils.IsNullOrEmpty(s) ? cancellationToken.CancelIfRequestedAsync() ?? AsyncUtils.CompletedTask : JavaScriptUtils.WriteEscapedJavaScriptStringWithoutDelimitersAsync(writer, s, charEscapeFlags, stringEscapeHandling, client, writeBuffer, cancellationToken);
  }

  private static Task WriteEscapedJavaScriptStringWithDelimitersAsync(
    TextWriter writer,
    string s,
    char delimiter,
    bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling,
    JsonTextWriter client,
    char[] writeBuffer,
    CancellationToken cancellationToken)
  {
    Task task = writer.WriteAsync(delimiter, cancellationToken);
    if (!task.IsCompletedSuccessfully())
      return JavaScriptUtils.WriteEscapedJavaScriptStringWithDelimitersAsync(task, writer, s, delimiter, charEscapeFlags, stringEscapeHandling, client, writeBuffer, cancellationToken);
    if (!StringUtils.IsNullOrEmpty(s))
    {
      task = JavaScriptUtils.WriteEscapedJavaScriptStringWithoutDelimitersAsync(writer, s, charEscapeFlags, stringEscapeHandling, client, writeBuffer, cancellationToken);
      if (task.IsCompletedSuccessfully())
        return writer.WriteAsync(delimiter, cancellationToken);
    }
    return JavaScriptUtils.WriteCharAsync(task, writer, delimiter, cancellationToken);
  }

  private static async Task WriteEscapedJavaScriptStringWithDelimitersAsync(
    Task task,
    TextWriter writer,
    string s,
    char delimiter,
    bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling,
    JsonTextWriter client,
    char[] writeBuffer,
    CancellationToken cancellationToken)
  {
    await task.ConfigureAwait(false);
    if (!StringUtils.IsNullOrEmpty(s))
      await JavaScriptUtils.WriteEscapedJavaScriptStringWithoutDelimitersAsync(writer, s, charEscapeFlags, stringEscapeHandling, client, writeBuffer, cancellationToken).ConfigureAwait(false);
    await writer.WriteAsync(delimiter).ConfigureAwait(false);
  }

  public static async Task WriteCharAsync(
    Task task,
    TextWriter writer,
    char c,
    CancellationToken cancellationToken)
  {
    await task.ConfigureAwait(false);
    await writer.WriteAsync(c, cancellationToken).ConfigureAwait(false);
  }

  private static Task WriteEscapedJavaScriptStringWithoutDelimitersAsync(
    TextWriter writer,
    string s,
    bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling,
    JsonTextWriter client,
    char[] writeBuffer,
    CancellationToken cancellationToken)
  {
    int escape = JavaScriptUtils.FirstCharToEscape(s, charEscapeFlags, stringEscapeHandling);
    return escape != -1 ? JavaScriptUtils.WriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync(writer, s, escape, charEscapeFlags, stringEscapeHandling, client, writeBuffer, cancellationToken) : writer.WriteAsync(s, cancellationToken);
  }

  private static async Task WriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync(
    TextWriter writer,
    string s,
    int lastWritePosition,
    bool[] charEscapeFlags,
    StringEscapeHandling stringEscapeHandling,
    JsonTextWriter client,
    char[] writeBuffer,
    CancellationToken cancellationToken)
  {
    if (writeBuffer == null || writeBuffer.Length < lastWritePosition)
      writeBuffer = client.EnsureWriteBuffer(lastWritePosition, 6);
    ConfiguredTaskAwaitable configuredTaskAwaitable;
    if (lastWritePosition != 0)
    {
      s.CopyTo(0, writeBuffer, 0, lastWritePosition);
      configuredTaskAwaitable = writer.WriteAsync(writeBuffer, 0, lastWritePosition, cancellationToken).ConfigureAwait(false);
      await configuredTaskAwaitable;
    }
    bool isEscapedUnicodeText = false;
    string escapedValue = (string) null;
    for (int i = lastWritePosition; i < s.Length; ++i)
    {
      char c = s[i];
      if ((int) c >= charEscapeFlags.Length || charEscapeFlags[(int) c])
      {
        switch (c)
        {
          case '\b':
            escapedValue = "\\b";
            break;
          case '\t':
            escapedValue = "\\t";
            break;
          case '\n':
            escapedValue = "\\n";
            break;
          case '\f':
            escapedValue = "\\f";
            break;
          case '\r':
            escapedValue = "\\r";
            break;
          case '\\':
            escapedValue = "\\\\";
            break;
          case '\u0085':
            escapedValue = "\\u0085";
            break;
          case '\u2028':
            escapedValue = "\\u2028";
            break;
          case '\u2029':
            escapedValue = "\\u2029";
            break;
          default:
            if ((int) c < charEscapeFlags.Length || stringEscapeHandling == StringEscapeHandling.EscapeNonAscii)
            {
              if (c == '\'' && stringEscapeHandling != StringEscapeHandling.EscapeHtml)
              {
                escapedValue = "\\'";
                break;
              }
              if (c == '"' && stringEscapeHandling != StringEscapeHandling.EscapeHtml)
              {
                escapedValue = "\\\"";
                break;
              }
              if (writeBuffer.Length < 6)
                writeBuffer = client.EnsureWriteBuffer(6, 0);
              StringUtils.ToCharAsUnicode(c, writeBuffer);
              isEscapedUnicodeText = true;
              break;
            }
            continue;
        }
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter;
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
        int num1;
        if (i > lastWritePosition)
        {
          int length = i - lastWritePosition + (isEscapedUnicodeText ? 6 : 0);
          int num2 = isEscapedUnicodeText ? 6 : 0;
          if (writeBuffer.Length < length)
            writeBuffer = client.EnsureWriteBuffer(length, 6);
          s.CopyTo(lastWritePosition, writeBuffer, num2, length - num2);
          configuredTaskAwaitable = writer.WriteAsync(writeBuffer, num2, length - num2, cancellationToken).ConfigureAwait(false);
          awaiter = configuredTaskAwaitable.GetAwaiter();
          if (awaiter.IsCompleted)
          {
            awaiter.GetResult();
          }
          else
          {
            num1 = 1;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003E1__state = 1;
            configuredTaskAwaiter = awaiter;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JavaScriptUtils.\u003CWriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync\u003Ed__16>(ref awaiter, this);
            return;
          }
        }
        lastWritePosition = i + 1;
        if (!isEscapedUnicodeText)
        {
          configuredTaskAwaitable = writer.WriteAsync(escapedValue, cancellationToken).ConfigureAwait(false);
          awaiter = configuredTaskAwaitable.GetAwaiter();
          if (awaiter.IsCompleted)
          {
            awaiter.GetResult();
          }
          else
          {
            num1 = 2;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003E1__state = 2;
            configuredTaskAwaiter = awaiter;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JavaScriptUtils.\u003CWriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync\u003Ed__16>(ref awaiter, this);
            return;
          }
        }
        else
        {
          configuredTaskAwaitable = writer.WriteAsync(writeBuffer, 0, 6, cancellationToken).ConfigureAwait(false);
          awaiter = configuredTaskAwaitable.GetAwaiter();
          if (awaiter.IsCompleted)
          {
            awaiter.GetResult();
            isEscapedUnicodeText = false;
          }
          else
          {
            num1 = 3;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003E1__state = 3;
            configuredTaskAwaiter = awaiter;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JavaScriptUtils.\u003CWriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync\u003Ed__16>(ref awaiter, this);
            return;
          }
        }
      }
    }
    int num = s.Length - lastWritePosition;
    if (num == 0)
    {
      escapedValue = (string) null;
    }
    else
    {
      if (writeBuffer.Length < num)
        writeBuffer = client.EnsureWriteBuffer(num, 0);
      s.CopyTo(lastWritePosition, writeBuffer, 0, num);
      configuredTaskAwaitable = writer.WriteAsync(writeBuffer, 0, num, cancellationToken).ConfigureAwait(false);
      await configuredTaskAwaitable;
      escapedValue = (string) null;
    }
  }

  public static bool TryGetDateFromConstructorJson(
    JsonReader reader,
    out DateTime dateTime,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2), NotNullWhen(false)] out string errorMessage)
  {
    dateTime = new DateTime();
    errorMessage = (string) null;
    long? integer1;
    if (JavaScriptUtils.TryGetDateConstructorValue(reader, out integer1, out errorMessage) && integer1.HasValue)
    {
      long? integer2;
      if (!JavaScriptUtils.TryGetDateConstructorValue(reader, out integer2, out errorMessage))
        return false;
      if (integer2.HasValue)
      {
        List<long> longList = new List<long>()
        {
          integer1.Value,
          integer2.Value
        };
        long? integer3;
        while (JavaScriptUtils.TryGetDateConstructorValue(reader, out integer3, out errorMessage))
        {
          if (integer3.HasValue)
          {
            longList.Add(integer3.Value);
          }
          else
          {
            if (longList.Count > 7)
            {
              errorMessage = "Unexpected number of arguments when reading date constructor.";
              return false;
            }
            while (longList.Count < 7)
              longList.Add(0L);
            dateTime = new DateTime((int) longList[0], (int) longList[1] + 1, longList[2] == 0L ? 1 : (int) longList[2], (int) longList[3], (int) longList[4], (int) longList[5], (int) longList[6]);
            goto label_15;
          }
        }
        return false;
      }
      dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(integer1.Value);
label_15:
      return true;
    }
    errorMessage = errorMessage ?? "Date constructor has no arguments.";
    return false;
  }

  private static bool TryGetDateConstructorValue(
    JsonReader reader,
    out long? integer,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2), NotNullWhen(false)] out string errorMessage)
  {
    integer = new long?();
    errorMessage = (string) null;
    if (!reader.Read())
    {
      errorMessage = "Unexpected end when reading date constructor.";
      return false;
    }
    if (reader.TokenType == JsonToken.EndConstructor)
      return true;
    if (reader.TokenType != JsonToken.Integer)
    {
      errorMessage = "Unexpected token when reading date constructor. Expected Integer, got " + reader.TokenType.ToString();
      return false;
    }
    integer = new long?((long) reader.Value);
    return true;
  }
}
