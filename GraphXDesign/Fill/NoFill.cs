using System.Drawing;
using Newtonsoft.Json;

namespace GraphXDesign
{
    class NoFill:IFill
    {
        public NoFill(IFill fill) : base(fill) { }
        [JsonConstructor]
        public NoFill(Color color) : base(color) { }

        public NoFill() { }

        public override void Fill(BitmapWrap bmp, Point point)
        {
            //ничего не делаем
            return;
        }
    }
}
