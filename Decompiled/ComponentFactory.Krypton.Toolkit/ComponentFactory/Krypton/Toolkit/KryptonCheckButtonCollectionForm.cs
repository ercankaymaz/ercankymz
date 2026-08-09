#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckButtonCollectionForm : Form
{
	private class ListEntry
	{
		private KryptonCheckButton _checkButton;

		public KryptonCheckButton CheckButton => _checkButton;

		public ListEntry(KryptonCheckButton checkButton)
		{
			Debug.Assert(checkButton != null);
			_checkButton = checkButton;
		}

		public override string ToString()
		{
			return _checkButton.Site.Name + "  (Text: " + _checkButton.Text + ")";
		}
	}

	private KryptonCheckSet _checkSet;

	private IContainer components = null;

	private CheckedListBox checkedListBox;

	private Button buttonOK;

	private Button buttonCancel;

	private Label label;

	public KryptonCheckButtonCollectionForm()
		: this(null)
	{
	}

	public KryptonCheckButtonCollectionForm(KryptonCheckSet checkSet)
	{
		_checkSet = checkSet;
		InitializeComponent();
	}

	private void KryptonCheckButtonCollectionForm_Load(object sender, EventArgs e)
	{
		IContainer container = _checkSet.Container;
		if (container == null)
		{
			return;
		}
		foreach (object component in container.Components)
		{
			if (component is KryptonCheckButton)
			{
				KryptonCheckButton checkButton = (KryptonCheckButton)component;
				checkedListBox.Items.Add(new ListEntry(checkButton), _checkSet.CheckButtons.Contains(checkButton));
			}
		}
	}

	private void buttonOK_Click(object sender, EventArgs e)
	{
		List<KryptonCheckButton> list = new List<KryptonCheckButton>();
		foreach (KryptonCheckButton checkButton in _checkSet.CheckButtons)
		{
			list.Add(checkButton);
		}
		for (int i = 0; i < checkedListBox.Items.Count; i++)
		{
			ListEntry listEntry = (ListEntry)checkedListBox.Items[i];
			if (checkedListBox.GetItemChecked(i))
			{
				if (!_checkSet.CheckButtons.Contains(listEntry.CheckButton))
				{
					_checkSet.CheckButtons.Add(listEntry.CheckButton);
				}
				else
				{
					list.Remove(listEntry.CheckButton);
				}
			}
			else if (_checkSet.CheckButtons.Contains(listEntry.CheckButton))
			{
				_checkSet.CheckButtons.Remove(listEntry.CheckButton);
				list.Remove(listEntry.CheckButton);
			}
		}
		foreach (KryptonCheckButton item in list)
		{
			_checkSet.CheckButtons.Remove(item);
		}
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
		this.checkedListBox = new System.Windows.Forms.CheckedListBox();
		this.buttonOK = new System.Windows.Forms.Button();
		this.buttonCancel = new System.Windows.Forms.Button();
		this.label = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.checkedListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.checkedListBox.CheckOnClick = true;
		this.checkedListBox.FormattingEnabled = true;
		this.checkedListBox.IntegralHeight = false;
		this.checkedListBox.Location = new System.Drawing.Point(12, 30);
		this.checkedListBox.Name = "checkedListBox";
		this.checkedListBox.Size = new System.Drawing.Size(281, 246);
		this.checkedListBox.TabIndex = 1;
		this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.buttonOK.Location = new System.Drawing.Point(136, 282);
		this.buttonOK.Name = "buttonOK";
		this.buttonOK.Size = new System.Drawing.Size(75, 23);
		this.buttonOK.TabIndex = 2;
		this.buttonOK.Text = "OK";
		this.buttonOK.UseVisualStyleBackColor = true;
		this.buttonOK.Click += new System.EventHandler(buttonOK_Click);
		this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Location = new System.Drawing.Point(218, 282);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new System.Drawing.Size(75, 23);
		this.buttonCancel.TabIndex = 3;
		this.buttonCancel.Text = "Cancel";
		this.buttonCancel.UseVisualStyleBackColor = true;
		this.label.AutoSize = true;
		this.label.Location = new System.Drawing.Point(9, 9);
		this.label.Name = "label";
		this.label.Size = new System.Drawing.Size(214, 13);
		this.label.TabIndex = 0;
		this.label.Text = "Select the check buttons to group together";
		base.AcceptButton = this.buttonOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.buttonCancel;
		base.ClientSize = new System.Drawing.Size(305, 317);
		base.ControlBox = false;
		base.Controls.Add(this.label);
		base.Controls.Add(this.buttonCancel);
		base.Controls.Add(this.buttonOK);
		base.Controls.Add(this.checkedListBox);
		this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.MinimumSize = new System.Drawing.Size(250, 205);
		base.Name = "KryptonCheckButtonCollectionForm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "CheckButtons Collection Editor";
		base.Load += new System.EventHandler(KryptonCheckButtonCollectionForm_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
