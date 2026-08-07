// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TransportChannelBindings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TransportChannelBindings(Type[] defaultBindings) : 
  TransportBindingsBase<ITransportChannelFactory>(defaultBindings)
{
  public ITransportChannel GetChannel(string uriScheme) => this.GetBinding(uriScheme)?.Create();
}
