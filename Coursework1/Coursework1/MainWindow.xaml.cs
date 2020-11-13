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

namespace Coursework1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lblCountry.Visibility = Visibility.Visible;
            cboCountry.Visibility = Visibility.Visible;
        }


        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstNameEntry.Text;
            string surname = txtSurnameEntry.Text;
            


            try
            {
                int age = Convert.ToInt32(txtAgeEntry.Text);
            }catch
            {
                MessageBox.Show("Age cannot be left blank and it must be a number");
            }

           











            if (txtFirstNameEntry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "First Name(s)"); // Checks if a value has been entered into the first name text box
            }

            if (txtSurnameEntry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "Surname"); // Checks if a value has been entered into the surname text box
            }

            if (txtAddress1Entry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "Address1");
            }

            if (txtAddress2Entry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "Address2");
            }

            if (txtCityEntry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "City");
            }

            if (txtPostCodeEntry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "Postcode");
            }

            if (txtEmailEntry.Text == "")
            {
                MessageBox.Show("Field cannot be blank", "Email");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Validate()
        {

        }
    }
}  

