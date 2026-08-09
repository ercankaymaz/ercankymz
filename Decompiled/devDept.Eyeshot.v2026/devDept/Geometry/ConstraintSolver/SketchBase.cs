using System;
using System.Runtime.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public abstract class SketchBase : ISketchBase, ICloneable, ISerializable
{
	public IdPath ObjectId => _0023_003DzVvJEU5d_0024LdWP(null);

	protected SketchBase()
	{
	}

	protected SketchBase(SketchBase another)
	{
		_0023_003DzxWZ7yqG65a6T(another._0023_003DzDQs07gDx7oDr());
	}

	protected SketchBase(SerializationInfo info, StreamingContext context)
	{
		_0023_003DzxWZ7yqG65a6T((Id)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656756), typeof(Id)));
	}

	internal abstract Id _0023_003DzDQs07gDx7oDr();

	internal abstract void _0023_003DzxWZ7yqG65a6T(Id _0023_003DzPzO_0024GUk_003D);

	internal abstract ISketchBase _0023_003DzCzT7cK4_003D(Id _0023_003DzG5EGDUs_003D);

	internal abstract SketchBase _0023_003DziNzzmPCarBGC();

	internal IdPath _0023_003DzVvJEU5d_0024LdWP(SketchBase _0023_003DzKV5V6WI_003D)
	{
		IdPath idPath = new IdPath();
		for (SketchBase sketchBase = this; sketchBase != null; sketchBase = sketchBase._0023_003DziNzzmPCarBGC())
		{
			if (sketchBase == _0023_003DzKV5V6WI_003D)
			{
				return idPath;
			}
			if (sketchBase._0023_003DzDQs07gDx7oDr() == Id.Null)
			{
				return idPath;
			}
			idPath.path.Insert(0, sketchBase._0023_003DzDQs07gDx7oDr());
		}
		return idPath;
	}

	internal virtual ISketchBase _0023_003DzXKRytQoXWc2o(IdPath _0023_003Dz2QVVx8s_003D, int _0023_003DzyzK8swU_003D)
	{
		if (_0023_003Dz2QVVx8s_003D.path.Count == 0)
		{
			return null;
		}
		ISketchBase sketchBase = _0023_003DzCzT7cK4_003D(_0023_003Dz2QVVx8s_003D.path[_0023_003DzyzK8swU_003D]);
		if (!(sketchBase is SketchBase sketchBase2) || _0023_003DzyzK8swU_003D + 1 >= _0023_003Dz2QVVx8s_003D.path.Count)
		{
			return sketchBase;
		}
		return sketchBase2._0023_003DzXKRytQoXWc2o(_0023_003Dz2QVVx8s_003D, _0023_003DzyzK8swU_003D + 1);
	}

	public abstract object Clone();

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656756), _0023_003DzDQs07gDx7oDr());
	}
}
