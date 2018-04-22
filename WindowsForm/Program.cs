using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f = new Form();
            Button b = new Button();
            b.Text = "CLick Me";
            b.Click += Responder;
            b.Click += (object sender, EventArgs evt) => MessageBox.Show(((Button)sender).Text);
            f.Controls.Add(b);
            Application.Run(f);

        }

        static void Responder(object sender, EventArgs evt)
        {
            MessageBox.Show("Ouch. What did you do that");
        }
    }
}
