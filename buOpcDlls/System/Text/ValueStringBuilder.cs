// Decompiled with JetBrains decompiler
// Type: System.Text.ValueStringBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Text;

internal ref struct ValueStringBuilder
{
  private char[] _arrayToReturnToPool;
  private Span<char> _chars;
  private int _pos;

  public ValueStringBuilder(Span<char> initialBuffer)
  {
    this._arrayToReturnToPool = (char[]) null;
    this._chars = initialBuffer;
    this._pos = 0;
  }

  public ValueStringBuilder(int initialCapacity)
  {
    this._arrayToReturnToPool = ArrayPool<char>.Shared.Rent(initialCapacity);
    this._chars = (Span<char>) this._arrayToReturnToPool;
    this._pos = 0;
  }

  public int Length
  {
    get => this._pos;
    set => this._pos = value;
  }

  public int Capacity => this._chars.Length;

  public void EnsureCapacity(int capacity)
  {
    if ((uint) capacity <= (uint) this._chars.Length)
      return;
    this.Grow(capacity - this._pos);
  }

  public ref char GetPinnableReference() => ref MemoryMarshal.GetReference<char>(this._chars);

  public ref char GetPinnableReference(bool terminate)
  {
    if (terminate)
    {
      this.EnsureCapacity(this.Length + 1);
      this._chars[this.Length] = char.MinValue;
    }
    return ref MemoryMarshal.GetReference<char>(this._chars);
  }

  public ref char this[int index] => ref this._chars[index];

  [System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions.NullableContext(1)]
  public override string ToString()
  {
    string str = this._chars.Slice(0, this._pos).ToString();
    this.Dispose();
    return str;
  }

  public Span<char> RawChars => this._chars;

  public ReadOnlySpan<char> AsSpan(bool terminate)
  {
    if (terminate)
    {
      this.EnsureCapacity(this.Length + 1);
      this._chars[this.Length] = char.MinValue;
    }
    return (ReadOnlySpan<char>) this._chars.Slice(0, this._pos);
  }

  public ReadOnlySpan<char> AsSpan() => (ReadOnlySpan<char>) this._chars.Slice(0, this._pos);

  public ReadOnlySpan<char> AsSpan(int start)
  {
    return (ReadOnlySpan<char>) this._chars.Slice(start, this._pos - start);
  }

  public ReadOnlySpan<char> AsSpan(int start, int length)
  {
    return (ReadOnlySpan<char>) this._chars.Slice(start, length);
  }

  public bool TryCopyTo(Span<char> destination, out int charsWritten)
  {
    if (this._chars.Slice(0, this._pos).TryCopyTo(destination))
    {
      charsWritten = this._pos;
      this.Dispose();
      return true;
    }
    charsWritten = 0;
    this.Dispose();
    return false;
  }

  public void Insert(int index, char value, int count)
  {
    if (this._pos > this._chars.Length - count)
      this.Grow(count);
    int length = this._pos - index;
    this._chars.Slice(index, length).CopyTo(this._chars.Slice(index + count));
    this._chars.Slice(index, count).Fill(value);
    this._pos += count;
  }

  [System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions.NullableContext(2)]
  public void Insert(int index, string s)
  {
    if (s == null)
      return;
    int length1 = s.Length;
    if (this._pos > this._chars.Length - length1)
      this.Grow(length1);
    int length2 = this._pos - index;
    this._chars.Slice(index, length2).CopyTo(this._chars.Slice(index + length1));
    s.AsSpan().CopyTo(this._chars.Slice(index));
    this._pos += length1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Append(char c)
  {
    int pos = this._pos;
    if ((uint) pos < (uint) this._chars.Length)
    {
      this._chars[pos] = c;
      this._pos = pos + 1;
    }
    else
      this.GrowAndAppend(c);
  }

  [System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions.NullableContext(2)]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Append(string s)
  {
    if (s == null)
      return;
    int pos = this._pos;
    if (s.Length == 1 && (uint) pos < (uint) this._chars.Length)
    {
      this._chars[pos] = s[0];
      this._pos = pos + 1;
    }
    else
      this.AppendSlow(s);
  }

  private void AppendSlow(string s)
  {
    int pos = this._pos;
    if (pos > this._chars.Length - s.Length)
      this.Grow(s.Length);
    s.AsSpan().CopyTo(this._chars.Slice(pos));
    this._pos += s.Length;
  }

  public void Append(char c, int count)
  {
    if (this._pos > this._chars.Length - count)
      this.Grow(count);
    Span<char> span = this._chars.Slice(this._pos, count);
    for (int index = 0; index < span.Length; ++index)
      span[index] = c;
    this._pos += count;
  }

  public unsafe void Append(char* value, int length)
  {
    if (this._pos > this._chars.Length - length)
      this.Grow(length);
    Span<char> span = this._chars.Slice(this._pos, length);
    for (int index = 0; index < span.Length; ++index)
      span[index] = *value++;
    this._pos += length;
  }

  public void Append(ReadOnlySpan<char> value)
  {
    if (this._pos > this._chars.Length - value.Length)
      this.Grow(value.Length);
    value.CopyTo(this._chars.Slice(this._pos));
    this._pos += value.Length;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Span<char> AppendSpan(int length)
  {
    int pos = this._pos;
    if (pos > this._chars.Length - length)
      this.Grow(length);
    this._pos = pos + length;
    return this._chars.Slice(pos, length);
  }

  private void GrowAndAppend(char c)
  {
    this.Grow(1);
    this.Append(c);
  }

  private void Grow(int additionalCapacityBeyondPos)
  {
    char[] destination = ArrayPool<char>.Shared.Rent((int) Math.Max((uint) (this._pos + additionalCapacityBeyondPos), (uint) (this._chars.Length * 2)));
    this._chars.Slice(0, this._pos).CopyTo((Span<char>) destination);
    char[] arrayToReturnToPool = this._arrayToReturnToPool;
    this._chars = (Span<char>) (this._arrayToReturnToPool = destination);
    if (arrayToReturnToPool == null)
      return;
    ArrayPool<char>.Shared.Return(arrayToReturnToPool);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public unsafe void Dispose()
  {
    char[] arrayToReturnToPool = this._arrayToReturnToPool;
    *(ValueStringBuilder*) ref this = new ValueStringBuilder();
    if (arrayToReturnToPool == null)
      return;
    ArrayPool<char>.Shared.Return(arrayToReturnToPool);
  }
}
