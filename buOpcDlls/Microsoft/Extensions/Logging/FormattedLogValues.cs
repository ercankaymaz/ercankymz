// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.FormattedLogValues
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Threading;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(2)]
[Nullable(0)]
internal readonly struct FormattedLogValues : 
  IReadOnlyList<KeyValuePair<string, object>>,
  IReadOnlyCollection<KeyValuePair<string, object>>,
  IEnumerable<KeyValuePair<string, object>>,
  IEnumerable
{
  internal const int MaxCachedFormatters = 1024 /*0x0400*/;
  private const string NullFormat = "[null]";
  private static int _count;
  private static ConcurrentDictionary<string, LogValuesFormatter> _formatters = new ConcurrentDictionary<string, LogValuesFormatter>();
  private readonly LogValuesFormatter _formatter;
  private readonly object[] _values;
  private readonly string _originalMessage;

  internal LogValuesFormatter Formatter => this._formatter;

  public FormattedLogValues(string format, params object[] values)
  {
    if (values != null && values.Length != 0 && format != null)
    {
      if (FormattedLogValues._count >= 1024 /*0x0400*/)
      {
        if (!FormattedLogValues._formatters.TryGetValue(format, out this._formatter))
          this._formatter = new LogValuesFormatter(format);
      }
      else
        this._formatter = FormattedLogValues._formatters.GetOrAdd(format, (Func<string, LogValuesFormatter>) (f =>
        {
          Interlocked.Increment(ref FormattedLogValues._count);
          return new LogValuesFormatter(f);
        }));
    }
    else
      this._formatter = (LogValuesFormatter) null;
    this._originalMessage = format ?? "[null]";
    this._values = values;
  }

  [Nullable(new byte[] {0, 1, 2})]
  public KeyValuePair<string, object> this[int index]
  {
    [return: Nullable(new byte[] {0, 1, 2})] get
    {
      if (index < 0 || index >= this.Count)
        throw new IndexOutOfRangeException(nameof (index));
      return index == this.Count - 1 ? new KeyValuePair<string, object>("{OriginalFormat}", (object) this._originalMessage) : this._formatter.GetValue(this._values, index);
    }
  }

  public int Count => this._formatter == null ? 1 : this._formatter.ValueNames.Count + 1;

  [return: Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
  {
    for (int i = 0; i < this.Count; ++i)
      yield return this[i];
  }

  [NullableContext(1)]
  public override string ToString()
  {
    return this._formatter == null ? this._originalMessage : this._formatter.Format(this._values);
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
