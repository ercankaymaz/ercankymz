// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.System.Formats.Asn13538873.DoesNotReturnIfAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class System\u002EFormats\u002EAsn13538873\u002EDoesNotReturnIfAttribute : Attribute
{
  public System\u002EFormats\u002EAsn13538873\u002EDoesNotReturnIfAttribute(bool parameterValue)
  {
    this.ParameterValue = parameterValue;
  }

  public bool ParameterValue { get; }
}
