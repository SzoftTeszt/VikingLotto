using Kozos;

namespace Simulation
{
    public partial class Form1 : Form
    {
        private List<int> tippek = new List<int>();
        private VikingContext context = new VikingContext();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSorsol.Enabled = false;
            this.Size = new Size(700, 480);
            panel.Left = 30;
            panel.Top = 30;
            panel.Size = new Size(490, 360);
            panel.BackColor = Color.White;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    CheckBox box = new CheckBox();
                    box.Left = j * 55 + 30;
                    box.Top = i * 55 + 30;
                    box.AutoSize = true;
                    box.Text = (i * 8 + j + 1).ToString();
                    box.CheckedChanged += checkBox1_CheckedChanged;
                    this.panel.Controls.Add(box);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("A checkbox állapota megváltozott.");



            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                tippek.Add(int.Parse(box.Text));
                if (tippek.Count == 6)
                {
                    btnSorsol.Enabled = true;
                    foreach (Control control in panel.Controls)
                    {
                        if (control is CheckBox checkBox && !checkBox.Checked)
                        {
                            checkBox.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                tippek.Remove(int.Parse(box.Text));
                if (tippek.Count == 5)
                {
                    btnSorsol.Enabled = false;
                    foreach (Control control in panel.Controls)
                    {
                        if (control is CheckBox checkBox)
                        {
                            control.Enabled = true;
                        }
                    }
                }


            }
        }

        private void btnSorsol_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            HashSet<int> halmaz = new HashSet<int>();

            do
            {
                halmaz.Add(rnd.Next(1, 7));
                //halmaz.Add(rnd.Next(1, 49));
            } while (halmaz.Count < 6);

            label1.Text ="Kisorsolt számok:\n"+ string.Join(", ", halmaz.OrderBy(x=>x))+"\nTippeid:\n"+ string.Join(", ", tippek.OrderBy(x => x))+"\n"+halmaz.Intersect(tippek).Count()+" találatod volt";

            context.LottoSzamok.Add(
                new Szamok(string.Join(";", halmaz.OrderBy(x=>x))));
            context.SaveChanges();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            context.Dispose();
            base.OnFormClosing(e);
        }
    }
}
