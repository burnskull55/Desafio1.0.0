namespace DesafioTeams
{
    using DesafioClasses;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="frmMain" />.
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="frmMain"/> class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            this.btn_choseTeam.Enabled = false;
            this.btn_genCoup.Enabled = false;
        }

        /// <summary>
        /// Defines the URI.
        /// </summary>
        internal string URI = "";

        /// <summary>
        /// Defines the teams.
        /// </summary>
        internal List<TeamModel> teams = new List<TeamModel>();

        /// <summary>
        /// Defines the teamForCoup.
        /// </summary>
        internal TeamModel teamForCoup;

        /// <summary>
        /// Defines the teamsForCoup.
        /// </summary>
        internal List<TeamModel> teamsForCoup = new List<TeamModel>();

        /// <summary>
        /// The textBox1_TextChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label2_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label2_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label3_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label3_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The panel1_Paint.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="PaintEventArgs"/>.</param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// The lbl_sigla1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void lbl_sigla1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The button1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            GenCoup();
        }

        /// <summary>
        /// The GenCoup.
        /// </summary>
        private void GenCoup()
        {
            CoupModel coup = new CoupModel(this.teamsForCoup);
            coup.orderCoup();
            //coup.testFirstPhase();
            coup.firstPhase();
            //coup.testSecondPhase();
            coup.secondPhase();
            //coup.testFinalPhase();
            coup.finalPhase();

            showWinnerForm(coup.firstP, coup.secondP);
        }

        /// <summary>
        /// The showWinnerForm.
        /// </summary>
        /// <param name="teamA">The teamA<see cref="TeamModel"/>.</param>
        /// <param name="teamB">The teamB<see cref="TeamModel"/>.</param>
        private void showWinnerForm(TeamModel teamA, TeamModel teamB)
        {
            CopaResultForm frm = new CopaResultForm(teamA, teamB);
            frm.Show();
        }

        /// <summary>
        /// The checkBox7_CheckedChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label12_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label12_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label30_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label30_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label21_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label21_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The btn_getTeams_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btn_getTeams_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            GetAllTeams();
            this.btn_getTeams.Enabled = false;
            this.btn_choseTeam.Enabled = true;
        }

        /// <summary>
        /// The GetAllTeams.
        /// </summary>
        private async void GetAllTeams()
        {

            URI = "https://raw.githubusercontent.com/delsonvictor/testetecnico/master/equipes.json";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var TeamJsonString = await response.Content.ReadAsStringAsync();
                        this.teams.AddRange(JsonConvert.DeserializeObject<TeamModel[]>(TeamJsonString));

                        foreach (TeamModel team in JsonConvert.DeserializeObject<TeamModel[]>(TeamJsonString))
                        {
                            listBox1.Items.Add(team.nome);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível consumir o json : " + response.StatusCode);
                    }
                }
            }
        }

        /// <summary>
        /// The TeamPicker_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void TeamPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The btn_choseTeam_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void btn_choseTeam_Click(object sender, EventArgs e)
        {
            choseTeam();
            if (this.teamsForCoup.Count.Equals(8))
            {
                btn_choseTeam.Enabled = false;
                btn_genCoup.Enabled = true;
            }
            updateLbl();
        }

        /// <summary>
        /// The updateLbl.
        /// </summary>
        private void updateLbl()
        {
            int aux = listBox2.Items.Count;
            lbl_count.Text = aux.ToString();
        }

        /// <summary>
        /// The choseTeam.
        /// </summary>
        private void choseTeam()
        {
            try
            {
                foreach (TeamModel team in this.teams)
                {
                    if (listBox1.SelectedItem.Equals(team.nome))
                    {
                        //Console.WriteLine(listBox1.SelectedItem);
                        //Console.WriteLine(team.nome);
                        this.teamForCoup = team;
                        break;
                    }
                    else
                    {
                        //Console.WriteLine("nada corresponde a equipe selecionada");
                    }
                }

            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine("nada selecionado");
            }

            try
            {
                if (!isEqual())
                {
                    try
                    {
                        this.teamsForCoup.Add(this.teamForCoup);
                        listBox2.Items.Add(this.teamForCoup.nome);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("nada selecionado");
                    }

                }
                else
                {
                    //Console.WriteLine("equipes iguais ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("nada selecionado");
            }
        }

        /// <summary>
        /// The isEqual.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool isEqual()
        {
            bool aux = false;
            foreach (TeamModel team in this.teamsForCoup)
            {
                if (team.id.Equals(this.teamForCoup.id))
                {
                    //Console.WriteLine(team.id);
                    // Console.WriteLine(this.teamForCoup.id);

                    aux = true;
                    break;
                }
                else
                {
                    aux = false;
                }
            }

            return aux;
        }

        /// <summary>
        /// The listBox2_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label5_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label5_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label6_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label6_Click(object sender, EventArgs e)
        {
        }
    }
}
