using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class RasterViewSurrogate : ViewSurrogate
{
	internal int dpiOld;

	public byte DisplayMode;

	internal bool shadowOld;

	internal byte freezeAlphaOld;

	public RasterViewSurrogate(RasterView rasterView)
		: base(rasterView)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return _0023_003DzC3X1_iZp12rj();
		}
		RasterView rasterView = new RasterView(this);
		CopyDataToObject(rasterView);
		return rasterView;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is RasterView rasterView)
		{
			if (base.Version < 20)
			{
				rasterView.Dpi = dpiOld;
				rasterView.Shadow = shadowOld;
				rasterView.FreezeAlpha = freezeAlphaOld;
			}
			rasterView.DisplayMode = (displayType)DisplayMode;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		RasterView rasterView = (RasterView)entity;
		dpiOld = rasterView.Dpi;
		DisplayMode = (byte)rasterView.DisplayMode;
		shadowOld = rasterView.Shadow;
		freezeAlphaOld = rasterView.FreezeAlpha;
		base.CopyDataFromObject(entity);
	}
}
