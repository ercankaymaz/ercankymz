using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public delegate void BrowserEventHandler(Browser sender, BrowserEventArgs e);
