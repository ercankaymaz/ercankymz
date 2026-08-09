using System;
using System.Reflection;

namespace SourceGrid.Cells.Controllers;

public class BindProperty : ControllerBase
{
	private PropertyInfo propertyInfo_0 = null;

	private object object_0 = null;

	public BindProperty(PropertyInfo p_Property, object p_LinkObject)
	{
		BindValueAtProperty(p_Property, p_LinkObject);
	}

	public override void OnValueChanged(CellContext sender, EventArgs e)
	{
		base.OnValueChanged(sender, e);
		if (propertyInfo_0 != null)
		{
			propertyInfo_0.SetValue(object_0, sender.Cell.Model.ValueModel.GetValue(sender), null);
		}
	}

	protected virtual void BindValueAtProperty(PropertyInfo p_Property, object p_LinkObject)
	{
		propertyInfo_0 = p_Property;
		object_0 = p_LinkObject;
	}

	protected virtual void UnBindValueAtProperty()
	{
		propertyInfo_0 = null;
		object_0 = null;
	}
}
