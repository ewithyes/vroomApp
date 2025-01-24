namespace vroomApp;
using vroomApp.Podaci;
public partial class PitanjaPageOdgovoriNaKraju : ContentPage
{
    private List<Question> questions;
    private Dictionary<int, string> userAnswers = new();

    public PitanjaPageOdgovoriNaKraju(List<Question> questions)
    {
        InitializeComponent();
        this.questions = questions;
        DisplayQuestions();
    }

    private void DisplayQuestions()
    {
        foreach (var question in questions)
        {
            var questionStack = new StackLayout { Padding = 10 };

            var questionLabel = new Label
            {
                Text = question.Text,
                FontSize = 24,
                Margin = new Thickness(0, 10, 0, 10)
            };
            questionStack.Children.Add(questionLabel);

            foreach (var option in new[] { question.OptionA, question.OptionB, question.OptionC, question.OptionD })
            {
                var button = new Button { Text = option };
                button.Clicked += (sender, args) =>
                {
                    userAnswers[question.Id] = (sender as Button).Text;
                };
                questionStack.Children.Add(button);
            }

            QuestionsLayout.Children.Add(questionStack);
        }
    }

    private void OnFinishQuizClicked(object sender, EventArgs e)
    {
        int correctCount = 0;

        foreach (var question in questions)
        {
            if (userAnswers.TryGetValue(question.Id, out string userAnswer) &&
                userAnswer == question.CorrectAnswer)
            {
                correctCount++;
            }
        }

        DisplayAlert("Rezultat", $"Tačnih odgovora: {correctCount}/{questions.Count}", "OK");
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
