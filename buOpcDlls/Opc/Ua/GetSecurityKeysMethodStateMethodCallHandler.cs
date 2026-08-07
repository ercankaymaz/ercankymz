// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GetSecurityKeysMethodStateMethodCallHandler
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GetSecurityKeysMethodStateMethodCallHandler(
  ISystemContext _context,
  MethodState _method,
  NodeId _objectId,
  string securityGroupId,
  uint startingTokenId,
  uint requestedKeyCount,
  ref string securityPolicyUri,
  ref uint firstTokenId,
  ref byte[][] keys,
  ref double timeToNextKey,
  ref double keyLifetime);
