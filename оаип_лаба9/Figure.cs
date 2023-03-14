using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace оаип_лаба9
{
    abstract public class Figure
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public string name;
        public string createname;
        internal static object figure;

        abstract public void Draw();
        abstract public void MoveTo(int x, int y);
        public void DeleteF(Figure figure, bool flag = true)
        {
            if (flag == true)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figurelist.Remove(figure);
                this.Clear();
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figurelist)
                {
                    f.Draw();
                }
            }
            else
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figurelist.Remove(figure);
                this.Clear();
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figurelist)
                {
                    f.Draw();
                }
                ShapeContainer.figurelist.Add(figure);
            }
        }
        public  virtual void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }
    }
}
