using System;
using System.Collections.Generic;
using MS.Internal.Features;
using Microsoft.Windows.Design.Interaction;

namespace Microsoft.Windows.Design.Services;

public class ContextMenuService
{
	private ContextMenuFeatureConnector _contextMenuExtensionServer;

	internal ContextMenuService(ContextMenuFeatureConnector contextMenuExtensionServer)
	{
		if (contextMenuExtensionServer == null)
		{
			throw new ArgumentNullException("contextMenuExtensionServer");
		}
		_contextMenuExtensionServer = contextMenuExtensionServer;
	}

	public IEnumerable<MenuBase> GetItems()
	{
		return _contextMenuExtensionServer.GetItems();
	}
}
