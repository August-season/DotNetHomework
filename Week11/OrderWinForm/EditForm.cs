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
    public partial class EditForm : Form
    {
        private OrderService orderService;
        private bool editModel;

        public Order CurrentOrder { get; set; }
        public Action<EditForm> CloseEditFrom { get; set; }

        public EditForm(Order order, bool model, OrderService orderService)
        {
            InitializeComponent();
            customerbindingSource.Add(new Customer("1", "li"));
            customerbindingSource.Add(new Customer("2", "zhang"));
            this.orderService = orderService;
            this.editModel = model;

            this.CurrentOrder = order;
            orderbindingSource.DataSource = CurrentOrder;

            txtOrderId.Enabled = !model;
            if (!model)
            {
                CurrentOrder.Customer = (Customer)customerbindingSource.Current;
            }
        }
        public EditForm()
        {
            InitializeComponent();
        }

        private void EditDetail()
        {
            OrderDetail detail = detailbindingSource.Current as OrderDetail;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            DetailEditForm formDetailEdit = new DetailEditForm(detail);
            if (formDetailEdit.ShowDialog() == DialogResult.OK)
            {
                detailbindingSource.ResetBindings(false);
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            DetailEditForm formItemEdit = new DetailEditForm(new OrderDetail());
            try
            {
                if (formItemEdit.ShowDialog() == DialogResult.OK)
                {
                    uint index = 0;
                    if (CurrentOrder.Details.Count != 0)
                    {
                        index = CurrentOrder.Details.Max(i => i.Index) + 1;
                    }
                    formItemEdit.Detail.Index = index;
                    CurrentOrder.AddItem(formItemEdit.Detail);
                    detailbindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            EditDetail();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            OrderDetail detail = detailbindingSource.Current as OrderDetail;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.RemoveDetail(detail);
            detailbindingSource.ResetBindings(false);
        }


    private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.editModel)
                {
                    orderService.UpdateOrder(CurrentOrder);
                }
                else
                {
                    orderService.AddOrder(CurrentOrder);
                }
                CloseEditFrom(this);
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}
