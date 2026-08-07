// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.TagList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics;

[SecuritySafeCritical]
[ComVisible(true)]
public struct TagList : 
  IList<KeyValuePair<string, object>>,
  ICollection<KeyValuePair<string, object>>,
  IEnumerable<KeyValuePair<string, object>>,
  IEnumerable,
  IReadOnlyList<KeyValuePair<string, object>>,
  IReadOnlyCollection<KeyValuePair<string, object>>
{
  internal KeyValuePair<string, object> Tag1;
  internal KeyValuePair<string, object> Tag2;
  internal KeyValuePair<string, object> Tag3;
  internal KeyValuePair<string, object> Tag4;
  internal KeyValuePair<string, object> Tag5;
  internal KeyValuePair<string, object> Tag6;
  internal KeyValuePair<string, object> Tag7;
  internal KeyValuePair<string, object> Tag8;
  private int _tagsCount;
  private KeyValuePair<string, object>[] _overflowTags;
  private const int OverflowAdditionalCapacity = 8;

  public TagList([Nullable(new byte[] {0, 0, 1, 2})] ReadOnlySpan<KeyValuePair<string, object>> tagList)
    : this()
  {
    this._tagsCount = tagList.Length;
    switch (this._tagsCount)
    {
      case 0:
        break;
      case 1:
        this.Tag1 = tagList[0];
        break;
      case 2:
        this.Tag2 = tagList[1];
        goto case 1;
      case 3:
        this.Tag3 = tagList[2];
        goto case 2;
      case 4:
        this.Tag4 = tagList[3];
        goto case 3;
      case 5:
        this.Tag5 = tagList[4];
        goto case 4;
      case 6:
        this.Tag6 = tagList[5];
        goto case 5;
      case 7:
        this.Tag7 = tagList[6];
        goto case 6;
      case 8:
        this.Tag8 = tagList[7];
        goto case 7;
      default:
        this._overflowTags = new KeyValuePair<string, object>[this._tagsCount + 8];
        tagList.CopyTo((Span<KeyValuePair<string, object>>) this._overflowTags);
        break;
    }
  }

  public int Count
  {
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly] get
    {
      return this._tagsCount;
    }
  }

  public bool IsReadOnly
  {
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly] get => false;
  }

  [Nullable(new byte[] {0, 1, 2})]
  public KeyValuePair<string, object> this[int index]
  {
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly] [return: Nullable(new byte[] {0, 1, 2})] get
    {
      if ((uint) index >= (uint) this._tagsCount)
        throw new ArgumentOutOfRangeException(nameof (index));
      if (this._overflowTags != null)
        return this._overflowTags[index];
      KeyValuePair<string, object> keyValuePair;
      switch (index)
      {
        case 0:
          keyValuePair = this.Tag1;
          break;
        case 1:
          keyValuePair = this.Tag2;
          break;
        case 2:
          keyValuePair = this.Tag3;
          break;
        case 3:
          keyValuePair = this.Tag4;
          break;
        case 4:
          keyValuePair = this.Tag5;
          break;
        case 5:
          keyValuePair = this.Tag6;
          break;
        case 6:
          keyValuePair = this.Tag7;
          break;
        case 7:
          keyValuePair = this.Tag8;
          break;
        default:
          keyValuePair = new KeyValuePair<string, object>();
          break;
      }
      return keyValuePair;
    }
    [param: Nullable(new byte[] {0, 1, 2})] set
    {
      if ((uint) index >= (uint) this._tagsCount)
        throw new ArgumentOutOfRangeException(nameof (index));
      if (this._overflowTags != null)
      {
        this._overflowTags[index] = value;
      }
      else
      {
        switch (index)
        {
          case 0:
            this.Tag1 = value;
            break;
          case 1:
            this.Tag2 = value;
            break;
          case 2:
            this.Tag3 = value;
            break;
          case 3:
            this.Tag4 = value;
            break;
          case 4:
            this.Tag5 = value;
            break;
          case 5:
            this.Tag6 = value;
            break;
          case 6:
            this.Tag7 = value;
            break;
          case 7:
            this.Tag8 = value;
            break;
        }
      }
    }
  }

  [NullableContext(1)]
  public void Add(string key, [Nullable(2)] object value)
  {
    this.Add(new KeyValuePair<string, object>(key, value));
  }

  public void Add([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag)
  {
    if (this._overflowTags != null)
    {
      if (this._tagsCount == this._overflowTags.Length)
        Array.Resize<KeyValuePair<string, object>>(ref this._overflowTags, this._tagsCount + 8);
      this._overflowTags[this._tagsCount++] = tag;
    }
    else
    {
      switch (this._tagsCount)
      {
        case 0:
          this.Tag1 = tag;
          break;
        case 1:
          this.Tag2 = tag;
          break;
        case 2:
          this.Tag3 = tag;
          break;
        case 3:
          this.Tag4 = tag;
          break;
        case 4:
          this.Tag5 = tag;
          break;
        case 5:
          this.Tag6 = tag;
          break;
        case 6:
          this.Tag7 = tag;
          break;
        case 7:
          this.Tag8 = tag;
          break;
        case 8:
          this.MoveTagsToTheArray();
          this._overflowTags[8] = tag;
          break;
        default:
          return;
      }
      ++this._tagsCount;
    }
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
  public void CopyTo([Nullable(new byte[] {0, 0, 1, 2})] Span<KeyValuePair<string, object>> tags)
  {
    if (tags.Length < this._tagsCount)
      throw new ArgumentException(System.System.Diagnostics.DiagnosticSource3462135.SR.Arg_BufferTooSmall);
    if (this._overflowTags != null)
    {
      Span<KeyValuePair<string, object>> span = this._overflowTags.AsSpan<KeyValuePair<string, object>>();
      span = span.Slice(0, this._tagsCount);
      span.CopyTo(tags);
    }
    else
    {
      switch (this._tagsCount)
      {
        case 1:
          tags[0] = this.Tag1;
          break;
        case 2:
          tags[1] = this.Tag2;
          goto case 1;
        case 3:
          tags[2] = this.Tag3;
          goto case 2;
        case 4:
          tags[3] = this.Tag4;
          goto case 3;
        case 5:
          tags[4] = this.Tag5;
          goto case 4;
        case 6:
          tags[5] = this.Tag6;
          goto case 5;
        case 7:
          tags[6] = this.Tag7;
          goto case 6;
        case 8:
          tags[7] = this.Tag8;
          goto case 7;
      }
    }
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
  public void CopyTo([Nullable(new byte[] {1, 0, 1, 2})] KeyValuePair<string, object>[] array, int arrayIndex)
  {
    if (array == null)
      throw new ArgumentNullException(nameof (array));
    if ((long) (uint) arrayIndex >= (long) array.Length)
      throw new ArgumentOutOfRangeException(nameof (arrayIndex));
    this.CopyTo(array.AsSpan<KeyValuePair<string, object>>().Slice(arrayIndex));
  }

  public void Insert(int index, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    if ((uint) index > (uint) this._tagsCount)
      throw new ArgumentOutOfRangeException(nameof (index));
    if (index == this._tagsCount)
    {
      this.Add(item);
    }
    else
    {
      if (this._tagsCount == 8 && this._overflowTags == null)
        this.MoveTagsToTheArray();
      if (this._overflowTags != null)
      {
        if (this._tagsCount == this._overflowTags.Length)
          Array.Resize<KeyValuePair<string, object>>(ref this._overflowTags, this._tagsCount + 8);
        for (int tagsCount = this._tagsCount; tagsCount > index; --tagsCount)
          this._overflowTags[tagsCount] = this._overflowTags[tagsCount - 1];
        this._overflowTags[index] = item;
        ++this._tagsCount;
      }
      else
      {
        switch (index)
        {
          case 0:
            this.Tag8 = this.Tag7;
            this.Tag7 = this.Tag6;
            this.Tag6 = this.Tag5;
            this.Tag5 = this.Tag4;
            this.Tag4 = this.Tag3;
            this.Tag3 = this.Tag2;
            this.Tag2 = this.Tag1;
            this.Tag1 = item;
            break;
          case 1:
            this.Tag8 = this.Tag7;
            this.Tag7 = this.Tag6;
            this.Tag6 = this.Tag5;
            this.Tag5 = this.Tag4;
            this.Tag4 = this.Tag3;
            this.Tag3 = this.Tag2;
            this.Tag2 = item;
            break;
          case 2:
            this.Tag8 = this.Tag7;
            this.Tag7 = this.Tag6;
            this.Tag6 = this.Tag5;
            this.Tag5 = this.Tag4;
            this.Tag4 = this.Tag3;
            this.Tag3 = item;
            break;
          case 3:
            this.Tag8 = this.Tag7;
            this.Tag7 = this.Tag6;
            this.Tag6 = this.Tag5;
            this.Tag5 = this.Tag4;
            this.Tag4 = item;
            break;
          case 4:
            this.Tag8 = this.Tag7;
            this.Tag7 = this.Tag6;
            this.Tag6 = this.Tag5;
            this.Tag5 = item;
            break;
          case 5:
            this.Tag8 = this.Tag7;
            this.Tag7 = this.Tag6;
            this.Tag6 = item;
            break;
          case 6:
            this.Tag8 = this.Tag7;
            this.Tag7 = item;
            break;
          default:
            return;
        }
        ++this._tagsCount;
      }
    }
  }

  public void RemoveAt(int index)
  {
    if ((uint) index >= (uint) this._tagsCount)
      throw new ArgumentOutOfRangeException(nameof (index));
    if (this._overflowTags != null)
    {
      for (int index1 = index; index1 < this._tagsCount - 1; ++index1)
        this._overflowTags[index1] = this._overflowTags[index1 + 1];
      --this._tagsCount;
    }
    else
    {
      switch (index)
      {
        case 0:
          this.Tag1 = this.Tag2;
          goto case 1;
        case 1:
          this.Tag2 = this.Tag3;
          goto case 2;
        case 2:
          this.Tag3 = this.Tag4;
          goto case 3;
        case 3:
          this.Tag4 = this.Tag5;
          goto case 4;
        case 4:
          this.Tag5 = this.Tag6;
          goto case 5;
        case 5:
          this.Tag6 = this.Tag7;
          goto case 6;
        case 6:
          this.Tag7 = this.Tag8;
          break;
      }
      --this._tagsCount;
    }
  }

  public void Clear() => this._tagsCount = 0;

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
  public bool Contains([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    return this.IndexOf(item) >= 0;
  }

  public bool Remove([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    int index = this.IndexOf(item);
    if (index < 0)
      return false;
    this.RemoveAt(index);
    return true;
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
  [return: Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
  {
    return (IEnumerator<KeyValuePair<string, object>>) new TagList.Enumerator(ref this);
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new TagList.Enumerator(ref this);

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
  public int IndexOf([Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> item)
  {
    if (this._overflowTags != null)
    {
      for (int index = 0; index < this._tagsCount; ++index)
      {
        if (TagList.TagsEqual(this._overflowTags[index], item))
          return index;
      }
      return -1;
    }
    switch (this._tagsCount)
    {
      case 1:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        break;
      case 2:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        break;
      case 3:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        if (TagList.TagsEqual(this.Tag3, item))
          return 2;
        break;
      case 4:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        if (TagList.TagsEqual(this.Tag3, item))
          return 2;
        if (TagList.TagsEqual(this.Tag4, item))
          return 3;
        break;
      case 5:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        if (TagList.TagsEqual(this.Tag3, item))
          return 2;
        if (TagList.TagsEqual(this.Tag4, item))
          return 3;
        if (TagList.TagsEqual(this.Tag5, item))
          return 4;
        break;
      case 6:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        if (TagList.TagsEqual(this.Tag3, item))
          return 2;
        if (TagList.TagsEqual(this.Tag4, item))
          return 3;
        if (TagList.TagsEqual(this.Tag5, item))
          return 4;
        if (TagList.TagsEqual(this.Tag6, item))
          return 5;
        break;
      case 7:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        if (TagList.TagsEqual(this.Tag3, item))
          return 2;
        if (TagList.TagsEqual(this.Tag4, item))
          return 3;
        if (TagList.TagsEqual(this.Tag5, item))
          return 4;
        if (TagList.TagsEqual(this.Tag6, item))
          return 5;
        if (TagList.TagsEqual(this.Tag7, item))
          return 6;
        break;
      case 8:
        if (TagList.TagsEqual(this.Tag1, item))
          return 0;
        if (TagList.TagsEqual(this.Tag2, item))
          return 1;
        if (TagList.TagsEqual(this.Tag3, item))
          return 2;
        if (TagList.TagsEqual(this.Tag4, item))
          return 3;
        if (TagList.TagsEqual(this.Tag5, item))
          return 4;
        if (TagList.TagsEqual(this.Tag6, item))
          return 5;
        if (TagList.TagsEqual(this.Tag7, item))
          return 6;
        if (TagList.TagsEqual(this.Tag8, item))
          return 7;
        break;
    }
    return -1;
  }

  [Nullable(new byte[] {2, 0, 1, 2})]
  internal KeyValuePair<string, object>[] Tags
  {
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly] get
    {
      return this._overflowTags;
    }
  }

  private static bool TagsEqual(
    KeyValuePair<string, object> tag1,
    KeyValuePair<string, object> tag2)
  {
    if (tag1.Key != tag2.Key)
      return false;
    if (tag1.Value == null)
    {
      if (tag2.Value != null)
        return false;
    }
    else if (!tag1.Value.Equals(tag2.Value))
      return false;
    return true;
  }

  private void MoveTagsToTheArray()
  {
    this._overflowTags = new KeyValuePair<string, object>[16 /*0x10*/];
    this._overflowTags[0] = this.Tag1;
    this._overflowTags[1] = this.Tag2;
    this._overflowTags[2] = this.Tag3;
    this._overflowTags[3] = this.Tag4;
    this._overflowTags[4] = this.Tag5;
    this._overflowTags[5] = this.Tag6;
    this._overflowTags[6] = this.Tag7;
    this._overflowTags[7] = this.Tag8;
  }

  public struct Enumerator : IEnumerator<KeyValuePair<string, object>>, IDisposable, IEnumerator
  {
    private TagList _tagList;
    private int _index;

    internal Enumerator([System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly, In] ref TagList tagList)
    {
      this._index = -1;
      this._tagList = tagList;
    }

    [Nullable(new byte[] {0, 1, 2})]
    public KeyValuePair<string, object> Current
    {
      [return: Nullable(new byte[] {0, 1, 2})] get => this._tagList[this._index];
    }

    [Nullable(1)]
    object IEnumerator.Current => (object) this._tagList[this._index];

    public void Dispose() => this._index = this._tagList.Count;

    public bool MoveNext()
    {
      ++this._index;
      return this._index < this._tagList.Count;
    }

    public void Reset() => this._index = -1;
  }
}
