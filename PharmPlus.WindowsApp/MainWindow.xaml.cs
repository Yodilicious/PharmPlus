using System.Windows;

namespace PharmPlus.WindowsApp
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Lib;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _drugs = new ObservableCollection<Drug>();
            LstDrugs.ItemsSource = _drugs;
            TxtGenericDrugName.Focus();
        }

        private void CmdAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtGenericDrugName.Text.Length > 0 && TxtBrandDrugName.Text.Length > 0)
            {
                var drug = new Drug(TxtGenericDrugName.Text, TxtBrandDrugName.Text);
                _drugs.Add(drug);
                TxtGenericDrugName.Text = "";
                TxtBrandDrugName.Text = "";
                TxtGenericDrugName.Focus ();
            }
            else
            {
                MessageBox.Show(this, "Please enter both Generic and Brand names.");
                TxtGenericDrugName.Focus();
            }
        }

        private void CmdSearch_Click(object sender, RoutedEventArgs e)
        {
            if (TxtSearch.Text.Length > 0)
            {
                var result = (from d in _drugs
                    where d.BrandName == TxtSearch.Text
                    select d.GenericName).FirstOrDefault();

                if (!String.IsNullOrEmpty(result))
                {
                    MessageBox.Show(this, string.Format ("The Generic name is {0}", result));
                }
                else
                {
                    MessageBox.Show(this, "Brand name not found!");
                }
            }
            else
            {
                MessageBox.Show(this, "Please enter Brand name.");
                TxtSearch.Focus();
            }
        }

        private readonly ObservableCollection<Drug> _drugs;
    }
}
