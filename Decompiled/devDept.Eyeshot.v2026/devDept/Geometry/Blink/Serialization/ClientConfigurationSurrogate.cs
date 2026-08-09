using devDept.Serialization;

namespace devDept.Geometry.Blink.Serialization;

internal class ClientConfigurationSurrogate : Surrogate<ClientConfiguration>
{
	public bool Bagging;

	public ClientConfigurationSurrogate(ClientConfiguration obj)
		: base(obj)
	{
	}

	protected override ClientConfiguration ConvertToObject()
	{
		ClientConfiguration clientConfiguration = new ClientConfiguration();
		CopyDataToObject(clientConfiguration);
		return clientConfiguration;
	}

	protected override void CopyDataToObject(ClientConfiguration obj)
	{
		obj.Bagging = Bagging;
	}

	protected override void CopyDataFromObject(ClientConfiguration obj)
	{
		Bagging = obj.Bagging;
	}

	public static implicit operator ClientConfiguration(ClientConfigurationSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator ClientConfigurationSurrogate(ClientConfiguration source)
	{
		return source?.ConvertToSurrogate();
	}
}
