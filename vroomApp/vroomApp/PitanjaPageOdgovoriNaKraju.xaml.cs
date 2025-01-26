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
            // Create a container for each question
            var questionStack = new StackLayout
            {
                Padding = new Thickness(20),
                Spacing = 10,
                Margin = new Thickness(0, 10, 0, 10)
            };

            // Add the question text
            var questionLabel = new Label
            {
                Text = question.Text,
                FontSize = 20,
                FontFamily = "LeagueSpartanBold",
                TextColor = Color.FromArgb("#052d61"),
                HorizontalOptions = LayoutOptions.Start
            };
            questionStack.Children.Add(questionLabel);

            // Add RadioButtons for each option
            var optionsGroup = new StackLayout
            {
                Spacing = 5
            };

            foreach (var option in new[] { question.OptionA, question.OptionB, question.OptionC, question.OptionD })
            {
                var radioButton = new RadioButton
                {
                    Content = option,
                    FontSize = 18,
                    FontFamily = "LeagueSpartanRegular",
                    TextColor = Color.FromArgb("#052d61"),
                    GroupName = $"Question_{question.Id}" // Unique group for each question
                };

                // Attach event to capture the selected answer
                radioButton.CheckedChanged += (sender, e) =>
                {
                    if (e.Value) // When selected
                    {
                        userAnswers[question.Id] = option;
                    }
                };

                optionsGroup.Children.Add(radioButton);
            }

            questionStack.Children.Add(optionsGroup);

            // Add the question container to the main layout
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
