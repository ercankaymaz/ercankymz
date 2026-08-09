#define DEBUG
using System.Diagnostics;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class SeparatorMessageFilter : IMessageFilter
{
	private SeparatorController _controller;

	public SeparatorMessageFilter(SeparatorController controller)
	{
		Debug.Assert(controller != null);
		_controller = controller;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	public bool PreFilterMessage(ref Message m)
	{
		if (!_controller.IsMoving)
		{
			return false;
		}
		if (m.Msg < 256 || m.Msg > 264)
		{
			return false;
		}
		if ((m.Msg == 256 && (int)m.WParam.ToInt64() == 27) || (m.Msg == 256 && (int)m.WParam.ToInt64() == 91) || m.Msg == 260)
		{
			_controller.AbortMoving();
		}
		return true;
	}
}
