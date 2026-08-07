// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.StructMultiKey`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
[IsReadOnly]
internal struct StructMultiKey<[Nullable(2)] T1, [Nullable(2)] T2>(T1 v1, T2 v2) : 
  IEquatable<StructMultiKey<T1, T2>>
{
  public readonly T1 Value1 = v1;
  public readonly T2 Value2 = v2;

  public override int GetHashCode()
  {
    T1 obj1 = this.Value1;
    ref T1 local1 = ref obj1;
    int hashCode1 = (object) local1 != null ? local1.GetHashCode() : 0;
    T2 obj2 = this.Value2;
    ref T2 local2 = ref obj2;
    int hashCode2 = (object) local2 != null ? local2.GetHashCode() : 0;
    return hashCode1 ^ hashCode2;
  }

  [NullableContext(2)]
  public override bool Equals(object obj)
  {
    return obj is StructMultiKey<T1, T2> other && this.Equals(other);
  }

  public bool Equals([Nullable(new byte[] {0, 1, 1})] StructMultiKey<T1, T2> other)
  {
    return object.Equals((object) this.Value1, (object) other.Value1) && object.Equals((object) this.Value2, (object) other.Value2);
  }
}
