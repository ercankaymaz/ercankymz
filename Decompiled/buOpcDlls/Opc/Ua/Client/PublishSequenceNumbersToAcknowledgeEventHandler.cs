using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void PublishSequenceNumbersToAcknowledgeEventHandler(ISession session, PublishSequenceNumbersToAcknowledgeEventArgs e);
