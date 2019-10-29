using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace WeekPicker
{
	public static class ExtensionsUtils
	{
		public static DependencyObject SetGridCoords(this DependencyObject obj, int rowIndex, int columnIndex)
		{
			obj.SetValue(Grid.RowProperty, rowIndex);
			obj.SetValue(Grid.ColumnProperty, columnIndex);

			return obj;
		}
	}
}
