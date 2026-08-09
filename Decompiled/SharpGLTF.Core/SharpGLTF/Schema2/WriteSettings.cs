using System.Text.Json;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

public class WriteSettings
{
	private JsonWriterOptions _JsonOptions;

	public ResourceWriteMode ImageWriting { get; set; }

	public ImageWriterCallback ImageWriteCallback { get; set; }

	public bool MergeBuffers { get; set; } = true;

	public int BuffersMaxSize { get; set; } = int.MaxValue;

	public bool JsonIndented
	{
		get
		{
			return _JsonOptions.Indented;
		}
		set
		{
			_JsonOptions.Indented = value;
		}
	}

	public JsonWriterOptions JsonOptions
	{
		get
		{
			return _JsonOptions;
		}
		set
		{
			_JsonOptions = value;
		}
	}

	public ValidationMode Validation { get; set; } = ValidationMode.Strict;

	public JsonFilterCallback JsonPostprocessor { get; set; }

	public static implicit operator WriteSettings(ValidationMode vmode)
	{
		return new WriteSettings
		{
			Validation = vmode
		};
	}

	public WriteSettings()
	{
	}

	public WriteSettings(WriteSettings other)
	{
		Guard.NotNull(other, "other");
		other.CopyTo(this);
	}

	public void CopyTo(WriteSettings other)
	{
		Guard.NotNull(other, "other");
		other.ImageWriting = ImageWriting;
		other.ImageWriteCallback = ImageWriteCallback;
		other.MergeBuffers = MergeBuffers;
		other.BuffersMaxSize = BuffersMaxSize;
		other._JsonOptions = _JsonOptions;
		other.Validation = Validation;
		other.JsonPostprocessor = JsonPostprocessor;
	}
}
