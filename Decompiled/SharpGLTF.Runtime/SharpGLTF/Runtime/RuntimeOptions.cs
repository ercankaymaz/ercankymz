using System;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

public class RuntimeOptions
{
	public bool IsolateMemory { get; set; }

	public MeshInstancing GpuMeshInstancing { get; set; } = MeshInstancing.Enabled;

	public Converter<ExtraProperties, object> ExtrasConverterCallback { get; set; }

	internal static object ConvertExtras(ExtraProperties source, RuntimeOptions options)
	{
		if (source.Extras == null)
		{
			return null;
		}
		if (options == null)
		{
			return source.Extras;
		}
		Converter<ExtraProperties, object> extrasConverterCallback = options.ExtrasConverterCallback;
		if (extrasConverterCallback == null)
		{
			if (!options.IsolateMemory)
			{
				return source.Extras;
			}
			return source.Extras?.DeepClone();
		}
		return extrasConverterCallback(source);
	}
}
