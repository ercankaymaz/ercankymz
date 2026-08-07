// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IDiscoveryChannel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public interface IDiscoveryChannel : IChannelBase
{
  FindServersResponseMessage FindServers(FindServersMessage request);

  IAsyncResult BeginFindServers(
    FindServersMessage request,
    AsyncCallback callback,
    object asyncState);

  FindServersResponseMessage EndFindServers(IAsyncResult result);

  Task<FindServersResponseMessage> FindServersAsync(FindServersMessage request);

  FindServersOnNetworkResponseMessage FindServersOnNetwork(FindServersOnNetworkMessage request);

  IAsyncResult BeginFindServersOnNetwork(
    FindServersOnNetworkMessage request,
    AsyncCallback callback,
    object asyncState);

  FindServersOnNetworkResponseMessage EndFindServersOnNetwork(IAsyncResult result);

  Task<FindServersOnNetworkResponseMessage> FindServersOnNetworkAsync(
    FindServersOnNetworkMessage request);

  GetEndpointsResponseMessage GetEndpoints(GetEndpointsMessage request);

  IAsyncResult BeginGetEndpoints(
    GetEndpointsMessage request,
    AsyncCallback callback,
    object asyncState);

  GetEndpointsResponseMessage EndGetEndpoints(IAsyncResult result);

  Task<GetEndpointsResponseMessage> GetEndpointsAsync(GetEndpointsMessage request);
}
