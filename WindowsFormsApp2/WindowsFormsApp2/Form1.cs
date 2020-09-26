using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Model1 db = new Model1();

        // Кнопка для закрытия приложения
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Кнопка выбора фотографии 
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберете фото нового сотрудника";
            ofd.InitialDirectory = @"C:\Users\Kostya\Desktop\!!!На дому\Фотожоп";
            ofd.Filter = "Файлы JPG, GIF, PNG|*.jpg;*.gif;*.png|Все файлы (*.*)|*.*";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        // Кнопка сохранения данных в Базу Данных
        private void button2_Click(object sender, EventArgs e)
        {
            //string Dat = dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString();

            var selectedDate = dateTimePicker1.Value.Date;
            var today = DateTime.Today;
            var tdy = Convert.ToString(today);
            var dtp = Convert.ToString(selectedDate);
            if (selectedDate > today)
            {
                label8.Text = "Дата рождения*";
                label8.ForeColor = Color.Red;
                MessageBox.Show("Выбранная дата должна быть реальной!");
                return;

            }
            else
            {
                label8.Text = "Дата рождения";
                label8.ForeColor = Color.Black;
            }


            {
                // MessageBox.Show(DateTime.Today.ToString());
            }
            // Проверка на заполнение самыв важных полей в приложении
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" ||
                 dateTimePicker1.Text == "" || textBox9.Text == "" || comboBox1.Text == "")
            {
                {
                    if (textBox1.Text == "") // Логин
                    {
                        label2.Text = "Логин*";
                        label2.ForeColor = Color.Red;
                    }
                    else
                    {
                        label2.Text = "Логин";
                        label2.ForeColor = Color.Black;
                    }
                }

                {
                    if (textBox2.Text == "") // Пароль
                    {
                        label3.Text = "Пароль*";
                        label3.ForeColor = Color.Red;
                    }
                    else
                    {
                        label3.Text = "Пароль";
                        label3.ForeColor = Color.Black;
                    }
                }

                {
                    if (textBox3.Text == "") // Повторите пароль
                    {
                        label4.Text = "Повторите пароль*";
                        label4.ForeColor = Color.Red;
                    }
                    else
                    {
                        label4.Text = "Повторите пароль";
                        label4.ForeColor = Color.Black;
                    }
                }

                {
                    if (textBox4.Text == "") // Имя
                    {
                        label5.Text = "Имя*";
                        label5.ForeColor = Color.Red;
                    }
                    else
                    {
                        label5.Text = "Имя";
                        label5.ForeColor = Color.Black;
                    }
                }

                {
                    if (textBox5.Text == "") // Фамилия
                    {
                        label6.Text = "Фамилия*";
                        label6.ForeColor = Color.Red;
                    }
                    else
                    {
                        label6.Text = "Фамилия";
                        label6.ForeColor = Color.Black;
                    }
                }

                {
                    if (dateTimePicker1.Text == "") // Дата рождения
                    {
                        label8.Text = "Дата рождения*";
                        label8.ForeColor = Color.Red;
                    }
                    else
                    {
                        label8.Text = "Дата рождения";
                        label8.ForeColor = Color.Black;
                    }
                }

                {
                    if (textBox9.Text == "") // Адрес
                    {
                        label10.Text = "Адрес*";
                        label10.ForeColor = Color.Red;
                    }
                    else
                    {
                        label10.Text = "Адрес";
                        label10.ForeColor = Color.Black;
                    }
                }

                {
                    if (comboBox1.Text == "") // Должность
                    {
                        label11.Text = "Должность*";
                        label11.ForeColor = Color.Red;
                    }
                    else
                    {
                        label11.Text = "Должность";
                        label11.ForeColor = Color.Black;
                    }
                }

                MessageBox.Show("Заполните все ключевые поля, пожалуйста! Они помечены звездочкой  " + "* ");
                return;
            }

            // Проверка на совпадение паролей
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Пароли не совпадют!");
                return;
            }


            // Присвоение каждого текстбокса к конкретному полю в SQL
            Employee emp = new Employee();
            emp.Login = textBox1.Text;
            emp.Password = textBox2.Text;
            emp.FirstName = textBox4.Text;
            emp.SecondName = textBox5.Text;
            emp.ThirdName = textBox6.Text;
            emp.DateOfBirthday = dateTimePicker1.Value;
            emp.Number = textBox8.Text;
            emp.Address = textBox9.Text;
            emp.Role = comboBox1.Text;

            // Конвертирование изображение в другой тип данных и присвоение его к своему полю в SQL


            ImageConverter conv = new ImageConverter();
            // создаем массив байтов, из свойства Image ЭУ PictureBox
            byte[] IMAGE = (byte[])conv.ConvertTo(pictureBox1.Image, typeof(byte[]));
            // присваиваем свойству изображение в формате byte[]
            emp.Photo = IMAGE;
            // добавляем новый объект к коллекции
            db.Employee.Add(emp);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Пользователь зарегистрирован");
            }
            catch
            {
                MessageBox.Show("Вы уже зарегистрировали данного пользователя в систему!");
            }
        }
        // Показать пароль
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        // Показать пароль на "Покажите пароль"
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox2.Checked)
                {
                    textBox3.UseSystemPasswordChar = false;
                }
                else
                {
                    textBox3.UseSystemPasswordChar = true;
                }
            }
        }
        // Всё что происходит при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
            ToolTip pk1 = new ToolTip();
            pk1.SetToolTip(checkBox1, "Показать пароль");
            ToolTip pk2 = new ToolTip();
            pk2.SetToolTip(checkBox2, "Показать пароль");
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            {
                // Подсказка к вводу логина
                ToolTip log = new ToolTip();
                log.SetToolTip(pictureBox2, "Можно вводить только буквы английского языка и цифры. Максимальный размер логина - 40 символов");

                // Подсказка к вводу имени
                ToolTip name = new ToolTip();
                name.SetToolTip(pictureBox3, "Можно вводить только буквы русского и английского языка. Максимальный размер Имени - 40 символов");


                ToolTip sname = new ToolTip();
                sname.SetToolTip(pictureBox4, "Можно вводить только буквы русского и английского языка. Максимальный размер Фамилии - 49 символов");

                ToolTip tname = new ToolTip();
                tname.SetToolTip(pictureBox5, "Можно вводить только буквы русского и английского языка. Максимальный размер Отчества - 49 символов");
                
                
                textBox8.MaxLength = 12; // Максимальная длина номера Телефона
                textBox6.MaxLength = 49; // Максимальная длина Отчества
                textBox5.MaxLength = 49; // Максимальная длина Фаимилии
                textBox4.MaxLength = 40; // Максимальная длина Имени
                textBox1.MaxLength = 40; // Максимальная длина Логина
            }
        }


        // Возможные символы для введения логина
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char engsabc = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && engsabc != 8 && (e.KeyChar <= 64 || e.KeyChar >= 91)
                && (e.KeyChar <= 96 || e.KeyChar >= 123))
            {
                e.Handled = true;
            }

        }

        // Возможные символы для введения Имени, а ниже и фамилии с отчеством
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char rusabc = e.KeyChar;
            if ((rusabc < 'А' || rusabc > 'я') && (rusabc < 'A' || rusabc > 'z') && rusabc != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char rusabc = e.KeyChar;
            if ((rusabc < 'А' || rusabc > 'я') && (rusabc < 'A' || rusabc > 'z') && rusabc != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char rusabc = e.KeyChar;
            if ((rusabc < 'А' || rusabc > 'я') && (rusabc < 'A' || rusabc > 'z') && rusabc != '\b')
            {
                e.Handled = true;
            }
        }
    }
}