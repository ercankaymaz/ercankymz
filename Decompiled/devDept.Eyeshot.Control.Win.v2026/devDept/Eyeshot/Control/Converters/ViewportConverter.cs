using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class ViewportConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is Viewport && destinationType == typeof(InstanceDescriptor))
		{
			Viewport viewport = (Viewport)value;
			object[] array = new object[21];
			Type[] array2 = new Type[21];
			int num = 0;
			array2[num] = typeof(Point);
			array[num++] = viewport.Location;
			array2[num] = typeof(Size);
			array[num++] = viewport.Size;
			array2[num] = typeof(BackgroundSettings);
			array[num++] = viewport.Background;
			array2[num] = typeof(Camera);
			array[num++] = viewport.Camera;
			array2[num] = typeof(ToolBar[]);
			array[num++] = viewport.ToolBars;
			array2[num] = typeof(Legend[]);
			int num2 = num++;
			Legend[] legends = viewport.Legends;
			array[num2] = ((legends == null || legends.Length != 0) ? viewport.Legends : new Legend[1]
			{
				new Legend
				{
					Visible = false
				}
			});
			array2[num] = typeof(Histogram);
			array[num++] = viewport.Histogram;
			array2[num] = typeof(displayType);
			array[num++] = viewport.DisplayMode;
			array2[num] = typeof(bool);
			array[num++] = viewport.ShowLabels;
			array2[num] = typeof(bool);
			array[num++] = viewport.ShowVertices;
			array2[num] = typeof(bool);
			array[num++] = viewport.ShowVertexIndices;
			array2[num] = typeof(Grid[]);
			array[num++] = viewport.Grids;
			array2[num] = typeof(OriginSymbol[]);
			array[num++] = viewport.OriginSymbols;
			array2[num] = typeof(bool);
			array[num++] = viewport.SortLabels;
			array2[num] = typeof(RotateSettings);
			array[num++] = viewport.Rotate;
			array2[num] = typeof(ZoomSettings);
			array[num++] = viewport.Zoom;
			array2[num] = typeof(PanSettings);
			array[num++] = viewport.Pan;
			array2[num] = typeof(NavigationSettings);
			array[num++] = viewport.Navigation;
			array2[num] = typeof(CoordinateSystemIcon);
			array[num++] = viewport.CoordinateSystemIcon;
			array2[num] = typeof(ViewCubeIcon);
			array[num++] = viewport.ViewCubeIcon;
			array2[num] = typeof(ScaleBar);
			array[num++] = viewport.ScaleBar;
			return new InstanceDescriptor(typeof(Viewport).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
