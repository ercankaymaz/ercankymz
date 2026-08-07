// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.ITransportBindings`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportBindings<T>
{
  T GetBinding(string uriScheme);

  bool HasBinding(string uriScheme);

  void SetBinding(T binding);

  IEnumerable<Type> AddBindings(Assembly assembly);

  IEnumerable<Type> AddBindings(IEnumerable<Type> bindings);
}
