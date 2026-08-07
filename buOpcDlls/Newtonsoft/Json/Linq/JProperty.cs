// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JProperty
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
public class JProperty : JContainer
{
  private readonly JProperty.JPropertyList _content = new JProperty.JPropertyList();
  private readonly string _name;

  public override Task WriteToAsync(
    JsonWriter writer,
    CancellationToken cancellationToken,
    params JsonConverter[] converters)
  {
    Task task = writer.WritePropertyNameAsync(this._name, cancellationToken);
    return task.IsCompletedSuccessfully() ? this.WriteValueAsync(writer, cancellationToken, converters) : this.WriteToAsync(task, writer, cancellationToken, converters);
  }

  private async Task WriteToAsync(
    Task task,
    JsonWriter writer,
    CancellationToken cancellationToken,
    params JsonConverter[] converters)
  {
    ConfiguredTaskAwaitable configuredTaskAwaitable = task.ConfigureAwait(false);
    await configuredTaskAwaitable;
    configuredTaskAwaitable = this.WriteValueAsync(writer, cancellationToken, converters).ConfigureAwait(false);
    await configuredTaskAwaitable;
  }

  private Task WriteValueAsync(
    JsonWriter writer,
    CancellationToken cancellationToken,
    JsonConverter[] converters)
  {
    JToken jtoken = this.Value;
    return jtoken == null ? writer.WriteNullAsync(cancellationToken) : jtoken.WriteToAsync(writer, cancellationToken, converters);
  }

