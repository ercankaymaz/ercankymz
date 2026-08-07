// Decompiled with JetBrains decompiler
// Type: System.SequencePosition
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.ComponentModel;
using System.Numerics.Hashing;
using System.Runtime.CompilerServices.System.Memory;
using System.Runtime.InteropServices;

#nullable disable
namespace System;

[IsReadOnly]
[ComVisible(true)]
public struct SequencePosition(object @object, int integer) : IEquatable<SequencePosition>
{
  private readonly object _object = @object;
  private readonly int _integer = integer;

  [EditorBrowsable(EditorBrowsableState.Never)]
  public object GetObject() => this._object;

  [EditorBrowsable(EditorBrowsableState.Never)]
  public int GetInteger() => this._integer;

  public bool Equals(SequencePosition other)
  {
    return this._integer == other._integer && object.Equals(this._object, other._object);
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  public override bool Equals(object obj) => obj is SequencePosition other && this.Equals(other);

  [EditorBrowsable(EditorBrowsableState.Never)]
  public override int GetHashCode()
  {
    object obj = this._object;
    return HashHelpers.Combine(obj != null ? obj.GetHashCode() : 0, this._integer);
  }
}
