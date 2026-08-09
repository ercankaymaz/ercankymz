using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace SharpGLTF.Schema2;

[DebuggerDisplay("Channel {_Key}")]
public readonly struct MaterialChannel : IEquatable<MaterialChannel>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Material _Material;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _Key;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _MaterialTexture _TextureInfo;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private readonly IReadOnlyList<IMaterialParameter> _Parameters;

	public Material LogicalParent => _Material;

	public string Key => _Key;

	public bool HasDefaultContent => _CheckHasDefaultContent();

	[Obsolete("Use Parameters[]")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 Parameter
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _MaterialParameter<float>.Combine(_Parameters);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			_MaterialParameter<float>.Apply(_Parameters, value);
		}
	}

	public IReadOnlyList<IMaterialParameter> Parameters => _Parameters;

	public Texture Texture => _GetTexture();

	public TextureSampler TextureSampler => Texture?.Sampler;

	public int TextureCoordinate => _TextureInfo.TextureCoordinate;

	public TextureTransform TextureTransform => _TextureInfo.TextureTransform;

	public Vector4 Color
	{
		get
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			_MaterialParameter<Vector4> materialParameter = _Parameters.OfType<_MaterialParameter<Vector4>>().SingleOrDefault();
			if (materialParameter.Name == "RGBA")
			{
				return materialParameter.Value;
			}
			_MaterialParameter<Vector3> materialParameter2 = _Parameters.OfType<_MaterialParameter<Vector3>>().SingleOrDefault();
			if (materialParameter2.Name == "RGB")
			{
				return new Vector4(materialParameter2.Value, 1f);
			}
			throw new InvalidOperationException("RGB or RGBA not found.");
		}
		set
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			_MaterialParameter<Vector4> materialParameter = _Parameters.OfType<_MaterialParameter<Vector4>>().SingleOrDefault();
			if (materialParameter.Name == "RGBA")
			{
				materialParameter.Value = value;
				return;
			}
			_MaterialParameter<Vector3> materialParameter2 = _Parameters.OfType<_MaterialParameter<Vector3>>().SingleOrDefault();
			if (materialParameter2.Name == "RGB")
			{
				materialParameter2.Value = new Vector3(value.X, value.Y, value.Z);
				return;
			}
			throw new InvalidOperationException("RGB or RGBA not found.");
		}
	}

	internal MaterialChannel(Material m, string key, _MaterialTexture texInfo, params IMaterialParameter[] parameters)
	{
		Guard.NotNull(m, "m");
		Guard.NotNullOrEmpty(key, "key");
		Guard.NotNull(texInfo, "texInfo");
		Guard.NotNull(parameters, "parameters");
		_Key = key;
		_Material = m;
		_TextureInfo = texInfo;
		_Parameters = parameters;
	}

	public override int GetHashCode()
	{
		if (_Material == null)
		{
			return 0;
		}
		return _Material.GetHashCode() ^ _Extensions.GetHashCode(_Key, StringComparison.InvariantCulture);
	}

	public override bool Equals(object obj)
	{
		if (obj is MaterialChannel other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(MaterialChannel other)
	{
		if (_Material == null && other._Material == null)
		{
			return true;
		}
		if (_Material != other._Material)
		{
			return false;
		}
		if (_Key != other._Key)
		{
			return false;
		}
		return true;
	}

	public static bool operator ==(in MaterialChannel a, in MaterialChannel b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(in MaterialChannel a, in MaterialChannel b)
	{
		return !a.Equals(b);
	}

	public float GetFactor(string key)
	{
		return _Parameters.OfType<_MaterialParameter<float>>().Single((_MaterialParameter<float> item) => item.Name == key).Value;
	}

	public void SetFactor(string key, float value)
	{
		_MaterialParameter<float> materialParameter = _Parameters.OfType<_MaterialParameter<float>>().Single((_MaterialParameter<float> item) => item.Name == key);
		materialParameter.Value = value;
	}

	private Texture _GetTexture()
	{
		TextureInfo info = _TextureInfo.Info;
		if (info == null)
		{
			return null;
		}
		return _Material.LogicalParent.LogicalTextures[info.LogicalTextureIndex];
	}

	public Texture SetTexture(int texCoord, Image primaryImg, Image fallbackImg = null, TextureWrapMode ws = TextureWrapMode.REPEAT, TextureWrapMode wt = TextureWrapMode.REPEAT, TextureMipMapFilter min = TextureMipMapFilter.DEFAULT, TextureInterpolationFilter mag = TextureInterpolationFilter.DEFAULT)
	{
		if (primaryImg == null)
		{
			return null;
		}
		Guard.NotNull(_Material, "_Material");
		if (_TextureInfo.IsEmpty)
		{
			throw new InvalidOperationException();
		}
		TextureSampler sampler = _Material.LogicalParent.UseTextureSampler(ws, wt, min, mag);
		Texture texture = _Material.LogicalParent.UseTexture(primaryImg, fallbackImg, sampler);
		SetTexture(texCoord, texture);
		return texture;
	}

	public void SetTexture(int texSet, Texture tex)
	{
		Guard.NotNull(tex, "tex");
		Guard.MustShareLogicalParent(_Material, tex, "tex");
		if (_TextureInfo.IsEmpty)
		{
			throw new InvalidOperationException();
		}
		TextureInfo textureInfo = _TextureInfo.Use();
		textureInfo.TextureCoordinate = texSet;
		textureInfo.LogicalTextureIndex = tex.LogicalIndex;
	}

	public void SetTransform(Vector2 offset, Vector2 scale, float rotation = 0f, int? texCoordOverride = null)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (_TextureInfo.IsEmpty)
		{
			throw new InvalidOperationException();
		}
		TextureInfo textureInfo = _TextureInfo.Use();
		textureInfo.SetTransform(offset, scale, rotation, texCoordOverride);
	}

	private bool _CheckHasDefaultContent()
	{
		if (Texture != null)
		{
			return false;
		}
		if (!_Parameters.All((IMaterialParameter item) => item.IsDefault))
		{
			return false;
		}
		return true;
	}
}
