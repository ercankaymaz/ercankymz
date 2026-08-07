// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.System.Diagnostics.DiagnosticSource3462135.MemberNotNullAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class System\u002EDiagnostics\u002EDiagnosticSource3462135\u002EMemberNotNullAttribute : 
  Attribute
{
  public System\u002EDiagnostics\u002EDiagnosticSource3462135\u002EMemberNotNullAttribute(
    string member)
  {
    this.Members = new string[1]{ member };
  }

  public System\u002EDiagnostics\u002EDiagnosticSource3462135\u002EMemberNotNullAttribute(
    params string[] members)
  {
    this.Members = members;
  }

  public string[] Members { get; }
}
