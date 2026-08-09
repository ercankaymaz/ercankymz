using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public interface IContextMenuTarget
{
	bool HasSubMenu { get; }

	Rectangle ClientRectangle { get; }

	void ShowTarget();

	void ClearTarget();

	void ShowSubMenu();

	void ClearSubMenu();

	bool MatchMnemonic(char charCode);

	void MnemonicActivate();

	ViewBase GetActiveView();

	bool DoesStackedClientMouseDownBecomeCurrent(Point pt);
}
