// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
internal sealed class RequiresUnreferencedCodeAttribute : Attribute
{
  public RequiresUnreferencedCodeAttribute(string message) => this.Message = message;

  public string Message { get; }

  public string Url { get; set; }
}
