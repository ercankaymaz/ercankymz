using System.IO;

namespace ExCSS;

public abstract class MediaFeature : StylesheetNode, IMediaFeature, IStylesheetNode, IStyleFormattable
{
	private TokenValue _tokenValue;

	internal abstract IValueConverter Converter { get; }

	public bool IsMinimum { get; }

	public bool IsMaximum { get; }

	public string Name { get; }

	public string Value
	{
		get
		{
			if (!HasValue)
			{
				return string.Empty;
			}
			return _tokenValue.Text;
		}
	}

	public bool HasValue
	{
		get
		{
			if (_tokenValue != null)
			{
				return _tokenValue.Count > 0;
			}
			return false;
		}
	}

	internal MediaFeature(string name)
	{
		Name = name;
		IsMinimum = name.StartsWith("min-");
		IsMaximum = name.StartsWith("max-");
	}

	public override void ToCss(TextWriter writer, IStyleFormatter formatter)
	{
		string value = (HasValue ? Value : null);
		writer.Write(formatter.Constraint(Name, value));
	}

	internal bool TrySetValue(TokenValue tokenValue)
	{
		bool flag = ((tokenValue != null) ? (Converter.Convert(tokenValue) != null) : (!IsMinimum && !IsMaximum && Converter.ConvertDefault() != null));
		if (flag)
		{
			_tokenValue = tokenValue;
		}
		return flag;
	}
}
