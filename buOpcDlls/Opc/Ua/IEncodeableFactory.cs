// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IEncodeableFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IEncodeableFactory : ICloneable
{
  int InstanceId { get; }

  void AddEncodeableType(Type systemType);

  void AddEncodeableType(ExpandedNodeId encodingId, Type systemType);

  void AddEncodeableTypes(Assembly assembly);

  void AddEncodeableTypes(IEnumerable<Type> systemTypes);

  Type GetSystemType(ExpandedNodeId typeId);

  IReadOnlyDictionary<ExpandedNodeId, Type> EncodeableTypes { get; }
}
