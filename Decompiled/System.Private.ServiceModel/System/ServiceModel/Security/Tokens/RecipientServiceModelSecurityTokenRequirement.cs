namespace System.ServiceModel.Security.Tokens;

public sealed class RecipientServiceModelSecurityTokenRequirement : ServiceModelSecurityTokenRequirement
{
	public Uri ListenUri
	{
		get
		{
			return GetPropertyOrDefault<Uri>(ServiceModelSecurityTokenRequirement.ListenUriProperty, null);
		}
		set
		{
			base.Properties[ServiceModelSecurityTokenRequirement.ListenUriProperty] = value;
		}
	}

	public RecipientServiceModelSecurityTokenRequirement()
	{
		base.Properties.Add(ServiceModelSecurityTokenRequirement.IsInitiatorProperty, false);
	}

	public override string ToString()
	{
		return InternalToString();
	}
}
