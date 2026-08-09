using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace buMutliTextbox;

public class MacrosManager
{
	private readonly List<object> list_0 = new List<object>();

	[CompilerGenerated]
	private bool bool_0;

	private bool bool_1;

	[CompilerGenerated]
	private buMultiTextBox buMultiTextBox_0;

	public bool AllowMacroRecordingByUser
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool IsRecording
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			UnderlayingControl.Invalidate();
		}
	}

	public buMultiTextBox UnderlayingControl
	{
		[CompilerGenerated]
		get
		{
			return buMultiTextBox_0;
		}
		[CompilerGenerated]
		private set
		{
			buMultiTextBox_0 = value;
		}
	}

	public bool MacroIsEmpty => list_0.Count == 0;

	public string Macros
	{
		get
		{
			CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			KeysConverter keysConverter = new KeysConverter();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<macros>");
			foreach (object item in list_0)
			{
				if (!(item is Keys))
				{
					if (item is KeyValuePair<char, Keys> keyValuePair)
					{
						stringBuilder.AppendFormat("<item char='{0}' key='{1}' />\r\n", (int)keyValuePair.Key, keysConverter.ConvertToString(keyValuePair.Value));
					}
				}
				else
				{
					stringBuilder.AppendFormat("<item key='{0}' />\r\n", keysConverter.ConvertToString((Keys)item));
				}
			}
			stringBuilder.AppendLine("</macros>");
			Thread.CurrentThread.CurrentUICulture = currentUICulture;
			return stringBuilder.ToString();
		}
		set
		{
			bool_1 = false;
			ClearMacros();
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(value);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("./macros/item");
			CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			KeysConverter keysConverter = new KeysConverter();
			if (xmlNodeList != null)
			{
				foreach (XmlElement item in xmlNodeList)
				{
					XmlAttribute attributeNode = item.GetAttributeNode("char");
					XmlAttribute attributeNode2 = item.GetAttributeNode("key");
					if (attributeNode == null)
					{
						if (attributeNode2 != null)
						{
							AddKeyToMacros((Keys)keysConverter.ConvertFromString(attributeNode2.Value));
						}
					}
					else if (attributeNode2 == null)
					{
						AddCharToMacros((char)int.Parse(attributeNode.Value), Keys.None);
					}
					else
					{
						AddCharToMacros((char)int.Parse(attributeNode.Value), (Keys)keysConverter.ConvertFromString(attributeNode2.Value));
					}
				}
			}
			Thread.CurrentThread.CurrentUICulture = currentUICulture;
		}
	}

	internal MacrosManager(buMultiTextBox buMultiTextBox_1)
	{
		UnderlayingControl = buMultiTextBox_1;
		AllowMacroRecordingByUser = true;
	}

	public void ExecuteMacros()
	{
		IsRecording = false;
		UnderlayingControl.BeginUpdate();
		UnderlayingControl.Selection.BeginUpdate();
		UnderlayingControl.BeginAutoUndo();
		foreach (object item in list_0)
		{
			if (item is Keys)
			{
				UnderlayingControl.ProcessKey((Keys)item);
			}
			if (item is KeyValuePair<char, Keys> keyValuePair)
			{
				UnderlayingControl.ProcessKey(keyValuePair.Key, keyValuePair.Value);
			}
		}
		UnderlayingControl.EndAutoUndo();
		UnderlayingControl.Selection.EndUpdate();
		UnderlayingControl.EndUpdate();
	}

	public void AddCharToMacros(char c, Keys modifiers)
	{
		list_0.Add(new KeyValuePair<char, Keys>(c, modifiers));
	}

	public void AddKeyToMacros(Keys keyData)
	{
		list_0.Add(keyData);
	}

	public void ClearMacros()
	{
		list_0.Clear();
	}
}
