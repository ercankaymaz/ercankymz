using System.Xml.Serialization;

namespace System.ServiceModel.Description;

[XmlRoot(ElementName = "Location", Namespace = "http://schemas.xmlsoap.org/ws/2004/09/mex")]
public class MetadataLocation
{
	private string _location;

	[XmlText]
	public string Location
	{
		get
		{
			return _location;
		}
		set
		{
			if (value != null && !Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out Uri _))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.SFxMetadataReferenceInvalidLocation, value));
			}
			_location = value;
		}
	}

	public MetadataLocation()
	{
	}

	public MetadataLocation(string location)
	{
		Location = location;
	}
}
