// Decompiled with JetBrains decompiler
// Type: Opaline2Cs.Wrappable
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using System;

#nullable disable
namespace Opaline2Cs;

public abstract class Wrappable
{
  public IntPtr __Ptr;

  public static T Create<T>(IntPtr ptr, T t) where T : Wrappable
  {
    T obj;
    if (ptr != IntPtr.Zero)
    {
      t.__Ptr = ptr;
      obj = t;
    }
    else
      obj = default (T);
    return obj;
  }

  public override bool Equals(object Obj) => this.__Ptr == ((Wrappable) Obj).__Ptr;

  public static bool operator ==(Wrappable obj1, Wrappable obj2) => obj1.Equals((object) obj2);

  public static bool operator !=(Wrappable obj1, Wrappable obj2) => !obj1.Equals((object) obj2);

  public override int GetHashCode() => this.__Ptr.GetHashCode();
}
