using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public abstract class EditorControlBase : EditorBase
{
	private Control control_0;

	internal GridVirtual gridVirtual_0;

	internal LinkedControlValue linkedControlValue_0;

	private bool bool_6 = false;

	[CompilerGenerated]
	private KeyPressEventHandler keyPressEventHandler_0;

	public Control Control => control_0;

	public GridVirtual Grid => gridVirtual_0;

	public event KeyPressEventHandler KeyPress
	{
		[CompilerGenerated]
		add
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_0;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Combine(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_0, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyPressEventHandler keyPressEventHandler = keyPressEventHandler_0;
			KeyPressEventHandler keyPressEventHandler2;
			do
			{
				keyPressEventHandler2 = keyPressEventHandler;
				KeyPressEventHandler value2 = (KeyPressEventHandler)Delegate.Remove(keyPressEventHandler2, value);
				keyPressEventHandler = Interlocked.CompareExchange(ref keyPressEventHandler_0, value2, keyPressEventHandler2);
			}
			while ((object)keyPressEventHandler != keyPressEventHandler2);
		}
	}

	public EditorControlBase(Type p_Type)
		: base(p_Type)
	{
		control_0 = CreateControl();
		if (Control == null)
		{
			throw new SourceGridException("Control cannot be null");
		}
		Control.Hide();
	}

	protected abstract Control CreateControl();

	internal override void vmethod_0(CellContext cellContext_1)
	{
		base.vmethod_0(cellContext_1);
		if (Control != null)
		{
			if (!base.IsEditing && base.EnableEdit)
			{
				if (base.EditCell != null)
				{
					throw new SourceGridException("There is already a Cell in edit state");
				}
				if (!Class76.smethod_154(this))
				{
					Class76.smethod_676(this, cellContext_1.Grid);
				}
				linkedControlValue_0.Position = cellContext_1.Position;
				cellContext_1.Grid.ArrangeLinkedControls();
				OnStartingEdit(cellContext_1, Control);
				SetEditCell(cellContext_1);
				SafeSetEditValue(cellContext_1.Cell.Model.ValueModel.GetValue(cellContext_1));
				ShowControl(Control);
			}
			return;
		}
		throw new SourceGridException("Control cannot be null");
	}

	protected virtual void OnStartingEdit(CellContext cellContext, Control editorControl)
	{
		if (UseCellViewProperties)
		{
			editorControl.BackColor = cellContext.Cell.View.BackColor;
			editorControl.ForeColor = cellContext.Cell.View.ForeColor;
			editorControl.Font = cellContext.Cell.View.Font;
		}
	}

	protected virtual void ShowControl(Control editorControl)
	{
		editorControl.Show();
		editorControl.BringToFront();
		editorControl.Focus();
	}

	public override bool ApplyEdit()
	{
		if (!base.IsEditing)
		{
			return true;
		}
		try
		{
			return SetCellValue(base.EditCellContext, GetEditedValue());
		}
		catch (Exception p_Exception)
		{
			OnEditException(new ExceptionEventArgs(p_Exception));
			return false;
		}
	}

	internal override bool vmethod_1(bool bool_7)
	{
		if (base.IsEditing)
		{
			if (!bool_6)
			{
				bool_6 = true;
				try
				{
					bool flag = true;
					if (bool_7)
					{
						UndoEditValue();
					}
					if (Control.ContainsFocus && !base.EditCellContext.Grid.Focus())
					{
						flag = false;
					}
					if (flag && !bool_7)
					{
						flag = ApplyEdit();
					}
					if (!flag)
					{
						if (!Control.ContainsFocus)
						{
							Control.Focus();
						}
					}
					else
					{
						Class76.smethod_272(this);
						linkedControlValue_0.Position = Position.Empty;
						SetEditCell(CellContext.Empty);
					}
					return flag;
				}
				finally
				{
					bool_6 = false;
				}
			}
			return false;
		}
		return true;
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			if (base.IsEditing)
			{
				base.EditCellContext.EndEdit(cancel: false);
			}
		}
		catch (Exception p_Exception)
		{
			OnEditException(new ExceptionEventArgs(p_Exception));
		}
	}

	internal void method_6(object sender, KeyPressEventArgs e)
	{
		if (!e.Handled)
		{
			OnKeyPress(e);
		}
	}

	public virtual void UndoEditValue()
	{
		if (base.EditCell == null)
		{
			throw new SourceGridException("Not in edit state");
		}
		SafeSetEditValue(base.EditCell.Model.ValueModel.GetValue(base.EditCellContext));
	}

	public void SafeSetEditValue(object editValue)
	{
		try
		{
			SetEditValue(editValue);
		}
		catch (Exception innerException)
		{
			base.EditCellContext.Grid.OnUserException(new ExceptionEventArgs(new EditingCellException(innerException)));
			SetEditValue(base.DefaultValue);
		}
	}

	public abstract override object GetEditedValue();

	public abstract void SetEditValue(object editValue);

	protected virtual void OnKeyPress(KeyPressEventArgs e)
	{
		if (!e.Handled && keyPressEventHandler_0 != null)
		{
			keyPressEventHandler_0(this, e);
		}
	}

	public sealed override void SendCharToEditor(char key)
	{
		KeyPressEventArgs e = new KeyPressEventArgs(key);
		OnKeyPress(e);
		if (!e.Handled)
		{
			OnSendCharToEditor(e.KeyChar);
		}
	}

	protected abstract void OnSendCharToEditor(char key);

	public override Size GetMinimumSize(CellContext cellContext)
	{
		return Control.GetPreferredSize(Size.Empty);
	}
}
