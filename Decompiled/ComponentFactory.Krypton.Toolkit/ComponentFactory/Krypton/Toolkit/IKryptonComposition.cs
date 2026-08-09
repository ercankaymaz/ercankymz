using System;

namespace ComponentFactory.Krypton.Toolkit;

public interface IKryptonComposition
{
	int CompHeight { get; }

	bool CompVisible { get; set; }

	VisualForm CompOwnerForm { get; set; }

	IntPtr CompHandle { get; }

	void CompNeedPaint(bool needLayout);
}
