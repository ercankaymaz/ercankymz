using System;

namespace DevAge.Drawing.VisualElements;

public interface ICheckBox : ICloneable, IVisualElement
{
	ControlDrawStyle Style { get; set; }

	CheckBoxState CheckBoxState { get; set; }
}
