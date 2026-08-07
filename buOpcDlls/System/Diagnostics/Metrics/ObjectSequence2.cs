// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ObjectSequence2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct ObjectSequence2(object value1, object value2) : 
  IEquatable<ObjectSequence2>,
  IObjectSequence
{
  public object Value1 = value1;
  public object Value2 = value2;

  public bool Equals(ObjectSequence2 other)
  {
    if ((this.Value1 == null ? (other.Value1 == null ? 1 : 0) : (this.Value1.Equals(other.Value1) ? 1 : 0)) == 0)
      return false;
    return this.Value2 != null ? this.Value2.Equals(other.Value2) : other.Value2 == null;
  }

  public override bool Equals(object obj) => obj is ObjectSequence2 other && this.Equals(other);

  public object this[int i]
  {
    get
    {
      if (i == 0)
        return this.Value1;
      if (i != 1)
        throw new IndexOutOfRangeException();
      return this.Value2;
    }
    set
    {
      if (i == 0)
      {
        this.Value1 = value;
      }
      else
      {
        if (i != 1)
          throw new IndexOutOfRangeException();
        this.Value2 = value;
      }
    }
  }

  public override int GetHashCode()
  {
    object obj1 = this.Value1;
    int hashCode1 = obj1 != null ? obj1.GetHashCode() : 0;
    object obj2 = this.Value2;
    int hashCode2 = obj2 != null ? obj2.GetHashCode() : 0;
    return hashCode1 ^ hashCode2;
  }
}
