using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevAge.Windows.Forms;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public class RichTextBox : Cell
{
	public Font SelectionFont
	{
		get
		{
			return method_2().GetSelectionFont(GetContext());
		}
		set
		{
			method_2().SetSelectionFont(GetContext(), value);
		}
	}

	public Color SelectionColor
	{
		get
		{
			return method_2().GetSelectionColor(GetContext());
		}
		set
		{
			method_2().SetSelectionColor(GetContext(), value);
		}
	}

	public int SelectionCharOffset
	{
		get
		{
			return method_2().GetSelectionCharOffset(GetContext());
		}
		set
		{
			method_2().SetSelectionCharOffset(GetContext(), value);
		}
	}

	public HorizontalAlignment SelectionAlignment
	{
		get
		{
			return method_2().GetSelectionAlignment(GetContext());
		}
		set
		{
			method_2().SetSelectionAlignment(GetContext(), value);
		}
	}

	public RichTextBox()
		: this(null)
	{
	}

	public RichTextBox(RichText value)
		: base(value)
	{
		View = new SourceGrid.Cells.Views.RichTextBox();
		base.Model.AddModel(new SourceGrid.Cells.Models.RichTextBox());
		AddController(SourceGrid.Cells.Controllers.RichTextBox.Default);
		base.Editor = new SourceGrid.Cells.Editors.RichTextBox();
	}

	[SpecialName]
	private SourceGrid.Cells.Models.RichTextBox method_2()
	{
		return (SourceGrid.Cells.Models.RichTextBox)base.Model.FindModel(typeof(SourceGrid.Cells.Models.RichTextBox));
	}

	public void SelectionBold()
	{
		SelectionFont = new Font(SelectionFont, SelectionFont.Style ^ FontStyle.Bold);
	}

	public void SelectionItalic()
	{
		SelectionFont = new Font(SelectionFont, SelectionFont.Style ^ FontStyle.Italic);
	}

	public void SelectionUnderline()
	{
		SelectionFont = new Font(SelectionFont, SelectionFont.Style ^ FontStyle.Underline);
	}

	public void InsertString(string s)
	{
		method_2().InsertString(GetContext(), s);
	}

	public void SelectionSuperScript()
	{
		method_2().SetSelectionEffect(GetContext(), EffectType.Superscript);
	}

	public void SelectionNormalScript()
	{
		method_2().SetSelectionEffect(GetContext(), EffectType.Normal);
	}

	public void SelectionSubScript()
	{
		method_2().SetSelectionEffect(GetContext(), EffectType.Subscript);
	}

	public void SelectionNormal()
	{
		method_2().SetSelectionEffect(GetContext(), EffectType.Normal);
	}
}
