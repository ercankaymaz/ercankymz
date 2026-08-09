using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

[Serializable]
[TypeConverter(typeof(ClippingPlaneConverter))]
public class ClippingPlane : ClippingPlaneBase
{
	public enum cappingType
	{
		None,
		SingleColor,
		EntityColor
	}

	private cappingType _cappingMode = cappingType.SingleColor;

	internal IWorkspaceInternal workspace;

	internal Entity clippingPlaneMesh;

	public cappingType CappingMode
	{
		get
		{
			return _cappingMode;
		}
		set
		{
			_cappingMode = value;
			if (_cappingMode != cappingType.None && workspace != null)
			{
				BuildClippingPlaneMesh(CappingColor);
			}
		}
	}

	public Color CappingColor { get; set; } = Color.Blue;

	public bool ShowPlane { get; set; } = true;

	public ClippingPlane()
	{
	}

	public ClippingPlane(Vector3D normal, double distance, bool active)
		: base(normal, distance, active)
	{
	}

	public ClippingPlane(Vector3D normal, double distance, bool active, cappingType cappingMode, Color cappingColor, bool showPlane)
		: base(normal, distance, active)
	{
		CappingColor = cappingColor;
		ShowPlane = showPlane;
		CappingMode = cappingMode;
	}

	public ClippingPlane(Plane plane, bool active)
		: base(plane, active)
	{
	}

	public void Edit(Color? planeColor, bool planeVisibilityStatus = true)
	{
		if (workspace == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951940));
		}
		Color optionalColor = planeColor ?? Color.FromArgb(63, Color.Red);
		workspace.ObjectManipulator.EditClippingPlane(this, optionalColor, planeVisibilityStatus);
	}

	public void Apply()
	{
		if (workspace == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952121));
		}
		if (workspace.ObjectManipulator.editingClippingPlane && workspace.ObjectManipulator.clippingPlane == this)
		{
			workspace.ObjectManipulator.Apply();
		}
	}

	public void Cancel()
	{
		if (workspace == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952121));
		}
		if (workspace.ObjectManipulator.editingClippingPlane && workspace.ObjectManipulator.clippingPlane == this)
		{
			workspace.ObjectManipulator.Cancel();
		}
	}

	public void Dispose()
	{
		if (clippingPlaneMesh != null)
		{
			clippingPlaneMesh.Dispose();
			clippingPlaneMesh = null;
		}
	}

	internal void BuildClippingPlaneMesh(Color _0023_003Dz1MMYB1g_003D)
	{
		double num = 0.1;
		Point3D _0023_003DzF7v9r2A_003D;
		Point3D _0023_003Dz8dK2uhU_003D;
		if (workspace.CurrentBlockReference != null || workspace.Document.isBoundingBoxDirty)
		{
			_0023_003DzeCQ_iwfWa_Rx(workspace.CurrentTransformation, workspace.Entities, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		}
		else
		{
			_0023_003DzF7v9r2A_003D = workspace.OpenBlock.Entities.BoxMin;
			_0023_003Dz8dK2uhU_003D = workspace.OpenBlock.Entities.BoxMax;
		}
		Utility.GetSizeOnPlane(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D, base.Plane, out var min, out var max);
		Size2D size2D = new Size2D(min, max);
		Point3D[] array = new Point3D[4]
		{
			new Point3D(min.X - size2D.X * num, min.Y - size2D.Y * num),
			new Point3D(max.X + size2D.X * num, min.Y - size2D.Y * num),
			new Point3D(max.X + size2D.X * num, max.Y + size2D.Y * num),
			new Point3D(min.X - size2D.X * num, max.Y + size2D.Y * num)
		};
		if (clippingPlaneMesh == null)
		{
			clippingPlaneMesh = _0023_003DzZ9YtLf3trDGKaJtr0w_003D_003D(array, _0023_003Dz1MMYB1g_003D);
			return;
		}
		clippingPlaneMesh.Color = _0023_003Dz1MMYB1g_003D;
		clippingPlaneMesh.Vertices = array;
		clippingPlaneMesh.Regen(new RegenParams(0.0, workspace));
		clippingPlaneMesh.Compile(new CompileParams(workspace));
	}

	private Mesh _0023_003DzZ9YtLf3trDGKaJtr0w_003D_003D(Point3D[] _0023_003DzZ86NWzV6mlAE, Color _0023_003Dz1MMYB1g_003D)
	{
		Mesh mesh = new Mesh(_0023_003DzZ86NWzV6mlAE, new IndexTriangle[2]
		{
			new IndexTriangle(0, 1, 2),
			new IndexTriangle(0, 2, 3)
		});
		mesh.LayerName = workspace.Layers.GetDefaultLayerName();
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = _0023_003Dz1MMYB1g_003D;
		mesh.Regen(new RegenParams(0.0, workspace));
		mesh.Compile(new CompileParams(workspace));
		return mesh;
	}

	internal void CheckAndFixDefaultLayerName()
	{
		if (workspace != null && clippingPlaneMesh != null)
		{
			workspace.Layers.CheckAndFixDefaultLayerName(clippingPlaneMesh);
		}
	}

	private void _0023_003DzeCQ_iwfWa_Rx(Transformation _0023_003Dzptomndc_003D, IList<Entity> _0023_003Dzv7xH9gk_003D, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D)
	{
		List<Point3D> list = new List<Point3D>(_0023_003Dzv7xH9gk_003D.Count * 2);
		for (int i = 0; i < _0023_003Dzv7xH9gk_003D.Count; i++)
		{
			if (_0023_003Dzv7xH9gk_003D[i].BoxMax.X >= _0023_003Dzv7xH9gk_003D[i].BoxMin.X)
			{
				list.Add(_0023_003Dzv7xH9gk_003D[i].BoxMin);
				list.Add(_0023_003Dzv7xH9gk_003D[i].BoxMax);
			}
		}
		if (_0023_003Dzptomndc_003D != null)
		{
			List<Point3D> list2 = new List<Point3D>();
			for (int j = 0; j < list.Count; j += 2)
			{
				list2.AddRange(Utility.GetBoundingBoxCorners(list[j], list[j + 1]));
			}
			list = list2;
		}
		_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
		Utility.UpdateMinMax(_0023_003Dzptomndc_003D, list, list.Count, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
	}
}
