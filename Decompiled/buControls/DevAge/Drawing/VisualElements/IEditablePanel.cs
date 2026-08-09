using System;

namespace DevAge.Drawing.VisualElements;

public interface IEditablePanel : ICloneable, IBorder
{
	BorderStyle BorderStyle { get; set; }
}
