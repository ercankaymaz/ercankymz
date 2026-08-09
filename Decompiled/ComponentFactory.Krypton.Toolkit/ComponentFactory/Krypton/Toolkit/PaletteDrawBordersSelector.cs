using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
internal class PaletteDrawBordersSelector : UserControl
{
	private IContainer components = null;

	private CheckBox checkBoxInherit;

	private CheckBox checkBoxTop;

	private CheckBox checkBoxBottom;

	private CheckBox checkBoxLeft;

	private CheckBox checkBoxRight;

	private Label label1;

	public PaletteDrawBorders Value
	{
		get
		{
			PaletteDrawBorders paletteDrawBorders = PaletteDrawBorders.None;
			if (checkBoxInherit.Checked)
			{
				paletteDrawBorders = PaletteDrawBorders.Inherit;
			}
			else
			{
				if (checkBoxTop.Checked)
				{
					paletteDrawBorders |= PaletteDrawBorders.Top;
				}
				if (checkBoxBottom.Checked)
				{
					paletteDrawBorders |= PaletteDrawBorders.Bottom;
				}
				if (checkBoxLeft.Checked)
				{
					paletteDrawBorders |= PaletteDrawBorders.Left;
				}
				if (checkBoxRight.Checked)
				{
					paletteDrawBorders |= PaletteDrawBorders.Right;
				}
			}
			return paletteDrawBorders;
		}
		set
		{
			if ((value & PaletteDrawBorders.Inherit) == PaletteDrawBorders.Inherit)
			{
				checkBoxInherit.Checked = true;
				return;
			}
			if ((value & PaletteDrawBorders.Top) == PaletteDrawBorders.Top)
			{
				checkBoxTop.Checked = true;
			}
			if ((value & PaletteDrawBorders.Bottom) == PaletteDrawBorders.Bottom)
			{
				checkBoxBottom.Checked = true;
			}
			if ((value & PaletteDrawBorders.Left) == PaletteDrawBorders.Left)
			{
				checkBoxLeft.Checked = true;
			}
			if ((value & PaletteDrawBorders.Right) == PaletteDrawBorders.Right)
			{
				checkBoxRight.Checked = true;
			}
		}
	}

	public PaletteDrawBordersSelector()
	{
		InitializeComponent();
	}

	private void checkBoxInherit_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = checkBoxTop;
		bool enabled = (checkBoxBottom.Enabled = !checkBoxInherit.Checked);
		checkBox.Enabled = enabled;
		CheckBox checkBox2 = checkBoxLeft;
		enabled = (checkBoxRight.Enabled = !checkBoxInherit.Checked);
		checkBox2.Enabled = enabled;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.checkBoxInherit = new System.Windows.Forms.CheckBox();
		this.checkBoxTop = new System.Windows.Forms.CheckBox();
		this.checkBoxBottom = new System.Windows.Forms.CheckBox();
		this.checkBoxLeft = new System.Windows.Forms.CheckBox();
		this.checkBoxRight = new System.Windows.Forms.CheckBox();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.checkBoxInherit.AutoSize = true;
		this.checkBoxInherit.Location = new System.Drawing.Point(12, 12);
		this.checkBoxInherit.Name = "checkBoxInherit";
		this.checkBoxInherit.Size = new System.Drawing.Size(55, 17);
		this.checkBoxInherit.TabIndex = 0;
		this.checkBoxInherit.Text = "Inherit";
		this.checkBoxInherit.UseVisualStyleBackColor = true;
		this.checkBoxInherit.CheckedChanged += new System.EventHandler(checkBoxInherit_CheckedChanged);
		this.checkBoxTop.AutoSize = true;
		this.checkBoxTop.Location = new System.Drawing.Point(12, 60);
		this.checkBoxTop.Name = "checkBoxTop";
		this.checkBoxTop.Size = new System.Drawing.Size(45, 17);
		this.checkBoxTop.TabIndex = 1;
		this.checkBoxTop.Text = "Top";
		this.checkBoxTop.UseVisualStyleBackColor = true;
		this.checkBoxBottom.AutoSize = true;
		this.checkBoxBottom.Location = new System.Drawing.Point(12, 80);
		this.checkBoxBottom.Name = "checkBoxBottom";
		this.checkBoxBottom.Size = new System.Drawing.Size(59, 17);
		this.checkBoxBottom.TabIndex = 2;
		this.checkBoxBottom.Text = "Bottom";
		this.checkBoxBottom.UseVisualStyleBackColor = true;
		this.checkBoxLeft.AutoSize = true;
		this.checkBoxLeft.Location = new System.Drawing.Point(12, 100);
		this.checkBoxLeft.Name = "checkBoxLeft";
		this.checkBoxLeft.Size = new System.Drawing.Size(44, 17);
		this.checkBoxLeft.TabIndex = 3;
		this.checkBoxLeft.Text = "Left";
		this.checkBoxLeft.UseVisualStyleBackColor = true;
		this.checkBoxRight.AutoSize = true;
		this.checkBoxRight.Location = new System.Drawing.Point(12, 120);
		this.checkBoxRight.Name = "checkBoxRight";
		this.checkBoxRight.Size = new System.Drawing.Size(51, 17);
		this.checkBoxRight.TabIndex = 4;
		this.checkBoxRight.Text = "Right";
		this.checkBoxRight.UseVisualStyleBackColor = true;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(9, 35);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(53, 13);
		this.label1.TabIndex = 5;
		this.label1.Text = "---- OR ----";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.label1);
		base.Controls.Add(this.checkBoxTop);
		base.Controls.Add(this.checkBoxRight);
		base.Controls.Add(this.checkBoxBottom);
		base.Controls.Add(this.checkBoxInherit);
		base.Controls.Add(this.checkBoxLeft);
		base.Name = "PaletteDrawBordersSelector";
		base.Size = new System.Drawing.Size(76, 146);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
