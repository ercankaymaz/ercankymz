// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.IReferenceResolver
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
public interface IReferenceResolver
{
  object ResolveReference(object context, string reference);

  string GetReference(object context, object value);

  bool IsReferenced(object context, object value);

  void AddReference(object context, string reference, object value);
}
