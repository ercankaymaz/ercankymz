// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.ReflectionMember
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Utilities;

[NullableContext(2)]
[Nullable(0)]
internal class ReflectionMember
{
  public Type MemberType { get; set; }

  [field: Nullable(new byte[] {2, 1, 2})]
  [Nullable(new byte[] {2, 1, 2})]
  public Func<object, object> Getter { [return: Nullable(new byte[] {2, 1, 2})] get; [param: Nullable(new byte[] {2, 1, 2})] set; }

  [field: Nullable(new byte[] {2, 1, 2})]
  [Nullable(new byte[] {2, 1, 2})]
  public Action<object, object> Setter { [return: Nullable(new byte[] {2, 1, 2})] get; [param: Nullable(new byte[] {2, 1, 2})] set; }
}
