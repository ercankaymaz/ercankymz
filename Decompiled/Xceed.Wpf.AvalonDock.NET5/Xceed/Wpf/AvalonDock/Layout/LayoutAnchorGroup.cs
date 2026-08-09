using System;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("Children")]
public class LayoutAnchorGroup : LayoutGroup<LayoutAnchorable>, ILayoutPreviousContainer, ILayoutPaneSerializable
{
	[NonSerialized]
	private ILayoutContainer _previousContainer;

	private string _id;

	[XmlIgnore]
	ILayoutContainer ILayoutPreviousContainer.PreviousContainer
	{
		get
		{
			return _previousContainer;
		}
		set
		{
			if (_previousContainer != value)
			{
				_previousContainer = value;
				RaisePropertyChanged("PreviousContainer");
				if (_previousContainer is ILayoutPaneSerializable { Id: null } layoutPaneSerializable)
				{
					layoutPaneSerializable.Id = Guid.NewGuid().ToString();
				}
			}
		}
	}

	string ILayoutPreviousContainer.PreviousContainerId { get; set; }

	string ILayoutPaneSerializable.Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	protected override bool GetVisibility()
	{
		return base.Children.Count > 0;
	}

	public override void WriteXml(XmlWriter writer)
	{
		if (_id != null)
		{
			writer.WriteAttributeString("Id", _id);
		}
		if (_previousContainer != null && _previousContainer is ILayoutPaneSerializable layoutPaneSerializable)
		{
			writer.WriteAttributeString("PreviousContainerId", layoutPaneSerializable.Id);
		}
		base.WriteXml(writer);
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("Id"))
		{
			_id = reader.Value;
		}
		if (reader.MoveToAttribute("PreviousContainerId"))
		{
			((ILayoutPreviousContainer)this).PreviousContainerId = reader.Value;
		}
		base.ReadXml(reader);
	}
}
