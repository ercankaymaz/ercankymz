using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public abstract class Entity : ISerializable, ICloneable, IDisposable, IEntity, IEntityInternal, ISelectableItem, INotifyVisibleChanged
{
	internal delegate bool _0023_003Dz19nN745v9jgEVzj8BA_003D_003D(int _0023_003Dz3Ftsho0_003D, int _0023_003Dz13KtlVg_003D, string _0023_003DzwyYng5o_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, DoWorkEventArgs _0023_003DzorPxIr8Ftp0F, bool _0023_003DzW1fghQo_003D = false, params string[] _0023_003Dz53Cncpw_003D);

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<byte, bool> _0023_003DzziFbJyKAN6LYkVi_mQ_003D_003D;

		public static Func<int, bool> _0023_003DzAUqKWxoWkTK1M7_E_A_003D_003D;

		internal bool _0023_003DzyMUJMR34aEsJzC4BbAAyAZa7A5aN(byte _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D > 0;
		}

		internal bool _0023_003DzXeiYpaEUB_0024Pnd3FL_0024i9LjRRh6LjF8ZSIBg_003D_003D(int _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D > 0;
		}
	}

	[CompilerGenerated]
	private Tuple<ICurve, bool> _003CCavalierOriginalCurveInfo_003Ek__BackingField;

	internal global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<Entity, SketchItem> sketchLink;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private VisibleChangedEventHandler _0023_003Dz256ZxNw_003D;

	private bool _visible = true;

	[CompilerGenerated]
	private List<SelectabilityInfo> _003CInstanceSelectabilityInfo_003Ek__BackingField;

	[CompilerGenerated]
	private List<ClippabilityInfo> _003CInstanceClippabilityInfo_003Ek__BackingField;

	internal bool visibleAndInFrustum = true;

	internal bool isDirtyForFlattenTree;

	private string _layerName = Layer.DefaultLayerName;

	private string _lineTypeName;

	private float _lineTypeScale = 1f;

	private colorMethodType lineTypeMethod = colorMethodType.byLayer;

	private Color _color;

	private colorMethodType _colorMethod;

	private string _materialName;

	private colorMethodType _lineWeightMethod;

	private float _lineWeight;

	internal QuadTree _subdivisionTree;

	internal Point3D[] _vertices;

	protected internal EntityGraphicsData drawData;

	protected internal EntityGraphicsData drawPattern;

	internal regenType regenMode = regenType.RegenAndCompile;

	internal Point3D localMin;

	internal Point3D localMax;

	internal double localOffset;

	internal Point3D sphereCenter;

	internal double sphereRadius;

	private readonly List<Entity> _subEntityToDispose = new List<Entity>();

	internal double screenSize;

	protected OrientedBoundingRect _localOB;

	internal SilhoWireData silhoData;

	internal int[,] sharedEdgesForSilhouettesDraw;

	public TranslationIdentifier TranslationID { get; set; }

	public virtual object EntityData { get; set; }

	internal virtual SelectionInfoItem _selectionInfo { get; } = new SelectionInfoItem(null, null);

	internal virtual List<SelectionInfoItem> InstanceSelectionInfo { get; } = new List<SelectionInfoItem>();

	public bool Selected
	{
		get
		{
			return GetSelection();
		}
		set
		{
			SetSelection(value);
		}
	}

	internal List<VisibilityInfo> instanceVisibilityInfo { get; set; }

	public virtual bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			bool num = _visible != value;
			_visible = value;
			if (num)
			{
				_0023_003DzoC5Ax2mpp_0024GS();
			}
		}
	}

	public virtual bool Selectable { get; set; }

	public virtual bool Clippable { get; set; } = true;

	protected internal entityNatureType entityNature { get; set; }

	public virtual string LayerName
	{
		get
		{
			return _layerName;
		}
		set
		{
			_layerName = value;
			if (this is ICurve)
			{
				_0023_003DznGg4zZpR1yr2ytDGOA_003D_003D(this, colorMethodType.byLayer);
			}
			if (_colorMethod == colorMethodType.byLayer || _lineWeightMethod == colorMethodType.byLayer || lineTypeMethod == colorMethodType.byLayer)
			{
				isDirtyForFlattenTree = true;
			}
		}
	}

	public virtual AutodeskProperties AutodeskProperties { get; set; }

	public IfcProperties IfcProperties { get; set; }

	public int GroupIndex { get; set; }

	public int PrintOrder { get; set; }

	public virtual string LineTypeName
	{
		get
		{
			return _lineTypeName;
		}
		set
		{
			_lineTypeName = value;
			_0023_003DznGg4zZpR1yr2ytDGOA_003D_003D(this, colorMethodType.byEntity);
			if (lineTypeMethod == colorMethodType.byEntity)
			{
				isDirtyForFlattenTree = true;
			}
		}
	}

	public virtual float LineTypeScale
	{
		get
		{
			return _lineTypeScale;
		}
		set
		{
			_lineTypeScale = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public virtual colorMethodType LineTypeMethod
	{
		get
		{
			return lineTypeMethod;
		}
		set
		{
			lineTypeMethod = value;
			if (RegenMode == regenType.NotNeeded)
			{
				RegenMode = regenType.CompileOnly;
			}
			isDirtyForFlattenTree = true;
		}
	}

	public virtual Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			if (_colorMethod == colorMethodType.byEntity)
			{
				isDirtyForFlattenTree = true;
			}
		}
	}

	public virtual colorMethodType ColorMethod
	{
		get
		{
			return _colorMethod;
		}
		set
		{
			_colorMethod = value;
			isDirtyForFlattenTree = true;
		}
	}

	public virtual string MaterialName
	{
		get
		{
			return _materialName;
		}
		set
		{
			_materialName = value;
			if (_colorMethod == colorMethodType.byEntity)
			{
				isDirtyForFlattenTree = true;
			}
		}
	}

	public virtual colorMethodType LineWeightMethod
	{
		get
		{
			return _lineWeightMethod;
		}
		set
		{
			_lineWeightMethod = value;
			isDirtyForFlattenTree = true;
		}
	}

	public virtual float LineWeight
	{
		get
		{
			return _lineWeight;
		}
		set
		{
			if (value <= 0f)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967959));
			}
			_lineWeight = value;
			if (_lineWeightMethod == colorMethodType.byEntity)
			{
				isDirtyForFlattenTree = true;
			}
		}
	}

	public virtual regenType RegenMode
	{
		get
		{
			return regenMode;
		}
		set
		{
			regenMode = value;
			if (regenMode != regenType.NotNeeded)
			{
				_subdivisionTree = null;
				isDirtyForFlattenTree = true;
			}
			if (regenMode == regenType.RegenAndCompile)
			{
				silhoData = null;
				sharedEdgesForSilhouettesDraw = null;
				if (this is Mesh mesh)
				{
					mesh.sharedEdges = null;
				}
			}
		}
	}

	public virtual Point3D[] Vertices
	{
		get
		{
			return _vertices;
		}
		set
		{
			_vertices = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point3D BoxMin => localMin;

	public Point3D BoxMax => localMax;

	public Size3D BoxSize
	{
		get
		{
			Point3D point3D = localMax - localMin;
			return new Size3D(point3D.X, point3D.Y, point3D.Z);
		}
	}

	public OrientedBoundingRect OrientedBounding
	{
		get
		{
			return _localOB;
		}
		set
		{
			_localOB = value;
		}
	}

	protected internal virtual haloType HaloMode
	{
		get
		{
			if (!IsPolygonal())
			{
				return haloType.None;
			}
			return haloType.Thick;
		}
	}

	protected bool Compiling { get; set; }

	internal virtual bool UseMaterialTextureLength => false;

	public event VisibleChangedEventHandler VisibleChanged
	{
		[CompilerGenerated]
		add
		{
			VisibleChangedEventHandler visibleChangedEventHandler = _0023_003Dz256ZxNw_003D;
			VisibleChangedEventHandler visibleChangedEventHandler2;
			do
			{
				visibleChangedEventHandler2 = visibleChangedEventHandler;
				VisibleChangedEventHandler value2 = (VisibleChangedEventHandler)Delegate.Combine(visibleChangedEventHandler2, value);
				visibleChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz256ZxNw_003D, value2, visibleChangedEventHandler2);
			}
			while ((object)visibleChangedEventHandler != visibleChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			VisibleChangedEventHandler visibleChangedEventHandler = _0023_003Dz256ZxNw_003D;
			VisibleChangedEventHandler visibleChangedEventHandler2;
			do
			{
				visibleChangedEventHandler2 = visibleChangedEventHandler;
				VisibleChangedEventHandler value2 = (VisibleChangedEventHandler)Delegate.Remove(visibleChangedEventHandler2, value);
				visibleChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz256ZxNw_003D, value2, visibleChangedEventHandler2);
			}
			while ((object)visibleChangedEventHandler != visibleChangedEventHandler2);
		}
	}

	protected Entity()
	{
		sketchLink = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<Entity, SketchItem>(this);
	}

	protected Entity(SerializationInfo info, StreamingContext context)
		: this()
	{
		entityNature = (entityNatureType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967701), typeof(entityNatureType));
		LayerName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967684));
		GroupIndex = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967411));
		ColorMethod = (colorMethodType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967397), typeof(colorMethodType));
		Color = (Color)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829), typeof(Color));
		MaterialName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967386), typeof(string));
		LineWeightMethod = (colorMethodType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967367), typeof(colorMethodType));
		LineWeight = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967330));
		LineTypeMethod = (colorMethodType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967316), typeof(colorMethodType));
		LineTypeName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967305), typeof(string));
		LineTypeScale = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967552));
		EntityData = info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957282), typeof(object));
		Visible = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967510));
		Selectable = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967492));
		Clippable = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967475));
		AutodeskProperties = (AutodeskProperties)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967459), typeof(AutodeskProperties));
		IfcProperties = (IfcProperties)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967454), typeof(IfcProperties));
		PrintOrder = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968178));
	}

	protected Entity(Color color, entityNatureType nature)
		: this()
	{
		entityNature = nature;
		Visible = true;
		Color = color;
		MaterialName = null;
		LineWeight = 0.5f;
		ColorMethod = colorMethodType.byLayer;
		LineWeightMethod = colorMethodType.byLayer;
		Selected = false;
		Selectable = true;
		GroupIndex = -1;
	}

	protected Entity(entityNatureType nature)
		: this(Color.Black, nature)
	{
	}

	protected Entity(Entity another, bool keepTessellation = false)
		: this()
	{
		if (another is ICurve)
		{
			((ICurve)this).EdgeIndex = ((ICurve)another).EdgeIndex;
			((ICurve)this).FromBooleanIntersection = ((ICurve)another).FromBooleanIntersection;
		}
		entityNature = another.entityNature;
		Visible = another.Visible;
		Selectable = another.Selectable;
		LayerName = another.LayerName;
		GroupIndex = another.GroupIndex;
		ColorMethod = another.ColorMethod;
		Color = another.Color;
		if (another.MaterialName != null)
		{
			MaterialName = another.MaterialName;
		}
		LineWeightMethod = another.LineWeightMethod;
		LineWeight = another.LineWeight;
		LineTypeMethod = another.LineTypeMethod;
		LineTypeName = another.LineTypeName;
		LineTypeScale = another.LineTypeScale;
		if (another.EntityData is ICloneable cloneable)
		{
			EntityData = cloneable.Clone();
		}
		else if (another.EntityData is ValueType)
		{
			EntityData = another.EntityData;
		}
		PrintOrder = another.PrintOrder;
		if (another.AutodeskProperties != null)
		{
			AutodeskProperties = (AutodeskProperties)another.AutodeskProperties.Clone();
		}
		if (another.IfcProperties != null)
		{
			IfcProperties = (IfcProperties)another.IfcProperties.Clone();
		}
		if (keepTessellation)
		{
			_0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(another);
			_0023_003DzUAbMrNstr8eH(another);
			regenMode = regenType.CompileOnly;
		}
		if (another.TranslationID != null)
		{
			TranslationID = (TranslationIdentifier)another.TranslationID.Clone();
		}
		Clippable = another.Clippable;
	}

	internal Tuple<ICurve, bool> _0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D()
	{
		return _003CCavalierOriginalCurveInfo_003Ek__BackingField;
	}

	internal void _0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D(Tuple<ICurve, bool> _0023_003DzPzO_0024GUk_003D)
	{
		_003CCavalierOriginalCurveInfo_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	private protected void _0023_003DzCBXaK_002496NUpX(byte _0023_003DzHBMcsnabCilx)
	{
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzCBXaK_002496NUpX(_0023_003DzHBMcsnabCilx, this);
	}

	public virtual bool IsValid(StringBuilder log = null)
	{
		return true;
	}

	public abstract EntitySurrogate ConvertToSurrogate();

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967701), entityNature);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967684), LayerName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967411), GroupIndex);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967397), ColorMethod);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829), Color);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967386), MaterialName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967367), LineWeightMethod);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967330), LineWeight);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967316), LineTypeMethod);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967305), LineTypeName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967552), LineTypeScale);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957282), EntityData);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967510), Visible);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967492), Selectable);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967475), Clippable);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967459), AutodeskProperties);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967454), IfcProperties);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968178), PrintOrder);
	}

	public abstract object Clone();

	public abstract object CloneWithTessellation();

	private protected virtual void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
		if (_0023_003Dzb7SPTpc_003D.Vertices != null)
		{
			Vertices = Utility._0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(_0023_003Dzb7SPTpc_003D.Vertices);
		}
	}

	internal void _0023_003DzUAbMrNstr8eH(Entity _0023_003Dzb7SPTpc_003D)
	{
		localMin = (Point3D)(_0023_003Dzb7SPTpc_003D.localMin?.Clone());
		localMax = (Point3D)(_0023_003Dzb7SPTpc_003D.localMax?.Clone());
		sphereCenter = (Point3D)(_0023_003Dzb7SPTpc_003D.sphereCenter?.Clone());
		sphereRadius = _0023_003Dzb7SPTpc_003D.sphereRadius;
	}

	public virtual void TransformBy(Transformation xform)
	{
		bool flag = IsCurved();
		bool flag2 = RegenMode == regenType.RegenAndCompile || (xform.HasScaling && flag);
		_0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(xform, flag2);
		if (flag2)
		{
			RegenMode = regenType.RegenAndCompile;
			localMin = (localMax = null);
		}
		else
		{
			_0023_003Dzl_SRSHmkyuNv(xform);
		}
		if (OrientedBounding != null)
		{
			if (xform.IsScaleFactorUniform())
			{
				OrientedBounding._0023_003DzK3EEX2U_003D(xform);
			}
			else if (!flag2)
			{
				UpdateOrientedBoundingBox(new TraversalParams());
				OrientedBounding._0023_003DziQOhVy0_003D = true;
			}
			else
			{
				OrientedBounding = null;
			}
		}
	}

	private protected virtual void _0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(Transformation _0023_003DzLS0sR0pzioXc, bool _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
	{
		if (_vertices != null && !(IsCurved() && _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D))
		{
			TransformAllVertices(_0023_003DzLS0sR0pzioXc);
		}
	}

	private protected virtual void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		RegenMode = regenType.CompileOnly;
		if (!_0023_003DzLS0sR0pzioXc.HasRotation && !_0023_003DzLS0sR0pzioXc.HasReflection)
		{
			localMin.TransformBy(_0023_003DzLS0sR0pzioXc);
			localMax.TransformBy(_0023_003DzLS0sR0pzioXc);
			UpdateBoundingBoxSphere();
		}
		else
		{
			UpdateBoundingBox(null);
		}
		silhoData = null;
	}

	internal static void _0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(Point3D[] _0023_003DzJs2WPVlNsiqa, Transformation _0023_003DzNDQ_E88_003D)
	{
		int num = _0023_003DzJs2WPVlNsiqa.Length;
		if (num <= 0)
		{
			return;
		}
		if (_0023_003DzNDQ_E88_003D.IsTranslation)
		{
			for (int i = 0; i < num; i++)
			{
				Point3D point3D = _0023_003DzJs2WPVlNsiqa[i];
				point3D.X += _0023_003DzNDQ_E88_003D.Matrix[0, 3];
				point3D.Y += _0023_003DzNDQ_E88_003D.Matrix[1, 3];
				point3D.Z += _0023_003DzNDQ_E88_003D.Matrix[2, 3];
			}
			return;
		}
		if (_0023_003DzJs2WPVlNsiqa[0] is PointNormalUv)
		{
			Transformation matrixForNormals = Utility.GetMatrixForNormals(_0023_003DzNDQ_E88_003D);
			bool hasScaling = _0023_003DzNDQ_E88_003D.HasScaling;
			for (int j = 0; j < num; j++)
			{
				PointNormalUv pointNormalUv = (PointNormalUv)_0023_003DzJs2WPVlNsiqa[j];
				double[] array = _0023_003DzNDQ_E88_003D.ActOnLeftOne(pointNormalUv.X, pointNormalUv.Y, pointNormalUv.Z);
				pointNormalUv.X = array[0];
				pointNormalUv.Y = array[1];
				pointNormalUv.Z = array[2];
				Utility._0023_003Dze5abBKgivGEU(matrixForNormals, hasScaling, ref pointNormalUv.Nx, ref pointNormalUv.Ny, ref pointNormalUv.Nz);
			}
			return;
		}
		for (int k = 0; k < num; k++)
		{
			Point3D point3D2 = _0023_003DzJs2WPVlNsiqa[k];
			double[] array2 = _0023_003DzNDQ_E88_003D.ActOnLeftOne(point3D2.X, point3D2.Y, point3D2.Z);
			point3D2.X = array2[0];
			point3D2.Y = array2[1];
			point3D2.Z = array2[2];
			if (point3D2 is PointTangent pointTangent)
			{
				double[] array3 = _0023_003DzNDQ_E88_003D.ActOnLeftZero(pointTangent.Tx, pointTangent.Ty, pointTangent.Tz);
				pointTangent.Tx = array3[0];
				pointTangent.Ty = array3[1];
				pointTangent.Tz = array3[2];
			}
		}
	}

	public virtual void Translate(double dx, double dy, double dz = 0.0)
	{
		Transformation transformation = new Transformation();
		transformation.Translation(dx, dy, dz);
		TransformBy(transformation);
	}

	public void Translate(Vector3D v)
	{
		Translate(v.X, v.Y, v.Z);
	}

	public void Rotate(double angleInRadians, Vector3D axis)
	{
		Rotate(angleInRadians, axis, Point3D.Origin);
	}

	public virtual void Rotate(double angleInRadians, Vector3D axis, Point3D center)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(angleInRadians, axis, center);
		TransformBy(transformation);
	}

	public void Rotate(double angleInRadians, Point3D axisStart, Point3D axisEnd)
	{
		Rotate(angleInRadians, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public void Scale(double factor)
	{
		Scale(Point3D.Origin, factor, factor, factor);
	}

	public void Scale(Point3D fixedPoint, double factor)
	{
		Scale(fixedPoint, factor, factor, factor);
	}

	public virtual void Scale(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
	{
		Transformation transformation = new Transformation();
		transformation.Scaling(fixedPoint, sx, sy, sz);
		TransformBy(transformation);
	}

	public void Scale(double sx, double sy, double sz = 1.0)
	{
		Scale(Point3D.Origin, sx, sy, sz);
	}

	public void Scale(Vector3D sv)
	{
		Scale(Point3D.Origin, sv.X, sv.Y, sv.Z);
	}

	public virtual string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(GetType().ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968161) + ColorMethod);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968151) + Color.ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968136) + MaterialName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968125) + LineTypeMethod);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968087) + LineTypeName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968079) + LineTypeScale);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968298) + LayerName);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968286) + GroupIndex);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968241) + LineWeightMethod);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968237) + LineWeight);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968196) + RegenMode);
		if (BoxMin != null)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967928) + BoxMin);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967911) + BoxMax);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967898) + BoxSize);
		}
		else
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967884));
		}
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967850) + EntityData);
		_0023_003DzscmcWzZMTK3Yq65PUA_003D_003D(stringBuilder);
		if (TranslationID != null)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957859) + TranslationID);
		}
		if (_vertices != null)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967837) + _vertices.Length);
		}
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968057), IsValid()));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		if (IfcProperties != null)
		{
			stringBuilder.Append(IfcProperties.Dump());
		}
		return stringBuilder.ToString();
	}

	protected static double GetOffsetDistance(Vector3D extDir, Vector3D amount, double draftAngleInRadians)
	{
		double num = amount.Length * Math.Tan(draftAngleInRadians);
		Vector3D closestMainAxis = GetClosestMainAxis(extDir);
		return (0.0 - (double)Math.Sign(new Plane(Point3D.Origin, closestMainAxis).DistanceTo(amount.AsPoint))) * num;
	}

	protected static Vector3D GetClosestMainAxis(Vector3D normDir)
	{
		SortedList<double, Vector3D> sortedList = new SortedList<double, Vector3D>();
		sortedList.Add(normDir * Vector3D.AxisX, Vector3D.AxisX);
		double key = normDir * Vector3D.AxisY;
		if (!sortedList.ContainsKey(key))
		{
			sortedList.Add(key, Vector3D.AxisY);
		}
		double key2 = normDir * Vector3D.AxisZ;
		if (!sortedList.ContainsKey(key2))
		{
			sortedList.Add(key2, Vector3D.AxisZ);
		}
		Vector3D vector3D = new Vector3D(-1.0, 0.0, 0.0);
		double key3 = normDir * vector3D;
		if (!sortedList.ContainsKey(key3))
		{
			sortedList.Add(key3, vector3D);
		}
		Vector3D vector3D2 = new Vector3D(0.0, -1.0, 0.0);
		double key4 = normDir * vector3D2;
		if (!sortedList.ContainsKey(key4))
		{
			sortedList.Add(key4, vector3D2);
		}
		Vector3D vector3D3 = new Vector3D(0.0, 0.0, -1.0);
		double key5 = normDir * vector3D3;
		if (!sortedList.ContainsKey(key5))
		{
			sortedList.Add(key5, vector3D3);
		}
		Vector3D vector3D4 = sortedList.Values[sortedList.Count - 1];
		return new Vector3D(Math.Abs(vector3D4.X), Math.Abs(vector3D4.Y), Math.Abs(vector3D4.Z));
	}

	private protected LinearPath _0023_003DztgI92lDISTaw0QRVK9fD0NM_003D()
	{
		LinearPath linearPath = new LinearPath(Utility.DeepCopy(_vertices));
		linearPath.CopyAttributes(this);
		return linearPath;
	}

	internal SketchItem _0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()
	{
		return sketchLink._0023_003DzUtOYa_o_003D();
	}

	internal void _0023_003Dzo3By5vyys2vj7c0aCg_003D_003D(SketchItem _0023_003DzPzO_0024GUk_003D)
	{
		sketchLink._0023_003Dzdlp53MQ_003D(_0023_003DzPzO_0024GUk_003D.entityLink);
	}

	public bool IsCurved()
	{
		if (!(this is FemMesh) && !(this is Curve) && !(this is SketchEntity) && !(this is Surface) && !(this is Brep) && !(this is Circle) && !(this is Ellipse) && (!(this is CompositeCurve compositeCurve) || !_0023_003DzPDaJDrQVNBtuuccz7g_003D_003D(compositeCurve.CurveList)) && !(this is AngularDim) && (!(this is Region region) || !_0023_003DzPDaJDrQVNBtuuccz7g_003D_003D(region.ContourList)) && (!(this is Hatch hatch) || !_0023_003DzPDaJDrQVNBtuuccz7g_003D_003D(hatch.ContourList)) && !(this is Toolpath))
		{
			if (this is Balloon balloon)
			{
				return balloon.Style == Balloon.balloonStyleType.Circular;
			}
			return false;
		}
		return true;
	}

	internal bool _0023_003DzPDaJDrQVNBtuuccz7g_003D_003D(IList<ICurve> _0023_003Dz06A5WivSSyUp)
	{
		foreach (ICurve item in _0023_003Dz06A5WivSSyUp)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				if (((Entity)individualCurves[i]).IsCurved())
				{
					return true;
				}
			}
		}
		return false;
	}

	internal T _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003Dzm0CYiiE_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		if (this is Point)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968043));
		}
		T val = Mesh._0023_003DzFPVyG4Y9TGyH<T>(_0023_003DzDphw2mIGq8srlxP4lA_003D_003D(_0023_003Dzm0CYiiE_003D), null, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn: false, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		val.Color = Color;
		val.ColorMethod = ColorMethod;
		val.LayerName = LayerName;
		return val;
	}

	internal T _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003Dzm0CYiiE_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
	{
		if (this is Point)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967985));
		}
		T val = Mesh._0023_003DzZsKpvYbXHCDE<T>(_0023_003DzDphw2mIGq8srlxP4lA_003D_003D(_0023_003Dzm0CYiiE_003D), _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn: false, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		val.Color = Color;
		val.ColorMethod = ColorMethod;
		val.LayerName = LayerName;
		return val;
	}

	internal T[] _0023_003Dz789GXCk_003D<T>(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, bool _0023_003DzjepEGXc_003D) where T : Mesh, new()
	{
		return Mesh._0023_003Dz1A9iP9WIToC5<T>(_0023_003DzHgrHIfhYCh4p, (ICurve)this, null, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: false, _0023_003Dzjy_YX_0024o_003D, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzjepEGXc_003D);
	}

	internal TabulatedSurface[] _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(Vector3D _0023_003DzYNjcavt9guh2)
	{
		ICurve curve = (ICurve)this;
		List<TabulatedSurface> list = new List<TabulatedSurface>();
		if (curve is CompositeCurve)
		{
			ICurve[] array = ((CompositeCurve)curve).SplitAtDiscontinuities(speedChange: false);
			foreach (ICurve curve2 in array)
			{
				TabulatedSurface item = curve2.GetNurbsForm()._0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzYNjcavt9guh2, curve2);
				list.Add(item);
			}
		}
		else if (curve is LinearPath)
		{
			ICurve[] array = ((LinearPath)curve).SplitAtDiscontinuities();
			foreach (ICurve curve3 in array)
			{
				TabulatedSurface item2 = curve3.GetNurbsForm()._0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzYNjcavt9guh2, curve3);
				list.Add(item2);
			}
		}
		else
		{
			TabulatedSurface item3 = curve.GetNurbsForm()._0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzYNjcavt9guh2, curve);
			list.Add(item3);
		}
		return list.ToArray();
	}

	internal Surface[] _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		ICurve curve = (ICurve)this;
		List<Surface> list = new List<Surface>();
		if (curve is CompositeCurve)
		{
			ICurve[] array = ((CompositeCurve)curve).SplitAtDiscontinuities(speedChange: false);
			foreach (ICurve curve2 in array)
			{
				Surface surface = curve2.GetNurbsForm()._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, curve2);
				if (surface != null)
				{
					list.Add(surface);
				}
			}
		}
		else if (curve is LinearPath)
		{
			ICurve[] array = ((LinearPath)curve).SplitAtDiscontinuities();
			foreach (ICurve curve3 in array)
			{
				Surface surface2 = curve3.GetNurbsForm()._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, curve3);
				if (surface2 != null)
				{
					list.Add(surface2);
				}
			}
		}
		else
		{
			Surface surface3 = curve.GetNurbsForm()._0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, curve);
			if (surface3 != null)
			{
				list.Add(surface3);
			}
		}
		return list.ToArray();
	}

	internal Surface[] _0023_003Dz789GXCk_003D(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL)
	{
		return Surface._0023_003Dz1A9iP9WIToC5(_0023_003DzHgrHIfhYCh4p, (ICurve)this, null, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: false, _0023_003Dz0h7AakEIaVwL);
	}

	internal Solid _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003Dzm0CYiiE_003D)
	{
		return Solid._0023_003DzFPVyG4Y9TGyH(_0023_003DzDphw2mIGq8srlxP4lA_003D_003D(_0023_003Dzm0CYiiE_003D), _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn: false);
	}

	internal T _0023_003DzMMwu2nWS_6dkgi9W6QajAfo_003D<T>(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D) where T : Solid, new()
	{
		if (this is Point)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968043));
		}
		return Solid._0023_003DzFPVyG4Y9TGyH<T>((ICurve)this, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn: false);
	}

	internal Solid _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003Dzm0CYiiE_003D)
	{
		Point3D[] array = _0023_003DzDphw2mIGq8srlxP4lA_003D_003D(_0023_003Dzm0CYiiE_003D);
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (new Segment3D(array[i], array[i + 1]).IsOnAxis(_0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D))
			{
				return Mesh._0023_003DzZsKpvYbXHCDE(array, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn: false, Mesh.natureType.Smooth).ConvertToSolid();
			}
		}
		return Solid._0023_003DzZsKpvYbXHCDE(array, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn: false);
	}

	internal Solid[] _0023_003DzggPwIWi3oqtM(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL)
	{
		return Solid._0023_003DzZHGcnP0_003D(_0023_003DzHgrHIfhYCh4p, (ICurve)this, _0023_003Dzm0CYiiE_003D, _0023_003Dz0h7AakEIaVwL, _0023_003DzjepEGXc_003D: true);
	}

	protected internal virtual bool SelectedInternal()
	{
		return false;
	}

	public bool IsAnyInstanceSelected()
	{
		for (int i = 0; i < InstanceSelectionInfo.Count; i++)
		{
			if (InstanceSelectionInfo[i].SelectionInfo.IsSelected())
			{
				return true;
			}
		}
		return false;
	}

	internal SelectionInfoItem GetSelectionInfo(Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		if (_0023_003Dzq5nwX2I_003D == null || _0023_003Dzq5nwX2I_003D.Count == 0)
		{
			return _selectionInfo;
		}
		return SelectionInfoItemBase.FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, this, _selectionInfo, InstanceSelectionInfo);
	}

	public void SetSelection(bool status, Stack<BlockReference> parents = null)
	{
		if (status || parents == null || parents.Count == 0)
		{
			SelectionInfoItem selectionInfo = GetSelectionInfo(parents);
			if (selectionInfo.SelectionInfo.Selected != status)
			{
				selectionInfo.SelectionInfo.Selected = status;
				isDirtyForFlattenTree = true;
			}
		}
		else if (SelectionInfoItemBase._0023_003DzKr4WJ_0024k_003D(parents, this, _selectionInfo, InstanceSelectionInfo, -1, null))
		{
			isDirtyForFlattenTree = true;
		}
	}

	public bool GetSelection(Stack<BlockReference> parents = null)
	{
		return GetSelectionInfo(parents).SelectionInfo.IsFlagSet(selectionStatusType.Permanent);
	}

	public void ClearSelectionForAllInstances()
	{
		if (_selectionInfo.SelectionInfo.Selected || IsAnyInstanceSelected())
		{
			isDirtyForFlattenTree = true;
		}
		_selectionInfo.SelectionInfo.Selected = false;
		InstanceSelectionInfo.Clear();
	}

	[Obsolete("Use GetSelection(parents) instead")]
	public virtual bool IsSelected(Stack<BlockReference> parents = null)
	{
		return GetSelectionInfo(parents).SelectionInfo.IsSelected();
	}

	internal virtual bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (_0023_003Dzq5nwX2I_003D.Count > 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, out var _0023_003Dzv0Okb82R5LqH))
		{
			return _0023_003Dzv0Okb82R5LqH.SelectionInfo.IsFlagSet(_0023_003DzLEq8mIc_003D);
		}
		return _selectionInfo.SelectionInfo.IsFlagSet(_0023_003DzLEq8mIc_003D);
	}

	internal void _0023_003DzC4zdjec_003D(selectionStatusType _0023_003Dzjcx0hV4_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		GetSelectionInfo(_0023_003Dzq5nwX2I_003D).SelectionInfo.SetFlag(_0023_003Dzjcx0hV4_003D);
	}

	internal void _0023_003DzdTNnI4kZhk24(selectionStatusType _0023_003Dzjcx0hV4_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		GetSelectionInfo(_0023_003Dzq5nwX2I_003D).SelectionInfo.InvertFlag(_0023_003Dzjcx0hV4_003D);
	}

	internal bool _0023_003Dz8N0AJYucqzTg(selectionStatusType _0023_003Dzjcx0hV4_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		return GetSelectionInfo(_0023_003Dzq5nwX2I_003D).SelectionInfo.IsFlagSet(_0023_003Dzjcx0hV4_003D);
	}

	internal void _0023_003DzRebollBve4Ti(selectionStatusType _0023_003Dzjcx0hV4_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		GetSelectionInfo(_0023_003Dzq5nwX2I_003D).SelectionInfo.UnsetFlag(_0023_003Dzjcx0hV4_003D);
	}

	internal bool _0023_003DzSKm6PrOAK0ZZ()
	{
		return _selectionInfo.SelectionInfo.IsFlagSet(selectionStatusType.Temporary);
	}

	internal void _0023_003DzF1nZ1CQZihA_0024(bool _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D)
		{
			_selectionInfo.SelectionInfo.SetFlag(selectionStatusType.Temporary);
		}
		else
		{
			_selectionInfo.SelectionInfo.UnsetFlag(selectionStatusType.Temporary);
		}
	}

	public bool IsAnyInstanceVisible()
	{
		if (instanceVisibilityInfo == null)
		{
			return false;
		}
		for (int i = 0; i < instanceVisibilityInfo.Count; i++)
		{
			if (instanceVisibilityInfo[i].Visible)
			{
				return true;
			}
		}
		return false;
	}

	internal void _0023_003DzoC5Ax2mpp_0024GS()
	{
		_0023_003Dz256ZxNw_003D?.Invoke(this, new VisibleChangedEventArgs());
	}

	public void SetVisibility(bool status, Stack<BlockReference> parents)
	{
		_0023_003DzwOKvbbY_SlKa(status, parents, _0023_003DzQBV_0024ilHTK5pU: false);
	}

	private void _0023_003DzwOKvbbY_SlKa(bool _0023_003Dz7duJoMQ_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, bool _0023_003DzQBV_0024ilHTK5pU)
	{
		if (_0023_003Dzq5nwX2I_003D == null || _0023_003Dzq5nwX2I_003D.Count == 0)
		{
			Visible = _0023_003Dz7duJoMQ_003D;
			return;
		}
		if (_0023_003DzQBV_0024ilHTK5pU)
		{
			InstanceInfo.RemoveInstanceInfo(_0023_003Dzq5nwX2I_003D, instanceVisibilityInfo);
		}
		else
		{
			if (instanceVisibilityInfo == null)
			{
				instanceVisibilityInfo = new List<VisibilityInfo>();
			}
			InstanceInfo.FindInstanceInfoOrCreate(_0023_003Dzq5nwX2I_003D, instanceVisibilityInfo).Visible = _0023_003Dz7duJoMQ_003D;
		}
		_0023_003Dzq5nwX2I_003D.First()._0023_003DzoC5Ax2mpp_0024GS();
	}

	public bool GetVisibility(Stack<BlockReference> parents)
	{
		return InstanceInfo.FindClosestInstanceInfo(parents, instanceVisibilityInfo)?.Visible ?? Visible;
	}

	protected internal virtual bool IsVisibleAndInFrustum(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
	{
		if (((parents.Count == 0) ? visibleAndInFrustum : layers.GetItemFast(LayerName).Visible) && GetVisibility(parents))
		{
			return IsValidForDraw();
		}
		return false;
	}

	protected internal virtual bool IsVisible(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
	{
		if (layers.GetItemFast(LayerName).Visible && GetVisibility(parents))
		{
			return RegenMode != regenType.RegenAndCompile;
		}
		return false;
	}

	internal bool IsVisible(LayerKeyedCollection _0023_003DzeWJg3NJnk3WA)
	{
		if (_0023_003DzeWJg3NJnk3WA.GetItemFast(LayerName).Visible && Visible)
		{
			return IsValidForDraw();
		}
		return false;
	}

	public void ClearVisibility(Stack<BlockReference> parents)
	{
		_0023_003DzwOKvbbY_SlKa(_0023_003Dz7duJoMQ_003D: true, parents, _0023_003DzQBV_0024ilHTK5pU: true);
	}

	public void ClearVisibilityForAllInstances()
	{
		bool num = !Visible;
		Visible = true;
		instanceVisibilityInfo = null;
		if (num)
		{
			_0023_003DzoC5Ax2mpp_0024GS();
		}
	}

	internal virtual List<SelectabilityInfo> _0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO()
	{
		return _003CInstanceSelectabilityInfo_003Ek__BackingField;
	}

	internal virtual void _0023_003Dz83ApW34G0YRpjTWhFbieLglnyK9j(List<SelectabilityInfo> _0023_003DzPzO_0024GUk_003D)
	{
		_003CInstanceSelectabilityInfo_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	public bool IsAnyInstanceSelectable()
	{
		if (_0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO() == null)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO().Count; i++)
		{
			if (_0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO()[i]._0023_003Dz7eWMfCw_003D)
			{
				return true;
			}
		}
		return false;
	}

	public void SetSelectability(bool status, Stack<BlockReference> parents)
	{
		if (parents == null || parents.Count == 0)
		{
			Selectable = status;
			return;
		}
		if (_0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO() == null)
		{
			_0023_003Dz83ApW34G0YRpjTWhFbieLglnyK9j(new List<SelectabilityInfo>());
		}
		InstanceInfo.FindInstanceInfoOrCreate(parents, _0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO())._0023_003Dz7eWMfCw_003D = status;
	}

	public bool GetSelectability(Stack<BlockReference> parents)
	{
		return InstanceInfo.FindClosestInstanceInfo(parents, _0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO())?._0023_003Dz7eWMfCw_003D ?? Selectable;
	}

	internal bool IsSelectable(LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, bool _0023_003Dz9T3DCS8cAsPX = false)
	{
		Layer itemFast = _0023_003DzeWJg3NJnk3WA.GetItemFast(LayerName);
		if (itemFast.Visible && !itemFast.Locked && Visible)
		{
			if (!_0023_003Dz9T3DCS8cAsPX)
			{
				return Selectable;
			}
			return true;
		}
		return false;
	}

	public void ClearSelectability(Stack<BlockReference> parents)
	{
		if (parents == null || parents.Count == 0)
		{
			Selectable = true;
		}
		else
		{
			InstanceInfo.RemoveInstanceInfo(parents, _0023_003DzDcrhjkL3PV1t_0024fRQwzxJ_7OyAYZO());
		}
	}

	public void ClearSelectabilityForAllInstances()
	{
		Selectable = true;
		_0023_003Dz83ApW34G0YRpjTWhFbieLglnyK9j(null);
	}

	internal virtual List<ClippabilityInfo> _0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC()
	{
		return _003CInstanceClippabilityInfo_003Ek__BackingField;
	}

	internal virtual void _0023_003DzjYLAp3RVHJbBTauBrhH_6NB_i36Z(List<ClippabilityInfo> _0023_003DzPzO_0024GUk_003D)
	{
		_003CInstanceClippabilityInfo_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	public bool IsAnyInstanceClippable()
	{
		if (_0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC() == null)
		{
			return false;
		}
		for (int i = 0; i < _0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC().Count; i++)
		{
			if (_0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC()[i]._0023_003DzLnRTKMV2r82XoyFZ_0024Q_003D_003D)
			{
				return true;
			}
		}
		return false;
	}

	public void SetClippability(bool status, Stack<BlockReference> parents)
	{
		if (parents == null || parents.Count == 0)
		{
			Clippable = status;
			return;
		}
		if (_0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC() == null)
		{
			_0023_003DzjYLAp3RVHJbBTauBrhH_6NB_i36Z(new List<ClippabilityInfo>());
		}
		InstanceInfo.FindInstanceInfoOrCreate(parents, _0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC())._0023_003DzLnRTKMV2r82XoyFZ_0024Q_003D_003D = status;
	}

	public bool GetClippability(Stack<BlockReference> parents)
	{
		return InstanceInfo.FindClosestInstanceInfo(parents, _0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC())?._0023_003DzLnRTKMV2r82XoyFZ_0024Q_003D_003D ?? Clippable;
	}

	internal bool IsClippable(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA)
	{
		Layer itemFast = _0023_003DzeWJg3NJnk3WA.GetItemFast(LayerName);
		if (itemFast.Visible && !itemFast.Locked)
		{
			return GetClippability(_0023_003Dzq5nwX2I_003D);
		}
		return false;
	}

	public void ClearClippability(Stack<BlockReference> parents)
	{
		if (parents == null || parents.Count == 0)
		{
			Clippable = true;
		}
		else
		{
			InstanceInfo.RemoveInstanceInfo(parents, _0023_003Dz0XXkl7mPnkLZhJ27xBMEhuGJPsSC());
		}
	}

	public void ClearClippabilityForAllInstances()
	{
		Clippable = true;
		_0023_003DzjYLAp3RVHJbBTauBrhH_6NB_i36Z(null);
	}

	private void _0023_003Dzy5P5XTw1Ia3OtSlwMjxo_0024pvx7WCn6022CAZ_0024vW_IcXipw_0024DskEokGd4_003D(DrawSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		DrawSilhouettes(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawSilhouettes(DrawSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zy5P5XTw1Ia3OtSlwMjxo$pvx7WCn6022CAZ$vW_IcXipw$DskEokGd4=
		this._0023_003Dzy5P5XTw1Ia3OtSlwMjxo_0024pvx7WCn6022CAZ_0024vW_IcXipw_0024DskEokGd4_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzOCqeklaVi77wT_0024VGhRUnrLF5wUKp8amUtt_0024lgpQ_003D(RenderParams _0023_003DzELu0Pss_003D)
	{
		Render(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.Render(RenderParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zOCqeklaVi77wT$VGhRUnrLF5wUKp8amUtt$lgpQ=
		this._0023_003DzOCqeklaVi77wT_0024VGhRUnrLF5wUKp8amUtt_0024lgpQ_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzlRN4xf4_0024PUKeyQME941woo4yWrlz68B5_0024nRcU_DG1TCd(RenderParams _0023_003DzELu0Pss_003D)
	{
		RenderFast(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.RenderFast(RenderParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zlRN4xf4$PUKeyQME941woo4yWrlz68B5$nRcU_DG1TCd
		this._0023_003DzlRN4xf4_0024PUKeyQME941woo4yWrlz68B5_0024nRcU_DG1TCd(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzXG6Zjukqr_0rU0YVEM5N3ImXkCF_0024WnW8srNvl5zbRqvg(RenderParams _0023_003DzELu0Pss_003D)
	{
		DrawForShadow(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawForShadow(RenderParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zXG6Zjukqr_0rU0YVEM5N3ImXkCF$WnW8srNvl5zbRqvg
		this._0023_003DzXG6Zjukqr_0rU0YVEM5N3ImXkCF_0024WnW8srNvl5zbRqvg(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzWQv0KijyZrLjMb3m9pA_0024IdHSe8E5EfYvjtvbPTUCsVDE(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawFast(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawFast(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zWQv0KijyZrLjMb3m9pA$IdHSe8E5EfYvjtvbPTUCsVDE
		this._0023_003DzWQv0KijyZrLjMb3m9pA_0024IdHSe8E5EfYvjtvbPTUCsVDE(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzkWmZw3diFVOfwtBKJqcRRd3dVwEcGv3ktgykavc_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		Draw(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.Draw(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zkWmZw3diFVOfwtBKJqcRRd3dVwEcGv3ktgykavc=
		this._0023_003DzkWmZw3diFVOfwtBKJqcRRd3dVwEcGv3ktgykavc_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzLWKZm1muM5bSzGrn_0024CVyUTIEJw8N4AP_002468w2xJMaE6i7(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawEdges(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawEdges(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zLWKZm1muM5bSzGrn$CVyUTIEJw8N4AP$68w2xJMaE6i7
		this._0023_003DzLWKZm1muM5bSzGrn_0024CVyUTIEJw8N4AP_002468w2xJMaE6i7(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzSa5ZAVv7DU0DqV2fhFZja9cwKUMXqt2sBA9jKr7QKCA3Ky01_0024Q_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawIsocurves(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawIsocurves(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zSa5ZAVv7DU0DqV2fhFZja9cwKUMXqt2sBA9jKr7QKCA3Ky01$Q==
		this._0023_003DzSa5ZAVv7DU0DqV2fhFZja9cwKUMXqt2sBA9jKr7QKCA3Ky01_0024Q_003D_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzdxH4zXhZ8x1bU7GGhS0bQXYvUj7NPiI6mSs6RxsR1JLo(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawHiddenLines(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawHiddenLines(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zdxH4zXhZ8x1bU7GGhS0bQXYvUj7NPiI6mSs6RxsR1JLo
		this._0023_003DzdxH4zXhZ8x1bU7GGhS0bQXYvUj7NPiI6mSs6RxsR1JLo(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzGFDZtB7kvP_0024kXqzx6UxJJ0VGICFp1G6UXvOJuiowGzOw(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawFlat(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawFlat(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zGFDZtB7kvP$kXqzx6UxJJ0VGICFp1G6UXvOJuiowGzOw
		this._0023_003DzGFDZtB7kvP_0024kXqzx6UxJJ0VGICFp1G6UXvOJuiowGzOw(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzRn_00243qSf1iXQw5myNiHDGxnYkavfyikMW5rh8EgGOWx2G8giCSw_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawWireframe(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawWireframe(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zRn$3qSf1iXQw5myNiHDGxnYkavfyikMW5rh8EgGOWx2G8giCSw==
		this._0023_003DzRn_00243qSf1iXQw5myNiHDGxnYkavfyikMW5rh8EgGOWx2G8giCSw_003D_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003Dz9PLCOLo5odBR08HIYlB8dgpZaKWXPQntcJ3leDU3R2lFeKdmSQ_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawNormals(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawNormals(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z9PLCOLo5odBR08HIYlB8dgpZaKWXPQntcJ3leDU3R2lFeKdmSQ==
		this._0023_003Dz9PLCOLo5odBR08HIYlB8dgpZaKWXPQntcJ3leDU3R2lFeKdmSQ_003D_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DznpyEe6Vxo_oyqn4F20LotQsIDzz8NTnzupcuZFh71k19(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawSelected(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawSelected(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=znpyEe6Vxo_oyqn4F20LotQsIDzz8NTnzupcuZFh71k19
		this._0023_003DznpyEe6Vxo_oyqn4F20LotQsIDzz8NTnzupcuZFh71k19(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzJx2FjZRLqkSxdnt3lMzfp4e9ZDBEYGEEPfuTKsl_b_0024vg(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawFlatSelected(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawFlatSelected(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zJx2FjZRLqkSxdnt3lMzfp4e9ZDBEYGEEPfuTKsl_b$vg
		this._0023_003DzJx2FjZRLqkSxdnt3lMzfp4e9ZDBEYGEEPfuTKsl_b_0024vg(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzZOfiKDPCRBpBuEnfh_ZQ1tPXdwwEZYn4uwc1D3t25xpupmg4mKuTLic_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawWireframeSelected(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawWireframeSelected(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zZOfiKDPCRBpBuEnfh_ZQ1tPXdwwEZYn4uwc1D3t25xpupmg4mKuTLic=
		this._0023_003DzZOfiKDPCRBpBuEnfh_ZQ1tPXdwwEZYn4uwc1D3t25xpupmg4mKuTLic_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DztsEBUm1YStIa96lgnCdfilg_0024OsnQNSKTUNSor_ZxSOYrrM1J5A_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawVertices(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawVertices(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=ztsEBUm1YStIa96lgnCdfilg$OsnQNSKTUNSor_ZxSOYrrM1J5A==
		this._0023_003DztsEBUm1YStIa96lgnCdfilg_0024OsnQNSKTUNSor_ZxSOYrrM1J5A_003D_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzQplh4O79_0024DJ4SZp2A06Rj2fDZUz1BgBPspq3KHs_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		SetShader(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.SetShader(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQplh4O79$DJ4SZp2A06Rj2fDZUz1BgBPspq3KHs=
		this._0023_003DzQplh4O79_0024DJ4SZp2A06Rj2fDZUz1BgBPspq3KHs_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003Dzq_0024g6IDKU2cgV1jVuZUBAS6rkxWZ0UeQsmnM4GV50uWJj(DrawParams _0023_003DzELu0Pss_003D)
	{
		DrawForDepthPass(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawForDepthPass(DrawParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zq$g6IDKU2cgV1jVuZUBAS6rkxWZ0UeQsmnM4GV50uWJj
		this._0023_003Dzq_0024g6IDKU2cgV1jVuZUBAS6rkxWZ0UeQsmnM4GV50uWJj(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzTMS6G6Xe_0024ilxlrkqjJZAsMR6fpPSUYf3J5omOdnFoRK7(DrawForSelectionParams _0023_003DzELu0Pss_003D)
	{
		DrawForSelection(_0023_003DzELu0Pss_003D);
	}

	void IEntityInternal.DrawForSelection(DrawForSelectionParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zTMS6G6Xe$ilxlrkqjJZAsMR6fpPSUYf3J5omOdnFoRK7
		this._0023_003DzTMS6G6Xe_0024ilxlrkqjJZAsMR6fpPSUYf3J5omOdnFoRK7(_0023_003DzELu0Pss_003D);
	}

	private bool _0023_003DzkeQG7WiqQQTcb_00241pXlz4hs9dp3E8mn7ovgsjmdCHlcQdIpBGhw_003D_003D(FrustumParams _0023_003DzELu0Pss_003D)
	{
		return IsCrossing(_0023_003DzELu0Pss_003D);
	}

	bool IEntityInternal.IsCrossing(FrustumParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zkeQG7WiqQQTcb$1pXlz4hs9dp3E8mn7ovgsjmdCHlcQdIpBGhw==
		return this._0023_003DzkeQG7WiqQQTcb_00241pXlz4hs9dp3E8mn7ovgsjmdCHlcQdIpBGhw_003D_003D(_0023_003DzELu0Pss_003D);
	}

	private bool _0023_003DzRRw8cTuXzARo2_0024FCr6a4OYWEY1KkuuK1_0024QO_O6JebVFvhc4_00247vX4fAJnMHRO(FrustumParams _0023_003DzELu0Pss_003D)
	{
		return AllVerticesInFrustum(_0023_003DzELu0Pss_003D);
	}

	bool IEntityInternal.AllVerticesInFrustum(FrustumParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zRRw8cTuXzARo2$FCr6a4OYWEY1KkuuK1$QO_O6JebVFvhc4$7vX4fAJnMHRO
		return this._0023_003DzRRw8cTuXzARo2_0024FCr6a4OYWEY1KkuuK1_0024QO_O6JebVFvhc4_00247vX4fAJnMHRO(_0023_003DzELu0Pss_003D);
	}

	private bool _0023_003DzZxfgXtH0r39n7530Yqvg72SFS_vWIqUp1__efaFBimLbK7GpaUC5R0s_003D(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		return IsCrossingScreenPolygon(_0023_003DzELu0Pss_003D);
	}

	bool IEntityInternal.IsCrossingScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zZxfgXtH0r39n7530Yqvg72SFS_vWIqUp1__efaFBimLbK7GpaUC5R0s=
		return this._0023_003DzZxfgXtH0r39n7530Yqvg72SFS_vWIqUp1__efaFBimLbK7GpaUC5R0s_003D(_0023_003DzELu0Pss_003D);
	}

	private bool _0023_003DzGFDZtB7kvP_0024kXqzx6UxJJ_0024dYjNBXGsSUyyk9AaSf7DHXE8pdGcJXVW8_003D(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		return AllVerticesInScreenPolygon(_0023_003DzELu0Pss_003D);
	}

	bool IEntityInternal.AllVerticesInScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zGFDZtB7kvP$kXqzx6UxJJ$dYjNBXGsSUyyk9AaSf7DHXE8pdGcJXVW8=
		return this._0023_003DzGFDZtB7kvP_0024kXqzx6UxJJ_0024dYjNBXGsSUyyk9AaSf7DHXE8pdGcJXVW8_003D(_0023_003DzELu0Pss_003D);
	}

	private void _0023_003DzszPsFCa_0024zV5LLhMeGeRvdx_0024nU0Ytp5VJ9jrNAg9EAM47(int _0023_003Dz_0024rq3HRVr0IfR)
	{
		Animate(_0023_003Dz_0024rq3HRVr0IfR);
	}

	void IEntityInternal.Animate(int _0023_003Dz_0024rq3HRVr0IfR)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zszPsFCa$zV5LLhMeGeRvdx$nU0Ytp5VJ9jrNAg9EAM47
		this._0023_003DzszPsFCa_0024zV5LLhMeGeRvdx_0024nU0Ytp5VJ9jrNAg9EAM47(_0023_003Dz_0024rq3HRVr0IfR);
	}

	private bool _0023_003Dz2UBgZrhi8CcpHl17YCopg4OKh_Y71Q8eL0o0N88K_0024GXQ(TraversalParams _0023_003DzELu0Pss_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		return ComputeBoundingBox(_0023_003DzELu0Pss_003D, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
	}

	bool IEntityInternal.ComputeBoundingBox(TraversalParams _0023_003DzELu0Pss_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z2UBgZrhi8CcpHl17YCopg4OKh_Y71Q8eL0o0N88K$GXQ
		return this._0023_003Dz2UBgZrhi8CcpHl17YCopg4OKh_Y71Q8eL0o0N88K_0024GXQ(_0023_003DzELu0Pss_003D, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
	}

	internal static bool _0023_003DznGg4zZpR1yr2ytDGOA_003D_003D(Entity _0023_003Dz9j7EUB0_003D, colorMethodType _0023_003Dzjy_YX_0024o_003D)
	{
		if (_0023_003Dz9j7EUB0_003D.RegenMode == regenType.NotNeeded && _0023_003Dz9j7EUB0_003D.lineTypeMethod == _0023_003Dzjy_YX_0024o_003D)
		{
			_0023_003Dz9j7EUB0_003D.RegenMode = regenType.CompileOnly;
			return true;
		}
		return false;
	}

	protected virtual void InitGraphicsData(RenderContextBase renderContext)
	{
		if (drawData == null)
		{
			drawData = renderContext.CreateEntityGraphicsData(this);
		}
		if (drawPattern == null)
		{
			drawPattern = renderContext.CreateEntityGraphicsData(this);
		}
	}

	internal virtual bool IsValidForDraw()
	{
		if (RegenMode != regenType.NotNeeded)
		{
			if (drawData != null)
			{
				return drawData.IsValid();
			}
			return false;
		}
		return true;
	}

	public virtual void Dispose()
	{
		_0023_003DzSrny2FmSPIa7();
		drawData?.Dispose();
		drawPattern?.Dispose();
		if (regenMode != regenType.RegenAndCompile)
		{
			RegenMode = regenType.CompileOnly;
		}
	}

	private protected void _0023_003Dz9ctHTXjAW5QC(Entity _0023_003Dz9j7EUB0_003D)
	{
		_subEntityToDispose.Add(_0023_003Dz9j7EUB0_003D);
	}

	private protected void _0023_003DzSrny2FmSPIa7()
	{
		if (_subEntityToDispose == null)
		{
			return;
		}
		foreach (Entity item in _subEntityToDispose)
		{
			item.Dispose();
		}
		_subEntityToDispose.Clear();
	}

	private protected void _0023_003Dzz6CGSI8_003D(GfxAttributes _0023_003DzqP5lTto_003D, string _0023_003DzaROjBYA_003D, float _0023_003DzgvoDUidltBEx)
	{
		_color = _0023_003DzqP5lTto_003D.Color;
		_materialName = _0023_003DzqP5lTto_003D.MaterialName;
		_lineWeight = _0023_003DzqP5lTto_003D.LineWeight;
		_lineTypeName = _0023_003DzqP5lTto_003D.LineTypeName;
		_colorMethod = colorMethodType.byEntity;
		lineTypeMethod = colorMethodType.byEntity;
		_lineWeightMethod = colorMethodType.byEntity;
		_layerName = _0023_003DzaROjBYA_003D;
		_lineTypeScale = _0023_003DzgvoDUidltBEx;
	}

	internal void _0023_003DzrtnP79knlhMG(Entity _0023_003Dzb7SPTpc_003D)
	{
		LayerName = _0023_003Dzb7SPTpc_003D.LayerName;
		ColorMethod = _0023_003Dzb7SPTpc_003D.ColorMethod;
		Color = _0023_003Dzb7SPTpc_003D.Color;
	}

	public void CopyAttributes(Entity source)
	{
		_0023_003DzrtnP79knlhMG(source);
		GroupIndex = source.GroupIndex;
		LineWeightMethod = source.LineWeightMethod;
		LineWeight = source.LineWeight;
		LineTypeMethod = source.LineTypeMethod;
		LineTypeName = source.LineTypeName;
		LineTypeScale = source.LineTypeScale;
		MaterialName = source.MaterialName;
	}

	public void CopyAttributesFast(Entity source)
	{
		Visible = source.Visible;
		instanceVisibilityInfo = source.instanceVisibilityInfo;
		LayerName = source.LayerName;
		ColorMethod = source.ColorMethod;
		Color = source.Color;
		MaterialName = source.MaterialName;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void _0023_003DzqKkfI8jwDACTQroBqA_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
		LayerName = _0023_003Dzb7SPTpc_003D.LayerName;
	}

	protected internal virtual bool IsSmall(IsSmallParams data)
	{
		if (AvoidSmallSizeCulling())
		{
			return false;
		}
		if (localMin == null || localMax == null)
		{
			return false;
		}
		Point3D[] array = new Point3D[4]
		{
			localMin.Clone() as Point3D,
			new Point3D(localMax.X, localMin.Y, localMin.Z),
			new Point3D(localMin.X, localMax.Y, localMax.Z),
			localMax.Clone() as Point3D
		};
		if (data.Transformation != null && !data.Transformation.IsIdentity())
		{
			for (int i = 0; i < 4; i++)
			{
				array[i].TransformBy(data.Transformation);
			}
		}
		Point2D[] array2 = new Point2D[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			Camera.Project(data.RenderContext, data.ModelViewProj, data.ViewFrame, array[j].X, array[j].Y, array[j].Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _);
			array2[j] = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
		}
		Utility.BoundingRect(array2, out var min, out var max);
		double val = Math.Abs(max.X - min.X);
		double val2 = Math.Abs(max.Y - min.Y);
		screenSize = Math.Max(val, val2);
		return screenSize < data.SmallSize;
	}

	internal virtual bool AvoidSmallSizeCulling()
	{
		return false;
	}

	public bool IsInFrustum(FrustumParams data)
	{
		Point3D center = sphereCenter;
		Point3D point3D = localMin;
		Point3D point3D2 = localMax;
		Transformation transformation = data.Transformation;
		if (transformation != null)
		{
			center = transformation * sphereCenter;
			if (!data.Quick)
			{
				localMin = transformation * localMin;
				localMax = transformation * localMax;
			}
		}
		bool result = IsInFrustum(data, center, sphereRadius * data.Scale);
		localMin = point3D;
		localMax = point3D2;
		return result;
	}

	public virtual bool IsInFrustum(FrustumParams data, Point3D center, double radius)
	{
		if (data.Quick)
		{
			return Utility.IsInFrustum(data.Frustum, center, radius);
		}
		bool intersect;
		bool flag = Utility.IsInFrustum(data.Frustum, center, radius, out intersect);
		if (flag && intersect)
		{
			return Utility.IsInFrustum(data.Frustum, localMin, localMax);
		}
		return flag;
	}

	protected internal virtual bool IsCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (IntersectEdgeOrIsolineScreenPolygon(data) || InsideOrCrossingScreenPolygon(data))
		{
			return true;
		}
		if (((data.DisplayMode != displayType.Wireframe && (entityNature == entityNatureType.Polygon || entityNature == entityNatureType.RichPolygon || this is BlockReference)) || this is Triangle || this is Quad || this is Text || this is Table) && ThroughTriangleScreenPolygon(data))
		{
			return true;
		}
		return false;
	}

	protected virtual bool EvaluateIntersectTriangles(FrustumParams data)
	{
		return false;
	}

	protected virtual bool EvaluateIntersectEdges(FrustumParams data)
	{
		return false;
	}

	protected internal virtual bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		if (Utility.AllVerticesInScreenPolygon(data, _vertices, _vertices.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal virtual bool AllVerticesInFrustum(FrustumParams data)
	{
		if (Utility.AllVerticesInFrustum(data, _vertices, _vertices.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	internal virtual _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return null;
	}

	protected internal virtual void Animate(int frameNumber)
	{
	}

	public void UpdateBoundingBox(TraversalParams data)
	{
		ComputeBoundingBox(data ?? new TraversalParams(), out localMin, out localMax);
		UpdateBoundingBoxSphere();
	}

	public virtual void UpdateOrientedBoundingBox(TraversalParams data, bool keepCurrent = false)
	{
		_0023_003DzmKfnhwgr2htOg_AZRTHTOlQ_003D(data, out var _, keepCurrent, _0023_003DzWTWwLt_0024Yu8mErU8UnA_003D_003D: false);
	}

	internal virtual void _0023_003DzmKfnhwgr2htOg_AZRTHTOlQ_003D(TraversalParams _0023_003DzELu0Pss_003D, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D, bool _0023_003DzWTWwLt_0024Yu8mErU8UnA_003D_003D)
	{
		_0023_003DzHhJEwwk_003D = 0;
		if (_0023_003DzELu0Pss_003D != null && (this is Ghost || (_0023_003DzWTWwLt_0024Yu8mErU8UnA_003D_003D ? _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(_0023_003DzELu0Pss_003D, out var _0023_003DzrdSL0CI_003D, out var _0023_003DzD5Gs7jmmc9uK, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D) : _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(_0023_003DzELu0Pss_003D, out _0023_003DzrdSL0CI_003D, out _0023_003DzD5Gs7jmmc9uK, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D)) || _localOB != null) && _0023_003DzELu0Pss_003D.Transformation != null)
		{
			_localOB.AccumulateTransformation(_0023_003DzELu0Pss_003D.Transformation);
		}
	}

	internal virtual bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D)
	{
		Point2D[] array = new Point3D[0];
		_0023_003DzrdSL0CI_003D = array;
		_0023_003DzD5Gs7jmmc9uK = false;
		_0023_003DzHhJEwwk_003D = 1;
		if (_vertices != null)
		{
			array = _vertices;
			_0023_003DzrdSL0CI_003D = array;
		}
		if (_vertices != null && _vertices.Length == 0)
		{
			_localOB = new OrientedBoundingBox(localMin, Vector3D.AxisX, Vector3D.AxisY, 0.0, 0.0, 0.0);
			return true;
		}
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			return true;
		}
		if (_0023_003DzrdSL0CI_003D.Length != 0)
		{
			_localOB = new OrientedBoundingBox(_vertices);
			return true;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968689));
	}

	internal virtual bool _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D)
	{
		_0023_003DzrdSL0CI_003D = new Point2D[0];
		_0023_003DzD5Gs7jmmc9uK = false;
		_0023_003DzHhJEwwk_003D = 1;
		if (_vertices != null)
		{
			_0023_003DzrdSL0CI_003D = new Point2D[_vertices.Length];
			for (int i = 0; i < _vertices.Length; i++)
			{
				_0023_003DzrdSL0CI_003D[i] = new Point2D(_vertices[i].X, _vertices[i].Y);
			}
		}
		if (_vertices != null && _vertices.Length == 0)
		{
			_localOB = new OrientedBoundingRect(localMin, Vector2D.AxisX, Vector2D.AxisY, 0.0, 0.0);
			return true;
		}
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			return true;
		}
		if (_0023_003DzrdSL0CI_003D.Length != 0)
		{
			_localOB = new OrientedBoundingRect(_0023_003DzrdSL0CI_003D);
			return true;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968689));
	}

	protected internal virtual bool CombineBoundingBox(Transformation transform, Point3D boxMin, Point3D boxMax)
	{
		Point3D boxMin2 = localMin;
		Point3D boxMax2 = localMax;
		if (boxMin2.X > boxMax2.X || boxMin2.Y > boxMax2.Y || boxMin2.Z > boxMax2.Z)
		{
			return false;
		}
		if (transform != null)
		{
			Utility.GetBoundingBoxTransformed(transform, boxMin2, boxMax2, out boxMin2, out boxMax2);
		}
		if (boxMin2.X < boxMin.X)
		{
			boxMin.X = boxMin2.X;
		}
		if (boxMax2.X > boxMax.X)
		{
			boxMax.X = boxMax2.X;
		}
		if (boxMin2.Y < boxMin.Y)
		{
			boxMin.Y = boxMin2.Y;
		}
		if (boxMax2.Y > boxMax.Y)
		{
			boxMax.Y = boxMax2.Y;
		}
		if (boxMin2.Z < boxMin.Z)
		{
			boxMin.Z = boxMin2.Z;
		}
		if (boxMax2.Z > boxMax.Z)
		{
			boxMax.Z = boxMax2.Z;
		}
		return true;
	}

	protected internal virtual bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		Utility._0023_003Dzyx35VoBSR6flPmM7uA_003D_003D(_vertices, out var _0023_003DzTbDlaOM_003D);
		verticesCoords = _0023_003DzTbDlaOM_003D;
		return true;
	}

	protected internal virtual bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		return ComputeBoundingBox(data, _vertices, out boxMin, out boxMax);
	}

	protected static bool ComputeBoundingBox(TraversalParams data, IList<Point3D> entityVertices, out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(data?.Transformation, entityVertices, out boxMin, out boxMax);
		return boxMin.X <= boxMax.X;
	}

	protected static bool ComputeBoundingBox(TraversalParams data, float[] pointArray, int skipPoints, out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(data?.Transformation, pointArray, pointArray.Length, skipPoints, out boxMin, out boxMax);
		return boxMin.X <= boxMax.X;
	}

	protected internal void UpdateBoundingBoxSphere()
	{
		sphereCenter = Point3D.MidPoint(localMin, localMax);
		sphereRadius = Point3D.Distance(localMin, sphereCenter);
	}

	public abstract Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers);

	internal virtual Point3D[] _0023_003DzMHGsUs_0024dF1onGPMzUA_003D_003D(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, Dictionary<string, Point3D[]> _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D)
	{
		return EstimateBoundingBox(_0023_003DzJO1FWlQ_003D, _0023_003DzeWJg3NJnk3WA);
	}

	protected internal virtual void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		ComputeOffsetOnCameraAxes(data, _vertices, _vertices.Length);
	}

	protected internal static void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data, IList<Point3D> vertices, int vertexCount)
	{
		Transformation transformation = data.Transformation;
		PointF minQ = data.MinQ._0023_003Dzx9P_oXY_003D();
		PointF maxQ = data.MaxQ._0023_003Dzx9P_oXY_003D();
		for (int i = 0; i < vertexCount; i++)
		{
			Camera.ComputeOffsetOnCameraAxes(transformation * vertices[i], data.m1, data.m2, ref minQ, ref maxQ);
		}
		data.MinQ = minQ;
		data.MaxQ = maxQ;
	}

	protected internal static void ComputeOffsetOnCameraAxes(Transformation modelView, float[] pointArray, int count, PointF m1, PointF m2, ref PointF minQ, ref PointF maxQ, int skipPoints)
	{
		int num = 3 + skipPoints * 3;
		float[,] floatMatrix = modelView.GetFloatMatrix();
		for (int i = 0; i < count; i += num)
		{
			float[] array = Transformation.ActOnLeftOne(pointArray[i], pointArray[i + 1], pointArray[i + 2], floatMatrix);
			Camera._0023_003Dz4yR3wJK0ZQDToaQwLg_003D_003D(array[0], array[1], array[2], m1, m2, ref minQ, ref maxQ);
		}
	}

	internal virtual bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (Vertices != null)
		{
			return Vertices.Length != 0;
		}
		return false;
	}

	public virtual void Regen(RegenParams data)
	{
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	public virtual void Regen(double deviation)
	{
		Regen(new RegenParams(deviation));
	}

	internal virtual Point3D[] _0023_003DzDphw2mIGq8srlxP4lA_003D_003D(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		return _0023_003DzDphw2mIGq8srlxP4lA_003D_003D(new RegenParams(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D));
	}

	internal virtual Point3D[] _0023_003DzDphw2mIGq8srlxP4lA_003D_003D(RegenParams _0023_003DzELu0Pss_003D)
	{
		regenType regenType2 = regenMode;
		Point3D[] vertices = _vertices;
		bool _0023_003DzKm6RxpjBoSEs = _0023_003DzELu0Pss_003D._0023_003DzKm6RxpjBoSEs;
		_0023_003DzELu0Pss_003D._0023_003DzKm6RxpjBoSEs = true;
		Regen(_0023_003DzELu0Pss_003D);
		_0023_003DzELu0Pss_003D._0023_003DzKm6RxpjBoSEs = _0023_003DzKm6RxpjBoSEs;
		Point3D[] array = new Point3D[_vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			Point3D point3D = _vertices[i];
			array[i] = (Point3D)point3D.Clone();
		}
		_vertices = vertices;
		regenMode = regenType2;
		return array;
	}

	public virtual void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzSrny2FmSPIa7();
		Compiling = true;
		data.RenderContext.Compile(drawData, DrawEntity, null);
		Compiling = false;
		RegenMode = regenType.NotNeeded;
	}

	protected internal virtual void TransformAllVertices(Transformation t)
	{
		_0023_003Dz2ZUdIVU25dQGGvXHgQ_003D_003D(_vertices, t);
	}

	protected internal virtual bool ThroughTriangle(FrustumParams data)
	{
		return false;
	}

	protected void AddSelectedItemLeaf(FrustumParams data)
	{
		if (data.IsLeafSelection && !data.ForceSkipLeafAdd)
		{
			data.LeafSelectionInfo.Add(new SelectedItem(data.Parents, this));
		}
	}

	internal static bool _0023_003Dzz3lsBX3i0Rg2(FrustumParams _0023_003DzELu0Pss_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		byte[] _0023_003Dzsc0Foo8_003D;
		return _0023_003Dzz3lsBX3i0Rg2(_0023_003DzELu0Pss_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzTymA54q3SWU7: false, out _0023_003Dzsc0Foo8_003D);
	}

	internal static bool _0023_003Dzz3lsBX3i0Rg2(FrustumParams _0023_003DzELu0Pss_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, bool _0023_003DzTymA54q3SWU7, out byte[] _0023_003Dzsc0Foo8_003D)
	{
		Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
		_0023_003Dzsc0Foo8_003D = (_0023_003DzTymA54q3SWU7 ? null : new byte[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count]);
		if (transformation == null)
		{
			for (int i = 0; i < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; i++)
			{
				IndexTriangle indexTriangle = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i];
				if (FrustumEdgesTriangleIntersection(_0023_003DzELu0Pss_003D.SelectionEdges, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3]))
				{
					if (_0023_003DzTymA54q3SWU7)
					{
						return true;
					}
					_0023_003Dzsc0Foo8_003D[i] = 1;
				}
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; j++)
			{
				IndexTriangle indexTriangle2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j];
				if (FrustumEdgesTriangleIntersection(_0023_003DzELu0Pss_003D.SelectionEdges, transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V1], transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V2], transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V3]))
				{
					if (_0023_003DzTymA54q3SWU7)
					{
						return true;
					}
					_0023_003Dzsc0Foo8_003D[j] = 1;
				}
			}
		}
		return _0023_003Dzsc0Foo8_003D.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzyMUJMR34aEsJzC4BbAAyAZa7A5aN);
	}

	public static bool ThroughTriangleQuad(FrustumParams data, IList<Point3D> vertices)
	{
		Transformation transformation = data.Transformation;
		if (transformation == null)
		{
			if (FrustumEdgesTriangleIntersection(data.SelectionEdges, vertices[0], vertices[1], vertices[2]) || FrustumEdgesTriangleIntersection(data.SelectionEdges, vertices[0], vertices[2], vertices[3]))
			{
				return true;
			}
		}
		else if (FrustumEdgesTriangleIntersection(data.SelectionEdges, transformation * vertices[0], transformation * vertices[1], transformation * vertices[2]) || FrustumEdgesTriangleIntersection(data.SelectionEdges, transformation * vertices[0], transformation * vertices[2], transformation * vertices[3]))
		{
			return true;
		}
		return false;
	}

	protected internal virtual bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		return false;
	}

	internal static bool _0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		int[] _0023_003Dzsc0Foo8_003D;
		return _0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzELu0Pss_003D, _0023_003DzTymA54q3SWU7: true, out _0023_003Dzsc0Foo8_003D);
	}

	internal static bool _0023_003DzOejNn2S1Lat5_0024X4DHg_003D_003D(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, ScreenPolygonParams _0023_003DzELu0Pss_003D, bool _0023_003DzTymA54q3SWU7, out int[] _0023_003Dzsc0Foo8_003D)
	{
		Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
		_0023_003Dzsc0Foo8_003D = new int[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count];
		if (transformation == null)
		{
			for (int i = 0; i < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; i++)
			{
				IndexTriangle indexTriangle = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i];
				if (ThroughTriangleScreenPolygon(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3], _0023_003DzELu0Pss_003D))
				{
					if (_0023_003DzTymA54q3SWU7)
					{
						return true;
					}
					_0023_003Dzsc0Foo8_003D[i] = 1;
				}
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; j++)
			{
				IndexTriangle indexTriangle2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[j];
				if (ThroughTriangleScreenPolygon(transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V1], transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V2], transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V3], _0023_003DzELu0Pss_003D))
				{
					if (_0023_003DzTymA54q3SWU7)
					{
						return true;
					}
					_0023_003Dzsc0Foo8_003D[j] = 1;
				}
			}
		}
		return _0023_003Dzsc0Foo8_003D.Any((int _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D > 0);
	}

	public static bool ThroughTriangleScreenPolygonQuad(IList<Point3D> vertices, ScreenPolygonParams data)
	{
		Transformation transformation = data.Transformation;
		if (transformation == null)
		{
			if (ThroughTriangleScreenPolygon(vertices[0], vertices[1], vertices[2], data) || ThroughTriangleScreenPolygon(vertices[0], vertices[2], vertices[3], data))
			{
				return true;
			}
		}
		else if (ThroughTriangleScreenPolygon(transformation * vertices[0], transformation * vertices[1], transformation * vertices[2], data) || ThroughTriangleScreenPolygon(transformation * vertices[0], transformation * vertices[2], transformation * vertices[3], data))
		{
			return true;
		}
		return false;
	}

	protected static bool FrustumEdgesTriangleIntersection(Segment3D[] edgeList, Point3D v1, Point3D v2, Point3D v3)
	{
		Vector3D vector3D = Vector3D.Subtract(v2, v1);
		Vector3D vector3D2 = Vector3D.Subtract(v3, v1);
		Vector3D vector3D3 = Vector3D.Cross(vector3D, vector3D2);
		if (vector3D.IsZero || vector3D2.IsZero || vector3D3.IsZero)
		{
			return false;
		}
		for (int i = 0; i < edgeList.Length; i++)
		{
			Point3D p = edgeList[i].P0;
			Vector3D vector3D4 = Vector3D.Subtract(edgeList[i].P1, p);
			double num = vector3D3 * vector3D4;
			if (Math.Abs(num) < 1E-09)
			{
				continue;
			}
			Vector3D vector3D5 = Vector3D.Subtract(p, v1);
			double num2 = (0.0 - vector3D3 * vector3D5) / num;
			if (num2 < 0.0 || num2 > 1.0)
			{
				continue;
			}
			Point3D a = p + num2 * vector3D4;
			double num3 = vector3D * vector3D;
			double num4 = vector3D * vector3D2;
			double num5 = vector3D2 * vector3D2;
			Vector3D vector3D6 = Vector3D.Subtract(a, v1);
			double num6 = vector3D6 * vector3D;
			double num7 = vector3D6 * vector3D2;
			double num8 = num4 * num4 - num3 * num5;
			double num9 = (num4 * num7 - num5 * num6) / num8;
			if (!(num9 < 0.0) && !(num9 > 1.0))
			{
				double num10 = (num4 * num6 - num3 * num7) / num8;
				if (!(num10 < 0.0) && !(num9 + num10 > 1.0))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected static bool ThroughTriangleScreenPolygon(Point3D v1, Point3D v2, Point3D v3, ScreenPolygonParams data)
	{
		Point2D[] array = new Point2D[3];
		Camera.Project(data.Workspace.RenderContext, data.ModelViewProj, data.ViewFrame, v1.X, v1.Y, v1.Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
		if (_0023_003Dz_00246VsdVC_0024uVkn > 1.0)
		{
			return false;
		}
		array[0] = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
		Camera.Project(data.Workspace.RenderContext, data.ModelViewProj, data.ViewFrame, v2.X, v2.Y, v2.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
		if (_0023_003Dz_00246VsdVC_0024uVkn > 1.0)
		{
			return false;
		}
		array[1] = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
		Camera.Project(data.Workspace.RenderContext, data.ModelViewProj, data.ViewFrame, v3.X, v3.Y, v3.Z, out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf, out _0023_003Dz_00246VsdVC_0024uVkn);
		if (_0023_003Dz_00246VsdVC_0024uVkn > 1.0)
		{
			return false;
		}
		array[2] = new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf);
		for (int i = 0; i < array.Length; i++)
		{
			if (Utility.PointInPolygon(array[i], data.ScreenPolygon))
			{
				return true;
			}
		}
		for (int j = 0; j < data.ScreenPolygon.Count; j++)
		{
			if (Utility.PointInPolygon(data.ScreenPolygon[j], array))
			{
				return true;
			}
		}
		return false;
	}

	protected internal virtual bool InsideOrCrossingFrustum(FrustumParams data)
	{
		IList<Point3D> vertices = _vertices;
		data.LineType = GetLineType(data.Document.LineTypes, data.Document.Layers, data.ParentLineType);
		if (IsValidPatternByScreenToWorld(data.LineType, data.ScreenToWorld))
		{
			data.LineType.GetPatternVertices(data.MaxPatternRepetitions, _vertices, LineTypeScale * data.Document.LineTypeScale, out var lines, out var points);
			if (InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, lines, lines.Count, 2) || InsideFrustumPoint(data.Frustum, data.Transformation, points, points.Count))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, vertices, vertices.Count, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal static bool InsideOrCrossingFrustumInternal(PlaneEquation[] frustum, Transformation transform, IList<Point3D> points, int count, int increment)
	{
		if (transform == null || transform.IsIdentity())
		{
			for (int i = 0; i < count - 1; i += increment)
			{
				if (Utility.IsSegmentInsideOrCrossing(frustum, new Segment3D(points[i], points[i + 1])))
				{
					return true;
				}
			}
		}
		else
		{
			for (int j = 0; j < count - 1; j += increment)
			{
				if (Utility.IsSegmentInsideOrCrossing(frustum, new Segment3D(transform * points[j], transform * points[j + 1])))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected internal static bool InsideFrustumPoint(PlaneEquation[] frustum, Transformation transform, IList<Point3D> points, int count)
	{
		if (transform == null || transform.IsIdentity())
		{
			for (int i = 0; i < count; i++)
			{
				if (Utility.IsPointInsideOrCrossing(frustum, points[i]))
				{
					return true;
				}
			}
		}
		else
		{
			for (int j = 0; j < count - 1; j++)
			{
				if (Utility.IsPointInsideOrCrossing(frustum, transform * points[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected internal virtual bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		IList<Point3D> vertices = _vertices;
		data.LineType = GetLineType(data.Document.LineTypes, data.Document.Layers, data.ParentLineType);
		if (IsValidPatternByScreenToWorld(data.LineType, data.ScreenToWorld))
		{
			data.LineType.GetPatternVertices(data.MaxPatternRepetitions, _vertices, LineTypeScale * data.Document.LineTypeScale, out var lines, out var points);
			if (InsideOrCrossingScreenPolygonInternal(data, lines, lines.Count, 2) || InsideOrCrossingScreenPolygonPoint(data, points, points.Count))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
			return false;
		}
		if (InsideOrCrossingScreenPolygonInternal(data, vertices, vertices.Count, 1))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal static bool InsideOrCrossingScreenPolygonInternal(ScreenPolygonParams data, IList<Point3D> points, int count, int increment)
	{
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			for (int i = 0; i < count - 1; i += increment)
			{
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(points[i], points[i + 1], data))
				{
					return true;
				}
			}
		}
		else
		{
			for (int j = 0; j < count - 1; j += increment)
			{
				if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(data.Transformation * points[j], data.Transformation * points[j + 1], data))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected internal static bool InsideOrCrossingScreenPolygonPoint(ScreenPolygonParams data, IList<Point3D> points, int count)
	{
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			for (int i = 0; i < count - 1; i++)
			{
				if (Utility._0023_003DzwNyEcZpX6XZGQQLSIMXoIPUP01j6(points[i], data))
				{
					return true;
				}
			}
		}
		else
		{
			for (int j = 0; j < count - 1; j++)
			{
				if (Utility._0023_003DzwNyEcZpX6XZGQQLSIMXoIPUP01j6(data.Transformation * points[j], data))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool _0023_003Dz8Y5VBifFYChxexbDRySI1v0_003D(FrustumParams _0023_003DzELu0Pss_003D, double[] _0023_003DzDIaDiDgg1F9i)
	{
		return IntersectEdgeOrIsoline(_0023_003DzELu0Pss_003D);
	}

	internal virtual bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		return false;
	}

	internal virtual bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		return false;
	}

	internal virtual void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		FindClosestVertices(_0023_003DzELu0Pss_003D, _vertices, _vertices.Length, _0023_003Dz7xzxLVk_003D);
	}

	internal void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, IList<Point3D> _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D, int _0023_003Dz736ekIs_003D, int _0023_003Dz7xzxLVk_003D)
	{
		Point3D[] array = _0023_003Dz7n1NvS0_003D(_0023_003DzELu0Pss_003D, _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D, _0023_003Dz736ekIs_003D);
		List<int> list = new List<int>();
		for (int i = 0; i < _0023_003Dz736ekIs_003D; i++)
		{
			if (_0023_003DzIK1ryqzolaxwoX45gA_003D_003D(array[i], _0023_003DzELu0Pss_003D))
			{
				list.Add(i);
			}
		}
		List<BlockReference> _0023_003Dzq5nwX2I_003D = ((_0023_003DzELu0Pss_003D.Parents == null) ? null : new List<BlockReference>(_0023_003DzELu0Pss_003D.Parents));
		if (list.Count <= 0)
		{
			return;
		}
		if (_0023_003DzELu0Pss_003D.Transformation != null && !_0023_003DzELu0Pss_003D.Transformation.IsIdentity(0.0))
		{
			for (int j = 0; j < list.Count; j++)
			{
				_0023_003DzELu0Pss_003D.ClosestVertices.Add(new HitVertex(_0023_003DzELu0Pss_003D.Transformation * _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[list[j]], list[j], -1, -1, _0023_003Dz7xzxLVk_003D, _0023_003Dzq5nwX2I_003D));
			}
		}
		else
		{
			for (int k = 0; k < list.Count; k++)
			{
				_0023_003DzELu0Pss_003D.ClosestVertices.Add(new HitVertex(_0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[list[k]], list[k], -1, -1, _0023_003Dz7xzxLVk_003D, _0023_003Dzq5nwX2I_003D));
			}
		}
	}

	internal virtual bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		return FindClosestVertex(_0023_003DzELu0Pss_003D, _vertices, _vertices.Length, _0023_003Dz7xzxLVk_003D);
	}

	internal bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, IList<Point3D> _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D, int _0023_003Dz736ekIs_003D, int _0023_003Dz7xzxLVk_003D)
	{
		bool _0023_003DzcB8c8dw_003D = false;
		Point3D[] array = _0023_003Dz7n1NvS0_003D(_0023_003DzELu0Pss_003D, _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D, _0023_003Dz736ekIs_003D);
		for (int i = 0; i < _0023_003Dz736ekIs_003D; i++)
		{
			_0023_003Dz46TdCSv4NiVERbommQ_003D_003D(array[i], _0023_003DzELu0Pss_003D, ref _0023_003DzcB8c8dw_003D, i, _0023_003Dz7xzxLVk_003D);
		}
		if (_0023_003DzcB8c8dw_003D)
		{
			if (_0023_003DzELu0Pss_003D.Parents != null)
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.Parents = new List<BlockReference>(_0023_003DzELu0Pss_003D.Parents);
				_0023_003DzELu0Pss_003D.ClosestVertex.Parents.Reverse();
			}
			if (_0023_003DzELu0Pss_003D.Transformation != null && !_0023_003DzELu0Pss_003D.Transformation.IsIdentity(0.0))
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.Vertex = _0023_003DzELu0Pss_003D.Transformation * _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[_0023_003DzELu0Pss_003D.ClosestVertex.VertexIndex];
			}
			else
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.Vertex = _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[_0023_003DzELu0Pss_003D.ClosestVertex.VertexIndex];
			}
		}
		return _0023_003DzcB8c8dw_003D;
	}

	private static Point3D[] _0023_003Dz7n1NvS0_003D(FindClosestVertexParamsBase _0023_003DzELu0Pss_003D, IList<Point3D> _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D, int _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D)
	{
		Point3D[] array = new Point3D[_0023_003DzcuodTXZMEy5xbKmohQ_003D_003D];
		Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
		if (transformation != null && !transformation.IsIdentity(0.0))
		{
			for (int i = 0; i < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; i++)
			{
				Point3D point3D = transformation * _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[i];
				_0023_003DzELu0Pss_003D.camera._0023_003DzKWdaQi8_003D(_0023_003DzELu0Pss_003D.Workspace.RenderContext, _0023_003DzELu0Pss_003D.viewFrame, point3D.X, point3D.Y, point3D.Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
				array[i] = new Point3D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf, _0023_003Dz_00246VsdVC_0024uVkn);
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; j++)
			{
				_0023_003DzELu0Pss_003D.camera._0023_003DzKWdaQi8_003D(_0023_003DzELu0Pss_003D.Workspace.RenderContext, _0023_003DzELu0Pss_003D.viewFrame, _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[j].X, _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[j].Y, _0023_003DzetMfEmOPjJ5tRuUHJw_003D_003D[j].Z, out var _0023_003Dzm3rc4SA8WtT2, out var _0023_003DzOM5CofBvYOXf2, out var _0023_003Dz_00246VsdVC_0024uVkn2);
				array[j] = new Point3D(_0023_003Dzm3rc4SA8WtT2, _0023_003DzOM5CofBvYOXf2, _0023_003Dz_00246VsdVC_0024uVkn2);
			}
		}
		return array;
	}

	internal void _0023_003DzZmXx2DpbugLKXntdQQPZMqY_003D(FindClosestVerticesParams _0023_003DzELu0Pss_003D, float[] _0023_003DzrH1N0x4_003D, int _0023_003Dz736ekIs_003D, int _0023_003Dz7xzxLVk_003D)
	{
		Point3D[] array = _0023_003Dz7n1NvS0_003D(_0023_003DzELu0Pss_003D, _0023_003DzrH1N0x4_003D, _0023_003Dz736ekIs_003D / 3);
		List<int> list = new List<int>();
		for (int i = 0; i < array.Length; i++)
		{
			if (_0023_003DzIK1ryqzolaxwoX45gA_003D_003D(array[i], _0023_003DzELu0Pss_003D))
			{
				list.Add(i);
			}
		}
		List<BlockReference> _0023_003Dzq5nwX2I_003D = ((_0023_003DzELu0Pss_003D.Parents == null) ? null : new List<BlockReference>(_0023_003DzELu0Pss_003D.Parents));
		if (_0023_003DzELu0Pss_003D.Transformation != null && !_0023_003DzELu0Pss_003D.Transformation.IsIdentity(0.0))
		{
			float[,] floatMatrix = _0023_003DzELu0Pss_003D.Transformation.GetFloatMatrix();
			for (int j = 0; j < list.Count; j++)
			{
				int num = list[j] * 3;
				float[] array2 = Transformation.ActOnLeftOne(_0023_003DzrH1N0x4_003D[num], _0023_003DzrH1N0x4_003D[num + 1], _0023_003DzrH1N0x4_003D[num + 2], floatMatrix);
				_0023_003DzELu0Pss_003D.ClosestVertices.Add(new HitVertex(new Point3D(array2[0], array2[1], array2[2]), list[j], -1, -1, _0023_003Dz7xzxLVk_003D, _0023_003Dzq5nwX2I_003D));
			}
		}
		else
		{
			for (int k = 0; k < list.Count; k++)
			{
				int num2 = list[k] * 3;
				_0023_003DzELu0Pss_003D.ClosestVertices.Add(new HitVertex(new Point3D(_0023_003DzrH1N0x4_003D[num2], _0023_003DzrH1N0x4_003D[num2 + 1], _0023_003DzrH1N0x4_003D[num2 + 2]), list[k], -1, -1, _0023_003Dz7xzxLVk_003D, _0023_003Dzq5nwX2I_003D));
			}
		}
	}

	internal bool _0023_003DzyI0wuvHQi9AG(FindClosestVertexParams _0023_003DzELu0Pss_003D, float[] _0023_003DzrH1N0x4_003D, int _0023_003Dz736ekIs_003D, int _0023_003Dz7xzxLVk_003D)
	{
		bool _0023_003DzcB8c8dw_003D = false;
		Point3D[] array = _0023_003Dz7n1NvS0_003D(_0023_003DzELu0Pss_003D, _0023_003DzrH1N0x4_003D, _0023_003Dz736ekIs_003D / 3);
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003Dz46TdCSv4NiVERbommQ_003D_003D(array[i], _0023_003DzELu0Pss_003D, ref _0023_003DzcB8c8dw_003D, i, _0023_003Dz7xzxLVk_003D);
		}
		if (_0023_003DzcB8c8dw_003D)
		{
			if (_0023_003DzELu0Pss_003D.Parents != null)
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.Parents = new List<BlockReference>(_0023_003DzELu0Pss_003D.Parents);
				_0023_003DzELu0Pss_003D.ClosestVertex.Parents.Reverse();
			}
			int num = _0023_003DzELu0Pss_003D.ClosestVertex.VertexIndex * 3;
			if (_0023_003DzELu0Pss_003D.Transformation != null && !_0023_003DzELu0Pss_003D.Transformation.IsIdentity(0.0))
			{
				float[,] floatMatrix = _0023_003DzELu0Pss_003D.Transformation.GetFloatMatrix();
				float[] array2 = Transformation.ActOnLeftOne(_0023_003DzrH1N0x4_003D[num], _0023_003DzrH1N0x4_003D[num + 1], _0023_003DzrH1N0x4_003D[num + 2], floatMatrix);
				_0023_003DzELu0Pss_003D.ClosestVertex.Vertex = new Point3D(array2[0], array2[1], array2[2]);
			}
			else
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.Vertex = new Point3D(_0023_003DzrH1N0x4_003D[num], _0023_003DzrH1N0x4_003D[num + 1], _0023_003DzrH1N0x4_003D[num + 2]);
			}
		}
		return _0023_003DzcB8c8dw_003D;
	}

	private static Point3D[] _0023_003Dz7n1NvS0_003D(FindClosestVertexParamsBase _0023_003DzELu0Pss_003D, float[] _0023_003DzrH1N0x4_003D, int _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D)
	{
		Point3D[] array = new Point3D[_0023_003DzcuodTXZMEy5xbKmohQ_003D_003D];
		Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
		if (transformation != null && !transformation.IsIdentity(0.0))
		{
			int num = 0;
			float[,] floatMatrix = transformation.GetFloatMatrix();
			for (int i = 0; i < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; i++)
			{
				float[] array2 = Transformation.ActOnLeftOne(_0023_003DzrH1N0x4_003D[num++], _0023_003DzrH1N0x4_003D[num++], _0023_003DzrH1N0x4_003D[num++], floatMatrix);
				_0023_003DzELu0Pss_003D.camera._0023_003DzKWdaQi8_003D(_0023_003DzELu0Pss_003D.Workspace.RenderContext, _0023_003DzELu0Pss_003D.viewFrame, array2[0], array2[1], array2[2], out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
				array[i] = new Point3D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf, _0023_003Dz_00246VsdVC_0024uVkn);
			}
		}
		else
		{
			int num2 = 0;
			for (int j = 0; j < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; j++)
			{
				_0023_003DzELu0Pss_003D.camera._0023_003DzKWdaQi8_003D(_0023_003DzELu0Pss_003D.Workspace.RenderContext, _0023_003DzELu0Pss_003D.viewFrame, _0023_003DzrH1N0x4_003D[num2++], _0023_003DzrH1N0x4_003D[num2++], _0023_003DzrH1N0x4_003D[num2++], out var _0023_003Dzm3rc4SA8WtT2, out var _0023_003DzOM5CofBvYOXf2, out var _0023_003Dz_00246VsdVC_0024uVkn2);
				array[j] = new Point3D(_0023_003Dzm3rc4SA8WtT2, _0023_003DzOM5CofBvYOXf2, _0023_003Dz_00246VsdVC_0024uVkn2);
			}
		}
		return array;
	}

	private void _0023_003Dz46TdCSv4NiVERbommQ_003D_003D(Point3D _0023_003Dz0RbCW1K1c52K, FindClosestVertexParams _0023_003DzELu0Pss_003D, ref bool _0023_003DzcB8c8dw_003D, int _0023_003DzcJpaJQAcgoDn, int _0023_003Dz7xzxLVk_003D)
	{
		int num = _0023_003DzELu0Pss_003D.viewFrame[0];
		int num2 = num + _0023_003DzELu0Pss_003D.viewFrame[2];
		int num3 = _0023_003DzELu0Pss_003D.viewFrame[1];
		int num4 = num3 + _0023_003DzELu0Pss_003D.viewFrame[3];
		if (_0023_003Dz0RbCW1K1c52K.X > (double)num && _0023_003Dz0RbCW1K1c52K.X < (double)num2 && _0023_003Dz0RbCW1K1c52K.Y > (double)num3 && _0023_003Dz0RbCW1K1c52K.Y < (double)num4)
		{
			double num5 = (double)_0023_003DzELu0Pss_003D.mousePos.X - _0023_003Dz0RbCW1K1c52K.X;
			double num6 = (double)(_0023_003DzELu0Pss_003D.clientHeight - _0023_003DzELu0Pss_003D.mousePos.Y) - _0023_003Dz0RbCW1K1c52K.Y;
			double num7 = num5 * num5 + num6 * num6;
			if (num7 < _0023_003DzELu0Pss_003D.sqrDistance && _0023_003DzELu0Pss_003D.workspaceInternal.IsCloserVertex(_0023_003Dz0RbCW1K1c52K, num7, _0023_003DzELu0Pss_003D.minSqrDist))
			{
				_0023_003DzELu0Pss_003D.minSqrDist = num7;
				_0023_003DzcB8c8dw_003D = true;
				_0023_003DzELu0Pss_003D.ClosestVertex.VertexIndex = _0023_003DzcJpaJQAcgoDn;
				_0023_003DzELu0Pss_003D.ClosestVertex.EntityIndex = _0023_003Dz7xzxLVk_003D;
			}
		}
	}

	private bool _0023_003DzIK1ryqzolaxwoX45gA_003D_003D(Point3D _0023_003Dz0RbCW1K1c52K, FindClosestVerticesParams _0023_003DzELu0Pss_003D)
	{
		int num = _0023_003DzELu0Pss_003D.viewFrame[0];
		int num2 = num + _0023_003DzELu0Pss_003D.viewFrame[2];
		int num3 = _0023_003DzELu0Pss_003D.viewFrame[1];
		int num4 = num3 + _0023_003DzELu0Pss_003D.viewFrame[3];
		if (_0023_003Dz0RbCW1K1c52K.X > (double)num && _0023_003Dz0RbCW1K1c52K.X < (double)num2 && _0023_003Dz0RbCW1K1c52K.Y > (double)num3 && _0023_003Dz0RbCW1K1c52K.Y < (double)num4 && ((double)_0023_003DzELu0Pss_003D.mousePos.X - _0023_003Dz0RbCW1K1c52K.X) * ((double)_0023_003DzELu0Pss_003D.mousePos.X - _0023_003Dz0RbCW1K1c52K.X) + ((double)(_0023_003DzELu0Pss_003D.clientHeight - _0023_003DzELu0Pss_003D.mousePos.Y) - _0023_003Dz0RbCW1K1c52K.Y) * ((double)(_0023_003DzELu0Pss_003D.clientHeight - _0023_003DzELu0Pss_003D.mousePos.Y) - _0023_003Dz0RbCW1K1c52K.Y) < _0023_003DzELu0Pss_003D.sqrDistance)
		{
			return true;
		}
		return false;
	}

	internal virtual void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
	}

	protected internal virtual void DrawDirection(DrawParams data)
	{
	}

	private void _0023_003DzscmcWzZMTK3Yq65PUA_003D_003D(StringBuilder _0023_003DzgyYoHow_003D)
	{
		if (AutodeskProperties != null)
		{
			_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968609));
			_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968603) + AutodeskProperties.Thickness);
			string text = ((AutodeskProperties.ExtrusionDir != null) ? AutodeskProperties.ExtrusionDir.ToString() : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941266));
			_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968592) + text);
			if (!string.IsNullOrEmpty(AutodeskProperties.UnparsedDimensionText))
			{
				_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968806) + AutodeskProperties.UnparsedDimensionText);
			}
			_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
	}

	public Material GetMaterial(MaterialKeyedCollection materials, LayerKeyedCollection layers, Material parentMaterial = null)
	{
		switch (ColorMethod)
		{
		case colorMethodType.byEntity:
		{
			Material value2 = null;
			materials?.TryGetValue(MaterialName, out value2);
			return value2;
		}
		case colorMethodType.byParent:
			return parentMaterial;
		case colorMethodType.byLayer:
		{
			Material value = null;
			if (materials != null)
			{
				Layer itemFast = layers.GetItemFast(LayerName);
				materials.TryGetValue(itemFast.MaterialName, out value);
			}
			return value;
		}
		default:
			return null;
		}
	}

	internal Color GetColorRecursively(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, IWorkspace _0023_003DzFM3KC0w_003D = null)
	{
		Color result = _0023_003DzeWJg3NJnk3WA[LayerName].Color;
		switch (ColorMethod)
		{
		case colorMethodType.byEntity:
			result = Color;
			break;
		case colorMethodType.byParent:
			if (_0023_003Dzq5nwX2I_003D != null && _0023_003Dzq5nwX2I_003D.Count > 0)
			{
				BlockReference blockReference = _0023_003Dzq5nwX2I_003D.Pop();
				result = blockReference.GetColorRecursively(_0023_003Dzq5nwX2I_003D, _0023_003DzeWJg3NJnk3WA, _0023_003DzFM3KC0w_003D);
				_0023_003Dzq5nwX2I_003D.Push(blockReference);
			}
			else if (_0023_003DzFM3KC0w_003D != null)
			{
				result = _0023_003DzFM3KC0w_003D.Document.DefaultColor;
			}
			break;
		}
		return result;
	}

	public Color GetColor(LayerKeyedCollection layers, Color? parentColor = null)
	{
		Color result = layers[LayerName].Color;
		switch (ColorMethod)
		{
		case colorMethodType.byEntity:
			result = Color;
			break;
		case colorMethodType.byParent:
			if (parentColor.HasValue)
			{
				result = parentColor.Value;
			}
			break;
		}
		return result;
	}

	public double GetLineWeight(LayerKeyedCollection layers, double? parentLineWeight = null)
	{
		double result = layers[LayerName].LineWeight;
		switch (LineWeightMethod)
		{
		case colorMethodType.byEntity:
			result = LineWeight;
			break;
		case colorMethodType.byParent:
			result = parentLineWeight ?? 1.0;
			break;
		}
		return result;
	}

	internal StringBuilder _0023_003DzJ7t6sHqYVrbZ(StringBuilder _0023_003DzgyYoHow_003D, double _0023_003DzXWCF4rA_003D, Point3D _0023_003DzAFjGpZXv1YXZAqioSQ_003D_003D, double _0023_003DzhKcriekaIolc, Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, double _0023_003DzZZ1x4JqOx404, double _0023_003DzCtrz4DvviN6U, linearUnitsType _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D, massUnitsType _0023_003DzyxvbkJ1lwtnX, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA)
	{
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968771) + _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D.ToString().ToLower());
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968762) + _0023_003DzyxvbkJ1lwtnX.ToString().ToLower());
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957046) + _0023_003DzXWCF4rA_003D.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957036) + _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D.ToString().ToLower());
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957017) + _0023_003DzAFjGpZXv1YXZAqioSQ_003D_003D);
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956978) + _0023_003DzhKcriekaIolc.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956962) + _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D.ToString().ToLower());
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956976) + _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D);
		Material material = GetMaterial(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, _0023_003DzeWJg3NJnk3WA);
		bool num = material != null;
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968747);
		string text2 = (num ? material.Name : text);
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968731) + text2);
		string text3 = _0023_003DzCtrz4DvviN6U + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzyxvbkJ1lwtnX.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968717) + _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D.ToString().ToLower();
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968447) + text3);
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956935) + _0023_003DzZZ1x4JqOx404.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzyxvbkJ1lwtnX.ToString().ToLower());
		return _0023_003DzgyYoHow_003D;
	}

	internal virtual _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		return null;
	}

	internal void _0023_003DzYe_6EnQecc8d(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003Dzs_0024uS8LA_003D, Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ)
	{
		_0023_003DzISRR3MaRx1qQ?[LayerName].Add(_0023_003Dzs_0024uS8LA_003D);
		if (_0023_003Dz1MMYB1g_003D != Color.Empty)
		{
			_0023_003Dzs_0024uS8LA_003D._0023_003Dzwtld1NM_003D = new double[3]
			{
				(double)(int)_0023_003Dz1MMYB1g_003D.R / 255.0,
				(double)(int)_0023_003Dz1MMYB1g_003D.G / 255.0,
				(double)(int)_0023_003Dz1MMYB1g_003D.B / 255.0
			};
		}
	}

	internal virtual SilhoWireData _0023_003DzOQ9MbnSofHiL_xtPyyGkf6ozeVZJ(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(_0023_003DzELu0Pss_003D);
	}

	internal virtual SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return null;
	}

	protected internal virtual void SetShader(DrawParams data)
	{
		if (data.RenderContext.Shaders != null)
		{
			data.RenderContext.GetShaderAndEnable(data.ShaderParams);
		}
	}

	protected internal virtual bool IsCrossing(FrustumParams data)
	{
		if (IntersectEdgeOrIsoline(data) || InsideOrCrossingFrustum(data))
		{
			return true;
		}
		if (((data.DisplayMode != displayType.Wireframe && (entityNature == entityNatureType.Polygon || entityNature == entityNatureType.RichPolygon || this is BlockReference)) || this is Triangle || this is Quad || this is Text || this is Table || this is Hatch) && ThroughTriangle(data))
		{
			return true;
		}
		return false;
	}

	protected bool IsValidPatternByScreenToWorld(LineType lineType, float screenToWorld)
	{
		if (lineType == null || screenToWorld == 0f || lineType.Length < screenToWorld * 4f)
		{
			return false;
		}
		return true;
	}

	protected internal static void PropagateAttributes(Entity srcEntity, Entity destEntity, bool force)
	{
		if (force || destEntity.ColorMethod == colorMethodType.byParent)
		{
			destEntity.ColorMethod = srcEntity.ColorMethod;
			destEntity.Color = srcEntity.Color;
			destEntity.MaterialName = srcEntity.MaterialName;
			if (srcEntity.ColorMethod == colorMethodType.byLayer)
			{
				destEntity.LayerName = srcEntity.LayerName;
			}
		}
		if (force || destEntity.LineTypeMethod == colorMethodType.byParent)
		{
			destEntity.LineTypeMethod = srcEntity.LineTypeMethod;
			destEntity.LineTypeName = srcEntity.LineTypeName;
			if (srcEntity.LineTypeMethod == colorMethodType.byLayer)
			{
				destEntity.LayerName = srcEntity.LayerName;
			}
		}
		if (force || destEntity.LineWeightMethod == colorMethodType.byParent)
		{
			destEntity.LineWeightMethod = srcEntity.LineWeightMethod;
			destEntity.LineWeight = srcEntity.LineWeight;
			if (srcEntity.LineWeightMethod == colorMethodType.byLayer)
			{
				destEntity.LayerName = srcEntity.LayerName;
			}
		}
	}

	internal bool IsPolygonal()
	{
		if (entityNature != entityNatureType.Polygon)
		{
			return entityNature == entityNatureType.RichPolygon;
		}
		return true;
	}

	internal virtual shaderPrimitiveType GetPrimitiveTypeForWireframe(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (entityNature == entityNatureType.Point)
		{
			return shaderPrimitiveType.Point;
		}
		return shaderPrimitiveType.Line;
	}

	internal virtual shaderPrimitiveType GetPrimitiveTypeForFlat(DrawParams _0023_003DzELu0Pss_003D)
	{
		return entityNature switch
		{
			entityNatureType.Point => shaderPrimitiveType.Point, 
			entityNatureType.Wire => shaderPrimitiveType.Line, 
			_ => shaderPrimitiveType.Polygon, 
		};
	}

	internal virtual shaderPrimitiveType GetPrimitiveTypeForHiddenLines(DrawParams _0023_003DzELu0Pss_003D)
	{
		return GetPrimitiveTypeForFlat(_0023_003DzELu0Pss_003D);
	}

	protected internal static void SetSelectionColorForSelection(DrawParams data)
	{
		switch (data.ColorMode)
		{
		case colorType.Wireframe:
			data.RenderContext.SetColorWireframe(data.InsideSelectionColor);
			break;
		case colorType.Rendered:
		{
			Color diffuse = data.InsideSelectionMaterial.Diffuse;
			data.InsideSelectionMaterial.Diffuse = Color.FromArgb(data.InsideMaterial.Diffuse.A, diffuse);
			data.RenderContext.SetMaterial(data.InsideSelectionMaterial, _0023_003DzNGLWIVQ_003D: true, data);
			data.RenderContext._0023_003DzAQu_Xko_003D(data.InsideSelectionMaterial, (RenderParams)data);
			data.InsideSelectionMaterial.Diffuse = diffuse;
			break;
		}
		case colorType.Shaded:
			data.RenderContext.SetColorShadedInternal(entityNatureType.Polygon, data.InsideSelectionColor, _0023_003DzNGLWIVQ_003D: true, data.viewportInternal.parent.Backface);
			break;
		case colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected:
			data.RenderContext.SetColorWireframe(data.InsideSelectionColor);
			data.RenderContext.SetLighting(enable: false);
			data.RenderContext.SetShader(shaderType.NoLights);
			break;
		case colorType.ColorFrontMaterialAmbientAndDiffuse:
			data.RenderContext.SetMaterialFrontAmbientAndDiffuse(data.InsideSelectionColor);
			break;
		case colorType.ColorFrontMaterialAmbient:
			data.RenderContext.SetMaterialFrontAmbient(data.InsideSelectionColor);
			break;
		case colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected:
			data.RenderContext.SetColorWireframe(data.InsideSelectionColor);
			data.RenderContext.SetLighting(data.IsDrawingForHalo);
			data.RenderContext.SetShader(data.IsDrawingForHalo ? shaderType.Standard : shaderType.NoLights);
			break;
		}
	}

	protected internal static void SetEntityColorForSelection(DrawParams data)
	{
		switch (data.ColorMode)
		{
		case colorType.Wireframe:
			data.RenderContext.SetColorWireframe(data.InsideColor);
			break;
		case colorType.Rendered:
		{
			bool texture2D = data.RenderContext.SetMaterial(data.InsideMaterial, _0023_003DzNGLWIVQ_003D: false, data);
			data.RenderContext._0023_003DzAQu_Xko_003D(data.InsideMaterial, (RenderParams)data);
			data.ShaderParams.Texture2D = texture2D;
			data.RenderContext.GetShaderAndEnable(data.ShaderParams);
			break;
		}
		case colorType.Shaded:
			data.RenderContext.SetColorShadedInternal(entityNatureType.Polygon, data.InsideColor, _0023_003DzNGLWIVQ_003D: false, data.viewportInternal.parent.Backface);
			break;
		case colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected:
			data.RenderContext.SetMaterialFrontAmbientAndDiffuse(data.InsideColor);
			data.RenderContext.SetMaterialBackDiffuse(data.InsideColor);
			data.RenderContext.SetLighting(enable: true);
			data.RenderContext.SetShader(shaderType.Standard);
			break;
		case colorType.ColorFrontMaterialAmbientAndDiffuse:
			data.RenderContext.SetMaterialFrontAmbientAndDiffuse(data.InsideColor);
			break;
		case colorType.ColorFrontMaterialAmbient:
		case colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected:
			data.RenderContext.SetMaterialFrontAmbient(data.InsideColor);
			data.RenderContext.SetLighting(enable: true);
			data.RenderContext.SetShader(shaderType.Standard);
			break;
		}
	}

	protected internal static void SetEntityColorForFace(DrawParams data, Color color)
	{
		switch (data.ColorMode)
		{
		case colorType.Shaded:
		case colorType.Rendered:
			data.RenderContext.SetColorDiffuse(color, RenderContextBase._0023_003DzG_0024lkZE0vy9Tc(color, data.viewportInternal.parent.Backface, _0023_003DzNGLWIVQ_003D: false));
			break;
		case colorType.Wireframe:
		case colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected:
			data.RenderContext.SetColorWireframe(color);
			data.RenderContext.SetMaterialFrontAmbientAndDiffuse(color);
			data.RenderContext.SetMaterialBackDiffuse(color);
			break;
		case colorType.ColorFrontMaterialAmbientAndDiffuse:
			data.RenderContext.SetMaterialFrontAmbientAndDiffuse(color);
			break;
		case colorType.ColorFrontMaterialAmbient:
		case colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected:
			data.RenderContext.SetMaterialFrontAmbient(color);
			break;
		}
	}

	protected internal static void SetEntityMaterialForFace(DrawParams data, Material mat)
	{
		if (data.ColorMode == colorType.Rendered)
		{
			data.RenderContext._0023_003DzAjR7yQItKV_0024s(mat, data.Selected, (RenderParams)data);
			data.RenderContext.GetShaderAndEnable(data.ShaderParams);
		}
	}

	public virtual void SetLineWeight(RenderContextBase renderContext, float lineWeight)
	{
		switch (entityNature)
		{
		case entityNatureType.Point:
			renderContext.SetPointSize(lineWeight, setShader: false);
			break;
		case entityNatureType.Wire:
			renderContext.SetPointSize(lineWeight, setShader: false);
			renderContext.SetLineSize(lineWeight, setShader: false);
			break;
		case entityNatureType.Polygon:
		case entityNatureType.RichPolygon:
			renderContext.SetLineSize(lineWeight, setShader: false);
			break;
		}
	}

	protected internal virtual void SetLineWeightForSilhouettes(DrawSilhouettesParams data)
	{
		_0023_003Dzw7EU_3iuNJBd(data, data.Selected ? (data.SelectionLineWeightScaleFactor * data.SilhoThickness) : data.SilhoThickness);
	}

	protected internal virtual void SetLineWeightForEdges(DrawParams data)
	{
		_0023_003Dzw7EU_3iuNJBd(data, data.Selected ? (data.SelectionLineWeightScaleFactor * data.EdgeThickness) : data.EdgeThickness);
	}

	internal void _0023_003Dzw7EU_3iuNJBd(DrawParams _0023_003DzELu0Pss_003D, float _0023_003DzxOQTW6c4mcu_0024)
	{
		if (_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzxOQTW6c4mcu_0024, setShader: false) != _0023_003DzxOQTW6c4mcu_0024)
		{
			_0023_003DzELu0Pss_003D.RenderContext.EnableThickLinesInPolygonLineMode();
		}
	}

	internal virtual void ClearSelectionFaces(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
	}

	internal virtual List<SelectedSubItem> ClearSelectionFaces(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		return null;
	}

	internal virtual List<SelectionInfoSubItems> _0023_003Dz4NlMyrooY_aHAHG2Ag_003D_003D()
	{
		return null;
	}

	internal virtual int _0023_003Dz5RPGbcVkdZb3()
	{
		return -1;
	}

	internal static List<SelectedSubItem> ClearChildrenItemsSelection<T>(selectionStatusType _0023_003DzCYtX6jC7ppkE, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, ISelectableItem _0023_003DzG1TqnNw_003D, SelectionInfo[] _0023_003DzhiXQ7yaMmgIG, int _0023_003DzRLCcpW4_003D = -1) where T : SelectedSubItem, new()
	{
		List<SelectedSubItem> list = new List<SelectedSubItem>();
		if (_0023_003DzhiXQ7yaMmgIG != null)
		{
			for (int i = 0; i < _0023_003DzhiXQ7yaMmgIG.Length; i++)
			{
				if (_0023_003DzhiXQ7yaMmgIG[i].IsFlagSet(_0023_003DzCYtX6jC7ppkE))
				{
					T val = new T();
					val.Init(_0023_003Dzq5nwX2I_003D, _0023_003DzG1TqnNw_003D, i, _0023_003DzRLCcpW4_003D);
					list.Add(val);
					_0023_003DzhiXQ7yaMmgIG[i].UnsetFlag(_0023_003DzCYtX6jC7ppkE);
				}
			}
		}
		return list;
	}

	public LineType GetLineType(LineTypeKeyedCollection lineTypes, LayerKeyedCollection layers, LineType parentLineType = null)
	{
		if (!(this is ICurve) && !(this is BlockReference) && !(this is SectionLine))
		{
			return null;
		}
		switch (LineTypeMethod)
		{
		case colorMethodType.byEntity:
		{
			lineTypes.TryGetValue(LineTypeName, out var value2);
			return value2;
		}
		case colorMethodType.byParent:
			return parentLineType;
		case colorMethodType.byLayer:
		{
			Layer itemFast = layers.GetItemFast(LayerName);
			lineTypes.TryGetValue(itemFast.LineTypeName, out var value);
			return value;
		}
		default:
			return null;
		}
	}

	protected internal virtual void DrawOnScreenWireframe(DrawOnScreenWireframeParams myParams)
	{
		if (_vertices != null)
		{
			DrawOnScreenWireframe(myParams, Vertices.Length);
		}
	}

	protected internal void DrawOnScreenWireframe(DrawOnScreenWireframeParams myParams, int vertexCount)
	{
		if (_vertices == null)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < vertexCount; i++)
		{
			Camera.ComputeScreenPosition(myParams.RenderContext, myParams.ModelViewProj, myParams.ViewFrame, _vertices[i], out var _0023_003DzBJFJHwk_003D, out var _0023_003Dz40R7bAU_003D, out var _);
			num++;
			if (!(_0023_003DzBJFJHwk_003D < 0f) && !(_0023_003Dz40R7bAU_003D < 0f))
			{
				_0023_003Dzwv3N4vevzN8d(myParams.RenderContext, myParams.DigitsTexture, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, num);
			}
		}
	}

	protected internal virtual void DrawOnScreen(DrawOnScreenParams drawOnScreenParams)
	{
		if (_vertices != null)
		{
			DrawOnScreen(drawOnScreenParams, _vertices.Length);
		}
	}

	protected internal void DrawOnScreen(DrawOnScreenParams myParams, int vertexCount)
	{
		if (_vertices == null)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < vertexCount; i++)
		{
			Camera.ComputeScreenPosition(myParams.RenderContext, myParams.ModelViewProj, myParams.ViewFrame, _vertices[i], out var _0023_003DzBJFJHwk_003D, out var _0023_003Dz40R7bAU_003D, out var _0023_003DzId5C3LA_003D);
			num++;
			if (!(_0023_003DzBJFJHwk_003D < 0f) && !(_0023_003Dz40R7bAU_003D < 0f))
			{
				myParams.Camera.CheckScreenPointVisibility(Camera.ViewportPointSize, myParams.DepthValues, myParams.Stride, myParams.ViewFrame, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D, myParams.LeftBorder, myParams.RightBorder, myParams.BottomBorder, myParams.TopBorder, out var _0023_003DzaaJHKt4_003D);
				if (!_0023_003DzaaJHKt4_003D)
				{
					_0023_003Dzwv3N4vevzN8d(myParams.RenderContext, myParams.DigitsTexture, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, num);
				}
			}
		}
	}

	private void _0023_003Dzwv3N4vevzN8d(RenderContextBase _0023_003DzQdnFby4_003D, TextureMosaicBase _0023_003DzTdtGatfVuhzXOtdCOA_003D_003D, float _0023_003DzBJFJHwk_003D, float _0023_003Dz40R7bAU_003D, int _0023_003Dzfsn580w_003D)
	{
		PointF position = new PointF(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		_0023_003DzTdtGatfVuhzXOtdCOA_003D_003D.Draw(_0023_003DzQdnFby4_003D, GetDigits(_0023_003Dzfsn580w_003D), ref position, drawBuffered: true);
	}

	internal static int[] GetDigits(int _0023_003Dz437_00244ak_003D)
	{
		int num = 0;
		int num2 = _0023_003Dz437_00244ak_003D;
		do
		{
			num2 /= 10;
			num++;
		}
		while (num2 > 0);
		int[] array = new int[num];
		num2 = _0023_003Dz437_00244ak_003D;
		for (int num3 = array.Length - 1; num3 >= 0; num3--)
		{
			array[num3] = num2 % 10;
			num2 /= 10;
		}
		return array;
	}

	protected internal virtual void Draw(DrawParams data)
	{
		data.RenderContext.Draw(drawData);
	}

	protected void CompileWire(CompileParams data)
	{
		if (data.CompileWires)
		{
			data.RenderContext.Compile(drawData, DrawWireEntity, null);
			CompilePattern(data);
		}
	}

	protected virtual void CompilePattern(CompileParams data)
	{
		if (data.LineType != null && data.LineType.Length > 0f && !data._0023_003Dz_5uhDE0_003D)
		{
			data.RenderContext.Compile(drawPattern, DrawWithPattern, data);
		}
	}

	protected virtual void DrawEntity(RenderContextBase context, object myParams)
	{
	}

	protected internal virtual void DrawForDepthPass(DrawParams data)
	{
		DrawSelected(data);
	}

	protected virtual void DrawWireEntity(RenderContextBase context, object myParams)
	{
		context.DrawLineStrip(_vertices);
	}

	private protected bool _0023_003DzVmP7M1MzcRAi(DrawParams _0023_003DzELu0Pss_003D, LineType _0023_003DzhC3Yby0_003D)
	{
		if (_0023_003DzhC3Yby0_003D.Length * LineTypeScale * _0023_003DzELu0Pss_003D.LineTypeScale > 4f * _0023_003DzELu0Pss_003D.viewportInternal.screenToWorld && _0023_003DzELu0Pss_003D.viewportInternal.screenToWorld > 0f)
		{
			if (_0023_003DzELu0Pss_003D.FullParents.Count > 0 || _0023_003DzELu0Pss_003D.Parents.Count > 0 || !_0023_003DzELu0Pss_003D.viewportInternal.parent.IsOpenRootLevel || !_0023_003DzELu0Pss_003D.CompileWires)
			{
				_0023_003DzcbxI7LvTjkOHwnPzLg_003D_003D(_0023_003DzELu0Pss_003D, _0023_003DzhC3Yby0_003D, _vertices);
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.Draw(drawPattern);
			}
			return true;
		}
		return false;
	}

	private protected virtual void _0023_003DzcbxI7LvTjkOHwnPzLg_003D_003D(DrawParams _0023_003DzELu0Pss_003D, LineType _0023_003DzhC3Yby0_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		_0023_003DzhC3Yby0_003D.GetPatternVertices(_0023_003DzELu0Pss_003D.MaxPatternRepetitions, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, LineTypeScale * _0023_003DzELu0Pss_003D.LineTypeScale, out var lines, out var points, _0023_003DzELu0Pss_003D.Transformation);
		for (int i = 0; i < lines.Count; i += 2)
		{
			_0023_003DzELu0Pss_003D.RenderContext.DrawBufferedLine(lines[i], lines[i + 1]);
		}
		_0023_003DzELu0Pss_003D.RenderContext.DrawPointsOnTheFly(points.ToArray());
	}

	protected virtual void DrawWire(DrawParams data)
	{
		if (data.LineTypes.TryGetValue(data.Attributes?.LineTypeName, out var value) && _0023_003DzVmP7M1MzcRAi(data, value))
		{
			return;
		}
		if (data.CompileWires)
		{
			data.RenderContext.Draw(drawData);
			return;
		}
		for (int i = 0; i < _vertices.Length - 1; i++)
		{
			data.RenderContext.DrawBufferedLine(_vertices[i], _vertices[i + 1]);
		}
	}

	protected internal virtual void DrawFast(DrawParams data)
	{
		if (entityNature == entityNatureType.Polygon || entityNature == entityNatureType.RichPolygon)
		{
			data.RenderContext.PushRasterizerState();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_PolygonOffset_1_1);
			Draw(data);
			data.RenderContext.PopRasterizerState();
		}
		Draw(data);
	}

	protected internal virtual void DrawFlatFast(DrawParams data)
	{
		if (entityNature == entityNatureType.Polygon || entityNature == entityNatureType.RichPolygon)
		{
			data.RenderContext.PushRasterizerState();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_PolygonOffset_1_1);
			DrawFlat(data);
			data.RenderContext.PopRasterizerState();
		}
		DrawFlat(data);
	}

	protected virtual void DrawWithPattern(RenderContextBase renderContext, object myParams)
	{
		CompileParams compileParams = (CompileParams)myParams;
		compileParams.LineType.GetPatternVertices(compileParams.MaxPatternRepetitions, _vertices, LineTypeScale * compileParams.LineTypeScale, out var lines, out var points);
		compileParams.RenderContext.DrawLinesAndPoints(lines.ToArray(), points.ToArray());
	}

	protected internal virtual void DrawSelected(DrawParams data)
	{
		Draw(data);
	}

	protected internal virtual void DrawFlatSelected(DrawParams drawParams)
	{
		DrawSelected(drawParams);
	}

	protected internal virtual void DrawWireframeSelected(DrawParams data)
	{
		DrawWireframe(data);
	}

	protected internal virtual void Render(RenderParams data)
	{
		Draw(data);
	}

	protected internal virtual void RenderFast(RenderParams data)
	{
		if (entityNature == entityNatureType.Polygon || entityNature == entityNatureType.RichPolygon)
		{
			data.RenderContext.PushRasterizerState();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_PolygonOffset_1_1);
			Render(data);
			data.RenderContext.PopRasterizerState();
		}
		Render(data);
	}

	protected internal virtual void DrawForShadow(RenderParams data)
	{
		Draw(data);
	}

	protected internal virtual void DrawFlat(DrawParams data)
	{
		Draw(data);
	}

	protected internal virtual void DrawWireframe(DrawParams data)
	{
		Draw(data);
	}

	protected internal virtual void DrawIsocurves(DrawParams data)
	{
	}

	protected internal virtual void DrawIsocurvesForFlat(DrawParams data)
	{
	}

	protected internal virtual void DrawForSelectionFaces(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelectionEdges(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelectionVertices(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelectionSubCurves(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelectionSubContours(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelectionSketchPoints(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelectionSketchCurves(DrawForSelectionParams data)
	{
	}

	protected internal virtual void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	protected internal virtual void DrawForSelectionWireframe(DrawForSelectionParams data)
	{
		DrawForSelection(data);
	}

	protected internal virtual void DrawEdges(DrawParams data)
	{
	}

	protected double GetNormalLength()
	{
		return new Size3D(localMin, localMax).Diagonal / 100.0;
	}

	protected internal virtual void DrawNormals(DrawParams data)
	{
	}

	protected internal virtual void DrawVertices(DrawParams data)
	{
		_0023_003DzfytGakPJH0VOucX17g_003D_003D(data.RenderContext, _vertices, _vertices.Length);
	}

	protected internal virtual void DrawSelectedVertices(DrawParams data)
	{
	}

	internal void _0023_003DzfytGakPJH0VOucX17g_003D_003D(RenderContextBase _0023_003DzQdnFby4_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003Dz736ekIs_003D)
	{
		_0023_003DzQdnFby4_003D.DrawPoints(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, 0, _0023_003Dz736ekIs_003D);
	}

	protected internal virtual void DrawHiddenLinesMaterial(RenderParams data)
	{
		Render(data);
	}

	protected internal virtual void DrawHiddenLinesMaterialFast(RenderParams data)
	{
		RenderFast(data);
	}

	protected internal virtual void DrawHiddenLines(DrawParams data)
	{
		Draw(data);
	}

	protected internal virtual void DrawHiddenLinesFast(DrawParams data)
	{
		DrawFast(data);
	}

	protected internal virtual void DrawSilhouettes(DrawSilhouettesParams data)
	{
	}
}
