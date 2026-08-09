using System.ComponentModel;
using System.Windows.Forms;

namespace buControls.ClassViewer;

[ToolboxItem(false)]
public class setNumericUpDownControl : NumericUpDown
{
	public object EditValue = null;
}
