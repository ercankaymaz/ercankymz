// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.MemberNotNullAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[NullableContext(1)]
[Nullable(0)]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class MemberNotNullAttribute : Attribute
{
  public MemberNotNullAttribute(string member)
  {
    this.Members = new string[1]{ member };
  }

  public MemberNotNullAttribute(params string[] members) => this.Members = members;

  public string[] Members { get; }
}
