using Microsoft.Maui.Controls;

namespace CounterApp;

public partial class MainPage : ContentPage
{
    private int counterId = 1;

    public MainPage()
    {
        InitializeComponent();
        AddCounter($"Counter {counterId}");
    }

    private void AddCounterButtonClicked(object sender, EventArgs e)
    {
        counterId++;
        AddCounter($"Counter {counterId}");
    }

    private void AddCounter(string title)
    {
        var counterLayout = new VerticalStackLayout
        {
            Spacing = 10,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start
        };

        var counterLabel = new Label
        {
            Text = title,
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 16
        };

        var valueLabel = new Label
        {
            Text = "0",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 20,
            WidthRequest = 100, // Zwiększono szerokość
            HorizontalTextAlignment = TextAlignment.Center
        };

        var buttonLayout = new HorizontalStackLayout
        {
            Spacing = 10,
            HorizontalOptions = LayoutOptions.Center
        };

        var decrementButton = new Button
        {
            Text = "-",
            WidthRequest = 50
        };

        var incrementButton = new Button
        {
            Text = "+",
            WidthRequest = 50
        };

        decrementButton.Clicked += (s, e) =>
        {
            int currentValue = int.Parse(valueLabel.Text);
            valueLabel.Text = (currentValue - 1).ToString();
        };

        incrementButton.Clicked += (s, e) =>
        {
            int currentValue = int.Parse(valueLabel.Text);
            valueLabel.Text = (currentValue + 1).ToString();
        };

        buttonLayout.Children.Add(decrementButton);
        buttonLayout.Children.Add(incrementButton);

        counterLayout.Children.Add(counterLabel);
        counterLayout.Children.Add(valueLabel);
        counterLayout.Children.Add(buttonLayout);

        CounterList.Children.Add(counterLayout);
    }
}
