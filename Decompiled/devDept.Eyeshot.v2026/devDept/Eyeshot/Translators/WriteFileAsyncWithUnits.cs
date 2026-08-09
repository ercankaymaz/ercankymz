using System;
using System.Collections.Generic;
using System.IO;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public abstract class WriteFileAsyncWithUnits : WriteFileAsync
{
	protected linearUnitsType units;

	protected string author = string.Empty;

	protected string organization = string.Empty;

	protected string originatingSystem = string.Empty;

	protected float lineTypeScale = 1f;

	protected WriteFileAsyncWithUnits(string filePath, bool selectedOnly = false)
		: base(filePath, selectedOnly)
	{
	}

	protected WriteFileAsyncWithUnits(Document document, string filePath, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly), filePath)
	{
	}

	protected WriteFileAsyncWithUnits(Document document, Stream stream, bool selectedOnly = false)
		: this(new WriteParamsWithUnits(document, selectedOnly), stream)
	{
	}

	protected WriteFileAsyncWithUnits(WriteParamsWithUnits writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzVnfAoovaoMa7(writeParams);
	}

	protected WriteFileAsyncWithUnits(WriteParamsWithUnits writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzVnfAoovaoMa7(writeParams);
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	protected WriteFileAsyncWithUnits(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, linearUnitsType units)
		: base(entList, layerList, blockDict, filePath)
	{
		this.units = units;
	}

	[Obsolete("Use the constructor that accepts the WriteParams instead.")]
	protected WriteFileAsyncWithUnits(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, linearUnitsType units)
		: base(entList, layerList, blockDict, stream)
	{
		this.units = units;
	}

	private void _0023_003DzVnfAoovaoMa7(WriteParamsWithUnits _0023_003DzJ0JR0a10yEZc)
	{
		if (_0023_003DzJ0JR0a10yEZc != null)
		{
			author = _0023_003DzJ0JR0a10yEZc.Author;
			organization = _0023_003DzJ0JR0a10yEZc.Organization;
			originatingSystem = _0023_003DzJ0JR0a10yEZc.OriginatingSystem;
			units = _0023_003DzJ0JR0a10yEZc.Units;
		}
	}
}
