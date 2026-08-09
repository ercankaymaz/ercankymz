using System;
using System.Collections.Generic;

namespace CmdLanguage.API;

public class LanguageItem
{
	public string Key;

	public string Category;

	public Dictionary<string, string> Translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
}
