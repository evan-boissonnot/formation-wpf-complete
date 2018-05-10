using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xml;

namespace ListOfTemplates
{
    public class TypeTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type currentType = value as Type;
            string templateAsString = string.Empty;

            if (currentType != null)
            {
                ConstructorInfo info = currentType.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);

                Grid child = parameter as Grid;
                if(child != null)
                {
                    control.Visibility = System.Windows.Visibility.Collapsed;
                    child.Children.Add(control);

                    ControlTemplate template = control.Template;

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    StringBuilder builder = new StringBuilder();
                    XmlWriter writer = XmlWriter.Create(builder, settings);
                    XamlWriter.Save(template, writer);

                    templateAsString = builder.ToString();
                }
            }

            return templateAsString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
