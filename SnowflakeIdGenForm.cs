using System.Text;

namespace SnowflakeIdGen
{
	public partial class SnowflakeIdGenForm : Form
	{
		public SnowflakeIdGenForm()
		{
			InitializeComponent();
		}


		private void Generate()
		{
			SnowflakeGenerator generator = new SnowflakeGenerator(2);

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < 10; i++)
			{
				long decId = generator.GenerateIdNumber();

				if (radioSnowflake.Checked)
				{
					sb.AppendLine(decId.ToString());
				}
				else if (radioSnowflakeBase62.Checked)
				{
					string id = Base62Converter.ToBase62(decId);

					byte[] test = Base62Converter.FromBase62ToBytes(id);

					sb.AppendLine(id);
				}
				else if (radioGuid.Checked)
				{
					sb.AppendLine(Guid.NewGuid().ToString());
				}


			}

			textBox1.Text = sb.ToString();
		}


		private void btnGenerate_Click(object sender, EventArgs e)
		{
			Generate();
		}


		private void radioSnowflake_CheckedChanged(object sender, EventArgs e)
		{
			Generate();
		}

		private void radioGuid_CheckedChanged(object sender, EventArgs e)
		{
			Generate();
		}

		private void radioSnowflakeBase62_CheckedChanged(object sender, EventArgs e)
		{
			Generate();
		}

		private void SnowflakeIdGenForm_Load(object sender, EventArgs e)
		{
			Generate();
		}
	}
}
