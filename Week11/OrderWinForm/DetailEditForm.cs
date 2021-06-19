using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderApp;

namespace OrderWinForm
{

    public partial class DetailEditForm : Form
    {
        public OrderDetail Detail { get; set; }

        public DetailEditForm()
        {
            InitializeComponent();
        }

        public DetailEditForm(OrderDetail detail) : this()
        {
            this.Detail = detail;
            this.detailbindingSource.DataSource = detail;
            goodbindingSource.Add(new Goods("1", "apple", 100.0));
            goodbindingSource.Add(new Goods("2", "egg", 200.0));
        }

    }
}
