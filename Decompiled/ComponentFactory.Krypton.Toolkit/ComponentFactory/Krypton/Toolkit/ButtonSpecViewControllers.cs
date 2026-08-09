#define DEBUG
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecViewControllers
{
	private IMouseController _mouseController;

	private ISourceController _sourceController;

	private IKeyController _keyController;

	public IMouseController MouseController => _mouseController;

	public ISourceController SourceController => _sourceController;

	public IKeyController KeyController => _keyController;

	public ButtonSpecViewControllers(IMouseController mouseController, ISourceController sourceController, IKeyController keyController)
	{
		Debug.Assert(mouseController != null);
		Debug.Assert(sourceController != null);
		Debug.Assert(keyController != null);
		_mouseController = mouseController;
		_sourceController = sourceController;
		_keyController = keyController;
	}
}
