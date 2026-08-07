// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.Newtonsoft.Json1494283.NotNullWhenAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
internal sealed class Newtonsoft\u002EJson1494283\u002ENotNullWhenAttribute : Attribute
{
  public Newtonsoft\u002EJson1494283\u002ENotNullWhenAttribute(bool returnValue)
  {
    this.ReturnValue = returnValue;
  }

  public bool ReturnValue { get; }
}
