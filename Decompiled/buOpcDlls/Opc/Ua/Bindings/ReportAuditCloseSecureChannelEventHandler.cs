using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public delegate void ReportAuditCloseSecureChannelEventHandler(TcpServerChannel channel, Exception exception);
