using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace GraphXDesign
{
    class OnlyFill:SolidFill
    {
        public OnlyFill(IFill fill) : base(fill) { }
        [JsonConstructor]
        public OnlyFill(Color color) : base(color) { }
    }
}
