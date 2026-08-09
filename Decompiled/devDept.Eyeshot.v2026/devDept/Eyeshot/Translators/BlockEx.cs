using System;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
[Obsolete("Deprecated in favor of Block.")]
internal sealed class BlockEx : Block, IReadWriteDataEx, IDataEx, IWriteDataEx, IKeyedCollectionDisposableItem<BlockEx>, IKeyedCollectionItem<BlockEx>, INotifyKeyChanged, ICloneable, IEquatable<BlockEx>, IDisposable
{
	internal BlockEx(string _0023_003DzS_00246o7tc_003D, Point3D _0023_003Dz7uOrsVV7yn6Y)
		: base(_0023_003DzS_00246o7tc_003D, _0023_003Dz7uOrsVV7yn6Y)
	{
	}

	public BlockEx(string _0023_003DzS_00246o7tc_003D)
		: base(_0023_003DzS_00246o7tc_003D)
	{
	}

	public BlockEx(BlockEx _0023_003DzySgeilxprQOK)
		: base((BlockSurrogate)_0023_003DzySgeilxprQOK)
	{
	}

	protected BlockEx(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
		: base(_0023_003Dz9lrNnXY_003D, _0023_003DzB8iS0QA_003D)
	{
	}

	public bool Equals(BlockEx _0023_003Dzl_0024MIsC0_003D)
	{
		return Equals((Block)_0023_003Dzl_0024MIsC0_003D);
	}

	public override object Clone()
	{
		return new BlockEx(this);
	}

	public override BlockSurrogate ConvertToSurrogate()
	{
		return new BlockExSurrogate(this);
	}
}
