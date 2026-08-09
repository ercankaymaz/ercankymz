namespace System.IdentityModel.Claims;

public static class Rights
{
	private const string rightNamespace = "http://schemas.xmlsoap.org/ws/2005/05/identity/right";

	private const string identity = "http://schemas.xmlsoap.org/ws/2005/05/identity/right/identity";

	private const string possessProperty = "http://schemas.xmlsoap.org/ws/2005/05/identity/right/possessproperty";

	public static string Identity => "http://schemas.xmlsoap.org/ws/2005/05/identity/right/identity";

	public static string PossessProperty => "http://schemas.xmlsoap.org/ws/2005/05/identity/right/possessproperty";
}
