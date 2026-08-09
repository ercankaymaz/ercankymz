using System.Collections.Generic;

namespace CmdLanguage.API;

public class LanguageDatabase
{
	public List<string> SupportedLanguages = new List<string>();

	public List<LanguageItem> Items = new List<LanguageItem>();
}
