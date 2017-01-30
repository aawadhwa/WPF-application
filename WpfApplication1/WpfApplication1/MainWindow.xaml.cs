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
using System.Xml;
using System.Globalization;
using System.Resources;
using System.IO;
using System.Threading;
using System.Reflection;




namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String language = "english";

        public MainWindow()
        {
            InitializeComponent();
            }
        //Save button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            XmlDocument xmlDoc = new XmlDocument();
           
            if (language == "english")
            {
                if (!File.Exists("C:/Product.xml"))
                {
                    XmlElement root = xmlDoc.DocumentElement;
                    xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                    //Creating a root element
                    XmlNode rootNode = xmlDoc.CreateElement("Products");

                    xmlDoc.AppendChild(rootNode);
                    xmlDoc.Save("C:/Product.xml");
                }
                else
                {
                    //File exists so we can load it
                    xmlDoc.Load("C:/Product.xml");
                }
            }
            else
            {
                if (!File.Exists("C:/Product_German.xml"))
                {
                    XmlElement root = xmlDoc.DocumentElement;
                    xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                    //Creating a root element
                    XmlNode rootNode = xmlDoc.CreateElement("Products");

                    xmlDoc.AppendChild(rootNode);
                    xmlDoc.Save("C:/Product_German.xml");
                }
                else
                {
                    //File exists so we can load it
                    xmlDoc.Load("C:/Product_German.xml");
                }
 
            }

            //Creating sub elements
            XmlNode productSubNode = xmlDoc.CreateElement("Product");
            XmlNode categorySubNode = xmlDoc.CreateElement("Category");
            XmlNode productNameSubNode = xmlDoc.CreateElement("Name");

            XmlNode itemNumberSubNode = xmlDoc.CreateElement("ItemNumber");
            XmlNode from1SubNode = xmlDoc.CreateElement("From");
            XmlNode To1SubNode = xmlDoc.CreateElement("To");
            XmlNode from2SubNode = xmlDoc.CreateElement("From2");
            XmlNode To2SubNode = xmlDoc.CreateElement("To2");

            XmlNode descriptionSubNode = xmlDoc.CreateElement("Description");
            XmlNode orderSubNode = xmlDoc.CreateElement("Order");
            XmlNode telephoneSubNode = xmlDoc.CreateElement("Telephone");
            XmlNode faxSubNode = xmlDoc.CreateElement("Fax");
            XmlNode emailSubNode = xmlDoc.CreateElement("Email");

            if (language == "german")
            {
                categorySubNode.InnerText = ddCategory_german.SelectionBoxItem.ToString();
            }
            else
            {
               categorySubNode.InnerText = ddCategory.SelectionBoxItem.ToString();
            }
            
            productNameSubNode.InnerText = txtProductName.Text;
            from1SubNode.InnerText = txtFromNumber1.Text;
            from2SubNode.InnerText = txtFromNumber2.Text;
            To2SubNode.InnerText = txtToNumber2.Text;
            To1SubNode.InnerText = txtToNumber1.Text;
            descriptionSubNode.InnerText = txtDescription.Text;
            telephoneSubNode.InnerText = txtTelephone.Text;
            emailSubNode.InnerText = txtEmail.Text;
            faxSubNode.InnerText = txtFax.Text;

            itemNumberSubNode.AppendChild(from1SubNode);
            itemNumberSubNode.AppendChild(To1SubNode);
            itemNumberSubNode.AppendChild(from2SubNode);
            itemNumberSubNode.AppendChild(To2SubNode);
            
            orderSubNode.AppendChild(telephoneSubNode);
            orderSubNode.AppendChild(emailSubNode);
            orderSubNode.AppendChild(faxSubNode);

            productSubNode.AppendChild(categorySubNode);
            productSubNode.AppendChild(productNameSubNode);
            productSubNode.AppendChild(itemNumberSubNode);
            productSubNode.AppendChild(descriptionSubNode);
            productSubNode.AppendChild(orderSubNode);

            xmlDoc.DocumentElement.AppendChild(productSubNode);

            if (language == "english")
            {
                xmlDoc.Save("C:/Product.xml");
                MessageBoxResult result = MessageBox.Show("Record saved Successfully", "Confirmation");
            }
            else
            {
                xmlDoc.Save("C:/Product_German.xml");
                MessageBoxResult result = MessageBox.Show("Record saved Successfully in German", "Confirmation");
            }

        }

        //English flag button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            language = "english";
            CultureInfo ci = new CultureInfo("en-US");

            Assembly a = Assembly.Load("WpfApplication1");
            ResourceManager rm = new ResourceManager("WpfApplication1.langEnglish", a);
            lblDescription.Content = rm.GetString("description", ci);
            lblItemNumber.Content = rm.GetString("itemNumber", ci);
            lblFrom1.Content = rm.GetString("from", ci);
            lblFrom2.Content = rm.GetString("from", ci);
            lblTo1.Content = rm.GetString("to", ci);
            lblTo2.Content = rm.GetString("to", ci);
            lblOrderDetails.Content = rm.GetString("orderDetails", ci);
            lblProductName.Content = rm.GetString("productName", ci);
            lblSave.Content = rm.GetString("save", ci);
            lblSelectCategory.Content = rm.GetString("selectCategory", ci);
            lblheading.Content = rm.GetString("heading", ci);
            ddCategory.Visibility = Visibility;
            ddCategory_german.Visibility = Visibility.Collapsed;
            
        }

        //German flag button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            language = "german";
            CultureInfo ci = new CultureInfo("de-AT");

            Assembly a = Assembly.Load("WpfApplication1");
            ResourceManager rm = new ResourceManager("WpfApplication1.lanGerman", a);
            lblDescription.Content = rm.GetString("description", ci);
            lblItemNumber.Content = rm.GetString("itemNumber", ci);
            lblFrom1.Content = rm.GetString("from", ci);
            lblFrom2.Content = rm.GetString("from", ci);
            lblTo1.Content = rm.GetString("to", ci);
            lblTo2.Content = rm.GetString("to", ci);
            lblOrderDetails.Content = rm.GetString("orderDetails", ci);
            lblProductName.Content = rm.GetString("productName", ci);
            lblSave.Content = rm.GetString("save", ci);
            lblSelectCategory.Content = rm.GetString("selectCategory", ci);
            lblheading.Content = rm.GetString("heading", ci);
            ddCategory.Visibility = Visibility.Collapsed;
            ddCategory_german.Visibility = Visibility;


        }


    }
}

