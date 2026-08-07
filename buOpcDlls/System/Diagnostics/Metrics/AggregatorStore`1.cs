// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.AggregatorStore`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

#nullable disable
namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
internal struct AggregatorStore<TAggregator>(Func<TAggregator> createAggregator) where TAggregator : Aggregator
{
  private volatile object _stateUnion = (object) null;
  private volatile AggregatorLookupFunc<TAggregator> _cachedLookupFunc = (AggregatorLookupFunc<TAggregator>) null;
  private readonly Func<TAggregator> _createAggregatorFunc = createAggregator;

  public TAggregator GetAggregator(ReadOnlySpan<KeyValuePair<string, object>> labels)
  {
    AggregatorLookupFunc<TAggregator> cachedLookupFunc = this._cachedLookupFunc;
    TAggregator aggregator;
    return cachedLookupFunc != null && cachedLookupFunc(labels, out aggregator) ? aggregator : this.GetAggregatorSlow(labels);
  }

  private TAggregator GetAggregatorSlow(ReadOnlySpan<KeyValuePair<string, object>> labels)
  {
    AggregatorLookupFunc<TAggregator> aggregatorLookupFunc = LabelInstructionCompiler.Create<TAggregator>(ref this, this._createAggregatorFunc, labels);
    this._cachedLookupFunc = aggregatorLookupFunc;
    TAggregator aggregator;
    int num = aggregatorLookupFunc(labels, out aggregator) ? 1 : 0;
    return aggregator;
  }

  public void Collect(Action<LabeledAggregationStatistics> visitFunc)
  {
    switch (this._stateUnion)
    {
      case TAggregator aggregator:
        IAggregationStatistics stats = aggregator.Collect();
        visitFunc(new LabeledAggregationStatistics(stats, Array.Empty<KeyValuePair<string, string>>()));
        break;
      case FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator> labelNameDictionary1:
        labelNameDictionary1.Collect(visitFunc);
        break;
      case FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator> labelNameDictionary2:
        labelNameDictionary2.Collect(visitFunc);
        break;
      case FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator> labelNameDictionary3:
        labelNameDictionary3.Collect(visitFunc);
        break;
      case FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator> labelNameDictionary4:
        labelNameDictionary4.Collect(visitFunc);
        break;
      case MultiSizeLabelNameDictionary<TAggregator> labelNameDictionary5:
        labelNameDictionary5.Collect(visitFunc);
        break;
    }
  }

  public TAggregator GetAggregator()
  {
    MultiSizeLabelNameDictionary<TAggregator> labelNameDictionary1;
    TAggregator aggregator1;
    do
    {
      object stateUnion = this._stateUnion;
      switch (stateUnion)
      {
        case null:
          aggregator1 = this._createAggregatorFunc();
          continue;
        case TAggregator aggregator2:
          goto label_4;
        case MultiSizeLabelNameDictionary<TAggregator> labelNameDictionary2:
          goto label_5;
        default:
          labelNameDictionary1 = new MultiSizeLabelNameDictionary<TAggregator>(stateUnion);
          if (Interlocked.CompareExchange(ref this._stateUnion, (object) labelNameDictionary1, stateUnion) != stateUnion)
            continue;
          goto label_6;
      }
    }
    while ((object) aggregator1 != null && Interlocked.CompareExchange(ref this._stateUnion, (object) aggregator1, (object) null) != null);
    return aggregator1;
label_4:
    return aggregator2;
label_5:
    return labelNameDictionary2.GetNoLabelAggregator(this._createAggregatorFunc);
label_6:
    return labelNameDictionary1.GetNoLabelAggregator(this._createAggregatorFunc);
  }

  public ConcurrentDictionary<TObjectSequence, TAggregator> GetLabelValuesDictionary<TStringSequence, TObjectSequence>(
    [IsReadOnly, In] ref TStringSequence names)
    where TStringSequence : object, IStringSequence, IEquatable<TStringSequence>
    where TObjectSequence : object, IObjectSequence, IEquatable<TObjectSequence>
  {
    MultiSizeLabelNameDictionary<TAggregator> labelNameDictionary1;
    FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator> labelNameDictionary2;
    do
    {
      object stateUnion = this._stateUnion;
      switch (stateUnion)
      {
        case null:
          labelNameDictionary2 = new FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator>();
          continue;
        case FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator> labelNameDictionary3:
          goto label_4;
        case MultiSizeLabelNameDictionary<TAggregator> labelNameDictionary4:
          goto label_5;
        default:
          labelNameDictionary1 = new MultiSizeLabelNameDictionary<TAggregator>(stateUnion);
          if (Interlocked.CompareExchange(ref this._stateUnion, (object) labelNameDictionary1, stateUnion) != stateUnion)
            continue;
          goto label_6;
      }
    }
    while (Interlocked.CompareExchange(ref this._stateUnion, (object) labelNameDictionary2, (object) null) != null);
    return labelNameDictionary2.GetValuesDictionary(ref names);
label_4:
    return labelNameDictionary3.GetValuesDictionary(ref names);
label_5:
    return labelNameDictionary4.GetFixedSizeLabelNameDictionary<TStringSequence, TObjectSequence>().GetValuesDictionary(ref names);
label_6:
    return labelNameDictionary1.GetFixedSizeLabelNameDictionary<TStringSequence, TObjectSequence>().GetValuesDictionary(ref names);
  }
}
