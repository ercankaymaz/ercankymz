using System.Xml;

namespace System.ServiceModel.Description;

internal class XmlName
{
	private string _decoded;

	private string _encoded;

	internal string EncodedName
	{
		get
		{
			if (_encoded == null)
			{
				_encoded = NamingHelper.XmlName(_decoded);
			}
			return _encoded;
		}
	}

	internal string DecodedName
	{
		get
		{
			if (_decoded == null)
			{
				_decoded = NamingHelper.CodeName(_encoded);
			}
			return _decoded;
		}
	}

	private bool IsEmpty
	{
		get
		{
			if (string.IsNullOrEmpty(_encoded))
			{
				return string.IsNullOrEmpty(_decoded);
			}
			return false;
		}
	}

	internal XmlName(string name)
		: this(name, isEncoded: false)
	{
	}

	internal XmlName(string name, bool isEncoded)
	{
		if (isEncoded)
		{
			ValidateEncodedName(name, allowNull: true);
			_encoded = name;
		}
		else
		{
			_decoded = name;
		}
	}

	private static void ValidateEncodedName(string name, bool allowNull)
	{
		if (allowNull && name == null)
		{
			return;
		}
		try
		{
			XmlConvert.VerifyNCName(name);
		}
		catch (XmlException ex)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(ex.Message, "name"));
		}
	}

	internal static bool IsNullOrEmpty(XmlName xmlName)
	{
		if (!(xmlName == null))
		{
			return xmlName.IsEmpty;
		}
		return true;
	}

	private bool Matches(XmlName xmlName)
	{
		return string.Equals(EncodedName, xmlName.EncodedName, StringComparison.Ordinal);
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		XmlName xmlName = obj as XmlName;
		if (xmlName == null)
		{
			return false;
		}
		return Matches(xmlName);
	}

	public override int GetHashCode()
	{
		if (string.IsNullOrEmpty(EncodedName))
		{
			return 0;
		}
		return EncodedName.GetHashCode();
	}

	public override string ToString()
	{
		if (_encoded == null && _decoded == null)
		{
			return null;
		}
		if (_encoded != null)
		{
			return _encoded;
		}
		return _decoded;
	}

	public static bool operator ==(XmlName a, XmlName b)
	{
		return a?.Equals(b) ?? ((object)b == null);
	}

	public static bool operator !=(XmlName a, XmlName b)
	{
		return !(a == b);
	}
}
