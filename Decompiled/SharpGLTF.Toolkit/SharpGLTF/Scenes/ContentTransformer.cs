using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Animations;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;

namespace SharpGLTF.Scenes;

public abstract class ContentTransformer
{
	public readonly struct DeepCloneContext
	{
		private readonly IReadOnlyDictionary<NodeBuilder, NodeBuilder> _NodeMap;

		internal DeepCloneContext(IReadOnlyDictionary<NodeBuilder, NodeBuilder> nmap)
		{
			_NodeMap = nmap;
		}

		public NodeBuilder GetNode(NodeBuilder node)
		{
			if (node == null)
			{
				return null;
			}
			if (_NodeMap == null)
			{
				return node;
			}
			if (!_NodeMap.TryGetValue(node, out var value))
			{
				return node;
			}
			return value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _Content;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AnimatableProperty<ArraySegment<float>> _Morphings;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _DebugName
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(Name))
			{
				return Name;
			}
			return "*";
		}
	}

	public abstract string Name { get; set; }

	public abstract JsonNode Extras { get; set; }

	internal object Content => _Content;

	public AnimatableProperty<ArraySegment<float>> Morphings => _Morphings;

	public bool HasRenderableContent => _Content is IRenderableContent;

	protected ContentTransformer(object content)
	{
		SharpGLTF.Guard.NotNull(content, "content");
		if (content is IMeshBuilder<MaterialBuilder> mesh)
		{
			content = new MeshContent(mesh);
		}
		_Content = content;
	}

	public abstract ContentTransformer DeepClone(DeepCloneContext args);

	protected ContentTransformer(ContentTransformer other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		_Content = ((other._Content is ICloneable cloneable) ? cloneable.Clone() : other._Content);
		_Morphings = other._Morphings?.Clone();
	}

	public IMeshBuilder<MaterialBuilder> GetGeometryAsset()
	{
		return (_Content as IRenderableContent)?.GetGeometryAsset();
	}

	public CameraBuilder GetCameraAsset()
	{
		return (_Content as CameraContent)?.Camera;
	}

	public LightBuilder GetLightAsset()
	{
		return (_Content as LightContent)?.Light;
	}

	public abstract NodeBuilder GetArmatureRoot();

	public AnimatableProperty<ArraySegment<float>> UseMorphing()
	{
		if (this is FixedTransformer)
		{
			throw new InvalidOperationException("Internal FixedTransformer does not support animations. Use AddRigidMesh(MeshBuilder mesh, NodeBuilder node) to add an animatable instance");
		}
		if (_Morphings == null)
		{
			_Morphings = new AnimatableProperty<ArraySegment<float>>();
			_Morphings.Value = default(ArraySegment<float>);
		}
		return _Morphings;
	}

	public CurveBuilder<ArraySegment<float>> UseMorphing(string animationTrack)
	{
		AnimatableProperty<ArraySegment<float>> animatableProperty = UseMorphing();
		if (animatableProperty.Value.Count == 0)
		{
			throw new InvalidOperationException("A default sequence of weights must be set before setting animated weights. Use UseMorphing().SetValue(...)");
		}
		return animatableProperty.UseTrackBuilder(animationTrack);
	}

	public abstract Matrix4x4 GetPoseWorldMatrix();

	internal IEnumerable<string> GetAnimationTracksNames()
	{
		IEnumerable<string> enumerable = NodeBuilder.Flatten(GetArmatureRoot()).SelectMany((NodeBuilder item) => item.AnimationTracksNames);
		if (_Morphings != null)
		{
			enumerable = enumerable.Concat(_Morphings.Tracks.Keys);
		}
		return enumerable.Distinct();
	}
}
