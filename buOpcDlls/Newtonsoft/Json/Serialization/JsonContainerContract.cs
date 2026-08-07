// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonContainerContract
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(2)]
[Nullable(0)]
public class JsonContainerContract : JsonContract
{
  private JsonContract _itemContract;
  private JsonContract _finalItemContract;

  internal JsonContract ItemContract
  {
    get => this._itemContract;
    set
    {
      this._itemContract = value;
      if (this._itemContract != null)
        this._finalItemContract = this._itemContract.UnderlyingType.IsSealed() ? this._itemContract : (JsonContract) null;
      else
        this._finalItemContract = (JsonContract) null;
    }
  }

  internal JsonContract FinalItemContract => this._finalItemContract;

  public JsonConverter ItemConverter { get; set; }

  public bool? ItemIsReference { get; set; }

  public ReferenceLoopHandling? ItemReferenceLoopHandling { get; set; }

  public TypeNameHandling? ItemTypeNameHandling { get; set; }

  [NullableContext(1)]
  internal JsonContainerContract(Type underlyingType)
    : base(underlyingType)
  {
    JsonContainerAttribute cachedAttribute = JsonTypeReflector.GetCachedAttribute<JsonContainerAttribute>((object) underlyingType);
    if (cachedAttribute == null)
      return;
    if (cachedAttribute.ItemConverterType != (Type) null)
      this.ItemConverter = JsonTypeReflector.CreateJsonConverterInstance(cachedAttribute.ItemConverterType, cachedAttribute.ItemConverterParameters);
    this.ItemIsReference = cachedAttribute._itemIsReference;
    this.ItemReferenceLoopHandling = cachedAttribute._itemReferenceLoopHandling;
    this.ItemTypeNameHandling = cachedAttribute._itemTypeNameHandling;
  }
}
