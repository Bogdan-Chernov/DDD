using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace DDD

{
    class Group
    {
        public int idGr{ get; set; }

        public string NameGr { get; set; }

        public string NumberGr { get; set; }

        public string CuratorGr { get; set; }
    }
    class DataClass
    {
        public void UpdGr(Group group)
        {
            string SqlCmd = $"Update [dbo].[group] set NameGroup='{group.NameGr}'  ,NumberGroup ='{group.NumberGr}',CuratorGroup ='{group.CuratorGr}' Where idGroup={group.idGr};";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Группа изменена");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // Строка подключения к БД
        string strConnection = @"Data Source=DESKTOP-RMHJ8VR\SQLEXPRESS;Initial Catalog=groupall;Integrated Security=True";

        /// <summary>
        /// Добавления данных о группе 
        /// </summary>
        /// <param name="group"> Класс Group</param>
        public void AddGr(Group group)
        {
            // 
            string SqlCmd = $"INSERT INTO [dbo].[group] ([NameGr],[NumberGr],[CuratorGr]) " +
                $"VALUES ('{group.NameGr}','{group.NumberGr}','{group.CuratorGr}')";

            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Группа добавленна");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        /// <summary>
        /// Чтения данных из таблицы group
        /// </summary>
        /// <returns></returns>
        public List<Group> ReadGr()
        {
            string SqlCmd = "SELECT * FROM [dbo].[group]";
            List<Group> groups = new List<Group>();

            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);

                    // Получаем строки из таблицы
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();


                    if (sqlDataReader.HasRows)
                    {
                        // Построчно считываем данные
                        while (sqlDataReader.Read())
                        {
                            groups.Add(new Group()
                            {
                                NameGr = sqlDataReader.GetString(1),
                                NumberGr = sqlDataReader.GetString(2),
                                CuratorGr = sqlDataReader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            return groups;
        }

        public void DelGr(Group group)
        {
            string SqlCmd = $"Delete From [dbo].[group] Where idGroup={group.idGr};";
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlCmd, connection);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Группа удалена");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
       
    }   
}