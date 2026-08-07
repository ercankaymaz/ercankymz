// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonObjectAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false)]
public sealed class JsonObjectAttribute : JsonContainerAttribute
{
  private MemberSerialization _memberSerialization;
  internal MissingMemberHandling? _missingMemberHandling;
  internal Required? _itemRequired;
  internal NullValueHandling? _itemNullValueHandling;

  public MemberSerialization MemberSerialization
  {
    get => this._memberSerialization;
    set => this._memberSerialization = value;
  }

  public MissingMemberHandling MissingMemberHandling
  {
    get => this._missingMemberHandling.GetValueOrDefault();
    set => this._missingMemberHandling = new MissingMemberHandling?(value);
  }

  public NullValueHandling ItemNullValueHandling
  {
    get => this._itemNullValueHandling.GetValueOrDefault();
    set => this._itemNullValueHandling = new NullValueHandling?(value);
  }

  public Required ItemRequired
  {
    get => this._itemRequired.GetValueOrDefault();
    set => this._itemRequired = new Required?(value);
  }

  public JsonObjectAttribute()
  {
  }

  public JsonObjectAttribute(MemberSerialization memberSerialization)
  {
    this.MemberSerialization = memberSerialization;
  }

  [NullableContext(1)]
  public JsonObjectAttribute(string id)
    : base(id)
  {
  }
}
