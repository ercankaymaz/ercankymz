// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.LegacyPropagator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

#nullable disable
namespace System.Diagnostics;

internal sealed class LegacyPropagator : DistributedContextPropagator
{
  internal static DistributedContextPropagator Instance { get; } = (DistributedContextPropagator) new LegacyPropagator();

  public override IReadOnlyCollection<string> Fields { get; } = (IReadOnlyCollection<string>) new ReadOnlyCollection<string>((IList<string>) new string[5]
  {
    "traceparent",
    "Request-Id",
    "tracestate",
    "baggage",
    "Correlation-Context"
  });

  public override void Inject(
    Activity activity,
    object carrier,
    DistributedContextPropagator.PropagatorSetterCallback setter)
  {
    if (activity == null || setter == null)
      return;
    string id = activity.Id;
    if (id == null)
      return;
    if (activity.IdFormat == ActivityIdFormat.W3C)
    {
      setter(carrier, "traceparent", id);
      if (!string.IsNullOrEmpty(activity.TraceStateString))
        setter(carrier, "tracestate", activity.TraceStateString);
    }
    else
      setter(carrier, "Request-Id", id);
    DistributedContextPropagator.InjectBaggage(carrier, activity.Baggage, setter);
  }

  public override void ExtractTraceIdAndState(
    object carrier,
    DistributedContextPropagator.PropagatorGetterCallback getter,
    out string traceId,
    out string traceState)
  {
    if (getter == null)
    {
      traceId = (string) null;
      traceState = (string) null;
    }
    else
    {
      IEnumerable<string> fieldValues;
      getter(carrier, "traceparent", out traceId, out fieldValues);
      if (traceId == null)
        getter(carrier, "Request-Id", out traceId, out fieldValues);
      getter(carrier, "tracestate", out traceState, out fieldValues);
    }
  }

  public override IEnumerable<KeyValuePair<string, string>> ExtractBaggage(
    object carrier,
    DistributedContextPropagator.PropagatorGetterCallback getter)
  {
    if (getter == null)
      return (IEnumerable<KeyValuePair<string, string>>) null;
    string fieldValue;
    IEnumerable<string> fieldValues;
    getter(carrier, "baggage", out fieldValue, out fieldValues);
    IEnumerable<KeyValuePair<string, string>> baggage = (IEnumerable<KeyValuePair<string, string>>) null;
    if (fieldValue == null || !LegacyPropagator.TryExtractBaggage(fieldValue, out baggage))
    {
      getter(carrier, "Correlation-Context", out fieldValue, out fieldValues);
      if (fieldValue != null)
        LegacyPropagator.TryExtractBaggage(fieldValue, out baggage);
    }
    return baggage;
  }

  internal static bool TryExtractBaggage(
    string baggageString,
    out IEnumerable<KeyValuePair<string, string>> baggage)
  {
    baggage = (IEnumerable<KeyValuePair<string, string>>) null;
    List<KeyValuePair<string, string>> keyValuePairList = (List<KeyValuePair<string, string>>) null;
    if (string.IsNullOrEmpty(baggageString))
      return true;
    int index1 = 0;
    while (true)
    {
      while (index1 >= baggageString.Length || baggageString[index1] != ' ' && baggageString[index1] != '\t')
      {
        if (index1 < baggageString.Length)
        {
          int startIndex1 = index1;
          while (index1 < baggageString.Length && baggageString[index1] != ' ' && baggageString[index1] != '\t' && baggageString[index1] != '=')
            ++index1;
          if (index1 < baggageString.Length)
          {
            int num = index1;
            if (baggageString[index1] != '=')
            {
              while (index1 < baggageString.Length && (baggageString[index1] == ' ' || baggageString[index1] == '\t'))
                ++index1;
              if (index1 >= baggageString.Length || baggageString[index1] != '=')
                goto label_28;
            }
            int index2 = index1 + 1;
            while (index2 < baggageString.Length && (baggageString[index2] == ' ' || baggageString[index2] == '\t'))
              ++index2;
            if (index2 < baggageString.Length)
            {
              int startIndex2 = index2;
              while (index2 < baggageString.Length && baggageString[index2] != ' ' && baggageString[index2] != '\t' && baggageString[index2] != ',' && baggageString[index2] != ';')
                ++index2;
              if (startIndex1 < num && startIndex2 < index2)
              {
                if (keyValuePairList == null)
                  keyValuePairList = new List<KeyValuePair<string, string>>();
                keyValuePairList.Insert(0, new KeyValuePair<string, string>(WebUtility.UrlDecode(baggageString.Substring(startIndex1, num - startIndex1)).Trim(DistributedContextPropagator.s_trimmingSpaceCharacters), WebUtility.UrlDecode(baggageString.Substring(startIndex2, index2 - startIndex2)).Trim(DistributedContextPropagator.s_trimmingSpaceCharacters)));
              }
              while (index2 < baggageString.Length && baggageString[index2] != ',')
                ++index2;
              index1 = index2 + 1;
              if (index1 < baggageString.Length)
                continue;
            }
          }
        }
label_28:
        baggage = (IEnumerable<KeyValuePair<string, string>>) keyValuePairList;
        return keyValuePairList != null;
      }
      ++index1;
    }
  }
}
