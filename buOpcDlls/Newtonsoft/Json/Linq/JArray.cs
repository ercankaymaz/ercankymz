// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JArray
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
public class JArray : 
  JContainer,
  IList<JToken>,
  ICollection<JToken>,
  IEnumerable<JToken>,
  IEnumerable
{
  private readonly List<JToken> _values = new List<JToken>();

  public override async Task WriteToAsync(
    JsonWriter writer,
    CancellationToken cancellationToken,
    params JsonConverter[] converters)
  {
    ConfiguredTaskAwaitable configuredTaskAwaitable = writer.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);
    await configuredTaskAwaitable;
    for (int i = 0; i < this._values.Count; ++i)
    {
      configuredTaskAwaitable = this._values[i].WriteToAsync(writer, cancellationToken, converters).ConfigureAwait(false);
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
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JArray.\u003CWriteToAsync\u003Ed__0>(ref awaiter, this);
        return;
      }
    }
    configuredTaskAwaitable = writer.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
    await configuredTaskAwaitable;
  }

  public static Task<JArray> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    return JArray.LoadAsync(reader, (JsonLoadSettings) null, cancellationToken);
  }

  public static async Task<JArray> LoadAsync(
    JsonReader reader,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    ConfiguredTaskAwaitable<bool> configuredTaskAwaitable;
    if (reader.TokenType == JsonToken.None)
    {
      configuredTaskAwaitable = reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader.");
    }
    configuredTaskAwaitable = reader.MoveToContentAsync(cancellationToken).ConfigureAwait(false);
    int num = await configuredTaskAwaitable ? 1 : 0;
    if (reader.TokenType != JsonToken.StartArray)
      throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader. Current JsonReader item is not an array: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    JArray a = new JArray();
    a.SetLineInfo(reader as IJsonLineInfo, settings);
    await a.ReadTokenFromAsync(reader, settings, cancellationToken).ConfigureAwait(false);
    JArray jarray = a;
    a = (JArray) null;
    return jarray;
  }

  protected override IList<JToken> ChildrenTokens => (IList<JToken>) this._values;

  public override JTokenType Type => JTokenType.Array;

  public JArray()
  {
  }

  public JArray(JArray other)
    : base((JContainer) other, (JsonCloneSettings) null)
  {
  }

  internal JArray(JArray other, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
    : base((JContainer) other, settings)
  {
  }

  public JArray(params object[] content)
    : this((object) content)
  {
  }

  public JArray(object content) => this.Add(content);

  internal override bool DeepEquals(JToken node)
  {
    return node is JArray container && this.ContentsEqual((JContainer) container);
  }

  internal override JToken CloneToken([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings = null)
  {
    return (JToken) new JArray(this, settings);
  }

  public static JArray Load(JsonReader reader) => JArray.Load(reader, (JsonLoadSettings) null);

  public static JArray Load(JsonReader reader, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    if (reader.TokenType == JsonToken.None && !reader.Read())
      throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader.");
    reader.MoveToContent();
    if (reader.TokenType != JsonToken.StartArray)
      throw JsonReaderException.Create(reader, "Error reading JArray from JsonReader. Current JsonReader item is not an array: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    JArray jarray = new JArray();
    jarray.SetLineInfo(reader as IJsonLineInfo, settings);
    jarray.ReadTokenFrom(reader, settings);
    return jarray;
  }

  public static JArray Parse(string json) => JArray.Parse(json, (JsonLoadSettings) null);

  public static JArray Parse(string json, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    using (JsonReader reader = (JsonReader) new JsonTextReader((TextReader) new StringReader(json)))
    {
      JArray jarray = JArray.Load(reader, settings);
      do
        ;
      while (reader.Read());
      return jarray;
    }
  }

  public static JArray FromObject(object o) => JArray.FromObject(o, JsonSerializer.CreateDefault());

  public static JArray FromObject(object o, JsonSerializer jsonSerializer)
  {
    JToken jtoken = JToken.FromObjectInternal(o, jsonSerializer);
    return jtoken.Type == JTokenType.Array ? (JArray) jtoken : throw new ArgumentException("Object serialized to {0}. JArray instance expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jtoken.Type));
  }

  public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
  {
    writer.WriteStartArray();
    for (int index = 0; index < this._values.Count; ++index)
      this._values[index].WriteTo(writer, converters);
    writer.WriteEndArray();
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public override JToken this[object key]
  {
    [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] get
    {
      ValidationUtils.ArgumentNotNull(key, nameof (key));
      return key is int index ? this.GetItem(index) : throw new ArgumentException("Accessed JArray values with invalid key value: {0}. Int32 array index expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(key)));
    }
    [param: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] set
    {
      ValidationUtils.ArgumentNotNull(key, nameof (key));
      if (!(key is int index))
        throw new ArgumentException("Set JArray values with invalid key value: {0}. Int32 array index expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(key)));
      this.SetItem(index, value);
    }
  }

  public JToken this[int index]
  {
    get => this.GetItem(index);
    set => this.SetItem(index, value);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override int IndexOfItem(JToken item)
  {
    return item == null ? -1 : this._values.IndexOfReference<JToken>(item);
  }

  internal override void MergeItem(object content, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonMergeSettings settings)
  {
    IEnumerable content1 = this.IsMultiContent(content) || content is JArray ? (IEnumerable) content : (IEnumerable) null;
    if (content1 == null)
      return;
    JContainer.MergeEnumerableContent((JContainer) this, content1, settings);
  }

  public int IndexOf(JToken item) => this.IndexOfItem(item);

  public void Insert(int index, JToken item) => this.InsertItem(index, item, false, true);

  public void RemoveAt(int index) => this.RemoveItemAt(index);

  public IEnumerator<JToken> GetEnumerator() => this.Children().GetEnumerator();

  public void Add(JToken item) => this.Add((object) item);

  public void Clear() => this.ClearItems();

  public bool Contains(JToken item) => this.ContainsItem(item);

  public void CopyTo(JToken[] array, int arrayIndex) => this.CopyItemsTo((Array) array, arrayIndex);

  public bool IsReadOnly => false;

  public bool Remove(JToken item) => this.RemoveItem(item);

  internal override int GetDeepHashCode() => this.ContentsHashCode();
}
