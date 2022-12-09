using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VeterinaryClinic.Models;

namespace VeterinaryClinic
{
    public partial class MainWindow : Window
    {
        private VeterinaryClinic clinic;
        public MainWindow()
        {
            InitializeComponent();
            clinic = new VeterinaryClinic();
            if (!clinic.Clients.Any())
            {
                Client client = new Client() { Name = "Dmytro", Surname = "Sushchyk", TypeOfAnimal = "Cat", DateOfBirth = new DateTime(2020, 1, 2), Diagnosis = "Examination" };
                client.Appointments = new List<Appointment>();
                client.Appointments.Add(new Appointment() { DateOfAppointment = new DateTime(2022, 12, 17) });
                clinic.Clients.Add(client);
                clinic.SaveChanges();
            }
            Clients.ItemsSource = clinic.Clients.Include("Appointments").ToList();
        }

        private void Clients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() => 
                { 
                    Client client = Clients.SelectedItem as Client;
                    AppointmentsGrid.ItemsSource = client.Appointments.ToList();
                });
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    int day = int.Parse(DaySet.Text);
                    DaySet.Text = "";
                    int month = int.Parse(MonthSet.Text);
                    MonthSet.Text = "";
                    int year = int.Parse(YearSet.Text);
                    YearSet.Text = "";
                    int hour = int.Parse(HourSet.Text);
                    HourSet.Text = "";
                    int minute = int.Parse(MinuteSet.Text);
                    MinuteSet.Text = "";

                    Client client = Clients.SelectedItem as Client;
                    clinic.Clients.Where(c => c.Client_Id == client.Client_Id).FirstOrDefault().Appointments.Add(new Appointment() { DateOfAppointment = new DateTime(year, month, day, hour, minute, 0) });
                    clinic.SaveChanges();

                    AppointmentsGrid.ItemsSource = client.Appointments.ToList();

                });
            });
            AddAppointment.Visibility = Visibility.Hidden;
        }

        private void AddApp_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    string name = NameSet.Text;
                    NameSet.Text = "";
                    string surname = SurnameSet.Text;
                    SurnameSet.Text = "";
                    string type = TypeSet.Text;
                    TypeSet.Text = "";
                    string diagnos = DiagnosisSet.Text;
                    DiagnosisSet.Text = "";

                    int day = int.Parse(DayBSet.Text);
                    DayBSet.Text = "";
                    int month = int.Parse(MonthBSet.Text);
                    MonthBSet.Text = "";
                    int year = int.Parse(YearBSet.Text);
                    YearBSet.Text = "";

                    Client client = new Client() { Name = name, Surname = surname, TypeOfAnimal = type, DateOfBirth = new DateTime(year, month, day), Diagnosis = diagnos };
                    clinic.Clients.Add(client);
                    clinic.SaveChanges();

                    Clients.ItemsSource = clinic.Clients.Include("Appointments").ToList();
                });
            });
            AddClient.Visibility = Visibility.Hidden;
        }

        private void AddCl_Click(object sender, RoutedEventArgs e)
        {
            AddClient.Visibility = Visibility.Visible;
        }
    }
}
