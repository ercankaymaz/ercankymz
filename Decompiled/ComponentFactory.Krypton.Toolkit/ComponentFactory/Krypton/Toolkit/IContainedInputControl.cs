using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface IContainedInputControl
{
	Control ContainedControl { get; }
}
