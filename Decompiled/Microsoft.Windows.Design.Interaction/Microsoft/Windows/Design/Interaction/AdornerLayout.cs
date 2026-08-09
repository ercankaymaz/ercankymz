using System.Windows;
using System.Windows.Controls;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public abstract class AdornerLayout
{
	public abstract void AdornerPropertyChanged(DependencyObject adorner, DependencyPropertyChangedEventArgs args);

	public abstract bool EvaluateLayout(DesignerView view, UIElement adorner);

	public abstract void Measure(UIElement adorner, Size constraint);

	public abstract void Arrange(UIElement adorner);

	public abstract bool IsAssociated(UIElement adorner, ModelItem item);

	public virtual Size ArrangeChildren(FrameworkElement parent, UIElementCollection internalChildren, Size finalSize)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return finalSize;
	}
}
