using System.Text;

namespace SnowflakeIdGen
{
    public partial class SnowflakeIdGenForm : Form
    {
        public SnowflakeIdGenForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SnowflakeGenerator generator = new SnowflakeGenerator(2);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                long decId = generator.GenerateId();
                string id = Base62Converter.ToBase62(decId);

                sb.AppendLine(id);

                byte[] test = Base62Converter.FromBase62ToBytes(id);
            }

            textBox1.Text = sb.ToString();
        }


    }
}
