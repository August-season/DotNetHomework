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
    public partial class MainForm : Form
    {
        OrderService orderService;
        BindingSource bdsFields = new BindingSource();
        public Action<EditForm> ShowEditForm { get; set; }
        public String Keyword { get; set; }
        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService();
            Order order = new Order(1, new Customer("1", "li"), new List<OrderDetail>());
            order.AddItem(new OrderDetail(1, new Goods("1", "apple", 100.0), 10));
            order.AddItem(new OrderDetail(2, new Goods("2", "egg", 50.0), 61));
            orderService.AddOrder(order);
            Order order2 = new Order(2, new Customer("2", "zhang"), new List<OrderDetail>());
            order2.AddItem(new OrderDetail(1, new Goods("2", "egg", 200.0), 10));
            orderService.AddOrder(order2);
            orderbindingSource.DataSource = orderService.Orders;
            cbxField.SelectedIndex = 0;
            txtKeyword.DataBindings.Add("Text", this, "Keyword");
        }

        private void EditOrder()
        {
            Order order = orderbindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            EditForm form2 = new EditForm(order, true, orderService);
            ShowEditForm(form2);
        }

        public void QueryAll()
        {
            orderbindingSource.DataSource = orderService.Orders;
            orderbindingSource.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditForm formEdit = new EditForm(new Order(), false, orderService);
            ShowEditForm(formEdit);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            EditOrder();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order order = orderbindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            orderService.RemoveOrder(order.OrderId);
            QueryAll();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            switch (cbxField.SelectedIndex)
            {
                case 0://所有订单
                    orderbindingSource.DataSource = orderService.Orders;
                    break;
                case 1://根据ID查询
                    int.TryParse(Keyword, out int id);
                    Order order = orderService.GetOrder(id);
                    List<Order> result = new List<Order>();
                    if (order != null) result.Add(order);
                    orderbindingSource.DataSource = result;
                    break;
                case 2://根据客户查询
                    orderbindingSource.DataSource = orderService.QueryOrdersByCustomerName(Keyword);
                    break;
                case 3://根据货物查询
                    orderbindingSource.DataSource = orderService.QueryOrdersByGoodsName(Keyword);
                    break;
                case 4://根据总价格查询（大于某个总价）
                    float.TryParse(Keyword, out float totalPrice);
                    orderbindingSource.DataSource =
                           orderService.QueryByTotalAmount(totalPrice);
                    break;
            }
            orderbindingSource.ResetBindings(false);

        }
    }
}