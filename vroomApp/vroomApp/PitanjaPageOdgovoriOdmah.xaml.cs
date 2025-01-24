namespace vroomApp;
using vroomApp.Podaci;
public partial class PitanjaPageOdgovoriOdmah: ContentPage
{
    private int currentQuestionIndex = 0;
    private List<Question> questions;

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
            OptionAButton.Text = question.OptionA;
            OptionBButton.Text = question.OptionB;
            OptionCButton.Text = question.OptionC;
            OptionDButton.Text = question.OptionD;
        }
        else
        {
            DisplayAlert("Kviz završen", "Odgovorili ste na sva pitanja!", "OK");
            Navigation.PopModalAsync();
        }
    }

    private void OnOptionClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var selectedAnswer = button.Text;
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
