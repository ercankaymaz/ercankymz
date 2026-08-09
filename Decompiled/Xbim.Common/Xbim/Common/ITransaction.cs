using System;

namespace Xbim.Common;

public interface ITransaction : IDisposable
{
	string Name { get; }

	event EntityChangedHandler EntityChanged;

	event EntityChangingHandler EntityChanging;

	void Commit();

	void RollBack();

	void DoReversibleAction(Action doAction, Action undoAction, IPersistEntity entity, ChangeType changeType, int property);
}
