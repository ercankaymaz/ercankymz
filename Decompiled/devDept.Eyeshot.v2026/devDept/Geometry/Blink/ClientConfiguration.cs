using devDept.Geometry.Blink.Serialization;

namespace devDept.Geometry.Blink;

internal class ClientConfiguration
{
	public bool Bagging;

	internal ClientConfiguration()
	{
	}

	internal ClientConfigurationSurrogate ConvertToSurrogate()
	{
		return new ClientConfigurationSurrogate(this);
	}
}
