using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class Block : IEquatable<Block>, ISerializable, IDisposable, ICloneable, IKeyedCollectionDisposableItem<Block>, IKeyedCollectionItem<Block>, INotifyKeyChanged, IReadWriteDataEx, IDataEx, IWriteDataEx
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003DzhQ3FuW8xdquAzdgCDg_003D_003D;

		internal bool _0023_003Dzgskp9ngVa4wS86wYgSF5g0o_003D(Entity _0023_003Dzs_0024uS8LA_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D is BlockReference;
		}
	}

	internal autodeskExportType _exportMode;

	internal float[] zoomFitConvexHull;

	internal string blockNameForExport;

	internal string _filePath;

	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

	internal bool regenerated;

	internal SketchEntity sketchEntity;

	private EntityList _entList;

	private Point3D _basePoint;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003DzCcbOFGI_003D;

	private string _description;

	private List<List<int>> _groups = new List<List<int>>();

	public static linearUnitsType DefaultUnits = linearUnitsType.Meters;

	private linearUnitsType _units = DefaultUnits;

	public static massUnitsType DefaultMassUnits = massUnitsType.Kilograms;

	private massUnitsType _massUnits = DefaultMassUnits;

	internal const string COMBINE_BY_COLOR_BLOCK_NAME = "noJitter";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003Dz5KguOoA_003D = 1;

	private bool changedBasePoint;

	internal HashSet<BlockReference> referencesToMe = new HashSet<BlockReference>();

	private int _dof;

	private Dictionary<BlockReference, double[]> _oldParams;

	internal _0023_003Dz8MfiwJHarI9u66omqzWP6QqoL2rzmT2nhA_003D_003D matesGraph;

	public string XRefName { get; internal set; }

	public autodeskExportType ExportMode
	{
		get
		{
			return _exportMode;
		}
		set
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950913));
		}
	}

	public autodeskSourceType BlockSource { get; set; }

	public string FilePath
	{
		get
		{
			return _filePath;
		}
		set
		{
			if (value != null && value.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951114), StringComparison.InvariantCultureIgnoreCase))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951092));
			}
			_filePath = value;
		}
	}

	public object CustomData { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Block name.")]
	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (!string.Equals(_name, value, StringComparison.OrdinalIgnoreCase))
			{
				OnKeyChanged(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
				_name = value;
			}
		}
	}

	public bool IsResolved { get; internal set; }

	public EntityList Entities => _entList;

	public Point3D BasePoint
	{
		get
		{
			return _basePoint;
		}
		set
		{
			_basePoint = value;
			foreach (BlockReference item in referencesToMe)
			{
				item.fullTransformation = null;
			}
			changedBasePoint = true;
		}
	}

	public linearUnitsType Units
	{
		get
		{
			return _units;
		}
		set
		{
			_units = value;
			if (_units == linearUnitsType.NotSupported)
			{
				_units = linearUnitsType.Unitless;
			}
		}
	}

	public massUnitsType MassUnits
	{
		get
		{
			return _massUnits;
		}
		set
		{
			_massUnits = value;
			if (_massUnits == massUnitsType.NotSupported)
			{
				_massUnits = massUnitsType.Unitless;
			}
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			_description = value;
		}
	}

	public List<List<int>> Groups
	{
		get
		{
			return _groups;
		}
		set
		{
			_groups = value;
		}
	}

	public int DOF => _dof;

	public List<Mate> MatesList { get; } = new List<Mate>();

	public event KeyChangedEventHandler KeyChanged
	{
		[CompilerGenerated]
		add
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Combine(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Remove(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
	}

	public Block(string name)
		: this(name, Point3D.Origin)
	{
	}

	public Block(string name, double basePointX, double basePointY, double basePointZ)
		: this(name, new Point3D(basePointX, basePointY, basePointZ))
	{
	}

	public Block(string name, Point3D basePoint)
	{
		Name = name;
		BasePoint = basePoint;
		_0023_003DzhYfvCOi6649X(new EntityList());
	}

	public Block(string name, Point3D basePoint, linearUnitsType units)
	{
		Name = name;
		BasePoint = basePoint;
		_0023_003DzhYfvCOi6649X(new EntityList());
		_units = units;
	}

	public Block(string name, linearUnitsType units)
	{
		Name = name;
		BasePoint = Point3D.Origin;
		_0023_003DzhYfvCOi6649X(new EntityList());
		_units = units;
	}

	public Block(Block another, bool keepTessellation = false)
		: this(another, _0023_003DzQmmjROxvNJdJ: true, keepTessellation)
	{
	}

	internal Block(Block _0023_003DzySgeilxprQOK, bool _0023_003DzQmmjROxvNJdJ, bool _0023_003Dzu9oxwJ_zKlMt)
	{
		CloneBlock(_0023_003DzySgeilxprQOK, _0023_003DzQmmjROxvNJdJ, _0023_003Dzu9oxwJ_zKlMt);
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Block()
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951376), _0023_003Dz5KguOoA_003D++))
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Block(double basePointX, double basePointY, double basePointZ)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951376), _0023_003Dz5KguOoA_003D++), basePointX, basePointY, basePointZ)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Block(Point3D basePoint)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951376), _0023_003Dz5KguOoA_003D++), basePoint)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Block(Point3D basePoint, linearUnitsType units)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951376), _0023_003Dz5KguOoA_003D++), basePoint, units)
	{
	}

	[Obsolete("Use the constructor that accepts the name as first parameter instead.")]
	public Block(linearUnitsType units)
		: this(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951376), _0023_003Dz5KguOoA_003D++), units)
	{
	}

	protected internal Block(BlockSurrogate surrogate)
		: this(surrogate.Name, surrogate.BasePoint, (linearUnitsType)surrogate.Units)
	{
	}

	protected Block(SerializationInfo info, StreamingContext context)
	{
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		_0023_003DzhYfvCOi6649X((EntityList)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951314), typeof(EntityList)));
		BasePoint = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300), typeof(Point3D));
		_units = (linearUnitsType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951311), typeof(linearUnitsType));
		_massUnits = (massUnitsType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951035), typeof(massUnitsType));
		_description = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019));
		_filePath = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951005));
		_exportMode = (autodeskExportType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950990), typeof(autodeskExportType));
		XRefName = (string)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950976), typeof(string));
		BlockSource = (autodeskSourceType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950960), typeof(autodeskSourceType));
	}

	private void _0023_003DzaFFNyIFrZikPLuTPQK7cutgtnC4anl_0024Xk1MOG4s_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		XRefName = _0023_003DzPzO_0024GUk_003D;
	}

	void IWriteDataEx.set_XRefName(string _0023_003DzPzO_0024GUk_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zaFFNyIFrZikPLuTPQK7cutgtnC4anl$Xk1MOG4s=
		this._0023_003DzaFFNyIFrZikPLuTPQK7cutgtnC4anl_0024Xk1MOG4s_003D(_0023_003DzPzO_0024GUk_003D);
	}

	public void SetXReferenceData(Block another)
	{
		_exportMode = another._exportMode;
		_filePath = another._filePath;
		XRefName = another.XRefName;
	}

	internal float[] _0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D(IList<float> _0023_003Dzb4kOgUXOEMEs2KHscVEStxQ_003D, TraversalParams _0023_003DzELu0Pss_003D, double _0023_003DzxH4ozIo_003D, bool _0023_003DzCQIEH09zkxfv3kaXNy_002409eA_003D)
	{
		float[] result = null;
		if (_0023_003Dzb4kOgUXOEMEs2KHscVEStxQ_003D != null && _0023_003Dzb4kOgUXOEMEs2KHscVEStxQ_003D.Count >= 30)
		{
			float[][] array = Utility._0023_003DzEgpXpXaWYSvR(_0023_003Dzb4kOgUXOEMEs2KHscVEStxQ_003D, 500000, 3);
			if (_0023_003DzELu0Pss_003D.Workspace != null && _0023_003DzELu0Pss_003D.workspaceInternal.ZoomFitMode == zoomFitType.ConvexHull)
			{
				List<float> list = new List<float>();
				for (int i = 0; i < array.GetLength(0); i++)
				{
					list.AddRange(Utility.ConvexHull(array[i], _0023_003DzxH4ozIo_003D));
				}
				result = Utility.ConvexHull(list, _0023_003DzxH4ozIo_003D);
			}
			else
			{
				List<float> list2 = new List<float>();
				for (int j = 0; j < array.GetLength(0); j++)
				{
					list2.AddRange(Utility.ConvexHull2D(array[j]));
				}
				result = Utility.ConvexHull2D(list2);
			}
		}
		if (_0023_003DzCQIEH09zkxfv3kaXNy_002409eA_003D)
		{
			zoomFitConvexHull = result;
		}
		return result;
	}

	protected virtual void OnKeyChanged(string newKey, [CallerMemberName] string propertyName = null)
	{
		_0023_003Dzs0Yhv2U_003D?.Invoke(this, new KeyChangedEventArgs(propertyName, newKey));
	}

	public string GetKey()
	{
		return Name;
	}

	public void SetKey(string value)
	{
		Name = value;
	}

	internal void CloneBlock(Block _0023_003DzySgeilxprQOK, bool _0023_003DzQmmjROxvNJdJ = true, bool _0023_003Dzu9oxwJ_zKlMt = false)
	{
		Name = _0023_003DzySgeilxprQOK.Name;
		BasePoint = (Point3D)_0023_003DzySgeilxprQOK.BasePoint.Clone();
		_0023_003DzhYfvCOi6649X(new EntityList());
		Units = _0023_003DzySgeilxprQOK.Units;
		MassUnits = _0023_003DzySgeilxprQOK.MassUnits;
		Description = _0023_003DzySgeilxprQOK.Description;
		IsResolved = _0023_003DzySgeilxprQOK.IsResolved;
		_filePath = _0023_003DzySgeilxprQOK.FilePath;
		if (_0023_003DzySgeilxprQOK.CustomData is ICloneable cloneable)
		{
			CustomData = cloneable.Clone();
		}
		else if (_0023_003DzySgeilxprQOK.CustomData is ValueType)
		{
			CustomData = _0023_003DzySgeilxprQOK.CustomData;
		}
		Groups = new List<List<int>>(_0023_003DzySgeilxprQOK.Groups.Count);
		foreach (List<int> group in _0023_003DzySgeilxprQOK.Groups)
		{
			Groups.Add(group.ToList());
		}
		if (_0023_003DzQmmjROxvNJdJ)
		{
			foreach (Entity entity in _0023_003DzySgeilxprQOK.Entities)
			{
				Entity item = (Entity)(_0023_003Dzu9oxwJ_zKlMt ? entity.CloneWithTessellation() : entity.Clone());
				Entities.Add(item);
			}
		}
		_exportMode = _0023_003DzySgeilxprQOK.ExportMode;
		XRefName = _0023_003DzySgeilxprQOK.XRefName;
		BlockSource = _0023_003DzySgeilxprQOK.BlockSource;
	}

	public virtual object Clone()
	{
		return new Block(this);
	}

	public virtual object CloneWithTessellation()
	{
		return new Block(this, keepTessellation: true);
	}

	public Block GetShallowCopy()
	{
		Block block = (Block)MemberwiseClone();
		block._entList = new EntityList();
		block._entList._0023_003DzLG09JoU_003D(block);
		block.Entities.baseList.AddRange(Entities);
		return block;
	}

	public virtual void Dispose()
	{
		_entList.FreeGraphicsResources();
		regenerated = false;
		referencesToMe.Clear();
		zoomFitConvexHull = null;
	}

	internal void _0023_003DzhYfvCOi6649X(EntityList _0023_003DzPzO_0024GUk_003D)
	{
		_entList?._0023_003DzLG09JoU_003D(null);
		_entList = _0023_003DzPzO_0024GUk_003D;
		_entList?._0023_003DzLG09JoU_003D(this);
	}

	internal static bool IsLeaf(IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		return _0023_003Dzv7xH9gk_003D.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzgskp9ngVa4wS86wYgSF5g0o_003D) == 0;
	}

	internal bool IsLeaf()
	{
		return IsLeaf(Entities);
	}

	internal void _0023_003DzcX3lwu4d7umF(RegenParams _0023_003DzELu0Pss_003D)
	{
		regenerated = true;
		List<Entity> list = new List<Entity>(Entities.Count);
		for (int i = 0; i < _entList.Count; i++)
		{
			Entity entity = _entList[i];
			bool flag = entity is BlockReference;
			if (entity.RegenMode == regenType.RegenAndCompile || flag)
			{
				if (_0023_003DzELu0Pss_003D.SkipTexts && (entity is Text || entity is Table))
				{
					continue;
				}
				entity.Regen(_0023_003DzELu0Pss_003D);
				if (flag)
				{
					if (((BlockReference)entity).updatedDuringLastRegen)
					{
						list.Add(entity);
					}
				}
				else
				{
					list.Add(entity);
				}
			}
			else if (entity.RegenMode == regenType.CompileOnly)
			{
				list.Add(entity);
			}
		}
		if (changedBasePoint)
		{
			foreach (BlockReference item in referencesToMe)
			{
				item.transformedEntityBoxes.Clear();
				item.isBlockDirty = true;
			}
			changedBasePoint = false;
		}
		else
		{
			_0023_003DzfRP9c1V6cvLS(list);
		}
	}

	internal void _0023_003DzfRP9c1V6cvLS(IList<Entity> _0023_003Dzw7zC_0024NZ3ewct)
	{
		if (_0023_003Dzw7zC_0024NZ3ewct.Count == 0)
		{
			return;
		}
		foreach (BlockReference item in referencesToMe)
		{
			foreach (Entity item2 in _0023_003Dzw7zC_0024NZ3ewct)
			{
				item.transformedEntityBoxes.Remove(item2);
			}
			item.isBlockDirty = true;
		}
	}

	internal void _0023_003DzMRs_0024OEWhjDS6(string _0023_003DznkMU43c_003D, HashSet<string> _0023_003Dz4XghYRm_00245p6Y, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		if (!_0023_003Dz4XghYRm_00245p6Y.Add(_0023_003DznkMU43c_003D))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951777) + _0023_003DznkMU43c_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302936860));
		}
		foreach (Entity entity in Entities)
		{
			if (entity is BlockReference blockReference)
			{
				_0023_003DzJO1FWlQ_003D[blockReference.BlockName]._0023_003DzMRs_0024OEWhjDS6(blockReference.BlockName, _0023_003Dz4XghYRm_00245p6Y, _0023_003DzJO1FWlQ_003D);
			}
		}
		_0023_003Dz4XghYRm_00245p6Y.Remove(_0023_003DznkMU43c_003D);
	}

	public void Compile(CompileParams data)
	{
		linearUnitsType units = data.Units;
		data.Units = Units;
		foreach (Entity ent in _entList)
		{
			if (ent.RegenMode != regenType.NotNeeded)
			{
				ent.Compile(data);
				ent.RegenMode = regenType.NotNeeded;
			}
		}
		data.Units = units;
	}

	public int GroupSelection()
	{
		int num = _groups.Count;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		for (int i = 0; i < Entities.Count; i++)
		{
			Entity entity = Entities[i];
			if (entity.Selected)
			{
				list.Add(i);
				if (entity.GroupIndex != -1 && !list2.Contains(entity.GroupIndex))
				{
					list2.Add(entity.GroupIndex);
				}
			}
		}
		int num2;
		for (num2 = list2.Count - 1; num2 >= 0; num2--)
		{
			_0023_003DziQBE_qw_003D(list2[num2]);
			num--;
			num2--;
		}
		foreach (int item in list)
		{
			Entities[item].GroupIndex = num;
		}
		_groups.Add(list);
		return num;
	}

	public void Ungroup(int groupIndex)
	{
		foreach (int item in _groups[groupIndex])
		{
			Entities[item].GroupIndex = -1;
		}
		_0023_003DziQBE_qw_003D(groupIndex);
	}

	private void _0023_003DziQBE_qw_003D(int _0023_003DzbVwXNTo_003D)
	{
		for (int i = 0; i < _groups.Count; i++)
		{
			if (i == _0023_003DzbVwXNTo_003D)
			{
				continue;
			}
			foreach (int item in _groups[i])
			{
				if (Entities[item].GroupIndex > _0023_003DzbVwXNTo_003D)
				{
					Entities[item].GroupIndex--;
				}
			}
		}
		_groups.RemoveAt(_0023_003DzbVwXNTo_003D);
	}

	internal void _0023_003DzKoGQhbVaqLRx(int _0023_003Dz7xzxLVk_003D)
	{
		int groupIndex = Entities[_0023_003Dz7xzxLVk_003D].GroupIndex;
		if (groupIndex != -1)
		{
			if (groupIndex >= _groups.Count)
			{
				string[] obj = new string[5]
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951717),
					null,
					null,
					null,
					null
				};
				int num = _0023_003Dz7xzxLVk_003D;
				obj[1] = num.ToString();
				obj[2] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951684);
				obj[3] = groupIndex.ToString();
				obj[4] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951935);
				throw new EyeshotException(string.Concat(obj));
			}
			_groups[groupIndex].Remove(_0023_003Dz7xzxLVk_003D);
			if (_groups[groupIndex].Count == 0)
			{
				_0023_003DziQBE_qw_003D(groupIndex);
			}
		}
		_0023_003Dzs81As7NRhdUK(_0023_003Dz7xzxLVk_003D, -1);
	}

	internal void _0023_003Dzs81As7NRhdUK(int _0023_003DzyzK8swU_003D, int _0023_003Dzryar1ZU_003D)
	{
		for (int i = 0; i < _groups.Count; i++)
		{
			for (int j = 0; j < _groups[i].Count; j++)
			{
				if (_groups[i][j] >= _0023_003DzyzK8swU_003D)
				{
					_groups[i][j] += _0023_003Dzryar1ZU_003D;
				}
			}
		}
	}

	public virtual BlockSurrogate ConvertToSurrogate()
	{
		return new BlockSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), _name);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951314), _entList);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300), _basePoint);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951311), _units);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951035), _massUnits);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019), _description);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951005), FilePath);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950990), _exportMode);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950976), XRefName);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950960), BlockSource);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951899), Name, _units);
	}

	public bool Equals(Block other)
	{
		return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
	}

	internal void _0023_003Dz3z8yNhyUFswq(string _0023_003DzS_00246o7tc_003D, int _0023_003DzaRahxbnG4nPS, IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		int count = _entList.Count;
		List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[]> list = new List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[]>(count);
		List<bool> list2 = new List<bool>(count);
		List<bool> list3 = new List<bool>(count);
		for (int i = 0; i < count; i++)
		{
			Entity entity = _entList[i];
			if (!(entity is BlockReference blockReference) || _0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities.Count != 0)
			{
				list.Add(entity._0023_003DzuAMveDQA6vvk());
				list2.Add(entity is Mesh);
				list3.Add(entity is Solid);
			}
		}
		_0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf obj = new _0023_003Dz18IEgzJEVJEAtpayNrr9Mj_0024u2aTOeu3UMujTh86IKJMf(_0023_003DzS_00246o7tc_003D, _0023_003DzaRahxbnG4nPS, list.ToArray(), list2.ToArray(), list3.ToArray(), Layer.DefaultLayerName);
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, _0023_003DzeWJg3NJnk3WA[0].Name);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal void _0023_003Dzp6_0024ma46EnjuJk7zPtQ_003D_003D(List<Mate> _0023_003DzPzO_0024GUk_003D)
	{
		MatesList = _0023_003DzPzO_0024GUk_003D;
	}

	private T _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D<T>(T _0023_003Dz48C9g9BkbHSw) where T : Mate
	{
		if (_0023_003Dz48C9g9BkbHSw == null)
		{
			return null;
		}
		AddMate(_0023_003Dz48C9g9BkbHSw);
		return _0023_003Dz48C9g9BkbHSw;
	}

	public AngleMate AddAngleMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, double angle = 0.0, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreateAngleMate(obj1, parents1, obj2, parents2, angle, flip));
	}

	public CoincidentMate AddCoincidentMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreateCoincidentMate(obj1, parents1, obj2, parents2, flip));
	}

	public ConcentricMate AddConcentricMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreateConcentricMate(obj1, parents1, obj2, parents2, flip));
	}

	public DistanceMate AddDistanceMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, double distance = 0.0, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreateDistanceMate(obj1, parents1, obj2, parents2, distance, flip));
	}

	public ParallelMate AddParallelMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreateParallelMate(obj1, parents1, obj2, parents2, flip));
	}

	public PerpendicularMate AddPerpendicularMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreatePerpendicularMate(obj1, parents1, obj2, parents2, flip));
	}

	public TangentMate AddTangentMate(IMateable obj1, Stack<BlockReference> parents1, IMateable obj2, Stack<BlockReference> parents2, bool flip = false)
	{
		return _0023_003Dz0o4uXR7gmMLLVzxidw_003D_003D(Mate.CreateTangentMate(obj1, parents1, obj2, parents2, flip));
	}

	public bool AddMate(Mate mate, bool autoSolve = true, bool autoFlip = true)
	{
		if (matesGraph == null)
		{
			matesGraph = new _0023_003Dz8MfiwJHarI9u66omqzWP6QqoL2rzmT2nhA_003D_003D(MatesList);
		}
		matesGraph._0023_003DzPJNpNF4_003D(mate);
		_0023_003Dz6c_0024_00245z_0024xwc30();
		if (!autoSolve)
		{
			return true;
		}
		BlockReference _0023_003DzAFLumEs_003D = null;
		if (!mate.Component1.IsFixed)
		{
			_0023_003DzAFLumEs_003D = mate.Component1;
		}
		else if (!mate.Component2.IsFixed)
		{
			_0023_003DzAFLumEs_003D = mate.Component2;
		}
		if (_0023_003DzGZrCMzl_0024iuSu(_0023_003DzAFLumEs_003D) == solveFailureType.Success)
		{
			return true;
		}
		if (!autoFlip)
		{
			return false;
		}
		mate.Flip();
		if (_0023_003DzGZrCMzl_0024iuSu(_0023_003DzAFLumEs_003D) == solveFailureType.Success)
		{
			return true;
		}
		RemoveMate(mate);
		return false;
	}

	private void _0023_003Dz6c_0024_00245z_0024xwc30()
	{
		List<BlockReference> list = new List<BlockReference>();
		_oldParams = new Dictionary<BlockReference, double[]>();
		foreach (Mate mates in MatesList)
		{
			if (!list.Contains(mates._0023_003DzgM8TwmWg2tsG.Component) && !mates._0023_003DzgM8TwmWg2tsG.Component.IsFixed)
			{
				_oldParams.Add(mates._0023_003DzgM8TwmWg2tsG.Component, mates._0023_003DzgM8TwmWg2tsG.Component._0023_003DzCvxG2A3KpWd8()._0023_003Dz1MjudJU_003D());
				list.Add(mates._0023_003DzgM8TwmWg2tsG.Component);
			}
			if (!list.Contains(mates._0023_003DzdH0ws20LmJv0.Component) && !mates._0023_003DzdH0ws20LmJv0.Component.IsFixed)
			{
				_oldParams.Add(mates._0023_003DzdH0ws20LmJv0.Component, mates._0023_003DzdH0ws20LmJv0.Component._0023_003DzCvxG2A3KpWd8()._0023_003Dz1MjudJU_003D());
				list.Add(mates._0023_003DzdH0ws20LmJv0.Component);
			}
		}
	}

	public void UndoAddMate(Mate m)
	{
		List<BlockReference> list = new List<BlockReference>();
		foreach (Mate mates in MatesList)
		{
			if (!list.Contains(mates._0023_003DzgM8TwmWg2tsG.Component) && !mates._0023_003DzgM8TwmWg2tsG.Component.IsFixed)
			{
				mates._0023_003DzgM8TwmWg2tsG.Component._0023_003DzCvxG2A3KpWd8()._0023_003DzScPZa9I_003D(_oldParams[mates._0023_003DzgM8TwmWg2tsG.Component]);
				list.Add(mates._0023_003DzgM8TwmWg2tsG.Component);
			}
			if (!list.Contains(mates._0023_003DzdH0ws20LmJv0.Component) && !mates._0023_003DzdH0ws20LmJv0.Component.IsFixed)
			{
				mates._0023_003DzdH0ws20LmJv0.Component._0023_003DzCvxG2A3KpWd8()._0023_003DzScPZa9I_003D(_oldParams[mates._0023_003DzdH0ws20LmJv0.Component]);
				list.Add(mates._0023_003DzdH0ws20LmJv0.Component);
			}
		}
		_0023_003DzmBJ_VLs_003D(list);
		RemoveMate(m);
	}

	public void RemoveMate(Mate m)
	{
		if (!MatesList.Contains(m))
		{
			return;
		}
		matesGraph._0023_003DzddnMkwj8wXg_0024.Remove(m);
		foreach (LinkedList<Mate> value in matesGraph._0023_003DzhVzS_5o_003D.Values)
		{
			foreach (Mate item in value)
			{
				if (item == m)
				{
					value.Remove(item);
					break;
				}
			}
		}
		_0023_003DzGZrCMzl_0024iuSu(null);
	}

	public void RemoveAllMates(BlockReference blockReference)
	{
		if (matesGraph == null || !matesGraph._0023_003DzhVzS_5o_003D.ContainsKey(blockReference))
		{
			return;
		}
		List<Mate> list = new List<Mate>();
		foreach (Mate item in matesGraph._0023_003DzhVzS_5o_003D[blockReference])
		{
			list.Add(item);
		}
		foreach (Mate item2 in list)
		{
			RemoveMate(item2);
		}
	}

	public solveFailureType Solve(BlockReference startFrom = null)
	{
		return _0023_003DzGZrCMzl_0024iuSu(startFrom);
	}

	private solveFailureType _0023_003DzGZrCMzl_0024iuSu(BlockReference _0023_003DzAFLumEs_003D)
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		List<BlockReference> list = new List<BlockReference>();
		if (_0023_003DzAFLumEs_003D != null)
		{
			list.Add(_0023_003DzAFLumEs_003D);
			_0023_003DzAFLumEs_003D._0023_003DzCvxG2A3KpWd8()._0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, dragType.Free);
			if (matesGraph != null)
			{
				matesGraph._0023_003Dz3ZWMVJs_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, list, new List<Mate>(), _0023_003DzAFLumEs_003D);
			}
		}
		else
		{
			foreach (Mate mates in MatesList)
			{
				_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003Dz2m2938oFK1gG(mates);
				if (!list.Contains(mates._0023_003DzgM8TwmWg2tsG.Component) && !mates._0023_003DzgM8TwmWg2tsG.Component.IsFixed)
				{
					mates._0023_003DzgM8TwmWg2tsG.Component._0023_003DzCvxG2A3KpWd8()._0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, dragType.Free);
					list.Add(mates._0023_003DzgM8TwmWg2tsG.Component);
				}
				if (!list.Contains(mates._0023_003DzdH0ws20LmJv0.Component) && !mates._0023_003DzdH0ws20LmJv0.Component.IsFixed)
				{
					mates._0023_003DzdH0ws20LmJv0.Component._0023_003DzCvxG2A3KpWd8()._0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, dragType.Free);
					list.Add(mates._0023_003DzdH0ws20LmJv0.Component);
				}
			}
		}
		solveFailureType num = _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzbZBxE_0024c_003D(out _dof);
		if (num == solveFailureType.Success)
		{
			_0023_003DzmBJ_VLs_003D(list);
		}
		return num;
	}

	public solveFailureType SolveWithDrag(BlockReference dragged, Transformation currentTransformation, Point3D moveFrom, Point3D moveTo, dragType dragMode)
	{
		return _0023_003Dz_0024jHJbIr0rQCo(dragged, currentTransformation, moveFrom, moveTo, dragMode);
	}

	private solveFailureType _0023_003Dz_0024jHJbIr0rQCo(BlockReference _0023_003Dz204Nty0_003D, Transformation _0023_003DzVbm_57f1ucsE, Point3D _0023_003Dz5VRXGbg_003D, Point3D _0023_003Dz_PR4lSU_003D, dragType _0023_003Dzid4WWdal_0024vIJ)
	{
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2 = new _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D();
		List<BlockReference> _0023_003Dz_0024GW7xop_0024SPQ = new List<BlockReference> { _0023_003Dz204Nty0_003D };
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003Dz_PR4lSU_003D = _0023_003Dz_PR4lSU_003D;
		if (_0023_003Dz204Nty0_003D.IsFixed)
		{
			_dof = 0;
			return solveFailureType.Success;
		}
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003Dz96CX9U88jjMLoO6qZQ_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzX6bq7sSjCTnm = _0023_003DzPA1Qkq2QzdWh(_0023_003Dz204Nty0_003D, _0023_003Dz5VRXGbg_003D, _0023_003Dz_PR4lSU_003D, _0023_003DzVbm_57f1ucsE));
		foreach (Exp item in _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D)
		{
			Dictionary<Param, Exp> dictionary = new Dictionary<Param, Exp>();
			foreach (Param item2 in _0023_003Dz204Nty0_003D._0023_003DzCvxG2A3KpWd8()._0023_003DzGVWngirLnmOL())
			{
				dictionary.Add(item2, item._0023_003DzSOlfnhbkZ12J(item2));
			}
			_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzJuq1mFv6piLHNkjQLvMDlps_003D.Add(dictionary);
		}
		_0023_003Dz204Nty0_003D._0023_003DzCvxG2A3KpWd8()._0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, _0023_003Dzid4WWdal_0024vIJ);
		if (matesGraph != null)
		{
			matesGraph._0023_003Dz3ZWMVJs_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2, _0023_003Dz_0024GW7xop_0024SPQ, new List<Mate>(), _0023_003Dz204Nty0_003D);
		}
		solveFailureType num = _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzOykoXtw_003D();
		_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D2._0023_003DzbZBxE_0024c_003D(out _dof);
		if (num == solveFailureType.Success)
		{
			_0023_003DzmBJ_VLs_003D(_0023_003Dz_0024GW7xop_0024SPQ);
		}
		return num;
	}

	private ExpVector _0023_003DzPA1Qkq2QzdWh(BlockReference _0023_003Dzx9N4caMG0JLn, Point3D _0023_003Dz5VRXGbg_003D, Point3D _0023_003Dz_PR4lSU_003D, Transformation _0023_003DzVbm_57f1ucsE)
	{
		Point3D point3D = (Point3D)_0023_003Dz5VRXGbg_003D.Clone();
		Point3D point3D2 = (Point3D)_0023_003Dz_PR4lSU_003D.Clone();
		if (_0023_003DzVbm_57f1ucsE != null)
		{
			Transformation transformation = (Transformation)_0023_003DzVbm_57f1ucsE.Clone();
			transformation.Invert();
			point3D.TransformBy(transformation);
			point3D2.TransformBy(transformation);
		}
		Transformation transformation2 = (Transformation)_0023_003Dzx9N4caMG0JLn.Transformation.Clone();
		transformation2.Invert();
		Point3D point3D3 = (Point3D)point3D.Clone();
		point3D3.TransformBy(transformation2);
		_0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK obj = _0023_003Dzx9N4caMG0JLn._0023_003DzCvxG2A3KpWd8();
		obj._0023_003DzzHn3Uem7bIUU(_0023_003DzkzYmS5k_003D: true);
		ExpVector expVector = obj._0023_003DzK48Px00_003D(point3D3);
		double _0023_003DzM_0024o1stE_003D = obj._0023_003DzM_0024o1stE_003D;
		return new ExpVector(expVector.x._0023_003Dz7cZ02rs_003D(point3D2.X * _0023_003DzM_0024o1stE_003D), expVector.y._0023_003Dz7cZ02rs_003D(point3D2.Y * _0023_003DzM_0024o1stE_003D), expVector.z._0023_003Dz7cZ02rs_003D(point3D2.Z * _0023_003DzM_0024o1stE_003D));
	}

	private void _0023_003DzmBJ_VLs_003D(List<BlockReference> _0023_003Dz_0024GW7xop_0024SPQ6)
	{
		foreach (BlockReference item in _0023_003Dz_0024GW7xop_0024SPQ6)
		{
			if (!item.IsFixed)
			{
				item.Transformation = item._0023_003DzCvxG2A3KpWd8()._0023_003DzUavZtU6xebao();
			}
		}
		Entities.Regen();
	}
}
