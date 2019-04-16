using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Visualizer.UI
{
    internal static class UIHelper
    {
        public static void LoadComboBox<T>(ComboBox combo, bool includeMixed = true)
        {
            if (combo == null)
                throw new ArgumentNullException(nameof(combo));

            var types = GetTypeItems<T>();

            combo.Items.Clear();
            combo.Items.AddRange(types);

            if (includeMixed)
            {
                combo.Items.Add(new TypeItem("Mixed", types.SelectMany(it => it.Types)));
            }

            combo.SelectedIndex = 0;
        }

        private static TypeItem[] GetTypeItems<T>()
        {
            var result = new List<TypeItem>();

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (var type in asm.GetTypes())
                    {
                        if (typeof(T).IsAssignableFrom(type) &&
                            !type.IsAbstract &&
                            !type.IsInterface)
                        {
                            var desc = type.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)
                                           .Cast<DescriptionAttribute>()
                                           .Select(a => a.Description)
                                           .ToArray();

                            var name = desc.Length == 0 ? type.Name : String.Join("-", desc);

                            result.Add(new TypeItem(name, new Type[] { type }));
                        }

                    }
                }
                catch { }
            }

            return result.Distinct()
                         .OrderBy(i => i.Text)
                         .ToArray();
        }
    }
}
