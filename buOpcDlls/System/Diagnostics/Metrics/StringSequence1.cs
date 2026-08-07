// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.StringSequence1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct StringSequence1(string value1) : IEquatable<StringSequence1>, IStringSequence
{
  public string Value1 = value1;

  public override int GetHashCode() => this.Value1.GetHashCode();

  public bool Equals(StringSequence1 other) => this.Value1 == other.Value1;

  public override bool Equals(object obj) => obj is StringSequence1 other && this.Equals(other);

  public string this[int i]
  {
    get
    {
      if (i != 0)
        throw new IndexOutOfRangeException();
      return this.Value1;
    }
    set
    {
      if (i != 0)
        throw new IndexOutOfRangeException();
      this.Value1 = value;
    }
  }

  public int Length => 1;
}
