using System;
using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonLinkLabelActionList : DesignerActionList
{
	private KryptonLinkLabel _linkLabel;

	private IComponentChangeService _service;

	private string _action;

	public LabelStyle LabelStyle
	{
		get
		{
			return _linkLabel.LabelStyle;
		}
		set
		{
			if (_linkLabel.LabelStyle != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.LabelStyle, value);
				_linkLabel.LabelStyle = value;
			}
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _linkLabel.Orientation;
		}
		set
		{
			if (_linkLabel.Orientation != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.Orientation, value);
				_linkLabel.Orientation = value;
			}
		}
	}

	public KryptonLinkBehavior LinkBehavior
	{
		get
		{
			return _linkLabel.LinkBehavior;
		}
		set
		{
			if (_linkLabel.LinkBehavior != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.LinkBehavior, value);
				_linkLabel.LinkBehavior = value;
			}
		}
	}

	public bool LinkVisited
	{
		get
		{
			return _linkLabel.LinkVisited;
		}
		set
		{
			if (_linkLabel.LinkVisited != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.LinkVisited, value);
				_linkLabel.LinkVisited = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _linkLabel.Values.Text;
		}
		set
		{
			if (_linkLabel.Values.Text != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.Values.Text, value);
				_linkLabel.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _linkLabel.Values.ExtraText;
		}
		set
		{
			if (_linkLabel.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.Values.ExtraText, value);
				_linkLabel.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _linkLabel.Values.Image;
		}
		set
		{
			if (_linkLabel.Values.Image != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.Values.Image, value);
				_linkLabel.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _linkLabel.PaletteMode;
		}
		set
		{
			if (_linkLabel.PaletteMode != value)
			{
				_service.OnComponentChanged(_linkLabel, null, _linkLabel.PaletteMode, value);
				_linkLabel.PaletteMode = value;
			}
		}
	}

	public KryptonLinkLabelActionList(KryptonLinkLabelDesigner owner)
		: base(owner.Component)
	{
		_linkLabel = owner.Component as KryptonLinkLabel;
		if (_linkLabel != null)
		{
			if (_linkLabel.LinkVisited)
			{
				_action = "Link has not been visited";
			}
			else
			{
				_action = "Link has been visited";
			}
		}
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_linkLabel != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LabelStyle", "Style", "Appearance", "Label style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Visual orientation"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LinkBehavior", "Link Behavior", "Appearance", "Underline behavior"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb(_action, OnLinkVisitedClick), "Appearance"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Label text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Label extra text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Label image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}

	private void OnLinkVisitedClick(object sender, EventArgs e)
	{
		if (sender is DesignerVerb)
		{
			_linkLabel.LinkVisited = !_linkLabel.LinkVisited;
			if (_linkLabel.LinkVisited)
			{
				_action = "Link has not been visited";
			}
			else
			{
				_action = "Link has been visited";
			}
			if (GetService(typeof(DesignerActionUIService)) is DesignerActionUIService designerActionUIService)
			{
				designerActionUIService.Refresh(_linkLabel);
			}
		}
	}
}
