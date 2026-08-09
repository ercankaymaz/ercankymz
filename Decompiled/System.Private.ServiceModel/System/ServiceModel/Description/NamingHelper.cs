using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Description;

internal static class NamingHelper
{
	internal delegate bool DoesNameExist(string name, object nameCollection);

	internal const string DefaultNamespace = "http://tempuri.org/";

	internal const string DefaultServiceName = "service";

	internal const string MSNamespace = "http://schemas.microsoft.com/2005/07/ServiceModel";

	internal static string CombineUriStrings(string baseUri, string path)
	{
		if (Uri.IsWellFormedUriString(path, UriKind.Absolute) || path == string.Empty)
		{
			return path;
		}
		if (baseUri.EndsWith("/", StringComparison.Ordinal))
		{
			return baseUri + (path.StartsWith("/", StringComparison.Ordinal) ? path.Substring(1) : path);
		}
		return baseUri + (path.StartsWith("/", StringComparison.Ordinal) ? path : ("/" + path));
	}

	internal static string TypeName(Type t)
	{
		Type[] array = null;
		if (t.GetTypeInfo().IsGenericType)
		{
			array = t.GetTypeInfo().GenericTypeArguments;
		}
		else if (t.GetTypeInfo().ContainsGenericParameters)
		{
			array = t.GetTypeInfo().GenericTypeParameters;
		}
		if (array != null)
		{
			int num = t.Name.IndexOf('`');
			string text = ((num > 0) ? t.Name.Substring(0, num) : t.Name);
			text += "Of";
			for (int i = 0; i < array.Length; i++)
			{
				text = text + "_" + TypeName(array[i]);
			}
			return text;
		}
		if (t.IsArray)
		{
			return "ArrayOf" + TypeName(t.GetElementType());
		}
		return t.Name;
	}

	internal static XmlQualifiedName GetContractName(Type contractType, string name, string ns)
	{
		XmlName xmlName = new XmlName(name ?? TypeName(contractType));
		if (ns == null)
		{
			ns = "http://tempuri.org/";
		}
		return new XmlQualifiedName(xmlName.EncodedName, ns);
	}

	internal static XmlName GetOperationName(string logicalMethodName, string name)
	{
		return new XmlName(string.IsNullOrEmpty(name) ? logicalMethodName : name);
	}

	internal static string GetMessageAction(OperationDescription operation, bool isResponse)
	{
		ContractDescription declaringContract = operation.DeclaringContract;
		XmlQualifiedName contractName = new XmlQualifiedName(declaringContract.Name, declaringContract.Namespace);
		return GetMessageAction(contractName, operation.CodeName, null, isResponse);
	}

	internal static string GetMessageAction(XmlQualifiedName contractName, string opname, string action, bool isResponse)
	{
		if (action != null)
		{
			return action;
		}
		StringBuilder stringBuilder = new StringBuilder(64);
		if (string.IsNullOrEmpty(contractName.Namespace))
		{
			stringBuilder.Append("urn:");
		}
		else
		{
			stringBuilder.Append(contractName.Namespace);
			if (!contractName.Namespace.EndsWith("/", StringComparison.Ordinal))
			{
				stringBuilder.Append('/');
			}
		}
		stringBuilder.Append(contractName.Name);
		stringBuilder.Append('/');
		action = (isResponse ? (opname + "Response") : opname);
		return CombineUriStrings(stringBuilder.ToString(), action);
	}

	internal static string GetUniqueName(string baseName, DoesNameExist doesNameExist, object nameCollection)
	{
		for (int i = 0; i < int.MaxValue; i++)
		{
			string text = ((i > 0) ? (baseName + i) : baseName);
			if (!doesNameExist(text, nameCollection))
			{
				return text;
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cannot generate unique name for name {0}", baseName)));
	}

	internal static void CheckUriProperty(string ns, string propName)
	{
		if (!Uri.TryCreate(ns, UriKind.RelativeOrAbsolute, out Uri _))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.SFXUnvalidNamespaceValue, ns, propName));
		}
	}

	internal static void CheckUriParameter(string ns, string paramName)
	{
		if (!Uri.TryCreate(ns, UriKind.RelativeOrAbsolute, out Uri _))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(paramName, System.SR.Format(System.SR.SFXUnvalidNamespaceParam, ns));
		}
	}

	internal static string XmlName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return name;
		}
		if (IsAsciiLocalName(name))
		{
			return name;
		}
		if (IsValidNCName(name))
		{
			return name;
		}
		return XmlConvert.EncodeLocalName(name);
	}

	internal static string CodeName(string name)
	{
		return XmlConvert.DecodeName(name);
	}

	private static bool IsAlpha(char ch)
	{
		if (ch < 'A' || ch > 'Z')
		{
			if (ch >= 'a')
			{
				return ch <= 'z';
			}
			return false;
		}
		return true;
	}

	private static bool IsDigit(char ch)
	{
		if (ch >= '0')
		{
			return ch <= '9';
		}
		return false;
	}

	private static bool IsAsciiLocalName(string localName)
	{
		if (!IsAlpha(localName[0]))
		{
			return false;
		}
		for (int i = 1; i < localName.Length; i++)
		{
			char ch = localName[i];
			if (!IsAlpha(ch) && !IsDigit(ch))
			{
				return false;
			}
		}
		return true;
	}

	internal static bool IsValidNCName(string name)
	{
		try
		{
			XmlConvert.VerifyNCName(name);
			return true;
		}
		catch (XmlException)
		{
			return false;
		}
	}
}
