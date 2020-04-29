using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People
{
    public partial class FillForm : Form
    {
        private CountriesDAL countriesDAL;
        private PeopleDAL peopleDAL;
        private string errMess;
        private int errNumber;

        public FillForm()
        {
            InitializeComponent();
            string error = string.Empty;
            peopleDAL = new PeopleDAL(ref error);
            if (error != "OK")
            {
                errNumber = 1;
                errMess = "Error" + errNumber + Environment.NewLine + "People objektumot nem tudtam letrehozni. " + error;                
            }
            else
            {
                errMess = "OK";
                countriesDAL = new CountriesDAL();
            }
        }


        /// <summary>
        /// This event occurs before a form is displayed for the first time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillForm_Load(object sender, EventArgs e)
        {
            if (errMess == "OK") //letrejott a People objektum
            {
                //FillCbCountries();
                FillCbNames();

                FillDgvPeople("");

                //lblPersonNo.Text = m_People.GetPersonNumber().ToString();
            }            
        }

        /// <summary>
        /// Fills the country comboboxes with the country list.
        /// </summary>
        /// <param name="combo">specifies which combobox to fill</param>
        private void FillCbCountries()
        {
            string error = string.Empty;
            List<Country> countryList = countriesDAL.GetCountryList(ref error);

            if (error != "OK")
            {
                errNumber++;
                if (errMess == "OK")
                    errMess = string.Empty;
                    errMess = errMess + Environment.NewLine +
                    "Error" + errNumber + Environment.NewLine + "Hiba a ComboBox feltoltesenel." + error;
            }
            else
            {
                //fill the cbCountryFilter combobox
                comboBoxFilterCountries.DataSource = countryList;
                //the text to be dispayed as the combobox text
                comboBoxFilterCountries.DisplayMember = "CountryName";
                //the value of the combobox (can be accessed by the selectedValue property)
                comboBoxFilterCountries.ValueMember = "CountryId";

            }

        }

        private void FillCbNames()
        {
            string error = string.Empty;
            List<string> nameList = peopleDAL.GetNameList(ref error);

            if (error != "OK")
            {
                errNumber++;
                if (errMess == "OK")
                    errMess = string.Empty;
                errMess = errMess + Environment.NewLine +
                "Error" + errNumber + Environment.NewLine + "Hiba a ComboBox feltoltesenel." + error;
            }
            else
            {
                //fill the cbCountryFilter combobox
                comboBoxFilterNames.DataSource = nameList;
                //the text to be dispayed as the combobox text
                comboBoxFilterNames.DisplayMember = "PersonName";
                //the value of the combobox (can be accessed by the selectedValue property)

            }

        }


        //dvgPeople DataGridView feltoltese adatokkal
        //adatok = a megadott karakterrel/karakterekkel kezdodo nevu es orszagba tartozo nyaralok
        //az OrszagID ervenyes kell legyen (countryID>0)
        private void FillDgvPeople(string strName)
        {
            string error = string.Empty;
            dgvPeople.Rows.Clear();
            List<Person> personList = peopleDAL.GetPersonListDataReader(strName, ref error);

            if ((personList.Count != 0) && (error == "OK")) //ha van a felteteleknek eleget tevo nyaralo es nem lepett fel hiba,
            //a lista elemeit hozzaadjuk a DataGridView-hoz(lesznek olyan oszlopok/cellak, melyek 
            //nem jelennek meg a DataGridView-ban
            {
                foreach (Person item in personList)
                {
                    try
                    {
                        dgvPeople.Rows.Add(item.PersonId,
                                           item.PersonName,
                                           item.PersonCountry.CountryId,
                                           item.PersonCountry.CountryName,
                                           item.PhoneNumber
                                           );
                    }
                    catch (Exception ex)
                    {
                        errNumber++;
                        if (errMess == "OK") errMess = string.Empty;
                        errMess = errMess + Environment.NewLine + 
                            "Error"+errNumber+Environment.NewLine+"Invalid data " + ex.Message;
                    }
                }
            }
            else if (error != "OK")
            {
                errNumber++;
                if (errMess == "OK") errMess = string.Empty;
                errMess = errMess + Environment.NewLine + 
                    "Error"+errNumber+Environment.NewLine+"Hiba a DataGridView feltoltesenel." + error;
            }
        }

        /// <summary>
        /// Filters the personlist based on the PersonName and the selected countryId 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            //cbcountryfilter.selectedvalue->countryid
            //cbcountryfilter.selectedtext->countryname
            //FillDgvPeople(Convert.ToInt32(comboBoxFilterCountries.SelectedValue), labelCountries.Text);
            FillDgvPeople(comboBoxFilterNames.SelectedValue.ToString());

            if (errMess != "OK")
            {
                ErrorForm errorForm = new ErrorForm(errMess);
                errorForm.Show();
                errorForm.Focus();
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Occurs whenever the form is first shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillForm_Shown(object sender, EventArgs e)
        {
            if (errMess != "OK")
            {
                ErrorForm errorForm = new ErrorForm(errMess);
                errorForm.Show();
                errorForm.Focus();
            }
        }

      

        private void comboBoxFilterCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void comboBoxFilterNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("Több táblából is törlődhetnek sorok. Engedélyezi a törlést ? ", "Törlés", MessageBoxButtons.YesNo);
            string error = string.Empty;

            if (dgvPeople.SelectedRows.Count != 0)
            {
                if (dr == DialogResult.Yes)
                {
                    peopleDAL.deletePerson(Convert.ToString(dgvPeople.SelectedRows[0].Cells["personName"].Value), ref error);
                    if (error == "OK")
                    {
                        FillDgvPeople("");
                        MessageBox.Show("A törlés sikeres volt sor.");
                    }
                    else
                    {
                        MessageBox.Show("A törlés sikertelen volt sor.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott sor.");
            }

        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            FillDgvPeople("");
        }

        
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string error = string.Empty;

            if (dgvPeople.SelectedRows.Count != 0)
            {
                string personName = Convert.ToString(dgvPeople.SelectedRows[0].Cells["personName"].Value);
                string currentPhoneNumber = Convert.ToString(dgvPeople.SelectedRows[0].Cells["phoneNumber"].Value);
                string newPhoneNumber = textBoxPhoneNumber.Text;
                string oldPhoneNumber = peopleDAL.GetPhoneNumber(personName, ref error);

                if (error == "OK")
                {
                    if(currentPhoneNumber!=oldPhoneNumber)
                    {
                        buttonSave.Visible = true;
                        textBoxCurrent.Visible = true;
                        textBoxCurrent.Text = currentPhoneNumber;
                        textBoxOld.Visible = true;
                        textBoxOld.Text = oldPhoneNumber;
                        textBoxNew.Visible = true;
                        textBoxNew.Text = newPhoneNumber;
                        radioButtonNew.Visible = true;
                        radioButtonCurrent.Visible = true;
                        radioButtonOld.Visible = true;
                    } else
                    {
                        peopleDAL.updatePerson(personName, newPhoneNumber, ref error);
                    }
                }
                else
                {
                    MessageBox.Show("Az telefonszám lekérése sikertelen volt.");
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott sor.");
            }
        }

        private void btnGetPhoneNumber_Click(object sender, EventArgs e)
        {
            string error = string.Empty;

            if (dgvPeople.SelectedRows.Count != 0)
            {
                string personName = Convert.ToString(dgvPeople.SelectedRows[0].Cells["personName"].Value);
                string phoneNumber = peopleDAL.GetPhoneNumber(personName, ref error);

                if (error == "OK")
                {
                    labelPhoneNumber.Text = phoneNumber;
                }
                else
                {
                    MessageBox.Show("Az telefonszám lekérése sikertelen volt.");
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott sor.");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelUpdate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = string.Empty;

           
                
            if (radioButtonNew.Checked == true)
            {
                peopleDAL.updatePerson(Convert.ToString(dgvPeople.SelectedRows[0].Cells["personName"].Value), textBoxPhoneNumber.Text, ref error);
            }

            if (radioButtonOld.Checked == true)
            {
                peopleDAL.updatePerson(Convert.ToString(dgvPeople.SelectedRows[0].Cells["personName"].Value),
                Convert.ToString(dgvPeople.SelectedRows[0].Cells["phoneNumber"].Value), ref error);
            }

            if (error == "OK")
            {
                MessageBox.Show("A módositás sikeres volt.");
            } else {
                MessageBox.Show("A módositás sikertelen volt.");
            }

           
            buttonSave.Visible = false;
            textBoxCurrent.Visible = false;
            textBoxCurrent.Text = "";
            textBoxOld.Visible = false;
            textBoxOld.Text = "";
            textBoxNew.Visible = false;
            textBoxNew.Text = "";
            radioButtonNew.Visible = false;
            radioButtonCurrent.Visible = false;
            radioButtonOld.Visible = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxFilterCountries_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

    }
}
