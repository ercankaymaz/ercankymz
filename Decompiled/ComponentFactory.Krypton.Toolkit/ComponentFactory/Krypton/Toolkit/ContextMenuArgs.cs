using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ContextMenuArgs : CancelEventArgs
{
	private ContextMenuStrip _cms;

	private KryptonContextMenu _kcm;

	public ContextMenuStrip ContextMenuStrip => _cms;

	public KryptonContextMenu KryptonContextMenu => _kcm;

	public ContextMenuArgs()
		: this(null, null)
	{
	}

	public ContextMenuArgs(ContextMenuStrip cms)
		: this(cms, null)
	{
	}

	public ContextMenuArgs(KryptonContextMenu kcm)
		: this(null, kcm)
	{
	}

	public ContextMenuArgs(ContextMenuStrip cms, KryptonContextMenu kcm)
	{
		_cms = cms;
		_kcm = kcm;
	}
}
