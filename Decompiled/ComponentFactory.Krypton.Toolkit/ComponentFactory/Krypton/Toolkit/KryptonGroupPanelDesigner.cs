using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonGroupPanelDesigner : KryptonPanelDesigner, IKryptonDesignerSelect
{
	private KryptonGroupPanel _panel;

	private ISelectionService _selectionService;

	public override SelectionRules SelectionRules
	{
		get
		{
			if (Control.Parent is KryptonGroup || Control.Parent is KryptonHeaderGroup)
			{
				return SelectionRules.Locked;
			}
			return SelectionRules.None;
		}
	}

	public override IList SnapLines
	{
		get
		{
			ArrayList snapLines = null;
			AddPaddingSnapLines(ref snapLines);
			return snapLines;
		}
	}

	public override DesignerActionListCollection ActionLists => new DesignerActionListCollection();

	public bool CanPaint => true;

	protected override InheritanceAttribute InheritanceAttribute
	{
		get
		{
			if (_panel != null && _panel.Parent != null)
			{
				return (InheritanceAttribute)TypeDescriptor.GetAttributes(_panel.Parent)[typeof(InheritanceAttribute)];
			}
			return base.InheritanceAttribute;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_panel = component as KryptonGroupPanel;
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (_panel != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(component)["Locked"];
			if (propertyDescriptor != null && (_panel.Parent is KryptonGroup || _panel.Parent is KryptonHeaderGroup))
			{
				propertyDescriptor.SetValue(component, true);
			}
		}
	}

	public override bool CanBeParentedTo(IDesigner parentDesigner)
	{
		return parentDesigner is KryptonGroup || parentDesigner is KryptonHeaderGroup;
	}

	public void SelectParentControl()
	{
		if (_panel != null && _panel.Parent != null)
		{
			_selectionService.SetSelectedComponents(new object[1] { _panel.Parent }, SelectionTypes.Click);
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (!disposing)
			{
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	protected override void PreFilterProperties(IDictionary properties)
	{
		base.PreFilterProperties(properties);
		properties.Remove("Modifiers");
		properties.Remove("Locked");
		properties.Remove("GenerateMember");
		foreach (DictionaryEntry property in properties)
		{
			PropertyDescriptor propertyDescriptor = (PropertyDescriptor)property.Value;
			if (propertyDescriptor.Name.Equals("Name") && propertyDescriptor.DesignTimeOnly)
			{
				Attribute[] attributes = new Attribute[2]
				{
					BrowsableAttribute.No,
					DesignerSerializationVisibilityAttribute.Hidden
				};
				properties[property.Key] = TypeDescriptor.CreateProperty(propertyDescriptor.ComponentType, propertyDescriptor, attributes);
				break;
			}
		}
	}
}
