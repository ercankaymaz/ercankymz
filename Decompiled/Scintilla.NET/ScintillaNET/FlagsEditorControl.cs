using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ScintillaNET;

internal class FlagsEditorControl : UserControl
{
	private readonly Type enumType;

	private readonly Enum initialValue;

	private readonly IWindowsFormsEditorService editorService;

	private int inCheck;

	private IContainer components;

	private FlowLayoutPanel flowLayoutPanel_CheckBoxList;

	private TableLayoutPanel tableLayoutPanel;

	private Button button_Ok;

	private Button button_Cancel;

	public Enum Value { get; protected set; }

	public FlagsEditorControl()
	{
		InitializeComponent();
		button_Ok.Text = NativeMethods.GetMessageBoxString(0u);
		button_Cancel.Text = NativeMethods.GetMessageBoxString(1u);
	}

	public FlagsEditorControl(IWindowsFormsEditorService editorService, Enum value)
		: this()
	{
		this.editorService = editorService;
		enumType = value.GetType();
		Value = (initialValue = value);
		inCheck++;
		try
		{
			ulong num = CalculateEnumAllValue(enumType);
			bool flag = false;
			ulong valueBits = Convert.ToUInt64(Value);
			string[] names = Enum.GetNames(enumType);
			foreach (string text in names)
			{
				Enum obj = (Enum)Enum.Parse(enumType, text);
				ulong num2 = Convert.ToUInt64(obj);
				if (num2 == num)
				{
					flag = true;
				}
				if (num2 != 0L)
				{
					CheckBox checkBox = new CheckBox
					{
						Text = text,
						CheckState = CheckStateFromBits(num2, valueBits),
						AutoSize = true,
						Tag = obj,
						Margin = new Padding(3, 0, 3, 0),
						Padding = Padding.Empty
					};
					checkBox.CheckStateChanged += checkBox_CheckStateChanged;
					flowLayoutPanel_CheckBoxList.Controls.Add(checkBox);
				}
			}
			if (!flag)
			{
				CheckBox checkBox2 = new CheckBox
				{
					Text = "All",
					CheckState = CheckStateFromBits(num, valueBits),
					AutoSize = true,
					Tag = (Enum)Enum.ToObject(enumType, num),
					Margin = new Padding(3, 0, 3, 0),
					Padding = Padding.Empty
				};
				checkBox2.CheckStateChanged += checkBox_CheckStateChanged;
				flowLayoutPanel_CheckBoxList.Controls.Add(checkBox2);
			}
			AutoSize = true;
		}
		finally
		{
			inCheck--;
		}
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		base.OnBackColorChanged(e);
		Helpers.ApplyToControlTree(this, delegate(Control c)
		{
			if (Srgb.FromColor(c.BackColor).ToLinearSrgb().ToOkLab()
				.L < 0.5f)
			{
				c.ForeColor = Color.White;
			}
			else
			{
				c.ForeColor = Color.Black;
			}
		});
	}

	private static ulong CalculateEnumAllValue(Type enumType)
	{
		ulong num = 0uL;
		foreach (Enum value in Enum.GetValues(enumType))
		{
			num |= Convert.ToUInt64(value);
		}
		return num;
	}

	private static ulong CombineEnumBits(IEnumerable<CheckBox> checkBoxList)
	{
		ulong num = 0uL;
		foreach (CheckBox item in checkBoxList.Where((CheckBox c) => c.CheckState == CheckState.Checked))
		{
			num |= Convert.ToUInt64(item.Tag);
		}
		return num;
	}

