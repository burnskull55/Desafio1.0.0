namespace DesafioTeams
{
    using DesafioClasses;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="CopaResultForm" />.
    /// </summary>
    public partial class CopaResultForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CopaResultForm"/> class.
        /// </summary>
        /// <param name="teamA">The teamA<see cref="TeamModel"/>.</param>
        /// <param name="teamB">The teamB<see cref="TeamModel"/>.</param>
        public CopaResultForm(TeamModel teamA, TeamModel teamB)
        {
            InitializeComponent();
            lbl_first.Text = "1º lugar " + teamA.nome;
            lbl_second.Text = "2º lugar " + teamB.nome;
        }

        /// <summary>
        /// The CopaResultForm_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void CopaResultForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The panel2_Paint.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="PaintEventArgs"/>.</param>
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// The label4_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
