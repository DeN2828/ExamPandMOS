using OpenQA.Selenium;

namespace Olxparser;

public partial class MainPage : ContentPage
{
    IWebDriver browser;
    List<Objavi> result;
	public MainPage()
	{
        InitializeComponent();
    
        
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{

        Search searcher = new Search();
        result = searcher.start(textField.Text);
        field.Text = "";
        foreach(Objavi a in result)
        {

            field.Text += a.name + "\n" + a.city + "\n " + a.price + "\n" + a.sillka + "\n" + "-------------------------------------";
            


        }
    }
}


