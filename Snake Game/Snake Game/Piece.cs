using System.Drawing;
using System.Windows.Forms;

namespace Snake_Game
{
    class Piece : Label
    {
     
        public Piece(int x, int y, int size)
        {
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(size, size);
            BackColor = Color.Orange;
            Enabled = false;
        }
    }
}
