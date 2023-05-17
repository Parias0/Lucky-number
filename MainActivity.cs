using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace luckynumber
{
    [Activity(Label = "Random Number App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private TextView randomNumberTextView;
        private SeekBar rangeSeekBar;
        private Button rollButton;

        private int minRange = 1;
        private int maxMultiplier = 10;

        private Random random;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Ustawienie widoku dla MainActivity
            SetContentView(Resource.Layout.activity_main);

            // Inicjalizacja komponentów interfejsu użytkownika
            randomNumberTextView = FindViewById<TextView>(Resource.Id.randomNumberTextView);
            rangeSeekBar = FindViewById<SeekBar>(Resource.Id.rangeSeekBar);
            rollButton = FindViewById<Button>(Resource.Id.rollButton);

            // Inicjalizacja generatora liczb losowych
            random = new Random();

            // Ustawienie wartości początkowej dla zakresu w przesuwniku
            rangeSeekBar.Progress = minRange - 1;
            rangeSeekBar.Max = maxMultiplier;

            // Obsługa zdarzenia zmiany wartości przesuwnika
            rangeSeekBar.ProgressChanged += RangeSeekBar_ProgressChanged;

            // Obsługa kliknięcia przycisku "Roll"
            rollButton.Click += RollButton_Click;
        }

        private void RangeSeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            // Aktualizacja wartości minimalnej i maksymalnej zakresu
            minRange = 1;
            maxMultiplier = rangeSeekBar.Progress + 1;

            // Aktualizacja tekstu na ekranie
            randomNumberTextView.Text = string.Empty;
        }

        private void RollButton_Click(object sender, EventArgs e)
        {
            // Wylosowanie liczby z wybranego zakresu
            int randomNumber = random.Next(minRange, minRange + (maxMultiplier * 10));

            // Wyświetlenie wylosowanej liczby na ekranie
            randomNumberTextView.Text = randomNumber.ToString();
        }
    }
}
