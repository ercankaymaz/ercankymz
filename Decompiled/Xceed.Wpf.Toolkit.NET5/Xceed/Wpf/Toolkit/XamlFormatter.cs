using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace Xceed.Wpf.Toolkit;

public class XamlFormatter : ITextFormatter
{
	public string GetText(FlowDocument document)
	{
		TextRange textRange = new TextRange(document.ContentStart, document.ContentEnd);
		using MemoryStream memoryStream = new MemoryStream();
		textRange.Save(memoryStream, DataFormats.Xaml);
		return Encoding.Default.GetString(memoryStream.ToArray());
	}

	public void SetText(FlowDocument document, string text)
	{
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				document.Blocks.Clear();
				return;
			}
			TextRange textRange = new TextRange(document.ContentStart, document.ContentEnd);
			using MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(text));
			textRange.Load(stream, DataFormats.Xaml);
		}
		catch
		{
			throw new InvalidDataException("Data provided is not in the correct Xaml format.");
		}
	}
}
