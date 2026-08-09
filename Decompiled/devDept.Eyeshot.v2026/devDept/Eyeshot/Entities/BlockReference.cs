using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class BlockReference : Entity
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003DzwkD2_0024TESaGSJ95_djw_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003DzcLOxoWBTXaQKUV_y_0024g_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003Dzt_uw_0024630yt1SN4SGPw_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003DzE7gYhvhCXU_cdSBXhQ_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003DzKfRWP97p0VVOqhyn9A_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003DzbEm72O5aGvaQfjOx1w_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003Dzh_NLB_00242wvgOfQudDCQ_003D_003D;

		public static _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003Dzh1AV_0024pi35sSFp6I_Ig_003D_003D;

		internal bool _0023_003DzQl4gNE9gNeLJEoPMnk7jKh0lK0Ejzmd8YfeaG8s_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.AllVerticesInFrustum(_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003Dz8RDjZ99UHjB_H_002485zLHrDoyYVbAG9v1qBg_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.IntersectEdgeOrIsoline(_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003DzBM5kYw_1J62aySVT4At1pJxnrCXG_0024IWIoT1ybPI_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.IntersectEdgeOrIsolineScreenPolygon((ScreenPolygonParams)_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003DzJ6YhnHHX7Bx4DwkyNVhGyxY_0024gvcOb_xX1r08CjI_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.InsideOrCrossingFrustum(_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003Dz3fASI5c6oo_0024eZCTSt7YFGgzUC7v78m_0024O29i2Ftw_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.InsideOrCrossingScreenPolygon((ScreenPolygonParams)_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003DzlVY23OprrcIycYJ_3goW3ro_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.ThroughTriangle(_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003DznOBq7ryzyQZ79fDRg8Eg1oF51xUc(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.ThroughTriangleScreenPolygon((ScreenPolygonParams)_0023_003DzkvBuFaE_003D);
		}

		internal bool _0023_003DzxG2K531TTliAY9IXN0aDHGpHo5w6re3j82TJLgo_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.AllVerticesInScreenPolygon((ScreenPolygonParams)_0023_003DzkvBuFaE_003D);
		}
	}

	private delegate bool _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzmPmPjCPqZ3T3);

	private sealed class _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D
	{
		public FrustumParams _0023_003DzmPmPjCPqZ3T3;

		public _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D;

		internal bool _0023_003Dq8VGIf5GMm9uowJRCU5NEEsAl3n7FAEr1kcTweotpIWKe0uCFJ92wPbViak709il5H1yxDlWtT1uoDbF68BYjwg_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003DzmPmPjCPqZ3T3.workspaceInternal.IsSelectableForIsolation(_0023_003DzmPmPjCPqZ3T3, _0023_003Dzs_0024uS8LA_003D) && _0023_003Dzs_0024uS8LA_003D.IsVisible(_0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode))
			{
				return _0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzmPmPjCPqZ3T3);
			}
			return false;
		}
	}

	internal string _blockName;

	internal string blockNameForExport;

	internal Dictionary<Entity, Box3D> transformedEntityBoxes = new Dictionary<Entity, Box3D>();

	private AttributeReferenceDictionary _attributes = new AttributeReferenceDictionary();

	internal bool Current;

	internal GfxAttributesRendered AccumulatedParentsAttributes;

	internal Transformation transform;

	internal Transformation fullTransformation;

	internal double maxScaleFactor = 1.0;

	internal bool updatedDuringLastRegen;

	internal bool isBlockDirty;

	private bool useTransformedEntityBoxesOptimization;

	private _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _basis;

	public AttributeReferenceDictionary Attributes => _attributes;

	public Transformation AccumulatedParentsTransform { get; internal set; }

	public string BlockName
	{
		get
		{
			return _blockName;
		}
		set
		{
			_blockName = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point3D InsertionPoint
	{
		get
		{
			return new Point3D(transform.Matrix[0, 3], transform.Matrix[1, 3], transform.Matrix[2, 3]);
		}
		set
		{
			transform.Matrix[0, 3] = value.X;
			transform.Matrix[1, 3] = value.Y;
			transform.Matrix[2, 3] = value.Z;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Transformation Transformation
	{
		get
		{
			return transform;
		}
		set
		{
			Transformation transformation = new Transformation(Matrix.Inverse4(transform.Matrix));
			Transformation transformation2 = value * transformation;
			transform = value;
			fullTransformation = null;
			if (RegenMode != regenType.RegenAndCompile && !transformation2.HasRotation && !transformation2.HasReflection && localMin != null && localMax != null)
			{
				localMin.TransformBy(transformation2);
				localMax.TransformBy(transformation2);
				UpdateBoundingBoxSphere();
				foreach (KeyValuePair<Entity, Box3D> transformedEntityBox in transformedEntityBoxes)
				{
					transformedEntityBox.Value._0023_003DzVQaoDTr7XsmN().TransformBy(transformation2);
					transformedEntityBox.Value._0023_003Dz15VJ9VVI6246().TransformBy(transformation2);
				}
				isDirtyForFlattenTree = true;
			}
			else
			{
				RegenMode = regenType.RegenAndCompile;
			}
			if (base.OrientedBounding != null)
			{
				if (transform.IsScaleFactorUniform())
				{
					base.OrientedBounding.AccumulatedTransformation = transform;
				}
				else
				{
					base.OrientedBounding._0023_003DziQOhVy0_003D = true;
				}
			}
		}
	}

	public bool IsFixed { get; set; }

	public BlockReference(double x, double y, double z, string blockName, double rotationAngleInRadians)
		: this(x, y, z, blockName, 1.0, 1.0, 1.0, rotationAngleInRadians)
	{
	}

	public BlockReference(double x, double y, double z, string blockName, linearUnitsType globalUnits, BlockKeyedCollection blocks, double rotationAngleInRadians)
		: base(entityNatureType.None)
	{
		_blockName = blockName;
		Translation translation = new Translation(x, y, z);
		Rotation rotation = new Rotation(rotationAngleInRadians, Vector3D.AxisZ, Point3D.Origin);
		double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(blocks[blockName].Units, globalUnits);
		Scaling scaling = new Scaling(linearUnitsConversionFactor, linearUnitsConversionFactor, linearUnitsConversionFactor);
		transform = translation * rotation * scaling;
	}

	public BlockReference(double x, double y, double z, string blockName, double sx, double sy, double sz, double rotationAngleInRadians)
		: base(entityNatureType.None)
	{
		_blockName = blockName;
		Translation translation = new Translation(x, y, z);
		Rotation rotation = new Rotation(rotationAngleInRadians, Vector3D.AxisZ, Point3D.Origin);
		Scaling scaling = new Scaling(sx, sy, sz);
		transform = translation * rotation * scaling;
	}

	public BlockReference(Point3D insPoint, string blockName, double rotationAngleInRadians)
		: this(insPoint, blockName, 1.0, 1.0, 1.0, rotationAngleInRadians)
	{
	}

	public BlockReference(Point3D insPoint, string blockName, double sx, double sy, double sz, double rotationAngleInRadians)
		: base(entityNatureType.None)
	{
		_blockName = blockName;
		Translation translation = new Translation(insPoint.X, insPoint.Y, insPoint.Z);
		Rotation rotation = new Rotation(rotationAngleInRadians, Vector3D.AxisZ, Point3D.Origin);
		Scaling scaling = new Scaling(sx, sy, sz);
		transform = translation * rotation * scaling;
	}

	public BlockReference(string blockName)
		: this(null, blockName)
	{
	}

	public BlockReference(Transformation t, string blockName)
		: base(entityNatureType.None)
	{
		transform = t ?? new Identity();
		_blockName = blockName;
	}

	public BlockReference(Transformation t, string blockName, linearUnitsType globalUnits, BlockKeyedCollection blocks)
		: base(entityNatureType.None)
	{
		transform = t;
		_blockName = blockName;
		double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(blocks[blockName].Units, globalUnits);
		transform *= (Transformation)new Scaling(linearUnitsConversionFactor, linearUnitsConversionFactor, linearUnitsConversionFactor);
	}

	protected BlockReference(BlockReference another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		transform = (Transformation)another.transform.Clone();
		_blockName = another._blockName;
		foreach (KeyValuePair<string, AttributeReference> attribute in another.Attributes)
		{
			_attributes.Add(attribute.Key, (AttributeReference)attribute.Value.Clone());
		}
		_attributes.needSynchronization = another.Attributes.needSynchronization;
	}

	protected internal BlockReference(BlockReferenceSurrogate surrogate)
		: this(surrogate.Transformation, surrogate.BlockName)
	{
	}

	protected BlockReference(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_blockName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956164));
		transform = (Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956915), typeof(Transformation));
		_attributes = (AttributeReferenceDictionary)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956906), typeof(AttributeReferenceDictionary));
	}

	public Transformation GetFullTransformation(BlockKeyedCollection blocks, BlockKeyedCollection parentBlocks = null)
	{
		if (fullTransformation == null)
		{
			Block block = ((parentBlocks == null || parentBlocks.Count <= 0 || blocks.Contains(_blockName)) ? blocks.GetItemFast(_blockName) : parentBlocks.GetItemFast(_blockName));
			Identity identity = new Identity();
			identity[0, 3] = 0.0 - block.BasePoint.X;
			identity[1, 3] = 0.0 - block.BasePoint.Y;
			identity[2, 3] = 0.0 - block.BasePoint.Z;
			fullTransformation = transform * identity;
		}
		return fullTransformation;
	}

	internal void PropagateParentAttributes(BlockReference _0023_003Dzalvl9z8_003D, IWorkspaceInternal _0023_003DzImQx0os_003D)
	{
		if (_0023_003Dzalvl9z8_003D == null)
		{
			AccumulatedParentsTransform = GetFullTransformation(_0023_003DzImQx0os_003D.Blocks);
			AccumulatedParentsAttributes = new GfxAttributesRendered(_0023_003DzImQx0os_003D.Document.DefaultColor, _0023_003DzImQx0os_003D.Layers);
		}
		else
		{
			AccumulatedParentsTransform = _0023_003Dzalvl9z8_003D.AccumulatedParentsTransform * GetFullTransformation(_0023_003DzImQx0os_003D.Blocks);
			AccumulatedParentsAttributes = (GfxAttributesRendered)_0023_003Dzalvl9z8_003D.AccumulatedParentsAttributes.Clone();
		}
		Current = true;
		Layer _0023_003DztIaJjPw_003D = _0023_003DzImQx0os_003D.Layers[LayerName];
		AccumulatedParentsAttributes.Propagate(this, _0023_003DztIaJjPw_003D, _0023_003DzImQx0os_003D.Materials);
		AccumulatedParentsAttributes.PropagateLayer0(this, _0023_003DztIaJjPw_003D);
	}

	public override object Clone()
	{
		return new BlockReference(this);
	}

	public override object CloneWithTessellation()
	{
		return new BlockReference(this, RegenMode != regenType.RegenAndCompile);
	}

	public double GetScaleFactorX()
	{
		return transform.ScaleFactorX;
	}

	public double GetScaleFactorY()
	{
		return transform.ScaleFactorY;
	}

	public double GetScaleFactorZ()
	{
		return transform.ScaleFactorZ;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, null, materials));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956889) + _blockName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956858));
		stringBuilder.Append(transform.Dump());
		if (blocks != null && blocks.Count > 0)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956848) + linearUnits.ToString().ToLower());
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956804) + massUnits.ToString().ToLower());
			return _0023_003DzfHv2e_zS4vmCLzMTyw_003D_003D(stringBuilder, blocks, layers, materials, linearUnits, massUnits).ToString();
		}
		return stringBuilder.ToString();
	}

	public Entity[] ExplodeDeep(BlockKeyedCollection blocks, bool keepTessellation = false)
	{
		List<Entity> list = new List<Entity>();
		Entity[] array = Explode(blocks, resolveByParent: true, keepTessellation);
		foreach (Entity entity in array)
		{
			if (entity is BlockReference blockReference)
			{
				list.AddRange(blockReference.ExplodeDeep(blocks, keepTessellation));
			}
			else
			{
				list.Add(entity);
			}
		}
		return list.ToArray();
	}

	private StringBuilder _0023_003DzfHv2e_zS4vmCLzMTyw_003D_003D(StringBuilder _0023_003DzgyYoHow_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, linearUnitsType _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D, massUnitsType _0023_003DzyxvbkJ1lwtnX)
	{
		AreaProperties areaProperties = new AreaProperties();
		VolumeProperties volumeProperties = new VolumeProperties();
		Entity[] array = ExplodeDeep(_0023_003DzJO1FWlQ_003D, keepTessellation: true);
		double num = 0.0;
		Entity[] array2 = array;
		foreach (Entity entity in array2)
		{
			if (entity is IFace face)
			{
				Mesh[] tessellation = face.GetTessellation();
				areaProperties.Add(tessellation);
				volumeProperties.Add(tessellation);
				num += face.GetMass(entity.GetMaterial(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, _0023_003DzeWJg3NJnk3WA), _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D, _0023_003DzyxvbkJ1lwtnX, out var _);
			}
		}
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957046) + areaProperties.Area + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957036) + _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D.ToString().ToLower());
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957017) + areaProperties.Centroid);
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956978) + volumeProperties.Volume + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956962) + _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D.ToString().ToLower());
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956976) + volumeProperties.Centroid);
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956935) + num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzyxvbkJ1lwtnX.ToString().ToLower());
		return _0023_003DzgyYoHow_003D;
	}

	public linearUnitsType GetBlockUnits(BlockKeyedCollection blocks)
	{
		return blocks[_blockName].Units;
	}

	public override void Regen(double deviation)
	{
		throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956661));
	}

	public override void Regen(RegenParams data)
	{
		if (data.Document == null && !data.SkipTexts)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956547));
		}
		if (data.Blocks == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956730));
		}
		data.Parents.Push(this);
		Block block = data.Blocks[_blockName];
		fullTransformation = null;
		if (block.Entities.Count > 0 && !block.regenerated)
		{
			block._0023_003DzcX3lwu4d7umF(data);
		}
		Attributes._0023_003DzXQYa2Ko_003D(data.Document);
		if (Attributes.needSynchronization)
		{
			_0023_003DzsQAoLomWIpW0(data.Blocks, _0023_003DzEkR_P10_003D: false);
		}
		bool flag = _0023_003DzH5_UUBjbwiJl(data);
		updatedDuringLastRegen = RegenMode == regenType.RegenAndCompile;
		if (updatedDuringLastRegen)
		{
			transformedEntityBoxes = new Dictionary<Entity, Box3D>();
		}
		else
		{
			updatedDuringLastRegen = isBlockDirty;
		}
		if (updatedDuringLastRegen || block.Entities.Count == 0 || transformedEntityBoxes.Count == 0 || flag)
		{
			_0023_003DzFNUAUbe6oeIJ(data, out var _, out var _);
		}
		maxScaleFactor = transform.MaxAbsScaleFactor;
		data.Parents.Pop();
		isBlockDirty = false;
		RegenMode = regenType.CompileOnly;
	}

	internal bool _0023_003DzH5_UUBjbwiJl(RegenParams _0023_003DzELu0Pss_003D)
	{
		bool result = false;
		foreach (KeyValuePair<string, AttributeReference> attribute in Attributes)
		{
			if (attribute.Value.Data.regenMode == regenType.RegenAndCompile)
			{
				attribute.Value.Data.Regen(_0023_003DzELu0Pss_003D);
				transformedEntityBoxes.Remove(attribute.Value.Data);
				result = true;
			}
		}
		return result;
	}

	public override void Dispose()
	{
		base.Dispose();
		foreach (KeyValuePair<string, AttributeReference> attribute in Attributes)
		{
			attribute.Value.Dispose();
		}
		transformedEntityBoxes.Clear();
		RegenMode = regenType.RegenAndCompile;
	}

	public IList<Entity> GetEntities(BlockKeyedCollection blocks, BlockKeyedCollection parentBlocks = null)
	{
		IList<Entity> list = ((parentBlocks == null || parentBlocks.Count <= 0 || blocks.Contains(_blockName)) ? blocks.GetItemFast(_blockName).Entities : parentBlocks.GetItemFast(_blockName).Entities);
		if (Attributes.Count > 0)
		{
			List<Entity> list2 = new List<Entity>(Attributes.Count + list.Count);
			list2.AddRange(list);
			foreach (KeyValuePair<string, AttributeReference> attribute in Attributes)
			{
				list2.Add(attribute.Value.Data);
			}
			list = list2;
		}
		return list;
	}

	internal void GetBlocksNamesInternal(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, IList<string> _0023_003Dz91l5x2GgMkDk, bool _0023_003DzM3QnY6pto_0024xh = true)
	{
		if (!_0023_003DzJO1FWlQ_003D.Contains(BlockName))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957424));
		}
		if (_0023_003DzM3QnY6pto_0024xh && !_0023_003Dz91l5x2GgMkDk.Contains(BlockName))
		{
			_0023_003Dz91l5x2GgMkDk.Add(BlockName);
		}
		foreach (Entity entity in _0023_003DzJO1FWlQ_003D[BlockName].Entities)
		{
			if (entity is BlockReference blockReference)
			{
				blockReference.GetBlocksNamesInternal(_0023_003DzJO1FWlQ_003D, _0023_003Dz91l5x2GgMkDk);
			}
		}
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out bool _0023_003DzlglYmGw_003D, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[0];
		_0023_003Dz65XzMuTfn2Pgrp72BzWrnf1XUjxu(GetEntities(_0023_003DzELu0Pss_003D.Blocks), _0023_003DzELu0Pss_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzlglYmGw_003D, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D);
		return true;
	}

	internal bool _0023_003Dz65XzMuTfn2Pgrp72BzWrnf1XUjxu(IList<Entity> _0023_003Dzv7xH9gk_003D, TraversalParams _0023_003DzmPmPjCPqZ3T3, out Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out bool _0023_003DzlglYmGw_003D, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[0];
		bool result = true;
		List<Point2D> list = new List<Point2D>(_0023_003Dzv7xH9gk_003D.Count * 2);
		_0023_003DzlglYmGw_003D = false;
		_0023_003DzHhJEwwk_003D = 1;
		for (int i = 0; i < _0023_003Dzv7xH9gk_003D.Count; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			Point2D[] _0023_003DzrdSL0CI_003D = null;
			if (!entity._0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(_0023_003DzmPmPjCPqZ3T3, out _0023_003DzrdSL0CI_003D, out var _0023_003DzD5Gs7jmmc9uK, out var _0023_003DzHhJEwwk_003D2, _0023_003DzjZRgeJk_003D) || entity.OrientedBounding == null)
			{
				result = false;
				continue;
			}
			_0023_003DzHhJEwwk_003D += _0023_003DzHhJEwwk_003D2;
			_0023_003DzlglYmGw_003D |= _0023_003DzD5Gs7jmmc9uK || entity.OrientedBounding._0023_003DziQOhVy0_003D || entity.OrientedBounding._0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D;
			entity.OrientedBounding._0023_003DziQOhVy0_003D = false;
			entity.OrientedBounding._0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
			if (entity.OrientedBounding != null)
			{
				double diagonal = ((Size3D)entity.OrientedBounding.Size).Diagonal;
				if (_0023_003DzrdSL0CI_003D == null || (_0023_003DzrdSL0CI_003D.Length == 0 && diagonal != 0.0 && !double.IsInfinity(diagonal) && !double.IsNaN(diagonal)))
				{
					Point2D[] array = (Point3D[])entity.OrientedBounding.GetVertices();
					_0023_003DzrdSL0CI_003D = array;
				}
				list.AddRange(_0023_003DzrdSL0CI_003D);
			}
		}
		Point2D[] array2 = (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = list.ToArray());
		bool flag = false;
		if (_0023_003Dzv7xH9gk_003D.Count > 1 && list.Count > 0 && ((_localOB == null) | _0023_003DzlglYmGw_003D))
		{
			_localOB = new OrientedBoundingBox(array2);
			_0023_003DzlglYmGw_003D = true;
			flag = true;
		}
		else if (((_localOB == null) | _0023_003DzlglYmGw_003D) && _0023_003Dzv7xH9gk_003D.Count == 1)
		{
			if (_0023_003Dzv7xH9gk_003D[0].OrientedBounding != null)
			{
				_localOB = (OrientedBoundingBox)_0023_003Dzv7xH9gk_003D[0].OrientedBounding.Clone();
			}
			_0023_003DzlglYmGw_003D = true;
			flag = true;
		}
		Transformation transformation = GetFullTransformation(_0023_003DzmPmPjCPqZ3T3.Blocks);
		if (_localOB != null && transformation != null && !transformation.IsIdentity())
		{
			Point2D[] array = new Point3D[array2.Length];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
			for (int j = 0; j < array2.Length; j++)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = transformation * (Point3D)array2[j];
			}
			if (transformation.HasScaling)
			{
				_localOB = new OrientedBoundingBox(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			}
			else if (flag)
			{
				Transformation transformation2 = new Identity();
				_0023_003Dz3g9Q5YiWL7TC7cdhWQ_003D_003D(_0023_003DzmPmPjCPqZ3T3.Blocks[_blockName], transformation2);
				_localOB._0023_003DzK3EEX2U_003D(transformation2);
				_localOB.AccumulateTransformation(transform);
			}
		}
		return result;
	}

	internal override bool _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out bool _0023_003DzlglYmGw_003D, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[0];
		_0023_003DzE7UjXj35NWgzPs08_umG1oMi0Ta7(GetEntities(_0023_003DzELu0Pss_003D.Blocks), _0023_003DzELu0Pss_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzlglYmGw_003D, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D);
		return true;
	}

	internal bool _0023_003DzE7UjXj35NWgzPs08_umG1oMi0Ta7(IList<Entity> _0023_003Dzv7xH9gk_003D, TraversalParams _0023_003DzmPmPjCPqZ3T3, out Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out bool _0023_003DzlglYmGw_003D, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D)
	{
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[0];
		bool result = true;
		List<Point2D> list = new List<Point2D>(_0023_003Dzv7xH9gk_003D.Count * 2);
		_0023_003DzlglYmGw_003D = false;
		_0023_003DzHhJEwwk_003D = 1;
		for (int i = 0; i < _0023_003Dzv7xH9gk_003D.Count; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			Point2D[] _0023_003DzrdSL0CI_003D = null;
			if (!entity._0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(_0023_003DzmPmPjCPqZ3T3, out _0023_003DzrdSL0CI_003D, out var _0023_003DzD5Gs7jmmc9uK, out var _0023_003DzHhJEwwk_003D2, _0023_003DzjZRgeJk_003D))
			{
				result = false;
				continue;
			}
			_0023_003DzHhJEwwk_003D += _0023_003DzHhJEwwk_003D2;
			_0023_003DzlglYmGw_003D |= _0023_003DzD5Gs7jmmc9uK || entity.OrientedBounding._0023_003DziQOhVy0_003D || entity.OrientedBounding._0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D;
			entity.OrientedBounding._0023_003DziQOhVy0_003D = false;
			entity.OrientedBounding._0023_003DzqO65_ybZETkhHxdz_0024zlPWmw_003D = false;
			if (entity.OrientedBounding != null)
			{
				double diagonal = ((Size2D)entity.OrientedBounding.Size).Diagonal;
				if (_0023_003DzrdSL0CI_003D == null || (_0023_003DzrdSL0CI_003D.Length == 0 && diagonal != 0.0 && !double.IsInfinity(diagonal) && !double.IsNaN(diagonal)))
				{
					_0023_003DzrdSL0CI_003D = entity.OrientedBounding.GetVertices();
				}
				list.AddRange(_0023_003DzrdSL0CI_003D);
			}
		}
		Point2D[] array = (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = list.ToArray());
		bool flag = false;
		if (_0023_003Dzv7xH9gk_003D.Count > 1 && list.Count > 0 && ((_localOB == null) | _0023_003DzlglYmGw_003D))
		{
			_localOB = new OrientedBoundingRect(array);
			_0023_003DzlglYmGw_003D = true;
			flag = true;
		}
		else if (((_localOB == null) | _0023_003DzlglYmGw_003D) && _0023_003Dzv7xH9gk_003D.Count == 1)
		{
			if (_0023_003Dzv7xH9gk_003D[0].OrientedBounding != null)
			{
				_localOB = (OrientedBoundingRect)_0023_003Dzv7xH9gk_003D[0].OrientedBounding.Clone();
			}
			_0023_003DzlglYmGw_003D = true;
			flag = true;
		}
		Transformation transformation = new Identity();
		_0023_003Dz3g9Q5YiWL7TC7cdhWQ_003D_003D(_0023_003DzmPmPjCPqZ3T3.Blocks[_blockName], transformation);
		Transformation transformation2 = transformation * transform;
		if (_localOB != null && transformation2 != null && !transformation2.IsIdentity())
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = transformation2 * array[j];
			}
			if (transformation2.HasScaling)
			{
				_localOB = new OrientedBoundingRect(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			}
			else if (flag)
			{
				_localOB._0023_003DzK3EEX2U_003D(transformation);
				_localOB.AccumulateTransformation(transform);
			}
		}
		return result;
	}

	internal Block _0023_003Dzo_00248mPqY_003D(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, BlockKeyedCollection _0023_003DzibJx_aY_e1oq)
	{
		if (!_0023_003DzJO1FWlQ_003D.Contains(_blockName) && _0023_003DzibJx_aY_e1oq != null && _0023_003DzibJx_aY_e1oq.Count > 0)
		{
			return _0023_003DzibJx_aY_e1oq[_blockName];
		}
		return _0023_003DzJO1FWlQ_003D[_blockName];
	}

	public IList<Entity> GetEntitiesZoomFit(Block block)
	{
		List<Entity> list = new List<Entity>();
		list.AddRange(block.Entities);
		if (Attributes.Count > 0)
		{
			List<Entity> list2 = new List<Entity>(Attributes.Count + list.Count);
			list2.AddRange(list);
			foreach (KeyValuePair<string, AttributeReference> attribute in Attributes)
			{
				list2.Add(attribute.Value.Data);
			}
			list = list2;
		}
		return list;
	}

	protected internal bool GetAllVerticesParallel(TraversalParams data, object cToken, out IList<float> vertices)
	{
		vertices = Array.Empty<float>();
		bool flag = data.Document.OpenBlock.Name == BlockName;
		if (flag && data.Document.OpenBlock.zoomFitConvexHull == null && data.Transformation != null)
		{
			return false;
		}
		if (!flag)
		{
			data.Parents.Push(this);
		}
		IList<float> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		bool result = _0023_003Dzpy8J_0024UAHRCbnEAQhI1L1bS0_003D(data, cToken, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D != null)
		{
			vertices = new float[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count];
			float[,] floatMatrix = (GetFullTransformation(data.Blocks, data.workspaceInternal?.ParentBlocks) ?? new Identity()).GetFloatMatrix();
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i += 3)
			{
				float[] array = Transformation.ActOnLeftOne(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 2], floatMatrix);
				vertices[i] = array[0];
				vertices[i + 1] = array[1];
				vertices[i + 2] = array[2];
			}
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D is List<float>)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Clear();
			}
		}
		if (!flag)
		{
			data.Parents.Pop();
		}
		return result;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> vertices)
	{
		vertices = Array.Empty<float>();
		bool flag = data.Document.OpenBlock.Name == BlockName;
		if (flag && data.Document.OpenBlock.zoomFitConvexHull == null && data.Transformation != null)
		{
			return false;
		}
		if (!flag)
		{
			data.Parents.Push(this);
		}
		IList<float> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		bool result = _0023_003Dzpy8J_0024UAHRCbnEAQhI1L1bS0_003D(data, null, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D != null)
		{
			vertices = new float[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count];
			float[,] floatMatrix = transform.GetFloatMatrix();
			for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i += 3)
			{
				float[] array = Transformation.ActOnLeftOne(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 2], floatMatrix);
				vertices[i] = array[0];
				vertices[i + 1] = array[1];
				vertices[i + 2] = array[2];
			}
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D is List<float>)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Clear();
			}
		}
		if (!flag)
		{
			data.Parents.Pop();
		}
		return result;
	}

	private bool _0023_003Dzpy8J_0024UAHRCbnEAQhI1L1bS0_003D(TraversalParams _0023_003DzmPmPjCPqZ3T3, object _0023_003Dz4n6DluY_003D, out IList<float> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		bool flag = false;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = Array.Empty<float>();
		float[] array = null;
		Block block = _0023_003Dzo_00248mPqY_003D(_0023_003DzmPmPjCPqZ3T3.Blocks, _0023_003DzmPmPjCPqZ3T3.workspaceInternal?.ParentBlocks);
		bool flag2 = _0023_003DzmPmPjCPqZ3T3.Document.OpenBlock.Equals(block);
		if (block.zoomFitConvexHull != null && flag2)
		{
			array = block.zoomFitConvexHull;
		}
		else
		{
			IList<Entity> entitiesZoomFit = GetEntitiesZoomFit(block);
			bool flag3 = false;
			foreach (Entity item in entitiesZoomFit)
			{
				if (_0023_003Dz4n6DluY_003D != null && ((CancellationToken)_0023_003Dz4n6DluY_003D).IsCancellationRequested)
				{
					return false;
				}
				if ((item is Attribute && !(this is ParentBlockReference)) || (_0023_003DzmPmPjCPqZ3T3.SkipTexts && item is Text) || (_0023_003DzmPmPjCPqZ3T3.Document != null && !item.IsVisible(_0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode)))
				{
					continue;
				}
				flag = ((!(item is BlockReference blockReference) || _0023_003Dz4n6DluY_003D == null) ? (flag & item.GetAllVertices(_0023_003DzmPmPjCPqZ3T3, out var verticesCoords)) : (flag & blockReference.GetAllVerticesParallel(_0023_003DzmPmPjCPqZ3T3, _0023_003Dz4n6DluY_003D, out verticesCoords)));
				if (_0023_003Dz4n6DluY_003D != null && ((CancellationToken)_0023_003Dz4n6DluY_003D).IsCancellationRequested)
				{
					return false;
				}
				if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D == null || _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count == 0)
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = verticesCoords;
					continue;
				}
				if (!flag3)
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.ToList();
					flag3 = true;
				}
				((List<float>)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D).AddRange(verticesCoords);
			}
			double diagonal = _0023_003DzmPmPjCPqZ3T3.Document.OpenBlock.Entities.BoxSize.Diagonal;
			array = block._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzmPmPjCPqZ3T3, diagonal, flag2);
		}
		if (array != null)
		{
			flag = array.Length != 0;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
		}
		return flag;
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		return _0023_003Dzgb_0024SKVSyiPAvoiSM6g_003D_003D(data, transformedEntityBoxes, GetEntities(data.Blocks, data.workspaceInternal?.ParentBlocks), Attributes, out boxMin, out boxMax);
	}

	internal bool _0023_003Dzgb_0024SKVSyiPAvoiSM6g_003D_003D(TraversalParams _0023_003DzELu0Pss_003D, Dictionary<Entity, Box3D> _0023_003DzFRVP2KBOBJQk2b9AJyiGEfc_003D, IList<Entity> _0023_003DzWc9WmS8VMsuA, AttributeReferenceDictionary _0023_003DzSwO927XKVl3g, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		bool flag = _0023_003DzELu0Pss_003D.Document?.OpenBlock.Name == BlockName;
		_0023_003DzELu0Pss_003D.PushTransformation(this);
		if (!flag)
		{
			_0023_003DzELu0Pss_003D.Parents.Push(this);
		}
		List<Point3D> list = new List<Point3D>();
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if ((item is Attribute && !(this is ParentBlockReference)) || (_0023_003DzELu0Pss_003D.SkipTexts && item is Text) || (_0023_003DzELu0Pss_003D.Document != null && !item.IsVisible(_0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.Document.Layers, _0023_003DzELu0Pss_003D.Document.AttributeReferenceVisibilityMode)))
			{
				continue;
			}
			Point3D boxMin = Point3D.MaxValue;
			Point3D boxMax = Point3D.MinValue;
			if (useTransformedEntityBoxesOptimization && _0023_003DzFRVP2KBOBJQk2b9AJyiGEfc_003D != null && _0023_003DzFRVP2KBOBJQk2b9AJyiGEfc_003D.ContainsKey(item))
			{
				Box3D box3D = _0023_003DzFRVP2KBOBJQk2b9AJyiGEfc_003D[item];
				boxMin = box3D._0023_003DzVQaoDTr7XsmN();
				boxMax = box3D._0023_003Dz15VJ9VVI6246();
			}
			else
			{
				item.ComputeBoundingBox(_0023_003DzELu0Pss_003D, out boxMin, out boxMax);
				if (useTransformedEntityBoxesOptimization)
				{
					_0023_003DzFRVP2KBOBJQk2b9AJyiGEfc_003D?.Add(item, new Box3D(boxMin, boxMax));
				}
				if (item is BlockReference blockReference && blockReference._0023_003Dzo_00248mPqY_003D(_0023_003DzELu0Pss_003D.Blocks, _0023_003DzELu0Pss_003D.workspaceInternal?.ParentBlocks).zoomFitConvexHull == null)
				{
					_0023_003Dzo_00248mPqY_003D(_0023_003DzELu0Pss_003D.Blocks, _0023_003DzELu0Pss_003D.workspaceInternal?.ParentBlocks).zoomFitConvexHull = null;
				}
			}
			if (boxMin.X <= boxMax.X)
			{
				list.Add(boxMin);
				list.Add(boxMax);
			}
		}
		_0023_003DzDPcjoBJLcqli = Point3D.MaxValue;
		_0023_003Dz_0024N_0024yKptW9BoC = Point3D.MinValue;
		Utility.UpdateMinMax(null, list, list.Count, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		if (!flag)
		{
			_0023_003DzELu0Pss_003D.Parents.Pop();
		}
		_0023_003DzELu0Pss_003D.PopTransformation();
		return _0023_003DzDPcjoBJLcqli.X <= _0023_003Dz_0024N_0024yKptW9BoC.X;
	}

	internal void _0023_003DzFNUAUbe6oeIJ(TraversalParams _0023_003DzELu0Pss_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		useTransformedEntityBoxesOptimization = true;
		UpdateBoundingBox(_0023_003DzELu0Pss_003D);
		_0023_003DzDPcjoBJLcqli = localMin;
		_0023_003Dz_0024N_0024yKptW9BoC = localMax;
		useTransformedEntityBoxesOptimization = false;
	}

	internal void UpdateBoundingBoxQuick(TraversalParams _0023_003DzELu0Pss_003D)
	{
		Utility._0023_003DzEtuso7_p35ZOEjCHBg_003D_003D(_0023_003DzELu0Pss_003D.Blocks[BlockName].Entities, _0023_003DzELu0Pss_003D, out localMin, out localMax, out localOffset, out var _);
		UpdateBoundingBoxSphere();
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzQl4gNE9gNeLJEoPMnk7jKh0lK0Ejzmd8YfeaG8s_003D, data, _0023_003Dze9805_Rw_RXc: true);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		bool _0023_003Dz_5uhDE0_003D = data._0023_003Dz_5uhDE0_003D;
		Material parentMaterial = data.ParentMaterial;
		data._0023_003Dz_5uhDE0_003D = true;
		data.ParentMaterial = GetMaterial(data.Materials, data.Layers, data.ParentMaterial);
		_0023_003DzUT1EWEp6G6S4(data);
		Block block = data.Blocks[_blockName];
		if (block.Entities.Count > 0)
		{
			block.Compile(data);
		}
		data._0023_003Dz_5uhDE0_003D = _0023_003Dz_5uhDE0_003D;
		data.ParentMaterial = parentMaterial;
		RegenMode = regenType.NotNeeded;
	}

	internal void _0023_003DzUT1EWEp6G6S4(CompileParams _0023_003DzELu0Pss_003D)
	{
		foreach (KeyValuePair<string, AttributeReference> attribute in Attributes)
		{
			if (attribute.Value.Data.regenMode == regenType.CompileOnly)
			{
				attribute.Value.Data.Compile(_0023_003DzELu0Pss_003D);
			}
		}
	}

	public Entity[] Explode(BlockKeyedCollection blocks, bool resolveByParent = true, bool keepTessellation = false, Document document = null, bool burst = false)
	{
		TraversalParams _0023_003DzmPmPjCPqZ3T = new TraversalParams(this, blocks, document);
		GfxAttributesColorAndMaterial[] _0023_003DzxDMUADmeZWrF;
		return ExplodeInternal(_0023_003Dz7fKuZap8h713: false, null, _0023_003DzmPmPjCPqZ3T, new GfxAttributesColorAndMaterial(null, null), null, out _0023_003DzxDMUADmeZWrF, null, resolveByParent, keepTessellation, _0023_003DzNGLWIVQ_003D: false, burst);
	}

	internal Entity[] ExplodeInternal(bool _0023_003Dz7fKuZap8h713, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, TraversalParams _0023_003DzmPmPjCPqZ3T3, GfxAttributesColorAndMaterial _0023_003Dzifk54Z89G8fS, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, out GfxAttributesColorAndMaterial[] _0023_003DzxDMUADmeZWrF, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, bool _0023_003Dz7xgVbr5zq1_B = true, bool _0023_003Dzu9oxwJ_zKlMt = false, bool _0023_003DzNGLWIVQ_003D = false, bool _0023_003DzRammOI8NOXga = false)
	{
		GfxAttributesColorAndMaterial other = null;
		if (_0023_003Dz7fKuZap8h713)
		{
			if (!_0023_003DzNGLWIVQ_003D)
			{
				_0023_003DzNGLWIVQ_003D = IsSelected(_0023_003Dzq5nwX2I_003D, selectionStatusType.Permanent);
			}
			if (_0023_003Dzq5nwX2I_003D == null)
			{
				_0023_003Dzq5nwX2I_003D = new Stack<BlockReference>();
			}
			_0023_003Dzq5nwX2I_003D.Push(this);
			other = (GfxAttributesColorAndMaterial)_0023_003Dzifk54Z89G8fS.Clone();
		}
		List<GfxAttributesColorAndMaterial> list = new List<GfxAttributesColorAndMaterial>();
		List<Entity> list2 = new List<Entity>();
		Block block = ((_0023_003DzmPmPjCPqZ3T3.Blocks.Contains(_blockName) || _0023_003DzmPmPjCPqZ3T3.workspaceInternal?.ParentBlocks == null || _0023_003DzmPmPjCPqZ3T3.workspaceInternal.ParentBlocks.Count <= 0) ? _0023_003DzmPmPjCPqZ3T3.Blocks[_blockName] : _0023_003DzmPmPjCPqZ3T3.workspaceInternal.ParentBlocks[_blockName]);
		if (!_0023_003Dz7fKuZap8h713)
		{
			list2.Capacity = block.Entities.Count;
		}
		Transformation transformation = _0023_003DzmPmPjCPqZ3T3.Transformation;
		for (int i = 0; i < block.Entities.Count; i++)
		{
			Entity entity = block.Entities[i];
			Entity entity2;
			if (_0023_003Dz7fKuZap8h713)
			{
				_0023_003Dzifk54Z89G8fS.Assign(other);
				_0023_003Dzifk54Z89G8fS.Propagate(entity, _0023_003DzeWJg3NJnk3WA[LayerName], _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
				if (entity is BlockReference blockReference)
				{
					if (entity.Visible)
					{
						_0023_003DzmPmPjCPqZ3T3.PushTransformation((BlockReference)entity);
						GfxAttributesColorAndMaterial[] _0023_003DzxDMUADmeZWrF2;
						Entity[] collection = blockReference.ExplodeInternal(_0023_003Dz7fKuZap8h713, _0023_003DzeWJg3NJnk3WA, _0023_003DzmPmPjCPqZ3T3, _0023_003Dzifk54Z89G8fS, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, out _0023_003DzxDMUADmeZWrF2, _0023_003Dzq5nwX2I_003D, _0023_003Dz7xgVbr5zq1_B, _0023_003Dzu9oxwJ_zKlMt, _0023_003DzNGLWIVQ_003D);
						_0023_003DzmPmPjCPqZ3T3.PopTransformation();
						_0023_003Dzq5nwX2I_003D.Pop();
						list2.AddRange(collection);
						list.AddRange(_0023_003DzxDMUADmeZWrF2);
					}
					continue;
				}
				if (!(entity is IFace) || (!(entity is BlockReference) && _0023_003Dzifk54Z89G8fS.GetColor().A == byte.MaxValue && _0023_003Dzifk54Z89G8fS.RenderedColor.A == byte.MaxValue))
				{
					continue;
				}
				entity2 = (Entity)entity.Clone();
				entity2.Selected = _0023_003DzNGLWIVQ_003D;
				list.Add((GfxAttributesColorAndMaterial)_0023_003Dzifk54Z89G8fS.Clone());
			}
			else
			{
				if (_0023_003Dzu9oxwJ_zKlMt && !(entity is Text) && !(entity is Table))
				{
					if (entity.RegenMode == regenType.RegenAndCompile)
					{
						throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957317));
					}
					entity2 = (Entity)entity.CloneWithTessellation();
				}
				else
				{
					entity2 = (Entity)entity.Clone();
				}
				if (_0023_003DzRammOI8NOXga && entity2 is Attribute attribute && Attributes.ContainsKey(attribute.Tag))
				{
					AttributeReference attributeReference = Attributes[attribute.Tag];
					attribute.Tag = attributeReference.ToString();
					attribute.Alignment = attributeReference.Alignment;
					attribute.Plane = (Plane)attributeReference.Plane.Clone();
					attribute.WidthFactor = attributeReference.WidthFactor;
					attribute.Visible = !attributeReference.Invisible;
					attribute.ColorMethod = attributeReference.ColorMethod;
					attribute.Color = attributeReference.Color;
				}
				if (_0023_003Dz7xgVbr5zq1_B)
				{
					Entity.PropagateAttributes(this, entity2, force: false);
				}
			}
			if (entity.OrientedBounding != null)
			{
				entity2.OrientedBounding = (OrientedBoundingBox)entity.OrientedBounding.Clone();
			}
			if (entity.AutodeskProperties != null)
			{
				entity2.AutodeskProperties = entity.AutodeskProperties.Clone() as AutodeskProperties;
			}
			if (!_0023_003DzmPmPjCPqZ3T3.Transformation.IsScaleFactorUniform() && (entity2 is Circle || entity2 is Ellipse || entity2 is PlanarSurface))
			{
				double scaleFactorX = transformation.ScaleFactorX;
				double scaleFactorY = transformation.ScaleFactorY;
				double scaleFactorZ = transformation.ScaleFactorZ;
				Plane plane = null;
				plane = ((!(entity2 is PlanarEntity)) ? ((PlanarSurface)entity2).Plane : ((PlanarEntity)entity2).Plane);
				if (Vector3D.AreParallel(plane.AxisZ, Vector3D.AxisZ))
				{
					if (Utility.Compare(scaleFactorX, scaleFactorY) != 0)
					{
						entity2 = ((!(entity2 is PlanarEntity)) ? ((Entity)((PlanarSurface)entity2).GetGeneric()) : ((Entity)new LinearPath(Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(entity._vertices))));
					}
				}
				else if (Vector3D.AreParallel(plane.AxisZ, Vector3D.AxisY))
				{
					if (Utility.Compare(scaleFactorX, scaleFactorZ) != 0)
					{
						entity2 = ((!(entity2 is PlanarEntity)) ? ((Entity)((PlanarSurface)entity2).GetGeneric()) : ((Entity)new LinearPath(Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(entity._vertices))));
					}
				}
				else if (!Vector3D.AreParallel(plane.AxisZ, Vector3D.AxisX))
				{
					entity2 = ((!(entity2 is PlanarEntity)) ? ((Entity)((PlanarSurface)entity2).GetGeneric()) : ((Entity)new LinearPath(Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(entity._vertices))));
				}
				else if (Utility.Compare(scaleFactorY, scaleFactorZ) != 0)
				{
					entity2 = ((!(entity2 is PlanarEntity)) ? ((Entity)((PlanarSurface)entity2).GetGeneric()) : ((Entity)new LinearPath(Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(entity._vertices))));
				}
			}
			entity2.TransformBy(transformation);
			if (this is View view && entity2 is Dimension dimension)
			{
				dimension.LinearScale = 1.0 / view.Scale;
			}
			list2.Add(entity2);
		}
		_0023_003DzxDMUADmeZWrF = list.ToArray();
		return list2.ToArray();
	}

	public virtual void MoveTo(DrawParams data)
	{
		_0023_003Dz24qAJfg_003D(data);
	}

	private void _0023_003Dz24qAJfg_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.MultMatrixModelView(GetFullTransformation(_0023_003DzELu0Pss_003D.Blocks));
	}

	private void _0023_003DzdUEjJ2pAqEqH(DrawParams _0023_003DzELu0Pss_003D, bool _0023_003DzXXnY42Q1nOE_0024)
	{
		if (_0023_003DzXXnY42Q1nOE_0024)
		{
			MoveTo(_0023_003DzELu0Pss_003D);
		}
		else
		{
			_0023_003Dz24qAJfg_003D(_0023_003DzELu0Pss_003D);
		}
	}

	internal void GetEntitiesInPolygon(FrustumParams _0023_003DzmPmPjCPqZ3T3, bool _0023_003DzjytnZSTXee5u4cr703_OmmA_003D, out SelectedItem[] _0023_003DzVrinm7g_003D, IsInScreenDelegate _0023_003DzPtn_pSUGRWsi, bool _0023_003DzQ61OjgdtQIb86mElCQ_003D_003D, WorkspaceGetEntitiesInPolygonCallback _0023_003DzdFKmeb_0024w7Bho4zJKIg_003D_003D)
	{
		Transformation transformation = GetFullTransformation(_0023_003DzmPmPjCPqZ3T3.Blocks);
		_0023_003DzmPmPjCPqZ3T3.PushTransformation(transformation);
		_0023_003DzmPmPjCPqZ3T3.Parents.Push(this);
		_0023_003DzdFKmeb_0024w7Bho4zJKIg_003D_003D(_0023_003DzmPmPjCPqZ3T3, GetEntities(_0023_003DzmPmPjCPqZ3T3.Blocks), _0023_003DzjytnZSTXee5u4cr703_OmmA_003D, out _0023_003DzVrinm7g_003D, _0023_003DzPtn_pSUGRWsi, _0023_003DzQ61OjgdtQIb86mElCQ_003D_003D);
		_0023_003DzmPmPjCPqZ3T3.PopTransformation();
		_0023_003DzmPmPjCPqZ3T3.Parents.Pop();
	}

	private bool _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D(_0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D, FrustumParams _0023_003DzELu0Pss_003D, bool _0023_003Dze9805_Rw_RXc)
	{
		bool parentIsolated = _0023_003DzELu0Pss_003D.ParentIsolated;
		LineType parentLineType = _0023_003DzELu0Pss_003D.ParentLineType;
		_0023_003DzELu0Pss_003D.ParentIsolated = _0023_003DzELu0Pss_003D.ParentIsolated || _0023_003DzELu0Pss_003D.workspaceInternal.IsIsolated(_0023_003DzELu0Pss_003D, this);
		_0023_003DzELu0Pss_003D.ParentLineType = GetLineType(_0023_003DzELu0Pss_003D.Document.LineTypes, _0023_003DzELu0Pss_003D.Document.Layers, _0023_003DzELu0Pss_003D.ParentLineType);
		_0023_003DzELu0Pss_003D.PushTransformation(this);
		_0023_003DzELu0Pss_003D.Parents.Push(this);
		bool result = _0023_003DzvoXvCMnFQCo0t2yw3A_003D_003D(GetEntities(_0023_003DzELu0Pss_003D.Blocks), _0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D, _0023_003DzELu0Pss_003D, _0023_003Dze9805_Rw_RXc);
		_0023_003DzELu0Pss_003D.Parents.Pop();
		_0023_003DzELu0Pss_003D.PopTransformation();
		_0023_003DzELu0Pss_003D.ParentIsolated = parentIsolated;
		_0023_003DzELu0Pss_003D.ParentLineType = parentLineType;
		return result;
	}

	private bool _0023_003DzvoXvCMnFQCo0t2yw3A_003D_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, _0023_003DzF_7SIaTu5iGiZGZ2Jg_003D_003D _0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D, FrustumParams _0023_003DzmPmPjCPqZ3T3, bool _0023_003Dze9805_Rw_RXc)
	{
		_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2 = new _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D();
		_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3 = _0023_003DzmPmPjCPqZ3T3;
		_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D = _0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D;
		if (_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3.IsLeafSelection)
		{
			bool flag = false;
			{
				foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
				{
					bool flag2 = _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003Dq8VGIf5GMm9uowJRCU5NEEsAl3n7FAEr1kcTweotpIWKe0uCFJ92wPbViak709il5H1yxDlWtT1uoDbF68BYjwg_003D_003D(item);
					if (flag2 && _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3.FirstOnly)
					{
						return true;
					}
					flag = flag || flag2;
				}
				return flag;
			}
		}
		if (!_0023_003Dze9805_Rw_RXc)
		{
			return _0023_003DzWc9WmS8VMsuA.Any(_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003Dq8VGIf5GMm9uowJRCU5NEEsAl3n7FAEr1kcTweotpIWKe0uCFJ92wPbViak709il5H1yxDlWtT1uoDbF68BYjwg_003D_003D);
		}
		if (_0023_003DzWc9WmS8VMsuA.Count == 0)
		{
			return true;
		}
		bool result = false;
		foreach (Entity item2 in _0023_003DzWc9WmS8VMsuA)
		{
			if (!(item2 is Attribute) && item2.IsVisible(_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode))
			{
				result = true;
				if (!_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3.workspaceInternal.IsSelectableForIsolation(_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3, item2) || !_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003Dzy6sDJRqgqKxDKosXzw_003D_003D(item2, _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzmPmPjCPqZ3T3))
				{
					return false;
				}
			}
		}
		return result;
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D((Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D) => _0023_003Dzs_0024uS8LA_003D.IntersectEdgeOrIsoline(_0023_003DzkvBuFaE_003D), _0023_003DzELu0Pss_003D, _0023_003Dze9805_Rw_RXc: false);
	}

	internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D((Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D) => _0023_003Dzs_0024uS8LA_003D.IntersectEdgeOrIsolineScreenPolygon((ScreenPolygonParams)_0023_003DzkvBuFaE_003D), _0023_003DzELu0Pss_003D, _0023_003Dze9805_Rw_RXc: false);
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D((Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D) => _0023_003Dzs_0024uS8LA_003D.InsideOrCrossingFrustum(_0023_003DzkvBuFaE_003D), data, _0023_003Dze9805_Rw_RXc: false);
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D((Entity _0023_003Dzs_0024uS8LA_003D, FrustumParams _0023_003DzkvBuFaE_003D) => _0023_003Dzs_0024uS8LA_003D.InsideOrCrossingScreenPolygon((ScreenPolygonParams)_0023_003DzkvBuFaE_003D), data, _0023_003Dze9805_Rw_RXc: false);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzlVY23OprrcIycYJ_3goW3ro_003D, data, _0023_003Dze9805_Rw_RXc: false);
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DznOBq7ryzyQZ79fDRg8Eg1oF51xUc, data, _0023_003Dze9805_Rw_RXc: false);
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		return _0023_003DzUjUV3A_IaDmGQqnvXg_003D_003D(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzxG2K531TTliAY9IXN0aDHGpHo5w6re3j82TJLgo_003D, data, _0023_003Dze9805_Rw_RXc: true);
	}

	public override void TransformBy(Transformation xform)
	{
		Transformation = xform * transform;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		if (_0023_003DzJO1FWlQ_003D[BlockName].Entities.Count != 0)
		{
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
			obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
			obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		}
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003Dz0wVdkDSyPiY38wDh_0024it2Wow5fuuPl7r8a8kaJfYypij3(_blockName, transform.Matrix, ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new BlockReferenceSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base.BoxMin != null)
		{
			return base.BoxMax != null;
		}
		return false;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956164), _blockName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956915), transform);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956906), Attributes);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		return _0023_003DzMHGsUs_0024dF1onGPMzUA_003D_003D(blocks, layers, new Dictionary<string, Point3D[]>());
	}

	internal override Point3D[] _0023_003DzMHGsUs_0024dF1onGPMzUA_003D_003D(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, Dictionary<string, Point3D[]> _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		IList<Entity> entities = GetEntities(_0023_003DzJO1FWlQ_003D);
		if (!_0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D.ContainsKey(_blockName))
		{
			List<Point3D> list = new List<Point3D>(entities.Count * 2);
			foreach (Entity item in entities)
			{
				if (!(item is Attribute) && item.Visible && (_0023_003DzeWJg3NJnk3WA == null || _0023_003DzeWJg3NJnk3WA[item.LayerName].Visible))
				{
					list.AddRange(item._0023_003DzMHGsUs_0024dF1onGPMzUA_003D_003D(_0023_003DzJO1FWlQ_003D, _0023_003DzeWJg3NJnk3WA, _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D));
				}
			}
			Point3D[] value;
			if (list.Count > 8)
			{
				Utility.ComputeBoundingBox(list, out var boxMin, out var boxMax);
				value = Utility.GetBoundingBoxCorners(boxMin, boxMax);
			}
			else
			{
				value = list.ToArray();
			}
			_0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D.Add(_blockName, value);
		}
		Point3D[] array = _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D[_blockName].ToArray();
		_0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(array, _0023_003DzJO1FWlQ_003D);
		return array;
	}

	public void Transform(IList<Point3D> points, BlockKeyedCollection blocks)
	{
		_0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(points, blocks);
	}

	private void _0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(IList<Point3D> _0023_003DzYJ7TqZnPFT4uCILkBg_003D_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		int count = _0023_003DzYJ7TqZnPFT4uCILkBg_003D_003D.Count;
		Block block = _0023_003DzJO1FWlQ_003D[_blockName];
		for (int i = 0; i < count; i++)
		{
			_0023_003DzYJ7TqZnPFT4uCILkBg_003D_003D[i] = transform * (_0023_003DzYJ7TqZnPFT4uCILkBg_003D_003D[i] - block.BasePoint);
		}
	}

	internal override void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		_0023_003DzELu0Pss_003D.PushTransformation(this);
		_0023_003DzELu0Pss_003D.Parents.Push(this);
		_0023_003DzhSj4NWLzpllgkRXNhvst5vw_003D(_0023_003DzELu0Pss_003D.Blocks[_blockName].Entities, _0023_003DzELu0Pss_003D);
		_0023_003DzELu0Pss_003D.Parents.Pop();
		_0023_003DzELu0Pss_003D.PopTransformation();
	}

	internal static void _0023_003DzhSj4NWLzpllgkRXNhvst5vw_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, FindClosestVerticesParams _0023_003DzELu0Pss_003D)
	{
		for (int i = 0; i < _0023_003DzWc9WmS8VMsuA.Count; i++)
		{
			Entity entity = _0023_003DzWc9WmS8VMsuA[i];
			if (!(entity is Attribute) && (_0023_003DzELu0Pss_003D.entType.IsInstanceOfType(entity) || entity is BlockReference) && entity.Visible && _0023_003DzELu0Pss_003D.Document.Layers[entity.LayerName].Visible)
			{
				entity.FindClosestVertices(_0023_003DzELu0Pss_003D, i);
			}
		}
	}

	public IList<HitTriangle> FindClosestTriangle(Segment3D seg, BlockKeyedCollection blocks)
	{
		IList<HitTriangle> _0023_003DzOLHnb2M_003D = new List<HitTriangle>();
		return _0023_003DzC3xljkt4lyntnm05CQ_003D_003D(this, _0023_003DzOLHnb2M_003D, Transformation, blocks, seg);
	}

	private IList<HitTriangle> _0023_003DzC3xljkt4lyntnm05CQ_003D_003D(BlockReference _0023_003Dzalvl9z8_003D, IList<HitTriangle> _0023_003DzOLHnb2M_003D, Transformation _0023_003DzWnm9mSpVADEl, BlockKeyedCollection _0023_003DzCIIJPkRNO_27, Segment3D _0023_003DzJ_0024N5unzMWdRB)
	{
		Transformation transformation = (Transformation)_0023_003DzWnm9mSpVADEl.Clone();
		foreach (Block item in _0023_003DzCIIJPkRNO_27)
		{
			if (!(item.Name == _0023_003Dzalvl9z8_003D.BlockName))
			{
				continue;
			}
			foreach (Entity entity in item.Entities)
			{
				if (entity is Mesh)
				{
					IList<HitTriangle> list = ((Mesh)entity).FindClosestTriangle(transformation, _0023_003DzJ_0024N5unzMWdRB);
					transformation = (Transformation)_0023_003DzWnm9mSpVADEl.Clone();
					foreach (HitTriangle item2 in list)
					{
						_0023_003DzOLHnb2M_003D.Add(item2);
					}
				}
				else if (entity is BlockReference)
				{
					_0023_003DzWnm9mSpVADEl *= ((BlockReference)entity).Transformation;
					_0023_003DzC3xljkt4lyntnm05CQ_003D_003D((BlockReference)entity, _0023_003DzOLHnb2M_003D, _0023_003DzWnm9mSpVADEl, _0023_003DzCIIJPkRNO_27, _0023_003DzJ_0024N5unzMWdRB);
					_0023_003DzWnm9mSpVADEl = (Transformation)transformation.Clone();
				}
				else
				{
					if (!(entity is Solid))
					{
						continue;
					}
					IList<HitTriangle> list2 = ((Solid)entity).FindClosestTriangle(transformation, _0023_003DzJ_0024N5unzMWdRB);
					transformation = (Transformation)_0023_003DzWnm9mSpVADEl.Clone();
					foreach (HitTriangle item3 in list2)
					{
						_0023_003DzOLHnb2M_003D.Add(item3);
					}
				}
			}
		}
		return _0023_003DzOLHnb2M_003D;
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		_0023_003DzELu0Pss_003D.PushTransformation(this);
		_0023_003DzELu0Pss_003D.Parents.Push(this);
		bool result = _0023_003Dz46TdCSv4NiVERbommQ_003D_003D(_0023_003DzELu0Pss_003D.Blocks[_blockName].Entities, _0023_003DzELu0Pss_003D);
		_0023_003DzELu0Pss_003D.Parents.Pop();
		_0023_003DzELu0Pss_003D.PopTransformation();
		return result;
	}

	private Transformation _0023_003Dz3g9Q5YiWL7TC7cdhWQ_003D_003D<T>(IDictionary<string, T> _0023_003DzJO1FWlQ_003D) where T : Block
	{
		Transformation transformation = new Identity();
		_0023_003Dz3g9Q5YiWL7TC7cdhWQ_003D_003D(_0023_003DzJO1FWlQ_003D[_blockName], transformation);
		return transformation;
	}

	private static void _0023_003Dz3g9Q5YiWL7TC7cdhWQ_003D_003D(Block _0023_003DzLeyHB00_003D, Transformation _0023_003DzNDQ_E88_003D)
	{
		_0023_003DzNDQ_E88_003D[0, 3] = 0.0 - _0023_003DzLeyHB00_003D.BasePoint.X;
		_0023_003DzNDQ_E88_003D[1, 3] = 0.0 - _0023_003DzLeyHB00_003D.BasePoint.Y;
		_0023_003DzNDQ_E88_003D[2, 3] = 0.0 - _0023_003DzLeyHB00_003D.BasePoint.Z;
	}

	internal static bool _0023_003Dz46TdCSv4NiVERbommQ_003D_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, FindClosestVertexParams _0023_003DzELu0Pss_003D)
	{
		bool result = false;
		for (int i = 0; i < _0023_003DzWc9WmS8VMsuA.Count; i++)
		{
			Entity entity = _0023_003DzWc9WmS8VMsuA[i];
			if (!(entity is Attribute) && (_0023_003DzELu0Pss_003D.entType.IsInstanceOfType(entity) || entity is BlockReference) && entity.Visible && _0023_003DzELu0Pss_003D.Document.Layers[entity.LayerName].Visible && entity.FindClosestVertex(_0023_003DzELu0Pss_003D, i))
			{
				result = true;
			}
		}
		return result;
	}

	internal override SilhoWireData _0023_003DzOQ9MbnSofHiL_xtPyyGkf6ozeVZJ(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		Block block = _0023_003DzELu0Pss_003D.Blocks[_blockName];
		foreach (Entity entity in block.Entities)
		{
			if (entity.silhoData != null)
			{
				return null;
			}
			if (entity.entityNature != entityNatureType.Wire)
			{
				HiddenLinesView.PreProcessSilhouettesForDraw(block.Entities, _0023_003DzELu0Pss_003D);
				return null;
			}
		}
		return null;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957460), _blockName);
	}

	internal _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzc_0024xt7GEbkJyS(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Transformation _0023_003Dz4wZe_0024Xg_003D, bool _0023_003DzXNaz2CIaoHiD)
	{
		_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2 = new _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D();
		_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz8oO_z_0024d8gNK7 = WriteSTEP._0023_003DzS0Pr1Qk_003D(_blockName);
		if (_0023_003Dz4wZe_0024Xg_003D == null)
		{
			_0023_003Dz4wZe_0024Xg_003D = GetFullTransformation(_0023_003DzJO1FWlQ_003D);
		}
		double[] _0023_003DzB65HsyI_003D = new double[3]
		{
			_0023_003Dz4wZe_0024Xg_003D.Matrix[0, 3],
			_0023_003Dz4wZe_0024Xg_003D.Matrix[1, 3],
			_0023_003Dz4wZe_0024Xg_003D.Matrix[2, 3]
		};
		Vector3D vector3D = new Vector3D(_0023_003Dz4wZe_0024Xg_003D.Matrix[0, 0], _0023_003Dz4wZe_0024Xg_003D.Matrix[1, 0], _0023_003Dz4wZe_0024Xg_003D.Matrix[2, 0]);
		vector3D.Normalize();
		Vector3D vector3D2 = new Vector3D(_0023_003Dz4wZe_0024Xg_003D.Matrix[0, 2], _0023_003Dz4wZe_0024Xg_003D.Matrix[1, 2], _0023_003Dz4wZe_0024Xg_003D.Matrix[2, 2]);
		vector3D2.Normalize();
		double[] _0023_003DzjRTUPbA_003D = new double[3];
		double[] _0023_003Dz6FS6YUJeDBxqkdVwuw_003D_003D = new double[3] { 1.0, 0.0, 0.0 };
		double[] _0023_003DzOaxWKZA_003D = new double[3] { 0.0, 0.0, 1.0 };
		_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzXjOCl3g_003D(_0023_003DzB65HsyI_003D, vector3D2.ToArray(), vector3D.ToArray(), _0023_003DzjRTUPbA_003D, _0023_003DzOaxWKZA_003D, _0023_003Dz6FS6YUJeDBxqkdVwuw_003D_003D);
		return _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		data.PushTransformation(this);
		data.Parents.Push(this);
		Block block = _0023_003Dzo_00248mPqY_003D(data.Blocks, data.workspaceInternal?.ParentBlocks);
		if (block.zoomFitConvexHull != null && !ParallelConveHull.Instance.IsBusy())
		{
			PointF minQ = data.MinQ._0023_003Dzx9P_oXY_003D();
			PointF maxQ = data.MaxQ._0023_003Dzx9P_oXY_003D();
			Entity.ComputeOffsetOnCameraAxes(data.Transformation, block.zoomFitConvexHull, block.zoomFitConvexHull.Length, data.m1, data.m2, ref minQ, ref maxQ, 0);
			data.MinQ = minQ;
			data.MaxQ = maxQ;
		}
		else
		{
			_0023_003Dzh77AI_0024MD2bzqvv_0024XyWIs4S4_003D(GetEntities(data.Blocks), Attributes, data);
		}
		data.Parents.Pop();
		data.PopTransformation();
	}

	private static void _0023_003Dzh77AI_0024MD2bzqvv_0024XyWIs4S4_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, AttributeReferenceDictionary _0023_003DzSwO927XKVl3g, OffsetOnCameraAxesParams _0023_003DzmPmPjCPqZ3T3)
	{
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (!(item is Attribute) && item.IsVisible(_0023_003DzmPmPjCPqZ3T3.Parents, _0023_003DzmPmPjCPqZ3T3.Document.Layers, _0023_003DzmPmPjCPqZ3T3.Document.AttributeReferenceVisibilityMode))
			{
				item.ComputeOffsetOnCameraAxes(_0023_003DzmPmPjCPqZ3T3);
			}
		}
	}

	internal bool _0023_003Dzxbr8_0024Jk_003D(BlockReference _0023_003Dz5I3b_GM_003D, Dictionary<string, Block> _0023_003DzJO1FWlQ_003D)
	{
		if (this == _0023_003Dz5I3b_GM_003D)
		{
			return true;
		}
		Block block = _0023_003DzJO1FWlQ_003D[_blockName];
		for (int i = 0; i < block.Entities.Count; i++)
		{
			Entity entity = block.Entities[i];
			if (entity is BlockReference && ((BlockReference)entity)._0023_003Dzxbr8_0024Jk_003D(_0023_003Dz5I3b_GM_003D, _0023_003DzJO1FWlQ_003D))
			{
				return true;
			}
		}
		return false;
	}

	internal bool _0023_003DzsQAoLomWIpW0(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzEkR_P10_003D)
	{
		Block block = _0023_003DzJO1FWlQ_003D[BlockName];
		Dictionary<string, Attribute> dictionary = new Dictionary<string, Attribute>();
		foreach (Entity entity in block.Entities)
		{
			if (entity is Attribute)
			{
				Attribute attribute = (Attribute)entity;
				if (!dictionary.ContainsKey(attribute.Tag) && Attributes.ContainsKey(attribute.Tag))
				{
					dictionary.Add(attribute.Tag, attribute);
				}
			}
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, AttributeReference> attribute2 in Attributes)
		{
			if (!dictionary.ContainsKey(attribute2.Key))
			{
				list.Add(attribute2.Key);
			}
		}
		foreach (string item in list)
		{
			Attributes.Remove(item);
		}
		if (_0023_003DzEkR_P10_003D)
		{
			foreach (KeyValuePair<string, AttributeReference> attribute3 in Attributes)
			{
				attribute3.Value.SynchronizeAttributes(dictionary[attribute3.Key]);
			}
		}
		else
		{
			foreach (KeyValuePair<string, AttributeReference> attribute4 in Attributes)
			{
				if (attribute4.Value.needsSynchronization)
				{
					attribute4.Value.SynchronizeAttributes(dictionary[attribute4.Key]);
				}
			}
		}
		transformedEntityBoxes.Clear();
		Attributes.needSynchronization = false;
		return Attributes.Count > 0;
	}

	protected internal virtual void PopParents(DrawParams gfxData)
	{
		gfxData.Parents.Pop();
		gfxData.FullParents.Pop();
	}

	protected internal virtual void PushParents(DrawParams gfxData)
	{
		gfxData.Parents.Push(this);
		gfxData.FullParents.Push(this);
	}

	protected internal virtual void Draw(DrawEntitiesParams myParams, WorkspaceDrawCallback drawCall)
	{
		myParams.Workspace.RenderContext.EndDrawBufferedLines();
		myParams.Workspace.RenderContext.PushModelView();
		bool flag = false;
		_0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922 obj = new _0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922(myParams);
		DrawParams drawParams = myParams.DrawParams;
		drawParams.Attributes.PropagateLayer0(this, myParams.Workspace.Layers.GetItemFast(LayerName));
		if (!myParams._0023_003DzHwUoFCUb88ry().skipMoveTo)
		{
			_0023_003DzdUEjJ2pAqEqH(drawParams, myParams._0023_003DzHwUoFCUb88ry().IsAnimationRunning);
		}
		Transformation blockRefTransform = null;
		Transformation transformation = GetFullTransformation(drawParams.Blocks);
		drawParams.Transformation = ((drawParams.Transformation != null) ? (drawParams.Transformation * transformation) : transformation);
		if (drawParams.ShaderParams != null && (drawParams.ShaderParams.DoShadows || drawParams.PlanarReflections) && drawParams.ShaderParams.BlockRefTransform != null)
		{
			blockRefTransform = drawParams.ShaderParams.BlockRefTransform;
			drawParams.ShaderParams.BlockRefTransform = drawParams.Transformation;
			flag = true;
			drawParams.RenderContext.SetBlockRefTransform(drawParams.ShaderParams.BlockRefTansformMatrix);
		}
		drawParams.ParentIsolated = drawParams.ParentIsolated || myParams._0023_003DzHwUoFCUb88ry().IsIsolated(drawParams, this);
		bool flag2 = myParams._0023_003DzHwUoFCUb88ry().IsSelected(drawParams.ParentSelected, drawParams, this);
		myParams.selectionFound |= flag2;
		drawParams.ParentSelected = drawParams.ParentSelected || myParams._0023_003DzHwUoFCUb88ry().ShouldDrawAsSelected(flag2, drawParams);
		drawParams.ParentClippable = drawParams.ParentClippable && GetClippability(drawParams.Parents);
		drawParams.ScreenToWorld /= (float)maxScaleFactor;
		myParams.entList = GetEntities(drawParams.Blocks);
		PushParents(drawParams);
		bool frontFaceCW = drawParams.RenderContext.FrontFaceCW;
		if (Transformation.HasReflection)
		{
			drawParams.RenderContext.FrontFaceCW = !drawParams.RenderContext.FrontFaceCW;
		}
		drawParams.RasterViewForceGrayAlpha = ((this is View view) ? view._0023_003DztW86fAgbAiheM10M56ksjfw_003D() : 1f);
		drawCall(myParams);
		Draw(myParams.DrawParams);
		drawParams.RenderContext.FrontFaceCW = frontFaceCW;
		PopParents(drawParams);
		obj._0023_003Dz4q7Sk_A_003D(myParams);
		if (flag)
		{
			drawParams.ShaderParams.BlockRefTransform = blockRefTransform;
			drawParams.RenderContext.SetBlockRefTransform(drawParams.ShaderParams.BlockRefTansformMatrix);
		}
		myParams.Workspace.RenderContext.PopModelView();
	}

	protected internal override void Draw(DrawParams data)
	{
	}

	protected internal virtual void DrawForSelection(DrawEntitiesParams myParams, WorkspaceDrawForSelectionCallback drawCall)
	{
		myParams.Workspace.RenderContext.EndDrawBufferedLines();
		myParams.Workspace.RenderContext.PushModelView();
		_0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922 obj = new _0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922(myParams);
		DrawParams drawParams = myParams.DrawParams;
		_0023_003DzdUEjJ2pAqEqH(drawParams, myParams._0023_003DzHwUoFCUb88ry().IsAnimationRunning);
		drawParams.ParentIsolated = drawParams.ParentIsolated || myParams._0023_003DzHwUoFCUb88ry().IsIsolated(drawParams, this);
		myParams.entList = GetEntities(drawParams.Blocks);
		Transformation transformation = GetFullTransformation(drawParams.Blocks);
		drawParams.Transformation = ((drawParams.Transformation != null) ? (drawParams.Transformation * transformation) : transformation);
		drawParams.Parents.Push(this);
		drawParams.FullParents.Push(this);
		if (myParams.SelectInScope)
		{
			myParams._0023_003DzOryvhzXb10Kb();
		}
		drawCall(myParams);
		drawParams.Parents.Pop();
		drawParams.FullParents.Pop();
		bool inScope = myParams.InScope;
		obj._0023_003Dz4q7Sk_A_003D(myParams);
		myParams.Workspace.RenderContext.PopModelView();
		if (myParams.SelectInScope)
		{
			if (!myParams.InScope && inScope)
			{
				myParams.Workspace.RenderContext.SetColorWireframe(Color.White);
			}
		}
		else if (drawParams.Parents.Count == 0)
		{
			((DrawForSelectionParams)drawParams).FalseColorIndex++;
		}
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		data.RenderContext.PushModelView();
		_0023_003DzdUEjJ2pAqEqH(data, data.viewportInternal.parent.IsAnimationRunning);
		data.Parents.Push(this);
		data.FullParents.Push(this);
		ShadowHelper.DrawTrianglesForPlanarShadow(data, data.Blocks[_blockName].Entities);
		data.Parents.Pop();
		data.FullParents.Pop();
		data.RenderContext.PopModelView();
	}

	protected internal virtual bool DrawTrianglesForShadowMap(DrawEntitiesParams data)
	{
		data.Workspace.RenderContext.PushModelView();
		_0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922 _0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH923 = new _0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH922(data);
		_0023_003DzdUEjJ2pAqEqH(data.DrawParams, data._0023_003DzHwUoFCUb88ry().IsAnimationRunning);
		data.entList = GetEntities(data.Blocks);
		data.DrawParams.Parents.Push(this);
		data.DrawParams.FullParents.Push(this);
		data.simplify = false;
		bool result = data._0023_003DzHwUoFCUb88ry().DrawTrianglesForShadowMap(data);
		data.DrawParams.Parents.Pop();
		data.DrawParams.FullParents.Pop();
		_0023_003DzwTkSFaUDc1GLoedJA_JzDV_0024nH923._0023_003Dz4q7Sk_A_003D(data);
		data.Workspace.RenderContext.PopModelView();
		return result;
	}

	internal _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK _0023_003DzCvxG2A3KpWd8()
	{
		if (_basis == null)
		{
			_basis = new _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK(Transformation, (localMax == null || localMin == null) ? 1.0 : (1.0 / Math.Max(base.BoxSize.Diagonal, 1.0)));
		}
		return _basis;
	}
}
