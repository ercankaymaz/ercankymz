using Xbim.Common;

namespace Xbim.IO.Esent;

public struct XbimSurfaceStyle
{
	private readonly int _styleId;

	private readonly short _expressTypeId;

	public object TagRenderMaterial;

	public short ExpressTypeId => _expressTypeId;

	public int IfcSurfaceStyleLabel => _styleId;

	public bool IsIfcSurfaceStyle => _styleId > 0;

	public XbimSurfaceStyle(short expressTypeId, int ifcSurfaceStyleId)
	{
		_expressTypeId = expressTypeId;
		_styleId = ifcSurfaceStyleId;
		TagRenderMaterial = null;
	}

	public T SurfaceStyle<T>(EsentModel model) where T : class, IPersistEntity
	{
		if (IsIfcSurfaceStyle)
		{
			return (T)model.Instances[_styleId];
		}
		return null;
	}

	public override int GetHashCode()
	{
		if (IsIfcSurfaceStyle)
		{
			return _styleId;
		}
		return _expressTypeId * -1;
	}

	public override bool Equals(object obj)
	{
		if (obj is XbimSurfaceStyle xbimSurfaceStyle)
		{
			if (IsIfcSurfaceStyle && _styleId == xbimSurfaceStyle._styleId)
			{
				return true;
			}
			if (IsIfcSurfaceStyle)
			{
				return false;
			}
			return _expressTypeId == xbimSurfaceStyle._expressTypeId;
		}
		return false;
	}
}
