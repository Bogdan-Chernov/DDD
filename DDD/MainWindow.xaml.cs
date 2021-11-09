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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Fer()
        {
            DataClass main = new DataClass();

            lvViewGroup.ItemsSource = main.ReadGr();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text) && !String.IsNullOrWhiteSpace(tbCurator.Text))
                {
                    Group group = new Group()
                    {
                        NameGr = tbNameGroup.Text,
                        NumberGr = tbNumberGroup.Text,
                        CuratorGr = tbCurator.Text
                    };

                    DataClass main = new DataClass();

                    main.AddGr(group);
                    Fer();
                }
                else
                {
                    MessageBox.Show("Поле пустое");
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!String.IsNullOrWhiteSpace(tbIdGroup.Text))
                {
                    Group group = new Group()
                    {
                        idGr = Convert.ToInt32(tbIdGroup.Text)
                    };
                    DataClass main = new DataClass();
                    main.DelGr(group);
                    Fer();
                }
                else
                {
                    MessageBox.Show("Поле пустое");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) || !String.IsNullOrWhiteSpace(tbNumberGroup.Text) || !String.IsNullOrWhiteSpace(tbCurator.Text) || !String.IsNullOrWhiteSpace(tbIdGroup.Text))
                {
                    Group group = new Group()
                    {
                        idGr = Convert.ToInt32(tbIdGroup.Text),
                        NameGr = tbNameGroup.Text,
                        NumberGr = tbNumberGroup.Text,
                        CuratorGr = tbCurator.Text
                    };
                    DataClass main = new DataClass();
                    main.UpdGr(group);
                    Fer();
                }
                else
                {
                    MessageBox.Show("Поля пустые");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
