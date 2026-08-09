using System;
using System.Drawing;
using System.Windows.Forms;
using SourceGrid.Cells.Models;

namespace SourceGrid.Cells.Controllers;

public class ToolTipText : ControllerBase
{
	public static readonly ToolTipText Default = new ToolTipText();

	private string string_0 = string.Empty;

	private ToolTipIcon toolTipIcon_0 = ToolTipIcon.None;

	private bool bool_0 = false;

	private Color color_0 = Color.Empty;

	private Color color_1 = Color.Empty;

	public string ToolTipTitle
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public ToolTipIcon ToolTipIcon
	{
		get
		{
			return toolTipIcon_0;
		}
		set
		{
			toolTipIcon_0 = value;
		}
	}

	public bool IsBalloon
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Color ForeColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public override void OnMouseEnter(CellContext sender, EventArgs e)
	{
		base.OnMouseEnter(sender, e);
		ApplyToolTipText(sender, e);
	}

	public override void OnMouseLeave(CellContext sender, EventArgs e)
	{
		base.OnMouseLeave(sender, e);
		ResetToolTipText(sender, e);
	}

	protected virtual void ApplyToolTipText(CellContext sender, EventArgs e)
	{
		IToolTipText toolTipText;
		if ((toolTipText = (IToolTipText)sender.Cell.Model.FindModel(typeof(IToolTipText))) == null)
		{
			return;
		}
		string toolTipText2 = toolTipText.GetToolTipText(sender);
		if (toolTipText2 != null && toolTipText2.Length > 0)
		{
			sender.Grid.ToolTipText = toolTipText2;
			sender.Grid.ToolTip.ToolTipTitle = ToolTipTitle;
			sender.Grid.ToolTip.ToolTipIcon = ToolTipIcon;
			sender.Grid.ToolTip.IsBalloon = IsBalloon;
			if (!BackColor.IsEmpty)
			{
				sender.Grid.ToolTip.BackColor = BackColor;
			}
			if (!ForeColor.IsEmpty)
			{
				sender.Grid.ToolTip.ForeColor = ForeColor;
			}
		}
	}

	protected virtual void ResetToolTipText(CellContext sender, EventArgs e)
	{
		if (sender.Cell.Model.FindModel(typeof(IToolTipText)) != null)
		{
			sender.Grid.ToolTipText = null;
		}
	}
}
