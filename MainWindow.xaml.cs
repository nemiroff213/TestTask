using System;
using System.Windows;
using System.Threading;

namespace InvendApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte ButtonChange = 1;
        History<int> inthistory;
        History<string> stringhistory;
        LetterGenerator lettergenerator;
        NumberGenerator numbergenerator;
        public MainWindow()
        {
            InitializeComponent();
            inthistory = new History<int>();
            stringhistory = new History<string>();
            lettergenerator = new LetterGenerator();
            numbergenerator = new NumberGenerator();

        }
        private void ButtonRandom_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Random);
            thread.Start();

        }
        private void ButtonString_Click(object sender, RoutedEventArgs e)
        {
            ButtonChange = 1;

        }
        private void ButtonInt_Click(object sender, RoutedEventArgs e)
        {
            ButtonChange = 2;

        }
        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(PreviousValues);
            thread.Start();

        }

        private void Random()
        {
            TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Style = (Style)TextBox1.FindResource("Usual"); });
            TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Style = (Style)TextBox2.FindResource("Usual"); });
            TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Style = (Style)TextBox3.FindResource("Usual"); });

            if (ButtonChange == 1)
            {
                lettergenerator.StartRandom();
                stringhistory.AddObject(lettergenerator.GetRandom);

                for (int i = 0; i < lettergenerator.GetIlluminateIndex.Length; i++)
                {
                    switch (lettergenerator.GetIlluminateIndex[i])
                    {
                        case 0:
                            TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Style = null; TextBox1.Style = (Style)TextBox1.FindResource("IlluminateGreen"); });
                            break;
                        case 1:
                            TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Style = null; TextBox2.Style = (Style)TextBox2.FindResource("IlluminateGreen"); });
                            break;
                        case 2:
                            TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Style = null; TextBox3.Style = (Style)TextBox3.FindResource("IlluminateGreen"); });
                            break;
                    }
                }

                TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Text = "String: " + lettergenerator.GetRandom[0]; });
                TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Text = "String: " + lettergenerator.GetRandom[1]; });
                TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Text = "String: " + lettergenerator.GetRandom[2]; });
            }
            if (ButtonChange == 2)
            {
                numbergenerator.StartRandom();
                inthistory.AddObject(numbergenerator.GetRandom);

                switch (numbergenerator.GetIlluminateIndex)
                {
                    case 0:
                        TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                            TextBox1.Style = null; TextBox1.Style = (Style)TextBox1.FindResource("Illuminate");
                        }); break;
                    case 1:
                        TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                            TextBox2.Style = null; TextBox2.Style = (Style)TextBox2.FindResource("Illuminate");
                        }); break;
                    case 2:
                        TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                            TextBox3.Style = null; TextBox3.Style = (Style)TextBox3.FindResource("Illuminate");
                        }); break;
                }
                TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Text = "Int: " + Convert.ToString(numbergenerator.GetRandom[0]); });
                TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Text = "Int: " + Convert.ToString(numbergenerator.GetRandom[1]); });
                TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Text = "Int: " + Convert.ToString(numbergenerator.GetRandom[2]); });
            }
        }
        private void PreviousValues()
        {
            TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Style = (Style)TextBox1.FindResource("Usual"); });
            TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Style = (Style)TextBox2.FindResource("Usual"); });
            TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Style = (Style)TextBox3.FindResource("Usual"); });
            if (ButtonChange == 1)
            {
                string[] massiv = new string[3];
                massiv = stringhistory.GetPreviousElement();
                int count = 0;
                int[] index = new int[0];
                for (int i = 0; i < massiv.Length; i++)
                {
                    if (massiv[i][0].Equals(massiv[i][1]) || massiv[i][0].Equals(massiv[i][2]) || massiv[i][1].Equals(massiv[i][2]))
                    {
                        Array.Resize(ref index, index.Length + 1);
                        index[count] = i;
                        count++;
                    }
                }
                if (index.Length != 0)
                {
                    for (int i = 0; i < index.Length; i++)
                    {
                        switch (index[i])
                        {
                            case 0:
                                TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                                {
                                    TextBox3.Style = null; TextBox3.Style = (Style)TextBox3.FindResource("IlluminateGreen");
                                }); break;
                            case 1:
                                TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                                {
                                    TextBox2.Style = null; TextBox2.Style = (Style)TextBox2.FindResource("IlluminateGreen");
                                }); break;
                            case 2:
                                TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                                {
                                    TextBox1.Style = null; TextBox1.Style = (Style)TextBox1.FindResource("IlluminateGreen");
                                }); break;
                        }
                    }
                }


                TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Text = "String: " + massiv[2]; });
                TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Text = "String: " + massiv[1]; });
                TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Text = "String: " + massiv[0]; });
            }
            if (ButtonChange == 2)
            {
                int[] massiv = new int[3];
                massiv = inthistory.GetPreviousElement();
                int temporary = 0;
                for (int i = 0; i < massiv.Length; i++)
                {
                    temporary = massiv[i] > temporary ? massiv[i] : temporary;
                }
                int index = Array.IndexOf(massiv, temporary);
                switch (index)
                {
                    case 0:
                        TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                            TextBox3.Style = null; TextBox3.Style = (Style)TextBox3.FindResource("Illuminate");
                        }); break;
                    case 1:
                        TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                            TextBox2.Style = null; TextBox2.Style = (Style)TextBox2.FindResource("Illuminate");
                        }); break;
                    case 2:
                        TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate
                        {
                            TextBox1.Style = null; TextBox1.Style = (Style)TextBox1.FindResource("Illuminate");
                        }); break;
                }
                TextBox1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox1.Text = "Int: " + Convert.ToString(massiv[2]); });
                TextBox2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox2.Text = "Int: " + Convert.ToString(massiv[1]); });
                TextBox3.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate { TextBox3.Text = "Int: " + Convert.ToString(massiv[0]); });
            }

        }
    }
}

