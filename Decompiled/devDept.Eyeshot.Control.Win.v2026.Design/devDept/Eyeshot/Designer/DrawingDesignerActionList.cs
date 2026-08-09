using System;
using System.Diagnostics;
using System.Windows.Forms.Design;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer;

public class DrawingDesignerActionList<T> : WorkspaceDesignerActionList<T> where T : Drawing
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DrawingControlDesignerGeneric<T> _0023_003DzHMi3eDCqhAgu;

	public DrawingDesignerActionList(ControlDesigner designer)
		: base(designer)
	{
		try
		{
			_0023_003DzHMi3eDCqhAgu = (DrawingControlDesignerGeneric<T>)WorkspaceControlDesigner;
		}
		catch (Exception ex)
		{
			throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313419) + ex.StackTrace, ex);
		}
	}
}
