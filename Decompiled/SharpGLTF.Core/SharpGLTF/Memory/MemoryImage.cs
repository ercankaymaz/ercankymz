using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SharpGLTF.Memory;

[DebuggerDisplay("{ToDebuggerDisplay(),nq}")]
public readonly struct MemoryImage : IEquatable<MemoryImage>
{
	private const string EMBEDDED_OCTET_STREAM = "data:application/octet-stream";

	private const string EMBEDDED_GLTF_BUFFER = "data:application/gltf-buffer";

	private const string EMBEDDED_JPEG_BUFFER = "data:image/jpeg";

	private const string EMBEDDED_PNG_BUFFER = "data:image/png";

	private const string EMBEDDED_DDS_BUFFER = "data:image/vnd-ms.dds";

	private const string EMBEDDED_WEBP_BUFFER = "data:image/webp";

	private const string EMBEDDED_KTX2_BUFFER = "data:image/ktx2";

	private const string MIME_PNG = "image/png";

	private const string MIME_JPG = "image/jpeg";

	private const string MIME_DDS = "image/vnd-ms.dds";

	private const string MIME_WEBP = "image/webp";

	private const string MIME_KTX2 = "image/ktx2";

	private const string DEFAULT_PNG_IMAGE = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAHXpUWHRUaXRsZQAACJlzSU1LLM0pCUmtKCktSgUAKVIFt/VCuZ8AAAAoelRYdEF1dGhvcgAACJkLy0xOzStJVQhIzUtMSS1WcCzKTc1Lzy8BAG89CQyAoFAQAAAANElEQVQoz2O8cuUKAwxoa2vD2VevXsUqzsRAIqC9Bsb///8TdDey+CD0Awsx7h6NB5prAADPsx0VAB8VRQAAAABJRU5ErkJggg==";

	internal static readonly string[] _EmbeddedHeaders = new string[7] { "data:application/octet-stream", "data:application/gltf-buffer", "data:image/jpeg", "data:image/png", "data:image/vnd-ms.dds", "data:image/webp", "data:image/ktx2" };

	private const string GuardError_MustBeValidImage = "Must be a valid image: Png, Jpg, etc...";

	private readonly Lazy<ArraySegment<byte>> _LazyImage;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _SourcePathHint;

	internal static byte[] DefaultPngImage => Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAACXBIWXMAAA7DAAAOwwHHb6hkAAAAHXpUWHRUaXRsZQAACJlzSU1LLM0pCUmtKCktSgUAKVIFt/VCuZ8AAAAoelRYdEF1dGhvcgAACJkLy0xOzStJVQhIzUtMSS1WcCzKTc1Lzy8BAG89CQyAoFAQAAAANElEQVQoz2O8cuUKAwxoa2vD2VevXsUqzsRAIqC9Bsb///8TdDey+CD0Awsx7h6NB5prAADPsx0VAB8VRQAAAABJRU5ErkJggg==");

	public static MemoryImage Empty => default(MemoryImage);

	private ArraySegment<byte> _Image
	{
		get
		{
			if (_LazyImage != null)
			{
				return _LazyImage.Value;
			}
			return default(ArraySegment<byte>);
		}
	}

	public bool IsEmpty => _Image.Count == 0;

	public ReadOnlyMemory<byte> Content => _Image;

	public string SourcePath => _SourcePathHint;

	public bool IsPng => _IsPngImage(_Image);

	public bool IsJpg => _IsJpgImage(_Image);

	public bool IsDds => _IsDdsImage(_Image);

	public bool IsWebp => _IsWebpImage(_Image);

	public bool IsKtx2 => _IsKtx2Image(_Image);

	public bool IsExtendedFormat
	{
		get
		{
			if (!IsDds && !IsWebp)
			{
				return IsKtx2;
			}
			return true;
		}
	}

	public bool IsValid
	{
		get
		{
			try
			{
				_Verify(this, string.Empty);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}

	public string FileExtension
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			if (IsPng)
			{
				return "png";
			}
			if (IsJpg)
			{
				return "jpg";
			}
			if (IsDds)
			{
				return "dds";
			}
			if (IsWebp)
			{
				return "webp";
			}
			if (IsKtx2)
			{
				return "ktx2";
			}
			throw new InvalidOperationException("Image format not recognized.");
		}
	}

	public string MimeType
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			if (IsPng)
			{
				return "image/png";
			}
			if (IsJpg)
			{
				return "image/jpeg";
			}
			if (IsDds)
			{
				return "image/vnd-ms.dds";
			}
			if (IsWebp)
			{
				return "image/webp";
			}
			if (IsKtx2)
			{
				return "image/ktx2";
			}
			throw new InvalidOperationException("Image format not recognized.");
		}
	}

	public string ToDebuggerDisplay()
	{
		if (!string.IsNullOrWhiteSpace(_SourcePathHint))
		{
			return Path.GetFileName(_SourcePathHint);
		}
		if (IsEmpty)
		{
			return "Empty";
		}
		if (!_IsImage(_Image))
		{
			return $"Unknown {_Image.Count}ᴮʸᵗᵉˢ";
		}
		if (IsJpg)
		{
			return $"JPG {_Image.Count}ᴮʸᵗᵉˢ";
		}
		if (IsPng)
		{
			return $"PNG {_Image.Count}ᴮʸᵗᵉˢ";
		}
		if (IsDds)
		{
			return $"DDS {_Image.Count}ᴮʸᵗᵉˢ";
		}
		if (IsWebp)
		{
			return $"WEBP {_Image.Count}ᴮʸᵗᵉˢ";
		}
		if (IsKtx2)
		{
			return $"KTX2 {_Image.Count}ᴮʸᵗᵉˢ";
		}
		return "Undefined";
	}

	public static implicit operator MemoryImage(ArraySegment<byte> image)
	{
		return new MemoryImage(image);
	}

	public static implicit operator MemoryImage(byte[] image)
	{
		return new MemoryImage(image);
	}

	public static implicit operator MemoryImage(string filePath)
	{
		return new MemoryImage(filePath);
	}

	public static bool TryParseMime64(string mime64content, out MemoryImage image)
	{
		if (mime64content == null)
		{
			image = default(MemoryImage);
			return false;
		}
		byte[] array = mime64content.TryParseBase64Unchecked(_EmbeddedHeaders);
		if (array == null)
		{
			image = default(MemoryImage);
			return false;
		}
		if (mime64content.StartsWith("data:image/png", StringComparison.Ordinal) && !_IsPngImage(array))
		{
			throw new ArgumentException("Invalid PNG Content", "mime64content");
		}
		if (mime64content.StartsWith("data:image/jpeg", StringComparison.Ordinal) && !_IsJpgImage(array))
		{
			throw new ArgumentException("Invalid JPG Content", "mime64content");
		}
		if (mime64content.StartsWith("data:image/vnd-ms.dds", StringComparison.Ordinal) && !_IsDdsImage(array))
		{
			throw new ArgumentException("Invalid DDS Content", "mime64content");
		}
		if (mime64content.StartsWith("data:image/webp", StringComparison.Ordinal) && !_IsWebpImage(array))
		{
			throw new ArgumentException("Invalid WEBP Content", "mime64content");
		}
		if (mime64content.StartsWith("data:image/ktx2", StringComparison.Ordinal) && !_IsKtx2Image(array))
		{
			throw new ArgumentException("Invalid KTX2 Content", "mime64content");
		}
		image = array;
		return true;
	}

	public MemoryImage(ArraySegment<byte> image)
		: this(_ToLazy(image), null)
	{
	}

	public MemoryImage(byte[] image)
		: this(_ToLazy(image), null)
	{
	}

	public MemoryImage(Func<ArraySegment<byte>> factory)
		: this(new Lazy<ArraySegment<byte>>(factory), null)
	{
	}

	public MemoryImage(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			_LazyImage = _ToLazy(default(ArraySegment<byte>));
			_SourcePathHint = null;
			return;
		}
		filePath = Path.GetFullPath(filePath);
		byte[] array = File.ReadAllBytes(filePath);
		Guard.IsTrue(_IsImage(array), "filePath", "Must be a valid image: Png, Jpg, etc...");
		_LazyImage = _ToLazy(array);
		_SourcePathHint = filePath;
	}

	internal MemoryImage(byte[] image, string filePath)
		: this(_ToLazy(image), filePath)
	{
	}

	internal MemoryImage(ArraySegment<byte> image, string filePath)
		: this(_ToLazy(image), filePath)
	{
	}

	internal MemoryImage(MemoryImage image, string filePath)
	{
		_LazyImage = image._LazyImage;
		_SourcePathHint = filePath ?? image._SourcePathHint;
	}

	internal MemoryImage(Lazy<ArraySegment<byte>> image, string filePath)
	{
		_LazyImage = image;
		_SourcePathHint = filePath;
	}

	private static Lazy<ArraySegment<byte>> _ToLazy(byte[] bytes)
	{
		return _ToLazy(new ArraySegment<byte>(bytes));
	}

	private static Lazy<ArraySegment<byte>> _ToLazy(ArraySegment<byte> bytes)
	{
		return new Lazy<ArraySegment<byte>>(() => bytes);
	}

	public override int GetHashCode()
	{
		return _Image.Count.GetHashCode();
	}

	public static bool AreEqual(MemoryImage a, MemoryImage b)
	{
		if (a.GetHashCode() != b.GetHashCode())
		{
			return false;
		}
		if (a._Image.Equals(b._Image))
		{
			return true;
		}
		return MemoryExtensions.AsSpan(a._Image).SequenceEqual(b._Image);
	}

	public override bool Equals(object obj)
	{
		if (obj is MemoryImage b)
		{
			return AreEqual(this, b);
		}
		return false;
	}

	public bool Equals(MemoryImage other)
	{
		return AreEqual(this, other);
	}

	public static bool operator ==(MemoryImage left, MemoryImage right)
	{
		return AreEqual(left, right);
	}

	public static bool operator !=(MemoryImage left, MemoryImage right)
	{
		return !AreEqual(left, right);
	}

	public static string TrimImageExtension(string path)
	{
		if (path == null)
		{
			return null;
		}
		string[] array = new string[6] { ".jpg", ".jpeg", ".png", ".dds", ".webp", ".ktx2" };
		foreach (string text in array)
		{
			if (path.EndsWith(text, StringComparison.OrdinalIgnoreCase))
			{
				return path.Substring(0, path.Length - text.Length);
			}
		}
		return path;
	}

	internal static void _Verify(MemoryImage image, string paramName)
	{
		Guard.IsTrue(_IsImage(image._Image), paramName, paramName + " must be a valid image byte stream.");
		if (image.IsKtx2)
		{
			Ktx2Header.Verify(image._Image, paramName);
		}
	}

	public Stream Open()
	{
		if (_Image.Count == 0)
		{
			return null;
		}
		return new MemoryStream(_Image.Array, _Image.Offset, _Image.Count, writable: false);
	}

	public void SaveToFile(string filePath)
	{
		Guard.FilePathMustBeValid(filePath, "filePath");
		Guard.IsTrue(filePath.EndsWith("." + FileExtension, StringComparison.OrdinalIgnoreCase), "filePath", "filePath must use extension '." + FileExtension + "'");
		using FileStream destination = File.Create(filePath);
		using Stream stream = Open();
		stream.CopyTo(destination);
	}

	internal ArraySegment<byte> _GetBuffer()
	{
		return _Image;
	}

	internal string ToMime64(bool withPrefix = true)
	{
		if (!_IsImage(_Image))
		{
			return null;
		}
		string text = string.Empty;
		if (withPrefix)
		{
			if (IsPng)
			{
				text = "data:image/png";
			}
			if (IsJpg)
			{
				text = "data:image/jpeg";
			}
			if (IsDds)
			{
				text = "data:image/vnd-ms.dds";
			}
			if (IsWebp)
			{
				text = "data:image/webp";
			}
			if (IsKtx2)
			{
				text = "data:image/ktx2";
			}
			text += ";base64,";
		}
		return text + Convert.ToBase64String(_Image.Array, _Image.Offset, _Image.Count, Base64FormattingOptions.None);
	}

	public bool IsImageOfType(string format)
	{
		Guard.NotNullOrEmpty(format, "format");
		if (!_IsImage(_Image))
		{
			return false;
		}
		if (format.EndsWith("png", StringComparison.OrdinalIgnoreCase))
		{
			return IsPng;
		}
		if (format.EndsWith("jpg", StringComparison.OrdinalIgnoreCase))
		{
			return IsJpg;
		}
		if (format.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase))
		{
			return IsJpg;
		}
		if (format.EndsWith("dds", StringComparison.OrdinalIgnoreCase))
		{
			return IsDds;
		}
		if (format.EndsWith("webp", StringComparison.OrdinalIgnoreCase))
		{
			return IsWebp;
		}
		if (format.EndsWith("ktx2", StringComparison.OrdinalIgnoreCase))
		{
			return IsKtx2;
		}
		return false;
	}

	private static bool _IsPngImage(IReadOnlyList<byte> data)
	{
		if (data[0] != 137)
		{
			return false;
		}
		if (data[1] != 80)
		{
			return false;
		}
		if (data[2] != 78)
		{
			return false;
		}
		if (data[3] != 71)
		{
			return false;
		}
		return true;
	}

	private static bool _IsJpgImage(IReadOnlyList<byte> data)
	{
		if (data[0] != byte.MaxValue)
		{
			return false;
		}
		if (data[1] != 216)
		{
			return false;
		}
		return true;
	}

	private static bool _IsDdsImage(IReadOnlyList<byte> data)
	{
		if (data[0] != 68)
		{
			return false;
		}
		if (data[1] != 68)
		{
			return false;
		}
		if (data[2] != 83)
		{
			return false;
		}
		if (data[3] != 32)
		{
			return false;
		}
		return true;
	}

	private static bool _IsWebpImage(IReadOnlyList<byte> data)
	{
		if (data[0] != 82)
		{
			return false;
		}
		if (data[1] != 73)
		{
			return false;
		}
		if (data[2] != 70)
		{
			return false;
		}
		if (data[3] != 70)
		{
			return false;
		}
		if (data[8] != 87)
		{
			return false;
		}
		if (data[9] != 69)
		{
			return false;
		}
		if (data[10] != 66)
		{
			return false;
		}
		if (data[11] != 80)
		{
			return false;
		}
		return true;
	}

	private static bool _IsKtx2Image(IReadOnlyList<byte> data)
	{
		try
		{
			if (!Ktx2Header.TryGetHeader(data, out var header))
			{
				return false;
			}
			return header.IsValidHeader;
		}
		catch
		{
			return false;
		}
	}

	private static bool _IsImage(IReadOnlyList<byte> data)
	{
		if (data == null)
		{
			return false;
		}
		if (data.Count < 12)
		{
			return false;
		}
		if (_IsDdsImage(data))
		{
			return true;
		}
		if (_IsJpgImage(data))
		{
			return true;
		}
		if (_IsPngImage(data))
		{
			return true;
		}
		if (_IsWebpImage(data))
		{
			return true;
		}
		if (_IsKtx2Image(data))
		{
			return true;
		}
		return false;
	}
}
