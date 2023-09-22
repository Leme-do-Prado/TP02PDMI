namespace TarefasApp;

public partial class TaskEditingPage : ContentPage
{
    private Task task;

    public TaskEditingPage(Task task)
    {
        InitializeComponent();
        this.task = task;
        BindingContext = task;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (task != null)
        {
            task.taskTitle = titleEntry.Text;
            task.taskDescription = descriptionEntry.Text;
            task.CreationDate = creationDatePicker.Date;
            task.Priority = priorityPicker.SelectedItem as string;

            BindingContext = null;
            BindingContext = task;
        }

        await Navigation.PopModalAsync();
    }
}