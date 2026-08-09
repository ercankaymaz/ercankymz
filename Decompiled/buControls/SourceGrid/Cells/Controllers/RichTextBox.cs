using System.Drawing;
using System.Windows.Forms;
using DevAge.Windows.Forms;
using SourceGrid.Cells.Editors;

namespace SourceGrid.Cells.Controllers;

public class RichTextBox : ControllerBase
{
	public static readonly RichTextBox Default = new RichTextBox();

	public override void OnValueChanging(CellContext sender, ValueChangeEventArgs e)
	{
		base.OnValueChanging(sender, e);
		if (e.NewValue is RichText)
		{
			return;
		}
		SourceGrid.Cells.Editors.RichTextBox richTextBox = (SourceGrid.Cells.Editors.RichTextBox)sender.Cell.Editor;
		DevAgeRichTextBox control = richTextBox.Control;
		if (sender.Cell.Editor.EditCell == null)
		{
			control.Value = sender.Value as RichText;
			control.SelectAll();
		}
		if (!(e.NewValue is Font))
		{
			if (!(e.NewValue is Color))
			{
				if (!(e.NewValue is int))
				{
					if (!(e.NewValue is HorizontalAlignment))
					{
						if (e.NewValue is EffectType)
						{
							control.SelectionEffect = (EffectType)e.NewValue;
						}
					}
					else
					{
						control.SelectionAlignment = (HorizontalAlignment)e.NewValue;
					}
				}
				else
				{
					control.SelectionCharOffset = (int)e.NewValue;
				}
			}
			else
			{
				control.SelectionColor = (Color)e.NewValue;
			}
		}
		else
		{
			control.SelectionFont = (Font)e.NewValue;
		}
		if (sender.Cell.Editor.EditCell == null)
		{
			sender.Value = control.Value;
		}
	}
}
