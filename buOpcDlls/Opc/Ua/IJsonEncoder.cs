// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IJsonEncoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IJsonEncoder : IEncoder, IDisposable
{
  bool ForceNamespaceUri { get; set; }

  void PushArray(string fieldName);

  void PushStructure(string fieldName);

  void PopArray();

  void PopStructure();

  void UsingReversibleEncoding<T>(
    Action<string, T> action,
    string fieldName,
    T value,
    bool useReversibleEncoding);
}
