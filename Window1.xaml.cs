using Symulator1.Models.HDDscheduling;
using Symulator1.Models.Helper;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Symulator1.HddController;

namespace Symulator1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Button b;
        Grid g;
        Slider[] sliders;
        HddController controller;
        public Window1()
        {
            InitializeComponent();
            b = (Button)FindName("button");
            g = (Grid)FindName("Grid");
            sliders = new Slider[3];
            sliders[0] = (Slider)FindName("s1");
            sliders[1] = (Slider)FindName("s2");
            sliders[2] = (Slider)FindName("s3");

            rng_entry.InitSliders();
            rng_cylinder.InitSliders();
            Dictionary<string, RngControl> temp = new Dictionary<string, RngControl>();
            temp.Add("entry", rng_entry);
            temp.Add("cylinder", rng_cylinder);
            controller = new HddController(temp,int.Parse(process_amount.Text));

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
         
        private void displayresults(List<HDDResult> ps)

        {
            this.Wyniki.ItemsSource = ps;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.populateRandom();
            var maxlen = int.Parse(DiskWidth.Text);
            HddAlg[] algs =
            {
                new HddAlg("Empty"),
                new FCFS("FCFS",maxlen ),
                new SSTF("sstf",maxlen),
                new SCAN("scan",maxlen)
            };
            displayresults(controller.evaluateAlgorithm(algs));
        }
        void DiskWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ( rng_cylinder != null) { 
            try
            {
                rng_cylinder.max.Text = int.Parse(DiskWidth.Text).ToString();
                rng_cylinder.MaxRange = int.Parse(DiskWidth.Text);
            }
            catch (System.Exception)
            {
                DiskWidth.Text = rng_cylinder.MaxRange.ToString();

            }
        }
        }
    }
}

