using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class GlobalId
{
	private int _id;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Id => _id;

	[DebuggerStepThrough]
	public GlobalId()
	{
		_id = CommonHelper.NextId;
	}
}
