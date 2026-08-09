using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
public class BlockReferenceEx : BlockReference
{
	public List<KeyValuePair<string, object>> CustomProperties { get; internal set; }

	internal BlockReferenceEx(string blockName)
		: base(blockName)
	{
	}

	internal BlockReferenceEx(Transformation t, string blockName)
		: base(t, blockName)
	{
	}

	internal BlockReferenceEx(double x, double y, double z, string blockName, double sx, double sy, double sz, double rotationAngleInRadians)
		: base(x, y, z, blockName, sx, sy, sz, rotationAngleInRadians)
	{
	}

	protected BlockReferenceEx(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	protected BlockReferenceEx(BlockReferenceEx another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		if (another.CustomProperties == null)
		{
			return;
		}
		CustomProperties = new List<KeyValuePair<string, object>>(another.CustomProperties.Count);
		foreach (KeyValuePair<string, object> customProperty in another.CustomProperties)
		{
			object value = customProperty.Value;
			if (customProperty.Value is ICloneable cloneable)
			{
				value = cloneable.Clone();
			}
			CustomProperties.Add(new KeyValuePair<string, object>(customProperty.Key, value));
		}
	}

	public override object Clone()
	{
		return new BlockReferenceEx(this);
	}

	public override object CloneWithTessellation()
	{
		return new BlockReferenceEx(this, RegenMode != regenType.RegenAndCompile);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new BlockReferenceExSurrogate(this);
	}
}
