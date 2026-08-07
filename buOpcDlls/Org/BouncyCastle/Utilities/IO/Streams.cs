// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Streams
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public static class Streams
{
  private static readonly int MaxStackAlloc = Platform.Is64BitProcess ? 4096 /*0x1000*/ : 1024 /*0x0400*/;

  public static int DefaultBufferSize => Streams.MaxStackAlloc;

  public static void CopyTo(Stream source, Stream destination)
  {
    Streams.CopyTo(source, destination, Streams.DefaultBufferSize);
  }

  public static void CopyTo(Stream source, Stream destination, int bufferSize)
  {
    byte[] buffer = new byte[bufferSize];
    int count;
    while ((count = source.Read(buffer, 0, buffer.Length)) != 0)
      destination.Write(buffer, 0, count);
  }

  public static Task CopyToAsync(Stream source, Stream destination)
  {
    return Streams.CopyToAsync(source, destination, Streams.DefaultBufferSize);
  }

  public static Task CopyToAsync(Stream source, Stream destination, int bufferSize)
  {
    return Streams.CopyToAsync(source, destination, bufferSize, CancellationToken.None);
  }

  public static Task CopyToAsync(
    Stream source,
    Stream destination,
    CancellationToken cancellationToken)
  {
    return Streams.CopyToAsync(source, destination, Streams.DefaultBufferSize, cancellationToken);
  }

  public static async Task CopyToAsync(
    Stream source,
    Stream destination,
    int bufferSize,
    CancellationToken cancellationToken)
  {
    byte[] buffer = new byte[bufferSize];
    ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter awaiter1;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter2;
    while (true)
    {
      awaiter1 = source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false).GetAwaiter();
      if (awaiter1.IsCompleted)
      {
        int result;
        if ((result = awaiter1.GetResult()) != 0)
        {
          awaiter2 = destination.WriteAsync(buffer, 0, result, cancellationToken).ConfigureAwait(false).GetAwaiter();
          if (awaiter2.IsCompleted)
            awaiter2.GetResult();
          else
            goto label_6;
        }
        else
          goto label_7;
      }
      else
        break;
    }
    int num = 1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 1;
    ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter configuredTaskAwaiter1 = awaiter1;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter, Streams.\u003CCopyToAsync\u003Ed__8>(ref awaiter1, this);
    return;
label_6:
    num = 0;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 0;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter2 = awaiter2;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Streams.\u003CCopyToAsync\u003Ed__8>(ref awaiter2, this);
    return;
label_7:
    buffer = (byte[]) null;
  }

  public static void Drain(Stream inStr)
  {
    Streams.CopyTo(inStr, Stream.Null, Streams.DefaultBufferSize);
  }

  public static void PipeAll(Stream inStr, Stream outStr)
  {
    Streams.PipeAll(inStr, outStr, Streams.DefaultBufferSize);
  }

  public static void PipeAll(Stream inStr, Stream outStr, int bufferSize)
  {
    Streams.CopyTo(inStr, outStr, bufferSize);
  }

  public static long PipeAllLimited(Stream inStr, long limit, Stream outStr)
  {
    return Streams.PipeAllLimited(inStr, limit, outStr, Streams.DefaultBufferSize);
  }

  public static long PipeAllLimited(Stream inStr, long limit, Stream outStr, int bufferSize)
  {
    LimitedInputStream source = new LimitedInputStream(inStr, limit);
    Streams.CopyTo((Stream) source, outStr, bufferSize);
    return limit - source.CurrentLimit;
  }

  public static byte[] ReadAll(Stream inStr)
  {
    MemoryStream outStr = new MemoryStream();
    Streams.PipeAll(inStr, (Stream) outStr);
    return outStr.ToArray();
  }

  public static byte[] ReadAll(MemoryStream inStr) => inStr.ToArray();

  public static byte[] ReadAllLimited(Stream inStr, int limit)
  {
    MemoryStream outStr = new MemoryStream();
    Streams.PipeAllLimited(inStr, (long) limit, (Stream) outStr);
    return outStr.ToArray();
  }

  public static int ReadFully(Stream inStr, byte[] buf)
  {
    return Streams.ReadFully(inStr, buf, 0, buf.Length);
  }

  public static int ReadFully(Stream inStr, byte[] buf, int off, int len)
  {
    int num1;
    int num2;
    for (num1 = 0; num1 < len; num1 += num2)
    {
      num2 = inStr.Read(buf, off + num1, len - num1);
      if (num2 < 1)
        break;
    }
    return num1;
  }

  public static void ValidateBufferArguments(byte[] buffer, int offset, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    int num1 = buffer.Length - offset;
    if ((offset | num1) < 0)
      throw new ArgumentOutOfRangeException(nameof (offset));
    int num2 = num1 - count;
    if ((count | num2) < 0)
      throw new ArgumentOutOfRangeException(nameof (count));
  }

  public static int WriteBufTo(MemoryStream buf, byte[] output, int offset)
  {
    int int32 = Convert.ToInt32(buf.Length);
    buf.WriteTo((Stream) new MemoryStream(output, offset, int32));
    return int32;
  }
}
