// Decompiled with JetBrains decompiler
// Type: DevAge.Configuration.CommandLineArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

#nullable disable
namespace DevAge.Configuration;

public class CommandLineArgs : StringDictionary
{
  public CommandLineArgs(string Args)
  {
    if ((Args == null ? 1 : (Args == "" ? 1 : 0)) != 0)
    {
      Class39.smethod_85(this, new string[0]);
    }
    else
    {
      MatchCollection matchCollection = new Regex("(['\"][^\"]+['\"])\\s*|([^\\s]+)\\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(Args);
      string[] string_0 = new string[matchCollection.Count - 1];
      for (int i = 1; i < matchCollection.Count; ++i)
        string_0[i - 1] = matchCollection[i].Value.Trim();
      Class39.smethod_85(this, string_0);
    }
  }

  public CommandLineArgs(string[] Args) => Class39.smethod_85(this, Args);

  public override string ToString()
  {
    string str = "";
    foreach (string key in (IEnumerable) this.Keys)
      str = $"{str}{key}='{this[key]}'\n";
    return str;
  }
}
