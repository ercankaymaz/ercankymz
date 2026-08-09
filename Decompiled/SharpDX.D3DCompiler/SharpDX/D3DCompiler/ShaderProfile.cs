using System;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

public struct ShaderProfile(ShaderVersion version, int major, int minor, int profileMajor, int profileMinor)
{
	private const string shortStringFormat = "{0}_{1}_{2}";

	private const string longStringFormat = "{0}_{1}_{2}_level_{3}_{4}";

	public readonly ShaderVersion Version = version;

	public readonly int Major = major;

	public readonly int Minor = minor;

	public readonly int ProfileMajor = profileMajor;

	public readonly int ProfileMinor = profileMinor;

	public override string ToString()
	{
		string typePrefix = GetTypePrefix();
		if (ProfileMajor == 0)
		{
			return $"{typePrefix}_{Major}_{Minor}";
		}
		return $"{typePrefix}_{Major}_{Minor}_level_{ProfileMajor}_{ProfileMinor}";
	}

	public string GetTypePrefix()
	{
		return Version switch
		{
			ShaderVersion.PixelShader => "ps", 
			ShaderVersion.VertexShader => "vs", 
			ShaderVersion.GeometryShader => "gs", 
			ShaderVersion.HullShader => "hs", 
			ShaderVersion.DomainShader => "ds", 
			ShaderVersion.ComputeShader => "cs", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public FeatureLevel GetFeatureLevel()
	{
		if (Major == 5 && Minor == 0)
		{
			return FeatureLevel.Level_11_0;
		}
		if (Major == 4 && Minor == 1)
		{
			return FeatureLevel.Level_10_1;
		}
		if (Major == 4 && Minor == 0)
		{
			if (ProfileMajor == 9 && ProfileMinor == 3)
			{
				return FeatureLevel.Level_9_3;
			}
			if (ProfileMajor == 9 && ProfileMinor == 1)
			{
				return FeatureLevel.Level_9_1;
			}
			if (ProfileMajor == 0 && ProfileMinor == 0)
			{
				return FeatureLevel.Level_10_0;
			}
		}
		throw new InvalidOperationException("Cannot convert profile to feature level.");
	}
}
