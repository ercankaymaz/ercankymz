// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.Base64Encoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
internal class Base64Encoder
{
  private const int Base64LineSize = 76;
  private const int LineSizeInBytes = 57;
  private readonly char[] _charsLine = new char[76];
  private readonly TextWriter _writer;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  private byte[] _leftOverBytes;
  private int _leftOverBytesCount;

  public Base64Encoder(TextWriter writer)
  {
    ValidationUtils.ArgumentNotNull((object) writer, nameof (writer));
    this._writer = writer;
  }

  private void ValidateEncode(byte[] buffer, int index, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (index < 0)
      throw new ArgumentOutOfRangeException(nameof (index));
    if (count < 0)
      throw new ArgumentOutOfRangeException(nameof (count));
    if (count > buffer.Length - index)
      throw new ArgumentOutOfRangeException(nameof (count));
  }

  public void Encode(byte[] buffer, int index, int count)
  {
    this.ValidateEncode(buffer, index, count);
    if (this._leftOverBytesCount > 0)
    {
      if (this.FulfillFromLeftover(buffer, index, ref count))
        return;
      this.WriteChars(this._charsLine, 0, Convert.ToBase64CharArray(this._leftOverBytes, 0, 3, this._charsLine, 0));
    }
    this.StoreLeftOverBytes(buffer, index, ref count);
    int num = index + count;
    int length = 57;
    for (; index < num; index += length)
    {
      if (index + length > num)
        length = num - index;
      this.WriteChars(this._charsLine, 0, Convert.ToBase64CharArray(buffer, index, length, this._charsLine, 0));
    }
  }

  private void StoreLeftOverBytes(byte[] buffer, int index, ref int count)
  {
    int num = count % 3;
    if (num > 0)
    {
      count -= num;
      if (this._leftOverBytes == null)
        this._leftOverBytes = new byte[3];
      for (int index1 = 0; index1 < num; ++index1)
        this._leftOverBytes[index1] = buffer[index + count + index1];
    }
    this._leftOverBytesCount = num;
  }

  private bool FulfillFromLeftover(byte[] buffer, int index, ref int count)
  {
    int leftOverBytesCount = this._leftOverBytesCount;
    while (leftOverBytesCount < 3 && count > 0)
    {
      this._leftOverBytes[leftOverBytesCount++] = buffer[index++];
      --count;
    }
    if (count != 0 || leftOverBytesCount >= 3)
      return false;
    this._leftOverBytesCount = leftOverBytesCount;
    return true;
  }

  public void Flush()
  {
    if (this._leftOverBytesCount <= 0)
      return;
    this.WriteChars(this._charsLine, 0, Convert.ToBase64CharArray(this._leftOverBytes, 0, this._leftOverBytesCount, this._charsLine, 0));
    this._leftOverBytesCount = 0;
  }

  private void WriteChars(char[] chars, int index, int count)
  {
    this._writer.Write(chars, index, count);
  }

  public async Task EncodeAsync(
    byte[] buffer,
    int index,
    int count,
    CancellationToken cancellationToken)
  {
    this.ValidateEncode(buffer, index, count);
    if (this._leftOverBytesCount > 0)
    {
      if (this.FulfillFromLeftover(buffer, index, ref count))
        return;
      await this.WriteCharsAsync(this._charsLine, 0, Convert.ToBase64CharArray(this._leftOverBytes, 0, 3, this._charsLine, 0), cancellationToken).ConfigureAwait(false);
    }
    this.StoreLeftOverBytes(buffer, index, ref count);
    int num4 = index + count;
    int length = 57;
    for (; index < num4; index += length)
    {
      if (index + length > num4)
        length = num4 - index;
      ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter = this.WriteCharsAsync(this._charsLine, 0, Convert.ToBase64CharArray(buffer, index, length, this._charsLine, 0), cancellationToken).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        awaiter.GetResult();
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 1;
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Base64Encoder.\u003CEncodeAsync\u003Ed__13>(ref awaiter, this);
        break;
      }
    }
  }

  private Task WriteCharsAsync(
    char[] chars,
    int index,
    int count,
    CancellationToken cancellationToken)
  {
    return this._writer.WriteAsync(chars, index, count, cancellationToken);
  }

  public Task FlushAsync(CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
      return cancellationToken.FromCanceled();
    if (this._leftOverBytesCount <= 0)
      return AsyncUtils.CompletedTask;
    int base64CharArray = Convert.ToBase64CharArray(this._leftOverBytes, 0, this._leftOverBytesCount, this._charsLine, 0);
    this._leftOverBytesCount = 0;
    return this.WriteCharsAsync(this._charsLine, 0, base64CharArray, cancellationToken);
  }
}
