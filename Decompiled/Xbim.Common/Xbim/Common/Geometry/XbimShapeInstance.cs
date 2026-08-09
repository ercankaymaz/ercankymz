namespace Xbim.Common.Geometry;

public class XbimShapeInstance : IXbimShapeInstanceData
{
	private int _instanceLabel;

	private short _expressTypeId;

	private int _ifcProductLabel;

	private int _styleLabel;

	private int _shapeLabel;

	private int _representationContext;

	private XbimGeometryRepresentationType _representationType;

	private XbimMatrix3D _transformation;

	private XbimRect3D _boundingBox;

	public int InstanceLabel
	{
		get
		{
			return _instanceLabel;
		}
		set
		{
			_instanceLabel = value;
		}
	}

	public short IfcTypeId
	{
		get
		{
			return _expressTypeId;
		}
		set
		{
			_expressTypeId = value;
		}
	}

	public int IfcProductLabel
	{
		get
		{
			return _ifcProductLabel;
		}
		set
		{
			_ifcProductLabel = value;
		}
	}

	public int StyleLabel
	{
		get
		{
			return _styleLabel;
		}
		set
		{
			_styleLabel = value;
		}
	}

	public int ShapeGeometryLabel
	{
		get
		{
			return _shapeLabel;
		}
		set
		{
			_shapeLabel = value;
		}
	}

	public int RepresentationContext
	{
		get
		{
			return _representationContext;
		}
		set
		{
			_representationContext = value;
		}
	}

	public XbimGeometryRepresentationType RepresentationType
	{
		get
		{
			return _representationType;
		}
		set
		{
			_representationType = value;
		}
	}

	byte IXbimShapeInstanceData.RepresentationType
	{
		get
		{
			return (byte)_representationType;
		}
		set
		{
			_representationType = (XbimGeometryRepresentationType)value;
		}
	}

	public XbimMatrix3D Transformation
	{
		get
		{
			return _transformation;
		}
		set
		{
			_transformation = value;
		}
	}

	byte[] IXbimShapeInstanceData.Transformation
	{
		get
		{
			return _transformation.ToArray();
		}
		set
		{
			_transformation = XbimMatrix3D.FromArray(value);
		}
	}

	public XbimRect3D BoundingBox
	{
		get
		{
			return _boundingBox;
		}
		set
		{
			_boundingBox = value;
		}
	}

	byte[] IXbimShapeInstanceData.BoundingBox
	{
		get
		{
			return _boundingBox.ToFloatArray();
		}
		set
		{
			_boundingBox = XbimRect3D.FromArray(value);
		}
	}

	public bool HasStyle => _styleLabel > 0;

	public XbimShapeInstance(int id = -1)
	{
		_instanceLabel = id;
		_expressTypeId = 0;
		_ifcProductLabel = 0;
		_styleLabel = 0;
		_shapeLabel = -1;
		_representationContext = 0;
		_representationType = XbimGeometryRepresentationType.OpeningsAndAdditionsExcluded;
		_transformation = XbimMatrix3D.Identity;
		_boundingBox = XbimRect3D.Empty;
	}

	public override string ToString()
	{
		return $"{_instanceLabel},{_styleLabel},TypeId: {_expressTypeId},{_shapeLabel},{_ifcProductLabel},{_representationContext},{_representationType},{_transformation.ToString()}";
	}
}
