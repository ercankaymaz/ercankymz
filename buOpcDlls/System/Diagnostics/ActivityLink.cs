// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityLink
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis.System.Diagnostics.DiagnosticSource3462135;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[IsReadOnly]
[ComVisible(true)]
[method: NullableContext(2)]
public struct ActivityLink(ActivityContext context, ActivityTagsCollection tags = null) : 
  IEquatable<ActivityLink>
{
  public ActivityContext Context { get; } = context;

  [Nullable(new byte[] {2, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, object>> Tags { [return: Nullable(new byte[] {2, 0, 1, 2})] get; } = (IEnumerable<KeyValuePair<string, object>>) tags;

  [NullableContext(2)]
  public override bool Equals([NotNullWhen(true)] object obj)
  {
    return obj is ActivityLink activityLink && this.Equals(activityLink);
  }

  public bool Equals(ActivityLink value)
  {
    return this.Context == value.Context && value.Tags == this.Tags;
  }

  public static bool operator ==(ActivityLink left, ActivityLink right) => left.Equals(right);

  public static bool operator !=(ActivityLink left, ActivityLink right) => !left.Equals(right);

  public override int GetHashCode()
  {
    if (this == new ActivityLink())
      return 0;
    int hashCode = 177573 + this.Context.GetHashCode();
    if (this.Tags != null)
    {
      foreach (KeyValuePair<string, object> tag in this.Tags)
      {
        hashCode = (hashCode << 5) + hashCode + tag.Key.GetHashCode();
        if (tag.Value != null)
          hashCode = (hashCode << 5) + hashCode + tag.Value.GetHashCode();
      }
    }
    return hashCode;
  }
}
