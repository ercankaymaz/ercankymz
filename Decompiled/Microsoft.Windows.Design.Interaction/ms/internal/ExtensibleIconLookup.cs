using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Media.Imaging;

namespace MS.Internal;

internal class ExtensibleIconLookup
{
	private const string VisualStudio = "VisualStudio";

	private const string Expression = "Expression";

	private string fullName;

	private int requestedWidth;

	private int requestedHeight;

	private int? bestDistance;

	private int priority = 50;

	private string resourceName;

	private Stream stream;

	private static string applicationMoniker;

	public string ResourceName => resourceName;

	public Stream Stream => stream;

	public ExtensibleIconLookup(Type type, int requestedWidth, int requestedHeight)
	{
		fullName = type.FullName;
		this.requestedWidth = requestedWidth;
		this.requestedHeight = requestedHeight;
		ScanAssembly(type.Assembly);
		try
		{
			foreach (Assembly designAssembly in GetDesignAssemblies(type.Assembly))
			{
				ScanAssembly(designAssembly);
			}
		}
		catch (Exception)
		{
		}
	}

	private static IEnumerable<Assembly> GetDesignAssemblies(Assembly original)
	{
		string originalName = null;
		try
		{
			originalName = Path.GetFileNameWithoutExtension(original.Location);
		}
		catch (NotSupportedException)
		{
		}
		if (string.IsNullOrEmpty(originalName))
		{
			yield break;
		}
		try
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				if (!(assembly is AssemblyBuilder) && !assembly.FullName.StartsWith("Blend_RuntimeGeneratedTypesAssembly"))
				{
					string designName = null;
					try
					{
						designName = Path.GetFileName(assembly.Location);
					}
					catch (NotSupportedException)
					{
					}
					if (!string.IsNullOrEmpty(designName) && (designName.StartsWith(originalName + ".design", StringComparison.OrdinalIgnoreCase) || designName.StartsWith(originalName + "." + GetApplicationMoniker() + ".design", StringComparison.OrdinalIgnoreCase)))
					{
						yield return assembly;
					}
				}
			}
		}
		finally
		{
		}
	}

	private static string GetApplicationMoniker()
	{
		if (string.IsNullOrEmpty(applicationMoniker))
		{
			bool flag = false;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				if (assembly.FullName.StartsWith("Microsoft.VisualStudio.Xaml", StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					break;
				}
			}
			applicationMoniker = (flag ? "VisualStudio" : "Expression");
		}
		return applicationMoniker;
	}

	private void ScanAssembly(Assembly assembly)
	{
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		string text = GetApplicationMoniker();
		string value = string.Format(CultureInfo.InvariantCulture, ".{0}.", new object[1] { text });
		string[] manifestResourceNames = assembly.GetManifestResourceNames();
		string[] array = manifestResourceNames;
		foreach (string text2 in array)
		{
			if ((string.CompareOrdinal(text, "Expression") == 0 && !text2.EndsWith(".png", StringComparison.OrdinalIgnoreCase)) || (string.CompareOrdinal(text, "VisualStudio") == 0 && !text2.EndsWith(".png", StringComparison.OrdinalIgnoreCase) && !text2.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) && !text2.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) && !text2.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) && !text2.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)))
			{
				continue;
			}
			int num = text2.IndexOf(fullName + ".", StringComparison.Ordinal);
			if (num == -1)
			{
				continue;
			}
			string text3 = text2.Substring(num + fullName.Length);
			bool flag = false;
			if (text3.StartsWith(value, StringComparison.OrdinalIgnoreCase))
			{
				flag = true;
				if (priority > 0)
				{
					bestDistance = null;
					priority = 0;
				}
			}
			else if (priority > 0)
			{
				flag = true;
				priority = 1;
			}
			if (!flag)
			{
				continue;
			}
			int pixelWidth;
			int pixelHeight;
			try
			{
				using Stream streamSource = assembly.GetManifestResourceStream(text2);
				BitmapImage val = new BitmapImage();
				val.BeginInit();
				val.StreamSource = streamSource;
				val.EndInit();
				pixelWidth = ((BitmapSource)val).PixelWidth;
				pixelHeight = ((BitmapSource)val).PixelHeight;
			}
			catch (Exception)
			{
				continue;
			}
			int num2 = Math.Max(Math.Abs(requestedWidth - pixelWidth), Math.Abs(requestedHeight - pixelHeight));
			if (!bestDistance.HasValue || num2 < bestDistance.Value)
			{
				resourceName = text2;
				stream = assembly.GetManifestResourceStream(text2);
				bestDistance = num2;
			}
		}
	}
}
