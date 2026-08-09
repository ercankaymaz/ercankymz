using System;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
[TypeConverter(typeof(LightConverter))]
public class LightSettings
{
	private Vector3D _direction = Vector3D.AxisY;

	private Color color = Color.White;

	private Color specular = Color.White;

	private bool stationary = true;

	private bool active;

	private lightType _type;

	private Point3D _position = _0023_003DzCnsPzSJQqcsG();

	private double _spotHalfAngle = Math.PI / 4.0;

	private double _spotExponent;

	private double _constantAttenuation = 1.0;

	private double _linearAttenuation;

	private double _quadraticAttenuation;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light direction.")]
	public Vector3D Direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light type.")]
	public lightType Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light position.")]
	public Point3D Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Spot light half angle.")]
	public double SpotHalfAngle
	{
		get
		{
			return _spotHalfAngle;
		}
		set
		{
			if (value < 0.0 || value > Math.PI / 2.0)
			{
				throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988022));
			}
			_spotHalfAngle = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Spot light exponent.")]
	public double SpotExponent
	{
		get
		{
			return _spotExponent;
		}
		set
		{
			if (value < 0.0 || value > 128.0)
			{
				throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987978));
			}
			_spotExponent = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light constant attenuation.")]
	public double ConstantAttenuation
	{
		get
		{
			return _constantAttenuation;
		}
		set
		{
			if (value < 0.0)
			{
				throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987932));
			}
			_constantAttenuation = value;
		}
	}

	public double LinearAttenuation
	{
		get
		{
			return _linearAttenuation;
		}
		set
		{
			if (value < 0.0)
			{
				throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988654));
			}
			_linearAttenuation = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light quadratic attenuation.")]
	public double QuadraticAttenuation
	{
		get
		{
			return _quadraticAttenuation;
		}
		set
		{
			if (value < 0.0)
			{
				throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988606));
			}
			_quadraticAttenuation = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light color.")]
	public Color Color
	{
		get
		{
			return color;
		}
		set
		{
			color = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light specular color.")]
	public Color Specular
	{
		get
		{
			return specular;
		}
		set
		{
			specular = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light behaviour. Set false to mimic the Sun.")]
	public bool Stationary
	{
		get
		{
			return stationary;
		}
		set
		{
			stationary = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Light status.")]
	public bool Active
	{
		get
		{
			return active;
		}
		set
		{
			active = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("When true the light yields realistic shadows (Only one shadow is supported).")]
	public bool YieldShadow { get; set; }

	public LightSettings()
	{
	}

	public LightSettings(Vector3D direction, Color color)
		: this(direction, color, Color.Black)
	{
	}

	public LightSettings(Vector3D direction, Color color, Color specular)
	{
		_direction = direction;
		this.color = color;
		this.specular = specular;
	}

	public LightSettings(Vector3D direction, Color color, Color specular, bool stationary, bool active, bool yieldShadow)
		: this(direction, color, specular)
	{
		this.stationary = stationary;
		this.active = active;
		YieldShadow = yieldShadow;
	}

	public LightSettings(Vector3D direction, Color color, Color specular, bool stationary, bool active, bool yieldShadow, lightType type, Point3D position, double spotHalfAngle, double spotExponent, double constantAttenuation, double linearAttenuation, double quadraticAttenuation)
		: this(direction, color, specular, stationary, active, yieldShadow)
	{
		Type = type;
		Position = position;
		if (type == lightType.Spot && (spotHalfAngle < 0.0 || spotHalfAngle > Math.PI / 2.0))
		{
			spotHalfAngle = Math.PI / 2.0;
		}
		SpotHalfAngle = spotHalfAngle;
		SpotExponent = spotExponent;
		ConstantAttenuation = constantAttenuation;
		LinearAttenuation = linearAttenuation;
		QuadraticAttenuation = quadraticAttenuation;
	}

	private static Point3D _0023_003DzCnsPzSJQqcsG()
	{
		return Point3D.Origin;
	}

	public bool ShouldSerialize(LightSettings reference)
	{
		if (!(Direction != reference.Direction) && !(Color != reference.Color) && !(Specular != reference.Specular) && Stationary == reference.Stationary && Active == reference.Active && YieldShadow == reference.YieldShadow && Type == reference.Type && !(Position == null) && Position.X == reference.Position.X && Position.Y == reference.Position.Y && Position.Z == reference.Position.Z && SpotHalfAngle == reference.SpotHalfAngle && SpotExponent == reference.SpotExponent && ConstantAttenuation == reference.ConstantAttenuation && LinearAttenuation == reference.LinearAttenuation)
		{
			return QuadraticAttenuation != reference.QuadraticAttenuation;
		}
		return true;
	}

	internal static Vector3D _0023_003DzaPqMnu5FHVNCrtBBNC4Xux0Veb98(double[] _0023_003DzAGYOv8W3B_8F, Vector3D _0023_003Dz6u3psoE_003D)
	{
		double[] array = new double[16];
		for (int i = 0; i < 16; i++)
		{
			array[i] = _0023_003DzAGYOv8W3B_8F[i];
		}
		array[12] = (array[13] = (array[14] = 0.0));
		double[] array2 = new double[16];
		Utility.InvertMatrixd(array, array2);
		return new Vector3D(Utility.MultMatrixVecd(array2, new double[4]
		{
			0.0 - _0023_003Dz6u3psoE_003D.X,
			0.0 - _0023_003Dz6u3psoE_003D.Z,
			_0023_003Dz6u3psoE_003D.Y,
			0.0
		}));
	}

	public void GetLightDirection(double[] modelViewMatrix, out float[] direction, out float[] position)
	{
		direction = new float[4]
		{
			(float)_direction.X,
			(float)_direction.Y,
			(float)_direction.Z,
			0f
		};
		position = null;
		double[] array = null;
		int num = -1;
		if (Type != lightType.Directional)
		{
			direction[3] = 1f;
			num = 1;
			array = new double[4] { Position.X, Position.Y, Position.Z, 1.0 };
		}
		if (Stationary)
		{
			if (modelViewMatrix != null)
			{
				Vector3D vector3D = null;
				Vector3D vector3D2 = null;
				if (Type != lightType.Directional)
				{
					double[] array2 = new double[16];
					Utility.InvertMatrixd(modelViewMatrix, array2);
					vector3D2 = new Vector3D(Utility.MultMatrixVecd(array2, new double[4]
					{
						array[0],
						array[2],
						array[1],
						1.0
					}));
				}
				if (Type != lightType.Point)
				{
					vector3D = _0023_003DzaPqMnu5FHVNCrtBBNC4Xux0Veb98(modelViewMatrix, _direction);
				}
				if (vector3D != null)
				{
					direction[0] = (float)vector3D.X;
					direction[1] = (float)vector3D.Y;
					direction[2] = (float)vector3D.Z;
				}
				if (vector3D2 != null)
				{
					position = new float[3]
					{
						(float)vector3D2.X,
						(float)vector3D2.Y,
						(float)vector3D2.Z
					};
				}
			}
			else
			{
				direction[0] = (float)((double)num * Direction.X);
				direction[1] = (float)((double)num * Direction.Z);
				direction[2] = (float)Direction.Y;
				if (array != null)
				{
					position = new float[3]
					{
						(float)array[0],
						(float)array[2],
						(float)array[1]
					};
				}
			}
		}
		else
		{
			direction[0] = (float)((double)num * Direction.X);
			direction[1] = (float)((double)num * Direction.Y);
			direction[2] = (float)((double)num * Direction.Z);
			if (array != null)
			{
				position = new float[3]
				{
					(float)array[0],
					(float)array[1],
					(float)array[2]
				};
			}
		}
	}
}
