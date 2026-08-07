// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JConstructor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
public class JConstructor : JContainer
{
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  private string _name;
  private readonly List<JToken> _values = new List<JToken>();

  public override async Task WriteToAsync(
    JsonWriter writer,
    CancellationToken cancellationToken,
    params JsonConverter[] converters)
  {
    await writer.WriteStartConstructorAsync(this._name ?? string.Empty, cancellationToken).ConfigureAwait(false);
    for (int i = 0; i < this._values.Count; ++i)
    {
      ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter = this._values[i].WriteToAsync(writer, cancellationToken, converters).ConfigureAwait(false).GetAwaiter();
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
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JConstructor.\u003CWriteToAsync\u003Ed__0>(ref awaiter, this);
        return;
      }
    }
    await writer.WriteEndConstructorAsync(cancellationToken).ConfigureAwait(false);
  }

  public static Task<JConstructor> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    return JConstructor.LoadAsync(reader, (JsonLoadSettings) null, cancellationToken);
  }

  public static async Task<JConstructor> LoadAsync(
    JsonReader reader,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    ConfiguredTaskAwaitable<bool> configuredTaskAwaitable;
    if (reader.TokenType == JsonToken.None)
    {
      configuredTaskAwaitable = reader.ReadAsync(cancellationToken).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader.");
    }
    configuredTaskAwaitable = reader.MoveToContentAsync(cancellationToken).ConfigureAwait(false);
    int num = await configuredTaskAwaitable ? 1 : 0;
    JConstructor c = reader.TokenType == JsonToken.StartConstructor ? new JConstructor((string) reader.Value) : throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader. Current JsonReader item is not a constructor: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    c.SetLineInfo(reader as IJsonLineInfo, settings);
    await c.ReadTokenFromAsync(reader, settings, cancellationToken).ConfigureAwait(false);
    JConstructor jconstructor = c;
    c = (JConstructor) null;
    return jconstructor;
  }

  protected override IList<JToken> ChildrenTokens => (IList<JToken>) this._values;

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal override int IndexOfItem(JToken item)
  {
    return item == null ? -1 : this._values.IndexOfReference<JToken>(item);
  }

  internal override void MergeItem(object content, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonMergeSettings settings)
  {
    if (!(content is JConstructor content1))
      return;
    if (content1.Name != null)
      this.Name = content1.Name;
    JContainer.MergeEnumerableContent((JContainer) this, (IEnumerable) content1, settings);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public string Name
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] get => this._name;
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] set => this._name = value;
  }

  public override JTokenType Type => JTokenType.Constructor;

  public JConstructor()
  {
  }

  public JConstructor(JConstructor other)
    : base((JContainer) other, (JsonCloneSettings) null)
  {
    this._name = other.Name;
  }

  internal JConstructor(JConstructor other, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
    : base((JContainer) other, settings)
  {
    this._name = other.Name;
  }

  public JConstructor(string name, params object[] content)
    : this(name, (object) content)
  {
  }

  public JConstructor(string name, object content)
    : this(name)
  {
    this.Add(content);
  }

  public JConstructor(string name)
  {
    switch (name)
    {
      case null:
        throw new ArgumentNullException(nameof (name));
      case "":
        throw new ArgumentException("Constructor name cannot be empty.", nameof (name));
      default:
        this._name = name;
        break;
    }
  }

  internal override bool DeepEquals(JToken node)
  {
    return node is JConstructor container && this._name == container.Name && this.ContentsEqual((JContainer) container);
  }

  internal override JToken CloneToken([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings = null)
  {
    return (JToken) new JConstructor(this, settings);
  }

  public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
  {
    writer.WriteStartConstructor(this._name);
    int count = this._values.Count;
    for (int index = 0; index < count; ++index)
      this._values[index].WriteTo(writer, converters);
    writer.WriteEndConstructor();
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public override JToken this[object key]
  {
    [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] get
    {
      ValidationUtils.ArgumentNotNull(key, nameof (key));
      return key is int index ? this.GetItem(index) : throw new ArgumentException("Accessed JConstructor values with invalid key value: {0}. Argument position index expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(key)));
    }
    [param: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] set
    {
      ValidationUtils.ArgumentNotNull(key, nameof (key));
      if (!(key is int index))
        throw new ArgumentException("Set JConstructor values with invalid key value: {0}. Argument position index expected.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(key)));
      this.SetItem(index, value);
    }
  }

  internal override int GetDeepHashCode()
  {
    string name = this._name;
    return (name != null ? name.GetHashCode() : 0) ^ this.ContentsHashCode();
  }

  public static JConstructor Load(JsonReader reader)
  {
    return JConstructor.Load(reader, (JsonLoadSettings) null);
  }

  public static JConstructor Load(JsonReader reader, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    if (reader.TokenType == JsonToken.None && !reader.Read())
      throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader.");
    reader.MoveToContent();
    JConstructor jconstructor = reader.TokenType == JsonToken.StartConstructor ? new JConstructor((string) reader.Value) : throw JsonReaderException.Create(reader, "Error reading JConstructor from JsonReader. Current JsonReader item is not a constructor: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    jconstructor.SetLineInfo(reader as IJsonLineInfo, settings);
    jconstructor.ReadTokenFrom(reader, settings);
    return jconstructor;
  }
}
