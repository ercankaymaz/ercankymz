using System;
using System.ComponentModel;

namespace Xceed.Wpf.AvalonDock.Layout;

public interface ILayoutGroup : ILayoutContainer, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging
{
	event EventHandler ChildrenCollectionChanged;

	int IndexOfChild(ILayoutElement element);

	void InsertChildAt(int index, ILayoutElement element);

	void RemoveChildAt(int index);

	void ReplaceChildAt(int index, ILayoutElement element);
}
