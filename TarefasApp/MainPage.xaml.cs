using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TarefasApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Task> tasks;

        public MainPage(ObservableCollection<Task> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            tasks.Add(new Task { taskTitle = "Aspirador", taskDescription = "Passar aspirador na sala", CreationDate = DateTime.Now, Priority = "Média" });
            tasks.Add(new Task { taskTitle = "Leitura", taskDescription = "Ler Ensaio Sobre a Cegueira", CreationDate = DateTime.Now, Priority = "Baixa" });
            tasks.Add(new Task { taskTitle = "TP03", taskDescription = "Entregar TP03", CreationDate = DateTime.Now, Priority = "Alta" });
            taskListView.ItemsSource = tasks;
        }

        public void addToTaskList(Task task)
        {
            tasks.Add(task);
        }

        private void OnTaskItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Task selectedTask)
            {
                Navigation.PushAsync(new TaskDetailPage(selectedTask, tasks));
            }

                    ((ListView)sender).SelectedItem = null;
        }

        private async void OnAddTaskButtonClicked(object sender, EventArgs e)
        {
            var addTaskPage = new TaskAddingPage(tasks);
            await Navigation.PushModalAsync(new NavigationPage(addTaskPage));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}