using Android.App;
using Android.Widget;
using Android.OS;
using System;
using AndriodXamarinTipCalculator;
using Java.Math;

namespace TipCalculator
{
    [Activity(Label = "Tip Calculator", MainLauncher = true, Icon = "@mipmap/icon2")]
    public class MainActivity : Activity
    {
        //int count = 1;

        EditText inputBill;
        EditText inputTipPercent;
        EditText inputTax;
        EditText inputSplitBy;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;
        TextView outputBillAmount;
        TextView outputGrandTotal;
        TextView outputGrandTotalTip;
        TextView outputAllTip;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //must call
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            inputTipPercent = FindViewById<EditText>(Resource.Id.inputTipPercent);
            inputTax = FindViewById<EditText>(Resource.Id.inputTax);
            inputSplitBy = FindViewById<EditText>(Resource.Id.inputSplitBy);

            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            calculateButton.Click += OnCalculateClick;

            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
            outputBillAmount = FindViewById<TextView>(Resource.Id.outputBillAmount);
            outputGrandTotal = FindViewById<TextView>(Resource.Id.outputGrandTotal);
            outputGrandTotalTip = FindViewById<TextView>(Resource.Id.outputGrandTotalTip);
            outputAllTip = FindViewById<TextView>(Resource.Id.outputAllTip);
        }

        void OnCalculateClick(object sender, EventArgs e)
        {
            try
            {
                string text = inputBill.Text;
                var bill = double.Parse(text);
                string tippercenttext = inputTipPercent.Text;
                var tippercent = (double.Parse(tippercenttext)) * 0.01;

                string texttax = inputTax.Text;
                var tax = double.Parse(texttax);
                string splittext = inputSplitBy.Text;
                var split = double.Parse(splittext);

                if (tax != 0)
                {
                    bill = bill + (bill * (tax*0.01));

                    var tip = bill * tippercent;

                    var total = bill + tip;

                    outputTip.Text = (Math.Round((tip / split), 2)).ToString();
                    outputTotal.Text = (Math.Round((total / split), 2)).ToString();
                    outputBillAmount.Text = (Math.Round((bill / split), 2)).ToString();

                    outputGrandTotal.Text= (Math.Round((bill), 2)).ToString();
                    outputGrandTotalTip.Text = (Math.Round((total), 2)).ToString();
                    outputAllTip.Text = (Math.Round((total-bill), 2)).ToString();
                }
                else
                {
                    var tip = bill * tippercent;

                    var total = bill + tip;

                    outputTip.Text = (Math.Round((tip / split), 2)).ToString();
                    outputTotal.Text = (Math.Round((total / split), 2)).ToString();
                    outputBillAmount.Text = (Math.Round((bill / split), 2)).ToString();

                    outputGrandTotal.Text = (Math.Round((bill), 2)).ToString();
                    outputGrandTotalTip.Text = (Math.Round((total), 2)).ToString();
                    outputAllTip.Text = (Math.Round((total - bill), 2)).ToString();
                }
               
            }
            catch
            {

            }
            
        }
    }
}

