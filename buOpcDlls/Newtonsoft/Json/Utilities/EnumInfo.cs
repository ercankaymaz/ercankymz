// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.EnumInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(1)]
[Nullable(0)]
internal class EnumInfo
{
  public readonly bool IsFlags;
  public readonly ulong[] Values;
  public readonly string[] Names;
  public readonly string[] ResolvedNames;

  public EnumInfo(bool isFlags, ulong[] values, string[] names, string[] resolvedNames)
  {
    this.IsFlags = isFlags;
    this.Values = values;
    this.Names = names;
    this.ResolvedNames = resolvedNames;
  }
}