  public static Task<JProperty> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    return JProperty.LoadAsync(reader, (JsonLoadSettings) null, cancellationToken);
  }

  public static async Task<JProperty> LoadAsync(
    JsonReader reader,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    ConfiguredTaskAwaitable<bool> configuredTaskAwaitable;
    if (reader.TokenType == JsonToken.None)
    {
      configuredTaskAwaitable = reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        throw JsonReaderException.Create(reader, "Error reading JProperty from JsonReader.");
    }
    configuredTaskAwaitable = reader.MoveToContentAsync(cancellationToken).ConfigureAwait(false);
    int num = await configuredTaskAwaitable ? 1 : 0;
    JProperty p = reader.TokenType == JsonToken.PropertyName ? new JProperty((string) reader.Value) : throw JsonReaderException.Create(reader, "Error reading JProperty from JsonReader. Current JsonReader item is not a property: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    p.SetLineInfo(reader as IJsonLineInfo, settings);
    await p.ReadTokenFromAsync(reader, settings, cancellationToken).ConfigureAwait(false);
    JProperty jproperty = p;
    p = (JProperty) null;
    return jproperty;
  }

  protected override IList<JToken> ChildrenTokens => (IList<JToken>) this._content;

  public string Name
  {
    [DebuggerStepThrough] get => this._name;
  }

  public JToken Value
  {
    [DebuggerStepThrough] get => this._content._token;
    set
    {
      this.CheckReentrancy();
      JToken jtoken = value ?? (JToken) JValue.CreateNull();
      if (this._content._token == null)
        this.InsertItem(0, jtoken, false, true);
      else
        this.SetItem(0, jtoken);
    }
  }

  public JProperty(JProperty other)
    : base((JContainer) other, (JsonCloneSettings) null)
  {
    this._name = other.Name;
  }

  internal JProperty(JProperty other, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
    : base((JContainer) other, settings)
  {
    this._name = other.Name;
  }

  internal override JToken GetItem(int index)
  {
    if (index != 0)
      throw new ArgumentOutOfRangeException();
    return this.Value;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override void SetItem(int index, JToken item)
  {
    if (index != 0)
      throw new ArgumentOutOfRangeException();
    if (JContainer.IsTokenUnchanged(this.Value, item))
      return;
    ((JObject) this.Parent)?.InternalPropertyChanging(this);
    base.SetItem(0, item);
    ((JObject) this.Parent)?.InternalPropertyChanged(this);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override bool RemoveItem(JToken item)
  {
    throw new JsonException("Cannot add or remove items from {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
  }

  internal override void RemoveItemAt(int index)
  {
    throw new JsonException("Cannot add or remove items from {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override int IndexOfItem(JToken item) => item == null ? -1 : this._content.IndexOf(item);

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override bool InsertItem(
    int index,
    JToken item,
    bool skipParentCheck,
    bool copyAnnotations)
  {
    if (item != null && item.Type == JTokenType.Comment)
      return false;
    if (this.Value != null)
      throw new JsonException("{0} cannot have multiple values.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
    return base.InsertItem(0, item, false, copyAnnotations);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override bool ContainsItem(JToken item) => this.Value == item;

  internal override void MergeItem(object content, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonMergeSettings settings)
  {
    JToken jtoken = content is JProperty jproperty ? jproperty.Value : (JToken) null;
    if (jtoken == null || jtoken.Type == JTokenType.Null)
      return;
    this.Value = jtoken;
  }

  internal override void ClearItems()
  {
    throw new JsonException("Cannot add or remove items from {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JProperty)));
  }

  internal override bool DeepEquals(JToken node)
  {
    return node is JProperty container && this._name == container.Name && this.ContentsEqual((JContainer) container);
  }

  internal override JToken CloneToken([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
  {
    return (JToken) new JProperty(this, settings);
  }

  public override JTokenType Type
  {
    [DebuggerStepThrough] get => JTokenType.Property;
  }

  internal JProperty(string name)
  {
    ValidationUtils.ArgumentNotNull((object) name, nameof (name));
    this._name = name;
  }

  public JProperty(string name, params object[] content)
    : this(name, (object) content)
  {
  }

  public JProperty(string name, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] object content)
  {
    ValidationUtils.ArgumentNotNull((object) name, nameof (name));
    this._name = name;
    this.Value = this.IsMultiContent(content) ? (JToken) new JArray(content) : JContainer.CreateFromContent(content);
  }

  public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
  {
    writer.WritePropertyName(this._name);
    JToken jtoken = this.Value;
    if (jtoken != null)
      jtoken.WriteTo(writer, converters);
    else
      writer.WriteNull();
  }

  internal override int GetDeepHashCode()
  {
    int hashCode = this._name.GetHashCode();
    JToken jtoken = this.Value;
    int deepHashCode = jtoken != null ? jtoken.GetDeepHashCode() : 0;
    return hashCode ^ deepHashCode;
  }

  public static JProperty Load(JsonReader reader)
  {
    return JProperty.Load(reader, (JsonLoadSettings) null);
  }

  public static JProperty Load(JsonReader reader, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    if (reader.TokenType == JsonToken.None && !reader.Read())
      throw JsonReaderException.Create(reader, "Error reading JProperty from JsonReader.");
    reader.MoveToContent();
    JProperty jproperty = reader.TokenType == JsonToken.PropertyName ? new JProperty((string) reader.Value) : throw JsonReaderException.Create(reader, "Error reading JProperty from JsonReader. Current JsonReader item is not a property: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    jproperty.SetLineInfo(reader as IJsonLineInfo, settings);
    jproperty.ReadTokenFrom(reader, settings);
    return jproperty;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
  private class JPropertyList : IList<JToken>, ICollection<JToken>, IEnumerable<JToken>, IEnumerable
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
    internal JToken _token;

    public IEnumerator<JToken> GetEnumerator()
    {
      if (this._token != null)
        yield return this._token;
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public void Add(JToken item) => this._token = item;

    public void Clear() => this._token = (JToken) null;

    public bool Contains(JToken item) => this._token == item;

    public void CopyTo(JToken[] array, int arrayIndex)
    {
      if (this._token == null)
        return;
      array[arrayIndex] = this._token;
    }

    public bool Remove(JToken item)
    {
      if (this._token != item)
        return false;
      this._token = (JToken) null;
      return true;
    }

    public int Count => this._token == null ? 0 : 1;

    public bool IsReadOnly => false;

    public int IndexOf(JToken item) => this._token != item ? -1 : 0;

    public void Insert(int index, JToken item)
    {
      if (index != 0)
        return;
      this._token = item;
    }

    public void RemoveAt(int index)
    {
      if (index != 0)
        return;
      this._token = (JToken) null;
    }

    public JToken this[int index]
    {
      get
      {
        if (index != 0)
          throw new IndexOutOfRangeException();
        return this._token;
      }
      set
      {
        if (index != 0)
          throw new IndexOutOfRangeException();
        this._token = value;
      }
    }
  }
}
