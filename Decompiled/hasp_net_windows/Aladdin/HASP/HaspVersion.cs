using System;

namespace Aladdin.HASP;

[Serializable]
public struct HaspVersion
{
	private int majorVersion;

	private int minorVersion;

	private int serverBuild;

	private int buildNumber;

	public int MajorVersion => majorVersion;

	public int MinorVersion => minorVersion;

	public int ServerBuild => serverBuild;

	public int BuildNumber => buildNumber;

	public HaspVersion(int majorVersion, int minorVersion, int serverBuild, int buildNumber)
	{
		this.majorVersion = majorVersion;
		this.minorVersion = minorVersion;
		this.serverBuild = serverBuild;
		this.buildNumber = buildNumber;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != typeof(HaspVersion))
		{
			return false;
		}
		HaspVersion haspVersion = (HaspVersion)obj;
		if (haspVersion.majorVersion != majorVersion)
		{
			return false;
		}
		if (haspVersion.minorVersion != minorVersion)
		{
			return false;
		}
		if (haspVersion.serverBuild != serverBuild)
		{
			return false;
		}
		if (haspVersion.buildNumber != buildNumber)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return majorVersion ^ minorVersion ^ serverBuild ^ buildNumber;
	}

	public static bool operator ==(HaspVersion left, HaspVersion right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(HaspVersion left, HaspVersion right)
	{
		return !left.Equals(right);
	}
}
