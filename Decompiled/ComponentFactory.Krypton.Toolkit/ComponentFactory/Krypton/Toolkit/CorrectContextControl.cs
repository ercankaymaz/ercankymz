#define DEBUG
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class CorrectContextControl : IDisposable
{
	private ViewLayoutContext _context;

	private Control _startControl;

	public CorrectContextControl(ViewLayoutContext context, Control control)
	{
		Debug.Assert(context != null);
		_context = context;
		_startControl = context.Control;
		_context.Control = control;
	}

	public void Dispose()
	{
		_context.Control = _startControl;
	}
}
