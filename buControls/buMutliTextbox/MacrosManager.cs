// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.MacrosManager
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

#nullable disable
namespace buMutliTextbox;

public class MacrosManager
{
  private readonly List<object> list_0 = new List<object>();
  private bool bool_1;

  internal MacrosManager(buMultiTextBox buMultiTextBox_1)
  {
    this.UnderlayingControl = buMultiTextBox_1;
    this.AllowMacroRecordingByUser = true;
  }

  public bool AllowMacroRecordingByUser { get; set; }

  public bool IsRecording
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      this.UnderlayingControl.Invalidate();
    }
  }

  public buMultiTextBox UnderlayingControl { get; private set; }

  public void ExecuteMacros()
  {
    this.IsRecording = false;
    this.UnderlayingControl.BeginUpdate();
    this.UnderlayingControl.Selection.BeginUpdate();
    this.UnderlayingControl.BeginAutoUndo();
    foreach (object obj in this.list_0)
    {
      if (obj is Keys keyData)
        this.UnderlayingControl.ProcessKey(keyData);
      if (obj is KeyValuePair<char, Keys> keyValuePair)
        this.UnderlayingControl.ProcessKey(keyValuePair.Key, keyValuePair.Value);
    }
    this.UnderlayingControl.EndAutoUndo();
    this.UnderlayingControl.Selection.EndUpdate();
    this.UnderlayingControl.EndUpdate();
  }

  public void AddCharToMacros(char c, Keys modifiers)
  {
    this.list_0.Add((object) new KeyValuePair<char, Keys>(c, modifiers));
  }

  public void AddKeyToMacros(Keys keyData) => this.list_0.Add((object) keyData);

  public void ClearMacros() => this.list_0.Clear();

  public bool MacroIsEmpty => this.list_0.Count == 0;

  public string Macros
  {
    get
    {
      CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
      Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
      KeysConverter keysConverter = new KeysConverter();
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("<macros>");
      foreach (object obj in this.list_0)
      {
        if (obj is Keys keys)
          stringBuilder.AppendFormat("<item key='{0}' />\r\n", (object) keysConverter.ConvertToString((object) keys));
        else if (obj is KeyValuePair<char, Keys> keyValuePair)
          stringBuilder.AppendFormat("<item char='{0}' key='{1}' />\r\n", (object) (int) keyValuePair.Key, (object) keysConverter.ConvertToString((object) keyValuePair.Value));
      }
      stringBuilder.AppendLine("</macros>");
      Thread.CurrentThread.CurrentUICulture = currentUiCulture;
      return stringBuilder.ToString();
    }
    set
    {
      this.bool_1 = false;
      this.ClearMacros();
      if (string.IsNullOrEmpty(value))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(value);
      XmlNodeList xmlNodeList = xmlDocument.SelectNodes("./macros/item");
      CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
      Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
      KeysConverter keysConverter = new KeysConverter();
      if (xmlNodeList != null)
      {
        foreach (XmlElement xmlElement in xmlNodeList)
        {
          XmlAttribute attributeNode1 = xmlElement.GetAttributeNode("char");
          XmlAttribute attributeNode2 = xmlElement.GetAttributeNode("key");
          if (attributeNode1 != null)
          {
            if (attributeNode2 != null)
              this.AddCharToMacros((char) int.Parse(attributeNode1.Value), (Keys) keysConverter.ConvertFromString(attributeNode2.Value));
            else
              this.AddCharToMacros((char) int.Parse(attributeNode1.Value), Keys.None);
          }
          else if (attributeNode2 != null)
            this.AddKeyToMacros((Keys) keysConverter.ConvertFromString(attributeNode2.Value));
        }
      }
      Thread.CurrentThread.CurrentUICulture = currentUiCulture;
    }
  }
}
