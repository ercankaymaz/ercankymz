using System;
using System.Collections.Generic;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Container : ContainerBase
{
	private VisualElementList mElements = new VisualElementList();

	public new IBorder Border
	{
		get
		{
			return base.Border;
		}
		set
		{
			base.Border = value;
		}
	}

	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	public new IVisualElement Background
	{
		get
		{
			return base.Background;
		}
		set
		{
			base.Background = value;
		}
	}

	public new ElementsDrawMode ElementsDrawMode
	{
		get
		{
			return base.ElementsDrawMode;
		}
		set
		{
			base.ElementsDrawMode = value;
		}
	}

	public virtual VisualElementList Elements
	{
		get
		{
			return mElements;
		}
		set
		{
			mElements = value;
		}
	}

	public Container()
	{
	}

	public Container(Container other)
		: base(other)
	{
		if (other.Elements == null)
		{
			Elements = null;
		}
		else
		{
			Elements = (VisualElementList)other.Elements.Clone();
		}
	}

	protected override IEnumerable<IVisualElement> GetElements()
	{
		return Elements;
	}

	public override object Clone()
	{
		return new Container(this);
	}
}
