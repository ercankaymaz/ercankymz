using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using ns27;

namespace buMutliTextbox;

public class CommandManager
{
	private readonly int int_0 = 200;

	internal LimitedStack<UndoableCommand> limitedStack_0;

	internal Stack<UndoableCommand> stack_0 = new Stack<UndoableCommand>();

	[CompilerGenerated]
	private TextSource textSource_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	internal EventHandler eventHandler_0 = delegate
	{
	};

	protected internal int disabledCommands = 0;

	private int int_1 = 0;

	public TextSource TextSource
	{
		[CompilerGenerated]
		get
		{
			return textSource_0;
		}
		[CompilerGenerated]
		private set
		{
			textSource_0 = value;
		}
	}

	public bool UndoRedoStackIsEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool UndoEnabled => limitedStack_0.Count > 0;

	public bool RedoEnabled => stack_0.Count > 0;

	public event EventHandler RedoCompleted
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public CommandManager(TextSource ts)
	{
		limitedStack_0 = new LimitedStack<UndoableCommand>(int_0);
		TextSource = ts;
		UndoRedoStackIsEnabled = true;
	}

	public virtual void ExecuteCommand(Command cmd)
	{
		if (disabledCommands > 0)
		{
			return;
		}
		if (cmd.ts.CurrentTB.Selection.ColumnSelectionMode && cmd is UndoableCommand)
		{
			cmd = new MultiRangeCommand((UndoableCommand)cmd);
		}
		if (cmd is UndoableCommand)
		{
			(cmd as UndoableCommand).bool_0 = int_1 > 0;
			limitedStack_0.Push(cmd as UndoableCommand);
		}
		try
		{
			cmd.Execute();
		}
		catch (ArgumentOutOfRangeException)
		{
			if (cmd is UndoableCommand)
			{
				limitedStack_0.Pop();
			}
		}
		if (!UndoRedoStackIsEnabled)
		{
			Class76.smethod_89(this);
		}
		stack_0.Clear();
		TextSource.CurrentTB.OnUndoRedoStateChanged();
	}

	public void Undo()
	{
		if (limitedStack_0.Count > 0)
		{
			UndoableCommand undoableCommand = limitedStack_0.Pop();
			Class76.smethod_639(this);
			try
			{
				undoableCommand.Undo();
			}
			finally
			{
				Class76.smethod_20(this);
			}
			stack_0.Push(undoableCommand);
		}
		if (limitedStack_0.Count > 0 && limitedStack_0.Peek().bool_0)
		{
			Undo();
		}
		TextSource.CurrentTB.OnUndoRedoStateChanged();
	}

	public void EndAutoUndoCommands()
	{
		int_1--;
		if (int_1 == 0 && limitedStack_0.Count > 0)
		{
			limitedStack_0.Peek().bool_0 = false;
		}
	}

	public void BeginAutoUndoCommands()
	{
		int_1++;
	}
}
