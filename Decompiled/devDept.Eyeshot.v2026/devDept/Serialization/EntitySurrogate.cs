using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Serialization;

public class EntitySurrogate : SurrogateWithReferenceId<Entity>
{
	internal List<KeyValuePair<short, ProtoObject>> XData;

	public string LayerName;

	public byte ColorMethod;

	public Color Color;

	public string MaterialName;

	public byte LineWeightMethod;

	public float LineWeight;

	public byte LineTypeMethod;

	public string LineTypeName;

	public float LineTypeScale;

	public ProtoObject EntityData;

	public bool Visible;

	public bool Selectable;

	public bool Clippable;

	public string Type;

	public Point3D BoxMin;

	public Point3D BoxMax;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private contentType _0023_003DzJbRvCIbvl65qygMHuA_003D_003D;

	public AutodeskProperties AutodeskProperties;

	public IfcProperties IfcProperties;

	public int PrintOrder;

	protected internal contentType Content
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJbRvCIbvl65qygMHuA_003D_003D;
		}
	}

	public EntitySurrogate(Entity entity)
		: base(entity)
	{
	}

	private EntitySurrogate(int _0023_003DzN0lAKfo_003D)
		: base(_0023_003DzN0lAKfo_003D)
	{
	}

	private void _0023_003DzS29gKiH8udGd(contentType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJbRvCIbvl65qygMHuA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	protected override Entity ConvertToObject()
	{
		WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670074) + Type + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
		return null;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		entity.LayerName = LayerName;
		entity.ColorMethod = (colorMethodType)ColorMethod;
		entity.Color = Color;
		entity.MaterialName = MaterialName;
		entity.LineWeightMethod = (colorMethodType)LineWeightMethod;
		entity.LineWeight = LineWeight;
		entity.LineTypeMethod = (colorMethodType)LineTypeMethod;
		entity.LineTypeName = LineTypeName;
		entity.LineTypeScale = LineTypeScale;
		entity.Visible = Visible;
		entity.Selectable = Selectable;
		entity.Clippable = base.Version < 22 || Clippable;
		if (base.Version >= 7)
		{
			entity.AutodeskProperties = AutodeskProperties;
		}
		else if (XData != null)
		{
			if (entity.AutodeskProperties == null)
			{
				entity.AutodeskProperties = new AutodeskProperties();
			}
			entity.AutodeskProperties.XData = new List<KeyValuePair<short, object>>();
			foreach (KeyValuePair<short, ProtoObject> xDatum in XData)
			{
				object obj = xDatum.Value?.Object;
				if (obj is _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D2)
				{
					obj = new Point3D(_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D2._0023_003DzR216mFc_003D(), _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D2._0023_003DzqJqZpJk_003D(), _0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D2._0023_003Dz2_OZI5A_003D());
				}
				else if (obj is _0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D _0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D2)
				{
					obj = _0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D2._0023_003Dz_AadRvc_003D().ToString();
				}
				else if (obj is _0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP _0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP2)
				{
					obj = _0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP2._0023_003Dz_AadRvc_003D();
				}
				entity.AutodeskProperties.XData.Add(new KeyValuePair<short, object>(xDatum.Key, obj));
			}
		}
		if (base.Version >= 16)
		{
			entity.IfcProperties = IfcProperties;
		}
		entity.PrintOrder = PrintOrder;
		if (EntityData != null)
		{
			entity.EntityData = EntityData.Object;
		}
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		LayerName = entity.LayerName;
		ColorMethod = (byte)entity.ColorMethod;
		Color = entity.Color;
		MaterialName = entity.MaterialName;
		LineWeightMethod = (byte)entity.LineWeightMethod;
		LineWeight = entity.LineWeight;
		LineTypeMethod = (byte)entity.LineTypeMethod;
		LineTypeName = entity.LineTypeName;
		LineTypeScale = entity.LineTypeScale;
		Visible = entity.Visible;
		Selectable = entity.Selectable;
		Clippable = entity.Clippable;
		Type = entity.GetType().FullName;
		AutodeskProperties = entity.AutodeskProperties;
		IfcProperties = entity.IfcProperties;
		PrintOrder = entity.PrintOrder;
		if (entity.EntityData != null)
		{
			EntityData = new ProtoObject(entity.EntityData);
		}
	}

	protected virtual bool CheckSurrogateData(string logMessage = null)
	{
		return true;
	}

	protected Ghost CreateGhostEntity(string description = null)
	{
		Ghost ghost = new Ghost(description);
		CopyDataToObject(ghost);
		return ghost;
	}

	protected Entity CreateLinearPathOrGhostEntity(Point3D[] vertices, Type orgEntityType)
	{
		if (CheckSurrogateData(string.Empty))
		{
			LinearPath linearPath = new LinearPath(vertices);
			CopyDataToObject(linearPath);
			return linearPath;
		}
		return _0023_003Dz3_0024Us2DfJD5IJ(orgEntityType);
	}

	private protected Entity _0023_003Dz3_0024Us2DfJD5IJ(Type _0023_003DzIXGoWXWNaPyc)
	{
		string name = _0023_003DzIXGoWXWNaPyc.Name;
		string description = name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670018);
		string message = name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669988);
		WriteLog(message);
		return CreateGhostEntity(description);
	}

	internal Entity _0023_003DzlhB2gVPTKbvi9Its0Q_003D_003D(GLinearPath _0023_003Dzyl_94YHlXyPO, Type _0023_003DzIXGoWXWNaPyc)
	{
		if (CheckSurrogateData(string.Empty))
		{
			LinearPath linearPath = new LinearPath(_0023_003Dzyl_94YHlXyPO);
			CopyDataToObject(linearPath);
			return linearPath;
		}
		return _0023_003Dz3_0024Us2DfJD5IJ(_0023_003DzIXGoWXWNaPyc);
	}

	protected Entity CreateMeshOrGhostEntity(Point3D[] vertices, IndexTriangle[] triangles, Type orgEntityType)
	{
		if (CheckSurrogateData(string.Empty))
		{
			Mesh mesh = new Mesh(vertices, triangles);
			CopyDataToObject(mesh);
			return mesh;
		}
		string name = orgEntityType.Name;
		string description = name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670018);
		string message = name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669988);
		WriteLog(message);
		return CreateGhostEntity(description);
	}

	protected Entity CreatePointCloudOrGhostEntity(Point3D[] vertices, Type orgEntityType)
	{
		if (CheckSurrogateData(string.Empty))
		{
			PointCloud pointCloud = new PointCloud(vertices)
			{
				DrawingStyle = PointCloud.drawingStyleType.Lines
			};
			CopyDataToObject(pointCloud);
			return pointCloud;
		}
		string name = orgEntityType.Name;
		string description = name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670018);
		string message = name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669988);
		WriteLog(message);
		return CreateGhostEntity(description);
	}

	internal static bool _0023_003DzAwMDj22hwTHcSa4TUfUDNCI_003D(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		bool result = true;
		if (_0023_003Dzs_0024uS8LA_003D is VectorView)
		{
			_0023_003Dzs_0024uS8LA_003D.regenMode = regenType.RegenAndCompile;
		}
		else if (_0023_003Dzs_0024uS8LA_003D is devDept.Eyeshot.Entities.Point || _0023_003Dzs_0024uS8LA_003D is Line || _0023_003Dzs_0024uS8LA_003D is LinearEntity || _0023_003Dzs_0024uS8LA_003D is LinearPath || _0023_003Dzs_0024uS8LA_003D is Leader || _0023_003Dzs_0024uS8LA_003D is Mesh || _0023_003Dzs_0024uS8LA_003D is Picture || _0023_003Dzs_0024uS8LA_003D is Joint || _0023_003Dzs_0024uS8LA_003D is Bar || _0023_003Dzs_0024uS8LA_003D is PointCloud || _0023_003Dzs_0024uS8LA_003D is BlockReference)
		{
			_0023_003Dzs_0024uS8LA_003D.regenMode = regenType.CompileOnly;
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Text || _0023_003Dzs_0024uS8LA_003D is Table)
		{
			_0023_003Dzs_0024uS8LA_003D.regenMode = regenType.RegenAndCompile;
		}
		else
		{
			result = false;
		}
		return result;
	}

	public static implicit operator Entity(EntitySurrogate surrogate)
	{
		Entity entity = Serializer.GetCachedObject(surrogate) as Entity;
		if (entity != null)
		{
			return entity;
		}
		if (surrogate != null)
		{
			entity = surrogate.ConvertToObject();
			Serializer.AddToCache(surrogate, entity);
			if (entity == null)
			{
				if (string.IsNullOrEmpty(surrogate.Log))
				{
					surrogate.WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998666) + surrogate.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
				}
				return null;
			}
			if (!_0023_003DzAwMDj22hwTHcSa4TUfUDNCI_003D(entity))
			{
				switch (surrogate.Content)
				{
				case contentType.Geometry:
				case contentType.Tessellation:
					entity.regenMode = regenType.RegenAndCompile;
					break;
				case contentType.GeometryAndTessellation:
					entity.regenMode = regenType.CompileOnly;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			if (entity.regenMode == regenType.CompileOnly && !entity._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
			{
				entity.regenMode = regenType.RegenAndCompile;
			}
			if (!(entity is BlockReference) && entity.regenMode == regenType.CompileOnly)
			{
				entity.UpdateBoundingBox(null);
			}
		}
		return entity;
	}

	public static implicit operator EntitySurrogate(Entity source)
	{
		if (source == null)
		{
			return null;
		}
		EntitySurrogate entitySurrogate2;
		if (Serializer.GetCachedObjectWithReferenceId(source) is EntitySurrogate entitySurrogate)
		{
			entitySurrogate2 = new EntitySurrogate(entitySurrogate.ReferenceId);
		}
		else
		{
			entitySurrogate2 = source.ConvertToSurrogate();
			Serializer.AddToCache(source, entitySurrogate2);
		}
		if (entitySurrogate2 == null)
		{
			Type type = source.GetType();
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670693), type, type));
		}
		return entitySurrogate2;
	}

	internal static FastMesh[] _0023_003Dz7cReF5XErES5a62AbKubYBSe22Kb(Entity[] _0023_003Dzv7xH9gk_003D)
	{
		if (_0023_003Dzv7xH9gk_003D == null)
		{
			return new FastMesh[0];
		}
		FastMesh[] array = new FastMesh[_0023_003Dzv7xH9gk_003D.Length];
		for (int i = 0; i < _0023_003Dzv7xH9gk_003D.Length; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			if (entity == null || entity is Ghost)
			{
				array[i] = new FastMesh(new float[0], new int[0], new float[0]);
				continue;
			}
			if (entity is FastMesh fastMesh)
			{
				array[i] = fastMesh;
				continue;
			}
			Mesh mesh = (Mesh)entity;
			array[i] = mesh.ConvertToFastMesh();
		}
		return array;
	}

	[CLSCompliant(false)]
	protected override void BeforeDeserialize(SerializationContext serializationContext)
	{
		base.BeforeDeserialize(serializationContext);
		if (!(serializationContext.Context is FileSerializer fileSerializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669432));
		}
		_0023_003DzS29gKiH8udGd(fileSerializer.Content);
	}

	[CLSCompliant(false)]
	protected override void BeforeSerialize(SerializationContext serializationContext)
	{
		base.BeforeSerialize(serializationContext);
		if (!(serializationContext.Context is FileSerializer fileSerializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670603));
		}
		_0023_003DzS29gKiH8udGd(fileSerializer.Content);
		CheckSurrogateData();
		fileSerializer.WriteLog(base.Log);
	}
}
