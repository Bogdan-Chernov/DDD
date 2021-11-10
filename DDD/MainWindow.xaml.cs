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

        void UpdListView()
        {
            DataClass main = new DataClass();

            lvViewGroup.ItemsSource = main.ReadGroup();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text) && !String.IsNullOrWhiteSpace(tbCurator.Text))
                {
                    Group group = new Group()
                    {
                        NameGroup = tbNameGroup.Text,
                        NumberGroup = tbNumberGroup.Text,
                        CuratorGroup = tbCurator.Text
                    };

                    DataClass main = new DataClass();

                    main.AddGroup(group);
                    UpdListView();
                }
                else
                {
                    MessageBox.Show("НЕдопустимые данные для полей");
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
                        idGroup = Convert.ToInt32(tbIdGroup.Text)
                    };
                    DataClass main = new DataClass();
                    main.DelGroup(group);
                    UpdListView();
                    tbNameGroup.Clear();
                    tbCurator.Clear();
                    tbNumberGroup.Clear();
                    tbIdGroup.Text = "";
                }
                else
                {
                    MessageBox.Show("НЕдопустимые данные для полей");
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
                if (!String.IsNullOrWhiteSpace(tbNameGroup.Text) && !String.IsNullOrWhiteSpace(tbNumberGroup.Text) && !String.IsNullOrWhiteSpace(tbCurator.Text) && !String.IsNullOrWhiteSpace(tbIdGroup.Text))
                {
                    Group group = new Group()
                    {
                        idGroup = Convert.ToInt32(tbIdGroup.Text),
                        NameGroup = tbNameGroup.Text,
                        NumberGroup = tbNumberGroup.Text,
                        CuratorGroup = tbCurator.Text
                    };
                    DataClass main = new DataClass();
                    main.UpdGroup(group);
                    UpdListView();
                }
                else
                {
                    MessageBox.Show("НЕдопустимые данные для полей");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