	private void checkBox_CheckStateChanged(object sender, EventArgs e)
	{
		if (inCheck > 0)
		{
			return;
		}
		inCheck++;
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			IEnumerable<CheckBox> enumerable = flowLayoutPanel_CheckBoxList.Controls.OfType<CheckBox>();
			ulong num = CombineEnumBits(enumerable);
			ulong num2 = Convert.ToUInt64(checkBox.Tag);
			if (checkBox.CheckState == CheckState.Checked)
			{
				num |= num2;
			}
			else if (checkBox.CheckState == CheckState.Unchecked)
			{
				num &= ~num2;
			}
			Value = (Enum)Enum.ToObject(enumType, num);
			foreach (CheckBox item in enumerable)
			{
				ulong itemBits = Convert.ToUInt64(item.Tag);
				item.CheckState = CheckStateFromBits(itemBits, num);
			}
		}
		finally
		{
			inCheck--;
		}
	}

	private static CheckState CheckStateFromBits(ulong itemBits, ulong valueBits)
	{
		if ((itemBits & valueBits) != itemBits)
		{
			if ((itemBits & valueBits) != 0L)
			{
				return CheckState.Indeterminate;
			}
			return CheckState.Unchecked;
		}
		return CheckState.Checked;
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		switch (keyData)
		{
		case Keys.Return:
			button_Ok_Click(button_Ok, EventArgs.Empty);
			return true;
		case Keys.Escape:
			button_Cancel_Click(button_Cancel, EventArgs.Empty);
			return true;
		default:
			return base.ProcessDialogKey(keyData);
		}
	}

	private void button_Ok_Click(object sender, EventArgs e)
	{
		editorService.CloseDropDown();
	}

	private void button_Cancel_Click(object sender, EventArgs e)
	{
		Value = initialValue;
		editorService.CloseDropDown();
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
		this.flowLayoutPanel_CheckBoxList = new System.Windows.Forms.FlowLayoutPanel();
		this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
		this.button_Ok = new System.Windows.Forms.Button();
		this.button_Cancel = new System.Windows.Forms.Button();
		this.tableLayoutPanel.SuspendLayout();
		base.SuspendLayout();
		this.flowLayoutPanel_CheckBoxList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.flowLayoutPanel_CheckBoxList.AutoScroll = true;
		this.flowLayoutPanel_CheckBoxList.AutoSize = true;
		this.flowLayoutPanel_CheckBoxList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.tableLayoutPanel.SetColumnSpan(this.flowLayoutPanel_CheckBoxList, 2);
		this.flowLayoutPanel_CheckBoxList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		this.flowLayoutPanel_CheckBoxList.Location = new System.Drawing.Point(0, 0);
		this.flowLayoutPanel_CheckBoxList.Margin = new System.Windows.Forms.Padding(0);
		this.flowLayoutPanel_CheckBoxList.Name = "flowLayoutPanel_CheckBoxList";
		this.flowLayoutPanel_CheckBoxList.Size = new System.Drawing.Size(150, 124);
		this.flowLayoutPanel_CheckBoxList.TabIndex = 0;
		this.flowLayoutPanel_CheckBoxList.WrapContents = false;
		this.tableLayoutPanel.AutoSize = true;
		this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.tableLayoutPanel.ColumnCount = 2;
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel_CheckBoxList, 0, 0);
		this.tableLayoutPanel.Controls.Add(this.button_Ok, 0, 1);
		this.tableLayoutPanel.Controls.Add(this.button_Cancel, 1, 1);
		this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel.Name = "tableLayoutPanel";
		this.tableLayoutPanel.RowCount = 2;
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
		this.tableLayoutPanel.Size = new System.Drawing.Size(150, 150);
		this.tableLayoutPanel.TabIndex = 0;
		this.button_Ok.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button_Ok.AutoSize = true;
		this.button_Ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.button_Ok.Location = new System.Drawing.Point(0, 124);
		this.button_Ok.Margin = new System.Windows.Forms.Padding(0);
		this.button_Ok.Name = "button_Ok";
		this.button_Ok.Size = new System.Drawing.Size(75, 26);
		this.button_Ok.TabIndex = 1;
		this.button_Ok.Text = "OK";
		this.button_Ok.UseVisualStyleBackColor = false;
		this.button_Ok.Click += new System.EventHandler(button_Ok_Click);
		this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button_Cancel.AutoSize = true;
		this.button_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.button_Cancel.Location = new System.Drawing.Point(75, 124);
		this.button_Cancel.Margin = new System.Windows.Forms.Padding(0);
		this.button_Cancel.Name = "button_Cancel";
		this.button_Cancel.Size = new System.Drawing.Size(75, 26);
		this.button_Cancel.TabIndex = 1;
		this.button_Cancel.Text = "Cancel";
		this.button_Cancel.UseVisualStyleBackColor = false;
		this.button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		base.Controls.Add(this.tableLayoutPanel);
		base.Name = "FlagsEditorControl";
		this.tableLayoutPanel.ResumeLayout(false);
		this.tableLayoutPanel.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
