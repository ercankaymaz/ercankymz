using Pylon;

namespace Basler.Pylon;

internal class CTransportLayerInfoImpl : InfoImpl, ITransportLayerInfo
{
	public unsafe CTransportLayerInfoImpl(CInfoBase* pInfo)
		: base(pInfo)
	{
	}
}
