// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.LabelInstructionCompiler
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[SecurityCritical]
internal static class LabelInstructionCompiler
{
  public static AggregatorLookupFunc<TAggregator> Create<TAggregator>(
    ref AggregatorStore<TAggregator> aggregatorStore,
    Func<TAggregator> createAggregatorFunc,
    ReadOnlySpan<KeyValuePair<string, object>> labels)
    where TAggregator : Aggregator
  {
    LabelInstruction[] labelInstructionArray = LabelInstructionCompiler.Compile(labels);
    Array.Sort<LabelInstruction>(labelInstructionArray, (Comparison<LabelInstruction>) ((a, b) => string.CompareOrdinal(a.LabelName, b.LabelName)));
    int expectedLabels = labels.Length;
    switch (labelInstructionArray.Length)
    {
      case 0:
        TAggregator defaultAggregator = aggregatorStore.GetAggregator();
        return (AggregatorLookupFunc<TAggregator>) ((ReadOnlySpan<KeyValuePair<string, object>> l, out TAggregator aggregator) =>
        {
          if (l.Length != expectedLabels)
          {
            aggregator = default (TAggregator);
            return false;
          }
          aggregator = defaultAggregator;
          return true;
        });
      case 1:
        StringSequence1 names1 = new StringSequence1(labelInstructionArray[0].LabelName);
        ConcurrentDictionary<ObjectSequence1, TAggregator> valuesDictionary1 = aggregatorStore.GetLabelValuesDictionary<StringSequence1, ObjectSequence1>(ref names1);
        return new AggregatorLookupFunc<TAggregator>(new LabelInstructionInterpretter<ObjectSequence1, TAggregator>(expectedLabels, labelInstructionArray, valuesDictionary1, createAggregatorFunc).GetAggregator);
      case 2:
        StringSequence2 names2 = new StringSequence2(labelInstructionArray[0].LabelName, labelInstructionArray[1].LabelName);
        ConcurrentDictionary<ObjectSequence2, TAggregator> valuesDictionary2 = aggregatorStore.GetLabelValuesDictionary<StringSequence2, ObjectSequence2>(ref names2);
        return new AggregatorLookupFunc<TAggregator>(new LabelInstructionInterpretter<ObjectSequence2, TAggregator>(expectedLabels, labelInstructionArray, valuesDictionary2, createAggregatorFunc).GetAggregator);
      case 3:
        StringSequence3 names3 = new StringSequence3(labelInstructionArray[0].LabelName, labelInstructionArray[1].LabelName, labelInstructionArray[2].LabelName);
        ConcurrentDictionary<ObjectSequence3, TAggregator> valuesDictionary3 = aggregatorStore.GetLabelValuesDictionary<StringSequence3, ObjectSequence3>(ref names3);
        return new AggregatorLookupFunc<TAggregator>(new LabelInstructionInterpretter<ObjectSequence3, TAggregator>(expectedLabels, labelInstructionArray, valuesDictionary3, createAggregatorFunc).GetAggregator);
      default:
        string[] values = new string[labelInstructionArray.Length];
        for (int index = 0; index < labelInstructionArray.Length; ++index)
          values[index] = labelInstructionArray[index].LabelName;
        StringSequenceMany names4 = new StringSequenceMany(values);
        ConcurrentDictionary<ObjectSequenceMany, TAggregator> valuesDictionary4 = aggregatorStore.GetLabelValuesDictionary<StringSequenceMany, ObjectSequenceMany>(ref names4);
        return new AggregatorLookupFunc<TAggregator>(new LabelInstructionInterpretter<ObjectSequenceMany, TAggregator>(expectedLabels, labelInstructionArray, valuesDictionary4, createAggregatorFunc).GetAggregator);
    }
  }

  private static LabelInstruction[] Compile(ReadOnlySpan<KeyValuePair<string, object>> labels)
  {
    LabelInstruction[] labelInstructionArray = new LabelInstruction[labels.Length];
    for (int index = 0; index < labels.Length; ++index)
      labelInstructionArray[index] = new LabelInstruction(index, labels[index].Key);
    return labelInstructionArray;
  }
}
