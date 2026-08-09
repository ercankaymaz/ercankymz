using System.Runtime.CompilerServices;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public class CheckBox : Cell
{
	public bool? Checked
	{
		get
		{
			return method_2().GetCheckBoxStatus(GetContext()).Checked;
		}
		set
		{
			method_2().SetCheckedValue(GetContext(), value);
		}
	}

	public string Caption
	{
		get
		{
			return method_2().Caption;
		}
		set
		{
			method_2().Caption = value;
		}
	}

	public CheckBox()
		: this(null, false)
	{
	}

	public CheckBox(string caption, bool? checkValue)
		: base(checkValue)
	{
		if (caption == null || caption.Length <= 0)
		{
			View = SourceGrid.Cells.Views.CheckBox.Default;
		}
		else
		{
			View = SourceGrid.Cells.Views.CheckBox.MiddleLeftAlign;
		}
		base.Model.AddModel(new SourceGrid.Cells.Models.CheckBox());
		AddController(SourceGrid.Cells.Controllers.CheckBox.Default);
		AddController(MouseInvalidate.Default);
		base.Editor = new EditorBase(typeof(bool));
		base.Editor.EditableMode = EditableMode.None;
		Caption = caption;
	}

	[SpecialName]
	private SourceGrid.Cells.Models.CheckBox method_2()
	{
		return (SourceGrid.Cells.Models.CheckBox)base.Model.FindModel(typeof(SourceGrid.Cells.Models.CheckBox));
	}
}
