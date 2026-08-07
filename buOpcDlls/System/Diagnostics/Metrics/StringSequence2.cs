// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.StringSequence2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal struct StringSequence2(string value1, string value2) : 
  IEquatable<StringSequence2>,
  IStringSequence
{
  public string Value1 = value1;
  public string Value2 = value2;

  public bool Equals(StringSequence2 other)
  {
    return this.Value1 == other.Value1 && this.Value2 == other.Value2;
  }

  public override bool Equals(object obj) => obj is StringSequence2 other && this.Equals(other);

  public string this[int i]
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

  public int Length => 2;

  public override int GetHashCode()
  {
    string str1 = this.Value1;
    int hashCode1 = str1 != null ? str1.GetHashCode() : 0;
    string str2 = this.Value2;
    int hashCode2 = str2 != null ? str2.GetHashCode() : 0;
    return hashCode1 ^ hashCode2;
  }
}
