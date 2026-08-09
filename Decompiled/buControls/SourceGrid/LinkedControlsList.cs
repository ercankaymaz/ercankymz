using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using ns27;

namespace SourceGrid;

public class LinkedControlsList : IEnumerable, IEnumerable<LinkedControlValue>
{
	internal Control parent;

	private List<LinkedControlValue> list_0 = new List<LinkedControlValue>();

	public LinkedControlsList(Control parent)
	{
		this.parent = parent;
	}

	public void Clear()
	{
		foreach (LinkedControlValue item in list_0)
		{
			Class76.smethod_816(item, this);
		}
		list_0.Clear();
	}

	public void Add(LinkedControlValue linkedControl)
	{
		list_0.Add(linkedControl);
		parent.Controls.Add(linkedControl.Control);
	}

	public void Remove(LinkedControlValue linkedControl)
	{
		list_0.Remove(linkedControl);
		Class76.smethod_816(linkedControl, this);
	}

	public LinkedControlValue GetByControl(Control control)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			if (control == list_0[i].Control)
			{
				return list_0[i];
			}
		}
		return null;
	}

	public IEnumerator<LinkedControlValue> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
