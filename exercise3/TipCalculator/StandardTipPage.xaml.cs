namespace TipCalculator;

public partial class StandardTipPage : ContentPage
{
    private readonly Color _colorNavy = Colors.Navy;
    private readonly Color _colorSilver = Colors.Silver;

    public StandardTipPage()
    {
        InitializeComponent();
        BillInput.TextChanged += (_, _) => CalculateTip();
    }

    private void CalculateTip()
    {
        if (!double.TryParse(BillInput.Text, out var bill) || !(bill > 0)) return;

        var tip = Math.Round(bill * 0.15, 2);
        var final = bill + tip;

        TipOutput.Text = tip.ToString("C");
        TotalOutput.Text = final.ToString("C");
    }

    private void OnLight(object sender, EventArgs e)
    {
        Resources["FgColor"] = _colorNavy;
        Resources["BgColor"] = _colorSilver;
    }

    private void OnDark(object sender, EventArgs e)
    {
        Resources["FgColor"] = _colorSilver;
        Resources["BgColor"] = _colorNavy;
    }

    private async void GotoCustom(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CustomTipPage));
    }
}