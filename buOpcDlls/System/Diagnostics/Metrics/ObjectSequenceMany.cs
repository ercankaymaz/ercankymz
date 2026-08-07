// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ObjectSequenceMany
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct ObjectSequenceMany(object[] values) : IEquatable<ObjectSequenceMany>, IObjectSequence
{
  private readonly object[] _values = values;

  public bool Equals(ObjectSequenceMany other)
  {
    if (this._values.Length != other._values.Length)
      return false;
    for (int index = 0; index < this._values.Length; ++index)
    {
      object obj1 = this._values[index];
      object obj2 = other._values[index];
      if (obj1 == null)
      {
        if (obj2 != null)
          return false;
      }
      else if (!obj1.Equals(obj2))
        return false;
    }
    return true;
  }

  public override bool Equals(object obj) => obj is ObjectSequenceMany other && this.Equals(other);

  public object this[int i]
  {
    get => this._values[i];
    set => this._values[i] = value;
  }

  public override int GetHashCode()
  {
    int hashCode = 0;
    for (int index = 0; index < this._values.Length; ++index)
    {
      hashCode <<= 3;
      object obj = this._values[index];
      if (obj != null)
        hashCode ^= obj.GetHashCode();
    }
    return hashCode;
  }
}
