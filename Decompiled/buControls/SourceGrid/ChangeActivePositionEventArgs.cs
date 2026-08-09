using System.ComponentModel;

namespace SourceGrid;

public class ChangeActivePositionEventArgs : CancelEventArgs
{
	private Position pOldFocusPosition;

	private Position pNewFocusPosition;

	public Position OldFocusPosition => pOldFocusPosition;

	public Position NewFocusPosition => pNewFocusPosition;

	public ChangeActivePositionEventArgs(Position pOldFocusPosition, Position pNewFocusPosition)
		: base(cancel: false)
	{
		this.pOldFocusPosition = pOldFocusPosition;
		this.pNewFocusPosition = pNewFocusPosition;
	}
}
