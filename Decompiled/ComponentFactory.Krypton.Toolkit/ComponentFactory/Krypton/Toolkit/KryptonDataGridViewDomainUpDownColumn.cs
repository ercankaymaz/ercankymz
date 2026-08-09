using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[Designer("ComponentFactory.Krypton.Toolkit.KryptonDomainUpDownColumnDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[ToolboxBitmap(typeof(KryptonDataGridViewDomainUpDownColumn), "ToolboxBitmaps.KryptonDomainUpDown.bmp")]
public class KryptonDataGridViewDomainUpDownColumn : DataGridViewColumn
{
	private DataGridViewColumnSpecCollection _buttonSpecs;

	private StringCollection _items;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DataGridViewCell CellTemplate
	{
		get
		{
			return base.CellTemplate;
		}
		set
		{
			KryptonDataGridViewDomainUpDownCell kryptonDataGridViewDomainUpDownCell = value as KryptonDataGridViewDomainUpDownCell;
			if (value != null && kryptonDataGridViewDomainUpDownCell == null)
			{
				throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewDomainUpDownCell or derive from it.");
			}
			base.CellTemplate = value;
		}
	}

	[Category("Data")]
	[Description("Set of extra button specs to appear with control.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewColumnSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Data")]
	[Description("The allowable items of the domain up down.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public StringCollection Items => _items;

	private KryptonDataGridViewDomainUpDownCell DomainUpDownCellTemplate => (KryptonDataGridViewDomainUpDownCell)CellTemplate;

	public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick;

	public KryptonDataGridViewDomainUpDownColumn()
		: base(new KryptonDataGridViewDomainUpDownCell())
	{
		_buttonSpecs = new DataGridViewColumnSpecCollection(this);
		_items = new StringCollection();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Append("KryptonDataGridViewDomainUpDownColumn { Name=");
		stringBuilder.Append(base.Name);
		stringBuilder.Append(", Index=");
		stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	public override object Clone()
	{
		KryptonDataGridViewDomainUpDownColumn kryptonDataGridViewDomainUpDownColumn = base.Clone() as KryptonDataGridViewDomainUpDownColumn;
		string[] array = new string[Items.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Items[i];
		}
		kryptonDataGridViewDomainUpDownColumn.Items.AddRange(array);
		foreach (ButtonSpecAny buttonSpec in ButtonSpecs)
		{
			kryptonDataGridViewDomainUpDownColumn.ButtonSpecs.Add(buttonSpec.Clone());
		}
		return kryptonDataGridViewDomainUpDownColumn;
	}

	internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
	{
		if (this.ButtonSpecClick != null)
		{
			this.ButtonSpecClick(this, args);
		}
	}
}
