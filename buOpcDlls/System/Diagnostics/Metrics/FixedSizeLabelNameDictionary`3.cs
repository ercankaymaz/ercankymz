// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.FixedSizeLabelNameDictionary`3
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics.Metrics;

internal class FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator> : 
  ConcurrentDictionary<TStringSequence, ConcurrentDictionary<TObjectSequence, TAggregator>>
  where TStringSequence : object, IStringSequence, IEquatable<TStringSequence>
  where TObjectSequence : object, IObjectSequence, IEquatable<TObjectSequence>
  where TAggregator : Aggregator
{
  public void Collect(Action<LabeledAggregationStatistics> visitFunc)
  {
    foreach (KeyValuePair<TStringSequence, ConcurrentDictionary<TObjectSequence, TAggregator>> keyValuePair1 in (ConcurrentDictionary<TStringSequence, ConcurrentDictionary<TObjectSequence, TAggregator>>) this)
    {
      TStringSequence key1 = keyValuePair1.Key;
      foreach (KeyValuePair<TObjectSequence, TAggregator> keyValuePair2 in keyValuePair1.Value)
      {
        TObjectSequence key2 = keyValuePair2.Key;
        KeyValuePair<string, string>[] keyValuePairArray1 = new KeyValuePair<string, string>[key1.Length];
        for (int i = 0; i < keyValuePairArray1.Length; ++i)
        {
          KeyValuePair<string, string>[] keyValuePairArray2 = keyValuePairArray1;
          int index = i;
          string key3 = key1[i];
          object obj = key2[i];
          string str;
          if (obj == null)
          {
            str = (string) null;
          }
          else
          {
            str = obj.ToString();
            if (str != null)
              goto label_9;
          }
          str = "";
label_9:
          KeyValuePair<string, string> keyValuePair3 = new KeyValuePair<string, string>(key3, str);
          keyValuePairArray2[index] = keyValuePair3;
        }
        IAggregationStatistics stats = keyValuePair2.Value.Collect();
        visitFunc(new LabeledAggregationStatistics(stats, keyValuePairArray1));
      }
    }
  }

  public ConcurrentDictionary<TObjectSequence, TAggregator> GetValuesDictionary(
    [IsReadOnly, In] ref TStringSequence names)
  {
    return this.GetOrAdd(names, (Func<TStringSequence, ConcurrentDictionary<TObjectSequence, TAggregator>>) (_ => new ConcurrentDictionary<TObjectSequence, TAggregator>()));
  }
}
