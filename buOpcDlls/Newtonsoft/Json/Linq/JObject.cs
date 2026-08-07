// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
public class JObject : 
  JContainer,
  IDictionary<string, JToken>,
  ICollection<KeyValuePair<string, JToken>>,
  IEnumerable<KeyValuePair<string, JToken>>,
  IEnumerable,
  INotifyPropertyChanged,
  ICustomTypeDescriptor,
  INotifyPropertyChanging
{
  private readonly JPropertyKeyedCollection _properties = new JPropertyKeyedCollection();

  public override Task WriteToAsync(
    JsonWriter writer,
    CancellationToken cancellationToken,
    params JsonConverter[] converters)
  {
    Task task = writer.WriteStartObjectAsync(cancellationToken);
    if (!task.IsCompletedSuccessfully())
      return AwaitProperties(task, 0, writer, cancellationToken, converters);
    for (int index = 0; index < this._properties.Count; ++index)
    {
      Task async = this._properties[index].WriteToAsync(writer, cancellationToken, converters);
      if (!async.IsCompletedSuccessfully())
        return AwaitProperties(async, index + 1, writer, cancellationToken, converters);
    }
    return writer.WriteEndObjectAsync(cancellationToken);

    async Task AwaitProperties(
      Task task,
      int i,
      JsonWriter Writer,
      CancellationToken CancellationToken,
      JsonConverter[] Converters)
    {
      ConfiguredTaskAwaitable configuredTaskAwaitable = task.ConfigureAwait(false);
      await configuredTaskAwaitable;
      for (; i < this._properties.Count; ++i)
      {
        configuredTaskAwaitable = this._properties[i].WriteToAsync(Writer, CancellationToken, Converters).ConfigureAwait(false);
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter = configuredTaskAwaitable.GetAwaiter();
        if (awaiter.IsCompleted)
        {
          awaiter.GetResult();
        }
        else
        {
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JObject.\u003C\u003CWriteToAsync\u003Eg__AwaitProperties\u007C0_0\u003Ed>(ref awaiter, this);
          return;
        }
      }
      configuredTaskAwaitable = Writer.WriteEndObjectAsync(CancellationToken).ConfigureAwait(false);
      await configuredTaskAwaitable;
    }
  }

  public static Task<JObject> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    return JObject.LoadAsync(reader, (JsonLoadSettings) null, cancellationToken);
  }

  public static async Task<JObject> LoadAsync(
    JsonReader reader,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
    ConfiguredTaskAwaitable<bool> configuredTaskAwaitable;
    if (reader.TokenType == JsonToken.None)
    {
      configuredTaskAwaitable = reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader.");
    }
    configuredTaskAwaitable = reader.MoveToContentAsync(cancellationToken).ConfigureAwait(false);
    int num = await configuredTaskAwaitable ? 1 : 0;
    if (reader.TokenType != JsonToken.StartObject)
      throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader. Current JsonReader item is not an object: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    JObject o = new JObject();
    o.SetLineInfo(reader as IJsonLineInfo, settings);
    await o.ReadTokenFromAsync(reader, settings, cancellationToken).ConfigureAwait(false);
    JObject jobject = o;
    o = (JObject) null;
    return jobject;
  }

  protected override IList<JToken> ChildrenTokens => (IList<JToken>) this._properties;

  [field: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public event PropertyChangedEventHandler PropertyChanged;

  [field: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public event PropertyChangingEventHandler PropertyChanging;

  public JObject()
  {
  }

  public JObject(JObject other)
    : base((JContainer) other, (JsonCloneSettings) null)
  {
  }

  internal JObject(JObject other, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
    : base((JContainer) other, settings)
  {
  }

  public JObject(params object[] content)
    : this((object) content)
  {
  }

  public JObject(object content) => this.Add(content);

  internal override bool DeepEquals(JToken node)
  {
    return node is JObject jobject && this._properties.Compare(jobject._properties);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override int IndexOfItem(JToken item)
  {
    return item == null ? -1 : this._properties.IndexOfReference(item);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override bool InsertItem(
    int index,
    JToken item,
    bool skipParentCheck,
    bool copyAnnotations)
  {
    return (item == null || item.Type != JTokenType.Comment) && base.InsertItem(index, item, skipParentCheck, copyAnnotations);
  }

  internal override void ValidateToken(JToken o, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JToken existing)
  {
    ValidationUtils.ArgumentNotNull((object) o, nameof (o));
    JProperty jproperty1 = o.Type == JTokenType.Property ? (JProperty) o : throw new ArgumentException("Can not add {0} to {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) o.GetType(), (object) this.GetType()));
    if (existing != null)
    {
      JProperty jproperty2 = (JProperty) existing;
      if (jproperty1.Name == jproperty2.Name)
        return;
    }
    if (this._properties.TryGetValue(jproperty1.Name, out existing))
      throw new ArgumentException("Can not add property {0} to {1}. Property with the same name already exists on object.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jproperty1.Name, (object) this.GetType()));
  }

  internal override void MergeItem(object content, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonMergeSettings settings)
  {
    if (!(content is JObject jobject))
      return;
    foreach (KeyValuePair<string, JToken> keyValuePair in jobject)
    {
      JProperty jproperty = this.Property(keyValuePair.Key, settings != null ? settings.PropertyNameComparison : StringComparison.Ordinal);
      if (jproperty == null)
        this.Add(keyValuePair.Key, keyValuePair.Value);
      else if (keyValuePair.Value != null)
      {
        if (jproperty.Value is JContainer jcontainer && jcontainer.Type == keyValuePair.Value.Type)
          jcontainer.Merge((object) keyValuePair.Value, settings);
        else if (!JObject.IsNull(keyValuePair.Value) || settings != null && settings.MergeNullValueHandling == MergeNullValueHandling.Merge)
          jproperty.Value = keyValuePair.Value;
      }
    }
  }

  private static bool IsNull(JToken token)
  {
    return token.Type == JTokenType.Null || token is JValue jvalue && jvalue.Value == null;
  }

  internal void InternalPropertyChanged(JProperty childProperty)
  {
    this.OnPropertyChanged(childProperty.Name);
    if (this._listChanged != null)
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, this.IndexOfItem((JToken) childProperty)));
    if (this._collectionChanged == null)
      return;
    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, (IList) childProperty, (IList) childProperty, this.IndexOfItem((JToken) childProperty)));
  }

  internal void InternalPropertyChanging(JProperty childProperty)
  {
    this.OnPropertyChanging(childProperty.Name);
  }

  internal override JToken CloneToken([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
  {
    return (JToken) new JObject(this, settings);
  }

  public override JTokenType Type => JTokenType.Object;

  public IEnumerable<JProperty> Properties() => this._properties.Cast<JProperty>();

  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public JProperty Property(string name) => this.Property(name, StringComparison.Ordinal);

  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public JProperty Property(string name, StringComparison comparison)
  {
    if (name == null)
      return (JProperty) null;
    JToken jtoken;
    if (this._properties.TryGetValue(name, out jtoken))
      return (JProperty) jtoken;
    if (comparison != StringComparison.Ordinal)
    {
      for (int index = 0; index < this._properties.Count; ++index)
      {
        JProperty property = (JProperty) this._properties[index];
        if (string.Equals(property.Name, name, comparison))
          return property;
      }
    }
    return (JProperty) null;
  }

  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {0, 1})]
  public JEnumerable<JToken> PropertyValues()
  {
    return new JEnumerable<JToken>(this.Properties().Select<JProperty, JToken>((Func<JProperty, JToken>) ([System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(0)] (p) => p.Value)));
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public override JToken this[object key]
  {
    [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] get
    {
      ValidationUtils.ArgumentNotNull(key, nameof (key));
      return key is string propertyName ? this[propertyName] : throw new ArgumentException("Accessed JObject values with invalid key value: {0}. Object property name expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(key)));
    }
    [param: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] set
    {
      ValidationUtils.ArgumentNotNull(key, nameof (key));
      if (!(key is string propertyName))
        throw new ArgumentException("Set JObject values with invalid key value: {0}. Object property name expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(key)));
      this[propertyName] = value;
    }
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public JToken this[string propertyName]
  {
    [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] get
    {
      ValidationUtils.ArgumentNotNull((object) propertyName, nameof (propertyName));
      return this.Property(propertyName, StringComparison.Ordinal)?.Value;
    }
    [param: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] set
    {
      JProperty jproperty = this.Property(propertyName, StringComparison.Ordinal);
      if (jproperty != null)
      {
        jproperty.Value = value;
      }
      else
      {
        this.OnPropertyChanging(propertyName);
        this.Add(propertyName, value);
        this.OnPropertyChanged(propertyName);
      }
    }
  }

  public static JObject Load(JsonReader reader) => JObject.Load(reader, (JsonLoadSettings) null);

  public static JObject Load(JsonReader reader, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
    if (reader.TokenType == JsonToken.None && !reader.Read())
      throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader.");
    reader.MoveToContent();
    if (reader.TokenType != JsonToken.StartObject)
      throw JsonReaderException.Create(reader, "Error reading JObject from JsonReader. Current JsonReader item is not an object: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    JObject jobject = new JObject();
    jobject.SetLineInfo(reader as IJsonLineInfo, settings);
    jobject.ReadTokenFrom(reader, settings);
    return jobject;
  }

  public static JObject Parse(string json) => JObject.Parse(json, (JsonLoadSettings) null);

  public static JObject Parse(string json, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    using (JsonReader reader = (JsonReader) new JsonTextReader((TextReader) new StringReader(json)))
    {
      JObject jobject = JObject.Load(reader, settings);
      do
        ;
      while (reader.Read());
      return jobject;
    }
  }

  public static JObject FromObject(object o)
  {
    return JObject.FromObject(o, JsonSerializer.CreateDefault());
  }

  public static JObject FromObject(object o, JsonSerializer jsonSerializer)
  {
    JToken jtoken = JToken.FromObjectInternal(o, jsonSerializer);
    return jtoken.Type == JTokenType.Object ? (JObject) jtoken : throw new ArgumentException("Object serialized to {0}. JObject instance expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jtoken.Type));
  }

  public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
  {
    writer.WriteStartObject();
    for (int index = 0; index < this._properties.Count; ++index)
      this._properties[index].WriteTo(writer, converters);
    writer.WriteEndObject();
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public JToken GetValue(string propertyName)
  {
    return this.GetValue(propertyName, StringComparison.Ordinal);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public JToken GetValue(string propertyName, StringComparison comparison)
  {
    if (propertyName == null)
      return (JToken) null;
    return this.Property(propertyName, comparison)?.Value;
  }

  public bool TryGetValue(string propertyName, StringComparison comparison, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2), NotNullWhen(true)] out JToken value)
  {
    value = this.GetValue(propertyName, comparison);
    return value != null;
  }

  public void Add(string propertyName, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JToken value)
  {
    this.Add((object) new JProperty(propertyName, (object) value));
  }

  public bool ContainsKey(string propertyName)
  {
    ValidationUtils.ArgumentNotNull((object) propertyName, nameof (propertyName));
    return this._properties.Contains(propertyName);
  }

  ICollection<string> IDictionary<string, JToken>.Keys => this._properties.Keys;

  public bool Remove(string propertyName)
  {
    JProperty jproperty = this.Property(propertyName, StringComparison.Ordinal);
    if (jproperty == null)
      return false;
    jproperty.Remove();
    return true;
  }

  public bool TryGetValue(string propertyName, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2), NotNullWhen(true)] out JToken value)
  {
    JProperty jproperty = this.Property(propertyName, StringComparison.Ordinal);
    if (jproperty == null)
    {
      value = (JToken) null;
      return false;
    }
    value = jproperty.Value;
    return true;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {1, 2})]
  ICollection<JToken> IDictionary<string, JToken>.Values
  {
    [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {1, 2})] get
    {
      throw new NotImplementedException();
    }
  }

  void ICollection<KeyValuePair<string, JToken>>.Add([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, JToken> item)
  {
    this.Add((object) new JProperty(item.Key, (object) item.Value));
  }

  void ICollection<KeyValuePair<string, JToken>>.Clear() => this.RemoveAll();

  bool ICollection<KeyValuePair<string, JToken>>.Contains([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, JToken> item)
  {
    JProperty jproperty = this.Property(item.Key, StringComparison.Ordinal);
    return jproperty != null && jproperty.Value == item.Value;
  }

  void ICollection<KeyValuePair<string, JToken>>.CopyTo(
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {1, 0, 1, 2})] KeyValuePair<string, JToken>[] array,
    int arrayIndex)
  {
    if (array == null)
      throw new ArgumentNullException(nameof (array));
    if (arrayIndex < 0)
      throw new ArgumentOutOfRangeException(nameof (arrayIndex), "arrayIndex is less than 0.");
    if (arrayIndex >= array.Length && arrayIndex != 0)
      throw new ArgumentException("arrayIndex is equal to or greater than the length of array.");
    if (this.Count > array.Length - arrayIndex)
      throw new ArgumentException("The number of elements in the source JObject is greater than the available space from arrayIndex to the end of the destination array.");
    int num = 0;
    foreach (JProperty property in (Collection<JToken>) this._properties)
    {
      array[arrayIndex + num] = new KeyValuePair<string, JToken>(property.Name, property.Value);
      ++num;
    }
  }

  bool ICollection<KeyValuePair<string, JToken>>.IsReadOnly => false;

  bool ICollection<KeyValuePair<string, JToken>>.Remove([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, JToken> item)
  {
    if (!((ICollection<KeyValuePair<string, JToken>>) this).Contains(item))
      return false;
    this.Remove(item.Key);
    return true;
  }

  internal override int GetDeepHashCode() => this.ContentsHashCode();

  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator()
  {
    foreach (JProperty property in (Collection<JToken>) this._properties)
      yield return new KeyValuePair<string, JToken>(property.Name, property.Value);
  }

  protected virtual void OnPropertyChanged(string propertyName)
  {
    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
    if (propertyChanged == null)
      return;
    propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }

  protected virtual void OnPropertyChanging(string propertyName)
  {
    PropertyChangingEventHandler propertyChanging = this.PropertyChanging;
    if (propertyChanging == null)
      return;
    propertyChanging((object) this, new PropertyChangingEventArgs(propertyName));
  }

  PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
  {
    return ((ICustomTypeDescriptor) this).GetProperties((Attribute[]) null);
  }

  PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {2, 1})] Attribute[] attributes)
  {
    PropertyDescriptor[] properties = new PropertyDescriptor[this.Count];
    int index = 0;
    foreach (KeyValuePair<string, JToken> keyValuePair in this)
    {
      properties[index] = (PropertyDescriptor) new JPropertyDescriptor(keyValuePair.Key);
      ++index;
    }
    return new PropertyDescriptorCollection(properties);
  }

  AttributeCollection ICustomTypeDescriptor.GetAttributes() => AttributeCollection.Empty;

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  string ICustomTypeDescriptor.GetClassName() => (string) null;

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  string ICustomTypeDescriptor.GetComponentName() => (string) null;

  TypeConverter ICustomTypeDescriptor.GetConverter() => new TypeConverter();

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() => (EventDescriptor) null;

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() => (PropertyDescriptor) null;

  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  object ICustomTypeDescriptor.GetEditor(System.Type editorBaseType) => (object) null;

  EventDescriptorCollection ICustomTypeDescriptor.GetEvents([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {2, 1})] Attribute[] attributes)
  {
    return EventDescriptorCollection.Empty;
  }

  EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => EventDescriptorCollection.Empty;

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
  {
    return pd is JPropertyDescriptor ? (object) this : (object) null;
  }

  protected override DynamicMetaObject GetMetaObject(Expression parameter)
  {
    return (DynamicMetaObject) new DynamicProxyMetaObject<JObject>(parameter, this, (DynamicProxy<JObject>) new JObject.JObjectDynamicProxy());
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {0, 1})]
  private class JObjectDynamicProxy : DynamicProxy<JObject>
  {
    public override bool TryGetMember(JObject instance, GetMemberBinder binder, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] out object result)
    {
      result = (object) instance[binder.Name];
      return true;
    }

    public override bool TrySetMember(JObject instance, SetMemberBinder binder, object value)
    {
      if (!(value is JToken jtoken))
        jtoken = (JToken) new JValue(value);
      instance[binder.Name] = jtoken;
      return true;
    }

    public override IEnumerable<string> GetDynamicMemberNames(JObject instance)
    {
      return instance.Properties().Select<JProperty, string>((Func<JProperty, string>) ([System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(0)] (p) => p.Name));
    }
  }
}
