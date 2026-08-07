// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.IArrayPool`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(1)]
public interface IArrayPool<[Nullable(2)] T>
{
  T[] Rent(int minimumLength);

  void Return([Nullable(new byte[] {2, 1})] T[] array);
}
