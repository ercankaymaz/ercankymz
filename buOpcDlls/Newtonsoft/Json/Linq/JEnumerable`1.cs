// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JEnumerable`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq;

[NullableContext(1)]
[Nullable(0)]
[IsReadOnly]
public struct JEnumerable<[Nullable(0)] T> : 
  IJEnumerable<T>,
  IEnumerable<T>,
  IEnumerable,
  IEquatable<JEnumerable<T>>
  where T : JToken
{
  [Nullable(new byte[] {0, 1})]
  public static readonly JEnumerable<T> Empty = new JEnumerable<T>(Enumerable.Empty<T>());
  private readonly IEnumerable<T> _enumerable;

  public JEnumerable(IEnumerable<T> enumerable)
  {
    ValidationUtils.ArgumentNotNull((object) enumerable, nameof (enumerable));
    this._enumerable = enumerable;
  }

  public IEnumerator<T> GetEnumerator()
  {
    return ((IEnumerable<T>) ((object) this._enumerable ?? (object) JEnumerable<T>.Empty)).GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public IJEnumerable<JToken> this[object key]
  {
    get
    {
      return this._enumerable == null ? (IJEnumerable<JToken>) JEnumerable<JToken>.Empty : (IJEnumerable<JToken>) new JEnumerable<JToken>(this._enumerable.Values<T, JToken>(key));
    }
  }

  public bool Equals([Nullable(new byte[] {0, 1})] JEnumerable<T> other)
  {
    return object.Equals((object) this._enumerable, (object) other._enumerable);
  }

  [NullableContext(2)]
  public override bool Equals(object obj) => obj is JEnumerable<T> other && this.Equals(other);

  public override int GetHashCode()
  {
    return this._enumerable == null ? 0 : this._enumerable.GetHashCode();
  }
}
