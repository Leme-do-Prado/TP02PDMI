using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TarefasApp
{
    public partial class TaskDetailPage : ContentPage
    {
        private Task task;
        private ObservableCollection<Task> tasks;

        public TaskDetailPage(Task task, ObservableCollection<Task> tasks)
        {
            InitializeComponent();
            this.task = task;
            this.tasks = tasks; 
            BindingContext = task;
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
                var editPage = new TaskEditingPage(task);
                await Navigation.PushModalAsync(new NavigationPage(editPage));

        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirmação", "Tem certeza de que deseja excluir esta tarefa?", "Sim", "Cancelar");

            if (answer)
            {
                if (BindingContext is Task taskToDelete)
                {
                    tasks.Remove(taskToDelete);

                    OnPropertyChanged(nameof(tasks));
                }

                await Navigation.PopAsync();
            }
        }
    }
}