using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.ViewModels;

public class TreeViewBuilder
{
	public static List<IXbimViewModel> ContainmentView(IModel model)
	{
		List<IXbimViewModel> list = new List<IXbimViewModel>();
		IIfcProject ifcProject = model.Instances.FirstOrDefault<IIfcProject>();
		if (ifcProject == null)
		{
			return list;
		}
		list.Add(new XbimModelViewModel(ifcProject, null));
		foreach (IXbimViewModel item in list)
		{
			LazyLoadAll(item);
		}
		return list;
	}

	public static List<IXbimViewModel> ComponentView(IModel model)
	{
		List<IXbimViewModel> list = (from type in (from itm in (from itm in model.Instances.OfType<IIfcProduct>()
					select itm.GetType()).Distinct()
				where (typeof(IIfcElement).IsAssignableFrom(itm) && !typeof(IIfcFeatureElement).IsAssignableFrom(itm)) || typeof(IIfcSpace).IsAssignableFrom(itm)
				orderby itm.Name
				select itm).ToArray()
			select new TypeViewModel(type, model)).Cast<IXbimViewModel>().ToList();
		foreach (IXbimViewModel item in list)
		{
			LazyLoadAll(item);
		}
		return list;
	}

	private static void LazyLoadAll(IXbimViewModel parent)
	{
		foreach (IXbimViewModel child in parent.Children)
		{
			LazyLoadAll(child);
		}
	}
}
