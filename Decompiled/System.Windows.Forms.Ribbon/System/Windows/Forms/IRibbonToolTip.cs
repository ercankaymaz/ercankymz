using System.Drawing;

namespace System.Windows.Forms;

public interface IRibbonToolTip
{
	string ToolTip { get; set; }

	string ToolTipTitle { get; set; }

	Image ToolTipImage { get; set; }

	ToolTipIcon ToolTipIcon { get; set; }

	event RibbonElementPopupEventHandler ToolTipPopUp;
}
