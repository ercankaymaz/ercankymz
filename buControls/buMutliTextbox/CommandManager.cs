// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.CommandManager
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class CommandManager
{
  private readonly int int_0 = 200;
  internal LimitedStack<UndoableCommand> limitedStack_0;
  internal Stack<UndoableCommand> stack_0 = new Stack<UndoableCommand>();
  protected internal int disabledCommands = 0;
  private int int_1 = 0;

  public TextSource TextSource { get; private set; }

  public bool UndoRedoStackIsEnabled { get; set; }

  public event EventHandler RedoCompleted = (sender, e) => { };

  public CommandManager(TextSource ts)
  {
    this.limitedStack_0 = new LimitedStack<UndoableCommand>(this.int_0);
    this.TextSource = ts;
    this.UndoRedoStackIsEnabled = true;
  }

  public virtual void ExecuteCommand(Command cmd)
  {
    if (this.disabledCommands > 0)
      return;
    if (cmd.ts.CurrentTB.Selection.ColumnSelectionMode && cmd is UndoableCommand)
      cmd = (Command) new MultiRangeCommand((UndoableCommand) cmd);
    if (cmd is UndoableCommand)
    {
      (cmd as UndoableCommand).bool_0 = this.int_1 > 0;
      this.limitedStack_0.Push(cmd as UndoableCommand);
    }
    try
    {
      cmd.Execute();
    }
    catch (ArgumentOutOfRangeException ex)
    {
      if (cmd is UndoableCommand)
        this.limitedStack_0.Pop();
    }
    if (!this.UndoRedoStackIsEnabled)
      Class39.smethod_89(this);
    this.stack_0.Clear();
    this.TextSource.CurrentTB.OnUndoRedoStateChanged();
  }

  public void Undo()
  {
    if (this.limitedStack_0.Count > 0)
    {
      UndoableCommand undoableCommand = this.limitedStack_0.Pop();
      Class39.smethod_639(this);
      try
      {
        undoableCommand.Undo();
      }
      finally
      {
        Class39.smethod_20(this);
      }
      this.stack_0.Push(undoableCommand);
    }
    if (this.limitedStack_0.Count > 0 && this.limitedStack_0.Peek().bool_0)
      this.Undo();
    this.TextSource.CurrentTB.OnUndoRedoStateChanged();
  }

  public void EndAutoUndoCommands()
  {
    --this.int_1;
    if (this.int_1 != 0 || this.limitedStack_0.Count <= 0)
      return;
    this.limitedStack_0.Peek().bool_0 = false;
  }

  public void BeginAutoUndoCommands() => ++this.int_1;

  public bool UndoEnabled => this.limitedStack_0.Count > 0;

  public bool RedoEnabled => this.stack_0.Count > 0;
}
