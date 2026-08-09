using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua;

[ComVisible(true)]
public delegate Task ConnectionWaitingHandlerAsync(object sender, ConnectionWaitingEventArgs args);
