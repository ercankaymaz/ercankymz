// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivitySpanId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers.Binary;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis.System.Diagnostics.DiagnosticSource3462135;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics;

[IsReadOnly]
[SecuritySafeCritical]
[ComVisible(true)]
public struct ActivitySpanId : IEquatable<ActivitySpanId>
{
  private readonly string _hexString;

  internal ActivitySpanId(string hexString) => this._hexString = hexString;

  public static unsafe ActivitySpanId CreateRandom()
  {
    ulong num;
    ActivityTraceId.SetToRandomBytes(new Span<byte>((void*) &num, 8));
    return new ActivitySpanId(HexConverter.ToString(new ReadOnlySpan<byte>((void*) &num, 8), HexConverter.Casing.Lower));
  }

  public static ActivitySpanId CreateFromBytes(ReadOnlySpan<byte> idData)
  {
    return idData.Length == 8 ? new ActivitySpanId(HexConverter.ToString(idData, HexConverter.Casing.Lower)) : throw new ArgumentOutOfRangeException(nameof (idData));
  }

  public static ActivitySpanId CreateFromUtf8String(ReadOnlySpan<byte> idData)
  {
    return new ActivitySpanId(idData);
  }

  public static ActivitySpanId CreateFromString(ReadOnlySpan<char> idData)
  {
    return idData.Length == 16 /*0x10*/ && ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData) ? new ActivitySpanId(idData.ToString()) : throw new ArgumentOutOfRangeException(nameof (idData));
  }

  [NullableContext(1)]
  public string ToHexString() => this._hexString ?? "0000000000000000";

  [NullableContext(1)]
  public override string ToString() => this.ToHexString();

  public static bool operator ==(ActivitySpanId spanId1, ActivitySpanId spandId2)
  {
    return spanId1._hexString == spandId2._hexString;
  }

  public static bool operator !=(ActivitySpanId spanId1, ActivitySpanId spandId2)
  {
    return spanId1._hexString != spandId2._hexString;
  }

  public bool Equals(ActivitySpanId spanId) => this._hexString == spanId._hexString;

  [NullableContext(2)]
  public override bool Equals([NotNullWhen(true)] object obj)
  {
    return obj is ActivitySpanId activitySpanId && this._hexString == activitySpanId._hexString;
  }

  public override int GetHashCode() => this.ToHexString().GetHashCode();

  private unsafe ActivitySpanId(ReadOnlySpan<byte> idData)
  {
    if (idData.Length != 16 /*0x10*/)
      throw new ArgumentOutOfRangeException(nameof (idData));
    ulong num;
    if (!Utf8Parser.TryParse(idData, out num, out int _, 'x'))
    {
      this._hexString = ActivitySpanId.CreateRandom()._hexString;
    }
    else
    {
      if (BitConverter.IsLittleEndian)
        num = BinaryPrimitives.ReverseEndianness(num);
      this._hexString = HexConverter.ToString(new ReadOnlySpan<byte>((void*) &num, 8), HexConverter.Casing.Lower);
    }
  }

  public void CopyTo(Span<byte> destination)
  {
    ActivityTraceId.SetSpanFromHexChars(this.ToHexString().AsSpan(), destination);
  }
}
