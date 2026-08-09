#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DevAge.ComponentModel.Validator;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class EditorBase(Type p_Type) : ValidatorTypeConverter(p_Type)
{
	private CellContext cellContext_0 = CellContext.Empty;

	private string string_2 = "#ERROR!";

	private bool bool_3 = true;

	private EditableMode editableMode_0 = EditableMode.Default;

	private bool bool_4 = true;

	private bool bool_5 = true;

	[CompilerGenerated]
	private ValidatingCellEventHandler validatingCellEventHandler_0;

	[CompilerGenerated]
	private CellContextEventHandler cellContextEventHandler_0;

	[CompilerGenerated]
	private ExceptionEventHandler exceptionEventHandler_0;

	public CellContext EditCellContext => cellContext_0;

	public ICellVirtual EditCell => cellContext_0.Cell;

	public Position EditPosition => cellContext_0.Position;

	public string ErrorString
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public bool EnableEdit
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public EditableMode EditableMode
	{
		get
		{
			return editableMode_0;
		}
		set
		{
			editableMode_0 = value;
		}
	}

	public virtual bool EnableCellDrawOnEdit
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public virtual bool UseCellViewProperties
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool IsEditing => EditCell != null;

	[Obsolete("You should use the Control.Validating event")]
	public event ValidatingCellEventHandler Validating
	{
		add
		{
			method_1(value);
		}
		remove
		{
			method_2(value);
		}
	}

	[Obsolete("You should use the Control.Validated event")]
	public event CellContextEventHandler Validated
	{
		add
		{
			method_3(value);
		}
		remove
		{
			method_4(value);
		}
	}

	public event ExceptionEventHandler EditException
	{
		[CompilerGenerated]
		add
		{
			ExceptionEventHandler exceptionEventHandler = exceptionEventHandler_0;
			ExceptionEventHandler exceptionEventHandler2;
			do
			{
				exceptionEventHandler2 = exceptionEventHandler;
				ExceptionEventHandler value2 = (ExceptionEventHandler)Delegate.Combine(exceptionEventHandler2, value);
				exceptionEventHandler = Interlocked.CompareExchange(ref exceptionEventHandler_0, value2, exceptionEventHandler2);
			}
			while ((object)exceptionEventHandler != exceptionEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ExceptionEventHandler exceptionEventHandler = exceptionEventHandler_0;
			ExceptionEventHandler exceptionEventHandler2;
			do
			{
				exceptionEventHandler2 = exceptionEventHandler;
				ExceptionEventHandler value2 = (ExceptionEventHandler)Delegate.Remove(exceptionEventHandler2, value);
				exceptionEventHandler = Interlocked.CompareExchange(ref exceptionEventHandler_0, value2, exceptionEventHandler2);
			}
			while ((object)exceptionEventHandler != exceptionEventHandler2);
		}
	}

	protected void SetEditCell(CellContext cellContext)
	{
		cellContext_0 = cellContext;
	}

	public bool IsErrorString(string p_str)
	{
		if (!(p_str == ErrorString))
		{
			return false;
		}
		return true;
	}

	internal virtual void vmethod_0(CellContext cellContext_1)
	{
		if (cellContext_1.Cell != null)
		{
			if (cellContext_1.Grid != null)
			{
				if (cellContext_1.Grid.Selection.ActivePosition != cellContext_1.Position)
				{
					throw new SourceGridException("Cell must have the focus");
				}
				return;
			}
			throw new ArgumentNullException("cellContext.Grid");
		}
		throw new ArgumentNullException("cellContext.Cell");
	}

	public virtual bool ApplyEdit()
	{
		return true;
	}

	internal virtual bool vmethod_1(bool bool_6)
	{
		return true;
	}

	public virtual object GetEditedValue()
	{
		throw new SourceGridException("No valid cell editor found");
	}

	public virtual void ClearCell(CellContext cellContext)
	{
		SetCellValue(cellContext, base.DefaultValue);
	}

	public virtual bool SetCellValue(CellContext cellContext, object p_NewValue)
	{
		if (!EnableEdit)
		{
			return false;
		}
		if (cellContext.Cell != null)
		{
			ValidatingCellEventArgs e = new ValidatingCellEventArgs(cellContext, p_NewValue);
			OnValidating(e);
			if (!e.Cancel)
			{
				object value = cellContext.Cell.Model.ValueModel.GetValue(cellContext);
				try
				{
					cellContext.Cell.Model.ValueModel.SetValue(cellContext, ObjectToValue(e.NewValue));
					OnValidated(new CellContextEventArgs(cellContext));
				}
				catch (Exception p_Exception)
				{
					OnEditException(new ExceptionEventArgs(p_Exception));
					cellContext.Cell.Model.ValueModel.SetValue(cellContext, value);
					e.Cancel = true;
				}
			}
			return !e.Cancel;
		}
		throw new SourceGridException("Invalid CellContext, cell is null");
	}

	protected void OnValidated(CellContextEventArgs e)
	{
		if (cellContextEventHandler_0 != null)
		{
			cellContextEventHandler_0(this, e);
		}
	}

	protected void OnValidating(ValidatingCellEventArgs e)
	{
		if (validatingCellEventHandler_0 != null)
		{
			validatingCellEventHandler_0(this, e);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(ValidatingCellEventHandler validatingCellEventHandler_1)
	{
		ValidatingCellEventHandler validatingCellEventHandler = validatingCellEventHandler_0;
		ValidatingCellEventHandler validatingCellEventHandler2;
		do
		{
			validatingCellEventHandler2 = validatingCellEventHandler;
			ValidatingCellEventHandler value = (ValidatingCellEventHandler)Delegate.Combine(validatingCellEventHandler2, validatingCellEventHandler_1);
			validatingCellEventHandler = Interlocked.CompareExchange(ref validatingCellEventHandler_0, value, validatingCellEventHandler2);
		}
		while ((object)validatingCellEventHandler != validatingCellEventHandler2);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_2(ValidatingCellEventHandler validatingCellEventHandler_1)
	{
		ValidatingCellEventHandler validatingCellEventHandler = validatingCellEventHandler_0;
		ValidatingCellEventHandler validatingCellEventHandler2;
		do
		{
			validatingCellEventHandler2 = validatingCellEventHandler;
			ValidatingCellEventHandler value = (ValidatingCellEventHandler)Delegate.Remove(validatingCellEventHandler2, validatingCellEventHandler_1);
			validatingCellEventHandler = Interlocked.CompareExchange(ref validatingCellEventHandler_0, value, validatingCellEventHandler2);
		}
		while ((object)validatingCellEventHandler != validatingCellEventHandler2);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(CellContextEventHandler cellContextEventHandler_1)
	{
		CellContextEventHandler cellContextEventHandler = cellContextEventHandler_0;
		CellContextEventHandler cellContextEventHandler2;
		do
		{
			cellContextEventHandler2 = cellContextEventHandler;
			CellContextEventHandler value = (CellContextEventHandler)Delegate.Combine(cellContextEventHandler2, cellContextEventHandler_1);
			cellContextEventHandler = Interlocked.CompareExchange(ref cellContextEventHandler_0, value, cellContextEventHandler2);
		}
		while ((object)cellContextEventHandler != cellContextEventHandler2);
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_4(CellContextEventHandler cellContextEventHandler_1)
	{
		CellContextEventHandler cellContextEventHandler = cellContextEventHandler_0;
		CellContextEventHandler cellContextEventHandler2;
		do
		{
			cellContextEventHandler2 = cellContextEventHandler;
			CellContextEventHandler value = (CellContextEventHandler)Delegate.Remove(cellContextEventHandler2, cellContextEventHandler_1);
			cellContextEventHandler = Interlocked.CompareExchange(ref cellContextEventHandler_0, value, cellContextEventHandler2);
		}
		while ((object)cellContextEventHandler != cellContextEventHandler2);
	}

	protected virtual void OnEditException(ExceptionEventArgs e)
	{
		Debug.WriteLine("Exception on editing cell: " + e.Exception.ToString());
		if (exceptionEventHandler_0 != null)
		{
			exceptionEventHandler_0(this, e);
		}
	}

	public virtual void SendCharToEditor(char key)
	{
	}

	public virtual Size GetMinimumSize(CellContext cellContext)
	{
		return Size.Empty;
	}
}
