using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
[Obsolete("Use VectorView with Shaded flag to true.")]
public class RasterView : View
{
	private displayType _displayMode = displayType.Rendered;

	public displayType DisplayMode
	{
		get
		{
			return _displayMode;
		}
		set
		{
			_displayMode = value;
			_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	public override double Scale
	{
		get
		{
			return base.Scale;
		}
		set
		{
			if (value != 0.0)
			{
				base.Scale = value;
				_0023_003DzDaxeAiK9rC4V(_0023_003DzPzO_0024GUk_003D: true);
			}
		}
	}

	internal override AutodeskProperties.visualStyleType visualStyleMode
	{
		get
		{
			if (AutodeskProperties != null)
			{
				return AutodeskProperties.VisualStyleMode;
			}
			return DisplayMode switch
			{
				displayType.Wireframe => AutodeskProperties.visualStyleType.Wireframe, 
				displayType.Shaded => AutodeskProperties.visualStyleType.ShadedWithEdges, 
				displayType.Rendered => AutodeskProperties.visualStyleType.Realistic, 
				displayType.Flat => AutodeskProperties.visualStyleType.Conceptual, 
				displayType.HiddenLines => AutodeskProperties.visualStyleType.Hidden, 
				_ => AutodeskProperties.visualStyleType.Realistic, 
			};
		}
		set
		{
			if (AutodeskProperties == null)
			{
				AutodeskProperties = new AutodeskProperties();
			}
			AutodeskProperties.VisualStyleMode = value;
		}
	}

	public RasterView(double x, double y, viewType standardView, double scale, string name, double width = 0.0, double height = 0.0)
		: base(x, y, standardView, scale, name, width, height)
	{
	}

	public RasterView(double x, double y, Camera camera, double scale, string name, double width = 0.0, double height = 0.0)
		: base(x, y, camera, scale, name, width, height)
	{
	}

	public RasterView(double x, double y, Camera camera, double scale, string name, Size viewportSize)
		: base(x, y, camera, scale, name, viewportSize)
	{
	}

	public RasterView(double x, double y, Camera camera, double scale, string name, RectangleF window, Size viewportSize)
		: base(x, y, camera, scale, name, window, viewportSize)
	{
	}

	public RasterView(RasterView another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_displayMode = another._displayMode;
	}

	protected internal RasterView(RasterViewSurrogate surrogate)
		: base(surrogate)
	{
	}

	protected RasterView(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_displayMode = (displayType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975546), typeof(displayType));
	}

	public override object Clone()
	{
		return new RasterView(this);
	}

	public override object CloneWithTessellation()
	{
		return new RasterView(this, RegenMode != regenType.RegenAndCompile);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new RasterViewSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302975546), _displayMode);
	}
}
