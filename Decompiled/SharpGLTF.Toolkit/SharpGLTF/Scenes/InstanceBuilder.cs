using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Nodes;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("{Content}")]
public sealed class InstanceBuilder
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SceneBuilder _Parent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ContentTransformer _ContentTransformer;

	public string Name => _ContentTransformer?.Name;

	public JsonNode Extras => _ContentTransformer?.Extras;

	public ContentTransformer Content
	{
		get
		{
			return _ContentTransformer;
		}
		set
		{
			_ContentTransformer = value;
		}
	}

	public IEnumerable<MaterialBuilder> Materials
	{
		get
		{
			IMeshBuilder<MaterialBuilder> geometryAsset = Content.GetGeometryAsset();
			if (geometryAsset == null)
			{
				return Enumerable.Empty<MaterialBuilder>();
			}
			return geometryAsset.Materials;
		}
	}

	internal InstanceBuilder(SceneBuilder parent)
	{
		_Parent = parent;
	}

	public InstanceBuilder WithName(string name)
	{
		if (Content != null)
		{
			Content.Name = name;
		}
		return this;
	}

	public InstanceBuilder WithExtras(JsonNode extras)
	{
		if (Content != null)
		{
			Content.Extras = extras;
		}
		return this;
	}

	public void Remove()
	{
		if (_Parent != null)
		{
			_Parent._Instances.Remove(this);
			_Parent = null;
		}
	}

	internal InstanceBuilder _CopyTo(SceneBuilder other, ContentTransformer.DeepCloneContext args)
	{
		InstanceBuilder instanceBuilder = new InstanceBuilder(other);
		instanceBuilder._ContentTransformer = _ContentTransformer?.DeepClone(args);
		return instanceBuilder;
	}
}
