using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BAARS_4_Tester
{
    /// <summary>
    /// Interaction logic for TesterAnswers.xaml
    /// </summary>
    public partial class TesterAnswers : Window
    {
        Tester t;



        public TesterAnswers(Tester t)
        {
            this.t = t;
            InitializeComponent();
            display.Text = t.firstName+ " " + t.middleName + " " + t.lastName;
        }
    }
}
