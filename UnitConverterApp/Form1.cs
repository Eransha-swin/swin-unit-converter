using System;
using System.IO;
using System.Windows.Forms;
using ConverterCore;

namespace UnitConverterApp
{
    public partial class Form1 : Form
    {
        private readonly TextBox _value = new TextBox();
        private readonly ComboBox _from = new ComboBox();
        private readonly ComboBox _to = new ComboBox();
        private readonly Label _result = new Label();
        private UnitConverter _converter;

        public Form1()
        {
            InitializeComponent();

            Text = "Swinburne Unit Converter";
            Width = 380;
            Height = 230;

            _value.SetBounds(20, 20, 320, 24);
            _value.Text = "1";

            _from.SetBounds(20, 60, 150, 24);
            _to.SetBounds(190, 60, 150, 24);
            _from.DropDownStyle = ComboBoxStyle.DropDownList;
            _to.DropDownStyle = ComboBoxStyle.DropDownList;

            _result.SetBounds(20, 140, 320, 40);

            Button convert = new Button();
            convert.SetBounds(20, 100, 320, 30);
            convert.Text = "Convert";
            convert.Click += OnConvert;

            Controls.AddRange(new Control[] { _value, _from, _to, convert, _result });

            LoadRates();
        }

        private void LoadRates()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rates.json");
                _converter = new UnitConverter(RateTable.Load(path));

                foreach (string unit in _converter.Units)
                {
                    _from.Items.Add(unit);
                    _to.Items.Add(unit);
                }

                _from.SelectedIndex = 0;
                _to.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                _result.Text = "Startup error: " + ex.Message;
            }
        }

        private void OnConvert(object sender, EventArgs e)
        {
            double input;
            if (!double.TryParse(_value.Text, out input))
            {
                _result.Text = "Enter a valid number.";
                return;
            }

            double output = _converter.Convert(input, _from.Text, _to.Text);
            _result.Text = string.Format("{0} {1} = {2:G6} {3}", input, _from.Text, output, _to.Text);
        }
    }
}