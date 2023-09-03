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
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace ProizbodPrakt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ID;
        string pass_S;
        int id1;
        bool boolean;
        MySqlConnection conn = new MySqlConnection("host = localhost; user = Drakyla7936; password = 12345; database = ukadr");
        public MainWindow()
        {
            InitializeComponent();

            Border_1.Visibility = Visibility.Visible;
            Border_2.Visibility = Visibility.Hidden;
            Border_3.Visibility = Visibility.Hidden;
            Border_4.Visibility = Visibility.Hidden;
            Border_5.Visibility = Visibility.Hidden;
            Border_Menu.Visibility = Visibility.Hidden;
            Border_pass.Visibility = Visibility.Hidden;
            Border_Zad.Visibility = Visibility.Hidden;
            Border_izm.Visibility = Visibility.Hidden;
            Border_izm1.Visibility = Visibility.Hidden;
            Border_Otchet.Visibility = Visibility.Hidden;
            Border_Otchet1.Visibility = Visibility.Hidden;
            id_ZAD.Visibility = Visibility.Hidden;
            srok.Visibility = Visibility.Collapsed;
            date.Visibility = Visibility.Hidden;
            obrazovanie.Visibility = Visibility.Hidden;
            staj_R.Visibility = Visibility.Hidden;
            zadach.Visibility = Visibility.Hidden;
            sotr.Visibility = Visibility.Hidden;
            vplt.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Border_1.Visibility = Visibility.Hidden;
            Border_2.Visibility = Visibility.Visible;
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            Border_2.Visibility = Visibility.Hidden;
            Border_1.Visibility = Visibility.Visible;
        }
        public int st;
        private void Avtoz_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"select сотрудники.Логин,статус_сотрудника.Уровень_допуска,сотрудники.id,сотрудники.Должность from сотрудники,статус_сотрудника  where Логин = '{login.Text}' and Пароль = '{Pass.Password}' and сотрудники.статус = статус_сотрудника.id", conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                MessageBox.Show($"Добро пожаловать !  {rdr[0]}");
                id1 = Convert.ToInt32(rdr[2]);
                switch (Convert.ToInt16(rdr[1]))
                {
                    case 1:
                        boolean = true;
                        st = 1; SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; redactor_infa.Visibility = Visibility.Visible; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden;
                        Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Borderr_4.Visibility = Visibility.Collapsed;
                        status.Content = "Статус: `Сотрудник`";
                        break;
                    case 2:
                        boolean = true;
                        st = 2; SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden; redactor_infa.Visibility = Visibility.Visible;
                        Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Borderr_4.Visibility = Visibility.Visible;
                        vpl.Visibility = Visibility.Visible;
                        stat.Visibility = Visibility.Hidden;
                        status.Content = "Статус: `Модератор`";
                        break;
                    case 3:
                        boolean = true;
                        st = 3; SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden; redactor_infa.Visibility = Visibility.Visible;
                        Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Borderr_4.Visibility = Visibility.Visible;
                        vpl.Visibility = Visibility.Hidden;
                        status.Content = "Статус: `Администратор`";
                        break;
                    case 4:
                        status.Content = "Статус: `Стажер`";
                        Borderr_4.Visibility = Visibility.Collapsed;
                        st = 0;
                        conn.Close();
                        MySqlCommand cmd1 = new MySqlCommand($"select Годржд,Образование,Опыт from допинф where сотрудник = '{id1}'", conn);
                        conn.Open();
                        MySqlDataReader reader = cmd1.ExecuteReader();

                        reader.Read();
                        if (reader.HasRows)
                        {
                            boolean = true;
                            SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden;
                            Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                            Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                            Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        }
                        else
                        {
                            boolean = false;
                            Zadachi.Background = Brushes.Gray;
                            Izmen.Background = Brushes.Gray;
                            Otchet.Background = Brushes.Gray;
                            SAVE.Visibility = Visibility.Visible; create_infa.Visibility = Visibility.Visible; infa.Visibility = Visibility.Collapsed; date.Visibility = Visibility.Visible; obrazovanie.Visibility = Visibility.Visible; staj_R.Visibility = Visibility.Visible; redactor_infa.Visibility = Visibility.Collapsed;

                        }
                        reader.Close();
                        conn.Close();
                        break;
                }
                Border_2.Visibility = Visibility.Hidden;
                Border_1.Visibility = Visibility.Hidden;
                Border_Menu.Visibility = Visibility.Visible;
                Border_3.Visibility = Visibility.Visible;
                Border_infa.Visibility = Visibility.Hidden;
                Border_izm.Visibility = Visibility.Hidden;
                Border_izm1.Visibility = Visibility.Hidden;
                /*if (Convert.ToInt32(rdr[3]) == 2) 
                {
                    panel18.Visible = true;
                }*/
            }
            else
            {
                MessageBox.Show($"Не верный логин или пароль !");
                login.Background = Brushes.LightCoral;
                Pass.Background = Brushes.LightCoral;
            }
            rdr.Close();
            conn.Close();
        }

        private void Sotrudnik_Click(object sender, RoutedEventArgs e)
        {
            Border_4.Visibility = Visibility.Visible;
            Border_5.Visibility = Visibility.Visible;
            Border_Zad.Visibility = Visibility.Hidden;
            Border_izm.Visibility = Visibility.Hidden;
            Border_izm1.Visibility = Visibility.Hidden;
            Border_Otchet.Visibility = Visibility.Hidden;
            Border_Otchet1.Visibility = Visibility.Hidden;
            srok.Visibility = Visibility.Hidden;
            zadach.Visibility = Visibility.Hidden;
            sotr.Visibility = Visibility.Hidden;
            vplt.Visibility = Visibility.Hidden;
            if (boolean)
            {
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
                Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            }
            else
            {
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
                Zadachi.Background = Brushes.Gray;
                Izmen.Background = Brushes.Gray;
                Otchet.Background = Brushes.Gray;
                zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            }
            if (st == 0)
            {
                srok.Visibility = Visibility.Visible;
            }

                MySqlCommand cmd = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,Зарплата,график.Название,Логин,Пароль from сотрудники,график,должности where Логин = '{login.Text}' and Пароль = '{Pass.Password}' and сотрудники.График = график.id and сотрудники.Должность = должности.id", conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                if (reader.HasRows)
                {
                    id.Content = $"ID: {Convert.ToString(reader[0])}";
                    log.Content = $"Логин: {Convert.ToString(reader[5])}";
                    fio.Content = $"ФИО: {Convert.ToString(reader[1])}";
                    dolj.Content = $"Должность: {Convert.ToString(reader[2])}";
                    zarp.Content = $"Зарплата: {Convert.ToString(reader[3])} Руб.";
                    graf.Content = $"График: {Convert.ToString(reader[4])}";
                    ID = Convert.ToString(reader[0]);
                    pass_S = Convert.ToString(reader[6]);

                }

                reader.Close();
                conn.Close();
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Border_1.Visibility = Visibility.Visible;
            Border_3.Visibility = Visibility.Hidden;
            Border_4.Visibility = Visibility.Hidden;
            Border_5.Visibility = Visibility.Hidden;
            Border_pass.Visibility = Visibility.Hidden;
            Border_Menu.Visibility = Visibility.Hidden;
            Border_izm1.Visibility = Visibility.Hidden;
            Border_Otchet.Visibility = Visibility.Hidden;
            Border_Otchet1.Visibility = Visibility.Hidden;
            zadach.Visibility = Visibility.Hidden;
            sotr.Visibility = Visibility.Hidden;
            vplt.Visibility = Visibility.Hidden;
            if (boolean)
            {
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            }
            else
            {
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Zadachi.Background = Brushes.Gray;
                Izmen.Background = Brushes.Gray;
                Otchet.Background = Brushes.Gray;
            }
            date.Text = "";
            obrazovanie.Text = "";
            staj_R.Text = "";
            login.Text = "";
            Pass.Password = "";
            login.Background = Brushes.Transparent;
            Pass.Background = Brushes.Transparent;

        }

        private void Zadachi_Click(object sender, RoutedEventArgs e)
        {
            if (!boolean)
            {
                MessageBox.Show("Добавьте информацию о себе!");
            }
            else
            {
                Border_4.Visibility = Visibility.Hidden;
                Border_5.Visibility = Visibility.Hidden;
                Border_infa.Visibility = Visibility.Hidden;
                Border_pass.Visibility = Visibility.Hidden;
                Border_Zad.Visibility = Visibility.Visible;
                Border_izm.Visibility = Visibility.Hidden;
                Border_izm1.Visibility = Visibility.Hidden;
                Border_Otchet.Visibility = Visibility.Hidden;
                Border_Otchet1.Visibility = Visibility.Hidden;
                Border_Otchet.Visibility = Visibility.Hidden;
                Border_Otchet1.Visibility = Visibility.Hidden;
                zadach.Visibility = Visibility.Hidden;
                sotr.Visibility = Visibility.Hidden;
                vplt.Visibility = Visibility.Hidden;
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Zadachi.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
                Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                conn.Close();
                MySqlCommand cmd = new MySqlCommand($"select задачи.id,Дата,задачи.Название,статус_задачи.Статус from задачи,статус_задачи where задачи.Статус = статус_задачи.id and задачи.Назначен = {id1}", conn);
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                datagrid1.DataContext = dt;
            }
        }

        private void infa_Click(object sender, RoutedEventArgs e)
        {
            Border_infa.Visibility = Visibility.Visible;
            Border_5.Visibility = Visibility.Hidden;
            Border_pass.Visibility = Visibility.Hidden;
            date.Visibility = Visibility.Hidden;
            obrazovanie.Visibility = Visibility.Hidden;
            staj_R.Visibility = Visibility.Hidden;
            if (st == 0)
            {
                srok.Visibility = Visibility.Visible;
                srok.Content = "Срок тестирования: 1 Месяц";
            }
            conn.Close();
            MySqlCommand cmd = new MySqlCommand($"select Годржд,Образование,Опыт from допинф where сотрудник = '{ID}'", conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
            {
                god.Content = $"Год Рождения: {Convert.ToString(reader[0])}";
                obraz.Content = $"Образование: {Convert.ToString(reader[1])}";
                opit.Content = $"Опыт работы: {Convert.ToString(reader[2])}";
            }
            reader.Close();
            conn.Close();
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Border_5.Visibility = Visibility.Visible;
            Border_infa.Visibility = Visibility.Hidden;
        }

        private void redactor_Click(object sender, RoutedEventArgs e)
        {
            Border_5.Visibility = Visibility.Hidden;
            Border_infa.Visibility = Visibility.Hidden;
            Border_pass.Visibility = Visibility.Visible;
            date.Visibility = Visibility.Hidden;
            obrazovanie.Visibility = Visibility.Hidden;
            staj_R.Visibility = Visibility.Hidden;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (Pass_S.Password == pass_S & Pass_S.Password != Pass_N.Password & Pass_S.Password != "" & Pass_N.Password != "")
            {
                MySqlCommand cmd = new MySqlCommand($"update сотрудники set Пароль = '{Pass_N.Password}' where id = '{Convert.ToInt32(ID)}'", conn);
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Пароль был успешно изменен изменен :)");
                }
                conn.Close();
            }
            else if (Pass_S.Password != pass_S)
            {
                Pass_S.ToolTip = "Не совпадает со старым паролем";
                Pass_S.Background = Brushes.LightCoral;
                return;
            }
            else
            {
                Pass_N.ToolTip = "Такой пароль уже существует";
                Pass_S.Background = Brushes.LightCoral;
                return;
            }

        }

        private void Viviod_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"select Описание from задачи where id = '{id_Text.Text}'", conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            FlowDocument doc = new FlowDocument();
            Paragraph par = new Paragraph();
            if (id_Text.Text != "")
            {
                par.Inlines.Add(new Run(Convert.ToString(reader[0])));
                doc.Blocks.Add(par);
                opisanie.Document = doc;
            }
            else
            {
                id_Text.ToolTip = "Выберите номер задачи";
                id_Text.Background = Brushes.LightCoral;
            }
            reader.Close();
            conn.Close();
        }

        private void Izmen_Click(object sender, RoutedEventArgs e)
        {

            if (!boolean)
            {
                MessageBox.Show("Добавьте информацию о себе!");
            }
            else
            {
                Border_4.Visibility = Visibility.Hidden;
                Border_5.Visibility = Visibility.Hidden;
                Border_infa.Visibility = Visibility.Hidden;
                Border_pass.Visibility = Visibility.Hidden;
                Border_Zad.Visibility = Visibility.Hidden;
                Border_izm.Visibility = Visibility.Visible;
                Border_Otchet.Visibility = Visibility.Hidden;
                Border_Otchet1.Visibility = Visibility.Hidden;
                zadach.Visibility = Visibility.Hidden;
                sotr.Visibility = Visibility.Hidden;
                vplt.Visibility = Visibility.Hidden;
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Izmen.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
                Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                if (st > 1)
                {
                    MySqlCommand cmd = new MySqlCommand($"SELECT id, Название, Описание FROM изменения where Сотрудник = '{id1}' ", conn);
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    datagrid2.DataContext = dt;
                    Border_izm1.Visibility = Visibility.Visible;
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand($"SELECT id, Название, Описание FROM изменения where Сотрудник = '{id1}' ", conn);
                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    datagrid2.DataContext = dt;
                }
            }

        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (Check_user())
                return;
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO `сотрудники` (`ФИО`, `Логин`, `Пароль`,`Статус`) VALUES ('{FIO.Text}', '{login_R.Text}', '{Pass_R1.Password}','4');", conn);
            if (Pass_R1.Password == Pass_R2.Password & Pass_R1.Password != "" & Pass_R2.Password != "")
            {
                conn.Close();
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Регистрация прошла успешно !");
                    Border_2.Visibility = Visibility.Hidden;
                    Border_1.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
                conn.Close();
            }
            else if (Pass_R1.Password != Pass_R2.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                Pass_R1.Background = Brushes.LightCoral;
                Pass_R2.Background = Brushes.LightCoral;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        public Boolean Check_user()
        {
            MySqlCommand cmd_8 = new MySqlCommand($"SELECT * FROM ukadr.сотрудники where Логин = '{login_R.Text}';", conn);
            conn.Open();
            MySqlDataReader rdr = cmd_8.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                MessageBox.Show($"Такой Логин уже существует, создайте другой");
                login_R.Background = Brushes.LightCoral;
                return true;
            }
            else
            {
                return false;
            }
            conn.Close();
        }

        private void dobavit_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            TextRange op1 = new TextRange(opisanie1.Document.ContentStart, opisanie1.Document.ContentEnd);
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO `ukadr`.`изменения` (`Название`, `Описание`, `Сотрудник`) VALUES ('{N_Text.Text}', '{op1.Text}', '{Convert.ToInt32(id_Text1.Text)}');", conn);
            conn.Open();
            if (st == 2)
            {
                MySqlCommand cmd1 = new MySqlCommand($"select Статус from сотрудники where id = {Convert.ToInt32(id_Text1.Text)}", conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader[0]) >= 2)
                    {
                        a++;
                        MessageBox.Show("Нет доступа");
                        break;
                    }
                }
                reader.Close();
            }
            else { cmd.ExecuteNonQuery(); }
            if (a == 0) { cmd.ExecuteNonQuery(); }
            conn.Close();
            a = 0;
        }
        int a = 1;
        private void OTCHET_Click(object sender, RoutedEventArgs e)
        {
            string itg = ""; int r = -1;
            MySqlCommand cmd = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,Зарплата,график.Название,Годржд,Образование,Опыт from сотрудники,график,должности,допинф where Логин = '{login.Text}' and Пароль = '{Pass.Password}' and сотрудники.График = график.id and сотрудники.Должность = должности.id and сотрудники.id = допинф.Сотрудник", conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if (id_C.IsChecked == true)
            {
                itg += $"\n id: {id1}";
            }
            if (FIO_C.IsChecked == true)
            {
                itg += $"\n ФИО: {reader[1]}";
            }
            if (dol_C.IsChecked == true)
            {
                itg += $"\n Должность: {reader[2]}";
            }
            if (zarplata_C.IsChecked == true)
            {
                itg += $"\n Зарплата: {reader[3]} руб.";
            }
            if (grafic_C.IsChecked == true)
            {
                itg += $"\n График: {reader[4]}";
            }
            if (dopinf_C.IsChecked == true)
            {
                itg += $"\n Год рождения: {reader[5]} Образование: {reader[6]} Опыт: {reader[7]}";
            }

            reader.Close();
            //
            int u = 0;
            MySqlCommand cmd6 = new MySqlCommand($"select * from задачи where задачи.Назначен = {id1}", conn);
            MySqlDataReader read4 = cmd6.ExecuteReader();
            while (read4.Read())
            {
                u++;
            }
            read4.Close();

            MySqlCommand cmd4 = new MySqlCommand($"select задачи.id,задачи.Название,статус_задачи.Статус, задачи.Описание, задачи.Дата from сотрудники,задачи,статус_задачи where задачи.Назначен = {id1} and задачи.Статус = статус_задачи.id", conn);
            MySqlDataReader read1 = cmd4.ExecuteReader();
            read1.Read();
            for (int i = 0; i < u; i++)
            { if (zadachi_C.IsChecked == true) { itg += $"\n id задачи: {read1[0]}  Название: {read1[1]}  Статус: {read1[2]}  Описание: {read1[3]}  Дата: {read1[4]}"; } }
            read1.Close();

            double rol = 0; int i1 = 0;
            MySqlCommand cmd2 = new MySqlCommand($"select изменения.id,Название,Описание,Сотрудник from изменения", conn);
            MySqlDataReader read = cmd2.ExecuteReader();
            while (read.Read())
            {
                if (izm_C.IsChecked == true)
                {
                    itg += $"\n id изменения: {read[0]}  Название: {read[1]}  Описание: {read[2]}  Сотрудник: {read[3]}";
                }

            }
            read.Close();
            MySqlCommand cmd5 = new MySqlCommand($"select задачи.id,задачи.Название,статус_задачи.Статус, задачи.Описание, задачи.Дата from задачи,статус_задачи where задачи.Статус = статус_задачи.id", conn);
            MySqlDataReader read2 = cmd5.ExecuteReader();
            while (read2.Read())
            {
                if (all_C.IsChecked == true)
                {

                    itg += $"\n id задачи: {read2[0]}  Название: {read2[1]}  Статус: {read2[2]}  Описание: {read2[3]}  Дата: {read2[4]}";
                }

            }
            read2.Close();


            //---------------
            MySqlCommand cmd3 = new MySqlCommand($"select Зарплата from сотрудники", conn);
            MySqlDataReader rea = cmd3.ExecuteReader();
            while (rea.Read())
            {
                rol += Convert.ToDouble(rea[0]); i1++;
            }
            rea.Close();
            if (sum_C.IsChecked == true)
            {
                itg += $"\n Сумма зарплат: {rol} руб.";
            }
            if (sotrudnik_C.IsChecked == true)
            {
                itg += $"\n Количество сотрудников: {i1}";
            }
            if (zadacha_C.IsChecked == true)
            {
                MySqlCommand cmd1 = new MySqlCommand($"select задачи.Название,статус_задачи.Статус,задачи.Описание,задачи.Дата from задачи,статус_задачи where задачи.id = '{Convert.ToInt32(id_Text2.Text)}' and задачи.Статус = статус_задачи.id", conn);
                MySqlDataReader reade = cmd1.ExecuteReader();
                reade.Read();
                itg += $"\n id задачи: {id_Text2.Text}  Название: {reade[0]}  Статус: {reade[1]}  Описание: {reade[2]}  Дата: {reade[3]}";
                reade.Close();
            }
            conn.Close();

            using (StreamWriter sw = new StreamWriter($@"C:\Users\stepa\Desktop\Дистант\Отчет №{a}.txt")) { sw.Write($"{itg}"); MessageBox.Show($"Отчет№{a} составлен !"); }
            a++; itg = "";
            id_C.IsChecked = false; FIO_C.IsChecked = false; dol_C.IsChecked = false; zarplata_C.IsChecked = false; grafic_C.IsChecked = false; dopinf_C.IsChecked = false;
            zadachi_C.IsChecked = false; izm_C.IsChecked = false; all_C.IsChecked = false; sum_C.IsChecked = false; sotrudnik_C.IsChecked = false; zadacha_C.IsChecked = false; id_Text2.Text = "";
        }

        private void Otchet_Click_1(object sender, RoutedEventArgs e)
        {
            if (!boolean)
            {
                MessageBox.Show("Добавьте информацию о себе!");
            }
            else
            {
                Border_3.Visibility = Visibility.Visible;
                Border_4.Visibility = Visibility.Hidden;
                Border_5.Visibility = Visibility.Hidden;
                Border_izm1.Visibility = Visibility.Hidden;
                zadach.Visibility = Visibility.Hidden;
                sotr.Visibility = Visibility.Hidden;
                vplt.Visibility = Visibility.Hidden;
                Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                Otchet.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
                zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                if (st > 1)
                {
                    Border_Otchet.Visibility = Visibility.Visible;
                    Border_Otchet1.Visibility = Visibility.Visible;
                }
                else
                {
                    Border_Otchet.Visibility = Visibility.Visible;
                }
            }
        }

        private void create_infa_Click(object sender, RoutedEventArgs e)
        {
            Border_5.Visibility = Visibility.Hidden;
            Border_infa.Visibility = Visibility.Visible;
            date.Visibility = Visibility.Visible;
            obrazovanie.Visibility = Visibility.Visible;
            staj_R.Visibility = Visibility.Visible;
            SAVE.Visibility = Visibility.Visible;

        }
        public bool b;
        private void SAVE_Click_1(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM ukadr.допинф where Сотрудник = '{id1}'", conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            rdr.Close();
            conn.Close();
            if (b)
            {
                MySqlCommand cmd2 = new MySqlCommand($"UPDATE `ukadr`.`допинф` SET `Годржд` = '{date.Text}', `Образование` = '{obrazovanie.Text}', `Опыт` = '{staj_R.Text}' WHERE (`Сотрудник` = '{id1}');", conn);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Успешно!");
            }
            else
            {
                string data = date.SelectedDate.ToString();
                string obr = obrazovanie.Text;
                string stag = staj_R.Text;
                if (data != "" & obr != "" & stag != "")
                {
                    MySqlCommand cmd1 = new MySqlCommand($"INSERT INTO `допинф` (`Сотрудник`, `Годржд`, `Образование`, `Опыт`) VALUES ('{id1}', '{data}', '{obr}', '{stag}')", conn);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    Border_4.Visibility = Visibility.Visible;
                    Border_5.Visibility = Visibility.Visible;
                    SAVE.Visibility = Visibility.Collapsed;
                    create_infa.Visibility = Visibility.Collapsed;
                    infa.Visibility = Visibility.Visible;
                    date.Visibility = Visibility.Hidden;
                    obrazovanie.Visibility = Visibility.Hidden;
                    staj_R.Visibility = Visibility.Hidden;
                    redactor_infa.Visibility = Visibility.Visible;
                    Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                    Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                    Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                    proverka();
                }
                else
                {
                    MessageBox.Show("Вы не заполнили все поля");
                }
            }
        }
        void proverka()
        {
            MySqlCommand cmd = new MySqlCommand($"select сотрудники.Логин,статус_сотрудника.Уровень_допуска,сотрудники.id,сотрудники.Должность from сотрудники,статус_сотрудника  where Логин = '{login.Text}' and Пароль = '{Pass.Password}' and сотрудники.статус = статус_сотрудника.id", conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                switch (Convert.ToInt16(rdr[1]))
                {
                    case 1:
                        boolean = true;
                        st = 1; SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; redactor_infa.Visibility = Visibility.Visible; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden;
                        Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Borderr_4.Visibility = Visibility.Collapsed;
                        status.Content = "Статус: `Сотрудник`";
                        break;
                    case 2:
                        boolean = true;
                        st = 2; SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden; redactor_infa.Visibility = Visibility.Visible;
                        Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Borderr_4.Visibility = Visibility.Visible;
                        vpl.Visibility = Visibility.Visible;
                        status.Content = "Статус: `Модератор`";
                        break;
                    case 3:
                        boolean = true;
                        st = 3; SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden; redactor_infa.Visibility = Visibility.Visible;
                        Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        Borderr_4.Visibility = Visibility.Visible;
                        vpl.Visibility = Visibility.Hidden;
                        status.Content = "Статус: `Администратор`";
                        break;
                    case 4:
                        status.Content = "Статус: `Стажер`";
                        Borderr_4.Visibility = Visibility.Collapsed;
                        st = 0;
                        conn.Close();
                        MySqlCommand cmd1 = new MySqlCommand($"select Годржд,Образование,Опыт from допинф where сотрудник = '{id1}'", conn);
                        conn.Open();
                        MySqlDataReader reader = cmd1.ExecuteReader();

                        reader.Read();
                        if (reader.HasRows)
                        {
                            boolean = true;
                            SAVE.Visibility = Visibility.Collapsed; create_infa.Visibility = Visibility.Collapsed; infa.Visibility = Visibility.Visible; date.Visibility = Visibility.Hidden; obrazovanie.Visibility = Visibility.Hidden; staj_R.Visibility = Visibility.Hidden;
                            Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                            Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                            Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
                        }
                        else
                        {
                            boolean = false;
                            Zadachi.Background = Brushes.Gray;
                            Izmen.Background = Brushes.Gray;
                            Otchet.Background = Brushes.Gray;
                            SAVE.Visibility = Visibility.Visible; create_infa.Visibility = Visibility.Visible; infa.Visibility = Visibility.Collapsed; date.Visibility = Visibility.Visible; obrazovanie.Visibility = Visibility.Visible; staj_R.Visibility = Visibility.Visible; redactor_infa.Visibility = Visibility.Collapsed;

                        }
                        reader.Close();
                        conn.Close();
                        break;
                }
            }
        }
        private void Sotr_Click(object sender, RoutedEventArgs e)
        {
            Border_4.Visibility = Visibility.Hidden;
            Border_5.Visibility = Visibility.Hidden;
            Border_Zad.Visibility = Visibility.Hidden;
            Border_izm.Visibility = Visibility.Hidden;
            Border_izm1.Visibility = Visibility.Hidden;
            Border_Otchet.Visibility = Visibility.Hidden;
            Border_Otchet1.Visibility = Visibility.Hidden;
            srok.Visibility = Visibility.Hidden;
            zadach.Visibility = Visibility.Hidden;
            sotr.Visibility = Visibility.Visible;
            vplt.Visibility = Visibility.Hidden;
            Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            sotrr.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
            vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            if (st == 3) { stat.Visibility = Visibility.Visible; }
            MySqlCommand cmd = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,график.Название from сотрудники,должности,график where сотрудники.График = график.id and сотрудники.Должность= должности.id", conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            datagridd.DataContext = dt;
        }

        private void db_sotr(object sender, RoutedEventArgs e)
        {
            int d = 1, d1 = 1, stt = 0;
            switch (ss4.Text)
            {
                case "Офисный работник":
                    d = 1;
                    break;
                case "Бухгалтер":
                    d = 2;
                    break;
                case "Менеджер":
                    d = 3;
                    break;
                case "Секретарь":
                    d = 4;
                    break;
            }

            switch (ss3.Text)
            {
                case "2/2":
                    d1 = 1;
                    break;
                case "4/4":
                    d1 = 2;
                    break;
                case "5/2":
                    d1 = 3;
                    break;
                case "2/3":
                    d1 = 4;
                    break;
            }
            conn.Open();
            MySqlCommand cmd1 = new MySqlCommand($"update `сотрудники` set Должность = '{d}',Зарплата = '{ss2.Text}',График = '{d1}' where id = '{Convert.ToInt32(ss1.Text)}'", conn);
            if (st == 2)
            {
                MySqlCommand cmd2 = new MySqlCommand($"select Статус from сотрудники where id = {Convert.ToInt32(ss1.Text)}", conn);
                MySqlDataReader reade = cmd2.ExecuteReader();
                while (reade.Read())
                { 
                    if (Convert.ToInt32(reade[0]) >= 2) 
                    { 
                        stt++; MessageBox.Show("Нет доступа"); break; 
                    } 
                }
                reade.Close();
                if (stt == 0) { cmd1.ExecuteNonQuery(); }
            }
            else { cmd1.ExecuteNonQuery(); }
            MySqlCommand cmd = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,график.Название from сотрудники,должности,график where сотрудники.График = график.id and сотрудники.Должность= должности.id", conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            datagridd.DataContext = dt;
        }

        private void izm_sotr(object sender, RoutedEventArgs e)
        {
            int d = 1;
            switch (st2d.Text)
            {
                case "Сотрудник":
                    d = 1;
                    break;
                case "Модератор":
                    d = 2;
                    break;
                case "Администратор":
                    d = 3;
                    break;
            }
            MySqlCommand cmd = new MySqlCommand($"UPDATE `сотрудники` SET `Статус` = '{d}' WHERE (`id` = '{Convert.ToInt32(st1d.Text)}');", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void uvol_str(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM `ukadr`.`сотрудники` WHERE (`id` = '{Convert.ToInt32(stx1.Text)}')", conn);
            conn.Open();
            int stt = 0;
            if (st == 2)
            {
                MySqlCommand cmd2 = new MySqlCommand($"select Статус from сотрудники where id = '{Convert.ToInt32(stx1.Text)}'", conn);
                MySqlDataReader reade = cmd2.ExecuteReader();
                while (reade.Read())
                { if (Convert.ToInt32(reade[0]) >= 2) { stt++; MessageBox.Show("Нет доступа"); break; } }
                reade.Close();
                if (stt == 0) { cmd.ExecuteNonQuery(); }
            }
            else { cmd.ExecuteNonQuery(); }
            conn.Close();
        }

        private void zadach_Clic(object sender, RoutedEventArgs e)
        {
            Border_4.Visibility = Visibility.Hidden;
            Border_5.Visibility = Visibility.Hidden;
            Border_infa.Visibility = Visibility.Hidden;
            Border_pass.Visibility = Visibility.Hidden;
            Border_Zad.Visibility = Visibility.Hidden;
            Border_izm.Visibility = Visibility.Hidden;
            Border_izm1.Visibility = Visibility.Hidden;
            sotr.Visibility = Visibility.Hidden;
            zadach.Visibility = Visibility.Visible;
            Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            zd.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252));
            sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            vpl.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            MySqlCommand cmd = new MySqlCommand($"select задачи.id,задачи.Название,сотрудники.ФИО,статус_задачи.Статус from задачи,сотрудники,статус_задачи where сотрудники.id = задачи.Назначен and задачи.Статус = статус_задачи.id", conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            datagridd2.DataContext = dt;
        }

        private void dbz_Click(object sender, RoutedEventArgs e)
        {

            int d = 1; int stt = 0;
            conn.Open();
            TextRange op1 = new TextRange(zz6.Document.ContentStart, zz6.Document.ContentEnd);
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO `задачи` (`Назначен`, `Название`, `Дата`,`Статус`, `Описание`) VALUES ('{zz1.Text}', '{zz4.Text}', '{zz5.Text}', '{d}','{op1.Text}');", conn); ;
            if (zz1.Text != "")
            {
                switch (zz3.Text)
                {
                    case "Выполняется":
                        d = 1;
                        break;
                    case "Приостановлено":
                        d = 2;
                        break;
                    case "Выполнено":
                        d = 3;
                        break;
                    case "Провалено":
                        d = 4;
                        break;
                }
                if (st == 2)
                {
                    MySqlCommand cmd1 = new MySqlCommand($"select Статус from сотрудники where id = {Convert.ToInt32(zz1.Text)}", conn);
                    MySqlDataReader reader = cmd1.ExecuteReader();
                    while (reader.Read())
                    { if (Convert.ToInt32(reader[0]) >= 2) { stt++; MessageBox.Show("Нет доступа"); break; } }
                    reader.Close();
                    if (stt == 0) { cmd.ExecuteNonQuery(); }
                }
                else { cmd.ExecuteNonQuery(); }
            }
            else { MessageBox.Show("Заполните id сотрудника"); }
            conn.Close();
            MySqlCommand cmd3 = new MySqlCommand($"select задачи.id,задачи.Название,сотрудники.ФИО,статус_задачи.Статус from задачи,сотрудники,статус_задачи where сотрудники.id = задачи.Назначен and задачи.Статус = статус_задачи.id", conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd3.ExecuteReader());
            conn.Close();
            datagridd2.DataContext = dt;

        }

        private void vplt_Click(object sender, RoutedEventArgs e)
        {
            Border_4.Visibility = Visibility.Hidden;
            Border_5.Visibility = Visibility.Hidden;
            Border_infa.Visibility = Visibility.Hidden;
            Border_pass.Visibility = Visibility.Hidden;
            Border_Zad.Visibility = Visibility.Hidden;
            Border_izm.Visibility = Visibility.Hidden;
            Border_izm1.Visibility = Visibility.Hidden;
            sotr.Visibility = Visibility.Hidden;
            zadach.Visibility = Visibility.Hidden;
            vplt.Visibility = Visibility.Visible;
            Sotrudnik.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Zadachi.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Izmen.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            Otchet.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            zd.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            sotrr.Background = new SolidColorBrush(Color.FromRgb(71, 138, 201));
            vpl.Background = new SolidColorBrush(Color.FromRgb(117, 96, 252)); ;
            MySqlCommand cmd = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,Зарплата,ВЗМ,ВЗМдата from сотрудники,должности where сотрудники.Должность = должности.id", conn);
            conn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            datagridd3.DataContext = dt;



        }

        private void vpltv_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE `сотрудники` SET `ВЗМ` = `Зарплата`, `ВЗМдата` = '{DateTime.Now}' ", conn);
            cmd.ExecuteNonQuery();
            MySqlCommand cmd1 = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,Зарплата,ВЗМ,ВЗМдата from сотрудники,должности where сотрудники.Должность = должности.id", conn);
            DataTable dt = new DataTable();
            dt.Load(cmd1.ExecuteReader());
            conn.Close();
            datagridd3.DataContext = dt;
        }

        private void vpltp_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            MySqlCommand cmd1 = new MySqlCommand($"select ВЗМ from сотрудники where id = '{Convert.ToInt32(v6.Text)}'", conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
            reader.Read();
            double a = Convert.ToDouble(reader[0]) + Convert.ToDouble(v8.Text);
            reader.Close();
            MySqlCommand cmd = new MySqlCommand($"UPDATE `сотрудники` SET `ВЗМ` = '{a}' where id = '{Convert.ToInt32(v6.Text)}'", conn);
            cmd.ExecuteNonQuery();

            MySqlCommand cmd2 = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,Зарплата,ВЗМ,ВЗМдата from сотрудники,должности where сотрудники.Должность = должности.id", conn);
            DataTable dt = new DataTable();
            dt.Load(cmd2.ExecuteReader());
            conn.Close();
            datagridd3.DataContext = dt;
            
        }

        private void All_user_Click(object sender, RoutedEventArgs e)
        {
                MySqlCommand cmd = new MySqlCommand("select сотрудники.id,ФИО,должности.Название from сотрудники,должности where сотрудники.Должность = должности.id", conn);
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                datagrid2.DataContext = dt;
                conn.Close();
        }

        private void zadacha_C_Checked(object sender, RoutedEventArgs e)
        {
                id_ZAD.Visibility = Visibility.Visible;
        }

        private void zadacha_C_Unchecked(object sender, RoutedEventArgs e)
        {
            id_ZAD.Visibility = Visibility.Hidden;
        }

        private void redactor_infa_Click(object sender, RoutedEventArgs e)
        {
            Border_5.Visibility = Visibility.Hidden;
            Border_infa.Visibility = Visibility.Visible;
            Border_pass.Visibility = Visibility.Hidden;
            date.Visibility = Visibility.Visible;
            obrazovanie.Visibility = Visibility.Visible;
            staj_R.Visibility = Visibility.Visible;
            SAVE.Visibility = Visibility.Visible;
            god.Content = $"Год Рождения: ";
            obraz.Content = $"Образование: ";
            opit.Content = $"Опыт работы: ";
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM ukadr.допинф where Сотрудник = '{id1}'", conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                date.SelectedDate = Convert.ToDateTime(rdr[2]);
                obrazovanie.Text = rdr[3].ToString();
                staj_R.Text = rdr[4].ToString();
            }
            rdr.Close();
            conn.Close();
        }

        private void v2_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE `сотрудники` SET `ВЗМ` = `Зарплата`, `ВЗМдата` = '{DateTime.Now}' ", conn);
            cmd.ExecuteNonQuery();
            MySqlCommand cmd1 = new MySqlCommand($"select сотрудники.id,ФИО,должности.Название,Зарплата,ВЗМ,ВЗМдата from сотрудники,должности where сотрудники.Должность = должности.id", conn);
            DataTable dt = new DataTable();
            dt.Load(cmd1.ExecuteReader());
            datagridd3.DataContext = dt;
            conn.Close();
        }
    }
}
