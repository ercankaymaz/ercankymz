// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.DistributedContextPropagator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace System.Diagnostics;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public abstract class DistributedContextPropagator
{
  private static DistributedContextPropagator s_current = DistributedContextPropagator.CreateDefaultPropagator();
  internal const string TraceParent = "traceparent";
  internal const string RequestId = "Request-Id";
  internal const string TraceState = "tracestate";
  internal const string Baggage = "baggage";
  internal const string CorrelationContext = "Correlation-Context";
  internal const char Space = ' ';
  internal const char Tab = '\t';
  internal const char Comma = ',';
  internal const char Semicolon = ';';
  internal const string CommaWithSpace = ", ";
  internal static readonly char[] s_trimmingSpaceCharacters = new char[2]
  {
    ' ',
    '\t'
  };

  public abstract IReadOnlyCollection<string> Fields { get; }

  [NullableContext(2)]
  public abstract void Inject(
    Activity activity,
    object carrier,
    DistributedContextPropagator.PropagatorSetterCallback setter);

  [NullableContext(2)]
  public abstract void ExtractTraceIdAndState(
    object carrier,
    DistributedContextPropagator.PropagatorGetterCallback getter,
    out string traceId,
    out string traceState);

  [NullableContext(2)]
  [return: Nullable(new byte[] {2, 0, 1, 2})]
  public abstract IEnumerable<KeyValuePair<string, string>> ExtractBaggage(
    object carrier,
    DistributedContextPropagator.PropagatorGetterCallback getter);

  public static DistributedContextPropagator Current
  {
    get => DistributedContextPropagator.s_current;
    set
    {
      DistributedContextPropagator.s_current = value ?? throw new ArgumentNullException(nameof (value));
    }
  }

  public static DistributedContextPropagator CreateDefaultPropagator() => LegacyPropagator.Instance;

  public static DistributedContextPropagator CreatePassThroughPropagator()
  {
    return PassThroughPropagator.Instance;
  }

  public static DistributedContextPropagator CreateNoOutputPropagator()
  {
    return NoOutputPropagator.Instance;
  }

  internal static void InjectBaggage(
    object carrier,
    IEnumerable<KeyValuePair<string, string>> baggage,
    DistributedContextPropagator.PropagatorSetterCallback setter)
  {
    using (IEnumerator<KeyValuePair<string, string>> enumerator = baggage.GetEnumerator())
    {
      if (!enumerator.MoveNext())
        return;
      StringBuilder stringBuilder = new StringBuilder();
      do
      {
        KeyValuePair<string, string> current = enumerator.Current;
        stringBuilder.Append(WebUtility.UrlEncode(current.Key)).Append('=').Append(WebUtility.UrlEncode(current.Value)).Append(", ");
      }
      while (enumerator.MoveNext());
      setter(carrier, "Correlation-Context", stringBuilder.ToString(0, stringBuilder.Length - 2));
    }
  }

  [NullableContext(0)]
  public delegate void PropagatorGetterCallback(
    object carrier,
    [Nullable(1)] string fieldName,
    out string fieldValue,
    [Nullable(new byte[] {2, 1})] out IEnumerable<string> fieldValues);

  [NullableContext(0)]
  public delegate void PropagatorSetterCallback(
    [Nullable(2)] object carrier,
    string fieldName,
    string fieldValue);
}
