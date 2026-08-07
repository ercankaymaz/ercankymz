// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonPropertyCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(new byte[] {0, 1, 1})]
public class JsonPropertyCollection : KeyedCollection<string, JsonProperty>
{
  private readonly Type _type;
  private readonly List<JsonProperty> _list;

  public JsonPropertyCollection(Type type)
    : base((IEqualityComparer<string>) StringComparer.Ordinal)
  {
    ValidationUtils.ArgumentNotNull((object) type, nameof (type));
    this._type = type;
    this._list = (List<JsonProperty>) this.Items;
  }

  protected override string GetKeyForItem(JsonProperty item) => item.PropertyName;

  public void AddProperty(JsonProperty property)
  {
    if (this.Contains(property.PropertyName))
    {
      if (property.Ignored)
        return;
      JsonProperty jsonProperty = this[property.PropertyName];
      bool flag = true;
      if (jsonProperty.Ignored)
      {
        this.Remove(jsonProperty);
        flag = false;
      }
      else if (property.DeclaringType != (Type) null && jsonProperty.DeclaringType != (Type) null)
      {
        if (property.DeclaringType.IsSubclassOf(jsonProperty.DeclaringType) || jsonProperty.DeclaringType.IsInterface() && property.DeclaringType.ImplementInterface(jsonProperty.DeclaringType))
        {
          this.Remove(jsonProperty);
          flag = false;
        }
        if (jsonProperty.DeclaringType.IsSubclassOf(property.DeclaringType) || property.DeclaringType.IsInterface() && jsonProperty.DeclaringType.ImplementInterface(property.DeclaringType) || this._type.ImplementInterface(jsonProperty.DeclaringType) && this._type.ImplementInterface(property.DeclaringType))
          return;
      }
      if (flag)
        throw new JsonSerializationException("A member with the name '{0}' already exists on '{1}'. Use the JsonPropertyAttribute to specify another name.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) property.PropertyName, (object) this._type));
    }
    this.Add(property);
  }

  [return: Nullable(2)]
  public JsonProperty GetClosestMatchProperty(string propertyName)
  {
    return this.GetProperty(propertyName, StringComparison.Ordinal) ?? this.GetProperty(propertyName, StringComparison.OrdinalIgnoreCase);
  }

  private bool TryGetProperty(string key, [Nullable(2), NotNullWhen(true)] out JsonProperty item)
  {
    if (this.Dictionary != null)
      return this.Dictionary.TryGetValue(key, out item);
    item = (JsonProperty) null;
    return false;
  }

  [return: Nullable(2)]
  public JsonProperty GetProperty(string propertyName, StringComparison comparisonType)
  {
    if (comparisonType == StringComparison.Ordinal)
    {
      JsonProperty jsonProperty;
      return this.TryGetProperty(propertyName, out jsonProperty) ? jsonProperty : (JsonProperty) null;
    }
    for (int index = 0; index < this._list.Count; ++index)
    {
      JsonProperty property = this._list[index];
      if (string.Equals(propertyName, property.PropertyName, comparisonType))
        return property;
    }
    return (JsonProperty) null;
  }
}
