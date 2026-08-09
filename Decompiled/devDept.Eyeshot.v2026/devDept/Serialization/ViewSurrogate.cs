using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class ViewSurrogate(View view) : BlockReferenceSurrogate(view)
{
	public double X;

	public double Y;

	public Camera Camera;

	public byte ViewType;

	public double Scale;

	public double Width;

	public double Height;

	public RectangleF Window;

	public Point3D WindowCenter;

	public bool HasChanged;

	public List<Tuple<List<BlockReference>, Entity>> EntitiesToHide = new List<Tuple<List<BlockReference>, Entity>>();

	public int Dpi;

	public bool Shadow;

	public byte FreezeAlpha;

	internal Size viewportSize;

	protected override Entity ConvertToObject()
	{
		WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673159) + Type + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
		return null;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is View view)
		{
			view.X = X;
			view.Y = Y;
			view._0023_003DzXs_0024UXorrEwQq(Camera);
			view.ViewType = (viewType)ViewType;
			view.Scale = Scale;
			view._0023_003DzUBcyrssJEGAK(Width);
			view._0023_003DzBEcDMzq6J80l(Height);
			view._0023_003DzBZEKdN8_003D(Window);
			view.WindowCenter = WindowCenter;
			if (base.Version >= 20)
			{
				view.Dpi = Dpi;
				view.Shadow = Shadow;
				view.FreezeAlpha = FreezeAlpha;
			}
			view._0023_003DzDaxeAiK9rC4V(base.Content == contentType.Geometry || HasChanged);
			view.EntitiesToHide = _0023_003Dz63jQZiCoqdOn(EntitiesToHide);
			view.viewportSize = ((base.Version < 19) ? new Size(5000, 5000) : viewportSize);
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		View view = (View)entity;
		X = view.X;
		Y = view.Y;
		Camera = view.Camera;
		ViewType = (byte)view.ViewType;
		Scale = view.Scale;
		Width = view.Width;
		Height = view.Height;
		Window = view.Window;
		WindowCenter = view.WindowCenter;
		Dpi = view.Dpi;
		Shadow = view.Shadow;
		FreezeAlpha = view.FreezeAlpha;
		HasChanged = view.HasChanged;
		EntitiesToHide = _0023_003DzU8nPn4pMGQYl(view.EntitiesToHide);
		viewportSize = view.viewportSize;
		base.CopyDataFromObject(entity);
	}

	private static List<Tuple<List<BlockReference>, Entity>> _0023_003DzU8nPn4pMGQYl(List<Tuple<Stack<BlockReference>, Entity>> _0023_003DzPLc__OVH8sIO)
	{
		List<Tuple<List<BlockReference>, Entity>> list = new List<Tuple<List<BlockReference>, Entity>>();
		foreach (Tuple<Stack<BlockReference>, Entity> item in _0023_003DzPLc__OVH8sIO)
		{
			list.Add(new Tuple<List<BlockReference>, Entity>(item.Item1.ToList(), item.Item2));
		}
		return list;
	}

	private static List<Tuple<Stack<BlockReference>, Entity>> _0023_003Dz63jQZiCoqdOn(List<Tuple<List<BlockReference>, Entity>> _0023_003DzTfokzf66VV0F)
	{
		List<Tuple<Stack<BlockReference>, Entity>> list = new List<Tuple<Stack<BlockReference>, Entity>>();
		if (_0023_003DzTfokzf66VV0F != null)
		{
			foreach (Tuple<List<BlockReference>, Entity> item in _0023_003DzTfokzf66VV0F)
			{
				List<BlockReference> list2 = ((item.Item1 == null) ? new List<BlockReference>() : item.Item1.ToList());
				list2.Reverse();
				list.Add(new Tuple<Stack<BlockReference>, Entity>(new Stack<BlockReference>(list2), item.Item2));
			}
		}
		return list;
	}
}
