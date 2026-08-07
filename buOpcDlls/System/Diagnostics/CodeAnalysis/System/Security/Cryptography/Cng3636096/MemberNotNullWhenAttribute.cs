// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.System.Security.Cryptography.Cng3636096.MemberNotNullWhenAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class System\u002ESecurity\u002ECryptography\u002ECng3636096\u002EMemberNotNullWhenAttribute : 
  Attribute
{
  public System\u002ESecurity\u002ECryptography\u002ECng3636096\u002EMemberNotNullWhenAttribute(
    bool returnValue,
    string member)
  {
    this.ReturnValue = returnValue;
    this.Members = new string[1]{ member };
  }

  public System\u002ESecurity\u002ECryptography\u002ECng3636096\u002EMemberNotNullWhenAttribute(
    bool returnValue,
    params string[] members)
  {
    this.ReturnValue = returnValue;
    this.Members = members;
  }

  public bool ReturnValue { get; }

  public string[] Members { get; }
}
