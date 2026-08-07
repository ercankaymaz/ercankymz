// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[NullableContext(1)]
[Nullable(0)]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class MemberNotNullWhenAttribute : Attribute
{
  public MemberNotNullWhenAttribute(bool returnValue, string member)
  {
    this.ReturnValue = returnValue;
    this.Members = new string[1]{ member };
  }

  public MemberNotNullWhenAttribute(bool returnValue, params string[] members)
  {
    this.ReturnValue = returnValue;
    this.Members = members;
  }

  public bool ReturnValue { get; }

  public string[] Members { get; }
}
