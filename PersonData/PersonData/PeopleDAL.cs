using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace People
{
    /// <summary>
    /// Structure for storing the Person's information
    /// </summary>
    public struct Person
    {
        string personId;
        string personName;
        Country personCountry;
        string phoneNumber;

        public string PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        public Country PersonCountry
        {
            get { return personCountry; }
            set { personCountry = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

       
    }

    public class PeopleDAL : DALGen
    {
        public PeopleDAL(ref string error)
        {
            //megpróbáljuk, hogy létrejön-e a kapcsolat            
            base.CreateConnection(ref error);             
        }

   
        /// <summary>
        /// Gets the list of all people into a person structure list (loading the structure list with 
        /// the data from DataReader). 
        /// If a valid countryId is given, then filters the results based on the countryId and on the PersonName.
        /// </summary>
        /// <param name="PersonName"> the name of the person </param>
        /// <param name="countryId"> the ID of the hpuse's country </param>
        /// <returns>the list of people</returns>

        public List<Person> GetPersonListDataReader(string personName, ref string error)
        {
            string query = "SELECT SzemelyiSzam, SzemelyNev, Telszam, Szemelyek.OrszagID, OrszagNev" 
                +" FROM Szemelyek, Orszagok "
                +" WHERE Szemelyek.OrszagID = Orszagok.OrszagID ";

            if (personName!="")
            {
                query += " and SzemelyNev= @personName";
            }

            string[] parameters = new string[1];
            parameters[0] = "@personName";
            string[] parameterValues = new string[1];
            parameterValues[0] = personName;
            SqlDataReader dataReader = ExecuteReader(query, parameters, parameterValues, ref error);
            List<Person> personList = new List<Person>();

            if (error == "OK")
            {
                Person item = new Person();
                while (dataReader.Read())
                {                   
                    try
                    {
                        item.PersonId = dataReader["SzemelyiSzam"].ToString();
                        item.PersonName = dataReader["SzemelyNev"].ToString();
                        item.PersonCountry = new Country(Convert.ToInt32(dataReader["OrszagID"]), dataReader["OrszagNev"].ToString());
                        item.PhoneNumber = dataReader["Telszam"].ToString();
                    }
                    catch (Exception ex)
                    {
                        error = "Invalid data " + ex.Message;
                    }
                    personList.Add(item);
                }
            }
            CloseDataReader(dataReader);

            return personList;
        }


        /// ugyanaz, mint az elozo, csak itt DataSet-tel dolgozunk 
        public List<Person> GetPersonListDataSet(string str, ref string error)
        {
            string query = "SELECT SzemelyiSzam, SzemelyNev, Telszam, Szemelyek.OrszagID, OrszagNev " +
                " FROM Szemelyek, Orszagok "
                + " WHERE Szemelyek.OrszagID = Orszagok.OrszagID ";

            //if (countryId >= 0)
            //{
            //    query += " and Orszagok.OrszagID = " + countryId;
            //}

            if (str!="")
            {
                query += " and SzemelyNev LIKE '" + str + "%' ";
            }

            DataSet ds_tabla = new DataSet();
            ds_tabla = ExecuteDS(query, ref error);

            List<Person> personList = new List<Person>();

            if (error == "OK")
            {
                Person item = new Person();
                foreach (DataRow r in ds_tabla.Tables[0].Rows)
                {                    
                    try
                    {
                        item.PersonId = r["SzemelyiSzam"].ToString();
                        item.PersonName = r["SzemelyNev"].ToString();
                        item.PersonCountry = new Country(Convert.ToInt32(r["OrszagID"]), r["OrszagNev"].ToString());
                        item.PhoneNumber = r["Telszam"].ToString();
                    }
                    catch (Exception ex)
                    {
                        error = "Invalid data " + ex.Message;
                    }

                    personList.Add(item);
                }
            }
            return personList;
        }

        public List<string> GetNameList(ref string error)
        {
            string query = "SELECT SzemelyNev "
                + " FROM Szemelyek ";

            string[] parameters = new string[0];
            string[] parameterValues = new string[0];

            SqlDataReader dataReader = ExecuteReader(query,  parameters, parameterValues, ref error);

            List<string> nameList = new List<string>();
            string item;

            if (error == "OK")
            {
                while (dataReader.Read())
                {
                    try
                    {
                        item = dataReader[0].ToString();
                        nameList.Add(item);
                    }
                    catch (Exception ex)
                    {
                        error = "Invalid data " + ex.Message;
                    }
                }
            }
            CloseDataReader(dataReader);

            return nameList;
        }

        public string GetPhoneNumber(string strName, ref string error)
        {
            string query = "SELECT Telszam FROM Szemelyek " +
                            "WHERE SzemelyNev = @personName ";

            string[] parameters = new string[1];
            parameters[0] = "@personName";
            string[] parameterValues = new string[1];
            parameterValues[0] = strName;
            string retPhoneNumber = Convert.ToString(ExecuteScalarParametrized(query, parameters, parameterValues, ref error));
            return retPhoneNumber;
        }

        public void deletePerson(string strName, ref string error)
        {
            string command = "DELETE FROM Szemelyek WHERE SzemelyNev='" + strName + "'";
            ExecuteNonQuery(command, ref error);
        }

        public void updatePerson(string strName, string newPhoneNumber, ref string error)
        {
            string command = "UPDATE Szemelyek SET Telszam='" + newPhoneNumber + "'" + " WHERE SzemelyNev='" + strName + "'";
            ExecuteNonQuery(command, ref error);
        }
    }
}
