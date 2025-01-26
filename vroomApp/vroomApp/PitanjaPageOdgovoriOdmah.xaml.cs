namespace vroomApp;

using Microsoft.Maui;
using vroomApp.Podaci;

public partial class PitanjaPageOdgovoriOdmah : ContentPage
{
    private int currentQuestionIndex = 0;
    private List<Question> questions;
    private string selectedAnswer;

    public PitanjaPageOdgovoriOdmah(List<Question> questions)
    {
        InitializeComponent();
        this.questions = questions;
        ShowQuestion();
    }

    private void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            var question = questions[currentQuestionIndex];
            QuestionLabel.Text = question.Text;

            // Assign options to radio buttons
            OptionARadioButton.Content = question.OptionA;
            OptionBRadioButton.Content = question.OptionB;
            OptionCRadioButton.Content = question.OptionC;
            OptionDRadioButton.Content = question.OptionD;

            // Reset selection
            OptionARadioButton.IsChecked = false;
            OptionBRadioButton.IsChecked = false;
            OptionCRadioButton.IsChecked = false;
            OptionDRadioButton.IsChecked = false;
            selectedAnswer = null;
        }
        else
        {
            DisplayAlert("Kviz završen", "Odgovorili ste na sva pitanja!", "OK");
            Navigation.PopModalAsync();
        }
    }

    private void OnOptionSelected(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value) // If a radio button is checked
        {
            var radioButton = sender as RadioButton;
            selectedAnswer = radioButton.Content.ToString();        }
    }

    private void OnNextQuestionClicked(object sender, EventArgs e)
    {
        var correctAnswer = questions[currentQuestionIndex].CorrectAnswer;

        if (selectedAnswer == correctAnswer)
            DisplayAlert("Tačno!", "Odabrali ste tačan odgovor.", "Dalje");
        else
            DisplayAlert("Netačno", $"Tačan odgovor je: {correctAnswer}", "Dalje");

        currentQuestionIndex++;
        ShowQuestion();
    }
    private async void OnVroomTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new HomePage());
    }
    private async void OnProfilTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilPage());
    }

}
