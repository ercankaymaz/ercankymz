// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.MultiSizeLabelNameDictionary`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Threading;

#nullable disable
namespace System.Diagnostics.Metrics;

internal class MultiSizeLabelNameDictionary<TAggregator> where TAggregator : Aggregator
{
  private TAggregator NoLabelAggregator;
  private FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator> Label1;
  private FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator> Label2;
  private FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator> Label3;
  private FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator> LabelMany;

  public MultiSizeLabelNameDictionary(object initialLabelNameDict)
  {
    this.NoLabelAggregator = default (TAggregator);
    this.Label1 = (FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator>) null;
    this.Label2 = (FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator>) null;
    this.Label3 = (FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator>) null;
    this.LabelMany = (FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator>) null;
    switch (initialLabelNameDict)
    {
      case TAggregator aggregator:
        this.NoLabelAggregator = aggregator;
        break;
      case FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator> labelNameDictionary1:
        this.Label1 = labelNameDictionary1;
        break;
      case FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator> labelNameDictionary2:
        this.Label2 = labelNameDictionary2;
        break;
      case FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator> labelNameDictionary3:
        this.Label3 = labelNameDictionary3;
        break;
      case FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator> labelNameDictionary4:
        this.LabelMany = labelNameDictionary4;
        break;
    }
  }

  public TAggregator GetNoLabelAggregator(Func<TAggregator> createFunc)
  {
    if ((object) this.NoLabelAggregator == null)
    {
      TAggregator aggregator = createFunc();
      if ((object) aggregator != null)
        Interlocked.CompareExchange<TAggregator>(ref this.NoLabelAggregator, aggregator, default (TAggregator));
    }
    return this.NoLabelAggregator;
  }

  public FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator> GetFixedSizeLabelNameDictionary<TStringSequence, TObjectSequence>()
    where TStringSequence : object, IStringSequence, IEquatable<TStringSequence>
    where TObjectSequence : object, IObjectSequence, IEquatable<TObjectSequence>
  {
    TStringSequence stringSequence = default (TStringSequence);
    if (!((object) stringSequence is StringSequence1))
    {
      if (!((object) stringSequence is StringSequence2))
      {
        if (!((object) stringSequence is StringSequence3))
        {
          if (!((object) stringSequence is StringSequenceMany))
            return (FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator>) null;
          if (this.LabelMany == null)
            Interlocked.CompareExchange<FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator>>(ref this.LabelMany, new FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator>(), (FixedSizeLabelNameDictionary<StringSequenceMany, ObjectSequenceMany, TAggregator>) null);
          return (FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator>) this.LabelMany;
        }
        if (this.Label3 == null)
          Interlocked.CompareExchange<FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator>>(ref this.Label3, new FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator>(), (FixedSizeLabelNameDictionary<StringSequence3, ObjectSequence3, TAggregator>) null);
        return (FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator>) this.Label3;
      }
      if (this.Label2 == null)
        Interlocked.CompareExchange<FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator>>(ref this.Label2, new FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator>(), (FixedSizeLabelNameDictionary<StringSequence2, ObjectSequence2, TAggregator>) null);
      return (FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator>) this.Label2;
    }
    if (this.Label1 == null)
      Interlocked.CompareExchange<FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator>>(ref this.Label1, new FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator>(), (FixedSizeLabelNameDictionary<StringSequence1, ObjectSequence1, TAggregator>) null);
    return (FixedSizeLabelNameDictionary<TStringSequence, TObjectSequence, TAggregator>) this.Label1;
  }

  public void Collect(Action<LabeledAggregationStatistics> visitFunc)
  {
    if ((object) this.NoLabelAggregator != null)
    {
      IAggregationStatistics stats = this.NoLabelAggregator.Collect();
      visitFunc(new LabeledAggregationStatistics(stats, Array.Empty<KeyValuePair<string, string>>()));
    }
    this.Label1?.Collect(visitFunc);
    this.Label2?.Collect(visitFunc);
    this.Label3?.Collect(visitFunc);
    this.LabelMany?.Collect(visitFunc);
  }
}
