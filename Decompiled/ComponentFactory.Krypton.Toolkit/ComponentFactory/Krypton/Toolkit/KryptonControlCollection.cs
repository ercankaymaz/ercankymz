using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonControlCollection : Control.ControlCollection
{
	public KryptonControlCollection(Control owner)
		: base(owner)
	{
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void AddInternal(Control control)
	{
		base.Add(control);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void RemoveInternal(Control control)
	{
		base.Remove(control);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void ClearInternal()
	{
		for (int num = Count - 1; num >= 0; num--)
		{
			RemoveInternal(this[num]);
		}
	}
}
