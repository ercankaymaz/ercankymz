// Decompiled with JetBrains decompiler
// Type: System.Runtime.CompilerServices.NativeIntegerAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.CodeAnalysis.System.Runtime.CompilerServices.Unsafe;

#nullable disable
namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
[Embedded]
[CompilerGenerated]
internal sealed class NativeIntegerAttribute : Attribute
{
  public readonly bool[] TransformFlags;

  public NativeIntegerAttribute()
  {
    // ISSUE: reference to a compiler-generated field
    this.TransformFlags = new bool[1]{ true };
  }

  public NativeIntegerAttribute(bool[] A_0) => this.TransformFlags = A_0;
}
