using OpenQA.Selenium;

namespace olxParsFin;

public partial class MainPage : ContentPage
{
    List<Objavi> result;
    public MainPage()
    {
        InitializeComponent();


    }

    private void OnCounterClicked(object sender, EventArgs e)
    {

        Search searcher = new Search();
        result = searcher.start(textField.Text,priceFrom.Text,priceTo.Text,filtr.SelectedIndex);
        field.Text = "";
        foreach (Objavi a in result)
        {

            field.Text += a.name + "\n" + a.city + "\n " + a.price + "\n" + a.sillka + "\n" + "-------------------------------------";



        }
    }

    void priceTo_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        try
        {
            int.Parse(priceTo.Text);
            priceTo.BackgroundColor = Colors.Blue;


        }
        catch
        {
            priceTo.BackgroundColor = Colors.Red;
        }
    }

    void priceFrom_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        try
        {
            int.Parse(priceFrom.Text);
            priceFrom.BackgroundColor = Colors.Blue;


        }
        catch
        {
            priceFrom.BackgroundColor = Colors.Red;
        }
    }
}


