using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit;

public interface IRichTextBoxFormatBar
{
	System.Windows.Controls.RichTextBox Target { get; set; }

	bool PreventDisplayFadeOut { get; }

	void Update();
}
