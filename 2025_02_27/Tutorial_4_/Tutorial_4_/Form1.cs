namespace Tutorial_4_
{
    public partial class Form1 : Form
    {
        // Assuming averagelabel is a Label control, so changing its type to Label
        public Label averagelabel { get; private set; }
        public double distancelabel { get; private set; }
        public double gaslabel { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton1_Click(object sender, EventArgs e)
        {
            double distance, gas, average;

            // �T�O�Z���O���Ī��Ʀr
            if (double.TryParse(distancetextBox1.Text, out distance))
            {
                // �p�G���\�ѪR�Z���A��ܽոհT��
                MessageBox.Show($"Distance: {distance}");

                // �T�O�o�q�O���Ī��Ʀr
                if (!double.TryParse(gastextBox2.Text, out gas))
                {
                    MessageBox.Show("�п�J���Ī��Ʀr���o�q");
                    gastextBox2.Focus();    //�N��в���gasTextBox2
                    gastextBox2.Text = "";  //�M��
                }
                else
                {
                    // �p�G���\�ѪR�o�q�A��ܽոհT��
                    MessageBox.Show($"Gas: {gas}");

                    // �ˬd�o�q�O�_���s�A�קK���H�s���~
                    if (gas == 0)
                    {
                        MessageBox.Show("�o�q���ର�s");
                        gastextBox2.Focus();
                        gastextBox2.Text = "";  //�M��
                    }
                    else
                    {
                        // �p�⥭���o��
                        average = distance / gas;

                        // ���T�a��s Label ������ܭp�⵲�G
                        averagelabel.Text = $"{average:f2} ����/����"; // �ץ������覡�A�榡�����

                        // ��s loglistbox
                        loglistbox.Items.Add($"{average:f2} ����/����");

                        // ��ܭp�⵲�G�]�ոեΡ^
                        MessageBox.Show($"�p�⵲�G: {average:f2} ����/����");
                    }
                }
            }
            else
            {
                MessageBox.Show("�п�J���Ī��Ʀr�@�����{");
                distancetextBox1.Focus();    //�N��в���distancetextBox1
                distancetextBox1.Text = "";  //�M��
            }
        }

        private void ExitButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistbox.Items.Clear();
            loglistbox.Items.Add("�����o�Ӭ����G");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (loglistbox.Items.Count > 1)
            {
                loglistbox.Items.Add("�����o�Ӭ����G");
                for (int i = 1; i < loglistbox.Items.Count; i++)
                {
                    sum += double.Parse(loglistbox.Items[i].ToString().Replace("����/����", ""));
                }
                loglistbox.Items.Add($"�����o�ӡG{(sum / (loglistbox.Items.Count - 1)):f2} ����/����");
            }
            else
            {
                MessageBox.Show("�S������");
            }
        }
    }
}
