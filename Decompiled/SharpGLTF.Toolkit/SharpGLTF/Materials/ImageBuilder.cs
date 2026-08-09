using System;
using System.Diagnostics;
using System.Text.Json.Nodes;
using SharpGLTF.Memory;

namespace SharpGLTF.Materials;

[DebuggerDisplay("{_DebuggerDisplay(),nq}")]
public sealed class ImageBuilder : BaseBuilder
{
	public MemoryImage Content { get; set; }

	public string AlternateWriteFileName { get; set; }

	internal string _DebuggerDisplay()
	{
		string text = "Image ";
		if (!string.IsNullOrWhiteSpace(base.Name))
		{
			text = text + base.Name + " ";
		}
		return text + Content.ToDebuggerDisplay();
	}

	public static implicit operator ImageBuilder(ArraySegment<byte> image)
	{
		return new MemoryImage(image);
	}

	public static implicit operator ImageBuilder(byte[] image)
	{
		return new MemoryImage(image);
	}

	public static implicit operator ImageBuilder(string filePath)
	{
		return new MemoryImage(filePath);
	}

	public static implicit operator ImageBuilder(MemoryImage content)
	{
		return From(content);
	}

	public static ImageBuilder From(MemoryImage content, string name = null)
	{
		if (!content.IsEmpty)
		{
			return new ImageBuilder(content, name, null);
		}
		return null;
	}

	public static ImageBuilder From(MemoryImage content, string name, JsonNode extras)
	{
		if (!content.IsEmpty)
		{
			return new ImageBuilder(content, name, extras);
		}
		return null;
	}

	private ImageBuilder(MemoryImage content, string name, JsonNode extras)
		: base(name, extras)
	{
		Content = content;
	}

	internal ImageBuilder Clone()
	{
		return new ImageBuilder(this);
	}

	private ImageBuilder(ImageBuilder other)
		: base(other)
	{
		Content = other.Content;
	}

	public static bool AreEqualByContent(ImageBuilder x, ImageBuilder y)
	{
		if ((x: x, y: y).AreSameReference(out var result))
		{
			return result;
		}
		if (!BaseBuilder.AreEqualByContent(x, y))
		{
			return false;
		}
		if (!MemoryImage.AreEqual(x.Content, y.Content))
		{
			return false;
		}
		return true;
	}

	public static int GetContentHashCode(ImageBuilder x)
	{
		if (x == null)
		{
			return 0;
		}
		int contentHashCode = BaseBuilder.GetContentHashCode(x);
		return contentHashCode ^ x.Content.GetHashCode();
	}

	public static bool IsEmpty(ImageBuilder ib)
	{
		return ib?.Content.IsEmpty ?? true;
	}

	public static bool IsValid(ImageBuilder ib)
	{
		return ib?.Content.IsValid ?? false;
	}
}
