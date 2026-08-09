using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Materials;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public class ChannelBuilder
{
	private sealed class _ContentComparer : IEqualityComparer<ChannelBuilder>
	{
		public static readonly _ContentComparer Default = new _ContentComparer();

		public bool Equals(ChannelBuilder x, ChannelBuilder y)
		{
			return AreEqualByContent(x, y);
		}

		public int GetHashCode(ChannelBuilder obj)
		{
			return GetContentHashCode(obj);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly MaterialBuilder _Parent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly KnownChannel _Key;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly MaterialValue.Collection _Parameters;

	public TextureBuilder Texture { get; private set; }

	public KnownChannel Key => _Key;

	[Obsolete("Use .Parameters[KnownProperty] or .Parameters.CombinedVector")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 Parameter
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _Parameters.CombinedVector;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			_Parameters.CombinedVector = value;
		}
	}

	public MaterialValue.Collection Parameters => _Parameters;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static IEqualityComparer<ChannelBuilder> ContentComparer => _ContentComparer.Default;

	private string _GetDebuggerDisplay()
	{
		string text = Key.ToString();
		TextureBuilder validTexture = GetValidTexture();
		if (validTexture?.PrimaryImage != null)
		{
			text = text + " " + validTexture.PrimaryImage.Content.ToDebuggerDisplay();
		}
		return text;
	}

	internal ChannelBuilder(MaterialBuilder parent, KnownChannel key)
	{
		SharpGLTF.Guard.NotNull(parent, "parent");
		_Parent = parent;
		_Key = key;
		_Parameters = MaterialValue.CreateDefaultProperties(key);
	}

	public static bool AreEqualByContent(ChannelBuilder x, ChannelBuilder y)
	{
		if ((x: x, y: y).AreSameReference(out var result))
		{
			return result;
		}
		if (x._Key != y._Key)
		{
			return false;
		}
		if (!MaterialValue.Collection.AreEqual(x._Parameters, y._Parameters))
		{
			return false;
		}
		if (!TextureBuilder.AreEqualByContent(x.Texture, y.Texture))
		{
			return false;
		}
		return true;
	}

	public static int GetContentHashCode(ChannelBuilder x)
	{
		if (x == null)
		{
			return 0;
		}
		int hashCode = x._Key.GetHashCode();
		hashCode ^= x._Parameters.GetHashCode();
		return hashCode ^ TextureBuilder.GetContentHashCode(x.Texture);
	}

	public TextureBuilder GetValidTexture()
	{
		if (Texture == null)
		{
			return null;
		}
		if (Texture.PrimaryImage == null)
		{
			return null;
		}
		return Texture;
	}

	public TextureBuilder UseTexture()
	{
		if (Texture == null)
		{
			Texture = new TextureBuilder(this);
		}
		return Texture;
	}

	public void RemoveTexture()
	{
		Texture = null;
	}

	internal void CopyTo(ChannelBuilder other)
	{
		_Parameters.CopyTo(other._Parameters);
		if (Texture == null)
		{
			RemoveTexture();
		}
		else
		{
			Texture.CopyTo(other.UseTexture());
		}
	}
}
