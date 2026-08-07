// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.LabelInstructionInterpretter`2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[SecurityCritical]
internal class LabelInstructionInterpretter<TObjectSequence, TAggregator>
  where TObjectSequence : struct, IObjectSequence, IEquatable<TObjectSequence>
  where TAggregator : Aggregator
{
  private int _expectedLabelCount;
  private LabelInstruction[] _instructions;
  private ConcurrentDictionary<TObjectSequence, TAggregator> _valuesDict;
  private Func<TObjectSequence, TAggregator> _createAggregator;

  public LabelInstructionInterpretter(
    int expectedLabelCount,
    LabelInstruction[] instructions,
    ConcurrentDictionary<TObjectSequence, TAggregator> valuesDict,
    Func<TAggregator> createAggregator)
  {
    this._expectedLabelCount = expectedLabelCount;
    this._instructions = instructions;
    this._valuesDict = valuesDict;
    this._createAggregator = (Func<TObjectSequence, TAggregator>) (_ => createAggregator());
  }

  public bool GetAggregator(
    ReadOnlySpan<KeyValuePair<string, object>> labels,
    out TAggregator aggregator)
  {
    aggregator = default (TAggregator);
    if (labels.Length != this._expectedLabelCount)
      return false;
    TObjectSequence key1 = default (TObjectSequence);
    if ((ValueType) key1 is ObjectSequenceMany)
      key1 = (TObjectSequence) (ValueType) new ObjectSequenceMany(new object[this._expectedLabelCount]);
    ref TObjectSequence local1 = ref key1;
    for (int index = 0; index < this._instructions.Length; ++index)
    {
      LabelInstruction instruction = this._instructions[index];
      string labelName = instruction.LabelName;
      KeyValuePair<string, object> keyValuePair = labels[instruction.SourceIndex];
      string key2 = keyValuePair.Key;
      if (labelName != key2)
        return false;
      ref TObjectSequence local2 = ref local1;
      int i = index;
      keyValuePair = labels[instruction.SourceIndex];
      object obj = keyValuePair.Value;
      local2[i] = obj;
    }
    if (!this._valuesDict.TryGetValue(key1, out aggregator))
    {
      aggregator = this._createAggregator(key1);
      if ((object) aggregator == null)
        return true;
      aggregator = this._valuesDict.GetOrAdd(key1, aggregator);
    }
    return true;
  }
}
