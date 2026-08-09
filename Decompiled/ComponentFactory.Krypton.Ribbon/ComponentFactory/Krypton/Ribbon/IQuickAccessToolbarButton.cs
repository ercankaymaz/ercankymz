using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public interface IQuickAccessToolbarButton
{
	event EventHandler Click;

	event PropertyChangedEventHandler PropertyChanged;

	void SetRibbon(KryptonRibbon ribbon);

	Image GetImage();

	string GetText();

	bool GetEnabled();

	Keys GetShortcutKeys();

	bool GetVisible();

	void SetVisible(bool visible);

	LabelStyle GetToolTipStyle();

	Image GetToolTipImage();

	Color GetToolTipImageTransparentColor();

	string GetToolTipTitle();

	string GetToolTipBody();

	void PerformClick();
}
