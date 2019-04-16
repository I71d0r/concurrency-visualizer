using System;
using System.Collections.Generic;
using System.Linq;

namespace Visualizer.UI
{
    internal class TypeItem
    {
        public string Text { get; }
        public Type[] Types { get; set; }

        public TypeItem(string text, IEnumerable<Type> types)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));
            if (types == null)
                throw new ArgumentNullException(nameof(types));

            Text = text;
            Types = types.ToArray();
        }

        public override string ToString() => Text;
    }
}
