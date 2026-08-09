using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class CloseReasonEventArgs : CancelEventArgs
{
	private ToolStripDropDownCloseReason _closeReason;

	public ToolStripDropDownCloseReason CloseReason => _closeReason;

	public CloseReasonEventArgs(ToolStripDropDownCloseReason closeReason)
	{
		_closeReason = closeReason;
	}
}
