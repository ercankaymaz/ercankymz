using System;

namespace Xbim.Common;

public class PlaceboTransaction : ITransaction, IDisposable
{
	public string Name => "Placebo";

	public event EntityChangedHandler EntityChanged;

	public event EntityChangingHandler EntityChanging;

	public void Commit()
	{
	}

	public void RollBack()
	{
	}

	public void DoReversibleAction(Action doAction, Action undoAction, IPersistEntity entity, ChangeType changeType, int property)
	{
	}

	public void Dispose()
	{
	}

	protected virtual void OnEntityChanged(IPersistEntity entity, ChangeType change, int property)
	{
		this.EntityChanged?.Invoke(entity, change, property);
	}

	protected virtual void OnEntityChanging(IPersistEntity entity, ChangeType change, int property)
	{
		this.EntityChanging?.Invoke(entity, change, property);
	}
}
