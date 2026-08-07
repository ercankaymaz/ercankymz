// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class CamelCasePropertyNamesContractResolver : DefaultContractResolver
{
  private static readonly object TypeContractCacheLock = new object();
  private static readonly DefaultJsonNameTable NameTable = new DefaultJsonNameTable();
  [Nullable(new byte[] {2, 0, 1, 1, 1})]
  private static Dictionary<StructMultiKey<Type, Type>, JsonContract> _contractCache;

  public CamelCasePropertyNamesContractResolver()
  {
    CamelCaseNamingStrategy caseNamingStrategy = new CamelCaseNamingStrategy();
    caseNamingStrategy.ProcessDictionaryKeys = true;
    caseNamingStrategy.OverrideSpecifiedNames = true;
    this.NamingStrategy = (NamingStrategy) caseNamingStrategy;
  }

  public override JsonContract ResolveContract(Type type)
  {
    StructMultiKey<Type, Type> key = !(type == (Type) null) ? new StructMultiKey<Type, Type>(this.GetType(), type) : throw new ArgumentNullException(nameof (type));
    Dictionary<StructMultiKey<Type, Type>, JsonContract> contractCache1 = CamelCasePropertyNamesContractResolver._contractCache;
    JsonContract contract;
    if (contractCache1 == null || !contractCache1.TryGetValue(key, out contract))
    {
      contract = this.CreateContract(type);
      lock (CamelCasePropertyNamesContractResolver.TypeContractCacheLock)
      {
        Dictionary<StructMultiKey<Type, Type>, JsonContract> contractCache2 = CamelCasePropertyNamesContractResolver._contractCache;
        Dictionary<StructMultiKey<Type, Type>, JsonContract> dictionary = contractCache2 != null ? new Dictionary<StructMultiKey<Type, Type>, JsonContract>((IDictionary<StructMultiKey<Type, Type>, JsonContract>) contractCache2) : new Dictionary<StructMultiKey<Type, Type>, JsonContract>();
        dictionary[key] = contract;
        CamelCasePropertyNamesContractResolver._contractCache = dictionary;
      }
    }
    return contract;
  }

  internal override DefaultJsonNameTable GetNameTable()
  {
    return CamelCasePropertyNamesContractResolver.NameTable;
  }
}
