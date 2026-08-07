// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
internal sealed class DynamicDependencyAttribute : Attribute
{
  public DynamicDependencyAttribute(string memberSignature)
  {
    this.MemberSignature = memberSignature;
  }

  public DynamicDependencyAttribute(string memberSignature, Type type)
  {
    this.MemberSignature = memberSignature;
    this.Type = type;
  }

  public DynamicDependencyAttribute(string memberSignature, string typeName, string assemblyName)
  {
    this.MemberSignature = memberSignature;
    this.TypeName = typeName;
    this.AssemblyName = assemblyName;
  }

  public DynamicDependencyAttribute(DynamicallyAccessedMemberTypes memberTypes, Type type)
  {
    this.MemberTypes = memberTypes;
    this.Type = type;
  }

  public DynamicDependencyAttribute(
    DynamicallyAccessedMemberTypes memberTypes,
    string typeName,
    string assemblyName)
  {
    this.MemberTypes = memberTypes;
    this.TypeName = typeName;
    this.AssemblyName = assemblyName;
  }

  public string MemberSignature { get; }

  public DynamicallyAccessedMemberTypes MemberTypes { get; }

  public Type Type { get; }

  public string TypeName { get; }

  public string AssemblyName { get; }

  public string Condition { get; set; }
}
