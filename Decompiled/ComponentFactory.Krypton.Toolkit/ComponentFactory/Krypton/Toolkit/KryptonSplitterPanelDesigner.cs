using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSplitterPanelDesigner : KryptonPanelDesigner, IKryptonDesignerSelect
{
	private KryptonSplitterPanel _panel;

	private ISelectionService _selectionService;

	public override SelectionRules SelectionRules
	{
		get
		{
			if (Control.Parent is KryptonSplitContainer)
			{
				return SelectionRules.Locked;
			}
			return SelectionRules.None;
		}
	}

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
		_panel = component as KryptonSplitterPanel;
		_selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		if (componentChangeService != null)
		{
			componentChangeService.ComponentChanged += OnComponentChanged;
		}
		if (_panel != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(component)["Locked"];
			if (propertyDescriptor != null && _panel.Parent is KryptonSplitContainer)
			{
				propertyDescriptor.SetValue(component, true);
			}
		}
	}

	public override bool CanBeParentedTo(IDesigner parentDesigner)
	{
		return parentDesigner is KryptonSplitContainerDesigner;
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
			if (disposing)
			{
				IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
				if (componentChangeService != null)
				{
					componentChangeService.ComponentChanged -= OnComponentChanged;
				}
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	protected override void OnPaintAdornments(PaintEventArgs pe)
	{
		base.OnPaintAdornments(pe);
		if (_panel != null && _panel.Controls.Count == 0)
		{
			DrawWaterMark(pe.Graphics);
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

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		if (_panel == null || _panel.Parent == null)
		{
			return;
		}
		if (_panel.Controls.Count == 0)
		{
			using (Graphics g = _panel.CreateGraphics())
			{
				DrawWaterMark(g);
				return;
			}
		}
		_panel.Invalidate();
	}

	private void DrawWaterMark(Graphics g)
	{
		Rectangle clientRectangle = Control.ClientRectangle;
		string name = Control.Name;
		using Font font = new Font("Arial", 8f);
		try
		{
			SizeF sizeF = g.MeasureString(name, font);
			int x = clientRectangle.Width / 2 - (int)sizeF.Width / 2;
			int y = clientRectangle.Height / 2 - (int)sizeF.Height / 2;
			TextRenderer.DrawText(g, name, font, new Point(x, y), Color.Black, TextFormatFlags.Default);
		}
		catch
		{
		}
	}
}
