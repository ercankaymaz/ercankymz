using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonHeaderGroupActionList : DesignerActionList
{
	private KryptonHeaderGroup _headerGroup;

	private IComponentChangeService _service;

	private DesignerVerb _visible1;

	private DesignerVerb _visible2;

	private string _text1;

	private string _text2;

	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _headerGroup.GroupBackStyle;
		}
		set
		{
			if (_headerGroup.GroupBackStyle != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.GroupBackStyle, value);
				_headerGroup.GroupBackStyle = value;
			}
		}
	}

	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _headerGroup.GroupBorderStyle;
		}
		set
		{
			if (_headerGroup.GroupBorderStyle != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.GroupBorderStyle, value);
				_headerGroup.GroupBorderStyle = value;
			}
		}
	}

	public HeaderStyle HeaderStylePrimary
	{
		get
		{
			return _headerGroup.HeaderStylePrimary;
		}
		set
		{
			if (_headerGroup.HeaderStylePrimary != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.HeaderStylePrimary, value);
				_headerGroup.HeaderStylePrimary = value;
			}
		}
	}

	public HeaderStyle HeaderStyleSecondary
	{
		get
		{
			return _headerGroup.HeaderStyleSecondary;
		}
		set
		{
			if (_headerGroup.HeaderStyleSecondary != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.HeaderStyleSecondary, value);
				_headerGroup.HeaderStyleSecondary = value;
			}
		}
	}

	public VisualOrientation HeaderPositionPrimary
	{
		get
		{
			return _headerGroup.HeaderPositionPrimary;
		}
		set
		{
			if (_headerGroup.HeaderPositionPrimary != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.HeaderPositionPrimary, value);
				_headerGroup.HeaderPositionPrimary = value;
			}
		}
	}

	public VisualOrientation HeaderPositionSecondary
	{
		get
		{
			return _headerGroup.HeaderPositionSecondary;
		}
		set
		{
			if (_headerGroup.HeaderPositionSecondary != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.HeaderPositionSecondary, value);
				_headerGroup.HeaderPositionSecondary = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _headerGroup.PaletteMode;
		}
		set
		{
			if (_headerGroup.PaletteMode != value)
			{
				_service.OnComponentChanged(_headerGroup, null, _headerGroup.PaletteMode, value);
				_headerGroup.PaletteMode = value;
			}
		}
	}

	public KryptonHeaderGroupActionList(KryptonHeaderGroupDesigner owner)
		: base(owner.Component)
	{
		_headerGroup = owner.Component as KryptonHeaderGroup;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_headerGroup != null)
		{
			bool headerVisiblePrimary = _headerGroup.HeaderVisiblePrimary;
			bool headerVisibleSecondary = _headerGroup.HeaderVisibleSecondary;
			_text1 = (headerVisiblePrimary ? "Hide primary header" : "Show primary header");
			_text2 = (headerVisibleSecondary ? "Hide secondary header" : "Show secondary header");
			_visible1 = new DesignerVerb(_text1, OnVisibleClick);
			_visible2 = new DesignerVerb(_text2, OnVisibleClick);
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GroupBackStyle", "Back style", "Appearance", "Background style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GroupBorderStyle", "Border style", "Appearance", "Border style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Primary Header"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(_visible1, "Primary Header"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("HeaderStylePrimary", "Style", "Primary Header", "Primary header style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("HeaderPositionPrimary", "Position", "Primary Header", "Primary header position"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Secondary Header"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(_visible2, "Secondary Header"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("HeaderStyleSecondary", "Style", "Secondary Header", "Secondary header style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("HeaderPositionSecondary", "Position", "Secondary Header", "Secondary header position"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}

	private void OnVisibleClick(object sender, EventArgs e)
	{
		DesignerVerb designerVerb = sender as DesignerVerb;
		bool flag = designerVerb == _visible1;
		bool flag2 = !(flag ? _headerGroup.HeaderVisiblePrimary : _headerGroup.HeaderVisibleSecondary);
		if (flag)
		{
			_text1 = (flag2 ? "Hide primary header" : "Show primary header");
		}
		else
		{
			_text2 = (flag2 ? "Hide secondary header" : "Show secondary header");
		}
		if (flag)
		{
			_headerGroup.HeaderVisiblePrimary = flag2;
		}
		else
		{
			_headerGroup.HeaderVisibleSecondary = flag2;
		}
		if (GetService(typeof(DesignerActionUIService)) is DesignerActionUIService designerActionUIService)
		{
			designerActionUIService.Refresh(_headerGroup);
		}
	}
}
