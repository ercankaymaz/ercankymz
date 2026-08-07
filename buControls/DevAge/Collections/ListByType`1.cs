// Decompiled with JetBrains decompiler
// Type: DevAge.Collections.ListByType`1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace DevAge.Collections;

public abstract class ListByType<T> : List<T>
{
  public T GetByType(Type searchType)
  {
    T byType;
    for (int index = 0; index < this.Count; ++index)
    {
      if (searchType.IsAssignableFrom(this[index].GetType()))
      {
        byType = this[index];
        goto label_6;
      }
    }
    byType = default (T);
label_6:
    return byType;
  }
}
