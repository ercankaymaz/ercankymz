using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Security;

internal sealed class RequestSecurityTokenResponseCollection : BodyWriter
{
	private SecurityStandardsManager _standardsManager;

	public IEnumerable<RequestSecurityTokenResponse> RstrCollection { get; }

	public RequestSecurityTokenResponseCollection(IEnumerable<RequestSecurityTokenResponse> rstrCollection)
		: this(rstrCollection, SecurityStandardsManager.DefaultInstance)
	{
	}

	public RequestSecurityTokenResponseCollection(IEnumerable<RequestSecurityTokenResponse> rstrCollection, SecurityStandardsManager standardsManager)
		: base(isBuffered: true)
	{
		if (rstrCollection == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("rstrCollection");
		}
		int num = 0;
		foreach (RequestSecurityTokenResponse item in rstrCollection)
		{
			if (item == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(string.Format(CultureInfo.InvariantCulture, "rstrCollection[{0}]", num));
			}
			num++;
		}
		RstrCollection = rstrCollection;
		_standardsManager = standardsManager ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("standardsManager"));
	}

	public void WriteTo(XmlWriter writer)
	{
		_standardsManager.TrustDriver.WriteRequestSecurityTokenResponseCollection(this, writer);
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		WriteTo(writer);
	}
}
