using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Flat_UI_Dashboard_Design
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );
        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(46, 51, 73);
            this.Size = new System.Drawing.Size(951, 577);
            this.ShowIcon = false;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void InitializeButtons()
        {
            // Initialize the array with your buttons
            Button[] buttons = new Button[]
            {
                btnDashBoard,
                btnAnalytics,
                btnCalendar,
                btnContactUs,
                btnSettings
            };

            // Attach MouseEnter and MouseLeave events to each button
            foreach (Button button in buttons)
            {
                button.MouseClick += Button_MouseClick;
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
        }



        private void Button_MouseClick(object sender, EventArgs e)
        {
  
            if (sender is Button)
            {
                Button enteredButton = (Button)sender;
                PnlNavHandler(sender, true);
            }
        }


        private void Button_MouseEnter(object sender, EventArgs e)
        {
 
            if (sender is Button)
            {
                Button enteredButton = (Button)sender;
                PnlNavHandler(sender, true);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
 
            if (sender is Button)
            {
                Button leftButton = (Button)sender;
                PnlNavHandler(sender, false);
            }
        }

 

        private void PnlNavHandler(object sender, bool Enters)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                if (true == Enters)
                {
                    PnlNav.Height = clickedButton.Height;
                    PnlNav.Top = clickedButton.Top;
                    PnlNav.Left = clickedButton.Left;
                    clickedButton.BackColor = Color.FromArgb(46, 51, 73);
                }
                else
                {
                    clickedButton.BackColor = Color.FromArgb(24, 30, 54);
                }
            }
        }

    }
}
