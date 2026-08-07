// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JContainer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(1)]
[System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(0)]
public abstract class JContainer : 
  JToken,
  IList<JToken>,
  ICollection<JToken>,
  IEnumerable<JToken>,
  IEnumerable,
  ITypedList,
  IBindingList,
  IList,
  ICollection,
  INotifyCollectionChanged
{
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  internal ListChangedEventHandler _listChanged;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  internal AddingNewEventHandler _addingNew;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  internal NotifyCollectionChangedEventHandler _collectionChanged;
  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  private object _syncRoot;
  private bool _busy;

  internal async Task ReadTokenFromAsync(
    JsonReader reader,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings options,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    JContainer jcontainer = this;
    ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
    int startDepth = reader.Depth;
    if (!await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
      throw JsonReaderException.Create(reader, "Error reading {0} from JsonReader.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jcontainer.GetType().Name));
    await jcontainer.ReadContentFromAsync(reader, options, cancellationToken).ConfigureAwait(false);
    if (reader.Depth > startDepth)
      throw JsonReaderException.Create(reader, "Unexpected end of content while loading {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) jcontainer.GetType().Name));
  }

  private async Task ReadContentFromAsync(
    JsonReader reader,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    JContainer jcontainer = this;
    IJsonLineInfo lineInfo = reader as IJsonLineInfo;
    JContainer parent = jcontainer;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
    do
    {
      if (parent is JProperty jproperty1 && jproperty1.Value != null)
      {
        if (parent != jcontainer)
          parent = parent.Parent;
        else
          goto label_1;
      }
      switch (reader.TokenType)
      {
        case JsonToken.None:
          continue;
        case JsonToken.StartObject:
          JObject content1 = new JObject();
          content1.SetLineInfo(lineInfo, settings);
          parent.Add((object) content1);
          parent = (JContainer) content1;
          goto case JsonToken.None;
        case JsonToken.StartArray:
          JArray content2 = new JArray();
          content2.SetLineInfo(lineInfo, settings);
          parent.Add((object) content2);
          parent = (JContainer) content2;
          goto case JsonToken.None;
        case JsonToken.StartConstructor:
          JConstructor content3 = new JConstructor(reader.Value.ToString());
          content3.SetLineInfo(lineInfo, settings);
          parent.Add((object) content3);
          parent = (JContainer) content3;
          goto case JsonToken.None;
        case JsonToken.PropertyName:
          JProperty jproperty2 = JContainer.ReadProperty(reader, settings, lineInfo, parent);
          if (jproperty2 != null)
          {
            parent = (JContainer) jproperty2;
            goto case JsonToken.None;
          }
          awaiter = reader.SkipAsync().ConfigureAwait(false).GetAwaiter();
          if (awaiter.IsCompleted)
          {
            awaiter.GetResult();
            goto case JsonToken.None;
          }
          goto label_29;
        case JsonToken.Comment:
          if (settings != null && settings.CommentHandling == CommentHandling.Load)
          {
            JValue comment = JValue.CreateComment(reader.Value.ToString());
            comment.SetLineInfo(lineInfo, settings);
            parent.Add((object) comment);
            goto case JsonToken.None;
          }
          goto case JsonToken.None;
        case JsonToken.Integer:
        case JsonToken.Float:
        case JsonToken.String:
        case JsonToken.Boolean:
        case JsonToken.Date:
        case JsonToken.Bytes:
          JValue content4 = new JValue(reader.Value);
          content4.SetLineInfo(lineInfo, settings);
          parent.Add((object) content4);
          goto case JsonToken.None;
        case JsonToken.Null:
          JValue content5 = JValue.CreateNull();
          content5.SetLineInfo(lineInfo, settings);
          parent.Add((object) content5);
          goto case JsonToken.None;
        case JsonToken.Undefined:
          JValue undefined = JValue.CreateUndefined();
          undefined.SetLineInfo(lineInfo, settings);
          parent.Add((object) undefined);
          goto case JsonToken.None;
        case JsonToken.EndObject:
          if (parent != jcontainer)
          {
            parent = parent.Parent;
            goto case JsonToken.None;
          }
          goto label_31;
        case JsonToken.EndArray:
          if (parent != jcontainer)
          {
            parent = parent.Parent;
            goto case JsonToken.None;
          }
          goto label_14;
        case JsonToken.EndConstructor:
          if (parent != jcontainer)
          {
            parent = parent.Parent;
            goto case JsonToken.None;
          }
          goto label_4;
        default:
          goto label_30;
      }
    }
    while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false));
    lineInfo = (IJsonLineInfo) null;
    parent = (JContainer) null;
    return;
label_1:
    lineInfo = (IJsonLineInfo) null;
    parent = (JContainer) null;
    return;
label_31:
    lineInfo = (IJsonLineInfo) null;
    parent = (JContainer) null;
    return;
label_14:
    lineInfo = (IJsonLineInfo) null;
    parent = (JContainer) null;
    return;
label_4:
    lineInfo = (IJsonLineInfo) null;
    parent = (JContainer) null;
    return;
label_29:
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 0;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, JContainer.\u003CReadContentFromAsync\u003Ed__1>(ref awaiter, this);
    return;
label_30:
    throw new InvalidOperationException("The JsonReader should not be on a token of type {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
  }

  public event ListChangedEventHandler ListChanged
  {
    add => this._listChanged += value;
    remove => this._listChanged -= value;
  }

  public event AddingNewEventHandler AddingNew
  {
    add => this._addingNew += value;
    remove => this._addingNew -= value;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public event NotifyCollectionChangedEventHandler CollectionChanged
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] add
    {
      this._collectionChanged += value;
    }
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] remove
    {
      this._collectionChanged -= value;
    }
  }

  protected abstract IList<JToken> ChildrenTokens { get; }

  internal JContainer()
  {
  }

  internal JContainer(JContainer other, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonCloneSettings settings)
    : this()
  {
    ValidationUtils.ArgumentNotNull((object) other, nameof (other));
    bool copyAnnotations;
    if (copyAnnotations = settings == null || settings.CopyAnnotations)
      this.CopyAnnotations((JToken) this, (JToken) other);
    int index = 0;
    foreach (JToken content in (IEnumerable<JToken>) other)
    {
      this.TryAddInternal(index, (object) content, false, copyAnnotations);
      ++index;
    }
  }

  internal void CheckReentrancy()
  {
    if (this._busy)
      throw new InvalidOperationException("Cannot change {0} during a collection change event.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
  }

  internal virtual IList<JToken> CreateChildrenCollection() => (IList<JToken>) new List<JToken>();

  protected virtual void OnAddingNew(AddingNewEventArgs e)
  {
    AddingNewEventHandler addingNew = this._addingNew;
    if (addingNew == null)
      return;
    addingNew((object) this, e);
  }

  protected virtual void OnListChanged(ListChangedEventArgs e)
  {
    ListChangedEventHandler listChanged = this._listChanged;
    if (listChanged == null)
      return;
    this._busy = true;
    try
    {
      listChanged((object) this, e);
    }
    finally
    {
      this._busy = false;
    }
  }

  protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
  {
    NotifyCollectionChangedEventHandler collectionChanged = this._collectionChanged;
    if (collectionChanged == null)
      return;
    this._busy = true;
    try
    {
      collectionChanged((object) this, e);
    }
    finally
    {
      this._busy = false;
    }
  }

  public override bool HasValues => this.ChildrenTokens.Count > 0;

  internal bool ContentsEqual(JContainer container)
  {
    if (container == this)
      return true;
    IList<JToken> childrenTokens1 = this.ChildrenTokens;
    IList<JToken> childrenTokens2 = container.ChildrenTokens;
    if (childrenTokens1.Count != childrenTokens2.Count)
      return false;
    for (int index = 0; index < childrenTokens1.Count; ++index)
    {
      if (!childrenTokens1[index].DeepEquals(childrenTokens2[index]))
        return false;
    }
    return true;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public override JToken First
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] get
    {
      IList<JToken> childrenTokens = this.ChildrenTokens;
      return childrenTokens.Count <= 0 ? (JToken) null : childrenTokens[0];
    }
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  public override JToken Last
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] get
    {
      IList<JToken> childrenTokens = this.ChildrenTokens;
      int count = childrenTokens.Count;
      return count <= 0 ? (JToken) null : childrenTokens[count - 1];
    }
  }

  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {0, 1})]
  public override JEnumerable<JToken> Children()
  {
    return new JEnumerable<JToken>((IEnumerable<JToken>) this.ChildrenTokens);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  [return: System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(new byte[] {1, 2})]
  public override IEnumerable<T> Values<T>() => this.ChildrenTokens.Convert<JToken, T>();

  public IEnumerable<JToken> Descendants() => this.GetDescendants(false);

  public IEnumerable<JToken> DescendantsAndSelf() => this.GetDescendants(true);

  internal IEnumerable<JToken> GetDescendants(bool self)
  {
    JContainer descendant1 = this;
    if (self)
      yield return (JToken) descendant1;
    foreach (JToken o in (IEnumerable<JToken>) descendant1.ChildrenTokens)
    {
      yield return o;
      if (o is JContainer jcontainer)
      {
        foreach (JToken descendant2 in jcontainer.Descendants())
          yield return descendant2;
      }
    }
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal bool IsMultiContent([NotNullWhen(true)] object content)
  {
    return content is IEnumerable && !(content is string) && !(content is JToken) && !(content is byte[]);
  }

  internal JToken EnsureParentToken([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JToken item, bool skipParentCheck, bool copyAnnotations)
  {
    if (item == null)
      return (JToken) JValue.CreateNull();
    if (skipParentCheck || item.Parent == null && item != this && (!item.HasValues || this.Root != item))
      return item;
    JsonCloneSettings skipCopyAnnotations = copyAnnotations ? (JsonCloneSettings) null : JsonCloneSettings.SkipCopyAnnotations;
    item = item.CloneToken(skipCopyAnnotations);
    return item;
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal abstract int IndexOfItem(JToken item);

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal virtual bool InsertItem(
    int index,
    JToken item,
    bool skipParentCheck,
    bool copyAnnotations)
  {
    IList<JToken> childrenTokens = this.ChildrenTokens;
    if (index > childrenTokens.Count)
      throw new ArgumentOutOfRangeException(nameof (index), "Index must be within the bounds of the List.");
    this.CheckReentrancy();
    item = this.EnsureParentToken(item, skipParentCheck, copyAnnotations);
    JToken jtoken1 = index == 0 ? (JToken) null : childrenTokens[index - 1];
    JToken jtoken2 = index == childrenTokens.Count ? (JToken) null : childrenTokens[index];
    this.ValidateToken(item, (JToken) null);
    item.Parent = this;
    item.Previous = jtoken1;
    if (jtoken1 != null)
      jtoken1.Next = item;
    item.Next = jtoken2;
    if (jtoken2 != null)
      jtoken2.Previous = item;
    childrenTokens.Insert(index, item);
    if (this._listChanged != null)
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    if (this._collectionChanged != null)
      this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (object) item, index));
    return true;
  }

  internal virtual void RemoveItemAt(int index)
  {
    IList<JToken> childrenTokens = this.ChildrenTokens;
    if (index < 0)
      throw new ArgumentOutOfRangeException(nameof (index), "Index is less than 0.");
    if (index >= childrenTokens.Count)
      throw new ArgumentOutOfRangeException(nameof (index), "Index is equal to or greater than Count.");
    this.CheckReentrancy();
    JToken changedItem = childrenTokens[index];
    JToken jtoken1 = index == 0 ? (JToken) null : childrenTokens[index - 1];
    JToken jtoken2 = index == childrenTokens.Count - 1 ? (JToken) null : childrenTokens[index + 1];
    if (jtoken1 != null)
      jtoken1.Next = jtoken2;
    if (jtoken2 != null)
      jtoken2.Previous = jtoken1;
    changedItem.Parent = (JContainer) null;
    changedItem.Previous = (JToken) null;
    changedItem.Next = (JToken) null;
    childrenTokens.RemoveAt(index);
    if (this._listChanged != null)
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
    if (this._collectionChanged == null)
      return;
    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, (object) changedItem, index));
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal virtual bool RemoveItem(JToken item)
  {
    if (item != null)
    {
      int index = this.IndexOfItem(item);
      if (index >= 0)
      {
        this.RemoveItemAt(index);
        return true;
      }
    }
    return false;
  }

  internal virtual JToken GetItem(int index) => this.ChildrenTokens[index];

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal virtual void SetItem(int index, JToken item)
  {
    IList<JToken> childrenTokens = this.ChildrenTokens;
    if (index < 0)
      throw new ArgumentOutOfRangeException(nameof (index), "Index is less than 0.");
    if (index >= childrenTokens.Count)
      throw new ArgumentOutOfRangeException(nameof (index), "Index is equal to or greater than Count.");
    JToken jtoken1 = childrenTokens[index];
    if (JContainer.IsTokenUnchanged(jtoken1, item))
      return;
    this.CheckReentrancy();
    item = this.EnsureParentToken(item, false, true);
    this.ValidateToken(item, jtoken1);
    JToken jtoken2 = index == 0 ? (JToken) null : childrenTokens[index - 1];
    JToken jtoken3 = index == childrenTokens.Count - 1 ? (JToken) null : childrenTokens[index + 1];
    item.Parent = this;
    item.Previous = jtoken2;
    if (jtoken2 != null)
      jtoken2.Next = item;
    item.Next = jtoken3;
    if (jtoken3 != null)
      jtoken3.Previous = item;
    childrenTokens[index] = item;
    jtoken1.Parent = (JContainer) null;
    jtoken1.Previous = (JToken) null;
    jtoken1.Next = (JToken) null;
    if (this._listChanged != null)
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
    if (this._collectionChanged == null)
      return;
    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, (object) item, (object) jtoken1, index));
  }

  internal virtual void ClearItems()
  {
    this.CheckReentrancy();
    IList<JToken> childrenTokens = this.ChildrenTokens;
    foreach (JToken jtoken in (IEnumerable<JToken>) childrenTokens)
    {
      jtoken.Parent = (JContainer) null;
      jtoken.Previous = (JToken) null;
      jtoken.Next = (JToken) null;
    }
    childrenTokens.Clear();
    if (this._listChanged != null)
      this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    if (this._collectionChanged == null)
      return;
    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
  }

  internal virtual void ReplaceItem(JToken existing, JToken replacement)
  {
    if (existing == null || existing.Parent != this)
      return;
    this.SetItem(this.IndexOfItem(existing), replacement);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal virtual bool ContainsItem(JToken item) => this.IndexOfItem(item) != -1;

  internal virtual void CopyItemsTo(Array array, int arrayIndex)
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
    foreach (JToken childrenToken in (IEnumerable<JToken>) this.ChildrenTokens)
    {
      array.SetValue((object) childrenToken, arrayIndex + num);
      ++num;
    }
  }

  internal static bool IsTokenUnchanged(JToken currentValue, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JToken newValue)
  {
    if (!(currentValue is JValue jvalue))
      return false;
    return newValue == null ? jvalue.Type == JTokenType.Null : jvalue.Equals((object) newValue);
  }

  internal virtual void ValidateToken(JToken o, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JToken existing)
  {
    ValidationUtils.ArgumentNotNull((object) o, nameof (o));
    if (o.Type == JTokenType.Property)
      throw new ArgumentException("Can not add {0} to {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) o.GetType(), (object) this.GetType()));
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public virtual void Add(object content)
  {
    this.TryAddInternal(this.ChildrenTokens.Count, content, false, true);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal bool TryAdd(object content)
  {
    return this.TryAddInternal(this.ChildrenTokens.Count, content, false, true);
  }

  internal void AddAndSkipParentCheck(JToken token)
  {
    this.TryAddInternal(this.ChildrenTokens.Count, (object) token, true, true);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public void AddFirst(object content) => this.TryAddInternal(0, content, false, true);

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  internal bool TryAddInternal(
    int index,
    object content,
    bool skipParentCheck,
    bool copyAnnotations)
  {
    if (this.IsMultiContent(content))
    {
      IEnumerable enumerable = (IEnumerable) content;
      int index1 = index;
      foreach (object content1 in enumerable)
      {
        this.TryAddInternal(index1, content1, skipParentCheck, copyAnnotations);
        ++index1;
      }
      return true;
    }
    JToken fromContent = JContainer.CreateFromContent(content);
    return this.InsertItem(index, fromContent, skipParentCheck, copyAnnotations);
  }

  internal static JToken CreateFromContent([System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] object content)
  {
    return content is JToken jtoken ? jtoken : (JToken) new JValue(content);
  }

  public JsonWriter CreateWriter() => (JsonWriter) new JTokenWriter(this);

  public void ReplaceAll(object content)
  {
    this.ClearItems();
    this.Add(content);
  }

  public void RemoveAll() => this.ClearItems();

  internal abstract void MergeItem(object content, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonMergeSettings settings);

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public void Merge(object content)
  {
    if (content == null)
      return;
    this.ValidateContent(content);
    this.MergeItem(content, (JsonMergeSettings) null);
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  public void Merge(object content, JsonMergeSettings settings)
  {
    if (content == null)
      return;
    this.ValidateContent(content);
    this.MergeItem(content, settings);
  }

  private void ValidateContent(object content)
  {
    if (!content.GetType().IsSubclassOf(typeof (JToken)) && !this.IsMultiContent(content))
      throw new ArgumentException("Could not determine JSON object type for type {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) content.GetType()), nameof (content));
  }

  internal void ReadTokenFrom(JsonReader reader, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings options)
  {
    int depth = reader.Depth;
    if (!reader.Read())
      throw JsonReaderException.Create(reader, "Error reading {0} from JsonReader.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType().Name));
    this.ReadContentFrom(reader, options);
    if (reader.Depth > depth)
      throw JsonReaderException.Create(reader, "Unexpected end of content while loading {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType().Name));
  }

  internal void ReadContentFrom(JsonReader r, [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonLoadSettings settings)
  {
    ValidationUtils.ArgumentNotNull((object) r, nameof (r));
    IJsonLineInfo lineInfo = r as IJsonLineInfo;
    JContainer parent = this;
    do
    {
      if (parent is JProperty jproperty1 && jproperty1.Value != null)
        goto label_20;
label_1:
      switch (r.TokenType)
      {
        case JsonToken.None:
          continue;
        case JsonToken.StartObject:
          JObject content1 = new JObject();
          content1.SetLineInfo(lineInfo, settings);
          parent.Add((object) content1);
          parent = (JContainer) content1;
          goto case JsonToken.None;
        case JsonToken.StartArray:
          JArray content2 = new JArray();
          content2.SetLineInfo(lineInfo, settings);
          parent.Add((object) content2);
          parent = (JContainer) content2;
          goto case JsonToken.None;
        case JsonToken.StartConstructor:
          JConstructor content3 = new JConstructor(r.Value.ToString());
          content3.SetLineInfo(lineInfo, settings);
          parent.Add((object) content3);
          parent = (JContainer) content3;
          goto case JsonToken.None;
        case JsonToken.PropertyName:
          JProperty jproperty2 = JContainer.ReadProperty(r, settings, lineInfo, parent);
          if (jproperty2 != null)
          {
            parent = (JContainer) jproperty2;
            goto case JsonToken.None;
          }
          r.Skip();
          goto case JsonToken.None;
        case JsonToken.Comment:
          if (settings != null && settings.CommentHandling == CommentHandling.Load)
          {
            JValue comment = JValue.CreateComment(r.Value.ToString());
            comment.SetLineInfo(lineInfo, settings);
            parent.Add((object) comment);
            goto case JsonToken.None;
          }
          goto case JsonToken.None;
        case JsonToken.Integer:
        case JsonToken.Float:
        case JsonToken.String:
        case JsonToken.Boolean:
        case JsonToken.Date:
        case JsonToken.Bytes:
          JValue content4 = new JValue(r.Value);
          content4.SetLineInfo(lineInfo, settings);
          parent.Add((object) content4);
          goto case JsonToken.None;
        case JsonToken.Null:
          JValue content5 = JValue.CreateNull();
          content5.SetLineInfo(lineInfo, settings);
          parent.Add((object) content5);
          goto case JsonToken.None;
        case JsonToken.Undefined:
          JValue undefined = JValue.CreateUndefined();
          undefined.SetLineInfo(lineInfo, settings);
          parent.Add((object) undefined);
          goto case JsonToken.None;
        case JsonToken.EndObject:
          if (parent != this)
          {
            parent = parent.Parent;
            goto case JsonToken.None;
          }
          goto label_24;
        case JsonToken.EndArray:
          if (parent != this)
          {
            parent = parent.Parent;
            goto case JsonToken.None;
          }
          goto label_26;
        case JsonToken.EndConstructor:
          if (parent != this)
          {
            parent = parent.Parent;
            goto case JsonToken.None;
          }
          goto label_27;
        default:
          goto label_25;
      }
label_20:
      if (parent != this)
      {
        parent = parent.Parent;
        goto label_1;
      }
      goto label_23;
    }
    while (r.Read());
    goto label_28;
label_24:
    return;
label_26:
    return;
label_27:
    return;
label_28:
    return;
label_23:
    return;
label_25:
    throw new InvalidOperationException("The JsonReader should not be on a token of type {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) r.TokenType));
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  private static JProperty ReadProperty(
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(1)] JsonReader r,
    JsonLoadSettings settings,
    IJsonLineInfo lineInfo,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(1)] JContainer parent)
  {
    DuplicatePropertyNameHandling propertyNameHandling = settings != null ? settings.DuplicatePropertyNameHandling : DuplicatePropertyNameHandling.Replace;
    JObject jobject = (JObject) parent;
    string name1 = r.Value.ToString();
    string name2 = name1;
    JProperty jproperty = jobject.Property(name2, StringComparison.Ordinal);
    if (jproperty != null)
    {
      if (propertyNameHandling == DuplicatePropertyNameHandling.Ignore)
        return (JProperty) null;
      if (propertyNameHandling == DuplicatePropertyNameHandling.Error)
        throw JsonReaderException.Create(r, "Property with the name '{0}' already exists in the current JSON object.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) name1));
    }
    JProperty content = new JProperty(name1);
    content.SetLineInfo(lineInfo, settings);
    if (jproperty == null)
      parent.Add((object) content);
    else
      jproperty.Replace((JToken) content);
    return content;
  }

  internal int ContentsHashCode()
  {
    int num = 0;
    foreach (JToken childrenToken in (IEnumerable<JToken>) this.ChildrenTokens)
      num ^= childrenToken.GetDeepHashCode();
    return num;
  }

  string ITypedList.GetListName(PropertyDescriptor[] listAccessors) => string.Empty;

  PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
  {
    PropertyDescriptorCollection itemProperties;
    if (!(this.First is ICustomTypeDescriptor first))
    {
      itemProperties = (PropertyDescriptorCollection) null;
    }
    else
    {
      itemProperties = first.GetProperties();
      if (itemProperties != null)
        return itemProperties;
    }
    return new PropertyDescriptorCollection(CollectionUtils.ArrayEmpty<PropertyDescriptor>());
  }

  int IList<JToken>.IndexOf(JToken item) => this.IndexOfItem(item);

  void IList<JToken>.Insert(int index, JToken item) => this.InsertItem(index, item, false, true);

  void IList<JToken>.RemoveAt(int index) => this.RemoveItemAt(index);

  JToken IList<JToken>.this[int index]
  {
    get => this.GetItem(index);
    set => this.SetItem(index, value);
  }

  void ICollection<JToken>.Add(JToken item) => this.Add((object) item);

  void ICollection<JToken>.Clear() => this.ClearItems();

  bool ICollection<JToken>.Contains(JToken item) => this.ContainsItem(item);

  void ICollection<JToken>.CopyTo(JToken[] array, int arrayIndex)
  {
    this.CopyItemsTo((Array) array, arrayIndex);
  }

  bool ICollection<JToken>.IsReadOnly => false;

  bool ICollection<JToken>.Remove(JToken item) => this.RemoveItem(item);

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  private JToken EnsureValue(object value)
  {
    if (value == null)
      return (JToken) null;
    return value is JToken jtoken ? jtoken : throw new ArgumentException("Argument is not a JToken.");
  }

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  int IList.Add(object value)
  {
    this.Add((object) this.EnsureValue(value));
    return this.Count - 1;
  }

  void IList.Clear() => this.ClearItems();

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  bool IList.Contains(object value) => this.ContainsItem(this.EnsureValue(value));

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  int IList.IndexOf(object value) => this.IndexOfItem(this.EnsureValue(value));

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  void IList.Insert(int index, object value)
  {
    this.InsertItem(index, this.EnsureValue(value), false, false);
  }

  bool IList.IsFixedSize => false;

  bool IList.IsReadOnly => false;

  [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)]
  void IList.Remove(object value) => this.RemoveItem(this.EnsureValue(value));

  void IList.RemoveAt(int index) => this.RemoveItemAt(index);

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  object IList.this[int index]
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] get
    {
      return (object) this.GetItem(index);
    }
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] set
    {
      this.SetItem(index, this.EnsureValue(value));
    }
  }

  void ICollection.CopyTo(Array array, int index) => this.CopyItemsTo(array, index);

  public int Count => this.ChildrenTokens.Count;

  bool ICollection.IsSynchronized => false;

  object ICollection.SyncRoot
  {
    get
    {
      if (this._syncRoot == null)
        Interlocked.CompareExchange(ref this._syncRoot, new object(), (object) null);
      return this._syncRoot;
    }
  }

  void IBindingList.AddIndex(PropertyDescriptor property)
  {
  }

  object IBindingList.AddNew()
  {
    AddingNewEventArgs e = new AddingNewEventArgs();
    this.OnAddingNew(e);
    if (e.NewObject == null)
      throw new JsonException("Could not determine new value to add to '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
    if (!(e.NewObject is JToken newObject))
      throw new JsonException("New item to be added to collection must be compatible with {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (JToken)));
    this.Add((object) newObject);
    return (object) newObject;
  }

  bool IBindingList.AllowEdit => true;

  bool IBindingList.AllowNew => true;

  bool IBindingList.AllowRemove => true;

  void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
  {
    throw new NotSupportedException();
  }

  int IBindingList.Find(PropertyDescriptor property, object key)
  {
    throw new NotSupportedException();
  }

  bool IBindingList.IsSorted => false;

  void IBindingList.RemoveIndex(PropertyDescriptor property)
  {
  }

  void IBindingList.RemoveSort() => throw new NotSupportedException();

  ListSortDirection IBindingList.SortDirection => ListSortDirection.Ascending;

  [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)]
  PropertyDescriptor IBindingList.SortProperty
  {
    [System.Runtime.CompilerServices.Newtonsoft.Json.NullableContext(2)] get
    {
      return (PropertyDescriptor) null;
    }
  }

  bool IBindingList.SupportsChangeNotification => true;

  bool IBindingList.SupportsSearching => false;

  bool IBindingList.SupportsSorting => false;

  internal static void MergeEnumerableContent(
    JContainer target,
    IEnumerable content,
    [System.Runtime.CompilerServices.Newtonsoft.Json.Nullable(2)] JsonMergeSettings settings)
  {
    if (settings != null)
    {
      switch (settings.MergeArrayHandling)
      {
        case MergeArrayHandling.Concat:
          break;
        case MergeArrayHandling.Union:
          HashSet<JToken> jtokenSet = new HashSet<JToken>((IEnumerable<JToken>) target, (IEqualityComparer<JToken>) JToken.EqualityComparer);
          IEnumerator enumerator1 = content.GetEnumerator();
          try
          {
            while (enumerator1.MoveNext())
            {
              JToken fromContent = JContainer.CreateFromContent(enumerator1.Current);
              if (jtokenSet.Add(fromContent))
                target.Add((object) fromContent);
            }
            return;
          }
          finally
          {
            if (enumerator1 is IDisposable disposable)
              disposable.Dispose();
          }
        case MergeArrayHandling.Replace:
          if (target == content)
            return;
          target.ClearItems();
          IEnumerator enumerator2 = content.GetEnumerator();
          try
          {
            while (enumerator2.MoveNext())
            {
              object current = enumerator2.Current;
              target.Add((object) JContainer.CreateFromContent(current));
            }
            return;
          }
          finally
          {
            if (enumerator2 is IDisposable disposable)
              disposable.Dispose();
          }
        case MergeArrayHandling.Merge:
          int key = 0;
          IEnumerator enumerator3 = content.GetEnumerator();
          try
          {
            while (enumerator3.MoveNext())
            {
              object current = enumerator3.Current;
              if (key < target.Count)
              {
                if (target[(object) key] is JContainer jcontainer)
                  jcontainer.Merge(current, settings);
                else if (current != null)
                {
                  JToken fromContent = JContainer.CreateFromContent(current);
                  if (fromContent.Type != JTokenType.Null)
                    target[(object) key] = fromContent;
                }
              }
              else
                target.Add((object) JContainer.CreateFromContent(current));
              ++key;
            }
            return;
          }
          finally
          {
            if (enumerator3 is IDisposable disposable)
              disposable.Dispose();
          }
        default:
          throw new ArgumentOutOfRangeException(nameof (settings), "Unexpected merge array handling when merging JSON.");
      }
    }
    foreach (object content1 in content)
      target.Add((object) JContainer.CreateFromContent(content1));
  }
}
