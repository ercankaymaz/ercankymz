using System;
using System.Windows.Markup;

namespace Xceed.Wpf.Toolkit.Core;

[MarkupExtensionReturnType(typeof(Uri))]
public class PackUriExtension : MarkupExtension
{
	private string m_assemblyName;

	private string m_path;

	private UriKind m_uriKind;

	public string AssemblyName
	{
		get
		{
			return m_assemblyName;
		}
		set
		{
			m_assemblyName = value;
		}
	}

	public string Path
	{
		get
		{
			return m_path;
		}
		set
		{
			m_path = value;
		}
	}

	public UriKind Kind
	{
		get
		{
			return m_uriKind;
		}
		set
		{
			m_uriKind = value;
		}
	}

	public PackUriExtension()
		: this(UriKind.Relative)
	{
	}

	public PackUriExtension(UriKind uriKind)
	{
		m_uriKind = uriKind;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (string.IsNullOrEmpty(m_path))
		{
			throw new InvalidOperationException("Path must be set during initialization");
		}
		string uriString;
		switch (m_uriKind)
		{
		case UriKind.RelativeOrAbsolute:
		case UriKind.Relative:
			uriString = BuildRelativePackUriString(m_assemblyName, m_path);
			break;
		case UriKind.Absolute:
			uriString = BuildAbsolutePackUriString(m_assemblyName, m_path);
			break;
		default:
			throw new NotSupportedException();
		}
		return new Uri(uriString, m_uriKind);
	}

	internal static string BuildRelativePackUriString(string assemblyName, string path)
	{
		return BuildRelativePackUriString(assemblyName, string.Empty, path);
	}

	internal static string BuildRelativePackUriString(string assemblyName, string version, string path)
	{
		if (string.IsNullOrEmpty(assemblyName))
		{
			throw new ArgumentException("assemblyName cannot be null or empty", assemblyName);
		}
		string text = string.Empty;
		if (!assemblyName.EndsWith(".NET5", StringComparison.OrdinalIgnoreCase))
		{
			text = ".NET5";
		}
		if (!string.IsNullOrEmpty(version))
		{
			version = ";v" + version;
		}
		return $"/{assemblyName}{text}{version};component/{path}";
	}

	internal static string BuildAbsolutePackUriString(string assemblyName, string path)
	{
		return BuildAbsolutePackUriString(assemblyName, string.Empty, path);
	}

	internal static string BuildAbsolutePackUriString(string assemblyName, string version, string path)
	{
		string text = string.Empty;
		bool num = !string.IsNullOrEmpty(assemblyName);
		if (num && !assemblyName.EndsWith(".NET5", StringComparison.OrdinalIgnoreCase))
		{
			text = ".NET5";
		}
		if (num && !string.IsNullOrEmpty(version))
		{
			version = ";v" + version;
		}
		return $"pack://application:,,,/{assemblyName}{text}{version};component/{path}";
	}
}
