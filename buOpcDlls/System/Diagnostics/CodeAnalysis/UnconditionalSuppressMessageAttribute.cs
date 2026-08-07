// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class UnconditionalSuppressMessageAttribute : Attribute
{
  public UnconditionalSuppressMessageAttribute(string category, string checkId)
  {
    this.Category = category;
    this.CheckId = checkId;
  }

  public string Category { get; }

  public string CheckId { get; }

  public string Scope { get; set; }

  public string Target { get; set; }

  public string MessageId { get; set; }

  public string Justification { get; set; }
}
