// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionClientExtensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class SessionClientExtensions
{
  internal static IEnumerable<C> Batch<T, C>(this C collection, uint batchSize) where C : List<T>, new()
  {
    if ((long) ((C) collection).Count >= (long) batchSize && batchSize != 0U)
    {
      C c1 = new C();
      c1.Capacity = (int) batchSize;
      C c2 = c1;
      foreach (T obj in (List<T>) collection)
      {
        c2.Add(obj);
        if ((long) c2.Count == (long) batchSize)
        {
          yield return c2;
          C c3 = new C();
          c3.Capacity = (int) batchSize;
          c2 = c3;
        }
      }
      if (c2.Count > 0)
        yield return c2;
    }
    else
      yield return collection;
  }
}
