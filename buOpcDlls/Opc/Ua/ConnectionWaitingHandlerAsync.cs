// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConnectionWaitingHandlerAsync
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public delegate Task ConnectionWaitingHandlerAsync(object sender, ConnectionWaitingEventArgs args);
