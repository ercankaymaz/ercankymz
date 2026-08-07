// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ObjectSequence1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct ObjectSequence1(object value1) : IEquatable<ObjectSequence1>, IObjectSequence
{
  public object Value1 = value1;

  public override int GetHashCode()
  {
    object obj = this.Value1;
    return obj == null ? 0 : obj.GetHashCode();
  }

  public bool Equals(ObjectSequence1 other)
  {
    return this.Value1 != null ? this.Value1.Equals(other.Value1) : other.Value1 == null;
  }

  public override bool Equals(object obj) => obj is ObjectSequence1 other && this.Equals(other);

  public object this[int i]
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
}
