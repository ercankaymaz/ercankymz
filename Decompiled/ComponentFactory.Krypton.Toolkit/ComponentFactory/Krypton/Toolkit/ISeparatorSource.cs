using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public interface ISeparatorSource
{
	Control SeparatorControl { get; }

	Orientation SeparatorOrientation { get; }

	bool SeparatorCanMove { get; }

	int SeparatorIncrements { get; }

	Rectangle SeparatorMoveBox { get; }

	bool SeparatorMoving(Point mouse, Point splitter);

	void SeparatorMoved(Point mouse, Point splitter);

	void SeparatorNotMoved();
}
