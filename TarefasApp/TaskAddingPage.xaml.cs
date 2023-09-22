using System.Collections.ObjectModel; 
namespace TarefasApp
{
    public partial class TaskAddingPage : ContentPage
    {
        private ObservableCollection<Task> tasks; 

        public TaskAddingPage(ObservableCollection<Task> tasks)
        {
            InitializeComponent();
            this.tasks = tasks; 
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            Task newTask = new Task
            {
                taskTitle = titleEntry.Text,
                taskDescription = descriptionEntry.Text,
                CreationDate = creationDatePicker.Date,
                Priority = priorityPicker.SelectedItem as string
            };

            tasks.Add(newTask); 

            await Navigation.PopModalAsync();
        }
    }
}