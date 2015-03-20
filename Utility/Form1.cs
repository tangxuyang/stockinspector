using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Utility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Translate_Click(object sender, EventArgs e)
        {
            try
            {
                string str = tb_input.Text;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(str);
                GenerateStock(doc);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void GenerateStock(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            /*
             <ul class="seo_pageList" id="index_data_0">
		<li>
			<span>
				<a href="/gs/sh_600000.shtml">600000</a>
			</span><a href="http://stock.quote.stockstar.com/600000.shtml">浦发银行</a>
		</li></ul>
             */
            XmlElement root = doc.DocumentElement;
            foreach(XmlNode ul in root.ChildNodes)
            {
                foreach(XmlNode li in ul.ChildNodes)
                {
                    sb.AppendLine(li.FirstChild.FirstChild.InnerText+"|"+li.LastChild.InnerText);
                }
            }

            tb_Output.Text = sb.ToString();
        }
    }
}
