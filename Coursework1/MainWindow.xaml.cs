
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
            List<string> myList = Readfile("..\\..\\countries.txt");
            InitializeComponent();

            // Add each item in the list into the combobox 
            foreach (String item in myList)
            {
                cboCountry.Items.Add(item);
            }

        }

        // ***EVENTS***

        // Clear event that occurs when the button is clicked by the user
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // A blank form is opened and the one currently showing is closed 
            // clearing all data entered by the user
            MainWindow NewForm = new MainWindow();
            NewForm.Show();
            this.Close();

            MessageBox.Show("All data has been cleared");
        }

        // Checkbox event that occurs when  the checkbox "checkYes" is checked by the user
        private void checkYes_Checked(object sender, RoutedEventArgs e)
        {
            // Makes the country field visible to the user since the student is an international student
            lblCountry.Visibility = Visibility.Visible;
            cboCountry.Visibility = Visibility.Visible;
         
            if (checkYes.IsChecked.HasValue && checkNo.IsChecked.Value)
            {
                checkNo.IsChecked = false;
            }
        }

        // Checkbox event that occurs when the checkbox "checkNo" is checked by the user
        private void checkNo_Checked(object sender, RoutedEventArgs e)
        {
            // Hides the country field since the user is not an international student
            lblCountry.Visibility = Visibility.Hidden;
            cboCountry.Visibility = Visibility.Hidden;

            if (checkNo.IsChecked.HasValue && checkYes.IsChecked.Value)
            {
                checkYes.IsChecked = false;
            }
        }
        
        // Button event that validates the student data when the user clicks the button 
        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // When any if statment occurs, an "ArgumentExeption" occurs with a relevant error message 
                if (txtFirstName.Text == "")
                {
                    throw new System.ArgumentException("First Name(s) cannot be left blank");
                }

                if (txtSurname.Text == "")
                {
                    throw new System.ArgumentException("Surname cannot be left blank");
                }

                if (ValidateAge(txtAge.Text) == false)
                {
                    throw new System.ArgumentException("Age must be in the range 16 to 101");
                }

                if (cboCourse.Text == "")
                {
                    throw new System.ArgumentException("Course cannot be left blank");
                }

                if (txtAddress1.Text == "")
                {
                    throw new System.ArgumentException("Address cannot be left blank");
                }

                if (txtCity.Text == "")
                {
                    throw new System.ArgumentException("City cannot be left blank");
                }

                if(txtPostCode.Text == "")
                {
                    throw new System.ArgumentException("Postcode cannot be left blank");
                }

                if (ValidateEmail(txtEmail.Text) == false)
                {
                    throw new System.ArgumentException("Email cannot start or end with a special character, it also must contain a @ symbol");
                }

                if(checkNo.IsChecked.Value == false && checkYes.IsChecked.Value == false)
                {
                    throw new System.ArgumentException("International student must be checked yes or no");
                }

                if ((checkNo.IsChecked.HasValue && checkYes.IsChecked.Value) && cboCountry.Text == "")
                {
                    throw new System.ArgumentException("Country cannot be left blank if a person is a international student");
                }

                if (txtPostCode.Text == "")
                {
                    throw new System.ArgumentException("Postcode cannot be left blank");
                }

                // If no if statments return false then the data entered in the form has been validated
                MessageBox.Show("Validated succesfully");
            }
            // When an error in the form occurs then the data is not validated and the relevant error message is shown
            catch (ArgumentException ex)
                {
                    MessageBox.Show("Data has not been validated");
                    MessageBox.Show(ex.Message);
                }
        }

        // ***METHODS***

        // Read in each line from a text file to create a list of items in an array
        private List<String> Readfile(String filePath)
        {
            List<string> list = new List<string>();
            string[] fileText = System.IO.File.ReadAllLines(filePath);
            list.AddRange(fileText);
            return list;
        }

        /*
        * Method used to validate the email field
        * Returns a boolean value, true or false 
        * Validates that the email does not start or end with a special charcter and contains a '@' symbol
        */
        public static bool ValidateEmail(string str)
        {
            // Method goes through each character in the string passed to the method
            foreach (char c in str)
            {
                // When the first and last character is a letter or digit and the string contains a @ symbol the method returns true
                if ((!char.IsLetterOrDigit(str[0]) && char.IsLetterOrDigit(str[str.Length - 1])) && (str.Contains('@')))
                {
                    return true;
                }
            }
            // Otherwise the method returns false
            return false;
        }

       /*
        * Method used to validate the age field
        * Returns a boolean value, true or false 
        * Validates that the age is a number between 16 and 101
        */
        public static bool ValidateAge(string str)
        {
            try
            {
                // Convert string value into an integer
                int age = Convert.ToInt32(str); 

                // When the is less than 16 and more than 101 then the method return false 
                if ((age < 16) || (age > 101)) 
                {
                    return false;
                }
                // Otherwise return true 
                return true;
            }
            // If an error occurs when parsing the string passed into the method into and interger the method returns false
            catch (FormatException)
            {
                return false;
            }
        }
    }
}