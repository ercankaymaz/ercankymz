using System.ComponentModel;
using System.Windows.Forms;

namespace buControls.ClassViewer;

[ToolboxItem(false)]
public class setDateTimeControl : DateTimePicker
{
	public object EditValue = null;
}
