// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class DoesNotReturnIfAttribute : Attribute
{
  public DoesNotReturnIfAttribute(bool parameterValue) => this.ParameterValue = parameterValue;

  public bool ParameterValue { get; }
}
