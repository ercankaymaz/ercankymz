using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

public class ReadSettings
{
	public ValidationMode Validation { get; set; } = ValidationMode.Strict;

	public ImageDecodeCallback ImageDecoder { get; set; }

	public JsonFilterCallback JsonPreprocessor { get; set; }

	public static implicit operator ReadSettings(ValidationMode vmode)
	{
		return new ReadSettings
		{
			Validation = vmode
		};
	}

	public ReadSettings()
	{
	}

	public ReadSettings(ReadSettings other)
	{
		Guard.NotNull(other, "other");
		other.CopyTo(this);
	}

	public void CopyTo(ReadSettings other)
	{
		Guard.NotNull(other, "other");
		other.Validation = Validation;
		other.ImageDecoder = ImageDecoder;
		other.JsonPreprocessor = JsonPreprocessor;
	}
}
