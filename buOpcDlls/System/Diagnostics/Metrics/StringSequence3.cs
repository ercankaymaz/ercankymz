// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.StringSequence3
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct StringSequence3(string value1, string value2, string value3) : 
  IEquatable<StringSequence3>,
  IStringSequence
{
  public string Value1 = value1;
  public string Value2 = value2;
  public string Value3 = value3;

  public bool Equals(StringSequence3 other)
  {
    return this.Value1 == other.Value1 && this.Value2 == other.Value2 && this.Value3 == other.Value3;
  }

  public override bool Equals(object obj) => obj is StringSequence3 other && this.Equals(other);

  public string this[int i]
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

  public int Length => 3;

  public override int GetHashCode()
  {
    string str1 = this.Value1;
    int hashCode1 = str1 != null ? str1.GetHashCode() : 0;
    string str2 = this.Value2;
    int hashCode2 = str2 != null ? str2.GetHashCode() : 0;
    int num = hashCode1 ^ hashCode2;
    string str3 = this.Value3;
    int hashCode3 = str3 != null ? str3.GetHashCode() : 0;
    return num ^ hashCode3;
  }
}
