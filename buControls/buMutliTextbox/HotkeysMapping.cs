// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.HotkeysMapping
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class HotkeysMapping : SortedDictionary<System.Windows.Forms.Keys, FCTBAction>
{
  public virtual void InitDefault()
  {
    this[System.Windows.Forms.Keys.G | System.Windows.Forms.Keys.Control] = FCTBAction.GoToDialog;
    this[System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Control] = FCTBAction.FindDialog;
    this[System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Alt] = FCTBAction.FindChar;
    this[System.Windows.Forms.Keys.F3] = FCTBAction.FindNext;
    this[System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control] = FCTBAction.ReplaceDialog;
    this[System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control] = FCTBAction.Copy;
    this[System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.CommentSelected;
    this[System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Control] = FCTBAction.Cut;
    this[System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control] = FCTBAction.Paste;
    this[System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control] = FCTBAction.SelectAll;
    this[System.Windows.Forms.Keys.Z | System.Windows.Forms.Keys.Control] = FCTBAction.Undo;
    this[System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control] = FCTBAction.Redo;
    this[System.Windows.Forms.Keys.U | System.Windows.Forms.Keys.Control] = FCTBAction.UpperCase;
    this[System.Windows.Forms.Keys.U | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.LowerCase;
    this[System.Windows.Forms.Keys.OemMinus | System.Windows.Forms.Keys.Control] = FCTBAction.NavigateBackward;
    this[System.Windows.Forms.Keys.OemMinus | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.NavigateForward;
    this[System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Control] = FCTBAction.BookmarkLine;
    this[System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.UnbookmarkLine;
    this[System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control] = FCTBAction.GoNextBookmark;
    this[System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoPrevBookmark;
    this[System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.Alt] = FCTBAction.Undo;
    this[System.Windows.Forms.Keys.Back | System.Windows.Forms.Keys.Control] = FCTBAction.ClearWordLeft;
    this[System.Windows.Forms.Keys.Insert] = FCTBAction.ReplaceMode;
    this[System.Windows.Forms.Keys.Insert | System.Windows.Forms.Keys.Control] = FCTBAction.Copy;
    this[System.Windows.Forms.Keys.Insert | System.Windows.Forms.Keys.Shift] = FCTBAction.Paste;
    this[System.Windows.Forms.Keys.Delete] = FCTBAction.DeleteCharRight;
    this[System.Windows.Forms.Keys.Delete | System.Windows.Forms.Keys.Control] = FCTBAction.ClearWordRight;
    this[System.Windows.Forms.Keys.Delete | System.Windows.Forms.Keys.Shift] = FCTBAction.Cut;
    this[System.Windows.Forms.Keys.Left] = FCTBAction.GoLeft;
    this[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift] = FCTBAction.GoLeftWithSelection;
    this[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordLeft;
    this[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordLeftWithSelection;
    this[System.Windows.Forms.Keys.Left | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoLeft_ColumnSelectionMode;
    this[System.Windows.Forms.Keys.Right] = FCTBAction.GoRight;
    this[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift] = FCTBAction.GoRightWithSelection;
    this[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordRight;
    this[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoWordRightWithSelection;
    this[System.Windows.Forms.Keys.Right | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoRight_ColumnSelectionMode;
    this[System.Windows.Forms.Keys.Up] = FCTBAction.GoUp;
    this[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Shift] = FCTBAction.GoUpWithSelection;
    this[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoUp_ColumnSelectionMode;
    this[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Alt] = FCTBAction.MoveSelectedLinesUp;
    this[System.Windows.Forms.Keys.Up | System.Windows.Forms.Keys.Control] = FCTBAction.ScrollUp;
    this[System.Windows.Forms.Keys.Down] = FCTBAction.GoDown;
    this[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Shift] = FCTBAction.GoDownWithSelection;
    this[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt] = FCTBAction.GoDown_ColumnSelectionMode;
    this[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Alt] = FCTBAction.MoveSelectedLinesDown;
    this[System.Windows.Forms.Keys.Down | System.Windows.Forms.Keys.Control] = FCTBAction.ScrollDown;
    this[System.Windows.Forms.Keys.Prior] = FCTBAction.GoPageUp;
    this[System.Windows.Forms.Keys.Prior | System.Windows.Forms.Keys.Shift] = FCTBAction.GoPageUpWithSelection;
    this[System.Windows.Forms.Keys.Next] = FCTBAction.GoPageDown;
    this[System.Windows.Forms.Keys.Next | System.Windows.Forms.Keys.Shift] = FCTBAction.GoPageDownWithSelection;
    this[System.Windows.Forms.Keys.Home] = FCTBAction.GoHome;
    this[System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Shift] = FCTBAction.GoHomeWithSelection;
    this[System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Control] = FCTBAction.GoFirstLine;
    this[System.Windows.Forms.Keys.Home | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoFirstLineWithSelection;
    this[System.Windows.Forms.Keys.End] = FCTBAction.GoEnd;
    this[System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Shift] = FCTBAction.GoEndWithSelection;
    this[System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Control] = FCTBAction.GoLastLine;
    this[System.Windows.Forms.Keys.End | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control] = FCTBAction.GoLastLineWithSelection;
    this[System.Windows.Forms.Keys.Escape] = FCTBAction.ClearHints;
    this[System.Windows.Forms.Keys.M | System.Windows.Forms.Keys.Control] = FCTBAction.MacroRecord;
    this[System.Windows.Forms.Keys.E | System.Windows.Forms.Keys.Control] = FCTBAction.MacroExecute;
    this[System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Control] = FCTBAction.AutocompleteMenu;
    this[System.Windows.Forms.Keys.Tab] = FCTBAction.IndentIncrease;
    this[System.Windows.Forms.Keys.Tab | System.Windows.Forms.Keys.Shift] = FCTBAction.IndentDecrease;
    this[System.Windows.Forms.Keys.Subtract | System.Windows.Forms.Keys.Control] = FCTBAction.ZoomOut;
    this[System.Windows.Forms.Keys.Add | System.Windows.Forms.Keys.Control] = FCTBAction.ZoomIn;
    this[System.Windows.Forms.Keys.D0 | System.Windows.Forms.Keys.Control] = FCTBAction.ZoomNormal;
    this[System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control] = FCTBAction.AutoIndentChars;
  }

  public override string ToString()
  {
    CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
    StringBuilder stringBuilder = new StringBuilder();
    KeysConverter keysConverter = new KeysConverter();
    foreach (KeyValuePair<System.Windows.Forms.Keys, FCTBAction> keyValuePair in (SortedDictionary<System.Windows.Forms.Keys, FCTBAction>) this)
      stringBuilder.AppendFormat("{0}={1}, ", (object) keysConverter.ConvertToString((object) keyValuePair.Key), (object) keyValuePair.Value);
    if (stringBuilder.Length > 1)
      stringBuilder.Remove(stringBuilder.Length - 2, 2);
    Thread.CurrentThread.CurrentUICulture = currentUiCulture;
    return stringBuilder.ToString();
  }

  public static HotkeysMapping Parse(string s)
  {
    HotkeysMapping hotkeysMapping = new HotkeysMapping();
    hotkeysMapping.Clear();
    CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
    KeysConverter keysConverter = new KeysConverter();
    string str1 = s;
    char[] chArray1 = new char[1]{ ',' };
    foreach (string str2 in str1.Split(chArray1))
    {
      char[] chArray2 = new char[1]{ '=' };
      string[] strArray = str2.Split(chArray2);
      System.Windows.Forms.Keys key = (System.Windows.Forms.Keys) keysConverter.ConvertFromString(strArray[0].Trim());
      FCTBAction fctbAction = (FCTBAction) Enum.Parse(typeof (FCTBAction), strArray[1].Trim());
      hotkeysMapping[key] = fctbAction;
    }
    Thread.CurrentThread.CurrentUICulture = currentUiCulture;
    return hotkeysMapping;
  }
}
