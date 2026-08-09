using System.Collections.Specialized;
using System.Text.RegularExpressions;
using ns27;

namespace DevAge.Configuration;

public class CommandLineArgs : StringDictionary
{
	public CommandLineArgs(string Args)
	{
		if (Args != null && !(Args == ""))
		{
			Regex regex = new Regex("(['\"][^\"]+['\"])\\s*|([^\\s]+)\\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
			MatchCollection matchCollection = regex.Matches(Args);
			string[] array = new string[matchCollection.Count - 1];
			for (int i = 1; i < matchCollection.Count; i++)
			{
				array[i - 1] = matchCollection[i].Value.Trim();
			}
			Class76.smethod_85(this, array);
		}
		else
		{
			Class76.smethod_85(this, new string[0]);
		}
	}

	public CommandLineArgs(string[] Args)
	{
		Class76.smethod_85(this, Args);
	}

	public override string ToString()
	{
		string text = "";
		foreach (string key in Keys)
		{
			text = text + key + "='" + this[key] + "'\n";
		}
		return text;
	}
}
