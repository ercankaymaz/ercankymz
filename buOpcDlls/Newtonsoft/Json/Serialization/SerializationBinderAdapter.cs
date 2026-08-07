// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.SerializationBinderAdapter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Runtime.Serialization;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
internal class SerializationBinderAdapter : ISerializationBinder
{
  public readonly SerializationBinder SerializationBinder;

  public SerializationBinderAdapter(SerializationBinder serializationBinder)
  {
    this.SerializationBinder = serializationBinder;
  }

  public Type BindToType([Nullable(2)] string assemblyName, string typeName)
  {
    return this.SerializationBinder.BindToType(assemblyName, typeName);
  }

  [NullableContext(2)]
  public void BindToName([Nullable(1)] Type serializedType, out string assemblyName, out string typeName)
  {
    this.SerializationBinder.BindToName(serializedType, out assemblyName, out typeName);
  }
}
