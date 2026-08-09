using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{_DebuggerDisplay(),nq}")]
public sealed class Image : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "image";

	private int? _bufferView;

	private string _mimeType;

	private string _uri;

	private MemoryImage? _SatelliteContent;

	public MemoryImage Content
	{
		get
		{
			return GetSatelliteContent();
		}
		set
		{
			SetSatelliteContent(value);
		}
	}

	public string AlternateWriteFileName { get; set; }

	internal int _SourceBufferViewIndex => _bufferView.AsValue(-1);

	internal bool _HasContent
	{
		get
		{
			if (_bufferView.HasValue)
			{
				return true;
			}
			return _SatelliteContent?.IsValid ?? false;
		}
	}

	protected override string GetSchemaName()
	{
		return "image";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "bufferView";
		yield return "mimeType";
		yield return "uri";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "bufferView":
			value = FieldInfo.From("bufferView", this, (Image instance) => instance._bufferView);
			return true;
		case "mimeType":
			value = FieldInfo.From("mimeType", this, (Image instance) => instance._mimeType);
			return true;
		case "uri":
			value = FieldInfo.From("uri", this, (Image instance) => instance._uri);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "bufferView", _bufferView);
		JsonSerializable.SerializeProperty(writer, "mimeType", _mimeType);
		JsonSerializable.SerializeProperty(writer, "uri", _uri);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "bufferView":
			JsonSerializable.DeserializePropertyValue<Image, int?>(ref reader, this, out _bufferView);
			break;
		case "mimeType":
			JsonSerializable.DeserializePropertyValue<Image, string>(ref reader, this, out _mimeType);
			break;
		case "uri":
			JsonSerializable.DeserializePropertyValue<Image, string>(ref reader, this, out _uri);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal string _DebuggerDisplay()
	{
		return $"Image[{base.LogicalIndex}] {base.Name} = {Content.ToDebuggerDisplay()}";
	}

	internal Image()
	{
	}

	private MemoryImage GetSatelliteContent()
	{
		if (_SatelliteContent.HasValue)
		{
			return _SatelliteContent.Value;
		}
		if (_bufferView.HasValue)
		{
			BufferView bufferView = base.LogicalParent.LogicalBufferViews[_bufferView.Value];
			return bufferView.Content;
		}
		throw new InvalidOperationException();
	}

	private void SetSatelliteContent(MemoryImage content)
	{
		MemoryImage._Verify(content, "content");
		_DiscardContent();
		_SatelliteContent = content;
	}

	internal void TransferToInternalBuffer()
	{
		if (_SatelliteContent.HasValue)
		{
			_bufferView = base.LogicalParent.UseBufferView(_SatelliteContent.Value._GetBuffer()).LogicalIndex;
			_uri = null;
			_mimeType = null;
			_SatelliteContent = null;
		}
	}

	internal void _ResolveUri(ReadContext context)
	{
		if (!string.IsNullOrWhiteSpace(_uri))
		{
			string fullPath;
			if (MemoryImage.TryParseMime64(_uri, out var image))
			{
				_SatelliteContent = image;
			}
			else if (context.TryGetFullPath(_uri, out fullPath))
			{
				_SatelliteContent = fullPath;
			}
			else
			{
				_SatelliteContent = new MemoryImage(context.ReadAllBytesToEnd(_uri), _uri);
			}
			_uri = null;
			_mimeType = null;
		}
	}

	internal void _DiscardContent()
	{
		_uri = null;
		_mimeType = null;
		_bufferView = null;
		_SatelliteContent = null;
	}

	internal void _WriteToInternal()
	{
		if (!_SatelliteContent.HasValue)
		{
			_WriteAsBufferView();
			return;
		}
		MemoryImage value = _SatelliteContent.Value;
		MemoryImage._Verify(value, "imimg");
		_uri = value.ToMime64();
		_mimeType = value.MimeType;
	}

	internal void _WriteToSatellite(WriteContext writer, string satelliteUri)
	{
		if (!_SatelliteContent.HasValue)
		{
			_WriteAsBufferView();
			return;
		}
		MemoryImage value = _SatelliteContent.Value;
		MemoryImage._Verify(value, "imimg");
		if (string.IsNullOrWhiteSpace(AlternateWriteFileName))
		{
			satelliteUri = MemoryImage.TrimImageExtension(satelliteUri);
			satelliteUri = satelliteUri + "." + value.FileExtension;
		}
		else
		{
			satelliteUri = AlternateWriteFileName;
			if (satelliteUri.EndsWith(".*"))
			{
				satelliteUri = Path.ChangeExtension(satelliteUri, value.FileExtension);
			}
			if (Path.IsPathRooted(satelliteUri))
			{
				throw new InvalidOperationException("AlternateWriteFileName must be a relative path");
			}
		}
		satelliteUri = writer.WriteImage(satelliteUri, value);
		satelliteUri = _Extensions.Replace(satelliteUri, "\\", "/", StringComparison.Ordinal);
		_uri = satelliteUri._EscapeStringInternal();
		_mimeType = null;
	}

	private void _WriteAsBufferView()
	{
		Guard.IsTrue(_bufferView.HasValue, "_bufferView");
		MemoryImage content = Content;
		MemoryImage._Verify(content, "imimg");
		_uri = null;
		_mimeType = content.MimeType;
	}

	internal void _ClearAfterWrite()
	{
		_uri = null;
		_mimeType = null;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsNullOrValidURI("_uri", _uri, MemoryImage._EmbeddedHeaders).IsNullOrIndex("BufferView", _bufferView, validate.Root.LogicalBufferViews);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		if (_bufferView.HasValue)
		{
			BufferView bufferView = validate.Root.LogicalBufferViews[_bufferView.GetValueOrDefault()];
			validate.IsTrue("BufferView", bufferView.IsDataBuffer, "is a GPU target.");
		}
		MemoryImage._Verify(Content, "Content");
	}
}
