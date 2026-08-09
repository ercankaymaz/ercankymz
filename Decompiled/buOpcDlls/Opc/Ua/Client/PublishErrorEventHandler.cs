using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void PublishErrorEventHandler(ISession session, PublishErrorEventArgs e);
