// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonConverterAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(1)]
[Nullable(0)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Parameter, AllowMultiple = false)]
public sealed class JsonConverterAttribute : Attribute
{
  private readonly Type _converterType;

  public Type ConverterType => this._converterType;

  [field: Nullable(new byte[] {2, 1})]
  [Nullable(new byte[] {2, 1})]
  public object[] ConverterParameters { [return: Nullable(new byte[] {2, 1})] get; }

  public JsonConverterAttribute(Type converterType)
  {
    this._converterType = !(converterType == (Type) null) ? converterType : throw new ArgumentNullException(nameof (converterType));
  }

  public JsonConverterAttribute(Type converterType, params object[] converterParameters)
    : this(converterType)
  {
    this.ConverterParameters = converterParameters;
  }
}
