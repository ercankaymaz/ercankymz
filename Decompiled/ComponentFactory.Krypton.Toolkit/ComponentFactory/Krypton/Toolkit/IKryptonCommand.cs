using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IKryptonCommand
{
	bool Enabled { get; set; }

	bool Checked { get; set; }

	CheckState CheckState { get; set; }

	string Text { get; set; }

	string ExtraText { get; set; }

	string TextLine1 { get; set; }

	string TextLine2 { get; set; }

	Image ImageSmall { get; set; }

	Image ImageLarge { get; set; }

	Color ImageTransparentColor { get; set; }

	event EventHandler Execute;

	event PropertyChangedEventHandler PropertyChanged;

	void PerformExecute();
}
