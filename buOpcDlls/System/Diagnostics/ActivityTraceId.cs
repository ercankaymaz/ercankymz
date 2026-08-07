// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityTraceId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers.Binary;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis.System.Diagnostics.DiagnosticSource3462135;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics;

[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
[SecuritySafeCritical]
[ComVisible(true)]
public struct ActivityTraceId : IEquatable<ActivityTraceId>
{
  private readonly string _hexString;

  internal ActivityTraceId(string hexString) => this._hexString = hexString;

  public static ActivityTraceId CreateRandom()
  {
    Span<byte> span = stackalloc byte[16 /*0x10*/];
    ActivityTraceId.SetToRandomBytes(span);
    return ActivityTraceId.CreateFromBytes((ReadOnlySpan<byte>) span);
  }

  public static ActivityTraceId CreateFromBytes(ReadOnlySpan<byte> idData)
  {
    return idData.Length == 16 /*0x10*/ ? new ActivityTraceId(HexConverter.ToString(idData, HexConverter.Casing.Lower)) : throw new ArgumentOutOfRangeException(nameof (idData));
  }

  public static ActivityTraceId CreateFromUtf8String(ReadOnlySpan<byte> idData)
  {
    return new ActivityTraceId(idData);
  }

  public static ActivityTraceId CreateFromString(ReadOnlySpan<char> idData)
  {
    return idData.Length == 32 /*0x20*/ && ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData) ? new ActivityTraceId(idData.ToString()) : throw new ArgumentOutOfRangeException(nameof (idData));
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
  public string ToHexString() => this._hexString ?? "00000000000000000000000000000000";

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
  public override string ToString() => this.ToHexString();

  public static bool operator ==(ActivityTraceId traceId1, ActivityTraceId traceId2)
  {
    return traceId1._hexString == traceId2._hexString;
  }

  public static bool operator !=(ActivityTraceId traceId1, ActivityTraceId traceId2)
  {
    return traceId1._hexString != traceId2._hexString;
  }

  public bool Equals(ActivityTraceId traceId) => this._hexString == traceId._hexString;

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(2)]
  public override bool Equals([NotNullWhen(true)] object obj)
  {
    return obj is ActivityTraceId activityTraceId && this._hexString == activityTraceId._hexString;
  }

  public override int GetHashCode() => this.ToHexString().GetHashCode();

  private ActivityTraceId(ReadOnlySpan<byte> idData)
  {
    if (idData.Length != 32 /*0x20*/)
      throw new ArgumentOutOfRangeException(nameof (idData));
    Span<ulong> span = stackalloc ulong[2];
    int bytesConsumed;
    if (!Utf8Parser.TryParse(idData.Slice(0, 16 /*0x10*/), out span[0], out bytesConsumed, 'x'))
      this._hexString = ActivityTraceId.CreateRandom()._hexString;
    else if (!Utf8Parser.TryParse(idData.Slice(16 /*0x10*/, 16 /*0x10*/), out span[1], out bytesConsumed, 'x'))
    {
      this._hexString = ActivityTraceId.CreateRandom()._hexString;
    }
    else
    {
      if (BitConverter.IsLittleEndian)
      {
        span[0] = BinaryPrimitives.ReverseEndianness(span[0]);
        span[1] = BinaryPrimitives.ReverseEndianness(span[1]);
      }
      this._hexString = HexConverter.ToString((ReadOnlySpan<byte>) MemoryMarshal.AsBytes<ulong>(span), HexConverter.Casing.Lower);
    }
  }

  public void CopyTo(Span<byte> destination)
  {
    ActivityTraceId.SetSpanFromHexChars(this.ToHexString().AsSpan(), destination);
  }

  internal static void SetToRandomBytes(Span<byte> outBytes)
  {
    RandomNumberGenerator current = RandomNumberGenerator.Current;
    Unsafe.WriteUnaligned<long>(ref outBytes[0], current.Next());
    if (outBytes.Length != 16 /*0x10*/)
      return;
    Unsafe.WriteUnaligned<long>(ref outBytes[8], current.Next());
  }

  internal static void SetSpanFromHexChars(ReadOnlySpan<char> charData, Span<byte> outBytes)
  {
    for (int index = 0; index < outBytes.Length; ++index)
      outBytes[index] = ActivityTraceId.HexByteFromChars(charData[index * 2], charData[index * 2 + 1]);
  }

  internal static byte HexByteFromChars(char char1, char char2)
  {
    int num1 = HexConverter.FromLowerChar((int) char1);
    int num2 = HexConverter.FromLowerChar((int) char2);
    if ((num1 | num2) == (int) byte.MaxValue)
      throw new ArgumentOutOfRangeException("idData");
    return (byte) (num1 << 4 | num2);
  }

  internal static bool IsLowerCaseHexAndNotAllZeros(ReadOnlySpan<char> idData)
  {
    bool flag = false;
    for (int index = 0; index < idData.Length; ++index)
    {
      char c = idData[index];
      if (!HexConverter.IsHexLowerChar((int) c))
        return false;
      if (c != '0')
        flag = true;
    }
    return flag;
  }
}
