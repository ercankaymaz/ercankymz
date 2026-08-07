// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.AsyncUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal static class AsyncUtils
{
  public static readonly Task<bool> False = Task.FromResult<bool>(false);
  public static readonly Task<bool> True = Task.FromResult<bool>(true);
  internal static readonly Task CompletedTask = Task.Delay(0);

  internal static Task<bool> ToAsync(this bool value)
  {
    return !value ? AsyncUtils.False : AsyncUtils.True;
  }

  [NullableContext(2)]
  public static Task CancelIfRequestedAsync(this CancellationToken cancellationToken)
  {
    return !cancellationToken.IsCancellationRequested ? (Task) null : cancellationToken.FromCanceled();
  }

  [NullableContext(2)]
  [return: Nullable(new byte[] {2, 1})]
  public static Task<T> CancelIfRequestedAsync<T>(this CancellationToken cancellationToken)
  {
    return !cancellationToken.IsCancellationRequested ? (Task<T>) null : cancellationToken.FromCanceled<T>();
  }

  public static Task FromCanceled(this CancellationToken cancellationToken)
  {
    return new Task((Action) (() => { }), cancellationToken);
  }

  public static Task<T> FromCanceled<[Nullable(2)] T>(this CancellationToken cancellationToken)
  {
    return new Task<T>((Func<T>) ([NullableContext(0)] () => default (T)), cancellationToken);
  }

  public static Task WriteAsync(
    this TextWriter writer,
    char value,
    CancellationToken cancellationToken)
  {
    return !cancellationToken.IsCancellationRequested ? writer.WriteAsync(value) : cancellationToken.FromCanceled();
  }

  public static Task WriteAsync(
    this TextWriter writer,
    [Nullable(2)] string value,
    CancellationToken cancellationToken)
  {
    return !cancellationToken.IsCancellationRequested ? writer.WriteAsync(value) : cancellationToken.FromCanceled();
  }

  public static Task WriteAsync(
    this TextWriter writer,
    char[] value,
    int start,
    int count,
    CancellationToken cancellationToken)
  {
    return !cancellationToken.IsCancellationRequested ? writer.WriteAsync(value, start, count) : cancellationToken.FromCanceled();
  }

  public static Task<int> ReadAsync(
    this TextReader reader,
    char[] buffer,
    int index,
    int count,
    CancellationToken cancellationToken)
  {
    return !cancellationToken.IsCancellationRequested ? reader.ReadAsync(buffer, index, count) : cancellationToken.FromCanceled<int>();
  }

  public static bool IsCompletedSuccessfully(this Task task)
  {
    return task.Status == TaskStatus.RanToCompletion;
  }
}
