// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityEvent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[NullableContext(1)]
[Nullable(0)]
[IsReadOnly]
[ComVisible(true)]
public struct ActivityEvent(string name, DateTimeOffset timestamp = default (DateTimeOffset), [Nullable(2)] ActivityTagsCollection tags = null)
{
  private static readonly ActivityTagsCollection s_emptyTags = new ActivityTagsCollection();

  public ActivityEvent(string name)
    : this(name, DateTimeOffset.UtcNow, ActivityEvent.s_emptyTags)
  {
  }

  public string Name { get; } = name ?? string.Empty;

  public DateTimeOffset Timestamp { get; } = timestamp != new DateTimeOffset() ? timestamp : DateTimeOffset.UtcNow;

  [Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, object>> Tags { [return: Nullable(new byte[] {1, 0, 1, 2})] get; } = (IEnumerable<KeyValuePair<string, object>>) (tags ?? ActivityEvent.s_emptyTags);
}
