using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDMediaWatched
{
    public partial class Form1 : Form
    {
        public static string
            path_local,
            path_program,
            path_op,
            path_trashbox,
            Information = "",
            ConsoleOutput = "",
            user_type = "",
            version = "",
            version_date = "",
            usernameArg = "",
            domainArg = "",
            passwordArg = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
