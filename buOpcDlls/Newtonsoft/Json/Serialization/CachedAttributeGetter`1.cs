// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.CachedAttributeGetter`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

internal static class CachedAttributeGetter<T> where T : Attribute
{
  [Nullable(new byte[] {1, 1, 2})]
  private static readonly ThreadSafeStore<object, T> TypeAttributeCache = new ThreadSafeStore<object, T>(new Func<object, T>(JsonTypeReflector.GetAttribute<T>));

  [NullableContext(1)]
  [return: Nullable(2)]
  public static T GetAttribute(object type)
  {
    return CachedAttributeGetter<T>.TypeAttributeCache.Get(type);
  }
}
