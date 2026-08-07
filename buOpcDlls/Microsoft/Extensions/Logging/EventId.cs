// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.EventId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(2)]
[Nullable(0)]
[ComVisible(true)]
public readonly struct EventId(int id, string name = null)
{
  public static implicit operator EventId(int i) => new EventId(i);

  public static bool operator ==(EventId left, EventId right) => left.Equals(right);

  public static bool operator !=(EventId left, EventId right) => !left.Equals(right);

  public int Id { get; } = id;

  public string Name { get; } = name;

  [NullableContext(1)]
  public override string ToString() => this.Name ?? this.Id.ToString();

  public bool Equals(EventId other) => this.Id == other.Id;

  public override bool Equals([NotNullWhen(true)] object obj)
  {
    return obj != null && obj is EventId other && this.Equals(other);
  }

  public override int GetHashCode() => this.Id;
}
