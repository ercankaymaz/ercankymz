using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms;

public interface IContainsRibbonComponents
{
	IEnumerable<Component> GetAllChildComponents();
}
