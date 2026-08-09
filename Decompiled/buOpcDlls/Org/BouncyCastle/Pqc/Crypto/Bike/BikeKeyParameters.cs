using Org.BouncyCastle.Crypto;

namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public abstract class BikeKeyParameters : AsymmetricKeyParameter
{
	private readonly BikeParameters m_parameters;

	public BikeParameters Parameters => m_parameters;

	internal BikeKeyParameters(bool isPrivate, BikeParameters parameters)
		: base(isPrivate)
	{
		m_parameters = parameters;
	}
}
