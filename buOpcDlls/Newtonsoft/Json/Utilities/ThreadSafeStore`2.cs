// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ThreadSafeStore`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class ThreadSafeStore<TKey, [Nullable(2)] TValue>
{
  private readonly ConcurrentDictionary<TKey, TValue> _concurrentStore;
  private readonly Func<TKey, TValue> _creator;

  public ThreadSafeStore(Func<TKey, TValue> creator)
  {
    ValidationUtils.ArgumentNotNull((object) creator, nameof (creator));
    this._creator = creator;
    this._concurrentStore = new ConcurrentDictionary<TKey, TValue>();
  }

  public TValue Get(TKey key) => this._concurrentStore.GetOrAdd(key, this._creator);
}
