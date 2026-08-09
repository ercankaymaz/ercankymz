using System;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class ReentrantFlag
{
	public class _ReentrantFlagHandler : IDisposable
	{
		private ReentrantFlag _owner;

		public _ReentrantFlagHandler(ReentrantFlag owner)
		{
			_owner = owner;
			_owner._flag = true;
		}

		public void Dispose()
		{
			_owner._flag = false;
		}
	}

	private bool _flag;

	public bool CanEnter => !_flag;

	public _ReentrantFlagHandler Enter()
	{
		if (_flag)
		{
			throw new InvalidOperationException();
		}
		return new _ReentrantFlagHandler(this);
	}
}
