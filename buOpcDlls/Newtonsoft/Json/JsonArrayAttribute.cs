// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonArrayAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
public sealed class JsonArrayAttribute : JsonContainerAttribute
{
  private bool _allowNullItems;

  public bool AllowNullItems
  {
    get => this._allowNullItems;
    set => this._allowNullItems = value;
  }

  public JsonArrayAttribute()
  {
  }

  public JsonArrayAttribute(bool allowNullItems) => this._allowNullItems = allowNullItems;

  [NullableContext(1)]
  public JsonArrayAttribute(string id)
    : base(id)
  {
  }
}
