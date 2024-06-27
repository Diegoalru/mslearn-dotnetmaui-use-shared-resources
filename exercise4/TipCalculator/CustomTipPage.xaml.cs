namespace TipCalculator;

public partial class CustomTipPage
{
    public CustomTipPage()
    {
        InitializeComponent();

        BillInput.TextChanged += (_, _) => CalculateTip(false, false);
        RoundDown.Clicked += (_, _) => CalculateTip(false, true);
        RoundUp.Clicked += (_, _) => CalculateTip(true, false);

        TipPercentSlider.ValueChanged += (_, e) =>
        {
            var pct = Math.Round(e.NewValue);
            TipPercent.Text = $"{pct}%";
            CalculateTip(false, false);
        };
    }

    private void CalculateTip(bool roundUp, bool roundDown)
    {
        if (!double.TryParse(BillInput.Text, out var t) || !(t > 0)) return;

        var pct = Math.Round(TipPercentSlider.Value);
        var tip = Math.Round(t * (pct / 100.0), 2);

        var final = t + tip;

        if (roundUp)
        {
            final = Math.Ceiling(final);
            tip = final - t;
        }
        else if (roundDown)
        {
            final = Math.Floor(final);
            tip = final - t;
        }

        TipOutput.Text = tip.ToString("C");
        TotalOutput.Text = final.ToString("C");
    }

    private void OnNormalTip(object sender, EventArgs e)
    {
        TipPercentSlider.Value = 15;
    }

    private void OnGenerousTip(object sender, EventArgs e)
    {
        TipPercentSlider.Value = 20;
    }
}