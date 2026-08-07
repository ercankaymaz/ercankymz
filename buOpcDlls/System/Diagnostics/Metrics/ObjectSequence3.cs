// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ObjectSequence3
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct ObjectSequence3(object value1, object value2, object value3) : 
  IEquatable<ObjectSequence3>,
  IObjectSequence
{
  public object Value1 = value1;
  public object Value2 = value2;
  public object Value3 = value3;

  public bool Equals(ObjectSequence3 other)
  {
    if ((this.Value1 == null ? (other.Value1 == null ? 1 : 0) : (this.Value1.Equals(other.Value1) ? 1 : 0)) == 0 || (this.Value2 == null ? (other.Value2 == null ? 1 : 0) : (this.Value2.Equals(other.Value2) ? 1 : 0)) == 0)
      return false;
    return this.Value3 != null ? this.Value3.Equals(other.Value3) : other.Value3 == null;
  }

  public override bool Equals(object obj) => obj is ObjectSequence3 other && this.Equals(other);

  public object this[int i]
  {
    get
    {
      if (i == 0)
        return this.Value1;
      if (i == 1)
        return this.Value2;
      if (i != 2)
        throw new IndexOutOfRangeException();
      return this.Value3;
    }
    set
    {
      if (i == 0)
        this.Value1 = value;
      else if (i == 1)
      {
        this.Value2 = value;
      }
      else
      {
        if (i != 2)
          throw new IndexOutOfRangeException();
        this.Value3 = value;
      }
    }
  }

  public override int GetHashCode()
  {
    object obj1 = this.Value1;
    int hashCode1 = obj1 != null ? obj1.GetHashCode() : 0;
    object obj2 = this.Value2;
    int hashCode2 = obj2 != null ? obj2.GetHashCode() : 0;
    int num = hashCode1 ^ hashCode2;
    object obj3 = this.Value3;
    int hashCode3 = obj3 != null ? obj3.GetHashCode() : 0;
    return num ^ hashCode3;
  }
}
