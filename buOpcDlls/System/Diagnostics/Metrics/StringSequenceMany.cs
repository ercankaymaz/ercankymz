// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.StringSequenceMany
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct StringSequenceMany(string[] values) : IEquatable<StringSequenceMany>, IStringSequence
{
  private readonly string[] _values = values;

  public Span<string> AsSpan() => this._values.AsSpan<string>();

  public bool Equals(StringSequenceMany other)
  {
    if (this._values.Length != other._values.Length)
      return false;
    for (int index = 0; index < this._values.Length; ++index)
    {
      if (this._values[index] != other._values[index])
        return false;
    }
    return true;
  }

  public override bool Equals(object obj) => obj is StringSequenceMany other && this.Equals(other);

  public string this[int i]
  {
    get => this._values[i];
    set => this._values[i] = value;
  }

  public int Length => this._values.Length;

  public override int GetHashCode()
  {
    int hashCode = 0;
    for (int index = 0; index < this._values.Length; ++index)
      hashCode = hashCode << 3 ^ this._values[index].GetHashCode();
    return hashCode;
  }
}
