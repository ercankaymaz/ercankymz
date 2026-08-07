// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.LibraryImportAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
internal sealed class LibraryImportAttribute : Attribute
{
  public LibraryImportAttribute(string libraryName) => this.LibraryName = libraryName;

  public string LibraryName { get; }

  public string EntryPoint { get; set; }

  public StringMarshalling StringMarshalling { get; set; }

  public Type StringMarshallingCustomType { get; set; }

  public bool SetLastError { get; set; }
}
