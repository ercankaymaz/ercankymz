using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;

namespace SourceGrid.Cells.Editors;

public static class Factory
{
	public static EditorBase Create(Type p_Type)
	{
		TypeConverter converter = TypeDescriptor.GetConverter(p_Type);
		ICollection collection = null;
		bool p_StandardValueExclusive = false;
		if (converter != null)
		{
			collection = converter.GetStandardValues();
			p_StandardValueExclusive = collection != null && collection.Count > 0 && converter.GetStandardValuesExclusive();
		}
		object editor = TypeDescriptor.GetEditor(p_Type, typeof(UITypeEditor));
		if (editor == null)
		{
			if (collection == null)
			{
				if (converter == null || !converter.CanConvertFrom(typeof(string)))
				{
					return null;
				}
				return new TextBox(p_Type);
			}
			return new ComboBox(p_Type, collection, p_StandardValueExclusive);
		}
		return new TextBoxUITypeEditor(p_Type);
	}

	public static EditorBase Create(Type p_Type, object p_DefaultValue, bool p_bAllowNull, ICollection p_StandardValues, bool p_bStandardValueExclusive, TypeConverter p_TypeConverter, UITypeEditor p_UITypeEditor)
	{
		EditorBase editorBase;
		if (p_UITypeEditor != null)
		{
			TextBoxUITypeEditor textBoxUITypeEditor = new TextBoxUITypeEditor(p_Type);
			textBoxUITypeEditor.Control.UITypeEditor = p_UITypeEditor;
			editorBase = textBoxUITypeEditor;
		}
		else if (p_StandardValues == null)
		{
			if (p_TypeConverter == null || !p_TypeConverter.CanConvertFrom(typeof(string)))
			{
				editorBase = null;
			}
			else
			{
				TextBox textBox = new TextBox(p_Type);
				editorBase = textBox;
			}
		}
		else
		{
			ComboBox comboBox = new ComboBox(p_Type);
			editorBase = comboBox;
		}
		if (editorBase != null)
		{
			editorBase.DefaultValue = p_DefaultValue;
			editorBase.AllowNull = p_bAllowNull;
			editorBase.StandardValues = p_StandardValues;
			editorBase.StandardValuesExclusive = p_bStandardValueExclusive;
			editorBase.TypeConverter = p_TypeConverter;
		}
		return editorBase;
	}
}
