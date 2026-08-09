using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class NoneExcludedImageIndexConverter : ImageIndexConverter
{
	protected override bool IncludeNoneAsStandardValue => false;
}
